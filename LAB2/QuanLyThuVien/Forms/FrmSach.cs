using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public partial class FrmSach : Form
    {
        private readonly SachService service = new SachService();
        private readonly DanhMucService danhMuc = new DanhMucService();

        private TextBox txtMa;
        private TextBox txtTen;
        private NumericUpDown numNam;
        private NumericUpDown numSoLuong;
        private ComboBox cboTheLoai;
        private ComboBox cboNXB;
        private TextBox txtTim;
        private DataGridView dgvSach;

        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;

        public FrmSach()
        {
            InitializeComponent();
            TaoGiaoDien();
            Load += FrmSach_Load;
        }

        private void TaoGiaoDien()
        {
            Text = "Quản lý đầu sách";
            ClientSize = new Size(1120, 740);
            StartPosition = FormStartPosition.CenterParent;

            Panel panel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 250
            };

            txtMa = TaoTextBox(145, 25, 220);
            txtTen = TaoTextBox(525, 25, 280);

            numNam = new NumericUpDown
            {
                Location = new Point(145, 70),
                Size = new Size(220, 28),
                Minimum = 1000,
                Maximum = 3000
            };

            numSoLuong = new NumericUpDown
            {
                Location = new Point(525, 70),
                Size = new Size(280, 28),
                Minimum = 0,
                Maximum = 100000
            };

            cboTheLoai = new ComboBox
            {
                Location = new Point(145, 115),
                Size = new Size(220, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            cboNXB = new ComboBox
            {
                Location = new Point(525, 115),
                Size = new Size(280, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            txtTim = TaoTextBox(145, 165, 350);

            Button btnTim = TaoNut("Tìm", 520, 162);
            btnThem = TaoNut("Thêm", 140, 210);
            btnCapNhat = TaoNut("Cập nhật", 280, 210);
            btnXoa = TaoNut("Xóa", 420, 210);
            Button btnLamMoi = TaoNut("Làm mới", 560, 210);

            btnTim.Click += (s, e) => TaiDuLieu();
            btnThem.Click += btnThem_Click;
            btnCapNhat.Click += btnCapNhat_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += (s, e) => LamMoi();

            dgvSach = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvSach.SelectionChanged += dgvSach_SelectionChanged;

            Button btnDong = new Button
            {
                Text = "Đóng",
                Dock = DockStyle.Bottom,
                Height = 42
            };
            btnDong.Click += (s, e) => Close();

            panel.Controls.AddRange(new Control[]
            {
                TaoLabel("Mã đầu sách:", 30, 28),
                txtMa,
                TaoLabel("Tên sách:", 440, 28),
                txtTen,

                TaoLabel("Năm xuất bản:", 30, 73),
                numNam,
                TaoLabel("Số lượng hiện có:", 400, 73),
                numSoLuong,

                TaoLabel("Thể loại:", 55, 118),
                cboTheLoai,
                TaoLabel("Nhà xuất bản:", 415, 118),
                cboNXB,

                TaoLabel("Tìm mã hoặc tên:", 25, 168),
                txtTim,
                btnTim,

                btnThem,
                btnCapNhat,
                btnXoa,
                btnLamMoi
            });

            Controls.Add(dgvSach);
            Controls.Add(panel);
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

        private TextBox TaoTextBox(int x, int y, int width)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 28)
            };
        }

        private Button TaoNut(string text, int x, int y)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(120, 35)
            };
        }

        private void FrmSach_Load(object sender, EventArgs e)
        {
            cboTheLoai.DataSource = danhMuc.LayTheLoai();
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";

            cboNXB.DataSource = danhMuc.LayNhaXuatBan();
            cboNXB.DisplayMember = "MaNhaXuatBan";
            cboNXB.ValueMember = "MaNhaXuatBan";

            TaiDuLieu();
            LamMoi();
        }

        private void TaiDuLieu()
        {
            dgvSach.DataSource = service.LayDanhSach(txtTim.Text.Trim());
        }

        private DauSach LayDuLieuForm()
        {
            return new DauSach
            {
                MaDauSach = txtMa.Text.Trim(),
                TenSach = txtTen.Text.Trim(),
                NamXuatBan = (int)numNam.Value,
                SoLuongHienCo = (int)numSoLuong.Value,
                MaTheLoai = cboTheLoai.SelectedValue == null
                    ? ""
                    : cboTheLoai.SelectedValue.ToString(),
                MaNhaXuatBan = cboNXB.SelectedValue == null
                    ? ""
                    : cboNXB.SelectedValue.ToString()
            };
        }

        private void HienKetQua(KetQuaXuLy ketQua)
        {
            MessageBox.Show(
                ketQua.ThongBao,
                ketQua.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK,
                ketQua.ThanhCong
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning);

            if (ketQua.ThanhCong)
            {
                TaiDuLieu();
                LamMoi();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HienKetQua(service.Luu(LayDuLieuForm(), false));
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            HienKetQua(service.Luu(LayDuLieuForm(), true));
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
                return;

            if (MessageBox.Show(
                "Xóa đầu sách đang chọn?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HienKetQua(service.Xoa(txtMa.Text.Trim()));
            }
        }

        private void LamMoi()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtTim.Clear();

            numNam.Value = DateTime.Today.Year;
            numSoLuong.Value = 0;

            txtMa.ReadOnly = false;
            txtMa.Focus();

            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void dgvSach_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = dgvSach.CurrentRow == null
                ? null
                : dgvSach.CurrentRow.DataBoundItem as DataRowView;

            if (r == null) return;

            txtMa.Text = Convert.ToString(r["MaDauSach"]);
            txtTen.Text = Convert.ToString(r["TenSach"]);
            numNam.Value = Convert.ToDecimal(r["NamXuatBan"]);
            numSoLuong.Value = Convert.ToDecimal(r["SoLuongHienCo"]);

            cboTheLoai.SelectedValue = Convert.ToString(r["MaTheLoai"]);
            cboNXB.SelectedValue = Convert.ToString(r["MaNhaXuatBan"]);

            txtMa.ReadOnly = true;
            btnThem.Enabled = false;
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}