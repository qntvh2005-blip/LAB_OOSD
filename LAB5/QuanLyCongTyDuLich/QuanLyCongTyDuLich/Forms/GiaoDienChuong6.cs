using System.Drawing;
using System.Windows.Forms;

// Them file nay vao thu muc Forms. Trong constructor cua moi Frm,
// goi HoanThienGiaoDien(); NGAY SAU InitializeComponent(); (chi mot lan).
// Khong thay Designer, Service, SQL, du lieu hay su kien Click/Load cu.
namespace QuanLyCongTyDuLich.Forms
{
    internal static class GiaoDienC6
    {
        internal static readonly AnchorStyles BonCanh = AnchorStyles.Top |
            AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        internal static void ChuanBi(Form f, string title, int width = 1000, int height = 680)
        {
            f.SuspendLayout();
            f.AutoScaleMode = AutoScaleMode.Dpi;
            f.AutoScaleDimensions = new SizeF(96F, 96F);
            f.Font = new Font("Microsoft Sans Serif", 8.25F);
            f.Text = title;
            f.ClientSize = new Size(width, height);
            f.MinimumSize = f.Size;
            f.StartPosition = FormStartPosition.CenterParent;
            f.BackColor = SystemColors.Control;
            ChuanBiCon(f);
        }

        private static void ChuanBiCon(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // An nhan cu de tranh nhan bi trung. Nhan ket qua se duoc hien lai bang Dat.
                if (c is Label) c.Visible = false;
                var combo = c as ComboBox;
                if (combo != null) combo.DropDownStyle = ComboBoxStyle.DropDownList;
                var date = c as DateTimePicker;
                if (date != null) { date.Format = DateTimePickerFormat.Custom; date.CustomFormat = "dd/MM/yyyy"; }
                var grid = c as DataGridView;
                if (grid != null)
                {
                    grid.ReadOnly = true;
                    grid.AllowUserToAddRows = false;
                    grid.AllowUserToDeleteRows = false;
                    grid.MultiSelect = false;
                    grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    grid.BackgroundColor = Color.White;
                    grid.BorderStyle = BorderStyle.FixedSingle;
                    grid.RowHeadersWidth = 28;
                    grid.ColumnHeadersHeight = 28;
                }
                ChuanBiCon(c);
            }
        }

        internal static void Dat(Control c, int x, int y, int w, int h = 24)
        {
            var label = c as Label;
            if (label != null) { label.AutoSize = false; label.TextAlign = ContentAlignment.MiddleLeft; }
            c.Dock = DockStyle.None;
            c.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            c.SetBounds(x, y, w, h);
            c.Visible = true;
        }

        internal static void Nhan(Control parent, string text, int x, int y, int w = 100)
        {
            var label = new Label { Text = text, AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft, Name = "lblC6_" + parent.Controls.Count };
            Dat(label, x, y, w);
            parent.Controls.Add(label);
        }

        internal static void O(Control parent, string text, Control input, int x, int y, int labelWidth, int inputWidth)
        {
            Nhan(parent, text, x, y, labelWidth);
            Dat(input, x + labelWidth, y, inputWidth);
        }

        internal static void Nut(Button b, string text, int x, int y, int w = 120)
        {
            b.Text = text;
            Dat(b, x, y, w, 32);
        }

        internal static void Bang(DataGridView g, int x, int y, int w, int h)
        {
            Dat(g, x, y, w, h);
            // Grid phia tren giu chieu cao; grid cuoi Form gian theo cua so.
            g.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        internal static void Tab(TabControl t, int x, int y, int w, int h)
        {
            Dat(t, x, y, w, h);
            t.Anchor = BonCanh;
            // Chot kich thuoc TabPage truoc khi dat Anchor cho cac grid con.
            t.CreateControl();
            foreach (TabPage p in t.TabPages)
            {
                p.Bounds = t.DisplayRectangle;
                p.BackColor = SystemColors.Control;
                p.UseVisualStyleBackColor = false;
            }
        }

        internal static void Xong(Form f, Button close)
        {
            Nut(close, "Đóng", f.ClientSize.Width - 112, f.ClientSize.Height - 42, 100);
            close.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            close.DialogResult = DialogResult.Cancel;
            f.CancelButton = close;
            f.ResumeLayout(true);
        }

        internal static void Tien(NumericUpDown n) { n.ThousandsSeparator = true; }
        internal static void KetQua(Label l) { l.ForeColor = Color.Firebrick; l.Font = new Font(l.Font, FontStyle.Bold); }
    }

    public partial class FrmMain
    {
        private void HoanThienGiaoDien()
        {
            GiaoDienC6.ChuanBi(this, "Quản lý công ty du lịch Văn Hóa Việt", 800, 580);
            StartPosition = FormStartPosition.CenterScreen;
            var title = new Label { Name = "lblTieuDeC6", Text = "CÔNG TY DU LỊCH VĂN HÓA VIỆT",
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold), ForeColor = Color.FromArgb(31, 78, 121) };
            GiaoDienC6.Dat(title, 30, 28, 740, 48);
            title.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(title);
            Button[] left = { btnDanhMuc, btnChuyenLe, btnDangKyDoan, btnKetThuc };
            Button[] right = { btnTour, btnDangKyLe, btnPhanCong, btnThongKe };
            for (int i = 0; i < 4; i++)
            {
                GiaoDienC6.Dat(left[i], 70, 115 + i * 78, 320, 58);
                GiaoDienC6.Dat(right[i], 410, 115 + i * 78, 320, 58);
            }
            GiaoDienC6.Dat(btnThoat, 240, 455, 320, 58);
            ResumeLayout(true);
        }
    }

    public partial class FrmDanhMuc
    {
        private void HoanThienGiaoDien()
        {
            GiaoDienC6.ChuanBi(this, "Danh mục");
            GiaoDienC6.Tab(tabControl1, 12, 12, 976, 614);
            GiaoDienC6.Bang(dgvPT, 12, 12, 940, 370);
            GiaoDienC6.O(tabPT, "Mã PT:", txtPTMa, 12, 400, 100, 160);
            GiaoDienC6.O(tabPT, "Tên PT:", txtPTTen, 315, 400, 100, 350);
            GiaoDienC6.O(tabPT, "Ghi chú:", txtPTGhiChu, 12, 442, 100, 650);
            GiaoDienC6.Nut(btnThemPT, "Thêm", 810, 437);
            GiaoDienC6.Bang(dgvDB, 12, 12, 940, 370);
            GiaoDienC6.O(tabDB, "Mã điểm bán:", txtDBMa, 12, 400, 100, 160);
            GiaoDienC6.O(tabDB, "Tên điểm bán:", txtDBTen, 315, 400, 110, 350);
            GiaoDienC6.O(tabDB, "Địa chỉ:", txtDBDiaChi, 12, 440, 100, 650);
            GiaoDienC6.O(tabDB, "Điện thoại:", txtDBDT, 12, 480, 100, 250);
            GiaoDienC6.Nut(btnThemDB, "Thêm", 810, 475);
            GiaoDienC6.Bang(dgvHDV, 12, 12, 940, 370);
            GiaoDienC6.O(tabHDV, "Mã HDV:", txtHDVMa, 12, 400, 100, 160);
            GiaoDienC6.O(tabHDV, "Họ tên:", txtHDVTen, 315, 400, 100, 350);
            GiaoDienC6.O(tabHDV, "Điện thoại:", txtHDVDT, 12, 440, 100, 250);
            GiaoDienC6.O(tabHDV, "Lương cơ bản:", numLuong, 415, 440, 110, 220);
            GiaoDienC6.Tien(numLuong);
            GiaoDienC6.Nut(btnThemHDV, "Thêm", 810, 435);
            GiaoDienC6.Bang(dgvDTQ, 12, 12, 940, 310);
            GiaoDienC6.O(tabDTQ, "Mã điểm TQ:", txtDTQMa, 12, 340, 100, 160);
            GiaoDienC6.O(tabDTQ, "Tên điểm TQ:", txtDTQTen, 315, 340, 100, 350);
            GiaoDienC6.O(tabDTQ, "Địa điểm:", txtDTQDiaDiem, 12, 380, 100, 650);
            GiaoDienC6.O(tabDTQ, "Nội dung:", txtDTQNoiDung, 12, 420, 100, 650);
            GiaoDienC6.O(tabDTQ, "Ý nghĩa:", txtDTQYNghia, 12, 460, 100, 650);
            GiaoDienC6.Nut(btnThemDTQ, "Thêm", 810, 455);
            GiaoDienC6.Xong(this, btnDong);
        }
    }

    public partial class FrmTour
    {
        private void HoanThienGiaoDien()
        {
            GiaoDienC6.ChuanBi(this, "Tour - hành trình");
            GiaoDienC6.O(this, "Tour đang chọn (cho các tab hành trình):", cboTour, 12, 15, 270, 420);
            GiaoDienC6.Tab(tabTour, 12, 52, 976, 574);
            tabTourThongTin.Text = "Tour"; tabPhuongTien.Text = "Phương tiện theo chặng";
            GiaoDienC6.Bang(dgvTour, 12, 12, 940, 330);
            GiaoDienC6.O(tabTourThongTin, "Mã tour:", txtMa, 12, 360, 90, 160);
            GiaoDienC6.O(tabTourThongTin, "Tên tour:", txtTen, 300, 360, 85, 370);
            GiaoDienC6.O(tabTourThongTin, "Số ngày:", numNgay, 12, 402, 90, 85);
            GiaoDienC6.O(tabTourThongTin, "Số đêm:", numDem, 235, 402, 80, 85);
            GiaoDienC6.O(tabTourThongTin, "Đơn giá / khách:", numGia, 445, 402, 110, 200);
            GiaoDienC6.Tien(numGia);
            GiaoDienC6.O(tabTourThongTin, "Mô tả:", txtMoTa, 12, 444, 90, 653);
            GiaoDienC6.Nut(btnThemTour, "Thêm tour", 810, 438);
            GiaoDienC6.Bang(dgvDiemDung, 12, 12, 940, 330);
            GiaoDienC6.O(tabDiemDung, "Thứ tự:", numThuTu, 12, 360, 90, 85);
            GiaoDienC6.O(tabDiemDung, "Tên điểm dừng:", txtDiemDung, 215, 360, 120, 420);
            chkDoiPT.Text = "Đổi phương tiện"; chkAn.Text = "Có ăn uống"; chkKS.Text = "Có khách sạn";
            GiaoDienC6.Dat(chkDoiPT, 12, 398, 155);
            GiaoDienC6.Dat(chkAn, 185, 398, 120);
            GiaoDienC6.Dat(chkKS, 320, 398, 140);
            GiaoDienC6.O(tabDiemDung, "Hạng sao:", numSao, 490, 398, 90, 80);
            numSao.Enabled = chkKS.Checked;
            GiaoDienC6.O(tabDiemDung, "Ghi chú:", txtGhiChuDD, 12, 444, 90, 653);
            GiaoDienC6.Nut(btnThemDD, "Thêm điểm dừng", 795, 438, 145);
            GiaoDienC6.Bang(dgvChang, 12, 12, 940, 330);
            GiaoDienC6.O(tabPhuongTien, "Chặng thứ:", numChang, 12, 360, 90, 85);
            GiaoDienC6.O(tabPhuongTien, "Phương tiện:", cboPT, 225, 360, 100, 350);
            GiaoDienC6.O(tabPhuongTien, "Ghi chú:", txtGhiChuPT, 12, 402, 90, 653);
            GiaoDienC6.Nut(btnThemChang, "Gán phương tiện", 795, 397, 145);
            GiaoDienC6.Nhan(tabPhuongTien, "Chặng là đoạn di chuyển nối các điểm dừng của hành trình.", 12, 446, 740);
            GiaoDienC6.Bang(dgvTQ, 12, 12, 940, 330);
            GiaoDienC6.O(tabDiemTQ, "Điểm tham quan:", cboDTQ, 12, 360, 120, 350);
            GiaoDienC6.O(tabDiemTQ, "Thứ tự:", numThuTuTQ, 515, 360, 75, 85);
            GiaoDienC6.Nut(btnThemTQ, "Gán điểm TQ", 795, 355, 145);
            GiaoDienC6.Xong(this, btnDong);
        }
    }

    public partial class FrmChuyenLe
    {
        private void HoanThienGiaoDien()
        {
            GiaoDienC6.ChuanBi(this, "Lịch chuyến khách lẻ");
            GiaoDienC6.O(this, "Mã chuyến:", txtMa, 12, 18, 100, 160);
            GiaoDienC6.O(this, "Tour:", cboTour, 310, 18, 60, 580);
            GiaoDienC6.O(this, "Ngày đi:", dtDi, 12, 58, 100, 160);
            GiaoDienC6.Nhan(this, "Ngày về:", 310, 58, 80);
            GiaoDienC6.Dat(lblNgayVe, 390, 58, 220);
            GiaoDienC6.O(this, "Địa điểm đón:", txtDon, 12, 98, 100, 550);
            GiaoDienC6.Nut(btnThem, "Tạo chuyến", 688, 93);
            GiaoDienC6.Nut(btnDongDK, "Đóng đăng ký", 828, 93, 140);
            GiaoDienC6.Bang(dgv, 12, 148, 976, 478);
            dgv.Anchor = GiaoDienC6.BonCanh;
            GiaoDienC6.Xong(this, btnDong);
        }
    }

    public partial class FrmDangKyLe
    {
        private void HoanThienGiaoDien()
        {
            GiaoDienC6.ChuanBi(this, "Đăng ký khách lẻ theo chuyến");
            GiaoDienC6.O(this, "Số đăng ký:", txtSo, 12, 18, 110, 160);
            GiaoDienC6.O(this, "Chuyến:", cboChuyen, 320, 18, 70, 580);
            GiaoDienC6.O(this, "Điểm bán vé:", cboDiemBan, 12, 58, 110, 190);
            GiaoDienC6.O(this, "Người đăng ký:", txtTen, 335, 58, 105, 220);
            GiaoDienC6.O(this, "Điện thoại:", txtDT, 690, 58, 80, 200);
            GiaoDienC6.O(this, "Số người:", numNguoi, 12, 98, 110, 80);
            GiaoDienC6.Nhan(this, "Thành tiền:", 255, 98, 100);
            GiaoDienC6.Dat(lblThanhTien, 355, 98, 220); GiaoDienC6.KetQua(lblThanhTien);
            GiaoDienC6.Nut(btnDangKy, "Đăng ký và thanh toán vé", 735, 93, 235);
            GiaoDienC6.Bang(dgv, 12, 148, 976, 478);
            dgv.Anchor = GiaoDienC6.BonCanh;
            GiaoDienC6.Xong(this, btnDong);
        }
    }

    public partial class FrmDangKyDoan
    {
        private void HoanThienGiaoDien()
        {
            GiaoDienC6.ChuanBi(this, "Phiếu đăng ký theo đoàn", 1000, 720);
            GiaoDienC6.Dat(grpDoan, 12, 12, 450, 220); grpDoan.Text = "Thông tin đoàn khách";
            GiaoDienC6.Dat(grpDangKy, 474, 12, 514, 220); grpDangKy.Text = "Đăng ký tour";
            GiaoDienC6.O(grpDoan, "Mã đoàn:", txtMaDoan, 12, 28, 115, 300);
            GiaoDienC6.O(grpDoan, "Cơ quan / gia đình:", txtTenCQ, 12, 65, 115, 300);
            GiaoDienC6.O(grpDoan, "Địa chỉ:", txtDiaChi, 12, 102, 115, 300);
            GiaoDienC6.O(grpDoan, "Điện thoại:", txtDT, 12, 139, 115, 300);
            GiaoDienC6.O(grpDoan, "Người đại diện:", txtDaiDien, 12, 176, 115, 300);
            GiaoDienC6.O(grpDangKy, "Số phiếu:", txtSo, 12, 28, 95, 115);
            GiaoDienC6.O(grpDangKy, "Tour:", cboTour, 235, 28, 45, 220);
            GiaoDienC6.O(grpDangKy, "Ngày đi:", dtDi, 12, 65, 95, 115);
            GiaoDienC6.O(grpDangKy, "Số người:", numNguoi, 235, 65, 80, 100);
            GiaoDienC6.O(grpDangKy, "Điểm đón:", txtDon, 12, 102, 95, 393);
            GiaoDienC6.O(grpDangKy, "Tiền cọc:", numCoc, 12, 139, 95, 165); GiaoDienC6.Tien(numCoc);
            chkBH.Text = "Mua bảo hiểm"; GiaoDienC6.Dat(chkBH, 300, 139, 180);
            GiaoDienC6.Nhan(grpDangKy, "Kết thúc:", 12, 176, 70); GiaoDienC6.Dat(lblKetThuc, 82, 176, 135);
            GiaoDienC6.Nhan(grpDangKy, "Tổng tiền:", 235, 176, 75); GiaoDienC6.Dat(lblTong, 310, 176, 190); GiaoDienC6.KetQua(lblTong);
            GiaoDienC6.Nhan(this, "Danh sách người đi (bắt buộc khi mua bảo hiểm)", 12, 239, 600);
            GiaoDienC6.Bang(dgvThanhVien, 12, 268, 976, 160);
            dgvThanhVien.ReadOnly = false;
            dgvThanhVien.AllowUserToAddRows = true; dgvThanhVien.AllowUserToDeleteRows = true;
            dgvThanhVien.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvThanhVien.Enabled = chkBH.Checked;
            GiaoDienC6.Nut(btnDangKy, "Lập phiếu đăng ký", 655, 440, 155);
            GiaoDienC6.Nut(btnHuy, "Hủy phiếu (mất cọc)", 822, 440, 166);
            GiaoDienC6.Nhan(this, "Các phiếu đăng ký đoàn", 12, 470, 500);
            GiaoDienC6.Bang(dgv, 12, 500, 976, 166); dgv.Anchor = GiaoDienC6.BonCanh;
            GiaoDienC6.Xong(this, btnDong);
        }
    }

    public partial class FrmPhanCongHDV
    {
        private void HoanThienGiaoDien()
        {
            GiaoDienC6.ChuanBi(this, "Phân công hướng dẫn viên");
            GiaoDienC6.O(this, "Mã phân công:", txtMaPC, 12, 18, 115, 160);
            GiaoDienC6.O(this, "Hướng dẫn viên:", cboHDV, 330, 18, 115, 390);
            GiaoDienC6.O(this, "Loại:", cboLoai, 12, 58, 115, 160);
            GiaoDienC6.O(this, "Chuyến / đoàn:", cboDoiTuong, 330, 58, 115, 525);
            GiaoDienC6.O(this, "Thù lao tour:", numThuLao, 12, 98, 115, 160); GiaoDienC6.Tien(numThuLao);
            GiaoDienC6.Nhan(this, "Chọn LE cho chuyến khách lẻ hoặc DOAN cho phiếu đoàn.", 330, 98, 475);
            GiaoDienC6.Nut(btnPhanCong, "Phân công", 850, 93);
            GiaoDienC6.Bang(dgv, 12, 148, 976, 478); dgv.Anchor = GiaoDienC6.BonCanh;
            GiaoDienC6.Xong(this, btnDong);
        }
    }

    public partial class FrmKetThucKhaoSat
    {
        private void HoanThienGiaoDien()
        {
            GiaoDienC6.ChuanBi(this, "Kết thúc tour - thanh toán đoàn - khảo sát");
            GiaoDienC6.Tab(tabKT, 12, 12, 976, 614);
            GiaoDienC6.Bang(dgvDoan, 12, 12, 940, 385);
            GiaoDienC6.O(tabPage1, "Số thanh toán:", txtSoTT, 12, 416, 110, 140);
            GiaoDienC6.O(tabPage1, "Phiếu đoàn:", txtSoDK, 290, 416, 90, 140);
            GiaoDienC6.O(tabPage1, "Ngày thanh toán:", dtTT, 550, 416, 115, 160);
            GiaoDienC6.O(tabPage1, "Số tiền:", numTien, 12, 460, 110, 170); GiaoDienC6.Tien(numTien);
            GiaoDienC6.O(tabPage1, "Ghi chú:", txtGhiChu, 310, 460, 70, 360);
            GiaoDienC6.Nut(btnThanhToan, "Ghi nhận thanh toán", 770, 455, 182);
            GiaoDienC6.O(tabPage2, "Loại khách:", cboLoaiKS, 12, 18, 85, 90);
            GiaoDienC6.O(tabPage2, "Đăng ký đã kết thúc:", cboDangKy, 205, 18, 135, 350);
            GiaoDienC6.O(tabPage2, "Mã KS:", txtMaKS, 715, 18, 60, 177);
            GiaoDienC6.O(tabPage2, "Ngày gửi:", dtGui, 12, 58, 85, 160);
            GiaoDienC6.Nut(btnGui, "Gửi phiếu khảo sát", 770, 53, 182);
            GiaoDienC6.Bang(dgvKS, 12, 108, 940, 310);
            GiaoDienC6.O(tabPage2, "Phiếu chọn:", txtKSChon, 12, 435, 85, 160);
            GiaoDienC6.O(tabPage2, "Ngày phản hồi:", dtPH, 290, 435, 105, 160);
            GiaoDienC6.O(tabPage2, "Điểm (1–5):", numDiem, 590, 435, 90, 75);
            GiaoDienC6.O(tabPage2, "Góp ý:", txtGopY, 12, 477, 85, 643);
            GiaoDienC6.Nut(btnGhiPH, "Ghi nhận góp ý", 770, 472, 182);
            GiaoDienC6.Xong(this, btnDong);
        }
    }

    public partial class FrmLuongThongKe
    {
        private void HoanThienGiaoDien()
        {
            GiaoDienC6.ChuanBi(this, "Lương hướng dẫn viên - thống kê");
            GiaoDienC6.Tab(tabTK, 12, 12, 976, 614);
            GiaoDienC6.O(tabPage1, "Tháng:", numThang, 12, 18, 65, 70);
            GiaoDienC6.O(tabPage1, "Năm:", numNam, 170, 18, 50, 100);
            GiaoDienC6.Nut(btnLuong, "Tính lương", 350, 13, 130);
            GiaoDienC6.Nhan(tabPage1, "Lương = lương cơ bản + thù lao các tour kết thúc trong tháng", 500, 18, 450);
            GiaoDienC6.Bang(dgvLuong, 12, 65, 940, 505); dgvLuong.Anchor = GiaoDienC6.BonCanh;
            GiaoDienC6.O(tabPage2, "Từ ngày:", dtTu, 12, 18, 75, 160);
            GiaoDienC6.O(tabPage2, "Đến ngày:", dtDen, 285, 18, 80, 160);
            GiaoDienC6.Nut(btnTongHop, "Thống kê tổng hợp", 570, 13, 170);
            GiaoDienC6.Bang(dgvTongHop, 12, 65, 940, 505); dgvTongHop.Anchor = GiaoDienC6.BonCanh;
            GiaoDienC6.Xong(this, btnDong);
        }
    }
}
