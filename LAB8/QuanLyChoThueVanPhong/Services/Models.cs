using System;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>Kết quả thực thi của mọi thao tác Service; Form chỉ đọc ThanhCong và ThongBao.</summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; private set; }
        public string ThongBao { get; private set; }
        public object DuLieu { get; private set; }

        public static KetQuaXuLy Ok(string thongBao, object duLieu = null)
        {
            return new KetQuaXuLy { ThanhCong = true, ThongBao = thongBao, DuLieu = duLieu };
        }

        public static KetQuaXuLy Fail(string thongBao)
        {
            return new KetQuaXuLy { ThanhCong = false, ThongBao = thongBao };
        }
    }

    /// <summary>Dòng phòng được chọn thuê trong hợp đồng.</summary>
    public class PhongThueItem
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public decimal DienTich { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTienThang { get { return DienTich * DonGia; } }
    }

    /// <summary>Dòng sử dụng dịch vụ trong hóa đơn dịch vụ cuối tháng.</summary>
    public class ChiTietDichVuItem
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public decimal? ChiSoDau { get; set; }
        public decimal? ChiSoCuoi { get; set; }
        public decimal SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get { return SoLuong * DonGia; } }
    }

    /// <summary>Hằng số quy định nghiệp vụ quản lý cho thuê văn phòng cao ốc.</summary>
    public static class QuyDinhCaoOc
    {
        public const int ThoiHanThueToiThieuThang = 6;
        public const int SoThangTraTruocBanDau = 6;
        public const int ThangBatDauTraTungThang = 7;

        // Trạng thái phòng
        public const string PhongTrong = "Trống";
        public const string PhongDangThue = "Đang thuê";
        public const string PhongBaoTri = "Bảo trì";

        // Trạng thái hợp đồng
        public const string HDHieuLuc = "Hiệu lực";
        public const string HDDaThanhLy = "Đã thanh lý";
        public const string HDDaGiaHan = "Đã gia hạn";

        // Trạng thái thẻ xe
        public const string TheHoatDong = "Hoạt động";
        public const string TheBiKhoa = "Bị khóa";
        public const string TheDaThuHoi = "Đã thu hồi";
    }
}
