using System;
using System.Data;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmKiemTraXuPhat : Form
    {
        private readonly KiemTraPhongService _ktService = new KiemTraPhongService();
        private readonly HopDongService _hdService = new HopDongService();
        private readonly DanhMucService _dmService = new DanhMucService();

        public FrmKiemTraXuPhat()
        {
            InitializeComponent();
            Load += FrmKiemTraXuPhat_Load;
        }

        private void FrmKiemTraXuPhat_Load(object sender, EventArgs e)
        {
            NapCombobox();
            TaiDanhSachKiemTra();
            TaiDanhSachXuPhat();
            TaoMaMoi();
        }

        private void TaoMaMoi()
        {
            txtMaKT.Text = "KT" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
            txtMaBB.Text = "BB" + DateTime.Now.ToString("yyyyMMddHHmmss").Substring(2, 8);
        }

        private void NapCombobox()
        {
            DataTable dtPhong = _dmService.LayDanhSachPhong();
            FormHelper.Nap(cboPhongKT, dtPhong, "TenPhong", "MaPhong");
            FormHelper.Nap(cboPhongBB, dtPhong, "TenPhong", "MaPhong");

            DataTable dtHD = _hdService.LayDanhSachHopDong();
            FormHelper.Nap(cboHopDongBB, dtHD, "MaHD", "MaHD");
        }

        private void TaiDanhSachKiemTra()
        {
            DataTable dtKT = _ktService.LayDanhSachKiemTra();
            dgvKiemTra.DataSource = dtKT;

            // Nạp các phiếu kiểm tra có vi phạm vào ComboBox biên bản
            DataView dv = new DataView(dtKT);
            dv.RowFilter = "CoViPham = 1 OR CoViPham = true";
            FormHelper.Nap(cboPhieuKT, dv.ToTable(), "MaPhieuKT", "MaPhieuKT");
        }

        private void TaiDanhSachXuPhat()
        {
            dgvXuPhat.DataSource = _ktService.LayDanhSachXuPhat();
        }

        private void btnLuuKiemTra_Click(object sender, EventArgs e)
        {
            string maKT = txtMaKT.Text.Trim();
            string maPhong = FormHelper.Gia(cboPhongKT);
            string nguoiKT = txtNguoiKT.Text.Trim();
            DateTime ngayKT = dtpNgayKT.Value.Date;
            string hienTrang = txtHienTrang.Text.Trim();
            bool coThayDoi = chkThayDoiKetCau.Checked;
            bool datYC = chkDatYeuCau.Checked;
            string ghiChu = txtGhiChuKT.Text.Trim();

            if (string.IsNullOrEmpty(maKT) || string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng nhập mã kiểm tra và chọn phòng kiểm tra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy kq = _ktService.LapPhieuKiemTra(maKT, maPhong, nguoiKT, hienTrang, "Nội thất tốt", coThayDoi, ghiChu);
            if (FormHelper.Bao(kq))
            {
                TaoMaMoi();
                TaiDanhSachKiemTra();
            }
        }

        private void btnLapBienBan_Click(object sender, EventArgs e)
        {
            string maBB = txtMaBB.Text.Trim();
            string maKT = FormHelper.Gia(cboPhieuKT);
            string maHD = FormHelper.Gia(cboHopDongBB);
            string maPhong = FormHelper.Gia(cboPhongBB);
            string loi = txtLoiViPham.Text.Trim();
            decimal tienPhat = numTienPhat.Value;
            DateTime hanKP = dtpHanKhacPhuc.Value.Date;
            string bienPhap = txtBienPhap.Text.Trim();

            if (string.IsNullOrEmpty(maBB) || string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng điền đủ mã biên bản, hợp đồng và phòng vi phạm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy kq = _ktService.LapBienBanXuPhat(maBB, string.IsNullOrEmpty(maKT) ? "KT001" : maKT, maHD, maPhong, loi, tienPhat, hanKP);
            if (FormHelper.Bao(kq))
            {
                TaoMaMoi();
                TaiDanhSachXuPhat();
            }
        }

        private void btnNopTienPhat_Click(object sender, EventArgs e)
        {
            string maBB = FormHelper.O(dgvXuPhat, "MaBB");
            if (string.IsNullOrEmpty(maBB))
            {
                MessageBox.Show("Vui lòng chọn một biên bản xử phạt trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string daNop = FormHelper.O(dgvXuPhat, "DaNopPhat");
            if (daNop == "True" || daNop == "1")
            {
                MessageBox.Show("Biên bản này đã nộp phạt rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xác nhận thu tiền phạt cho biên bản " + maBB + "?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                KetQuaXuLy kq = _ktService.NopTienPhat(maBB);
                if (FormHelper.Bao(kq))
                {
                    TaiDanhSachXuPhat();
                }
            }
        }
    }
}
