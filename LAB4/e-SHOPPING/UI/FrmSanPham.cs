using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_SHOPPING.Models;
using Context=e_SHOPPING.Services.AppContext;

namespace e_SHOPPING.UI
{
    public class FrmSanPham : LabForm
    {
        readonly Context app;readonly ComboBox groups=Ui.Combo(110,78,270);readonly DataGridView grid=Ui.Grid(20,125,960,390);
        readonly Label status=Ui.Label("Chưa đăng nhập",20,25,430);readonly Label cart=Ui.Label("",630,78,350);
        readonly System.Collections.Generic.Dictionary<string,Bitmap> images=new System.Collections.Generic.Dictionary<string,Bitmap>();
        readonly NumericUpDown qty=new NumericUpDown{Location=new Point(385,540),Width=70,Minimum=1,Maximum=1000,Value=1};
        public FrmSanPham(Context app):base("e-SHOPPING — Cửa hàng ABC",1000,650)
        {
            this.app=app;grid.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom;
            grid.Columns.Add(new DataGridViewImageColumn{Name="anh",HeaderText="Ảnh mẫu",ImageLayout=DataGridViewImageCellLayout.Zoom,FillWeight=60});grid.RowTemplate.Height=52;
            grid.CellFormatting+=(s,e)=>{if(e.ColumnIndex==0&&e.RowIndex>=0){var p=grid.Rows[e.RowIndex].DataBoundItem as SanPham;if(p!=null){if(!images.ContainsKey(p.MaSanPham))images[p.MaSanPham]=Ui.ProductImage(p.MaSanPham);e.Value=images[p.MaSanPham];e.FormattingApplied=true;}}};
            FormClosed+=(s,e)=>{foreach(var image in images.Values)image.Dispose();};
            Ui.Column(grid,"ma","Mã","MaSanPham",60);Ui.Column(grid,"ten","Sản phẩm","TenSanPham",180);Ui.Column(grid,"nsx","Nhà sản xuất","NhaSanXuat",100);Ui.Column(grid,"gia","Giá hiện hành","GiaHienHanh",100,"N0");
            grid.Columns.Add(new DataGridViewCheckBoxColumn{Name="con",HeaderText="Còn hàng",DataPropertyName="ConHang",FillWeight=70});
            var login=Ui.Button("Đăng nhập",470,18);var register=Ui.Button("Đăng ký",630,18);var logout=Ui.Button("Đăng xuất",790,18);
            var detail=Ui.Button("Xem chi tiết",20,535,155);var add=Ui.Button("Thêm vào giỏ",470,535);var view=Ui.Button("Giỏ hàng / Đặt hàng",710,535,270);
            Controls.AddRange(new Control[]{status,login,register,logout,Ui.Label("Nhóm",20,80,80),groups,cart,grid,detail,Ui.Label("Số lượng",280,543,100),qty,add,view,Ui.Label("Bản LAB: sản phẩm, xác minh thanh toán và gửi email được giả lập.",20,604,960)});
            login.Click+=(s,e)=>{using(var f=new FrmDangNhap(app))f.ShowDialog(this);RefreshStatus();};
            register.Click+=(s,e)=>{using(var f=new FrmDangKy(app))f.ShowDialog(this);};logout.Click+=(s,e)=>{app.Khach=null;RefreshStatus();};
            groups.SelectedIndexChanged+=async(s,e)=>await LoadProducts();
            Shown+=async(s,e)=>await Run(async()=>{var data=await Task.Run(()=>app.SanPham.LayNhom());data.Insert(0,new NhomSanPham{MaNhom="",TenNhom="Tất cả nhóm"});Ui.Bind(groups,data,"TenNhom","MaNhom");RefreshStatus();});
            detail.Click+=async(s,e)=>await Run(async()=>{var p=Selected();var fresh=await Task.Run(()=>app.SanPham.LayChiTiet(p.MaSanPham));using(var f=new FrmChiTietSanPham(fresh,app))f.ShowDialog(this);RefreshStatus();});
            add.Click+=async(s,e)=>await Run(async()=>{var p=Selected();int sl=(int)qty.Value;var fresh=await Task.Run(()=>app.SanPham.LayChiTiet(p.MaSanPham));app.GioHang.Them(fresh,sl);RefreshStatus();MessageBox.Show(this,"Đã thêm vào giỏ.");});
            view.Click+=(s,e)=>{using(var f=new FrmGioHang(app))f.ShowDialog(this);RefreshStatus();};
        }
        async Task LoadProducts(){await Run(async()=>{var ma=groups.SelectedValue as string;var data=await Task.Run(()=>app.SanPham.LaySanPham(string.IsNullOrEmpty(ma)?null:ma));grid.DataSource=data;});}
        SanPham Selected(){var p=grid.CurrentRow==null?null:grid.CurrentRow.DataBoundItem as SanPham;if(p==null)throw new InvalidOperationException("Vui lòng chọn sản phẩm.");return p;}
        void RefreshStatus(){status.Text=app.Khach==null?"Chưa đăng nhập — bạn vẫn có thể chọn hàng":"Xin chào, "+app.Khach.HoTen;cart.Text="Giỏ: "+app.GioHang.Gio.DanhSachDong.Sum(x=>x.SoLuong)+" sản phẩm | "+Ui.Money(app.GioHang.TinhTienHang());}
    }
    public class FrmChiTietSanPham : LabForm
    {
        public FrmChiTietSanPham(SanPham p,Context app):base("Chi tiết sản phẩm",660,480)
        {
            var image=new PictureBox{Location=new Point(25,30),Size=new Size(180,180),SizeMode=PictureBoxSizeMode.Zoom};
            var bitmap=Ui.ProductImage(p.MaSanPham);image.Image=bitmap;FormClosed+=(s,e)=>{bitmap.Dispose();};
            var details=new TextBox{Location=new Point(230,25),Size=new Size(400,335),ReadOnly=true,Multiline=true,ScrollBars=ScrollBars.Vertical,BorderStyle=BorderStyle.None,BackColor=Color.White,
                Text=p.TenSanPham+"\r\nMã: "+p.MaSanPham+"\r\nNhà sản xuất: "+p.NhaSanXuat+"\r\nGiá: "+Ui.Money(p.GiaHienHanh)+"\r\nTình trạng: "+(p.ConHang?"Còn hàng":"Hết hàng")+"\r\n\r\n"+p.MoTa+"\r\n\r\nThông số: "+p.ThongSoKyThuat+"\r\n\r\nẢnh minh họa dùng cho bản LAB."};
            Shown+=(s,e)=>{details.Select(0,0);};
            var qty=new NumericUpDown{Location=new Point(230,385),Minimum=1,Maximum=1000,Value=1,Width=80};var add=Ui.Button("Thêm vào giỏ",335,380,180);add.Enabled=p.ConHang;
            Controls.AddRange(new Control[]{image,details,qty,add});add.Click+=async(s,e)=>await Run(async()=>{var fresh=await Task.Run(()=>app.SanPham.LayChiTiet(p.MaSanPham));app.GioHang.Them(fresh,(int)qty.Value);MessageBox.Show(this,"Đã thêm vào giỏ.");});
        }
    }
}
