using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService service = new DanhMucService();

        // Nhân viên
        private TextBox txtNVMa;
        private TextBox txtNVHo;
        private TextBox txtNVTen;
        private ComboBox cboNVPhai;
        private DateTimePicker dtNVNgaySinh;
        private TextBox txtNVChucVu;
        private TextBox txtNVSDT;
        private DataGridView dgvNV;
        private Button btnNVThem;
        private Button btnNVCapNhat;
        private Button btnNVXoa;

        // Thể loại
        private TextBox txtTLMa;
        private TextBox txtTLTen;
        private DataGridView dgvTL;
        private Button btnTLThem;
        private Button btnTLCapNhat;
        private Button btnTLXoa;

        // Nhà xuất bản
        private TextBox txtNXBMa;
        private TextBox txtNXBDiaChi;
        private TextBox txtNXBSDT;
        private DataGridView dgvNXB;
        private Button btnNXBThem;
        private Button btnNXBCapNhat;
        private Button btnNXBXoa;

        public FrmDanhMuc()
        {
            InitializeComponent();
            TaoGiaoDien();
            Load += FrmDanhMuc_Load;
        }

        private void TaoGiaoDien()
        {
            Text = "Danh mục và nhân viên";
            ClientSize = new Size(1060, 720);
            StartPosition = FormStartPosition.CenterParent;

            TabControl tabs = new TabControl
            {
                Dock = DockStyle.Fill
            };

            TabPage tabNV = new TabPage("Nhân viên");
            TabPage tabTL = new TabPage("Thể loại");
            TabPage tabNXB = new TabPage("Nhà xuất bản");

            TaoTabNhanVien(tabNV);
            TaoTabTheLoai(tabTL);
            TaoTabNhaXuatBan(tabNXB);

            tabs.TabPages.Add(tabNV);
            tabs.TabPages.Add(tabTL);
            tabs.TabPages.Add(tabNXB);

            Button btnDong = new Button
            {
                Text = "Đóng",
                Dock = DockStyle.Bottom,
                Height = 42
            };
            btnDong.Click += (s, e) => Close();

            Controls.Add(tabs);
            Controls.Add(btnDong);
        }

        private void TaoTabNhanVien(TabPage tab)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 220
            };

            txtNVMa = TaoTextBox(130, 20, 180);
            txtNVHo = TaoTextBox(470, 20, 180);
            txtNVTen = TaoTextBox(790, 20, 180);

            cboNVPhai = new ComboBox
            {
                Location = new Point(130, 65),
                Size = new Size(180, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboNVPhai.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            dtNVNgaySinh = new DateTimePicker
            {
                Location = new Point(470, 65),
                Size = new Size(180, 28),
                Format = DateTimePickerFormat.Short
            };

            txtNVChucVu = TaoTextBox(790, 65, 180);
            txtNVSDT = TaoTextBox(130, 110, 180);

            btnNVThem = TaoNut("Thêm", 370, 145);
            btnNVCapNhat = TaoNut("Cập nhật", 510, 145);
            btnNVXoa = TaoNut("Xóa", 650, 145);
            Button btnNVMoi = TaoNut("Làm mới", 790, 145);

            btnNVThem.Click += btnNVThem_Click;
            btnNVCapNhat.Click += btnNVCapNhat_Click;
            btnNVXoa.Click += btnNVXoa_Click;
            btnNVMoi.Click += (s, e) => LamMoiNV();

            dgvNV = TaoDataGridView();
            dgvNV.Dock = DockStyle.Fill;
            dgvNV.SelectionChanged += dgvNV_SelectionChanged;

            panel.Controls.AddRange(new Control[]
            {
                TaoLabel("Mã nhân viên:", 20, 22),
                txtNVMa,
                TaoLabel("Họ:", 400, 22),
                txtNVHo,
                TaoLabel("Tên:", 720, 22),
                txtNVTen,

                TaoLabel("Phái:", 20, 67),
                cboNVPhai,
                TaoLabel("Ngày sinh:", 370, 67),
                dtNVNgaySinh,
                TaoLabel("Chức vụ:", 700, 67),
                txtNVChucVu,

                TaoLabel("Điện thoại:", 20, 112),
                txtNVSDT,

                btnNVThem,
                btnNVCapNhat,
                btnNVXoa,
                btnNVMoi
            });

            tab.Controls.Add(dgvNV);
            tab.Controls.Add(panel);
        }

        private void TaoTabTheLoai(TabPage tab)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 150
            };

            txtTLMa = TaoTextBox(140, 25, 200);
            txtTLTen = TaoTextBox(530, 25, 260);

            btnTLThem = TaoNut("Thêm", 230, 80);
            btnTLCapNhat = TaoNut("Cập nhật", 370, 80);
            btnTLXoa = TaoNut("Xóa", 510, 80);
            Button btnTLMoi = TaoNut("Làm mới", 650, 80);

            btnTLThem.Click += btnTLThem_Click;
            btnTLCapNhat.Click += btnTLCapNhat_Click;
            btnTLXoa.Click += btnTLXoa_Click;
            btnTLMoi.Click += (s, e) => LamMoiTL();

            dgvTL = TaoDataGridView();
            dgvTL.Dock = DockStyle.Fill;
            dgvTL.SelectionChanged += dgvTL_SelectionChanged;

            panel.Controls.AddRange(new Control[]
            {
                TaoLabel("Mã thể loại:", 30, 28),
                txtTLMa,
                TaoLabel("Tên thể loại:", 410, 28),
                txtTLTen,
                btnTLThem,
                btnTLCapNhat,
                btnTLXoa,
                btnTLMoi
            });

            tab.Controls.Add(dgvTL);
            tab.Controls.Add(panel);
        }

        private void TaoTabNhaXuatBan(TabPage tab)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 180
            };

            txtNXBMa = TaoTextBox(160, 25, 200);
            txtNXBDiaChi = TaoTextBox(540, 25, 320);
            txtNXBSDT = TaoTextBox(160, 70, 200);

            btnNXBThem = TaoNut("Thêm", 250, 120);
            btnNXBCapNhat = TaoNut("Cập nhật", 390, 120);
            btnNXBXoa = TaoNut("Xóa", 530, 120);
            Button btnNXBMoi = TaoNut("Làm mới", 670, 120);

            btnNXBThem.Click += btnNXBThem_Click;
            btnNXBCapNhat.Click += btnNXBCapNhat_Click;
            btnNXBXoa.Click += btnNXBXoa_Click;
            btnNXBMoi.Click += (s, e) => LamMoiNXB();

            dgvNXB = TaoDataGridView();
            dgvNXB.Dock = DockStyle.Fill;
            dgvNXB.SelectionChanged += dgvNXB_SelectionChanged;

            panel.Controls.AddRange(new Control[]
            {
                TaoLabel("Mã nhà xuất bản:", 25, 28),
                txtNXBMa,
                TaoLabel("Địa chỉ:", 450, 28),
                txtNXBDiaChi,
                TaoLabel("Điện thoại:", 55, 73),
                txtNXBSDT,
                btnNXBThem,
                btnNXBCapNhat,
                btnNXBXoa,
                btnNXBMoi
            });

            tab.Controls.Add(dgvNXB);
            tab.Controls.Add(panel);
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

        private DataGridView TaoDataGridView()
        {
            return new DataGridView
            {
                ReadOnly = true,
                MultiSelect = false,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
        }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            TaiDuLieu();
            LamMoiNV();
            LamMoiTL();
            LamMoiNXB();
        }

        private void TaiDuLieu()
        {
            dgvNV.DataSource = service.LayNhanVien();
            dgvTL.DataSource = service.LayTheLoai();
            dgvNXB.DataSource = service.LayNhaXuatBan();
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
                LamMoiNV();
                LamMoiTL();
                LamMoiNXB();
            }
        }

        // ===== NHAN VIEN =====

        private void btnNVThem_Click(object sender, EventArgs e)
        {
            HienKetQua(service.LuuNhanVien(LayNhanVienTuForm(), false));
        }

        private void btnNVCapNhat_Click(object sender, EventArgs e)
        {
            HienKetQua(service.LuuNhanVien(LayNhanVienTuForm(), true));
        }

        private void btnNVXoa_Click(object sender, EventArgs e)
        {
            if (XacNhanXoa())
            {
                HienKetQua(service.Xoa(
                    "NhanVien",
                    "MaNhanVien",
                    txtNVMa.Text.Trim()));
            }
        }

        private NhanVien LayNhanVienTuForm()
        {
            return new NhanVien
            {
                MaNhanVien = txtNVMa.Text.Trim(),
                Ho = txtNVHo.Text.Trim(),
                Ten = txtNVTen.Text.Trim(),
                Phai = Convert.ToString(cboNVPhai.SelectedItem),
                NgaySinh = dtNVNgaySinh.Value,
                ChucVu = txtNVChucVu.Text.Trim(),
                SoDienThoai = txtNVSDT.Text.Trim()
            };
        }

        private void dgvNV_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = dgvNV.CurrentRow == null
                ? null
                : dgvNV.CurrentRow.DataBoundItem as DataRowView;

            if (r == null) return;

            txtNVMa.Text = Convert.ToString(r["MaNhanVien"]);
            txtNVHo.Text = Convert.ToString(r["Ho"]);
            txtNVTen.Text = Convert.ToString(r["Ten"]);
            cboNVPhai.SelectedItem = Convert.ToString(r["Phai"]);
            dtNVNgaySinh.Value = Convert.ToDateTime(r["NgaySinh"]);
            txtNVChucVu.Text = Convert.ToString(r["ChucVu"]);
            txtNVSDT.Text = Convert.ToString(r["SoDienThoai"]);

            txtNVMa.ReadOnly = true;
            btnNVThem.Enabled = false;
            btnNVCapNhat.Enabled = true;
            btnNVXoa.Enabled = true;
        }

        private void LamMoiNV()
        {
            txtNVMa.Clear();
            txtNVHo.Clear();
            txtNVTen.Clear();
            txtNVChucVu.Clear();
            txtNVSDT.Clear();

            cboNVPhai.SelectedIndex = 0;
            dtNVNgaySinh.Value = DateTime.Today.AddYears(-25);

            txtNVMa.ReadOnly = false;
            btnNVThem.Enabled = true;
            btnNVCapNhat.Enabled = false;
            btnNVXoa.Enabled = false;
        }

        // ===== THE LOAI =====

        private void btnTLThem_Click(object sender, EventArgs e)
        {
            HienKetQua(service.LuuTheLoai(
                txtTLMa.Text,
                txtTLTen.Text,
                false));
        }

        private void btnTLCapNhat_Click(object sender, EventArgs e)
        {
            HienKetQua(service.LuuTheLoai(
                txtTLMa.Text,
                txtTLTen.Text,
                true));
        }

        private void btnTLXoa_Click(object sender, EventArgs e)
        {
            if (XacNhanXoa())
            {
                HienKetQua(service.Xoa(
                    "TheLoai",
                    "MaTheLoai",
                    txtTLMa.Text.Trim()));
            }
        }

        private void dgvTL_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = dgvTL.CurrentRow == null
                ? null
                : dgvTL.CurrentRow.DataBoundItem as DataRowView;

            if (r == null) return;

            txtTLMa.Text = Convert.ToString(r["MaTheLoai"]);
            txtTLTen.Text = Convert.ToString(r["TenTheLoai"]);

            txtTLMa.ReadOnly = true;
            btnTLThem.Enabled = false;
            btnTLCapNhat.Enabled = true;
            btnTLXoa.Enabled = true;
        }

        private void LamMoiTL()
        {
            txtTLMa.Clear();
            txtTLTen.Clear();

            txtTLMa.ReadOnly = false;
            btnTLThem.Enabled = true;
            btnTLCapNhat.Enabled = false;
            btnTLXoa.Enabled = false;
        }

        // ===== NHA XUAT BAN =====

        private void btnNXBThem_Click(object sender, EventArgs e)
        {
            HienKetQua(service.LuuNhaXuatBan(
                txtNXBMa.Text,
                txtNXBDiaChi.Text,
                txtNXBSDT.Text,
                false));
        }

        private void btnNXBCapNhat_Click(object sender, EventArgs e)
        {
            HienKetQua(service.LuuNhaXuatBan(
                txtNXBMa.Text,
                txtNXBDiaChi.Text,
                txtNXBSDT.Text,
                true));
        }

        private void btnNXBXoa_Click(object sender, EventArgs e)
        {
            if (XacNhanXoa())
            {
                HienKetQua(service.Xoa(
                    "NhaXuatBan",
                    "MaNhaXuatBan",
                    txtNXBMa.Text.Trim()));
            }
        }

        private void dgvNXB_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = dgvNXB.CurrentRow == null
                ? null
                : dgvNXB.CurrentRow.DataBoundItem as DataRowView;

            if (r == null) return;

            txtNXBMa.Text = Convert.ToString(r["MaNhaXuatBan"]);
            txtNXBDiaChi.Text = Convert.ToString(r["DiaChi"]);
            txtNXBSDT.Text = Convert.ToString(r["SoDienThoai"]);

            txtNXBMa.ReadOnly = true;
            btnNXBThem.Enabled = false;
            btnNXBCapNhat.Enabled = true;
            btnNXBXoa.Enabled = true;
        }

        private void LamMoiNXB()
        {
            txtNXBMa.Clear();
            txtNXBDiaChi.Clear();
            txtNXBSDT.Clear();

            txtNXBMa.ReadOnly = false;
            btnNXBThem.Enabled = true;
            btnNXBCapNhat.Enabled = false;
            btnNXBXoa.Enabled = false;
        }

        private bool XacNhanXoa()
        {
            return MessageBox.Show(
                "Bạn có chắc muốn xóa dữ liệu đang chọn?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}