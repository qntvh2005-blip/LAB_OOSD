using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Xử lý nghiệp vụ lập hợp đồng thuê văn phòng:
    /// - Khách có thể thuê cùng lúc nhiều phòng.
    /// - Thời hạn thuê tối thiểu 6 tháng.
    /// - Khách phải trả trước tiền thuê của 6 tháng đầu tiên.
    /// - Tự động lên lịch thanh toán từ tháng thứ 7 trở đi (trả vào đầu mỗi tháng).
    /// Toàn bộ thao tác thực thi trong 1 SQL Transaction đảm bảo toàn vẹn dữ liệu.
    /// </summary>
    public class HopDongService
    {
        public DataTable LayDanhSachHopDong()
        {
            return Db.Query(@"SELECT h.MaHD, h.MaKH, k.TenCongTy, k.NguoiDaiDien, k.DienThoai,
                                     h.NgayKy, h.NgayBatDau, h.NgayKetThuc, h.ThoiHanThueThang,
                                     h.TienDatCoc, h.TongTienThang, h.TienTraTruoc6Thang, h.TrangThai
                              FROM dbo.HopDongThue h
                              JOIN dbo.KhachHang k ON h.MaKH = k.MaKH
                              ORDER BY h.NgayKy DESC, h.MaHD DESC");
        }

        public DataTable LayChiTietPhongTheoHopDong(string maHD)
        {
            return Db.Query(@"SELECT c.MaHD, c.MaPhong, p.TenPhong, t.TenTang, c.DienTichThue, 
                                     c.DonGiaThueThang, c.ThanhTienThang
                              FROM dbo.ChiTietHopDong c
                              JOIN dbo.Phong p ON c.MaPhong = p.MaPhong
                              JOIN dbo.Tang t ON p.MaTang = t.MaTang
                              WHERE c.MaHD = @hd", Db.P("@hd", maHD));
        }

        public DataTable LayLichThanhToanTienThue(string maHD)
        {
            return Db.Query(@"SELECT MaHDTT, MaHD, KyThanhToan, Thang, Nam, SoTien, NgayHenTra, 
                                     NgayThanhToan, DaThanhToan, GhiChu
                              FROM dbo.HoaDonTienThue
                              WHERE MaHD = @hd
                              ORDER BY Nam, Thang, MaHDTT", Db.P("@hd", maHD));
        }

        public KetQuaXuLy LapHopDong(string maHD, string maKH, DateTime ngayKy, DateTime ngayBatDau,
            int thoiHanThang, decimal tienDatCoc, List<PhongThueItem> dsPhong)
        {
            if (string.IsNullOrWhiteSpace(maHD) || string.IsNullOrWhiteSpace(maKH))
                return KetQuaXuLy.Fail("Mã hợp đồng và mã khách hàng không được để trống.");

            // Kiểm tra quy tắc nghiệp vụ: Thuê ít nhất 6 tháng
            if (thoiHanThang < QuyDinhCaoOc.ThoiHanThueToiThieuThang)
                return KetQuaXuLy.Fail(string.Format("Quy định cao ốc: Thời hạn thuê tối thiểu phải từ {0} tháng trở lên!", QuyDinhCaoOc.ThoiHanThueToiThieuThang));

            if (dsPhong == null || dsPhong.Count == 0)
                return KetQuaXuLy.Fail("Hợp đồng phải chọn ít nhất một văn phòng cần thuê.");

            // Tạo chuỗi XML danh sách phòng cho Stored Procedure
            var sb = new StringBuilder();
            sb.Append("<root>");
            foreach (var p in dsPhong)
            {
                sb.AppendFormat("<item MaPhong=\"{0}\" DonGia=\"{1}\" />", p.MaPhong, p.DonGia);
            }
            sb.Append("</root>");

            try
            {
                var dt = Db.ExecuteProc("dbo.sp_LapHopDongThue",
                    Db.P("@MaHD", maHD),
                    Db.P("@MaKH", maKH),
                    Db.P("@NgayKy", ngayKy.Date),
                    Db.P("@NgayBatDau", ngayBatDau.Date),
                    Db.P("@ThoiHanThueThang", thoiHanThang),
                    Db.P("@TienDatCoc", tienDatCoc),
                    Db.P("@DanhSachPhong", sb.ToString()));

                if (dt.Rows.Count > 0)
                {
                    decimal traTruoc6T = Convert.ToDecimal(dt.Rows[0]["TienTraTruoc6Thang"]);
                    decimal tongThang = Convert.ToDecimal(dt.Rows[0]["TongTienThang"]);
                    return KetQuaXuLy.Ok(string.Format("Lập hợp đồng {0} thành công! Tiền thuê 1 tháng: {1:N0} đ. Số tiền trả trước 6 tháng đầu: {2:N0} đ.",
                        maHD, tongThang, traTruoc6T));
                }

                return KetQuaXuLy.Ok("Lập hợp đồng thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }
    }
}
