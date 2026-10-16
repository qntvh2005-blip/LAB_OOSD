using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmVienPhiHoanTat : Form
    {
        private readonly VienPhiService svc = new VienPhiService();

        public FrmVienPhiHoanTat()
        {
            InitializeComponent();
        }

        private void FrmVienPhiHoanTat_Load(object sender, EventArgs e)
        {
            Tai();
        }

        private void Tai()
        {
            dgvChoThanhToan.DataSource = svc.LayDanhSachChoThanhToan();
            dgvLichSuHD.DataSource = svc.LayLichSuHoaDon();
        }

        private void dgvChoThanhToan_SelectionChanged(object sender, EventArgs e)
        {
            string maPK = FormHelper.O(dgvChoThanhToan, "MaPhieuKham");
            txtMaPK.Text = maPK;

            decimal tienKham = 0, tienXN = 0, tienThuoc = 0;
            decimal.TryParse(FormHelper.O(dgvChoThanhToan, "TienKham"), out tienKham);
            decimal.TryParse(FormHelper.O(dgvChoThanhToan, "TienXN"), out tienXN);
            decimal.TryParse(FormHelper.O(dgvChoThanhToan, "TienThuoc"), out tienThuoc);

            string loaiKham = FormHelper.O(dgvChoThanhToan, "LoaiKham");
            decimal mienPhi = (loaiKham == QuyDinh.LoaiKhamDinhKy) ? tienKham : 0;
            decimal tong = tienKham + tienXN + tienThuoc - mienPhi;

            lblChiTietTien.Text = string.Format("Tiền khám: {0:N0} đ | Tiền XN: {1:N0} đ | Tiền thuốc: {2:N0} đ | Miễn phí định kỳ: {3:N0} đ",
                tienKham, tienXN, tienThuoc, mienPhi);
            lblTongThu.Text = string.Format("TỔNG THỰC THU: {0:N0} VNĐ", tong);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            var k = svc.ThanhToanVaHoanTat(
                txtMaHD.Text,
                txtMaPK.Text,
                txtPhanUngPhu.Text,
                txtHieuQua.Text,
                txtGhiChu.Text
            );

            if (FormHelper.Bao(k))
            {
                Tai();
                txtMaHD.Clear();
                txtPhanUngPhu.Clear();
                txtHieuQua.Clear();
                txtGhiChu.Clear();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
