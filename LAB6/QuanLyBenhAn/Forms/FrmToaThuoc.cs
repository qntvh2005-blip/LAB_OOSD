using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmToaThuoc : Form
    {
        private readonly ToaThuocService svc = new ToaThuocService();
        private readonly KhamBenhService kbSvc = new KhamBenhService();
        private readonly DanhMucService dmSvc = new DanhMucService();
        private readonly BindingList<ChiTietToaItem> dsThuocKe = new BindingList<ChiTietToaItem>();

        public FrmToaThuoc()
        {
            InitializeComponent();
        }

        private void FrmToaThuoc_Load(object sender, EventArgs e)
        {
            FormHelper.Nap(cboPhieuKham, kbSvc.LayPhieuKhamChoXetNghiemHoacToa(), "HienThi", "MaPhieuKham");
            FormHelper.Nap(cboThuoc, dmSvc.LayThuoc(), "TenThuoc", "MaThuoc");

            dgvThuocTrongToa.DataSource = dsThuocKe;
            numSoLuong.Value = 10;
            txtLieuDung.Text = "1 viên / lần x 2 lần / ngày";
            txtCachDung.Text = "Uống sau khi ăn no";

            Tai();
        }

        private void Tai()
        {
            dgvToaThuoc.DataSource = svc.LayTatCaToaThuoc();
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            string maThuoc = FormHelper.Gia(cboThuoc);
            if (string.IsNullOrWhiteSpace(maThuoc)) return;

            // Kiểm tra xem thuốc đã có trong toa tạm chưa
            var daCo = dsThuocKe.FirstOrDefault(x => x.MaThuoc == maThuoc);
            if (daCo != null)
            {
                daCo.SoLuong += (int)numSoLuong.Value;
                dgvThuocTrongToa.Refresh();
                CapNhatTongTien();
                return;
            }

            var drv = cboThuoc.SelectedItem as DataRowView;
            decimal donGia = drv != null ? Convert.ToDecimal(drv["DonGia"]) : 0;
            string tenThuoc = drv != null ? drv["TenThuoc"].ToString() : "";

            dsThuocKe.Add(new ChiTietToaItem
            {
                MaThuoc = maThuoc,
                TenThuoc = tenThuoc,
                SoLuong = (int)numSoLuong.Value,
                DonGia = donGia,
                LieuDung = txtLieuDung.Text,
                CachDung = txtCachDung.Text
            });

            CapNhatTongTien();
        }

        private void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            if (dgvThuocTrongToa.CurrentRow != null && dgvThuocTrongToa.CurrentRow.DataBoundItem is ChiTietToaItem item)
            {
                dsThuocKe.Remove(item);
                CapNhatTongTien();
            }
        }

        private void CapNhatTongTien()
        {
            decimal tong = dsThuocKe.Sum(x => x.ThanhTien);
            lblTongTien.Text = "Tổng tiền thuốc: " + tong.ToString("N0") + " đ";
        }

        private void btnLapToa_Click(object sender, EventArgs e)
        {
            var k = svc.LapToaThuoc(
                txtMaToa.Text,
                FormHelper.Gia(cboPhieuKham),
                txtLoiDan.Text,
                dsThuocKe.ToList()
            );

            if (FormHelper.Bao(k))
            {
                dsThuocKe.Clear();
                CapNhatTongTien();
                Tai();
                txtMaToa.Clear();
                txtLoiDan.Clear();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
