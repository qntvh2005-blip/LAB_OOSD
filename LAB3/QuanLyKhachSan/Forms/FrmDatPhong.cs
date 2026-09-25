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
            if(UI.IsDesign)return;
            UI.Fit(this);
            numSoNguoi.Minimum=1;txtSoPhieu.Text=Db.Id("DP");txtQT.Text="Việt Nam";txtNguoiQT.Text="Việt Nam";
            dtTra.Value=DateTime.Today.AddDays(1);cboKenh.Items.AddRange(new object[]{"Điện thoại","Website","Trực tiếp"});cboKenh.SelectedIndex=2;
            dgvChon.DataSource=chosen;
            UI.Wire(this,btnDong,()=>Close());
            UI.Wire(this,btnTaiKhach,ReloadBooking);UI.Wire(this,btnTaiDat,ReloadBooking);UI.Wire(this,btnTaiNhan,ReloadCheckIn);
            UI.Wire(this,btnThemKhach,()=> {
                dm.Add("KhachHang",txtMaKH.Text.Trim(),txtTenKH.Text.Trim(),txtCMND.Text.Trim(),txtQT.Text.Trim(),string.IsNullOrWhiteSpace(txtSDT.Text)?(object)DBNull.Value:txtSDT.Text.Trim());
                ReloadBooking();UI.Done(this);
            });
            UI.Wire(this,btnThemPhong,()=> {
                string room=UI.Cell(dgvPhong,"SoPhong");Db.Required(room);
                foreach(var r in chosen)Db.Require(r.SoPhong!=room,"Phòng đã có trong phiếu.");
                chosen.Add(new PhongDatItem {SoPhong=room,SoNguoi=(int)numSoNguoi.Value,DonGiaNgay=Convert.ToDecimal(UI.Cell(dgvPhong,"DonGiaNgay"))});
            });
            UI.Wire(this,btnBoPhong,()=> {if(dgvChon.CurrentRow!=null)chosen.RemoveAt(dgvChon.CurrentRow.Index);});
            UI.Wire(this,btnLapPhieu,()=> {
                s.Book(txtSoPhieu.Text.Trim(),UI.V(cboKhach),UI.V(cboNV),dtNhan.Value,dtTra.Value,numCoc.Value,cboKenh.Text,new List<PhongDatItem>(chosen));
                chosen.Clear();txtSoPhieu.Text=Db.Id("DP");ReloadBooking();ReloadCheckIn();UI.Done(this);
            });
            cboPhieuNhan.SelectedIndexChanged+=(a,b)=>UI.Run(this,LoadGuests);
            UI.Wire(this,btnThemNguoi,()=> {
                s.AddGuest(UI.V(cboPhieuNhan),UI.V(cboPhongNhan),txtNguoiTen.Text.Trim(),txtNguoiCMND.Text.Trim(),txtNguoiQT.Text.Trim());
                LoadGuests();txtNguoiTen.Clear();txtNguoiCMND.Clear();UI.Done(this);
            });
            UI.Wire(this,btnNhanPhong,()=> {s.CheckIn(UI.V(cboPhieuNhan));ReloadCheckIn();ReloadBooking();UI.Done(this);});
            UI.Wire(this,btnNoShow,()=> {
                if(MessageBox.Show(this,"Xác nhận khách không đến nhận phòng?","No-show",MessageBoxButtons.YesNo)==DialogResult.Yes) {
                    s.NoShow(UI.V(cboPhieuNhan));ReloadCheckIn();ReloadBooking();UI.Done(this);
                }
            });
            foreach(var g in new[]{dgvKhach,dgvPhong,dgvChon,dgvPhieu,dgvCT,dgvNguoi})UI.FormatGrid(g);
            UI.Run(this,()=> {ReloadBooking();ReloadCheckIn();});
        }
        private void ReloadBooking()
        {
            dgvKhach.DataSource=dm.List("KhachHang");dgvPhong.DataSource=dm.List("Phong");dgvPhieu.DataSource=s.List();
            UI.Bind(cboKhach,dm.List("KhachHang"),"MaKhach","HoTen");UI.Bind(cboNV,dm.List("NhanVien"),"MaNV","HoTen");
        }
        private void ReloadCheckIn()
        {
            string old=UI.V(cboPhieuNhan);loading=true;
            try {UI.Bind(cboPhieuNhan,s.List(),"SoPhieuDat");if(!string.IsNullOrEmpty(old))cboPhieuNhan.SelectedValue=old;}
            finally {loading=false;}
            if(cboPhieuNhan.SelectedIndex<0 && cboPhieuNhan.Items.Count>0)cboPhieuNhan.SelectedIndex=0;
            LoadGuests();
        }
        private void LoadGuests()
        {
            if(loading)return;
            string stay=UI.V(cboPhieuNhan);dgvCT.DataSource=s.Rooms(stay);UI.Bind(cboPhongNhan,s.Rooms(stay),"SoPhong");dgvNguoi.DataSource=s.Guests(stay);
        }
    }
}
