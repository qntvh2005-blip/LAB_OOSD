using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>
    /// Quản lý quyền lợi khám sức khỏe định kỳ theo quý của bệnh nhân có hồ sơ bệnh án.
    /// Kiểm tra hiệu lực lệ phí năm và đặt lịch hẹn theo thời gian rảnh của khách hàng.
    /// </summary>
    public class DinhKyService
    {
        public DataTable LayLichHenTheoHoSo(string maHoSo)
        {
            return Db.Query(@"SELECT l.MaLichHen, l.MaHoSo, l.Nam, l.Quy, l.NgayGioHen, l.NoiDung, l.TrangThai
                              FROM LichKhamDinhKy l
                              WHERE l.MaHoSo = @h
                              ORDER BY l.Nam DESC, l.Quy DESC", Db.P("@h", maHoSo));
        }

        public DataTable LayTatCaLichHen(string trangThai = null)
        {
            string sql = @"SELECT l.MaLichHen, l.MaHoSo, b.HoTen AS TenBenhNhan, b.DienThoai,
                                  l.Nam, l.Quy, l.NgayGioHen, l.NoiDung, l.TrangThai
                           FROM LichKhamDinhKy l
                           JOIN HoSoBenhAn h ON l.MaHoSo = h.MaHoSo
                           JOIN BenhNhan b ON h.MaBN = b.MaBN";
            if (!string.IsNullOrWhiteSpace(trangThai))
            {
                sql += " WHERE l.TrangThai = @tt ORDER BY l.NgayGioHen";
                return Db.Query(sql, Db.P("@tt", trangThai));
            }
            sql += " ORDER BY l.NgayGioHen DESC";
            return Db.Query(sql);
        }

        public DataTable LayLichHenChoKham(string maHoSo)
        {
            return Db.Query(@"SELECT MaLichHen,
                                     MaLichHen + ' - Quý ' + CAST(Quy AS varchar) + '/' + CAST(Nam AS varchar) + ' (' + CONVERT(varchar(10), NgayGioHen, 103) + ')' AS HienThi,
                                     Nam, Quy, NgayGioHen, NoiDung
                              FROM LichKhamDinhKy
                              WHERE MaHoSo = @h AND TrangThai = @tt
                              ORDER BY NgayGioHen",
                              Db.P("@h", maHoSo), Db.P("@tt", QuyDinh.HenDaDat));
        }

        public KetQuaXuLy DatLichHen(string maLich, string maHoSo, int nam, int quy, DateTime ngayGioHen, string noiDung)
        {
            if (string.IsNullOrWhiteSpace(maLich) || string.IsNullOrWhiteSpace(maHoSo))
                return KetQuaXuLy.Fail("Mã lịch hẹn và mã hồ sơ không được để trống.");

            if (quy < 1 || quy > 4)
                return KetQuaXuLy.Fail("Quý phải nằm trong khoảng từ 1 đến 4.");
            if (ngayGioHen.Year != nam || (ngayGioHen.Month - 1) / 3 + 1 != quy)
                return KetQuaXuLy.Fail("Ngày hẹn phải thuộc đúng năm và quý đã chọn.");

            if (ngayGioHen < DateTime.Now.AddMinutes(-30))
                return KetQuaXuLy.Fail("Thời gian hẹn khám định kỳ phải từ thời điểm hiện tại trở đi.");

            try
            {
                // 1. Kiểm tra hồ sơ có tồn tại không
                object oHS = Db.Scalar("SELECT TrangThai FROM HoSoBenhAn WHERE MaHoSo = @h", Db.P("@h", maHoSo));
                if (oHS == null) return KetQuaXuLy.Fail("Hồ sơ bệnh án không tồn tại.");
                if (oHS.ToString() != "Đang theo dõi")
                    return KetQuaXuLy.Fail("Hồ sơ bệnh án không ở trạng thái hoạt động (Trạng thái: " + oHS.ToString() + ").");

                // 2. Kiểm tra hồ sơ đã đóng lệ phí cho năm đó chưa
                object oLP = Db.Scalar(@"SELECT 1 FROM LePhiNam WHERE MaHoSo = @h AND Nam = @n
                    AND @ngay BETWEEN CAST(NgayDong AS date) AND NgayHetHan",
                    Db.P("@h", maHoSo), Db.P("@n", nam), Db.P("@ngay",ngayGioHen.Date));
                if (oLP == null)
                    return KetQuaXuLy.Fail("Bệnh nhân chưa đóng lệ phí cho năm " + nam + ". Vui lòng hoàn tất lệ phí năm để hưởng quyền lợi khám định kỳ miễn phí.");

                // 3. Kiểm tra xem quý đó đã đặt hẹn chưa
                object oDaDat = Db.Scalar("SELECT 1 FROM LichKhamDinhKy WHERE MaHoSo = @h AND Nam = @n AND Quy = @q",
                    Db.P("@h", maHoSo), Db.P("@n", nam), Db.P("@q", quy));
                if (oDaDat != null)
                    return KetQuaXuLy.Fail("Bệnh nhân đã đăng ký lịch khám định kỳ cho Quý " + quy + "/" + nam + " rồi.");

                Db.Execute(@"INSERT INTO LichKhamDinhKy(MaLichHen, MaHoSo, Nam, Quy, NgayGioHen, NoiDung, TrangThai)
                             VALUES(@lh, @hs, @nam, @quy, @ngay, @nd, @tt)",
                             Db.P("@lh", maLich), Db.P("@hs", maHoSo), Db.P("@nam", nam),
                             Db.P("@quy", quy), Db.P("@ngay", ngayGioHen), Db.P("@nd", noiDung),
                             Db.P("@tt", QuyDinh.HenDaDat));

                return KetQuaXuLy.Ok("Đã đặt lịch hẹn khám định kỳ Quý " + quy + "/" + nam + " thành công cho hồ sơ " + maHoSo + ".");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }
    }
}
