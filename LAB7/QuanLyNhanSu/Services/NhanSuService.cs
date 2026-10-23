using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class TuyenDungService
    {
        public void TuyenDung(
            string nv,
            string ten,
            DateTime sinh,
            string dt,
            string dc,
            string pb,
            string qd,
            DateTime ngay,
            DateTime tu,
            DateTime den,
            decimal luong,
            string dk,
            string ky
        )
        {
            Rules.Text(nv, "Mã NV");
            Rules.Text(ten, "Họ tên", 120);
            Rules.Text(pb, "Phòng ban");
            Rules.Text(qd, "Số QĐ");
            Rules.Text(dk, "Điều khoản", 1000);
            Rules.Text(ky, "Người ký", 120);
            Rules.Need(
                sinh.Date < DateTime.Today
                    && tu.Date <= den.Date
                    && ngay.Date <= tu.Date
                    && luong > 0,
                "Ngày hoặc lương thử việc không hợp lệ."
            );
            Db.Transaction(
                (c, t) =>
                {
                    Rules.DecisionDate(c, t, tu);
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO NhanVien
                            VALUES (@n, @ten, @s, @dt, @dc, @p, 'ThuViec');
                        ",
                        Db.P("@n", nv),
                        Db.P("@ten", ten),
                        Db.P("@s", sinh.Date),
                        Db.P("@dt", dt),
                        Db.P("@dc", dc),
                        Db.P("@p", pb)
                    );
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO QuyetDinhTuyenDung (
                                SoQD, MaNV, NgayQD, TuNgay, DenNgay,
                                LuongThuViec, DieuKhoan, NguoiKy
                            )
                            VALUES                        (@q, @n, @d, @tu, @den, @l, @dk, @k);
                        ",
                        Db.P("@q", qd),
                        Db.P("@n", nv),
                        Db.P("@d", ngay.Date),
                        Db.P("@tu", tu.Date),
                        Db.P("@den", den.Date),
                        Db.P("@l", luong),
                        Db.P("@dk", dk),
                        Db.P("@k", ky)
                    );
                }
            );
        }

        public void DanhGia(string nv, bool dat)
        {
            Db.Transaction(
                (c, t) =>
                {
                    Rules.Employee(c, t, nv);
                    var d = Db.Query(
                        c,
                        t,
                        @"
                            SELECT *
                            FROM QuyetDinhTuyenDung
                            WHERE MaNV = @n;
                        ",
                        Db.P("@n", nv)
                    );
                    Rules.Need(
                        d.Rows.Count == 1
                            && d.Rows[0]["KetQua"].ToString() == "ChoDanhGia"
                            && Convert.ToDateTime(d.Rows[0]["DenNgay"]) < DateTime.Today,
                        "Chỉ đánh giá sau ngày kết thúc và chưa đánh giá."
                    );
                    Db.Execute(
                        c,
                        t,
                        @"
                            UPDATE QuyetDinhTuyenDung
                            SET KetQua = @k
                            WHERE MaNV = @n;
                        ",
                        Db.P("@k", dat ? "Dat" : "KhongDat"),
                        Db.P("@n", nv)
                    );
                    if (!dat)
                        Db.Execute(
                            c,
                            t,
                            @"
                                UPDATE NhanVien
                                SET TrangThai = 'KhongDat'
                                WHERE MaNV = @n;
                            ",
                            Db.P("@n", nv)
                        );
                }
            );
        }
    }

    public class HopDongService
    {
        public void KyHopDong(
            string hd,
            string nv,
            string loai,
            DateTime ngay,
            DateTime tu,
            DateTime? den,
            string dk,
            string ky,
            string ql,
            decimal l,
            decimal pc,
            decimal dh,
            string qc,
            string cv,
            decimal pccv,
            string xh,
            string yt,
            decimal rx,
            decimal ry
        )
        {
            foreach (var x in new[] { hd, nv, ql, qc, cv })
                Rules.Text(x, "Mã/số quyết định");
            Rules.Text(dk, "Điều khoản", 1000);
            Rules.Text(ky, "Người ký", 120);
            Rules.Need(
                (loai == "DaiHan" && !den.HasValue)
                    || (loai == "NganHan" && den.HasValue && den.Value.Date >= tu.Date),
                "Loại hoặc ngày hết hạn hợp đồng sai."
            );
            Rules.Need(
                ngay.Date <= tu.Date && l > 0 && pc >= 0 && dh >= 0 && pccv >= 0,
                "Ngày ký, lương hoặc phụ cấp sai."
            );
            bool bh =
                loai == "DaiHan"
                || !string.IsNullOrWhiteSpace(xh)
                || !string.IsNullOrWhiteSpace(yt);
            if (bh)
            {
                Rules.Text(xh, "BHXH", 30);
                Rules.Text(yt, "BHYT", 30);
                Rules.Need(
                    rx >= 0 && ry >= 0 && rx + ry <= 1,
                    "Tỷ lệ bảo hiểm trong [0,1], tổng không quá 1."
                );
            }
            Db.Transaction(
                (c, t) =>
                {
                    Rules.Employee(c, t, nv);
                    Rules.DecisionDate(c, t, tu);
                    var q = Db.Query(
                        c,
                        t,
                        @"
                            SELECT *
                            FROM QuyetDinhTuyenDung
                            WHERE MaNV = @n;
                        ",
                        Db.P("@n", nv)
                    );
                    Rules.Need(
                        q.Rows.Count == 1
                            && q.Rows[0]["KetQua"].ToString() == "Dat"
                            && Convert.ToDateTime(q.Rows[0]["DenNgay"]) < ngay.Date,
                        "Phải đạt thử việc và ký sau khi kết thúc thử việc."
                    );
                    Rules.Need(
                        Convert.ToInt32(
                            Db.Scalar(
                                c,
                                t,
                                @"
                                    SELECT COUNT(*)
                                    FROM HopDong
                                    WHERE MaNV = @n
                                          AND TuNgay <= @end
                                          AND (DenNgay IS NULL
                                               OR DenNgay >= @tu);
                                ",
                                Db.P("@n", nv),
                                Db.P("@end", den ?? new DateTime(9999, 12, 31)),
                                Db.P("@tu", tu.Date)
                            )
                        ) == 0,
                        "Hợp đồng trùng thời hạn."
                    );
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO HopDong
                            VALUES (@h, @n, @lo, @ng, @tu, @den, @dk, @k);
                        ",
                        Db.P("@h", hd),
                        Db.P("@n", nv),
                        Db.P("@lo", loai),
                        Db.P("@ng", ngay.Date),
                        Db.P("@tu", tu.Date),
                        Db.P("@den", den),
                        Db.P("@dk", dk),
                        Db.P("@k", ky)
                    );
                    if (bh)
                        Db.Execute(
                            c,
                            t,
                            @"
                                INSERT INTO HoSoBaoHiem
                                VALUES (@h, @x, @y, @rx, @ry);
                            ",
                            Db.P("@h", hd),
                            Db.P("@x", xh),
                            Db.P("@y", yt),
                            Db.P("@rx", rx),
                            Db.P("@ry", ry)
                        );
                    QuyetDinhService.Luong(c, t, ql, nv, tu, l, pc, dh, ky);
                    QuyetDinhService.ChucVu(c, t, qc, nv, cv, tu, pccv, ky);
                    Db.Execute(
                        c,
                        t,
                        @"
                            UPDATE NhanVien
                            SET TrangThai = 'ChinhThuc'
                            WHERE MaNV = @n;
                        ",
                        Db.P("@n", nv)
                    );
                }
            );
        }
    }

    public class QuyetDinhService
    {
        internal static void Luong(
            SqlConnection c,
            SqlTransaction t,
            string q,
            string nv,
            DateTime d,
            decimal l,
            decimal pc,
            decimal dh,
            string ky
        )
        {
            Db.Execute(
                c,
                t,
                @"
                    INSERT INTO QuyetDinhLuong
                    VALUES (@q, @n, @d, @l, @pc, @dh, @k);
                ",
                Db.P("@q", q),
                Db.P("@n", nv),
                Db.P("@d", d.Date),
                Db.P("@l", l),
                Db.P("@pc", pc),
                Db.P("@dh", dh),
                Db.P("@k", ky)
            );
        }

        internal static void ChucVu(
            SqlConnection c,
            SqlTransaction t,
            string q,
            string nv,
            string cv,
            DateTime d,
            decimal pc,
            string ky
        )
        {
            Db.Execute(
                c,
                t,
                @"
                    INSERT INTO QuyetDinhChucVu
                    VALUES (@q, @n, @cv, @d, @pc, @k);
                ",
                Db.P("@q", q),
                Db.P("@n", nv),
                Db.P("@cv", cv),
                Db.P("@d", d.Date),
                Db.P("@pc", pc),
                Db.P("@k", ky)
            );
        }

        public void DoiLuong(
            string q,
            string nv,
            DateTime d,
            decimal l,
            decimal pc,
            decimal dh,
            string ky
        )
        {
            Rules.Text(q, "QĐ");
            Rules.Text(ky, "Người ký", 120);
            Rules.Need(l > 0 && pc >= 0 && dh >= 0, "Lương/phụ cấp không hợp lệ.");
            Db.Transaction(
                (c, t) =>
                {
                    Rules.CanWork(c, t, nv, d);
                    Rules.DecisionDate(c, t, d);
                    Rules.Need(
                        Convert.ToInt32(
                            Db.Scalar(
                                c,
                                t,
                                @"
                                    SELECT COUNT(*)
                                    FROM HopDong
                                    WHERE MaNV = @n
                                          AND TuNgay <= @d
                                          AND (DenNgay IS NULL
                                               OR DenNgay >= @d);
                                ",
                                Db.P("@n", nv),
                                Db.P("@d", d.Date)
                            )
                        ) == 1,
                        "Cần hợp đồng hiệu lực."
                    );
                    Luong(c, t, q, nv, d, l, pc, dh, ky);
                }
            );
        }

        public void BoNhiem(string q, string nv, string cv, DateTime d, decimal pc, string ky)
        {
            Rules.Text(q, "QĐ");
            Rules.Text(ky, "Người ký", 120);
            Rules.Need(pc >= 0, "Phụ cấp không âm.");
            Db.Transaction(
                (c, t) =>
                {
                    Rules.CanWork(c, t, nv, d);
                    Rules.DecisionDate(c, t, d);
                    Rules.Need(
                        Convert.ToInt32(
                            Db.Scalar(
                                c,
                                t,
                                @"
                                    SELECT COUNT(*)
                                    FROM HopDong
                                    WHERE MaNV = @n
                                          AND TuNgay <= @d
                                          AND (DenNgay IS NULL
                                               OR DenNgay >= @d);
                                ",
                                Db.P("@n", nv),
                                Db.P("@d", d.Date)
                            )
                        ) == 1,
                        "Cần hợp đồng hiệu lực."
                    );
                    ChucVu(c, t, q, nv, cv, d, pc, ky);
                }
            );
        }
    }

    public class DanhMucService
    {
        public void Phong(string ma, string ten)
        {
            Rules.Text(ma, "Mã");
            Rules.Text(ten, "Tên", 120);
            Db.Transaction(
                (c, t) =>
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO PhongBan
                            VALUES (@m, @t);
                        ",
                        Db.P("@m", ma),
                        Db.P("@t", ten)
                    )
            );
        }

        public void ChucVu(string ma, string ten)
        {
            Rules.Text(ma, "Mã");
            Rules.Text(ten, "Tên", 120);
            Db.Transaction(
                (c, t) =>
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO ChucVu
                            VALUES (@m, @t);
                        ",
                        Db.P("@m", ma),
                        Db.P("@t", ten)
                    )
            );
        }

        public void Ca(string ma, string ten, decimal gio)
        {
            Rules.Text(ma, "Mã");
            Rules.Text(ten, "Tên", 100);
            Rules.Need(gio > 0 && gio <= 24, "Giờ chuẩn sai.");
            Db.Transaction(
                (c, t) =>
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO CaLam
                            VALUES (@m, @t, @g);
                        ",
                        Db.P("@m", ma),
                        Db.P("@t", ten),
                        Db.P("@g", gio)
                    )
            );
        }
    }
}
