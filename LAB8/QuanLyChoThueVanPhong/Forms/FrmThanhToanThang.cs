using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmThanhToanThang : Form
    {
        private readonly ThanhToanService _ttService = new ThanhToanService();
        private readonly HopDongService _hdService = new HopDongService();
        private readonly DanhMucService _dmService = new DanhMucService();
        private readonly List<ChiTietDichVuItem> _dsDichVuChon = new List<ChiTietDichVuItem>();

        public FrmThanhToanThang() : this(0)
        {
        }

        public FrmThanhToanThang(int initialTab)
        {
            InitializeComponent();
            if (initialTab >= 0 && initialTab < tabMain.TabPages.Count)
            {
                tabMain.SelectedIndex = initialTab;
            }
            Load += FrmThanhToanThang_Load;
        }

        private void FrmThanhToanThang_Load(object sender, EventArgs e)
        {
            NapCombobox();
            TaiDanhSachTienThue();
            TaiDanhSachHoaDonDichVu();
            cboThangDV.SelectedIndex = DateTime.Now.Month - 1;
            numNamDV.Value = DateTime.Now.Year;
            txtMaHDDV.Text = "DV" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
        }

        private void NapCombobox()
        {
            DataTable dtHD = _hdService.LayDanhSachHopDong();
            FormHelper.Nap(cboLocHDThue, dtHD, "MaHD", "MaHD");
            FormHelper.Nap(cboHDDV, dtHD, "MaHD", "MaHD");

            DataTable dtDV = _dmService.LayDanhSachDichVu();
            FormHelper.Nap(cboDichVu, dtDV, "TenDV", "MaDV");
        }

        #region Tab Tiền Thuê Tháng
        private void TaiDanhSachTienThue()
        {
            string maHD = chkLocTheoHD.Checked ? FormHelper.Gia(cboLocHDThue) : null;
            bool? daTT = null;
            if (cboTrangThaiThue.SelectedIndex == 1) daTT = false; // Chưa trả
            else if (cboTrangThaiThue.SelectedIndex == 2) daTT = true; // Đã trả

            dgvTienThue.DataSource = _ttService.LayDanhSachHoaDonTienThue(maHD, daTT);
        }

        private void btnLocTienThue_Click(object sender, EventArgs e)
        {
            TaiDanhSachTienThue();
        }

        private void btnThuTienThue_Click(object sender, EventArgs e)
        {
            string maHDTT = FormHelper.O(dgvTienThue, "MaHDTT");
            if (string.IsNullOrEmpty(maHDTT))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn tiền thuê trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string daTTStr = FormHelper.O(dgvTienThue, "DaThanhToan");
            if (daTTStr == "True" || daTTStr == "1")
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xác nhận thu tiền cho hóa đơn " + maHDTT + "?", "Xác nhận thu phí",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KetQuaXuLy kq = _ttService.ThanhToanTienThue(maHDTT);
                if (FormHelper.Bao(kq))
                {
                    TaiDanhSachTienThue();
                }
            }
        }
        #endregion

        #region Tab Dịch Vụ Cuối Tháng
        private void cboHDDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maHD = FormHelper.Gia(cboHDDV);
            if (!string.IsNullOrEmpty(maHD))
            {
                DataTable dtPhong = _hdService.LayChiTietPhongTheoHopDong(maHD);
                FormHelper.Nap(cboPhongDV, dtPhong, "TenPhong", "MaPhong");
            }
        }

        private void TaiDanhSachHoaDonDichVu()
        {
            dgvHoaDonDV.DataSource = _ttService.LayDanhSachHoaDonDichVu();
        }

        private void dgvHoaDonDV_SelectionChanged(object sender, EventArgs e)
        {
            string maHDDV = FormHelper.O(dgvHoaDonDV, "MaHDDV");
            if (!string.IsNullOrEmpty(maHDDV))
            {
                dgvChiTietDV.DataSource = _ttService.LayChiTietDichVu(maHDDV);
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            string maDV = FormHelper.Gia(cboDichVu);
            if (string.IsNullOrEmpty(maDV))
            {
                MessageBox.Show("Vui lòng chọn một dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dtDV = _dmService.LayDanhSachDichVu();
            DataRow[] rows = dtDV.Select("MaDV = '" + maDV + "'");
            if (rows.Length > 0)
            {
                DataRow r = rows[0];
                string tenDV = r["TenDV"].ToString();
                decimal donGia = Convert.ToDecimal(r["DonGia"]);

                decimal? dau = numChiSoDau.Value > 0 ? (decimal?)numChiSoDau.Value : null;
                decimal? cuoi = numChiSoCuoi.Value > 0 ? (decimal?)numChiSoCuoi.Value : null;
                decimal soLuong = numSoLuongDV.Value;

                if (cuoi.HasValue && dau.HasValue && cuoi.Value >= dau.Value)
                {
                    soLuong = cuoi.Value - dau.Value;
                }

                _dsDichVuChon.Add(new ChiTietDichVuItem
                {
                    MaDV = maDV,
                    TenDV = tenDV,
                    ChiSoDau = dau,
                    ChiSoCuoi = cuoi,
                    SoLuong = soLuong,
                    DonGia = donGia
                });

                CapNhatLuoiDichVuChon();
            }
        }

        private void btnXoaDichVuChon_Click(object sender, EventArgs e)
        {
            if (dgvDichVuChon.CurrentRow != null && dgvDichVuChon.CurrentRow.Index >= 0)
            {
                int idx = dgvDichVuChon.CurrentRow.Index;
                if (idx < _dsDichVuChon.Count)
                {
                    _dsDichVuChon.RemoveAt(idx);
                    CapNhatLuoiDichVuChon();
                }
            }
        }

        private void CapNhatLuoiDichVuChon()
        {
            dgvDichVuChon.DataSource = null;
            dgvDichVuChon.DataSource = new List<ChiTietDichVuItem>(_dsDichVuChon);

            decimal tong = 0;
            foreach (var item in _dsDichVuChon)
            {
                tong += item.ThanhTien;
            }
            lblTongTienDV.Text = string.Format("Tổng tiền DV: {0:N0} đ", tong);
        }

        private void btnLapHDDV_Click(object sender, EventArgs e)
        {
            string maHDDV = txtMaHDDV.Text.Trim();
            string maHD = FormHelper.Gia(cboHDDV);
            string maPhong = FormHelper.Gia(cboPhongDV);
            int thang = cboThangDV.SelectedIndex + 1;
            int nam = (int)numNamDV.Value;
            DateTime ngayCuoiThang = new DateTime(nam, thang, DateTime.DaysInMonth(nam, thang));

            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng chọn hợp đồng và phòng thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dsDichVuChon.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một dịch vụ vào hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy kq = _ttService.LapHoaDonDichVuCuoiThang(maHDDV, maHD, maPhong, thang, nam, _dsDichVuChon);
            if (FormHelper.Bao(kq))
            {
                _dsDichVuChon.Clear();
                CapNhatLuoiDichVuChon();
                TaiDanhSachHoaDonDichVu();
                txtMaHDDV.Text = "DV" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
            }
        }

        private void btnThuTienDV_Click(object sender, EventArgs e)
        {
            string maHDDV = FormHelper.O(dgvHoaDonDV, "MaHDDV");
            if (string.IsNullOrEmpty(maHDDV))
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string daTTStr = FormHelper.O(dgvHoaDonDV, "DaThanhToan");
            if (daTTStr == "True" || daTTStr == "1")
            {
                MessageBox.Show("Hóa đơn dịch vụ này đã thanh toán rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xác nhận thu tiền cho hóa đơn dịch vụ " + maHDDV + "?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KetQuaXuLy kq = _ttService.ThanhToanDichVu(maHDDV);
                if (FormHelper.Bao(kq))
                {
                    TaiDanhSachHoaDonDichVu();
                }
            }
        }
        #endregion
    }
}
