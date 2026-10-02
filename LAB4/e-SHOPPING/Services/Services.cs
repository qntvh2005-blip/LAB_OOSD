using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Data.SqlClient;
using e_SHOPPING.Models;
using e_SHOPPING.Data;
using e_SHOPPING.Adapters;

namespace e_SHOPPING.Services
{
    public static class PasswordHasher
    {
        public static void Create(string password,out string salt,out string hash)
        {
            var bytes=new byte[16];using(var rng=RandomNumberGenerator.Create())rng.GetBytes(bytes);
            salt=Convert.ToBase64String(bytes);hash=Derive(password,bytes);
        }
        static string Derive(string password,byte[] salt)
        { using(var derive=new Rfc2898DeriveBytes(password,salt,100000))return Convert.ToBase64String(derive.GetBytes(32)); }
        public static bool Verify(string password,string salt,string hash)
        {
            var expected=Convert.FromBase64String(hash);var actual=Convert.FromBase64String(Derive(password,Convert.FromBase64String(salt)));
            if(expected.Length!=actual.Length)return false;int diff=0;for(int i=0;i<actual.Length;i++)diff|=actual[i]^expected[i];return diff==0;
        }
    }
    public static class Validation
    {
        public static void Required(string value,string field,int max)
        {if(string.IsNullOrWhiteSpace(value)||value.Length>max)throw new InvalidOperationException(field+" là bắt buộc, tối đa "+max+" ký tự.");}
        public static void Phone(string value)
        {if(value==null || value.Length<8 || value.Length>20 || !value.All(c=>char.IsDigit(c)||c=='+'||c==' '||c=='-'))throw new InvalidOperationException("Điện thoại không hợp lệ.");}
    }
    public class TaiKhoanService
    {
        readonly TaiKhoanRepository repo;
        public TaiKhoanService(TaiKhoanRepository repo){this.repo=repo;}
        public void DangKy(KhachHang k,string password)
        {
            k.HoTen=(k.HoTen??"").Trim();k.TenDangNhap=(k.TenDangNhap??"").Trim();
            Validation.Required(k.HoTen,"Họ tên",100);Validation.Required(k.TenDangNhap,"Tên đăng nhập",50);
            Validation.Required(k.CMNDPassport,"CMND/Passport",30);Validation.Required(k.DiaChi,"Địa chỉ",250);Validation.Phone(k.DienThoai);
            if(k.NgaySinh.Date>=DateTime.Today)throw new InvalidOperationException("Ngày sinh phải trước hôm nay.");
            if(string.IsNullOrEmpty(password)||password.Length<6||password.Length>128)throw new InvalidOperationException("Mật khẩu cần từ 6 đến 128 ký tự.");
            k.Email=string.IsNullOrWhiteSpace(k.Email)?null:k.Email.Trim();
            if(k.Email!=null){if(k.Email.Length>254)throw new InvalidOperationException("Email quá dài.");try{var mail=new MailAddress(k.Email);if(mail.Address!=k.Email)throw new FormatException();}catch{throw new InvalidOperationException("Email không hợp lệ.");}}
            if(repo.LayKhachHang(k.TenDangNhap)!=null)throw new InvalidOperationException("Tên đăng nhập đã tồn tại.");
            string salt,hash;PasswordHasher.Create(password,out salt,out hash);k.MuoiMatKhau=salt;k.MatKhauBam=hash;k.MaKhachHang="KH"+Guid.NewGuid().ToString("N");
            try{repo.Luu(k);}catch(SqlException ex){if(ex.Number==2601||ex.Number==2627)throw new InvalidOperationException("Tên đăng nhập đã tồn tại.");throw;}
        }
        public KhachHang DangNhap(string ten,string password)
        {
            ten=(ten??"").Trim();Validation.Required(ten,"Tên đăng nhập",50);
            if(string.IsNullOrEmpty(password)||password.Length>128)throw new InvalidOperationException("Vui lòng nhập mật khẩu hợp lệ.");
            var k=repo.LayKhachHang(ten);if(k==null||!k.KiemTraMatKhau(password))throw new InvalidOperationException("Tên đăng nhập hoặc mật khẩu không đúng.");return k;
        }
    }
    public class SanPhamService
    {
        readonly IProductAdapter adapter;
        public SanPhamService(IProductAdapter adapter){this.adapter=adapter;}
        public System.Collections.Generic.List<NhomSanPham> LayNhom(){return adapter.LayNhom();}
        public System.Collections.Generic.List<SanPham> LaySanPham(string nhom){return adapter.LaySanPham(nhom);}
        public SanPham LayChiTiet(string ma){var p=adapter.LayChiTiet(ma);if(p==null)throw new InvalidOperationException("Không tìm thấy sản phẩm.");return p;}
    }
    public class GioHangService
    {
        public GioHang Gio { get; private set; } = new GioHang();
        public void Them(SanPham sp,int sl){Gio.Them(sp,sl);}
        public void CapNhat(string ma,int sl){Gio.CapNhatSoLuong(ma,sl);}
        public void Xoa(string ma){Gio.Xoa(ma);}
        public decimal TinhTienHang(){return Gio.TinhTienHang();}
        public void LamTrong(){Gio.DanhSachDong.Clear();}
    }
    public class DatHangService
    {
        readonly IProductAdapter product;readonly IPaymentAdapter payment;readonly IEmailAdapter email;readonly DonHangRepository repo;
        public DatHangService(IProductAdapter p,IPaymentAdapter t,IEmailAdapter e,DonHangRepository r){product=p;payment=t;email=e;repo=r;}
        public CauHinh LayCauHinh(){return repo.LayCauHinh();}
        void KiemTraYeuCau(YeuCauDatHang y)
        {
            if(y==null||y.Khach==null)throw new InvalidOperationException("Bạn cần đăng nhập trước khi đặt hàng.");
            if(y.Gio==null||y.Gio.DanhSachDong.Count==0)throw new InvalidOperationException("Giỏ hàng đang trống.");
            if(y.Phien==null||y.Phien.MaYeuCau==Guid.Empty)throw new InvalidOperationException("Phiên đặt hàng không hợp lệ.");
            Validation.Required(y.HoTen,"Họ tên người nhận",100);Validation.Required(y.DiaChi,"Địa chỉ người nhận",250);Validation.Phone(y.DienThoai);
            if(y.The==null||y.The.LoaiThe==null)throw new InvalidOperationException("Vui lòng chọn loại thẻ.");
            foreach(var d in y.Gio.DanhSachDong)if(d.SoLuong<=0)throw new InvalidOperationException("Số lượng phải lớn hơn 0.");
        }
        DonHang TinhDon(YeuCauDatHang y,CauHinh cfg)
        {
            var phi=cfg.BieuPhi.SingleOrDefault(x=>x.MaKhuVuc==y.MaKhuVuc&&x.MaLoaiGiaoHang==y.MaGiaoHang);
            var the=cfg.The.SingleOrDefault(x=>x.MaLoaiThe==y.The.LoaiThe.MaLoaiThe);
            if(phi==null||the==null)throw new InvalidOperationException("Cấu hình giao hàng hoặc loại thẻ không hợp lệ.");
            y.The.LoaiThe=the;
            var d=new DonHang {MaDonHang="DH"+Guid.NewGuid().ToString("N"),MaYeuCau=y.Phien.MaYeuCau,MaKhachHang=y.Khach.MaKhachHang,
                MaKhuVuc=y.MaKhuVuc,MaLoaiGiaoHang=y.MaGiaoHang,ThoiDiemDat=DateTime.Now,HoTenNguoiNhan=y.HoTen.Trim(),DiaChiNguoiNhan=y.DiaChi.Trim(),DienThoaiNguoiNhan=y.DienThoai.Trim()};
            foreach(var line in y.Gio.DanhSachDong)
            {
                var p=product.LayChiTiet(line.SanPham.MaSanPham);
                if(p==null||!p.ConHang)throw new InvalidOperationException("Sản phẩm "+line.SanPham.TenSanPham+" hiện không còn hàng.");
                d.ChiTiet.Add(new ChiTietDonHang{MaSanPham=p.MaSanPham,TenSanPhamLucDat=p.TenSanPham,SoLuong=line.SoLuong,DonGiaLucDat=p.GiaHienHanh});
            }
            d.TienHang=d.ChiTiet.Sum(x=>x.TinhThanhTien());d.PhiGiaoHang=phi.TinhPhi(d.TienHang);d.LePhiThe=the.TinhLePhi();d.TongThanhToan=d.TinhTongThanhToan();return d;
        }
        public DonHang BaoGia(YeuCauDatHang y){KiemTraYeuCau(y);return TinhDon(y,repo.LayCauHinh());}
        public KetQuaDatHang DatHang(YeuCauDatHang y,DonHang daXacNhan)
        {
            if(y==null||y.Khach==null||y.Phien==null)throw new InvalidOperationException("Phiên đăng nhập/đặt hàng không hợp lệ.");
            var existing=repo.TimTheoYeuCau(y.Phien.MaYeuCau);
            if(existing!=null)
            {
                if(existing.MaKhachHang!=y.Khach.MaKhachHang)throw new InvalidOperationException("Mã yêu cầu đã được sử dụng.");
                return new KetQuaDatHang{Don=existing,KetQuaEmail="Đơn đã được lưu trước đó; không gửi email lần nữa."};
            }
            KiemTraYeuCau(y);var cfg=repo.LayCauHinh();var d=TinhDon(y,cfg);
            if(!y.The.KiemTraDinhDang())throw new InvalidOperationException("Thông tin thẻ không hợp lệ: kiểm tra số thẻ, CSV, chủ thẻ và hạn sử dụng.");
            // So sanh tung dong, khong chi tong: hai thay doi gia co the bu tru nhau.
            if(daXacNhan==null||daXacNhan.MaYeuCau!=y.Phien.MaYeuCau||d.TongThanhToan!=daXacNhan.TongThanhToan ||
                d.PhiGiaoHang!=daXacNhan.PhiGiaoHang||d.LePhiThe!=daXacNhan.LePhiThe||d.ChiTiet.Count!=daXacNhan.ChiTiet.Count||
                d.ChiTiet.Any(a=>!daXacNhan.ChiTiet.Any(b=>a.MaSanPham==b.MaSanPham&&a.SoLuong==b.SoLuong&&a.DonGiaLucDat==b.DonGiaLucDat)))
            {y.Phien.ChuyenTrangThai("CanXacNhanLai");return new KetQuaDatHang{CanXacNhanLai=true,Don=d};}
            y.Phien.TongDaXacNhan=d.TongThanhToan;y.Phien.ChuyenTrangThai("ChoXacMinh");
            try{d.XacNhan=payment.XacMinh(y.The,d.TongThanhToan);}catch{y.Phien.ChuyenTrangThai("LoiKetNoi");throw;}
            if(!d.XacNhan.DaChapNhan()){y.Phien.ChuyenTrangThai("BiTuChoi");throw new InvalidOperationException("Dịch vụ thanh toán từ chối. Chưa ghi nhận đơn.");}
            y.Phien.ChuyenTrangThai("DangGhiNhan");
            DonHang saved;try{saved=repo.LuuDonHang(d);}catch{y.Phien.ChuyenTrangThai("LoiGhiNhan");throw;}
            y.Phien.ChuyenTrangThai("HoanTat");string msg="Khách không có email; bỏ qua gửi xác nhận.";
            if(saved.MaDonHang!=d.MaDonHang)return new KetQuaDatHang{Don=saved,KetQuaEmail="Đơn đã lưu; không gửi email lặp."};
            if(!string.IsNullOrWhiteSpace(y.Khach.Email))
            {
                try{email.GuiXacNhan(y.Khach.Email,EmailAdapter.TaoNoiDung(d,y.Khach,cfg));msg="Dịch vụ email giả lập đã tiếp nhận xác nhận.";}
                catch{msg="Đơn đã lưu thành công; dịch vụ email chưa gửi được xác nhận.";}
            }
            return new KetQuaDatHang{Don=d,KetQuaEmail=msg};
        }
    }
    public class AppContext
    {
        public KhachHang Khach {get;set;}
        public ProductAdapter Product {get;private set;}=new ProductAdapter();
        public PaymentAdapter Payment {get;private set;}=new PaymentAdapter();
        public EmailAdapter Email {get;private set;}=new EmailAdapter();
        public TaiKhoanService TaiKhoan {get;private set;}
        public SanPhamService SanPham {get;private set;}
        public GioHangService GioHang {get;private set;}=new GioHangService();
        public DatHangService DatHang {get;private set;}
        public AppContext()
        {
            CheDoGiaLap mode;bool failure;
            if(Enum.TryParse(System.Configuration.ConfigurationManager.AppSettings["MockPaymentMode"],out mode))Payment.CheDo=mode;
            if(bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["MockEmailFailure"],out failure))Email.LoiKetNoi=failure;
            if(bool.TryParse(System.Configuration.ConfigurationManager.AppSettings["MockProductFailure"],out failure))Product.LoiKetNoi=failure;
            TaiKhoan=new TaiKhoanService(new TaiKhoanRepository());SanPham=new SanPhamService(Product);DatHang=new DatHangService(Product,Payment,Email,new DonHangRepository());
        }
    }
}
