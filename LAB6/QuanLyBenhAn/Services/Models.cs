using System;

namespace QuanLyBenhAn.Services
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

    /// <summary>Dòng thuốc trong chi tiết toa thuốc.</summary>
    public class ChiTietToaItem
    {
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public int SoLuong { get; set; }
        public string LieuDung { get; set; }
        public string CachDung { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get { return SoLuong * DonGia; } }
    }

    /// <summary>Hằng số và quy định nghiệp vụ chuẩn mực theo đặc tả HUTECH.</summary>
    public static class QuyDinh
    {
        public const decimal LePhiNamMacDinh = 500000m;
        public const decimal TienKhamMacDinh = 150000m;

        // Loại khám
        public const string LoaiKhamThuong = "Khám thường";
        public const string LoaiKhamDinhKy = "Khám định kỳ";

        // Trạng thái phiếu khám
        public const string TrangThaiDangKham = "Đang khám";
        public const string TrangThaiChoXetNghiem = "Chờ xét nghiệm";
        public const string TrangThaiChoThanhToan = "Chờ thanh toán";
        public const string TrangThaiDaHoanTat = "Đã hoàn tất";

        // Trạng thái lịch hẹn
        public const string HenDaDat = "Đã đặt hẹn";
        public const string HenDaKham = "Đã khám";
        public const string HenHuy = "Hủy hẹn";

        // Trạng thái xét nghiệm
        public const string XNChoKetQua = "Chờ kết quả";
        public const string XNDaCoKetQua = "Đã có kết quả";
        public const string XNHuy = "Đã hủy";

        // Trạng thái hồ sơ
        public const string HSDangTheoDoi = "Đang theo dõi";
        public const string HSNgungTheoDoi = "Tạm khóa";
    }
}
