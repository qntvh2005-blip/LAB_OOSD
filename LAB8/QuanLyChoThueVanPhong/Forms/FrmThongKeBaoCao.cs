using System;
using System.Data;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmThongKeBaoCao : Form
    {
        private readonly ThongKeService _tkService = new ThongKeService();

        public FrmThongKeBaoCao()
        {
            InitializeComponent();
            Load += FrmThongKeBaoCao_Load;
        }

        private void FrmThongKeBaoCao_Load(object sender, EventArgs e)
        {
            numNamThue.Value = DateTime.Now.Year;
            numNamDV.Value = DateTime.Now.Year;

            TaiTatCaThongKe();
        }

        private void TaiTatCaThongKe()
        {
            TaiThongKePhong();
            TaiThongKeDoanhThuThue();
            TaiThongKeDoanhThuDV();
            TaiTongHopCongNo();
        }

        private void TaiThongKePhong()
        {
            dgvPhongStatus.DataSource = _tkService.ThongKeTinhTrangPhong();
        }

        private void TaiThongKeDoanhThuThue()
        {
            int nam = (int)numNamThue.Value;
            dgvDoanhThuThue.DataSource = _tkService.ThongKeDoanhThuThueTheoNam(nam);
        }

        private void TaiThongKeDoanhThuDV()
        {
            int nam = (int)numNamDV.Value;
            dgvDoanhThuDV.DataSource = _tkService.ThongKeDoanhThuDichVuTheoNam(nam);
        }

        private void TaiTongHopCongNo()
        {
            dgvCongNoToanBo.DataSource = _tkService.TongHopCongNoToanCaoOc();
        }

        private void btnXemDoanhThuThue_Click(object sender, EventArgs e)
        {
            TaiThongKeDoanhThuThue();
        }

        private void btnXemDoanhThuDV_Click(object sender, EventArgs e)
        {
            TaiThongKeDoanhThuDV();
        }

        private void btnTaiLaiCongNo_Click(object sender, EventArgs e)
        {
            TaiTongHopCongNo();
        }
    }
}
