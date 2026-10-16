using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
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
            dgvKhoa.DataSource = svc.LayKhoa();
            dgvBacSi.DataSource = svc.LayBacSi();
            dgvLoaiXN.DataSource = svc.LayLoaiXetNghiem();
            dgvThuoc.DataSource = svc.LayThuoc();
            FormHelper.Nap(cboKhoaBS, svc.LayKhoa(), "TenKhoa", "MaKhoa");
        }

        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemKhoa(txtMaKhoa.Text, txtTenKhoa.Text, txtViTri.Text, txtSDTKhoa.Text)))
            {
                Tai();
                txtMaKhoa.Clear(); txtTenKhoa.Clear(); txtViTri.Clear(); txtSDTKhoa.Clear();
            }
        }

        private void btnThemBS_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemBacSi(txtMaBS.Text, FormHelper.Gia(cboKhoaBS), txtTenBS.Text, txtChuyenKhoa.Text, txtSDTBS.Text, txtHocVi.Text)))
            {
                Tai();
                txtMaBS.Clear(); txtTenBS.Clear(); txtChuyenKhoa.Clear(); txtSDTBS.Clear(); txtHocVi.Clear();
            }
        }

        private void btnThemXN_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemLoaiXN(txtMaXN.Text, txtTenXN.Text, numGiaXN.Value, txtChiSo.Text)))
            {
                Tai();
                txtMaXN.Clear(); txtTenXN.Clear(); txtChiSo.Clear();
            }
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            if (FormHelper.Bao(svc.ThemThuoc(txtMaThuoc.Text, txtTenThuoc.Text, txtDVT.Text, numGiaThuoc.Value, txtCongDung.Text, txtCanhBao.Text)))
            {
                Tai();
                txtMaThuoc.Clear(); txtTenThuoc.Clear(); txtDVT.Clear(); txtCongDung.Clear(); txtCanhBao.Clear();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
