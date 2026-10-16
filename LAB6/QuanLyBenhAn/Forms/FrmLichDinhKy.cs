using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmLichDinhKy : Form
    {
        private readonly DinhKyService svc = new DinhKyService();
        private readonly BenhNhanService bnSvc = new BenhNhanService();

        public FrmLichDinhKy()
        {
            InitializeComponent();
        }

        private void FrmLichDinhKy_Load(object sender, EventArgs e)
        {
            FormHelper.Nap(cboHoSo, bnSvc.LayDanhSachHoSo(), "MaHoSo", "MaHoSo");
            dtGioHen.Value = DateTime.Today.AddDays(1).AddHours(9);
            cboQuy.SelectedIndex = (dtGioHen.Value.Month - 1) / 3;
            numNam.Value = dtGioHen.Value.Year;
            Tai();
        }

        private void Tai()
        {
            dgvLichHen.DataSource = svc.LayTatCaLichHen();
        }

        private void btnDatLich_Click(object sender, EventArgs e)
        {
            int quy = cboQuy.SelectedIndex + 1;
            var k = svc.DatLichHen(
                txtMaLich.Text,
                FormHelper.Gia(cboHoSo),
                (int)numNam.Value,
                quy,
                dtGioHen.Value,
                txtNoiDung.Text
            );

            if (FormHelper.Bao(k))
            {
                Tai();
                txtMaLich.Clear();
                txtNoiDung.Clear();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
