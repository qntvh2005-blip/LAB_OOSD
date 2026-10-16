using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmDangKyHoSo : Form
    {
        private readonly BenhNhanService svc = new BenhNhanService();

        public FrmDangKyHoSo()
        {
            InitializeComponent();
        }

        private void FrmDangKyHoSo_Load(object sender, EventArgs e)
        {
            cboGioiTinh.SelectedIndex = 0;
            numNamLePhi.Value = DateTime.Today.Year;
            numTienLePhi.Value = QuyDinh.LePhiNamMacDinh;
            numGiaHanNam.Value = DateTime.Today.Year + 1;
            numGiaHanTien.Value = QuyDinh.LePhiNamMacDinh;
            Tai();
        }

        private void Tai()
        {
            dgvBenhNhan.DataSource = svc.LayDanhSachBenhNhan();
            dgvHoSo.DataSource = svc.LayDanhSachHoSo();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            var k = svc.DangKyLanDau(
                txtMaBN.Text,
                txtHoTen.Text,
                dtNgaySinh.Value,
                cboGioiTinh.Text,
                txtDiaChi.Text,
                txtSDT.Text,
                txtAnh.Text,
                txtMaPDK.Text,
                txtGhiChuPDK.Text,
                txtMaHoSo.Text,
                txtTienSuDiUng.Text,
                (int)numNamLePhi.Value,
                numTienLePhi.Value
            );

            if (FormHelper.Bao(k))
            {
                Tai();
                txtMaBN.Clear();
                txtHoTen.Clear();
                txtDiaChi.Clear();
                txtSDT.Clear();
                txtAnh.Clear();
                txtMaPDK.Clear();
                txtGhiChuPDK.Clear();
                txtMaHoSo.Clear();
                txtTienSuDiUng.Clear();
            }
        }

        private void dgvHoSo_SelectionChanged(object sender, EventArgs e)
        {
            string maHoSo = FormHelper.O(dgvHoSo, "MaHoSo");
            txtGiaHanHoSo.Text = maHoSo;
            if (!string.IsNullOrWhiteSpace(maHoSo))
            {
                dgvLePhi.DataSource = svc.LayLePhiCuaHoSo(maHoSo);
            }
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            var k = svc.GiaHanLePhiNam(
                txtGiaHanHoSo.Text,
                (int)numGiaHanNam.Value,
                numGiaHanTien.Value,
                txtGiaHanGhiChu.Text
            );

            if (FormHelper.Bao(k))
            {
                Tai();
                dgvLePhi.DataSource = svc.LayLePhiCuaHoSo(txtGiaHanHoSo.Text);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
