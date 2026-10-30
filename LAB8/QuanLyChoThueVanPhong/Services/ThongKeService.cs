using System;
using System.Data;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Thống kê tình trạng văn phòng, doanh thu tiền thuê, doanh thu dịch vụ và tổng hợp công nợ cao ốc.
    /// </summary>
    public class ThongKeService
    {
        public DataTable ThongKeTinhTrangPhong()
        {
            return Db.Query(@"SELECT TrangThai, COUNT(*) AS SoLuong,
                                     SUM(DienTich) AS TongDienTich,
                                     CAST(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM dbo.Phong) AS decimal(5,2)) AS TyLePhanTram
                              FROM dbo.Phong
                              GROUP BY TrangThai");
        }

        public DataTable ThongKeDoanhThuThueTheoNam(int nam)
        {
            return Db.Query(@"SELECT Thang,
                                     COUNT(CASE WHEN DaThanhToan = 1 THEN 1 END) AS SoHoaDonDaThu,
                                     SUM(CASE WHEN DaThanhToan = 1 THEN SoTien ELSE 0 END) AS DoanhThuDaThu,
                                     SUM(CASE WHEN DaThanhToan = 0 THEN SoTien ELSE 0 END) AS CongNoChuaThu
                              FROM dbo.HoaDonTienThue
                              WHERE Nam = @n
                              GROUP BY Thang
                              ORDER BY Thang", Db.P("@n", nam));
        }

        public DataTable ThongKeDoanhThuDichVuTheoNam(int nam)
        {
            return Db.Query(@"SELECT Thang,
                                     COUNT(CASE WHEN DaThanhToan = 1 THEN 1 END) AS SoHoaDonDaThu,
                                     SUM(CASE WHEN DaThanhToan = 1 THEN TongTien ELSE 0 END) AS DoanhThuDaThu,
                                     SUM(CASE WHEN DaThanhToan = 0 THEN TongTien ELSE 0 END) AS CongNoChuaThu
                              FROM dbo.HoaDonDichVu
                              WHERE Nam = @n
                              GROUP BY Thang
                              ORDER BY Thang", Db.P("@n", nam));
        }

        public DataTable TongHopCongNoToanCaoOc()
        {
            return Db.Query(@"SELECT h.MaHD, k.TenCongTy, k.DienThoai,
                                     ISNULL((SELECT SUM(SoTien) FROM dbo.HoaDonTienThue WHERE MaHD = h.MaHD AND DaThanhToan = 0), 0) AS NoTienThue,
                                     ISNULL((SELECT SUM(TongTien) FROM dbo.HoaDonDichVu WHERE MaHD = h.MaHD AND DaThanhToan = 0), 0) AS NoDichVu,
                                     ISNULL((SELECT SUM(SoTienPhat) FROM dbo.BienBanXuPhat WHERE MaHD = h.MaHD AND DaNopPhat = 0), 0) AS NoPhatViPham
                              FROM dbo.HopDongThue h
                              JOIN dbo.KhachHang k ON h.MaKH = k.MaKH
                              WHERE h.TrangThai <> N'Đã thanh lý'
                              ORDER BY h.MaHD");
        }
    }
}
