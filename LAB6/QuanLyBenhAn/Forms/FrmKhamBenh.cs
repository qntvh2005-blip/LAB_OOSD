using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmKhamBenh : Form
    {
        private readonly KhamBenhService svc = new KhamBenhService();
        private readonly DanhMucService dmSvc = new DanhMucService();
        private readonly BenhNhanService bnSvc = new BenhNhanService();
        private readonly DinhKyService dkSvc = new DinhKyService();

        public FrmKhamBenh()
        {
            InitializeComponent();
        }

        private void FrmKhamBenh_Load(object sender, EventArgs e)
        {
            cboLoaiKham.Items.AddRange(new object[] { QuyDinh.LoaiKhamThuong, QuyDinh.LoaiKhamDinhKy });
            cboLoaiKham.SelectedIndex = 0;

            FormHelper.Nap(cboHoSo, bnSvc.LayDanhSachHoSo(), "MaHoSo", "MaHoSo");
            FormHelper.Nap(cboKhoa, dmSvc.LayKhoa(), "TenKhoa", "MaKhoa");

            TaiBacSiTheoKhoa();
            Tai();
        }

        private void Tai()
        {
            dgvPhieuKham.DataSource = svc.LayDanhSachPhieuKham();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiBacSiTheoKhoa();
        }

        private void TaiBacSiTheoKhoa()
        {
            string maKhoa = FormHelper.Gia(cboKhoa);
            if (!string.IsNullOrWhiteSpace(maKhoa))
            {
                FormHelper.Nap(cboBacSi, dmSvc.LayBacSi(maKhoa), "HoTen", "MaBacSi");
            }
        }

        private void cboLoaiKham_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool laDinhKy = cboLoaiKham.Text == QuyDinh.LoaiKhamDinhKy;
            cboLichHen.Enabled = laDinhKy;
            if (laDinhKy)
            {
                string maHoSo = FormHelper.Gia(cboHoSo);
                if (!string.IsNullOrWhiteSpace(maHoSo))
                {
                    FormHelper.Nap(cboLichHen, dkSvc.LayLichHenChoKham(maHoSo), "HienThi", "MaLichHen");
                }
            }
        }

        private void cboHoSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiKham.Text == QuyDinh.LoaiKhamDinhKy)
            {
                string maHoSo = FormHelper.Gia(cboHoSo);
                if (!string.IsNullOrWhiteSpace(maHoSo))
                {
                    FormHelper.Nap(cboLichHen, dkSvc.LayLichHenChoKham(maHoSo), "HienThi", "MaLichHen");
                }
            }
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            string maLich = cboLoaiKham.Text == QuyDinh.LoaiKhamDinhKy ? FormHelper.Gia(cboLichHen) : null;
            var k = svc.TaoPhieuKham(
                txtMaPK.Text,
                FormHelper.Gia(cboHoSo),
                FormHelper.Gia(cboKhoa),
                FormHelper.Gia(cboBacSi),
                cboLoaiKham.Text,
                txtTrieuChung.Text,
                numThanNhiet.Value,
                txtHuyetAp.Text,
                txtChanDoan.Text,
                maLich
            );

            if (FormHelper.Bao(k))
            {
                Tai();
                txtMaPK.Clear();
                txtTrieuChung.Clear();
                txtHuyetAp.Clear();
                txtChanDoan.Clear();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
