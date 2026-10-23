using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class PhanBo
    {
        public string MaNV;
        public decimal SoTien;

        public PhanBo(string n, decimal s)
        {
            MaNV = n;
            SoTien = s;
        }
    }

    public class PhanCong
    {
        public string MaNV,
            MaCa,
            HinhThuc;
        public DateTime Ngay;
        public decimal GioPhuTroi;
    }

    public static class Rules
    {
        public static void Need(bool ok, string message)
        {
            if (!ok)
                throw new InvalidOperationException(message);
        }

        public static void Text(string s, string label, int max = 20)
        {
            Need(
                !string.IsNullOrWhiteSpace(s) && s.Trim().Length <= max,
                label + " bắt buộc, tối đa " + max + " ký tự."
            );
        }

        public static decimal Money(decimal d)
        {
            return Math.Round(d, 0, MidpointRounding.AwayFromZero);
        }

        public static void OpenMonth(SqlConnection c, SqlTransaction t, DateTime d)
        {
            Need(
                Convert.ToInt32(
                    Db.Scalar(
                        c,
                        t,
                        @"
                            SELECT COUNT(*)
                            FROM BangLuong WITH (UPDLOCK, HOLDLOCK)
                            WHERE Nam = @y
                                  AND Thang = @m;
                        ",
                        Db.P("@y", d.Year),
                        Db.P("@m", d.Month)
                    )
                ) == 0,
                "Tháng đã chốt lương, không sửa nguồn dữ liệu."
            );
        }

        public static DataRow Employee(SqlConnection c, SqlTransaction t, string nv)
        {
            var a = Db.Query(
                c,
                t,
                @"
                    SELECT *
                    FROM NhanVien WITH (UPDLOCK, HOLDLOCK)
                    WHERE MaNV = @n;
                ",
                Db.P("@n", nv)
            );
            Need(a.Rows.Count == 1, "Không có nhân viên.");
            return a.Rows[0];
        }

        public static void CanWork(SqlConnection c, SqlTransaction t, string nv, DateTime date)
        {
            Employee(c, t, nv);
            // Kết quả thử việc không làm mất công đã làm trong thời gian thử việc.
            // Kiểm tra theo ngày để vẫn có thể nhập công quá khứ trước khi chốt lương.
            int trial = Convert.ToInt32(
                Db.Scalar(
                    c,
                    t,
                    @"
                        SELECT COUNT(*)
                        FROM QuyetDinhTuyenDung
                        WHERE MaNV = @n
                              AND @d BETWEEN TuNgay AND DenNgay;
                    ",
                    Db.P("@n", nv),
                    Db.P("@d", date.Date)
                )
            );
            int hd = Convert.ToInt32(
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
                    Db.P("@d", date.Date)
                )
            );
            Need(trial + hd > 0, "Ngày làm việc nằm ngoài thử việc/hợp đồng.");
        }

        public static void DecisionDate(SqlConnection c, SqlTransaction t, DateTime d)
        {
            Need(
                Convert.ToInt32(
                    Db.Scalar(
                        c,
                        t,
                        @"
                            SELECT COUNT(*)
                            FROM BangLuong
                            WHERE DATEFROMPARTS(Nam, Thang, 1) >= DATEFROMPARTS(@y, @m, 1);
                        ",
                        Db.P("@y", d.Year),
                        Db.P("@m", d.Month)
                    )
                ) == 0,
                "Ngày hiệu lực có thể ảnh hưởng bảng lương đã chốt."
            );
        }
    }
}
