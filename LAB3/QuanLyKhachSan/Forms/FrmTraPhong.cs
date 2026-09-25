using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyKhachSan.Data;
using QuanLyKhachSan.Services;
namespace QuanLyKhachSan.Forms
{
    public partial class FrmTraPhong : Form
    {
        private readonly TraPhongService s=new TraPhongService();
        private readonly DatPhongService booking=new DatPhongService();
        private readonly DanhMucService dm=new DanhMucService();
        private readonly BindingList<DenBuItem> pending=new BindingList<DenBuItem>();
        private bool loading;
        public FrmTraPhong() {InitializeComponent();}
        private void FrmTraPhong_Load(object sender,EventArgs e)
        {
            if(IsDesign)return;
            FitToScreen();
            numSoNgay.Minimum=1;txtSoDB.Text=Db.Id("DB");txtSoHD.Text=Db.Id("HD");dgvDBChon.DataSource=pending;
            cboHT.Items.AddRange(new object[]{"Tiền mặt","Chuyển khoản","Thẻ","Ví điện tử"});cboHT.SelectedIndex=0;
            cboDat.SelectedIndexChanged+=(a,b)=>Run(StayDetail);
            dgvPhong.SelectionChanged+=(a,b)=>Run(RoomDetail);
            dgvTN.SelectionChanged+=(a,b)=>Run(DeviceDetail);
            dgvHD.SelectionChanged+=(a,b)=>Run(PaymentDetail);
            cboMucDo.SelectedIndexChanged+=(a,b)=>Run(RuleDetail);
            Wire(btnDong,()=>Close());Wire(btnTai,Reload);
            Wire(btnThemDB,()=> {
                string device=Cell(dgvTN,"MaTienNghi");Db.Required(device,Value(cboMucDo));
                foreach(var item in pending)Db.Require(item.MaTienNghi!=device,"Thiết bị đã có trong phiếu.");
                pending.Add(new DenBuItem {MaTienNghi=device,MucDoThietHai=Value(cboMucDo),SoTien=numDenBu.Value});
            });
            Wire(btnBoDB,()=> {if(dgvDBChon.CurrentRow!=null)pending.RemoveAt(dgvDBChon.CurrentRow.Index);});
            Wire(btnLapDB,()=> {
                s.Damage(txtSoDB.Text.Trim(),Value(cboDat),Cell(dgvPhong,"SoPhong"),Value(cboNV),new List<DenBuItem>(pending));
                txtSoDB.Text=Db.Id("DB");pending.Clear();dgvDB.DataSource=s.Damages(Value(cboDat));RoomDetail();Done();
            });
            Wire(btnLapHD,()=> {
                s.Invoice(txtSoHD.Text.Trim(),Value(cboDat),Value(cboNV),(int)numSoNgay.Value);txtSoHD.Text=Db.Id("HD");LoadInvoices();Done();
            });
            Wire(btnThanhToan,()=> {
                s.Pay(Db.Id("TT"),Cell(dgvHD,"SoHoaDon"),cboHT.Text,numTienTT.Value);LoadInvoices();Done();
            });
            Wire(btnTraPhong,()=> {s.CheckOut(Value(cboDat));Reload();Done();});
            foreach(var g in new[]{dgvPhong,dgvTN,dgvDBChon,dgvHD,dgvDB,dgvTT})FormatGrid(g);
            Run(Reload);
        }
        private void Reload()
        {
            string old=Value(cboDat);loading=true;
            try {Bind(cboDat,s.Stays(),"SoPhieuDat");if(!string.IsNullOrEmpty(old))cboDat.SelectedValue=old;Bind(cboNV,dm.List("NhanVien"),"MaNV","HoTen");}
            finally {loading=false;}
            if(cboDat.SelectedIndex<0 && cboDat.Items.Count>0)cboDat.SelectedIndex=0;
            StayDetail();
        }
        private void StayDetail()
        {
            if(loading)return;
            // Chặn SelectionChanged trong lúc đổi DataSource; sau đó nạp chi tiết đúng một lượt.
            loading=true;
            try {pending.Clear();dgvPhong.DataSource=booking.Rooms(Value(cboDat));dgvDB.DataSource=s.Damages(Value(cboDat));}
            finally {loading=false;}
            RoomDetail();LoadInvoices();
        }
        private void RoomDetail()
        {
            if(loading)return;
            loading=true;
            try {pending.Clear();dgvTN.DataSource=s.Equipment(Cell(dgvPhong,"SoPhong"));}
            finally {loading=false;}
            DeviceDetail();
        }
        private void DeviceDetail()
        {
            if(loading)return;
            loading=true;
            try {Bind(cboMucDo,s.Rules(Cell(dgvTN,"MaLoaiTN")),"MucDoThietHai");}
            finally {loading=false;}
            RuleDetail();
        }
        private void RuleDetail()
        {
            if(loading)return;
            var row=cboMucDo.SelectedItem as DataRowView;numDenBu.Value=row==null?0:Convert.ToDecimal(row["MucDenBu"]);
        }
        private void LoadInvoices()
        {
            loading=true;
            try {dgvHD.DataSource=s.Invoices(Value(cboDat));}
            finally {loading=false;}
            PaymentDetail();
        }
        private void PaymentDetail() {if(!loading)dgvTT.DataSource=s.Payments(Cell(dgvHD,"SoHoaDon"));}
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
