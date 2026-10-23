using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class ThuongPhatService
    {
        public void Lap(
            string q,
            string loai,
            string nv,
            string pb,
            DateTime ngay,
            DateTime ky,
            string nd,
            decimal tien,
            string ht,
            string nguoiky,
            List<PhanBo> ds
        )
        {
            Rules.Text(q, "Số quyết định");
            Rules.Text(nd, "Nội dung", 1000);
            Rules.Text(nguoiky, "Giám đốc ký", 120);
            bool cn = !string.IsNullOrWhiteSpace(nv);
            bool tt = !string.IsNullOrWhiteSpace(pb);
            Rules.Need(cn != tt, "Chọn đúng một đối tượng cá nhân hoặc tập thể.");
            Rules.Need(
                new[] { "Thuong", "Phat" }.Contains(loai)
                    && new[] { "QuaLuong", "TrucTiep" }.Contains(ht),
                "Loại/hình thức sai."
            );
            Rules.Need(
                tien > 0
                    && ds != null
                    && ds.Count > 0
                    && ds.All(x => x.SoTien > 0)
                    && ds.Sum(x => x.SoTien) == tien
                    && ds.Select(x => x.MaNV).Distinct().Count() == ds.Count,
                "Phân bổ phải dương, không trùng NV và tổng bằng số tiền quyết định."
            );
            if (cn)
                Rules.Need(
                    ds.Count == 1 && ds[0].MaNV == nv,
                    "Quyết định cá nhân phải phân bổ đúng nhân viên."
                );
            Db.Transaction(
                (c, t) =>
                {
                    Rules.OpenMonth(c, t, ky);
                    foreach (var x in ds)
                    {
                        var e = Rules.Employee(c, t, x.MaNV);
                        Rules.Need(
                            e["TrangThai"].ToString() != "KhongDat"
                                && (!tt || e["MaPB"].ToString() == pb),
                            "Nhân viên không hợp lệ hoặc ngoài tập thể."
                        );
                    }
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO QuyetDinhThuongPhat
                            VALUES (@q, @l, @n, @p, @d, @ky, @nd, @s, @ht, @k);
                        ",
                        Db.P("@q", q),
                        Db.P("@l", loai),
                        Db.P("@n", cn ? nv : null),
                        Db.P("@p", tt ? pb : null),
                        Db.P("@d", ngay.Date),
                        Db.P("@ky", new DateTime(ky.Year, ky.Month, 1)),
                        Db.P("@nd", nd),
                        Db.P("@s", tien),
                        Db.P("@ht", ht),
                        Db.P("@k", nguoiky)
                    );
                    foreach (var x in ds)
                        Db.Execute(
                            c,
                            t,
                            @"
                                INSERT INTO ChiTietThuongPhat (SoQD, MaNV, SoTien)
                                VALUES                       (@q, @n, @s);
                            ",
                            Db.P("@q", q),
                            Db.P("@n", x.MaNV),
                            Db.P("@s", x.SoTien)
                        );
                }
            );
        }

        public void ThuChi(string phieu, string q, DateTime ngay)
        {
            Rules.Text(phieu, "Số phiếu");
            Db.Transaction(
                (c, t) =>
                {
                    var d = Db.Query(
                        c,
                        t,
                        @"
                            SELECT *
                            FROM QuyetDinhThuongPhat WITH (UPDLOCK, HOLDLOCK)
                            WHERE SoQD = @q;
                        ",
                        Db.P("@q", q)
                    );
                    Rules.Need(
                        d.Rows.Count == 1 && d.Rows[0]["HinhThuc"].ToString() == "TrucTiep",
                        "Chỉ lập thủ công cho quyết định thu/chi trực tiếp; qua lương sinh phiếu khi chốt."
                    );
                    Rules.Need(
                        ngay.Date >= Convert.ToDateTime(d.Rows[0]["NgayQD"]),
                        "Ngày thu/chi trước quyết định."
                    );
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO PhieuThuChi (SoPhieu, SoQD, Ngay, Loai, SoTien)
                            VALUES                 (@p, @q, @d, @l, @s);
                        ",
                        Db.P("@p", phieu),
                        Db.P("@q", q),
                        Db.P("@d", ngay.Date),
                        Db.P("@l", d.Rows[0]["Loai"].ToString() == "Thuong" ? "Chi" : "Thu"),
                        Db.P("@s", d.Rows[0]["SoTien"])
                    );
                }
            );
        }
    }
}
