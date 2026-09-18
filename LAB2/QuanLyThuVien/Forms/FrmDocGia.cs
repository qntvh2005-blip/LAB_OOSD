using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public partial class FrmDocGia : Form
    {
        private readonly DocGiaService service = new DocGiaService();

        private TextBox txtMa;
        private TextBox txtHo;
        private TextBox txtTen;
        private DateTimePicker dtNgaySinh;
        private ComboBox cboPhai;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private TextBox txtEmail;
        private TextBox txtAnh;

        private DateTimePicker dtNgayCap;
        private DateTimePicker dtHan;
        private CheckBox chkLePhi;

        private DataGridView dgvDocGia;
        private Button btnThem;
        private Button btnCapNhat;

        public FrmDocGia()
        {
            InitializeComponent();
            TaoGiaoDien();
            Load += FrmDocGia_Load;
        }

        private void TaoGiaoDien()
        {
            Text = "Độc giả và thẻ thư viện";
            ClientSize = new Size(1190, 790);
            StartPosition = FormStartPosition.CenterParent;

            Panel panel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 330
            };

            txtMa = TaoTextBox(130, 20, 180);
            txtHo = TaoTextBox(475, 20, 180);
            txtTen = TaoTextBox(865, 20, 180);

            dtNgaySinh = new DateTimePicker
            {
                Location = new Point(130, 65),
                Size = new Size(180, 28),
                Format = DateTimePickerFormat.Short
            };

            cboPhai = new ComboBox
            {
                Location = new Point(475, 65),
                Size = new Size(180, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboPhai.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            txtSDT = TaoTextBox(865, 65, 180);
            txtDiaChi = TaoTextBox(130, 110, 350);
            txtEmail = TaoTextBox(650, 110, 395);
            txtAnh = TaoTextBox(130, 155, 915);

            dtNgayCap = new DateTimePicker
            {
                Location = new Point(130, 200),
                Size = new Size(180, 28),
                Format = DateTimePickerFormat.Short
            };

            dtHan = new DateTimePicker
            {
                Location = new Point(475, 200),
                Size = new Size(180, 28),
                Format = DateTimePickerFormat.Short
            };

            chkLePhi = new CheckBox
            {
                Text = "Đã đóng lệ phí năm",
                Location = new Point(865, 203),
                AutoSize = true
            };

            btnThem = TaoNut("Thêm độc giả", 150, 260);
            btnCapNhat = TaoNut("Cập nhật", 290, 260);
            Button btnCapThe = TaoNut("Cấp thẻ", 430, 260);
            Button btnGiaHan = TaoNut("Gia hạn thẻ", 570, 260);
            Button btnLamMoi = TaoNut("Làm mới", 710, 260);

            btnThem.Click += btnThem_Click;
            btnCapNhat.Click += btnCapNhat_Click;
            btnCapThe.Click += btnCapThe_Click;
            btnGiaHan.Click += btnGiaHan_Click;
            btnLamMoi.Click += (s, e) => LamMoi();

            dgvDocGia = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvDocGia.SelectionChanged += dgvDocGia_SelectionChanged;

            Button btnDong = new Button
            {
                Text = "Đóng",
                Dock = DockStyle.Bottom,
                Height = 42
            };
            btnDong.Click += (s, e) => Close();

            panel.Controls.AddRange(new Control[]
            {
                TaoLabel("Mã độc giả:", 35, 23),
                txtMa,
                TaoLabel("Họ:", 415, 23),
                txtHo,
                TaoLabel("Tên:", 805, 23),
                txtTen,

                TaoLabel("Ngày sinh:", 35, 68),
                dtNgaySinh,
                TaoLabel("Phái:", 430, 68),
                cboPhai,
                TaoLabel("Điện thoại:", 775, 68),
                txtSDT,

                TaoLabel("Địa chỉ:", 55, 113),
                txtDiaChi,
                TaoLabel("Email:", 590, 113),
                txtEmail,

                TaoLabel("Ảnh 3x4:", 55, 158),
                txtAnh,

                TaoLabel("Ngày cấp thẻ:", 25, 203),
                dtNgayCap,
                TaoLabel("Hạn sử dụng:", 370, 203),
                dtHan,
                chkLePhi,

                btnThem,
                btnCapNhat,
                btnCapThe,
                btnGiaHan,
                btnLamMoi
            });

            Controls.Add(dgvDocGia);
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
                Size = new Size(125, 35)
            };
        }

        private void FrmDocGia_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
            LamMoi();
        }

        private void TaiDuLieu()
        {
            dgvDocGia.DataSource = service.LayDanhSach();
        }

        private DocGia LayDuLieuForm()
        {
            return new DocGia
            {
                MaDocGia = txtMa.Text.Trim(),
                Ho = txtHo.Text.Trim(),
                Ten = txtTen.Text.Trim(),
                NgaySinh = dtNgaySinh.Value,
                Phai = Convert.ToString(cboPhai.SelectedItem),
                SoDienThoai = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Anh3x4 = txtAnh.Text.Trim()
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

        private void btnCapThe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn độc giả cần cấp thẻ.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            HienKetQua(service.CapThe(
                txtMa.Text.Trim(),
                dtNgayCap.Value,
                dtHan.Value,
                chkLePhi.Checked));
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMa.Text))
            {
                MessageBox.Show(
                    "Vui lòng chọn độc giả cần gia hạn thẻ.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            HienKetQua(service.GiaHanThe(
                txtMa.Text.Trim(),
                dtHan.Value,
                chkLePhi.Checked));
        }

        private void LamMoi()
        {
            txtMa.Clear();
            txtHo.Clear();
            txtTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();
            txtAnh.Clear();

            cboPhai.SelectedIndex = 0;
            dtNgaySinh.Value = DateTime.Today.AddYears(-20);
            dtNgayCap.Value = DateTime.Today;
            dtHan.Value = DateTime.Today.AddYears(1);
            chkLePhi.Checked = false;

            txtMa.ReadOnly = false;
            txtMa.Focus();

            btnThem.Enabled = true;
            btnCapNhat.Enabled = false;
        }

        private void dgvDocGia_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = dgvDocGia.CurrentRow == null
                ? null
                : dgvDocGia.CurrentRow.DataBoundItem as DataRowView;

            if (r == null) return;

            txtMa.Text = Convert.ToString(r["MaDocGia"]);
            txtHo.Text = Convert.ToString(r["Ho"]);
            txtTen.Text = Convert.ToString(r["Ten"]);
            dtNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
            cboPhai.SelectedItem = Convert.ToString(r["Phai"]);
            txtSDT.Text = Convert.ToString(r["SoDienThoai"]);
            txtDiaChi.Text = Convert.ToString(r["DiaChi"]);
            txtEmail.Text = Convert.ToString(r["Email"]);
            txtAnh.Text = Convert.ToString(r["Anh3x4"]);

            if (r["NgayCap"] != DBNull.Value)
                dtNgayCap.Value = Convert.ToDateTime(r["NgayCap"]);

            if (r["HanSuDung"] != DBNull.Value)
                dtHan.Value = Convert.ToDateTime(r["HanSuDung"]);

            if (r["DaDongLePhi"] != DBNull.Value)
                chkLePhi.Checked = Convert.ToBoolean(r["DaDongLePhi"]);

            txtMa.ReadOnly = true;
            btnThem.Enabled = false;
            btnCapNhat.Enabled = true;
        }
    }
}