using System;
using System.Collections.Generic;
using System.Linq;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class KeHoachService
    {
        public void Lap(string ma, string pb, DateTime dau, string nguoilap, List<PhanCong> ds)
        {
            Rules.Text(ma, "Mã kế hoạch");
            Rules.Text(nguoilap, "Người lập", 120);
            Rules.Need(
                dau.DayOfWeek == DayOfWeek.Monday && ds != null && ds.Count > 0,
                "Đầu tuần phải thứ Hai, có ít nhất một phân công."
            );
            Db.Transaction(
                (c, t) =>
                {
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO KeHoachTuan
                            VALUES (@m, @p, @d, @n);
                        ",
                        Db.P("@m", ma),
                        Db.P("@p", pb),
                        Db.P("@d", dau.Date),
                        Db.P("@n", nguoilap)
                    );
                    foreach (var x in ds)
                    {
                        Rules.Need(
                            x.Ngay.Date >= dau.Date && x.Ngay.Date < dau.Date.AddDays(7),
                            "Ngày phân công ngoài tuần."
                        );
                        Rules.OpenMonth(c, t, x.Ngay);
                        Rules.CanWork(c, t, x.MaNV, x.Ngay);
                        Rules.Need(
                            Rules.Employee(c, t, x.MaNV)["MaPB"].ToString() == pb,
                            "Nhân viên khác phòng ban."
                        );
                        Rules.Need(
                            x.GioPhuTroi >= 0
                                && x.GioPhuTroi <= 24
                                && (
                                    x.GioPhuTroi == 0
                                    || new[] { "TangCa", "NgayLe", "NgayNghi" }.Contains(x.HinhThuc)
                                ),
                            "Phụ trội kế hoạch sai."
                        );
                        Db.Execute(
                            c,
                            t,
                            @"
                                INSERT INTO PhanCongCa (MaKH, MaNV, Ngay, MaCa, GioPhuTroiDuKien, HinhThuc)
                                VALUES                (@k, @n, @d, @ca, @g, @h);
                            ",
                            Db.P("@k", ma),
                            Db.P("@n", x.MaNV),
                            Db.P("@d", x.Ngay.Date),
                            Db.P("@ca", x.MaCa),
                            Db.P("@g", x.GioPhuTroi),
                            Db.P("@h", x.GioPhuTroi == 0 ? null : x.HinhThuc)
                        );
                    }
                }
            );
        }
    }

    public class ChamCongService
    {
        public void Ghi(string nv, DateTime ngay, decimal gio, string nguoicham)
        {
            Rules.Text(nguoicham, "Người chấm", 120);
            Rules.Need(
                ngay.Date <= DateTime.Today && gio >= 0,
                "Ngày thực tế không ở tương lai; giờ không âm."
            );
            Db.Transaction(
                (c, t) =>
                {
                    Rules.OpenMonth(c, t, ngay);
                    Rules.CanWork(c, t, nv, ngay);
                    var d = Db.Query(
                        c,
                        t,
                        @"
                            SELECT p.Id,
                                   ca.GioChuan
                            FROM PhanCongCa AS p
                                 INNER JOIN
                                 CaLam AS ca
                                 ON ca.MaCa = p.MaCa
                            WHERE p.MaNV = @n
                                  AND p.Ngay = @d;
                        ",
                        Db.P("@n", nv),
                        Db.P("@d", ngay.Date)
                    );
                    Rules.Need(
                        d.Rows.Count == 1 && gio <= Convert.ToDecimal(d.Rows[0]["GioChuan"]),
                        "Chưa phân công ca hoặc vượt giờ ca."
                    );
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO ChamCong
                            VALUES (@id, @g, @n);
                        ",
                        Db.P("@id", d.Rows[0]["Id"]),
                        Db.P("@g", gio),
                        Db.P("@n", nguoicham)
                    );
                }
            );
        }

        public void PhuTroi(
            string phieu,
            DateTime ngay,
            string hinhthuc,
            decimal sogio,
            string nguoilap,
            List<PhanBo> ds
        )
        {
            Rules.Text(phieu, "Số phiếu");
            Rules.Text(nguoilap, "Người lập", 120);
            Rules.Need(
                ngay.Date <= DateTime.Today
                    && sogio > 0
                    && sogio <= 24
                    && ds != null
                    && ds.Count > 0
                    && ds.Select(x => x.MaNV).Distinct().Count() == ds.Count,
                "Ngày, số giờ hoặc danh sách phụ trội sai."
            );
            Db.Transaction(
                (c, t) =>
                {
                    Rules.OpenMonth(c, t, ngay);
                    Db.Execute(
                        c,
                        t,
                        @"
                            INSERT INTO PhieuPhuTroi
                            VALUES (@p, @d, @h, @g, @n);
                        ",
                        Db.P("@p", phieu),
                        Db.P("@d", ngay.Date),
                        Db.P("@h", hinhthuc),
                        Db.P("@g", sogio),
                        Db.P("@n", nguoilap)
                    );
                    foreach (var x in ds)
                    {
                        Rules.CanWork(c, t, x.MaNV, ngay);
                        var d = Db.Query(
                            c,
                            t,
                            @"
                                SELECT p.GioPhuTroiDuKien,
                                       p.HinhThuc
                                FROM PhanCongCa AS p
                                     INNER JOIN
                                     ChamCong AS c
                                     ON c.IdPhanCong = p.Id
                                WHERE p.MaNV = @n
                                      AND p.Ngay = @d;
                            ",
                            Db.P("@n", x.MaNV),
                            Db.P("@d", ngay.Date)
                        );
                        Rules.Need(
                            d.Rows.Count == 1,
                            "Phải có phân công và chấm công trước phụ trội."
                        );
                        decimal cu = Convert.ToDecimal(
                            Db.Scalar(
                                c,
                                t,
                                @"
                                    SELECT ISNULL(SUM(ct.SoGio), 0)
                                    FROM ChiTietPhuTroi AS ct
                                         INNER JOIN
                                         PhieuPhuTroi AS p
                                         ON p.SoPhieu = ct.SoPhieu
                                    WHERE ct.MaNV = @n
                                          AND p.Ngay = @d;
                                ",
                                Db.P("@n", x.MaNV),
                                Db.P("@d", ngay.Date)
                            )
                        );
                        Rules.Need(
                            x.SoTien > 0
                                && x.SoTien <= sogio
                                && cu + x.SoTien <= Convert.ToDecimal(d.Rows[0][0])
                                && d.Rows[0][1].ToString() == hinhthuc,
                            "Vượt giờ dự kiến hoặc sai hình thức phụ trội."
                        );
                        Db.Execute(
                            c,
                            t,
                            @"
                                INSERT INTO ChiTietPhuTroi
                                VALUES (@p, @n, @g);
                            ",
                            Db.P("@p", phieu),
                            Db.P("@n", x.MaNV),
                            Db.P("@g", x.SoTien)
                        );
                    }
                }
            );
        }
    }
}
