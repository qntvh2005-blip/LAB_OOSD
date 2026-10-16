using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmXetNghiem : Form
    {
        private readonly XetNghiemService svc = new XetNghiemService();
        private readonly KhamBenhService kbSvc = new KhamBenhService();
        private readonly DanhMucService dmSvc = new DanhMucService();

        public FrmXetNghiem()
        {
            InitializeComponent();
        }

        private void FrmXetNghiem_Load(object sender, EventArgs e)
        {
            FormHelper.Nap(cboPhieuKham, kbSvc.LayPhieuKhamChoXetNghiemHoacToa(), "HienThi", "MaPhieuKham");
            FormHelper.Nap(cboLoaiXN, dmSvc.LayLoaiXetNghiem(), "TenLoaiXN", "MaLoaiXN");
            Tai();
        }

        private void Tai()
        {
            dgvXetNghiem.DataSource = svc.LayTatCaXetNghiem();
        }

        private void btnChiDinh_Click(object sender, EventArgs e)
        {
            var k = svc.ChiDinhXetNghiem(txtMaPXN.Text, FormHelper.Gia(cboPhieuKham), FormHelper.Gia(cboLoaiXN));
            if (FormHelper.Bao(k))
            {
                Tai();
                txtMaPXN.Clear();
            }
        }

        private void dgvXetNghiem_SelectionChanged(object sender, EventArgs e)
        {
            txtPXNChon.Text = FormHelper.O(dgvXetNghiem, "MaPhieuXN");
            txtKetQua.Text = FormHelper.O(dgvXetNghiem, "KetQua");
        }

        private void btnLuuKQ_Click(object sender, EventArgs e)
        {
            var k = svc.CapNhatKetQua(txtPXNChon.Text, txtKetQua.Text);
            if (FormHelper.Bao(k))
            {
                Tai();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
