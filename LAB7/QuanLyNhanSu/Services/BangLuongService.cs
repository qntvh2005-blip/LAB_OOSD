using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class BangLuongService
    {
        internal decimal[] Rate(SqlConnection c, SqlTransaction t, string nv, DateTime d)
        {
            var hd = Db.Query(
                c,
                t,
                @"
                    SELECT TOP (1) SoHD,
                                   LoaiHD
                    FROM HopDong
                    WHERE MaNV = @n
                          AND TuNgay <= @d
                          AND (DenNgay IS NULL
                               OR DenNgay >= @d)
                    ORDER BY TuNgay DESC;
                ",
                Db.P("@n", nv),
                Db.P("@d", d.Date)
            );
            if (hd.Rows.Count == 0)
            {
                var tv = Db.Query(
                    c,
                    t,
                    @"
                        SELECT LuongThuViec
                        FROM QuyetDinhTuyenDung
                        WHERE MaNV = @n
                              AND @d BETWEEN TuNgay AND DenNgay;
                    ",
                    Db.P("@n", nv),
                    Db.P("@d", d.Date)
                );
                Rules.Need(
                    tv.Rows.Count == 1,
                    "Thiếu căn cứ lương ngày " + d.ToString("dd/MM/yyyy") + " của " + nv
                );
                return new[] { Convert.ToDecimal(tv.Rows[0][0]), 0m, 0m, 0m };
            }
            var lu = Db.Query(
                c,
                t,
                @"
                    SELECT TOP (1) *
                    FROM QuyetDinhLuong
                    WHERE MaNV = @n
                          AND NgayHieuLuc <= @d
                    ORDER BY NgayHieuLuc DESC;
                ",
                Db.P("@n", nv),
                Db.P("@d", d.Date)
            );
            var cv = Db.Query(
                c,
                t,
                @"
                    SELECT TOP (1) *
                    FROM QuyetDinhChucVu
                    WHERE MaNV = @n
                          AND NgayHieuLuc <= @d
                    ORDER BY NgayHieuLuc DESC;
                ",
                Db.P("@n", nv),
                Db.P("@d", d.Date)
            );
            Rules.Need(
                lu.Rows.Count == 1 && cv.Rows.Count == 1,
                "Thiếu quyết định lương hoặc chức vụ."
            );
            var bh = Db.Query(
                c,
                t,
                @"
                    SELECT *
                    FROM HoSoBaoHiem
                    WHERE SoHD = @h;
                ",
                Db.P("@h", hd.Rows[0]["SoHD"])
            );
            Rules.Need(
                hd.Rows[0]["LoaiHD"].ToString() != "DaiHan" || bh.Rows.Count == 1,
                "Hợp đồng dài hạn thiếu hồ sơ bảo hiểm."
            );
            return new[]
            {
                Convert.ToDecimal(lu.Rows[0]["LuongCoBan"]),
                Convert.ToDecimal(lu.Rows[0]["PhuCapLuong"])
                    + Convert.ToDecimal(lu.Rows[0]["PhuCapDocHai"])
                    + Convert.ToDecimal(cv.Rows[0]["PhuCapChucVu"]),
                bh.Rows.Count == 0 ? 0m : Convert.ToDecimal(bh.Rows[0]["TyLeBHXH"]),
                bh.Rows.Count == 0 ? 0m : Convert.ToDecimal(bh.Rows[0]["TyLeBHYT"]),
            };
        }

        public void Lap(string ma, int thang, int nam, decimal chuan)
        {
            Rules.Text(ma, "Mã bảng lương");
            Rules.Need(
                thang >= 1 && thang <= 12 && nam >= 2000 && nam <= 2100 && chuan > 0,
                "Tháng/năm/giờ chuẩn không hợp lệ."
            );
            var dau = new DateTime(nam, thang, 1);
            var cuoi = dau.AddMonths(1);
            Db.Transaction(
                (c, t) =>
                {
                    Rules.OpenMonth(c, t, dau);
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO BangLuong (MaBL, Thang, Nam, GioChuan)
                            VALUES               (@b, @m, @y, @g);
                        ",
                        Db.P("@b", ma),
                        Db.P("@m", thang),
                        Db.P("@y", nam),
                        Db.P("@g", chuan)
                    );
                    var nvs = Db.Query(
                        c,
                        t,
                        @"
                                                 SELECT MaNV
                                                 FROM NhanVien
                                                 ORDER BY MaNV;
                                             "
                    );
                    Rules.Need(nvs.Rows.Count > 0, "Chưa có nhân viên.");
                    foreach (DataRow nvrow in nvs.Rows)
                    {
                        string nv = nvrow[0].ToString();
                        decimal gio = 0,
                            ot = 0,
                            luong = 0,
                            phutroi = 0,
                            bhx = 0,
                            bhy = 0;
                        var cong = Db.Query(
                            c,
                            t,
                            @"
                                SELECT p.Ngay,
                                       c.GioThucTe
                                FROM ChamCong AS c
                                     INNER JOIN
                                     PhanCongCa AS p
                                     ON p.Id = c.IdPhanCong
                                WHERE p.MaNV = @n
                                      AND p.Ngay >= @d
                                      AND p.Ngay < @e;
                            ",
                            Db.P("@n", nv),
                            Db.P("@d", dau),
                            Db.P("@e", cuoi)
                        );
                        foreach (DataRow r in cong.Rows)
                        {
                            decimal h = Convert.ToDecimal(r["GioThucTe"]);
                            var a = Rate(c, t, nv, Convert.ToDateTime(r["Ngay"]));
                            gio += h;
                            luong += (a[0] + a[1]) * h / chuan;
                            bhx += a[0] * h / chuan * a[2];
                            bhy += a[0] * h / chuan * a[3];
                        }
                        var pt = Db.Query(
                            c,
                            t,
                            @"
                                SELECT p.Ngay,
                                       ct.SoGio
                                FROM ChiTietPhuTroi AS ct
                                     INNER JOIN
                                     PhieuPhuTroi AS p
                                     ON p.SoPhieu = ct.SoPhieu
                                WHERE ct.MaNV = @n
                                      AND p.Ngay >= @d
                                      AND p.Ngay < @e;
                            ",
                            Db.P("@n", nv),
                            Db.P("@d", dau),
                            Db.P("@e", cuoi)
                        );
                        foreach (DataRow r in pt.Rows)
                        {
                            decimal h = Convert.ToDecimal(r["SoGio"]);
                            var a = Rate(c, t, nv, Convert.ToDateTime(r["Ngay"]));
                            ot += h;
                            phutroi += a[0] / chuan * h * 1.5m;
                        }
                        decimal thuong = 0,
                            phat = 0;
                        var tp = Db.Query(
                            c,
                            t,
                            @"
                                SELECT d.Loai,
                                       ct.SoTien
                                FROM ChiTietThuongPhat AS ct
                                     INNER JOIN
                                     QuyetDinhThuongPhat AS d
                                     ON d.SoQD = ct.SoQD
                                WHERE ct.MaNV = @n
                                      AND ct.MaBL IS NULL
                                      AND d.HinhThuc = 'QuaLuong'
                                      AND d.KyApDung = @d;
                            ",
                            Db.P("@n", nv),
                            Db.P("@d", dau)
                        );
                        foreach (DataRow r in tp.Rows)
                        {
                            if (r["Loai"].ToString() == "Thuong")
                                thuong += Convert.ToDecimal(r["SoTien"]);
                            else
                                phat += Convert.ToDecimal(r["SoTien"]);
                        }
                        luong = Rules.Money(luong);
                        phutroi = Rules.Money(phutroi);
                        bhx = Rules.Money(bhx);
                        bhy = Rules.Money(bhy);
                        thuong = Rules.Money(thuong);
                        phat = Rules.Money(phat);
                        decimal net = luong + phutroi + thuong - phat - bhx - bhy;
                        Rules.Need(
                            net >= 0,
                            "Thực lĩnh âm tại " + nv + "; cần điều chỉnh khoản phạt trước chốt."
                        );
                        Db.Execute(
                            c,
                            t,
                            @"
                                INSERT INTO ChiTietBangLuong
                                VALUES (@b, @n, @g, @ot, @l, @pt, @x, @y, @th, @p, @net);
                            ",
                            Db.P("@b", ma),
                            Db.P("@n", nv),
                            Db.P("@g", gio),
                            Db.P("@ot", ot),
                            Db.P("@l", luong),
                            Db.P("@pt", phutroi),
                            Db.P("@x", bhx),
                            Db.P("@y", bhy),
                            Db.P("@th", thuong),
                            Db.P("@p", phat),
                            Db.P("@net", net)
                        );
                        Db.Execute(
                            c,
                            t,
                            @"
                                UPDATE ct
                                SET MaBL = @b
                                FROM ChiTietThuongPhat AS ct
                                     INNER JOIN
                                     QuyetDinhThuongPhat AS d
                                     ON d.SoQD = ct.SoQD
                                WHERE ct.MaNV = @n
                                      AND ct.MaBL IS NULL
                                      AND d.HinhThuc = 'QuaLuong'
                                      AND d.KyApDung = @d;
                            ",
                            Db.P("@b", ma),
                            Db.P("@n", nv),
                            Db.P("@d", dau)
                        );
                    }
                    var vouchers = Db.Query(
                        c,
                        t,
                        @"
                            SELECT q.*
                            FROM QuyetDinhThuongPhat AS q
                            WHERE q.HinhThuc = 'QuaLuong'
                                  AND q.KyApDung = @d
                                  AND NOT EXISTS (SELECT 1
                                                  FROM ChiTietThuongPhat AS ct
                                                  WHERE ct.SoQD = q.SoQD
                                                        AND (ct.MaBL IS NULL
                                                             OR ct.MaBL <> @b));
                        ",
                        Db.P("@d", dau),
                        Db.P("@b", ma)
                    );
                    foreach (DataRow q in vouchers.Rows)
                        Db.Execute(
                            c,
                            t,
                            @"
                                INSERT INTO PhieuThuChi
                                VALUES (@p, @q, @d, @l, @s, @b);
                            ",
                            Db.P("@p", "PT" + Guid.NewGuid().ToString("N").Substring(0, 18)),
                            Db.P("@q", q["SoQD"]),
                            Db.P("@d", DateTime.Today),
                            Db.P("@l", q["Loai"].ToString() == "Thuong" ? "Chi" : "Thu"),
                            Db.P("@s", q["SoTien"]),
                            Db.P("@b", ma)
                        );
                }
            );
        }

        public DataTable Xem()
        {
            return Db.Query(
                @"
                    SELECT b.Nam,
                           b.Thang,
                           n.HoTen,
                           c.*
                    FROM ChiTietBangLuong AS c
                         INNER JOIN
                         BangLuong AS b
                         ON b.MaBL = c.MaBL
                         INNER JOIN
                         NhanVien AS n
                         ON n.MaNV = c.MaNV
                    ORDER BY b.Nam DESC, b.Thang DESC, n.MaNV;
                "
            );
        }
    }
}
