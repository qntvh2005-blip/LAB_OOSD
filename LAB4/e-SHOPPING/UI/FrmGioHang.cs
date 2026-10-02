using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Context=e_SHOPPING.Services.AppContext;

namespace e_SHOPPING.UI
{
    public class FrmGioHang : LabForm
    {
        readonly Context app;readonly DataGridView grid=Ui.Grid(20,20,800,320);readonly Label total=Ui.Label("",20,425,800);
        readonly NumericUpDown qty=new NumericUpDown{Location=new Point(115,365),Minimum=1,Maximum=1000,Width=85,Value=1};
        public FrmGioHang(Context app):base("Giỏ hàng",840,530)
        {
            this.app=app;Ui.Column(grid,"ma","Mã","Ma",70);Ui.Column(grid,"ten","Sản phẩm","Ten",180);Ui.Column(grid,"sl","Số lượng","SL",65);Ui.Column(grid,"gia","Đơn giá tạm tính","Gia",100,"N0");Ui.Column(grid,"tien","Thành tiền","Tien",100,"N0");
            var update=Ui.Button("Cập nhật",220,360);var delete=Ui.Button("Xóa sản phẩm",385,360);var checkout=Ui.Button("Tiếp tục đặt hàng",575,465,245);var close=Ui.Button("Chọn thêm hàng",20,465,200);
            Controls.AddRange(new Control[]{grid,Ui.Label("Số lượng",20,368,90),qty,update,delete,total,checkout,close});RefreshCart();
            grid.SelectionChanged+=(s,e)=>{if(grid.CurrentRow!=null){var ma=grid.CurrentRow.Cells["ma"].Value as string;var d=app.GioHang.Gio.DanhSachDong.FirstOrDefault(x=>x.SanPham.MaSanPham==ma);if(d!=null)qty.Value=Math.Min(1000,d.SoLuong);}};
            update.Click+=async(s,e)=>await Run(()=>{app.GioHang.CapNhat(Selected(),(int)qty.Value);RefreshCart();return Task.CompletedTask;});
            delete.Click+=async(s,e)=>await Run(()=>{app.GioHang.Xoa(Selected());RefreshCart();return Task.CompletedTask;});close.Click+=(s,e)=>Close();
            checkout.Click+=async(s,e)=>await Run(()=>{
                if(app.GioHang.Gio.DanhSachDong.Count==0)throw new InvalidOperationException("Giỏ hàng đang trống.");
                if(app.Khach==null){using(var f=new FrmDangNhap(app))f.ShowDialog(this);if(app.Khach==null)return Task.CompletedTask;}
                using(var f=new FrmDatHang(app))if(f.ShowDialog(this)==DialogResult.OK){RefreshCart();Close();}return Task.CompletedTask;});
        }
        string Selected(){if(grid.CurrentRow==null)throw new InvalidOperationException("Vui lòng chọn dòng trong giỏ.");return (string)grid.CurrentRow.Cells["ma"].Value;}
        void RefreshCart(){grid.DataSource=app.GioHang.Gio.DanhSachDong.Select(d=>new{Ma=d.SanPham.MaSanPham,Ten=d.SanPham.TenSanPham,SL=d.SoLuong,Gia=d.DonGiaTamTinh,Tien=d.TinhThanhTien()}).ToList();total.Text="Tiền hàng tạm tính: "+Ui.Money(app.GioHang.TinhTienHang())+" (chưa gồm phí giao hàng và lệ phí thẻ)";}
    }
}
