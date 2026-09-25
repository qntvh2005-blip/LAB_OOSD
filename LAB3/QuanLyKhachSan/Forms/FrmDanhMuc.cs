using System;
using System.Windows.Forms;
using QuanLyKhachSan.Services;
namespace QuanLyKhachSan.Forms
{
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService s=new DanhMucService();
        public FrmDanhMuc() {InitializeComponent();}
        private void FrmDanhMuc_Load(object sender,EventArgs e)
        {
            if(UI.IsDesign)return;
            UI.Fit(this);
            UI.Wire(this,btnDong,()=>Close());
            foreach(var button in new[]{btnTaiKhu,btnTaiNV,btnTaiLoai,btnTaiDV,btnTaiQD})UI.Wire(this,button,Reload);
            UI.Wire(this,btnThemKhu,()=>Save("KhuVuc",txtKhuMa.Text.Trim(),txtKhuTen.Text.Trim()));
            UI.Wire(this,btnThemNV,()=>Save("NhanVien",txtNVMa.Text.Trim(),txtNVTen.Text.Trim(),txtNVVaiTro.Text.Trim(),Optional(txtNVSDT.Text)));
            UI.Wire(this,btnThemLoai,()=>Save("LoaiTienNghi",txtLoaiMa.Text.Trim(),txtLoaiTen.Text.Trim()));
            UI.Wire(this,btnThemDV,()=>Save("DichVu",txtDVMa.Text.Trim(),txtDVTen.Text.Trim(),txtDVDVT.Text.Trim(),numDVGia.Value));
            UI.Wire(this,btnThemQD,()=>Save("QuyDinhDenBu",txtQDMa.Text.Trim(),UI.V(cboQDLoai),txtQDMucDo.Text.Trim(),numQDTien.Value));
            foreach(var g in new[]{dgvKhu,dgvNV,dgvLoai,dgvDV,dgvQD})UI.FormatGrid(g);
            UI.Run(this,Reload);
        }
        private static object Optional(string text) {return string.IsNullOrWhiteSpace(text)?(object)DBNull.Value:text.Trim();}
        private void Save(string table,params object[] args) {s.Add(table,args); Reload(); UI.Done(this);}
        private void Reload()
        {
            dgvKhu.DataSource=s.List("KhuVuc"); dgvNV.DataSource=s.List("NhanVien");
            dgvLoai.DataSource=s.List("LoaiTienNghi"); dgvDV.DataSource=s.List("DichVu"); dgvQD.DataSource=s.List("QuyDinhDenBu");
            UI.Bind(cboQDLoai,s.List("LoaiTienNghi"),"MaLoaiTN","TenLoaiTN");
        }
    }
}
