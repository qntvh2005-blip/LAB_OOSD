using System;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService svc = new DanhMucService();

        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            Tai();
        }

        private void Tai()
        {
            dgvTang.DataSource = svc.LayDanhSachTang();
            dgvPhong.DataSource = svc.LayDanhSachPhong();
            dgvDichVu.DataSource = svc.LayDanhSachDichVu();
            dgvKhachHang.DataSource = svc.LayDanhSachKhachHang();

            FormHelper.Nap(cboTangPhong, svc.LayDanhSachTang(), "TenTang", "MaTang");
            if (cboHuong.Items.Count > 0 && cboHuong.SelectedIndex < 0)
                cboHuong.SelectedIndex = 0;
            if (cboLoaiDV.Items.Count > 0 && cboLoaiDV.SelectedIndex < 0)
                cboLoaiDV.SelectedIndex = 0;
        }

        private void btnThemTang_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemTang(txtMaTang.Text, txtTenTang.Text, (int)numDoCao.Value, numHeSoGia.Value, txtGhiChuTang.Text)))
            {
                Tai();
                txtMaTang.Clear(); txtTenTang.Clear(); txtGhiChuTang.Clear();
            }
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemPhong(txtMaPhong.Text, FormHelper.Gia(cboTangPhong), txtTenPhong.Text, numDienTich.Value, cboHuong.Text, numDonGiaCoBan.Value)))
            {
                Tai();
                txtMaPhong.Clear(); txtTenPhong.Clear();
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemDichVu(txtMaDV.Text, txtTenDV.Text, txtDVT.Text, numDonGiaDV.Value, cboLoaiDV.Text)))
            {
                Tai();
                txtMaDV.Clear(); txtTenDV.Clear(); txtDVT.Clear();
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemKhachHang(txtMaKH.Text, txtTenCongTy.Text, txtNguoiDaiDien.Text, txtMST.Text, txtSDTKH.Text, txtEmailKH.Text, txtDiaChiKH.Text)))
            {
                Tai();
                txtMaKH.Clear(); txtTenCongTy.Clear(); txtNguoiDaiDien.Clear(); txtMST.Clear(); txtSDTKH.Clear(); txtEmailKH.Clear(); txtDiaChiKH.Clear();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
