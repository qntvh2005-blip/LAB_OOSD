using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyKhachSan.Data;
using QuanLyKhachSan.Services;
namespace QuanLyKhachSan.Forms
{
    public partial class FrmDatPhong : Form
    {
        private readonly DanhMucService dm=new DanhMucService();
        private readonly DatPhongService s=new DatPhongService();
        private readonly BindingList<PhongDatItem> chosen=new BindingList<PhongDatItem>();
        private bool loading;
        public FrmDatPhong() {InitializeComponent();}
        private void FrmDatPhong_Load(object sender,EventArgs e)
        {
            if(IsDesign)return;
            FitToScreen();
            numSoNguoi.Minimum=1;txtSoPhieu.Text=Db.Id("DP");txtQT.Text="Việt Nam";txtNguoiQT.Text="Việt Nam";
            dtTra.Value=DateTime.Today.AddDays(1);cboKenh.Items.AddRange(new object[]{"Điện thoại","Website","Trực tiếp"});cboKenh.SelectedIndex=2;
            dgvChon.DataSource=chosen;
            Wire(btnDong,()=>Close());
            Wire(btnTaiKhach,ReloadBooking);Wire(btnTaiDat,ReloadBooking);Wire(btnTaiNhan,ReloadCheckIn);
            Wire(btnThemKhach,()=> {
                dm.Add("KhachHang",txtMaKH.Text.Trim(),txtTenKH.Text.Trim(),txtCMND.Text.Trim(),txtQT.Text.Trim(),string.IsNullOrWhiteSpace(txtSDT.Text)?(object)DBNull.Value:txtSDT.Text.Trim());
                ReloadBooking();Done();
            });
            Wire(btnThemPhong,()=> {
                string room=Cell(dgvPhong,"SoPhong");Db.Required(room);
                foreach(var r in chosen)Db.Require(r.SoPhong!=room,"Phòng đã có trong phiếu.");
                chosen.Add(new PhongDatItem {SoPhong=room,SoNguoi=(int)numSoNguoi.Value,DonGiaNgay=Convert.ToDecimal(Cell(dgvPhong,"DonGiaNgay"))});
            });
            Wire(btnBoPhong,()=> {if(dgvChon.CurrentRow!=null)chosen.RemoveAt(dgvChon.CurrentRow.Index);});
            Wire(btnLapPhieu,()=> {
                s.Book(txtSoPhieu.Text.Trim(),Value(cboKhach),Value(cboNV),dtNhan.Value,dtTra.Value,numCoc.Value,cboKenh.Text,new List<PhongDatItem>(chosen));
                chosen.Clear();txtSoPhieu.Text=Db.Id("DP");ReloadBooking();ReloadCheckIn();Done();
            });
            cboPhieuNhan.SelectedIndexChanged+=(a,b)=>Run(LoadGuests);
            Wire(btnThemNguoi,()=> {
                s.AddGuest(Value(cboPhieuNhan),Value(cboPhongNhan),txtNguoiTen.Text.Trim(),txtNguoiCMND.Text.Trim(),txtNguoiQT.Text.Trim());
                LoadGuests();txtNguoiTen.Clear();txtNguoiCMND.Clear();Done();
            });
            Wire(btnNhanPhong,()=> {s.CheckIn(Value(cboPhieuNhan));ReloadCheckIn();ReloadBooking();Done();});
            Wire(btnNoShow,()=> {
                if(MessageBox.Show(this,"Xác nhận khách không đến nhận phòng?","No-show",MessageBoxButtons.YesNo)==DialogResult.Yes) {
                    s.NoShow(Value(cboPhieuNhan));ReloadCheckIn();ReloadBooking();Done();
                }
            });
            foreach(var g in new[]{dgvKhach,dgvPhong,dgvChon,dgvPhieu,dgvCT,dgvNguoi})FormatGrid(g);
            Run(()=> {ReloadBooking();ReloadCheckIn();});
        }
        private void ReloadBooking()
        {
            dgvKhach.DataSource=dm.List("KhachHang");dgvPhong.DataSource=dm.List("Phong");dgvPhieu.DataSource=s.List();
            Bind(cboKhach,dm.List("KhachHang"),"MaKhach","HoTen");Bind(cboNV,dm.List("NhanVien"),"MaNV","HoTen");
        }
        private void ReloadCheckIn()
        {
            string old=Value(cboPhieuNhan);loading=true;
            try {Bind(cboPhieuNhan,s.List(),"SoPhieuDat");if(!string.IsNullOrEmpty(old))cboPhieuNhan.SelectedValue=old;}
            finally {loading=false;}
            if(cboPhieuNhan.SelectedIndex<0 && cboPhieuNhan.Items.Count>0)cboPhieuNhan.SelectedIndex=0;
            LoadGuests();
        }
        private void LoadGuests()
        {
            if(loading)return;
            string stay=Value(cboPhieuNhan);dgvCT.DataSource=s.Rooms(stay);Bind(cboPhongNhan,s.Rooms(stay),"SoPhong");dgvNguoi.DataSource=s.Guests(stay);
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
        private static string Cell(System.Windows.Forms.DataGridView grid,string property)
        {
            if(grid.CurrentRow==null)return "";
            var row=grid.CurrentRow.DataBoundItem as System.Data.DataRowView;
            if(row!=null)return System.Convert.ToString(row[property]);
            foreach(System.Windows.Forms.DataGridViewColumn column in grid.Columns)
                if(column.DataPropertyName==property)return System.Convert.ToString(grid.CurrentRow.Cells[column.Index].Value);
            return "";
        }
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
