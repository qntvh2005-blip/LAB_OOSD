using System;
using System.Windows.Forms;
using QuanLyKhachSan.Services;
namespace QuanLyKhachSan.Forms
{
    public partial class FrmThongKe : Form
    {
        private readonly ThongKeService s=new ThongKeService();
        public FrmThongKe() {InitializeComponent();}
        private void FrmThongKe_Load(object sender,EventArgs e)
        {
            if(UI.IsDesign)return;
            UI.Fit(this);
            dtTu.Value=new DateTime(DateTime.Today.Year,DateTime.Today.Month,1);
            UI.Wire(this,btnDong,()=>Close());UI.Wire(this,btnTK,Reload);UI.FormatGrid(dgvDV);UI.Run(this,Reload);
        }
        private void Reload()
        {
            var row=s.Summary(dtTu.Value,dtDen.Value).Rows[0];
            lblPhieu.Text="Phiếu đặt: "+row["SoPhieuDat"];
            lblDangO.Text="Đang ở hiện tại: "+row["DangOHienTai"];
            lblHoaDon.Text="Hóa đơn: "+row["SoHoaDon"];
            lblDoanhThu.Text="Doanh thu HĐ: "+Convert.ToDecimal(row["TongHoaDon"]).ToString("N0")+" đ";
            lblDenBu.Text="Tổng đền bù: "+Convert.ToDecimal(row["TongPhieuDenBu"]).ToString("N0")+" đ";
            lblThucThu.Text="Thực thu HĐ: "+Convert.ToDecimal(row["ThucThuHoaDon"]).ToString("N0")+" đ";
            dgvDV.DataSource=s.Services(dtTu.Value,dtDen.Value);
        }
    }
}
