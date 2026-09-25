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
            if(IsDesign)return;
            FitToScreen();
            dtTu.Value=new DateTime(DateTime.Today.Year,DateTime.Today.Month,1);
            Wire(btnDong,()=>Close());Wire(btnTK,Reload);FormatGrid(dgvDV);Run(Reload);
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
