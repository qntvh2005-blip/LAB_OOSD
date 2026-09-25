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
            if(UI.IsDesign)return;
            UI.Fit(this);
            numSL.Minimum=1;
            UI.Wire(this,btnDong,()=>Close());UI.Wire(this,btnTai,Reload);
            cboLuot.SelectedIndexChanged+=(a,b)=>UI.Run(this,Detail);
            UI.Wire(this,btnGhi,()=> {
                Db.Require(cboLuot.SelectedItem is DataRowView,"Chưa có phiếu đang ở.");
                s.Record(UI.V(cboLuot),txtPhong.Text,dtNgay.Value,UI.V(cboNV),UI.V(cboDV),(int)numSL.Value);Detail();UI.Done(this);
            });
            UI.FormatGrid(dgvLichSu);UI.Run(this,Reload);
        }
        private void Reload()
        {
            loading=true;
            try {UI.Bind(cboLuot,s.Stays(),"SoPhieuDat","HienThi");UI.Bind(cboDV,dm.List("DichVu"),"MaDV","TenDV");UI.Bind(cboNV,dm.List("NhanVien"),"MaNV","HoTen");}
            finally {loading=false;}Detail();
        }
        private void Detail()
        {
            if(loading)return;
            var row=cboLuot.SelectedItem as DataRowView;txtPhong.Text=row==null?"":Convert.ToString(row["SoPhong"]);
            dgvLichSu.DataSource=s.History(UI.V(cboLuot));
        }
    }
}
