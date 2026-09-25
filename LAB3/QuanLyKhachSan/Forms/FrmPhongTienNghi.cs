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
            if(IsDesign)return;
            FitToScreen();
            numMax.Minimum=1;numSTT.Minimum=1;txtSoLD.Text=Db.Id("LD");txtTinhTrang.Text="Tốt";txtTTLD.Text="Tốt";
            Wire(btnDong,()=>Close());
            foreach(var b in new[]{btnTai,btnTaiPhong,btnTaiTN}) Wire(b,Reload);
            Wire(btnThemPhong,()=> {dm.Add("Phong",txtPhong.Text.Trim(),Value(cboKhu),numMax.Value,numGia.Value);Reload();Done();});
            Wire(btnThemTN,()=> {dm.Add("TienNghi",txtMaTN.Text.Trim(),Value(cboLoai),numSTT.Value,txtTinhTrang.Text.Trim());Reload();Done();});
            Wire(btnLapDat,()=> {
                s.Install(txtSoLD.Text.Trim(),Value(cboTN),Value(cboPhong),dtNgay.Value,txtTTLD.Text.Trim(),Value(cboNV),txtGhiChu.Text.Trim());
                txtSoLD.Text=Db.Id("LD");Reload();Done();
            });
            foreach(var g in new[]{dgvPhong,dgvTN,dgvLD})FormatGrid(g);
            Run(Reload);
        }
        private void Reload()
        {
            dgvPhong.DataSource=dm.List("Phong"); dgvTN.DataSource=dm.List("TienNghi");dgvLD.DataSource=s.History();
            Bind(cboKhu,dm.List("KhuVuc"),"MaKhuVuc","TenKhuVuc");Bind(cboLoai,dm.List("LoaiTienNghi"),"MaLoaiTN","TenLoaiTN");
            Bind(cboTN,dm.List("TienNghi"),"MaTienNghi");Bind(cboPhong,dm.List("Phong"),"SoPhong");Bind(cboNV,dm.List("NhanVien"),"MaNV","HoTen");
        }
        private static bool IsDesign { get { return System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime; } }
        private void FitToScreen()
        {
            var bounds=System.Windows.Forms.Screen.FromControl(this).WorkingArea;
            AutoScroll=true; AutoScrollMinSize=ClientSize;
            Size=new System.Drawing.Size(Math.Min(Width,bounds.Width-20),Math.Min(Height,bounds.Height-20));
            Location=new System.Drawing.Point(bounds.Left+(bounds.Width-Width)/2,bounds.Top+(bounds.Height-Height)/2);
        }
        private void Run(System.Action action)
        { try { action(); } catch(System.Exception ex) { System.Windows.Forms.MessageBox.Show(this,ex.Message,"Không thực hiện được",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning); } }
        private void Done() { System.Windows.Forms.MessageBox.Show(this,"Thực hiện thành công.","Thông báo"); }
        private static void Bind(System.Windows.Forms.ComboBox control,System.Data.DataTable data,string value,string display=null)
        { control.DataSource=null; control.DisplayMember=display??value; control.ValueMember=value; control.DataSource=data; }
        private static string Value(System.Windows.Forms.ComboBox control)
        { var row=control.SelectedItem as System.Data.DataRowView; return row==null?control.Text:System.Convert.ToString(row[control.ValueMember]); }
        private static void FormatGrid(System.Windows.Forms.DataGridView grid)
        {
            foreach(System.Windows.Forms.DataGridViewColumn col in grid.Columns) {
                string p=col.DataPropertyName;
                if(p.Contains("Tien")||p.Contains("Gia")||p=="ConLai"||p=="MucDenBu") {
                    if(p=="MaTienNghi")continue;
                    col.DefaultCellStyle.Format="N0"; col.DefaultCellStyle.Alignment=System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
                }
                if(p.StartsWith("Ngay"))col.DefaultCellStyle.Format="dd/MM/yyyy";
            }
        }
        private void Wire(System.Windows.Forms.Button button,System.Action action)
        { button.Click+=(s,e)=>Run(action); }
    }
}
