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
            if(UI.IsDesign)return;
            UI.Fit(this);
            numSoNgay.Minimum=1;txtSoDB.Text=Db.Id("DB");txtSoHD.Text=Db.Id("HD");dgvDBChon.DataSource=pending;
            cboHT.Items.AddRange(new object[]{"Tiền mặt","Chuyển khoản","Thẻ","Ví điện tử"});cboHT.SelectedIndex=0;
            cboDat.SelectedIndexChanged+=(a,b)=>UI.Run(this,StayDetail);
            dgvPhong.SelectionChanged+=(a,b)=>UI.Run(this,RoomDetail);
            dgvTN.SelectionChanged+=(a,b)=>UI.Run(this,DeviceDetail);
            dgvHD.SelectionChanged+=(a,b)=>UI.Run(this,PaymentDetail);
            cboMucDo.SelectedIndexChanged+=(a,b)=>UI.Run(this,RuleDetail);
            UI.Wire(this,btnDong,()=>Close());UI.Wire(this,btnTai,Reload);
            UI.Wire(this,btnThemDB,()=> {
                string device=UI.Cell(dgvTN,"MaTienNghi");Db.Required(device,UI.V(cboMucDo));
                foreach(var item in pending)Db.Require(item.MaTienNghi!=device,"Thiết bị đã có trong phiếu.");
                pending.Add(new DenBuItem {MaTienNghi=device,MucDoThietHai=UI.V(cboMucDo),SoTien=numDenBu.Value});
            });
            UI.Wire(this,btnBoDB,()=> {if(dgvDBChon.CurrentRow!=null)pending.RemoveAt(dgvDBChon.CurrentRow.Index);});
            UI.Wire(this,btnLapDB,()=> {
                s.Damage(txtSoDB.Text.Trim(),UI.V(cboDat),UI.Cell(dgvPhong,"SoPhong"),UI.V(cboNV),new List<DenBuItem>(pending));
                txtSoDB.Text=Db.Id("DB");pending.Clear();dgvDB.DataSource=s.Damages(UI.V(cboDat));RoomDetail();UI.Done(this);
            });
            UI.Wire(this,btnLapHD,()=> {
                s.Invoice(txtSoHD.Text.Trim(),UI.V(cboDat),UI.V(cboNV),(int)numSoNgay.Value);txtSoHD.Text=Db.Id("HD");LoadInvoices();UI.Done(this);
            });
            UI.Wire(this,btnThanhToan,()=> {
                s.Pay(Db.Id("TT"),UI.Cell(dgvHD,"SoHoaDon"),cboHT.Text,numTienTT.Value);LoadInvoices();UI.Done(this);
            });
            UI.Wire(this,btnTraPhong,()=> {s.CheckOut(UI.V(cboDat));Reload();UI.Done(this);});
            foreach(var g in new[]{dgvPhong,dgvTN,dgvDBChon,dgvHD,dgvDB,dgvTT})UI.FormatGrid(g);
            UI.Run(this,Reload);
        }
        private void Reload()
        {
            string old=UI.V(cboDat);loading=true;
            try {UI.Bind(cboDat,s.Stays(),"SoPhieuDat");if(!string.IsNullOrEmpty(old))cboDat.SelectedValue=old;UI.Bind(cboNV,dm.List("NhanVien"),"MaNV","HoTen");}
            finally {loading=false;}
            if(cboDat.SelectedIndex<0 && cboDat.Items.Count>0)cboDat.SelectedIndex=0;
            StayDetail();
        }
        private void StayDetail()
        {
            if(loading)return;
            // Chặn SelectionChanged trong lúc đổi DataSource; sau đó nạp chi tiết đúng một lượt.
            loading=true;
            try {pending.Clear();dgvPhong.DataSource=booking.Rooms(UI.V(cboDat));dgvDB.DataSource=s.Damages(UI.V(cboDat));}
            finally {loading=false;}
            RoomDetail();LoadInvoices();
        }
        private void RoomDetail()
        {
            if(loading)return;
            loading=true;
            try {pending.Clear();dgvTN.DataSource=s.Equipment(UI.Cell(dgvPhong,"SoPhong"));}
            finally {loading=false;}
            DeviceDetail();
        }
        private void DeviceDetail()
        {
            if(loading)return;
            loading=true;
            try {UI.Bind(cboMucDo,s.Rules(UI.Cell(dgvTN,"MaLoaiTN")),"MucDoThietHai");}
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
            try {dgvHD.DataSource=s.Invoices(UI.V(cboDat));}
            finally {loading=false;}
            PaymentDetail();
        }
        private void PaymentDetail() {if(!loading)dgvTT.DataSource=s.Payments(UI.Cell(dgvHD,"SoHoaDon"));}
    }
}
