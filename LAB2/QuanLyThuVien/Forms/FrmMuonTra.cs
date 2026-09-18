using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;

namespace QuanLyThuVien.Forms
{
    public partial class FrmMuonTra : Form
    {
        private readonly MuonTraService service = new MuonTraService();
        private readonly SachService sachService = new SachService();
        private readonly DocGiaService docGiaService = new DocGiaService();
        private readonly DanhMucService danhMucService = new DanhMucService();

        private readonly DataTable selectedBooks = new DataTable();

        // Tab Mượn
        private ComboBox cboDocGia;
        private ComboBox cboNhanVienMuon;
        private DateTimePicker dtNgayMuon;
        private DateTimePicker dtHenTra;
        private Label lblTrangThai;
        private DataGridView dgvSachCon;
        private DataGridView dgvSachChon;

        // Tab Trả
        private ComboBox cboDocGiaTra;
        private ComboBox cboNhanVienTra;
        private DataGridView dgvDangMuon;
        private DateTimePicker dtNgayTra;
        private ComboBox cboTinhTrang;
        private NumericUpDown numPhiPhat;

        public FrmMuonTra()
        {
            InitializeComponent();

            selectedBooks.Columns.Add("MaDauSach", typeof(string));
            selectedBooks.Columns.Add("TenSach", typeof(string));
            selectedBooks.Columns.Add("NamXuatBan", typeof(int));
            selectedBooks.Columns.Add("SoLuongHienCo", typeof(int));

            TaoGiaoDien();
            Load += FrmMuonTra_Load;
        }

        private void TaoGiaoDien()
        {
            Text = "Mượn - Trả sách";
            ClientSize = new Size(1150, 760);
            StartPosition = FormStartPosition.CenterParent;

            TabControl tabs = new TabControl
            {
                Dock = DockStyle.Fill
            };

            TabPage tabMuon = new TabPage("Mượn sách");
            TabPage tabTra = new TabPage("Trả sách");

            TaoTabMuon(tabMuon);
            TaoTabTra(tabTra);

            tabs.TabPages.Add(tabMuon);
            tabs.TabPages.Add(tabTra);

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

        private void TaoTabMuon(TabPage tab)
        {
            Panel top = new Panel
            {
                Dock = DockStyle.Top,
                Height = 150
            };

            cboDocGia = TaoComboBox(125, 20, 230);
            cboNhanVienMuon = TaoComboBox(625, 20, 230);

            dtNgayMuon = TaoDatePicker(125, 65);
            dtHenTra = TaoDatePicker(625, 65);
            dtHenTra.Value = DateTime.Today.AddDays(7);

            Button btnKiemTra = TaoNut("Kiểm tra", 900, 18);
            Button btnLapPhieu = TaoNut("Lập phiếu mượn", 900, 65);

            lblTrangThai = new Label
            {
                Text = "",
                Location = new Point(125, 110),
                Size = new Size(800, 25),
                ForeColor = Color.DarkBlue
            };

            btnKiemTra.Click += btnKiemTra_Click;
            btnLapPhieu.Click += btnLapPhieu_Click;

            top.Controls.AddRange(new Control[]
            {
                TaoLabel("Độc giả:", 45, 23),
                cboDocGia,
                TaoLabel("Nhân viên:", 530, 23),
                cboNhanVienMuon,

                TaoLabel("Ngày mượn:", 35, 68),
                dtNgayMuon,
                TaoLabel("Ngày hẹn trả:", 515, 68),
                dtHenTra,

                btnKiemTra,
                btnLapPhieu,
                lblTrangThai
            });

            Panel body = new Panel
            {
                Dock = DockStyle.Fill
            };

            Label lblSachCon = new Label
            {
                Text = "Sách còn trong kho",
                Location = new Point(20, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Label lblSachChon = new Label
            {
                Text = "Sách đã chọn (tối đa 3)",
                Location = new Point(655, 15),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            dgvSachCon = TaoDataGridView();
            dgvSachCon.Location = new Point(20, 45);
            dgvSachCon.Size = new Size(480, 450);

            dgvSachChon = TaoDataGridView();
            dgvSachChon.Location = new Point(650, 45);
            dgvSachChon.Size = new Size(480, 450);
            dgvSachChon.DataSource = selectedBooks;

            Button btnThemSach = TaoNut("Thêm >>", 520, 180);
            Button btnBoSach = TaoNut("<< Bỏ", 520, 240);

            btnThemSach.Click += btnThemSach_Click;
            btnBoSach.Click += btnBoSach_Click;

            body.Controls.AddRange(new Control[]
            {
                lblSachCon,
                lblSachChon,
                dgvSachCon,
                dgvSachChon,
                btnThemSach,
                btnBoSach
            });

            tab.Controls.Add(body);
            tab.Controls.Add(top);
        }

        private void TaoTabTra(TabPage tab)
        {
            Panel top = new Panel
            {
                Dock = DockStyle.Top,
                Height = 190
            };

            cboDocGiaTra = TaoComboBox(145, 20, 230);
            cboNhanVienTra = TaoComboBox(650, 20, 230);

            Button btnTaiSachMuon = TaoNut("Tải sách đang mượn", 400, 18);

            dtNgayTra = TaoDatePicker(145, 65);

            cboTinhTrang = TaoComboBox(650, 65, 230);
            cboTinhTrang.Items.AddRange(new object[]
            {
                "Bình thường",
                "Rách/Hư hỏng",
                "Mất"
            });

            numPhiPhat = new NumericUpDown
            {
                Location = new Point(145, 110),
                Size = new Size(230, 28),
                Minimum = 0,
                Maximum = 1000000000,
                ThousandsSeparator = true
            };

            Button btnTraSach = TaoNut("Xác nhận trả sách", 650, 110);

            btnTaiSachMuon.Click += (s, e) => TaiSachDangMuon();
            btnTraSach.Click += btnTraSach_Click;

            top.Controls.AddRange(new Control[]
            {
                TaoLabel("Độc giả trả:", 50, 23),
                cboDocGiaTra,
                btnTaiSachMuon,
                TaoLabel("Nhân viên nhận trả:", 500, 23),
                cboNhanVienTra,

                TaoLabel("Ngày trả:", 70, 68),
                dtNgayTra,
                TaoLabel("Tình trạng:", 570, 68),
                cboTinhTrang,

                TaoLabel("Phí phạt:", 75, 113),
                numPhiPhat,
                btnTraSach
            });

            dgvDangMuon = TaoDataGridView();
            dgvDangMuon.Dock = DockStyle.Fill;

            tab.Controls.Add(dgvDangMuon);
            tab.Controls.Add(top);
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

        private ComboBox TaoComboBox(int x, int y, int width)
        {
            return new ComboBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
        }

        private DateTimePicker TaoDatePicker(int x, int y)
        {
            return new DateTimePicker
            {
                Location = new Point(x, y),
                Size = new Size(230, 28),
                Format = DateTimePickerFormat.Short
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

        private void FrmMuonTra_Load(object sender, EventArgs e)
        {
            TaiComboBox();
            TaiSachCon();
            LamMoiTra();
        }

        private void TaiComboBox()
        {
            cboDocGia.DataSource = docGiaService.LayComboDocGia();
            cboDocGia.DisplayMember = "HoTen";
            cboDocGia.ValueMember = "MaDocGia";

            cboDocGiaTra.DataSource = docGiaService.LayComboDocGia();
            cboDocGiaTra.DisplayMember = "HoTen";
            cboDocGiaTra.ValueMember = "MaDocGia";

            cboNhanVienMuon.DataSource = danhMucService.LayNhanVien();
            cboNhanVienMuon.DisplayMember = "MaNhanVien";
            cboNhanVienMuon.ValueMember = "MaNhanVien";

            cboNhanVienTra.DataSource = danhMucService.LayNhanVien();
            cboNhanVienTra.DisplayMember = "MaNhanVien";
            cboNhanVienTra.ValueMember = "MaNhanVien";
        }

        private string LayMaCombo(ComboBox combo)
        {
            if (combo.SelectedValue == null)
                return "";

            if (combo.SelectedValue is DataRowView)
                return "";

            return Convert.ToString(combo.SelectedValue);
        }

        private void TaiSachCon()
        {
            dgvSachCon.DataSource = sachService.LaySachConTrongKho();
        }

        private void TaiSachDangMuon()
        {
            string maDocGia = LayMaCombo(cboDocGiaTra);

            if (string.IsNullOrWhiteSpace(maDocGia))
            {
                dgvDangMuon.DataSource = null;
                return;
            }

            dgvDangMuon.DataSource = service.LaySachDangMuon(maDocGia);
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            KetQuaXuLy ketQua = service.KiemTraDieuKienMuon(
                LayMaCombo(cboDocGia),
                selectedBooks.Rows.Count);

            lblTrangThai.Text = ketQua.ThongBao;
            lblTrangThai.ForeColor = ketQua.ThanhCong
                ? Color.DarkGreen
                : Color.DarkRed;
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            DataRowView r = dgvSachCon.CurrentRow == null
                ? null
                : dgvSachCon.CurrentRow.DataBoundItem as DataRowView;

            if (r == null) return;

            if (selectedBooks.Rows.Count >= 3)
            {
                MessageBox.Show(
                    "Chỉ được chọn tối đa 3 đầu sách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string maSach = Convert.ToString(r["MaDauSach"]);

            foreach (DataRow row in selectedBooks.Rows)
            {
                if (Convert.ToString(row["MaDauSach"]) == maSach)
                {
                    MessageBox.Show(
                        "Đầu sách này đã có trong danh sách chọn.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            selectedBooks.Rows.Add(
                maSach,
                Convert.ToString(r["TenSach"]),
                Convert.ToInt32(r["NamXuatBan"]),
                Convert.ToInt32(r["SoLuongHienCo"]));
        }

        private void btnBoSach_Click(object sender, EventArgs e)
        {
            DataRowView r = dgvSachChon.CurrentRow == null
                ? null
                : dgvSachChon.CurrentRow.DataBoundItem as DataRowView;

            if (r == null) return;

            selectedBooks.Rows.Remove(r.Row);
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            List<string> danhSachMaSach = new List<string>();

            foreach (DataRow r in selectedBooks.Rows)
            {
                danhSachMaSach.Add(
                    Convert.ToString(r["MaDauSach"]));
            }

            KetQuaXuLy ketQua = service.LapPhieuMuon(
                LayMaCombo(cboDocGia),
                LayMaCombo(cboNhanVienMuon),
                danhSachMaSach,
                dtNgayMuon.Value,
                dtHenTra.Value);

            MessageBox.Show(
                ketQua.ThongBao,
                ketQua.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK,
                ketQua.ThanhCong
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning);

            if (ketQua.ThanhCong)
            {
                selectedBooks.Rows.Clear();
                lblTrangThai.Text = "";
                TaiSachCon();
                TaiSachDangMuon();
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            DataRowView r = dgvDangMuon.CurrentRow == null
                ? null
                : dgvDangMuon.CurrentRow.DataBoundItem as DataRowView;

            if (r == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sách cần trả.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy ketQua = service.TraSach(
                Convert.ToString(r["MaChiTiet"]),
                LayMaCombo(cboNhanVienTra),
                dtNgayTra.Value,
                Convert.ToString(cboTinhTrang.SelectedItem),
                numPhiPhat.Value);

            MessageBox.Show(
                ketQua.ThongBao,
                ketQua.ThanhCong ? "Thông báo" : "Lỗi",
                MessageBoxButtons.OK,
                ketQua.ThanhCong
                    ? MessageBoxIcon.Information
                    : MessageBoxIcon.Warning);

            if (ketQua.ThanhCong)
            {
                TaiSachDangMuon();
                TaiSachCon();
                LamMoiTra();
            }
        }

        private void LamMoiTra()
        {
            dtNgayTra.Value = DateTime.Today;
            numPhiPhat.Value = 0;

            if (cboTinhTrang.Items.Count > 0)
                cboTinhTrang.SelectedIndex = 0;
        }
    }
}