using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmTraCuuLichSu : Form
    {
        private readonly TraCuuService svc = new TraCuuService();
        private bool dangNapHoSo;

        public FrmTraCuuLichSu()
        {
            InitializeComponent();
        }

        private void FrmTraCuuLichSu_Load(object sender, EventArgs e)
        {
            TaiHoSo("");
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TaiHoSo(txtTuKhoa.Text);
        }

        private void TaiHoSo(string tuKhoa)
        {
            dgvLichSuKham.DataSource = null;
            dgvXN.DataSource = null;
            dgvToa.DataSource = null;
            dangNapHoSo = true;
            try { dgvHoSo.DataSource = svc.TimKiemHoSo(tuKhoa); }
            finally { dangNapHoSo = false; }
            dgvHoSo_SelectionChanged(null, EventArgs.Empty);
        }

        private void dgvHoSo_SelectionChanged(object sender, EventArgs e)
        {
            if (dangNapHoSo) return;
            dgvLichSuKham.DataSource = null;
            dgvXN.DataSource = null;
            dgvToa.DataSource = null;
            string maHoSo = FormHelper.O(dgvHoSo, "MaHoSo");
            string hoTen = FormHelper.O(dgvHoSo, "HoTen");
            string diUng = FormHelper.O(dgvHoSo, "TienSuDiUng");

            lblThongTinBN.Text = string.Format("Hồ sơ: {0} | Bệnh nhân: {1} | Tiền sử dị ứng: {2}",
                maHoSo, hoTen, string.IsNullOrWhiteSpace(diUng) ? "Không có" : diUng);

            if (!string.IsNullOrWhiteSpace(maHoSo))
            {
                dgvLichSuKham.DataSource = svc.LayLichSuKhamBenh(maHoSo);
            }
        }

        private void dgvLichSuKham_SelectionChanged(object sender, EventArgs e)
        {
            dgvXN.DataSource = null;
            dgvToa.DataSource = null;
            string maPK = FormHelper.O(dgvLichSuKham, "MaPhieuKham");
            if (!string.IsNullOrWhiteSpace(maPK))
            {
                dgvXN.DataSource = svc.LayChiTietXetNghiem(maPK);
                dgvToa.DataSource = svc.LayChiTietToaThuoc(maPK);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
