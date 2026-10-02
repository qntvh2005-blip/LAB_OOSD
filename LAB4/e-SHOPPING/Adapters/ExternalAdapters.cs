using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using e_SHOPPING.Models;

namespace e_SHOPPING.Adapters
{
    public enum CheDoGiaLap { ThanhCong, TuChoi, LoiKetNoi }
    public interface IProductAdapter
    {
        List<NhomSanPham> LayNhom();
        List<SanPham> LaySanPham(string maNhom);
        SanPham LayChiTiet(string ma);
    }
    public interface IPaymentAdapter { XacNhanThanhToan XacMinh(ThongTinTheNhap the, decimal tongTien); }
    public interface IEmailAdapter { void GuiXacNhan(string email, string noiDung); }
    public class ProductAdapter : IProductAdapter
    {
        public bool LoiKetNoi { get; set; }
        public List<SanPham> DuLieuMau { get; private set; }
        public ProductAdapter()
        {
            DuLieuMau = new List<SanPham> {
                Tao("SP01","DT","Điện thoại IPhone 20 Premium",6500000,"ABC","6.5 inch; 128 GB",true),
                Tao("SP02","PK","Tai nghe Gaming",450000,"ABC","Bluetooth; pin 20 giờ",true),
                Tao("SP03","PK","Bàn phím Logitec",550000,"XYZ","USB; 104 phím",true),
                Tao("SP04","PK","Chuột ATK",200000,"XYZ","USB; 1600 DPI",false),
                Tao("SP05","GD","Ấm siêu tốc ",750000,"HOME","1.8 lít; 1500 W",true)
            };
        }
        static SanPham Tao(string ma,string nhom,string ten,decimal gia,string nsx,string thongSo,bool con)
        {
            return new SanPham { MaSanPham=ma, MaNhom=nhom, TenSanPham=ten, GiaHienHanh=gia,
                NhaSanXuat=nsx, ThongSoKyThuat=thongSo, MoTa="Sản phẩm minh họa của cửa hàng SHOPPE.", HinhAnh="mock:"+ma, ConHang=con };
        }
        void Check() { if(LoiKetNoi) throw new InvalidOperationException("Không kết nối được hệ thống sản phẩm (giả lập)."); }
        public List<NhomSanPham> LayNhom() { Check(); return new List<NhomSanPham> {
            new NhomSanPham{MaNhom="DT",TenNhom="Điện thoại"},new NhomSanPham{MaNhom="PK",TenNhom="Phụ kiện"},new NhomSanPham{MaNhom="GD",TenNhom="Gia dụng"} }; }
        public List<SanPham> LaySanPham(string maNhom) { Check(); return DuLieuMau.Where(s=>maNhom==null || s.MaNhom==maNhom).Select(s=>s.Copy()).ToList(); }
        public SanPham LayChiTiet(string ma) { Check(); var s=DuLieuMau.SingleOrDefault(x=>x.MaSanPham==ma); return s==null?null:s.Copy(); }
    }
    public class PaymentAdapter : IPaymentAdapter
    {
        public CheDoGiaLap CheDo { get; set; }
        public int SoLanGoi { get; private set; }
        public XacNhanThanhToan XacMinh(ThongTinTheNhap the, decimal tongTien)
        {
            SoLanGoi++;
            if(CheDo==CheDoGiaLap.LoiKetNoi) throw new InvalidOperationException("Không kết nối được dịch vụ thanh toán (giả lập).");
            if(CheDo==CheDoGiaLap.TuChoi) return new XacNhanThanhToan { TrangThai="TuChoi" };
            if(!the.KiemTraDinhDang() || tongTien<0) throw new InvalidOperationException("Thông tin thẻ không hợp lệ.");
            return new XacNhanThanhToan { MaXacNhan="XN"+Guid.NewGuid().ToString("N"), MaLoaiThe=the.LoaiThe.MaLoaiThe,
                MaThamChieu="MOCK-"+Guid.NewGuid().ToString("N"), BonSoCuoi=the.SoThe.Substring(the.SoThe.Length-4),
                TrangThai="ChapNhan",ThoiDiemXacMinh=DateTime.Now };
        }
    }
    public class EmailAdapter : IEmailAdapter
    {
        public bool LoiKetNoi { get; set; }
        public string NoiDungCuoi { get; private set; }
        public void GuiXacNhan(string email,string noiDung)
        {
            if(LoiKetNoi) throw new InvalidOperationException("Dịch vụ email giả lập chưa gửi được.");
            NoiDungCuoi=noiDung; // Chi gia lap tiep nhan, khong gui email that.
        }
        public static string TaoNoiDung(DonHang don,KhachHang khach,CauHinh config)
        {
            var vi=CultureInfo.GetCultureInfo("vi-VN"); var s=new StringBuilder();
            s.AppendLine("XÁC NHẬN ĐƠN "+don.MaDonHang).AppendLine("Thời điểm: "+don.ThoiDiemDat.ToString("dd/MM/yyyy HH:mm"));
            s.AppendLine("Người mua: "+khach.HoTen).AppendLine("Người nhận: "+don.HoTenNguoiNhan);
            s.AppendLine("Địa chỉ: "+don.DiaChiNguoiNhan).AppendLine("Điện thoại: "+don.DienThoaiNguoiNhan);
            s.AppendLine("Khu vực: "+config.KhuVuc.Single(x=>x.MaKhuVuc==don.MaKhuVuc).TenKhuVuc);
            s.AppendLine("Giao hàng: "+config.GiaoHang.Single(x=>x.MaLoaiGiaoHang==don.MaLoaiGiaoHang).TenLoai);
            foreach(var d in don.ChiTiet) s.AppendLine(d.TenSanPhamLucDat+" | SL: "+d.SoLuong+" | Đơn giá: "+d.DonGiaLucDat.ToString("N0",vi)+" đ");
            s.AppendLine("Tiền hàng: "+don.TienHang.ToString("N0",vi)+" đ").AppendLine("Phí giao: "+don.PhiGiaoHang.ToString("N0",vi)+" đ");
            s.AppendLine("Lệ phí thanh toán: "+don.LePhiThe.ToString("N0",vi)+" đ").AppendLine("Tổng tiền: "+don.TongThanhToan.ToString("N0",vi)+" đ");
            return s.ToString(); // Khong dua so the, CSV, bon so cuoi hay loai the vao email.
        }
    }
}
