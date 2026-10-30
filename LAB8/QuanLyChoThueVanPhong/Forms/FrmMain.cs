using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void MoForm(Func<Form> formFactory)
        {
            try
            {
                using (Form f = formFactory())
                {
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi mở chức năng:\n" + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            MoForm(() => new FrmDanhMuc());
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            MoForm(() => new FrmHopDongThue());
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            MoForm(() => new FrmThanhToanThang(0));
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            MoForm(() => new FrmThanhToanThang(1));
        }

        private void btnGiaHan_Click(object sender, EventArgs e)
        {
            MoForm(() => new FrmGiaHan());
        }

        private void btnNhanVienTheXe_Click(object sender, EventArgs e)
        {
            MoForm(() => new FrmNhanVienTheXe());
        }

        private void btnKiemTraXuPhat_Click(object sender, EventArgs e)
        {
            MoForm(() => new FrmKiemTraXuPhat());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            MoForm(() => new FrmThongKeBaoCao());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát hệ thống?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
