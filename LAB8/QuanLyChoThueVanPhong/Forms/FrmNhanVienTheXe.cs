using System;
using System.Data;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmNhanVienTheXe : Form
    {
        private readonly NhanVienTheXeService _nvService = new NhanVienTheXeService();
        private readonly DanhMucService _dmService = new DanhMucService();

        public FrmNhanVienTheXe()
        {
            InitializeComponent();
            Load += FrmNhanVienTheXe_Load;
        }

        private void FrmNhanVienTheXe_Load(object sender, EventArgs e)
        {
            NapCombobox();
            TaiDanhSachNhanVien();
            TaiDanhSachTheXe();
            TaoMaMoi();
        }

        private void TaoMaMoi()
        {
            txtMaNV.Text = "NV" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
            txtMaThe.Text = "TX" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
        }

        private void NapCombobox()
        {
            DataTable dtKH = _dmService.LayDanhSachKhachHang();
            FormHelper.Nap(cboKhachHang, dtKH, "TenCongTy", "MaKH");

            DataTable dtPhong = _dmService.LayDanhSachPhong();
            FormHelper.Nap(cboPhong, dtPhong, "TenPhong", "MaPhong");

            DataTable dtNV = _nvService.LayDanhSachNhanVien();
            FormHelper.Nap(cboNhanVien, dtNV, "HoTen", "MaNVVP");

            if (cboLoaiXe.Items.Count > 0) cboLoaiXe.SelectedIndex = 0;
        }

        private void TaiDanhSachNhanVien()
        {
            DataTable dtNV = _nvService.LayDanhSachNhanVien();
            dgvNhanVien.DataSource = dtNV;
            FormHelper.Nap(cboNhanVien, dtNV, "HoTen", "MaNVVP");
        }

        private void TaiDanhSachTheXe()
        {
            dgvTheXe.DataSource = _nvService.LayDanhSachTheXe();
        }

        private void btnKhaiBaoNV_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string maKH = FormHelper.Gia(cboKhachHang);
            string maPhong = FormHelper.Gia(cboPhong);
            string hoTen = txtHoTen.Text.Trim();
            string cmnd = txtCMND.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string chucVu = txtChucVu.Text.Trim();

            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã nhân viên, họ tên, khách hàng và phòng làm việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy kq = _nvService.KhaiBaoNhanVien(maNV, maKH, maPhong, hoTen, DateTime.Now.AddYears(-25), "Nam", cmnd, sdt, chucVu, "");
            if (FormHelper.Bao(kq))
            {
                txtHoTen.Clear();
                txtCMND.Clear();
                txtSDT.Clear();
                txtEmail.Clear();
                txtChucVu.Clear();
                TaoMaMoi();
                TaiDanhSachNhanVien();
            }
        }

        private void btnCapTheXe_Click(object sender, EventArgs e)
        {
            string maThe = txtMaThe.Text.Trim();
            string maNV = FormHelper.Gia(cboNhanVien);
            string bienSo = txtBienSo.Text.Trim();
            string loaiXe = cboLoaiXe.SelectedItem != null ? cboLoaiXe.SelectedItem.ToString() : "Xe máy";
            string nhanHieu = txtNhanHieu.Text.Trim();
            string mauXe = txtMauXe.Text.Trim();

            if (string.IsNullOrEmpty(maThe) || string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(bienSo))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã thẻ, nhân viên và biển số xe.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy kq = _nvService.CapTheGiuXe(maThe, maNV, bienSo, loaiXe, nhanHieu, mauXe);
            if (FormHelper.Bao(kq))
            {
                txtBienSo.Clear();
                txtNhanHieu.Clear();
                txtMauXe.Clear();
                TaoMaMoi();
                TaiDanhSachTheXe();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaoMaMoi();
            NapCombobox();
            TaiDanhSachNhanVien();
            TaiDanhSachTheXe();
        }
    }
}
