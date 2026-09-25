using System;
using System.Data;
using QuanLyKhachSan.Data;
namespace QuanLyKhachSan.Services
{
    public class ThongKeService
    {
        public DataTable Summary(DateTime from,DateTime to)
        {
            Db.Require(to.Date>=from.Date,"Đến ngày không được trước từ ngày.");
            return Db.Query(@"SELECT
(SELECT COUNT(*) FROM PhieuDatPhong WHERE NgayLap>=@p0 AND NgayLap<@p1) AS SoPhieuDat,
(SELECT COUNT(*) FROM HoaDon WHERE NgayLap>=@p0 AND NgayLap<@p1) AS SoHoaDon,
(SELECT COUNT(*) FROM PhieuDatPhong WHERE TrangThai=N'Đang ở') AS DangOHienTai,
(SELECT ISNULL(SUM(TongTien),0) FROM HoaDon WHERE NgayLap>=@p0 AND NgayLap<@p1) AS TongHoaDon,
(SELECT ISNULL(SUM(SoTien),0) FROM ThanhToan WHERE NgayThanhToan>=@p0 AND NgayThanhToan<@p1) AS ThucThuHoaDon,
(SELECT ISNULL(SUM(TongTien),0) FROM PhieuDenBu WHERE NgayLap>=@p0 AND NgayLap<@p1) AS TongPhieuDenBu",from.Date,to.Date.AddDays(1));
        }
        public DataTable Services(DateTime from,DateTime to)
        { return Db.Query(@"SELECT d.MaDV,d.TenDV,SUM(c.SoLuong) AS SoLuong,SUM(c.ThanhTien) AS ThanhTien FROM PhieuSuDungDV p
JOIN ChiTietPhieuSuDungDV c ON p.SoPhieuSDDV=c.SoPhieuSDDV JOIN DichVu d ON c.MaDV=d.MaDV
WHERE p.NgaySuDung BETWEEN @p0 AND @p1 GROUP BY d.MaDV,d.TenDV",from.Date,to.Date); }
    }
}
