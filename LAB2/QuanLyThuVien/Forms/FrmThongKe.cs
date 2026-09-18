using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public partial class FrmThongKe : Form
    {
        private readonly ThongKeService service = new ThongKeService();

        private DateTimePicker dtTu;
        private DateTimePicker dtDen;

        private Label lblMuon;
        private Label lblQuaHan;
        private Label lblMat;
        private Label lblHuHong;
        private Label lblPhiPhat;

        private DataGridView dgvPhat;

        public FrmThongKe()
        {
            InitializeComponent();
            TaoGiaoDien();
            Load += FrmThongKe_Load;
        }

        private void TaoGiaoDien()
        {
            Text = "Thống kê thư viện";
            ClientSize = new Size(1100, 700);
            StartPosition = FormStartPosition.CenterParent;

            Panel top = new Panel
            {
                Dock = DockStyle.Top,
                Height = 230
            };

            dtTu = new DateTimePicker
            {
                Location = new Point(110, 20),
                Size = new Size(180, 28),
                Format = DateTimePickerFormat.Short
            };

            dtDen = new DateTimePicker
            {
                Location = new Point(420, 20),
                Size = new Size(180, 28),
                Format = DateTimePickerFormat.Short
            };

            Button btnThongKe = new Button
            {
                Text = "Thống kê",
                Location = new Point(680, 18),
                Size = new Size(130, 35)
            };
            btnThongKe.Click += btnThongKe_Click;

            lblMuon = TaoKPI("Số lượt sách mượn", 20, 90);
            lblQuaHan = TaoKPI("Sách quá hạn", 235, 90);
            lblMat = TaoKPI("Sách mất", 450, 90);
            lblHuHong = TaoKPI("Sách hư hỏng", 665, 90);
            lblPhiPhat = TaoKPI("Tổng phí phạt", 880, 90);

            top.Controls.AddRange(new Control[]
            {
                TaoLabel("Từ ngày:", 35, 23),
                dtTu,
                TaoLabel("Đến ngày:", 345, 23),
                dtDen,
                btnThongKe,

                lblMuon,
                lblQuaHan,
                lblMat,
                lblHuHong,
                lblPhiPhat
            });

            dgvPhat = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            Button btnDong = new Button
            {
                Text = "Đóng",
                Dock = DockStyle.Bottom,
                Height = 42
            };
            btnDong.Click += (s, e) => Close();

            Controls.Add(dgvPhat);
            Controls.Add(top);
            Controls.Add(btnDong);
        }

        private Label TaoLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true
            };
        }

        private Label TaoKPI(string tieuDe, int x, int y)
        {
            return new Label
            {
                Text = tieuDe + "\n0",
                Location = new Point(x, y),
                Size = new Size(195, 80),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            dtTu.Value = new DateTime(
                DateTime.Today.Year,
                DateTime.Today.Month,
                1);

            dtDen.Value = DateTime.Today;

            TaiThongKe();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            TaiThongKe();
        }

        private void TaiThongKe()
        {
            DateTime tuNgay = dtTu.Value.Date;
            DateTime denNgay = dtDen.Value.Date;

            if (tuNgay > denNgay)
            {
                DateTime tam = tuNgay;
                tuNgay = denNgay;
                denNgay = tam;

                dtTu.Value = tuNgay;
                dtDen.Value = denNgay;
            }

            ThongKeTongHop kq = service.LayTongHop(
                tuNgay,
                denNgay);

            lblMuon.Text = "Số lượt sách mượn\n" +
                kq.LuotSachMuon;

            lblQuaHan.Text = "Sách quá hạn\n" +
                kq.SachQuaHan;

            lblMat.Text = "Sách mất\n" +
                kq.SachMat;

            lblHuHong.Text = "Sách hư hỏng\n" +
                kq.SachHuHong;

            lblPhiPhat.Text = "Tổng phí phạt\n" +
                kq.TongPhiPhat.ToString("N0") + " đ";

            dgvPhat.DataSource = service.LayPhieuPhat(
                tuNgay,
                denNgay);
        }
    }
}