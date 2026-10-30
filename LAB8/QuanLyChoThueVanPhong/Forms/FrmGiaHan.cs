using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmGiaHan : Form
    {
        private readonly GiaHanService _ghService = new GiaHanService();
        private readonly HopDongService _hdService = new HopDongService();
        private int _thoiHanGoc = 0;
        private int _maxGiaHan = 0;

        public FrmGiaHan()
        {
            InitializeComponent();
            Load += FrmGiaHan_Load;
        }

        private void FrmGiaHan_Load(object sender, EventArgs e)
        {
            txtMaPGH.Text = "GH" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
            NapDanhSachHopDong();
            TaiDanhSachPhieuGiaHan();
        }

        private void NapDanhSachHopDong()
        {
            DataTable dtHD = _hdService.LayDanhSachHopDong();
            FormHelper.Nap(cboHopDong, dtHD, "MaHD", "MaHD");
            if (cboHopDong.Items.Count > 0)
            {
                cboHopDong.SelectedIndex = 0;
                KiemTraHopDong();
            }
        }

        private void cboHopDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            KiemTraHopDong();
        }

        private void KiemTraHopDong()
        {
            string maHD = FormHelper.Gia(cboHopDong);
            if (string.IsNullOrEmpty(maHD)) return;

            // Nạp danh sách phòng thuê thuộc hợp đồng
            DataTable dtPhong = _hdService.LayChiTietPhongTheoHopDong(maHD);
            FormHelper.Nap(cboPhong, dtPhong, "TenPhong", "MaPhong");

            // Lấy thời hạn gốc của hợp đồng
            DataTable dtHD = _hdService.LayDanhSachHopDong();
            DataRow[] rows = dtHD.Select("MaHD = '" + maHD + "'");
            if (rows.Length > 0)
            {
                _thoiHanGoc = Convert.ToInt32(rows[0]["ThoiHanThueThang"]);
                _maxGiaHan = _thoiHanGoc / 2;
                lblThoiHanGoc.Text = string.Format("Thời hạn ban đầu: {0} tháng | Tối đa được gia hạn: {1} tháng", _thoiHanGoc, _maxGiaHan);
                numSoThangGiaHan.Maximum = _maxGiaHan > 0 ? _maxGiaHan : 1;
                numSoThangGiaHan.Value = Math.Min(numSoThangGiaHan.Value, numSoThangGiaHan.Maximum);
            }

            // Kiểm tra công nợ tiền thuê
            DataTable dtNoThue = _ghService.LayCongNoTienThue(maHD);
            dgvNoTienThue.DataSource = dtNoThue;
            int soNoThue = dtNoThue.Rows.Count;
            if (soNoThue == 0)
            {
                lblTrangThaiNoThue.Text = "Nợ tiền thuê: 0 đ (HỢP LỆ)";
                lblTrangThaiNoThue.ForeColor = Color.Green;
            }
            else
            {
                lblTrangThaiNoThue.Text = string.Format("CÒN NỢ TIỀN THUÊ: {0} kỳ chưa trả", soNoThue);
                lblTrangThaiNoThue.ForeColor = Color.Red;
            }

            // Kiểm tra công nợ dịch vụ
            DataTable dtNoDV = _ghService.LayCongNoDichVu(maHD);
            dgvNoDichVu.DataSource = dtNoDV;
            int soNoDV = dtNoDV.Rows.Count;
            if (soNoDV == 0)
            {
                lblTrangThaiNoDV.Text = "Nợ dịch vụ: 0 đ (HỢP LỆ)";
                lblTrangThaiNoDV.ForeColor = Color.Green;
            }
            else
            {
                lblTrangThaiNoDV.Text = string.Format("CÒN NỢ DỊCH VỤ: {0} hóa đơn chưa trả", soNoDV);
                lblTrangThaiNoDV.ForeColor = Color.Red;
            }
        }

        private void TaiDanhSachPhieuGiaHan()
        {
            dgvPhieuGiaHan.DataSource = _ghService.LayDanhSachPhieuGiaHan();
        }

        private void btnLapPhieuGiaHan_Click(object sender, EventArgs e)
        {
            string maPGH = txtMaPGH.Text.Trim();
            string maHD = FormHelper.Gia(cboHopDong);
            string maPhong = FormHelper.Gia(cboPhong);
            int soThang = (int)numSoThangGiaHan.Value;
            decimal? donGiaMoi = numDonGiaMoi.Value > 0 ? (decimal?)numDonGiaMoi.Value : null;

            if (string.IsNullOrEmpty(maPGH) || string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng điền đủ mã phiếu, hợp đồng và phòng cần gia hạn.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy kq = _ghService.LapPhieuGiaHan(maPGH, maHD, maPhong, soThang, donGiaMoi);
            if (FormHelper.Bao(kq))
            {
                TaiDanhSachPhieuGiaHan();
                txtMaPGH.Text = "GH" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
                KiemTraHopDong();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaPGH.Text = "GH" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
            KiemTraHopDong();
            TaiDanhSachPhieuGiaHan();
        }
    }
}
