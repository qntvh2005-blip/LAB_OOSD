using System;
using System.Collections.Generic;
using System.Linq;
using e_SHOPPING.Services;

namespace e_SHOPPING.Models
{
    public class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CMNDPassport { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhauBam { get; set; }
        public string MuoiMatKhau { get; set; }
        public string Email { get; set; }
        public bool KiemTraMatKhau(string matKhau) { return PasswordHasher.Verify(matKhau, MuoiMatKhau, MatKhauBam); }
    }
    // DTO do ProductAdapter cung cap, khong tao bang SanPham cuc bo.
    public class NhomSanPham
    {
        public string MaNhom { get; set; }
        public string TenNhom { get; set; }
    }
    public class SanPham
    {
        public string MaSanPham { get; set; }
        public string MaNhom { get; set; }
        public string TenSanPham { get; set; }
        public string NhaSanXuat { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public string ThongSoKyThuat { get; set; }
        public decimal GiaHienHanh { get; set; }
        public bool ConHang { get; set; }
        public SanPham Copy() { return (SanPham)MemberwiseClone(); }
    }
    public class DongGioHang
    {
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaTamTinh { get; set; }
        public decimal TinhThanhTien() { return SoLuong * DonGiaTamTinh; }
    }
    public class GioHang
    {
        public List<DongGioHang> DanhSachDong { get; private set; } = new List<DongGioHang>();
        public void Them(SanPham sp, int soLuong)
        {
            if (sp == null || !sp.ConHang) throw new InvalidOperationException("Sản phẩm không còn hàng.");
            if (soLuong <= 0) throw new InvalidOperationException("Số lượng phải lớn hơn 0.");
            var dong = DanhSachDong.FirstOrDefault(x => x.SanPham.MaSanPham == sp.MaSanPham);
            if (dong == null) DanhSachDong.Add(new DongGioHang { SanPham = sp.Copy(), SoLuong = soLuong, DonGiaTamTinh = sp.GiaHienHanh });
            else dong.SoLuong = checked(dong.SoLuong + soLuong);
        }
        public void CapNhatSoLuong(string ma, int soLuong)
        {
            if (soLuong <= 0) throw new InvalidOperationException("Số lượng phải lớn hơn 0.");
            DanhSachDong.Single(x => x.SanPham.MaSanPham == ma).SoLuong = soLuong;
        }
        public void Xoa(string ma) { DanhSachDong.RemoveAll(x => x.SanPham.MaSanPham == ma); }
        public decimal TinhTienHang() { return DanhSachDong.Sum(x => x.TinhThanhTien()); }
    }
    public class PhienDatHang
    {
        public Guid MaYeuCau { get; set; } = Guid.NewGuid();
        public string TrangThai { get; private set; } = "NhapThongTin";
        public decimal TongDaXacNhan { get; set; }
        public void ChuyenTrangThai(string trangThai) { TrangThai = trangThai; }
    }
    public class KhuVuc { public string MaKhuVuc { get; set; } public string TenKhuVuc { get; set; } }
    public class LoaiGiaoHang
    {
        public string MaLoaiGiaoHang { get; set; }
        public string TenLoai { get; set; }
        public int ThoiGianXuLyGio { get; set; }
    }
    public class BieuPhiGiaoHang
    {
        public string MaKhuVuc { get; set; }
        public string MaLoaiGiaoHang { get; set; }
        public decimal PhiCoBan { get; set; }
        public decimal TinhPhi(decimal tienHang)
        {
            if (MaLoaiGiaoHang == "NHANH" && tienHang >= 1000000m) return 0;
            if (MaLoaiGiaoHang == "TRONGNGAY" && tienHang >= 5000000m) return 0;
            return PhiCoBan;
        }
    }
    public class LoaiThe
    {
        public string MaLoaiThe { get; set; }
        public string TenLoai { get; set; }
        public int SoChuSo { get; set; }
        public int DoDaiCSV { get; set; }
        public decimal LePhiSuDung { get; set; }
        public decimal TinhLePhi() { return LePhiSuDung; }
    }
    public class ThongTinTheNhap
    {
        public LoaiThe LoaiThe { get; set; }
        public string SoThe { get; set; }
        public string TenChuThe { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string CSV { get; set; }
        public bool KiemTraDinhDang()
        {
            return LoaiThe != null && Digits(SoThe, LoaiThe.SoChuSo) && Digits(CSV, LoaiThe.DoDaiCSV)
                && !string.IsNullOrWhiteSpace(TenChuThe) && TenChuThe.Length <= 100
                && new DateTime(NgayHetHan.Year, NgayHetHan.Month, 1).AddMonths(1) > DateTime.Today;
        }
        static bool Digits(string value, int length) { return value != null && value.Length == length && value.All(c => c >= '0' && c <= '9'); }
    }
    public class ChiTietDonHang
    {
        public string MaSanPham { get; set; }
        public string TenSanPhamLucDat { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaLucDat { get; set; }
        public decimal TinhThanhTien() { return SoLuong * DonGiaLucDat; }
    }
    public class XacNhanThanhToan
    {
        public string MaXacNhan { get; set; }
        public string MaLoaiThe { get; set; }
        public string MaThamChieu { get; set; }
        public string BonSoCuoi { get; set; }
        public string TrangThai { get; set; }
        public DateTime ThoiDiemXacMinh { get; set; }
        public bool DaChapNhan() { return TrangThai == "ChapNhan"; }
    }
    public class DonHang
    {
        public string MaDonHang { get; set; }
        public Guid MaYeuCau { get; set; }
        public string MaKhachHang { get; set; }
        public string MaKhuVuc { get; set; }
        public string MaLoaiGiaoHang { get; set; }
        public DateTime ThoiDiemDat { get; set; }
        public string HoTenNguoiNhan { get; set; }
        public string DiaChiNguoiNhan { get; set; }
        public string DienThoaiNguoiNhan { get; set; }
        public decimal TienHang { get; set; }
        public decimal PhiGiaoHang { get; set; }
        public decimal LePhiThe { get; set; }
        public decimal TongThanhToan { get; set; }
        public List<ChiTietDonHang> ChiTiet { get; set; } = new List<ChiTietDonHang>();
        public XacNhanThanhToan XacNhan { get; set; }
        public decimal TinhTongThanhToan() { return TienHang + PhiGiaoHang + LePhiThe; }
    }
    public class CauHinh
    {
        public List<KhuVuc> KhuVuc { get; set; } = new List<KhuVuc>();
        public List<LoaiGiaoHang> GiaoHang { get; set; } = new List<LoaiGiaoHang>();
        public List<BieuPhiGiaoHang> BieuPhi { get; set; } = new List<BieuPhiGiaoHang>();
        public List<LoaiThe> The { get; set; } = new List<LoaiThe>();
    }
    public class YeuCauDatHang
    {
        public KhachHang Khach { get; set; }
        public GioHang Gio { get; set; }
        public PhienDatHang Phien { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string MaKhuVuc { get; set; }
        public string MaGiaoHang { get; set; }
        public ThongTinTheNhap The { get; set; }
    }
    public class KetQuaDatHang
    {
        public bool CanXacNhanLai { get; set; }
        public DonHang Don { get; set; }
        public string KetQuaEmail { get; set; }
    }
}
