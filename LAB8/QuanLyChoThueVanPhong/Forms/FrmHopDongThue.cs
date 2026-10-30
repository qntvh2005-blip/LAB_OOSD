using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmHopDongThue : Form
    {
        private readonly HopDongService _hdService = new HopDongService();
        private readonly DanhMucService _dmService = new DanhMucService();
        private readonly List<PhongThueItem> _dsPhongChon = new List<PhongThueItem>();

        public FrmHopDongThue()
        {
            InitializeComponent();
            Load += FrmHopDongThue_Load;
        }

        private void FrmHopDongThue_Load(object sender, EventArgs e)
        {
            NapCombobox();
            TaiDanhSachHopDong();
            CapNhatLuoiPhongChon();
            txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
        }

        private void NapCombobox()
        {
            DataTable dtKH = _dmService.LayDanhSachKhachHang();
            FormHelper.Nap(cboKhachHang, dtKH, "TenCongTy", "MaKH");

            DataTable dtPhong = _dmService.LayDanhSachPhongTrong();
            FormHelper.Nap(cboPhongTrong, dtPhong, "TenPhong", "MaPhong");
        }

        private void TaiDanhSachHopDong()
        {
            dgvHopDong.DataSource = _hdService.LayDanhSachHopDong();
        }

        private void dgvHopDong_SelectionChanged(object sender, EventArgs e)
        {
            string maHD = FormHelper.O(dgvHopDong, "MaHD");
            if (string.IsNullOrEmpty(maHD)) return;

            dgvChiTietPhong.DataSource = _hdService.LayChiTietPhongTheoHopDong(maHD);
            dgvLichThanhToan.DataSource = _hdService.LayLichThanhToanTienThue(maHD);
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            string maPhong = FormHelper.Gia(cboPhongTrong);
            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng chọn một phòng trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dsPhongChon.Exists(p => p.MaPhong == maPhong))
            {
                MessageBox.Show("Phòng này đã được thêm vào danh sách thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dtPhong = _dmService.LayDanhSachPhong();
            DataRow[] rows = dtPhong.Select("MaPhong = '" + maPhong + "'");
            if (rows.Length > 0)
            {
                DataRow r = rows[0];
                decimal dienTich = Convert.ToDecimal(r["DienTich"]);
                decimal donGiaCoBan = Convert.ToDecimal(r["DonGiaCoBan"]);
                decimal heSo = Convert.ToDecimal(r["HeSoGia"]);
                decimal donGiaThucTe = donGiaCoBan * heSo;

                _dsPhongChon.Add(new PhongThueItem
                {
                    MaPhong = maPhong,
                    TenPhong = r["TenPhong"].ToString(),
                    DienTich = dienTich,
                    DonGia = donGiaThucTe
                });

                CapNhatLuoiPhongChon();
            }
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (dgvPhongChon.CurrentRow != null && dgvPhongChon.CurrentRow.Index >= 0)
            {
                int idx = dgvPhongChon.CurrentRow.Index;
                if (idx < _dsPhongChon.Count)
                {
                    _dsPhongChon.RemoveAt(idx);
                    CapNhatLuoiPhongChon();
                }
            }
        }

        private void CapNhatLuoiPhongChon()
        {
            dgvPhongChon.DataSource = null;
            dgvPhongChon.DataSource = new List<PhongThueItem>(_dsPhongChon);

            decimal tongThang = 0;
            decimal tongDienTich = 0;
            foreach (var p in _dsPhongChon)
            {
                tongDienTich += p.DienTich;
                tongThang += p.ThanhTienThang;
            }

            decimal traTruoc6Thang = tongThang * QuyDinhCaoOc.SoThangTraTruocBanDau;
            lblTongDienTich.Text = string.Format("Tổng DT: {0:N1} m²", tongDienTich);
            lblTongTienThang.Text = string.Format("Tiền/tháng: {0:N0} đ", tongThang);
            lblTraTruoc6Thang.Text = string.Format("Trả trước 6 tháng: {0:N0} đ", traTruoc6Thang);
        }

        private void btnLapHopDong_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim();
            string maKH = FormHelper.Gia(cboKhachHang);
            DateTime ngayKy = dtpNgayKy.Value.Date;
            DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
            int thoiHan = (int)numThoiHan.Value;
            decimal datCoc = numDatCoc.Value;

            if (_dsPhongChon.Count == 0)
            {
                MessageBox.Show("Phải chọn ít nhất 1 phòng để thuê.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy kq = _hdService.LapHopDong(maHD, maKH, ngayKy, ngayBatDau, thoiHan, datCoc, _dsPhongChon);
            if (FormHelper.Bao(kq))
            {
                _dsPhongChon.Clear();
                CapNhatLuoiPhongChon();
                NapCombobox();
                TaiDanhSachHopDong();
                txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            _dsPhongChon.Clear();
            CapNhatLuoiPhongChon();
            NapCombobox();
            TaiDanhSachHopDong();
            txtMaHD.Text = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
        }
    }
}
