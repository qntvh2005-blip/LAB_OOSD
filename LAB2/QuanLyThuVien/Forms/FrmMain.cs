using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            Text = "Quản lý thư viện";
            ClientSize = new Size(780, 450);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;

            Label lblTitle = new Label
            {
                Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN",
                Location = new Point(120, 30),
                Size = new Size(540, 50),
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btnDanhMuc = TaoNut(
                "btnDanhMuc", "Danh mục / Nhân viên", 140, 110);

            Button btnSach = TaoNut(
                "btnSach", "Quản lý đầu sách", 400, 110);

            Button btnDocGia = TaoNut(
                "btnDocGia", "Độc giả và thẻ", 140, 190);

            Button btnMuonTra = TaoNut(
                "btnMuonTra", "Mượn - Trả sách", 400, 190);

            Button btnThongKe = TaoNut(
                "btnThongKe", "Thống kê", 140, 270);

            Button btnThoat = TaoNut(
                "btnThoat", "Thoát", 400, 270);

            btnDanhMuc.Click += btnDanhMuc_Click;
            btnSach.Click += btnSach_Click;
            btnDocGia.Click += btnDocGia_Click;
            btnMuonTra.Click += btnMuonTra_Click;
            btnThongKe.Click += btnThongKe_Click;
            btnThoat.Click += btnThoat_Click;

            Controls.Add(lblTitle);
            Controls.Add(btnDanhMuc);
            Controls.Add(btnSach);
            Controls.Add(btnDocGia);
            Controls.Add(btnMuonTra);
            Controls.Add(btnThongKe);
            Controls.Add(btnThoat);
        }

        private Button TaoNut(string name, string text, int x, int y)
        {
            return new Button
            {
                Name = name,
                Text = text,
                Location = new Point(x, y),
                Size = new Size(240, 60),
                Font = new Font("Segoe UI", 11, FontStyle.Regular)
            };
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            using (FrmDanhMuc f = new FrmDanhMuc())
                f.ShowDialog(this);
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            using (FrmSach f = new FrmSach())
                f.ShowDialog(this);
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            using (FrmDocGia f = new FrmDocGia())
                f.ShowDialog(this);
        }

        private void btnMuonTra_Click(object sender, EventArgs e)
        {
            using (FrmMuonTra f = new FrmMuonTra())
                f.ShowDialog(this);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            using (FrmThongKe f = new FrmThongKe())
                f.ShowDialog(this);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Bạn có thực sự muốn thoát chương trình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}