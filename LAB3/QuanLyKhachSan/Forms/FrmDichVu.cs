using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.Data;
using QuanLyKhachSan.Services;
namespace QuanLyKhachSan.Forms
{
    public partial class FrmDichVu : Form
    {
        private readonly DichVuService s=new DichVuService();
        private readonly DanhMucService dm=new DanhMucService();
        private bool loading;
        public FrmDichVu() {InitializeComponent();}
        private void FrmDichVu_Load(object sender,EventArgs e)
        {
            if(IsDesign)return;
            FitToScreen();
            numSL.Minimum=1;
            Wire(btnDong,()=>Close());Wire(btnTai,Reload);
            cboLuot.SelectedIndexChanged+=(a,b)=>Run(Detail);
            Wire(btnGhi,()=> {
                Db.Require(cboLuot.SelectedItem is DataRowView,"Chưa có phiếu đang ở.");
                s.Record(Value(cboLuot),txtPhong.Text,dtNgay.Value,Value(cboNV),Value(cboDV),(int)numSL.Value);Detail();Done();
            });
            FormatGrid(dgvLichSu);Run(Reload);
        }
        private void Reload()
        {
            loading=true;
            try {Bind(cboLuot,s.Stays(),"SoPhieuDat","HienThi");Bind(cboDV,dm.List("DichVu"),"MaDV","TenDV");Bind(cboNV,dm.List("NhanVien"),"MaNV","HoTen");}
            finally {loading=false;}Detail();
        }
        private void Detail()
        {
            if(loading)return;
            var row=cboLuot.SelectedItem as DataRowView;txtPhong.Text=row==null?"":Convert.ToString(row["SoPhong"]);
            dgvLichSu.DataSource=s.History(Value(cboLuot));
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
