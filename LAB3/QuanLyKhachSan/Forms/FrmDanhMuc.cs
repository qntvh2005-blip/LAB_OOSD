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
            if(IsDesign)return;
            FitToScreen();
            Wire(btnDong,()=>Close());
            foreach(var button in new[]{btnTaiKhu,btnTaiNV,btnTaiLoai,btnTaiDV,btnTaiQD})Wire(button,Reload);
            Wire(btnThemKhu,()=>Save("KhuVuc",txtKhuMa.Text.Trim(),txtKhuTen.Text.Trim()));
            Wire(btnThemNV,()=>Save("NhanVien",txtNVMa.Text.Trim(),txtNVTen.Text.Trim(),txtNVVaiTro.Text.Trim(),Optional(txtNVSDT.Text)));
            Wire(btnThemLoai,()=>Save("LoaiTienNghi",txtLoaiMa.Text.Trim(),txtLoaiTen.Text.Trim()));
            Wire(btnThemDV,()=>Save("DichVu",txtDVMa.Text.Trim(),txtDVTen.Text.Trim(),txtDVDVT.Text.Trim(),numDVGia.Value));
            Wire(btnThemQD,()=>Save("QuyDinhDenBu",txtQDMa.Text.Trim(),Value(cboQDLoai),txtQDMucDo.Text.Trim(),numQDTien.Value));
            foreach(var g in new[]{dgvKhu,dgvNV,dgvLoai,dgvDV,dgvQD})FormatGrid(g);
            Run(Reload);
        }
        private static object Optional(string text) {return string.IsNullOrWhiteSpace(text)?(object)DBNull.Value:text.Trim();}
        private void Save(string table,params object[] args) {s.Add(table,args); Reload(); Done();}
        private void Reload()
        {
            dgvKhu.DataSource=s.List("KhuVuc"); dgvNV.DataSource=s.List("NhanVien");
            dgvLoai.DataSource=s.List("LoaiTienNghi"); dgvDV.DataSource=s.List("DichVu"); dgvQD.DataSource=s.List("QuyDinhDenBu");
            Bind(cboQDLoai,s.List("LoaiTienNghi"),"MaLoaiTN","TenLoaiTN");
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
