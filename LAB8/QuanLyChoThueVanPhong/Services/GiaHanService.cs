using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Xử lý nghiệp vụ lập phiếu gia hạn hợp đồng thuê văn phòng:
    /// - Kiểm tra điều kiện: Thời gian gia hạn <= 1/2 thời gian thuê ban đầu.
    /// - Kiểm tra điều kiện: Văn phòng thuê không còn nợ tiền thuê mặt bằng.
    /// - Kiểm tra điều kiện: Đã thanh toán đầy đủ các hóa đơn dịch vụ đã sử dụng.
    /// Toàn bộ thao tác thực thi trong 1 SQL Transaction đảm bảo toàn vẹn dữ liệu.
    /// </summary>
    public class GiaHanService
    {
        public DataTable LayDanhSachPhieuGiaHan()
        {
            return Db.Query(@"SELECT g.MaPGH, g.MaHD, k.TenCongTy, g.MaPhong, p.TenPhong,
                                     g.NgayGiaHan, g.SoThangGiaHan, g.NgayBatDauMoi, g.NgayKetThucMoi,
                                     g.DonGiaMoi, g.TongTienGiaHan, g.TrangThai
                              FROM dbo.PhieuGiaHan g
                              JOIN dbo.HopDongThue h ON g.MaHD = h.MaHD
                              JOIN dbo.KhachHang k ON h.MaKH = k.MaKH
                              JOIN dbo.Phong p ON g.MaPhong = p.MaPhong
                              ORDER BY g.NgayGiaHan DESC, g.MaPGH DESC");
        }

        public DataTable LayCongNoTienThue(string maHD)
        {
            return Db.Query(@"SELECT MaHDTT, KyThanhToan, Thang, Nam, SoTien, NgayHenTra
                              FROM dbo.HoaDonTienThue
                              WHERE MaHD = @hd AND DaThanhToan = 0
                              ORDER BY Nam, Thang", Db.P("@hd", maHD));
        }

        public DataTable LayCongNoDichVu(string maHD)
        {
            return Db.Query(@"SELECT MaHDDV, MaPhong, Thang, Nam, TongTien, NgayHenTra
                              FROM dbo.HoaDonDichVu
                              WHERE MaHD = @hd AND DaThanhToan = 0
                              ORDER BY Nam, Thang", Db.P("@hd", maHD));
        }

        public KetQuaXuLy LapPhieuGiaHan(string maPGH, string maHD, string maPhong, int soThangGiaHan, decimal? donGiaMoi = null)
        {
            if (string.IsNullOrWhiteSpace(maPGH) || string.IsNullOrWhiteSpace(maHD) || string.IsNullOrWhiteSpace(maPhong))
                return KetQuaXuLy.Fail("Mã phiếu gia hạn, mã hợp đồng và phòng gia hạn không được để trống.");

            if (soThangGiaHan <= 0)
                return KetQuaXuLy.Fail("Số tháng gia hạn phải lớn hơn 0.");

            try
            {
                var dt = Db.ExecuteProc("dbo.sp_LapPhieuGiaHan",
                    Db.P("@MaPGH", maPGH),
                    Db.P("@MaHD", maHD),
                    Db.P("@MaPhong", maPhong),
                    Db.P("@SoThangGiaHan", soThangGiaHan),
                    Db.P("@DonGiaMoi", donGiaMoi.HasValue ? (object)donGiaMoi.Value : DBNull.Value));

                if (dt.Rows.Count > 0)
                {
                    DateTime ngayMoi = Convert.ToDateTime(dt.Rows[0]["NgayKetThucMoi"]);
                    decimal tongTien = Convert.ToDecimal(dt.Rows[0]["TongTienGiaHan"]);
                    return KetQuaXuLy.Ok(string.Format("Gia hạn thành công theo phiếu {0}! Ngày kết thúc hợp đồng mới: {1:dd/MM/yyyy}. Tổng tiền gia hạn: {2:N0} đ.",
                        maPGH, ngayMoi, tongTien));
                }

                return KetQuaXuLy.Ok("Lập phiếu gia hạn thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }
    }
}
