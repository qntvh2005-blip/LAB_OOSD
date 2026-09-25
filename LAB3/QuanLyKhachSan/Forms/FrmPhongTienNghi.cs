using System;
using System.Windows.Forms;
using QuanLyKhachSan.Data;
using QuanLyKhachSan.Services;
namespace QuanLyKhachSan.Forms
{
    public partial class FrmPhongTienNghi : Form
    {
        private readonly DanhMucService dm=new DanhMucService();
        private readonly PhongTienNghiService s=new PhongTienNghiService();
        public FrmPhongTienNghi() {InitializeComponent();}
        private void FrmPhongTienNghi_Load(object sender,EventArgs e)
        {
            if(UI.IsDesign)return;
            UI.Fit(this);
            numMax.Minimum=1;numSTT.Minimum=1;txtSoLD.Text=Db.Id("LD");txtTinhTrang.Text="Tốt";txtTTLD.Text="Tốt";
            UI.Wire(this,btnDong,()=>Close());
            foreach(var b in new[]{btnTai,btnTaiPhong,btnTaiTN}) UI.Wire(this,b,Reload);
            UI.Wire(this,btnThemPhong,()=> {dm.Add("Phong",txtPhong.Text.Trim(),UI.V(cboKhu),numMax.Value,numGia.Value);Reload();UI.Done(this);});
            UI.Wire(this,btnThemTN,()=> {dm.Add("TienNghi",txtMaTN.Text.Trim(),UI.V(cboLoai),numSTT.Value,txtTinhTrang.Text.Trim());Reload();UI.Done(this);});
            UI.Wire(this,btnLapDat,()=> {
                s.Install(txtSoLD.Text.Trim(),UI.V(cboTN),UI.V(cboPhong),dtNgay.Value,txtTTLD.Text.Trim(),UI.V(cboNV),txtGhiChu.Text.Trim());
                txtSoLD.Text=Db.Id("LD");Reload();UI.Done(this);
            });
            foreach(var g in new[]{dgvPhong,dgvTN,dgvLD})UI.FormatGrid(g);
            UI.Run(this,Reload);
        }
        private void Reload()
        {
            dgvPhong.DataSource=dm.List("Phong"); dgvTN.DataSource=dm.List("TienNghi");dgvLD.DataSource=s.History();
            UI.Bind(cboKhu,dm.List("KhuVuc"),"MaKhuVuc","TenKhuVuc");UI.Bind(cboLoai,dm.List("LoaiTienNghi"),"MaLoaiTN","TenLoaiTN");
            UI.Bind(cboTN,dm.List("TienNghi"),"MaTienNghi");UI.Bind(cboPhong,dm.List("Phong"),"SoPhong");UI.Bind(cboNV,dm.List("NhanVien"),"MaNV","HoTen");
        }
    }
}
