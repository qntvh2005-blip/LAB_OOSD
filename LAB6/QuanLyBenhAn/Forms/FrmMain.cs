using System;
using System.Windows.Forms;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Mo(Form f)
        {
            using (f) f.ShowDialog(this);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e) { Mo(new FrmDanhMuc()); }
        private void btnDangKyHoSo_Click(object sender, EventArgs e) { Mo(new FrmDangKyHoSo()); }
        private void btnLichDinhKy_Click(object sender, EventArgs e) { Mo(new FrmLichDinhKy()); }
        private void btnKhamBenh_Click(object sender, EventArgs e) { Mo(new FrmKhamBenh()); }
        private void btnXetNghiem_Click(object sender, EventArgs e) { Mo(new FrmXetNghiem()); }
        private void btnToaThuoc_Click(object sender, EventArgs e) { Mo(new FrmToaThuoc()); }
        private void btnVienPhi_Click(object sender, EventArgs e) { Mo(new FrmVienPhiHoanTat()); }
        private void btnTraCuu_Click(object sender, EventArgs e) { Mo(new FrmTraCuuLichSu()); }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }
    }
}
