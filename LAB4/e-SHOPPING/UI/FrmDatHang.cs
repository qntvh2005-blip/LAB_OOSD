using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_SHOPPING.Models;
using Context=e_SHOPPING.Services.AppContext;

namespace e_SHOPPING.UI
{
    public class FrmDatHang : LabForm
    {
        readonly Context app;readonly PhienDatHang phien=new PhienDatHang();CauHinh config;DonHang quote;
        readonly TextBox hoTen=Ui.Text(205,30,350,100),diaChi=Ui.Text(205,73,350,250),phone=Ui.Text(205,116,350,20);
        readonly ComboBox khu=Ui.Combo(205,159,350),giao=Ui.Combo(205,202,350),loaiThe=Ui.Combo(205,290,350);
        readonly TextBox soThe=Ui.Text(205,333,350,16,false),chuThe=Ui.Text(205,376,350,100),csv=Ui.Text(205,462,120,4,false);
        readonly DateTimePicker expiry=new DateTimePicker{Location=new Point(205,419),Width=200,Format=DateTimePickerFormat.Custom,CustomFormat="MM/yyyy",ShowUpDown=true,Value=DateTime.Today.AddYears(1)};
        readonly TextBox summary=new TextBox{Location=new Point(600,30),Size=new Size(375,390),ReadOnly=true,Multiline=true,ScrollBars=ScrollBars.Vertical,BackColor=Color.FromArgb(245,248,252)};
        readonly Button calculate=Ui.Button("Tính tiền",600,450,170),confirm=Ui.Button("Xác nhận đặt hàng",785,450,190);
        public FrmDatHang(Context app):base("Đặt hàng — Thông tin người nhận và thẻ",1000,615)
        {
            this.app=app;
            string[] labels={"Họ tên người nhận","Địa chỉ người nhận","Điện thoại","Khu vực","Loại giao hàng"};int[] ys={30,73,116,159,202};for(int i=0;i<labels.Length;i++)Controls.Add(Ui.Label(labels[i],20,ys[i]+3,175));
            Controls.AddRange(new Control[]{hoTen,diaChi,phone,khu,giao,Ui.Label("THÔNG TIN THẺ",20,252,450),Ui.Label("Loại thẻ",20,293),loaiThe,Ui.Label("Số thẻ",20,336),soThe,Ui.Label("Tên chủ thẻ",20,379),chuThe,Ui.Label("Hết hạn (tháng/năm)",20,422,180),expiry,Ui.Label("Mã CSV (theo đề)",20,465,180),csv,summary,calculate,confirm,Ui.Label("Xác minh thẻ và gửi email đang dùng dịch vụ giả lập. Không trừ tiền thật.",20,555,950),Ui.Label("Số thẻ và CSV chỉ dùng trong lần xác minh, không lưu vào CSDL.",20,580,950)});
            confirm.Enabled=false;calculate.Enabled=false;
            if(app.Khach!=null){hoTen.Text=app.Khach.HoTen;diaChi.Text=app.Khach.DiaChi;phone.Text=app.Khach.DienThoai;}
            Shown+=async(s,e)=>await Run(async()=>{config=await Task.Run(()=>app.DatHang.LayCauHinh());Ui.Bind(khu,config.KhuVuc,"TenKhuVuc","MaKhuVuc");Ui.Bind(giao,config.GiaoHang,"TenLoai","MaLoaiGiaoHang");Ui.Bind(loaiThe,config.The,"TenLoai","MaLoaiThe");khu.SelectedValue="NT";giao.SelectedValue="THUONG";loaiThe.SelectedValue="VISA";calculate.Enabled=true;});
            foreach(var t in new[]{hoTen,diaChi,phone,soThe,chuThe,csv})t.TextChanged+=(s,e)=>InvalidateQuote();
            khu.SelectedIndexChanged+=(s,e)=>InvalidateQuote();giao.SelectedIndexChanged+=(s,e)=>InvalidateQuote();loaiThe.SelectedIndexChanged+=(s,e)=>InvalidateQuote();expiry.ValueChanged+=(s,e)=>InvalidateQuote();
            calculate.Click += async (s, e) => await Run(async () =>
            {
                if (!KiemTraTheNhap()) return;

                var y = Request();
                quote = await Task.Run(() => app.DatHang.BaoGia(y));
                phien.TongDaXacNhan = quote.TongThanhToan;
                ShowQuote(quote);
                confirm.Enabled = true;
            });
            confirm.Click+=async(s,e)=>await Run(async()=>{
                if (!KiemTraTheNhap()) return;
                if (quote==null)throw new InvalidOperationException("Vui lòng tính tiền trước.");
                if(MessageBox.Show(this,"Xác nhận tổng thanh toán "+Ui.Money(quote.TongThanhToan)+"?","Xác nhận đặt hàng",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes)return;
                var y=Request();var result=await Task.Run(()=>app.DatHang.DatHang(y,quote));
                if(result.CanXacNhanLai){quote=result.Don;phien.TongDaXacNhan=quote.TongThanhToan;ShowQuote(quote);MessageBox.Show(this,"Giá hoặc biểu phí đã thay đổi. Kiểm tra tổng mới rồi xác nhận lại.");return;}
                app.GioHang.LamTrong();soThe.Clear();csv.Clear();
                MessageBox.Show(this,"Đặt hàng thành công!\r\nMã đơn: "+result.Don.MaDonHang+"\r\nTổng thanh toán: "+Ui.Money(result.Don.TongThanhToan)+"\r\n"+result.KetQuaEmail,"Kết quả");DialogResult=DialogResult.OK;Close();
            });
            FormClosed+=(s,e)=>{soThe.Clear();csv.Clear();};
        }
        private bool KiemTraTheNhap()
        {
            var loai = loaiThe.SelectedItem as LoaiThe;
            string loi = null;
            string so = soThe.Text.Trim();
            string ma = csv.Text.Trim();

            if (loai == null)
                loi = "Vui lòng chọn loại thẻ.";
            else if (so.Length != loai.SoChuSo ||
                     !so.All(c => c >= '0' && c <= '9'))
                loi = $"Số thẻ {loai.TenLoai} phải gồm đúng {loai.SoChuSo} chữ số.";
            else if (ma.Length != loai.DoDaiCSV ||
                     !ma.All(c => c >= '0' && c <= '9'))
                loi = $"Mã CSV phải gồm đúng {loai.DoDaiCSV} chữ số.";
            else if (string.IsNullOrWhiteSpace(chuThe.Text))
                loi = "Vui lòng nhập tên chủ thẻ.";
            else if (new DateTime(expiry.Value.Year, expiry.Value.Month, 1)
                         .AddMonths(1) <= DateTime.Today)
                loi = "Thẻ đã hết hạn. Vui lòng kiểm tra tháng/năm hết hạn.";

            if (loi == null)
                return true;

            MessageBox.Show(this, loi, "Thông tin thẻ không hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return false;
        }
        void InvalidateQuote(){quote=null;confirm.Enabled=false;}
        YeuCauDatHang Request()
        {
            if(config==null)throw new InvalidOperationException("Chưa tải được cấu hình.");
            return new YeuCauDatHang{Khach=app.Khach,Gio=app.GioHang.Gio,Phien=phien,HoTen=hoTen.Text,DiaChi=diaChi.Text,DienThoai=phone.Text,
                MaKhuVuc=khu.SelectedValue as string,MaGiaoHang=giao.SelectedValue as string,
                The=new ThongTinTheNhap{LoaiThe=loaiThe.SelectedItem as LoaiThe,SoThe=soThe.Text.Trim(),CSV=csv.Text.Trim(),TenChuThe=chuThe.Text.Trim(),NgayHetHan=expiry.Value}};
        }
        void ShowQuote(DonHang d)
        {
            var shipping=config.GiaoHang.Single(x=>x.MaLoaiGiaoHang==d.MaLoaiGiaoHang);
            summary.Text="THÔNG TIN ĐƠN HÀNG\r\n\r\n"+string.Join("\r\n",d.ChiTiet.Select(x=>x.TenSanPhamLucDat+" × "+x.SoLuong+" = "+Ui.Money(x.TinhThanhTien())))+
                "\r\n\r\nTiền hàng: "+Ui.Money(d.TienHang)+"\r\nPhí giao hàng: "+Ui.Money(d.PhiGiaoHang)+"\r\nLệ phí thẻ: "+Ui.Money(d.LePhiThe)+"\r\n\r\nTỔNG: "+Ui.Money(d.TongThanhToan)+"\r\n\r\nThời gian xử lý dự kiến: "+shipping.ThoiGianXuLyGio+" giờ (cấu hình mẫu).";
        }
    }
}
