namespace QuanLyBenhAn.Forms
{
    partial class FrmDangKyHoSo
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDangKyMoi = new System.Windows.Forms.TabPage();
            this.dgvBenhNhan = new System.Windows.Forms.DataGridView();
            this.grpDangKy = new System.Windows.Forms.GroupBox();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.numTienLePhi = new System.Windows.Forms.NumericUpDown();
            this.lblTienLePhi = new System.Windows.Forms.Label();
            this.numNamLePhi = new System.Windows.Forms.NumericUpDown();
            this.lblNamLePhi = new System.Windows.Forms.Label();
            this.txtTienSuDiUng = new System.Windows.Forms.TextBox();
            this.lblTienSuDiUng = new System.Windows.Forms.Label();
            this.txtMaHoSo = new System.Windows.Forms.TextBox();
            this.lblMaHoSo = new System.Windows.Forms.Label();
            this.txtGhiChuPDK = new System.Windows.Forms.TextBox();
            this.lblGhiChuPDK = new System.Windows.Forms.Label();
            this.txtMaPDK = new System.Windows.Forms.TextBox();
            this.lblMaPDK = new System.Windows.Forms.Label();
            this.txtAnh = new System.Windows.Forms.TextBox();
            this.lblAnh = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtMaBN = new System.Windows.Forms.TextBox();
            this.lblMaBN = new System.Windows.Forms.Label();
            this.tabDanhSachHoSo = new System.Windows.Forms.TabPage();
            this.dgvLePhi = new System.Windows.Forms.DataGridView();
            this.lblLePhiTitle = new System.Windows.Forms.Label();
            this.pnlGiaHan = new System.Windows.Forms.Panel();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.txtGiaHanGhiChu = new System.Windows.Forms.TextBox();
            this.lblGiaHanGhiChu = new System.Windows.Forms.Label();
            this.numGiaHanTien = new System.Windows.Forms.NumericUpDown();
            this.lblGiaHanTien = new System.Windows.Forms.Label();
            this.numGiaHanNam = new System.Windows.Forms.NumericUpDown();
            this.lblGiaHanNam = new System.Windows.Forms.Label();
            this.txtGiaHanHoSo = new System.Windows.Forms.TextBox();
            this.lblGiaHanHoSo = new System.Windows.Forms.Label();
            this.dgvHoSo = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabDangKyMoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBenhNhan)).BeginInit();
            this.grpDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienLePhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNamLePhi)).BeginInit();
            this.tabDanhSachHoSo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLePhi)).BeginInit();
            this.pnlGiaHan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaHanTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaHanNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDangKyMoi);
            this.tabMain.Controls.Add(this.tabDanhSachHoSo);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(984, 610);
            this.tabMain.TabIndex = 0;
            // 
            // tabDangKyMoi
            // 
            this.tabDangKyMoi.Controls.Add(this.dgvBenhNhan);
            this.tabDangKyMoi.Controls.Add(this.grpDangKy);
            this.tabDangKyMoi.Location = new System.Drawing.Point(4, 25);
            this.tabDangKyMoi.Name = "tabDangKyMoi";
            this.tabDangKyMoi.Padding = new System.Windows.Forms.Padding(3);
            this.tabDangKyMoi.Size = new System.Drawing.Size(976, 581);
            this.tabDangKyMoi.TabIndex = 0;
            this.tabDangKyMoi.Text = "Đăng ký lần đầu & Cấp hồ sơ";
            this.tabDangKyMoi.UseVisualStyleBackColor = true;
            // 
            // dgvBenhNhan
            // 
            this.dgvBenhNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBenhNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBenhNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBenhNhan.Location = new System.Drawing.Point(3, 273);
            this.dgvBenhNhan.Name = "dgvBenhNhan";
            this.dgvBenhNhan.RowHeadersWidth = 51;
            this.dgvBenhNhan.RowTemplate.Height = 24;
            this.dgvBenhNhan.Size = new System.Drawing.Size(970, 305);
            this.dgvBenhNhan.TabIndex = 1;
            // 
            // grpDangKy
            // 
            this.grpDangKy.Controls.Add(this.btnDangKy);
            this.grpDangKy.Controls.Add(this.numTienLePhi);
            this.grpDangKy.Controls.Add(this.lblTienLePhi);
            this.grpDangKy.Controls.Add(this.numNamLePhi);
            this.grpDangKy.Controls.Add(this.lblNamLePhi);
            this.grpDangKy.Controls.Add(this.txtTienSuDiUng);
            this.grpDangKy.Controls.Add(this.lblTienSuDiUng);
            this.grpDangKy.Controls.Add(this.txtMaHoSo);
            this.grpDangKy.Controls.Add(this.lblMaHoSo);
            this.grpDangKy.Controls.Add(this.txtGhiChuPDK);
            this.grpDangKy.Controls.Add(this.lblGhiChuPDK);
            this.grpDangKy.Controls.Add(this.txtMaPDK);
            this.grpDangKy.Controls.Add(this.lblMaPDK);
            this.grpDangKy.Controls.Add(this.txtAnh);
            this.grpDangKy.Controls.Add(this.lblAnh);
            this.grpDangKy.Controls.Add(this.txtSDT);
            this.grpDangKy.Controls.Add(this.lblSDT);
            this.grpDangKy.Controls.Add(this.txtDiaChi);
            this.grpDangKy.Controls.Add(this.lblDiaChi);
            this.grpDangKy.Controls.Add(this.cboGioiTinh);
            this.grpDangKy.Controls.Add(this.lblGioiTinh);
            this.grpDangKy.Controls.Add(this.dtNgaySinh);
            this.grpDangKy.Controls.Add(this.lblNgaySinh);
            this.grpDangKy.Controls.Add(this.txtHoTen);
            this.grpDangKy.Controls.Add(this.lblHoTen);
            this.grpDangKy.Controls.Add(this.txtMaBN);
            this.grpDangKy.Controls.Add(this.lblMaBN);
            this.grpDangKy.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDangKy.Location = new System.Drawing.Point(3, 3);
            this.grpDangKy.Name = "grpDangKy";
            this.grpDangKy.Size = new System.Drawing.Size(970, 270);
            this.grpDangKy.TabIndex = 0;
            this.grpDangKy.TabStop = false;
            this.grpDangKy.Text = "Thông tin đăng ký bệnh nhân mới + Đóng lệ phí 1 năm (Transaction đồng thời)";
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(530, 215);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(420, 42);
            this.btnDangKy.TabIndex = 26;
            this.btnDangKy.Text = "ĐĂNG KÝ VÀ CẤP HỒ SƠ BỆNH ÁN";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // numTienLePhi
            // 
            this.numTienLePhi.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numTienLePhi.Location = new System.Drawing.Point(820, 175);
            this.numTienLePhi.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numTienLePhi.Name = "numTienLePhi";
            this.numTienLePhi.Size = new System.Drawing.Size(130, 22);
            this.numTienLePhi.TabIndex = 25;
            // 
            // lblTienLePhi
            // 
            this.lblTienLePhi.AutoSize = true;
            this.lblTienLePhi.Location = new System.Drawing.Point(735, 178);
            this.lblTienLePhi.Name = "lblTienLePhi";
            this.lblTienLePhi.Size = new System.Drawing.Size(78, 17);
            this.lblTienLePhi.TabIndex = 24;
            this.lblTienLePhi.Text = "Lệ phí năm:";
            // 
            // numNamLePhi
            // 
            this.numNamLePhi.Location = new System.Drawing.Point(620, 175);
            this.numNamLePhi.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            this.numNamLePhi.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numNamLePhi.Name = "numNamLePhi";
            this.numNamLePhi.Size = new System.Drawing.Size(95, 22);
            this.numNamLePhi.TabIndex = 23;
            this.numNamLePhi.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblNamLePhi
            // 
            this.lblNamLePhi.AutoSize = true;
            this.lblNamLePhi.Location = new System.Drawing.Point(525, 178);
            this.lblNamLePhi.Name = "lblNamLePhi";
            this.lblNamLePhi.Size = new System.Drawing.Size(91, 17);
            this.lblNamLePhi.TabIndex = 22;
            this.lblNamLePhi.Text = "Năm thu phí:";
            // 
            // txtTienSuDiUng
            // 
            this.txtTienSuDiUng.Location = new System.Drawing.Point(620, 138);
            this.txtTienSuDiUng.Name = "txtTienSuDiUng";
            this.txtTienSuDiUng.Size = new System.Drawing.Size(330, 22);
            this.txtTienSuDiUng.TabIndex = 21;
            // 
            // lblTienSuDiUng
            // 
            this.lblTienSuDiUng.AutoSize = true;
            this.lblTienSuDiUng.Location = new System.Drawing.Point(525, 141);
            this.lblTienSuDiUng.Name = "lblTienSuDiUng";
            this.lblTienSuDiUng.Size = new System.Drawing.Size(98, 17);
            this.lblTienSuDiUng.TabIndex = 20;
            this.lblTienSuDiUng.Text = "Tiền sử dị ứng:";
            // 
            // txtMaHoSo
            // 
            this.txtMaHoSo.Location = new System.Drawing.Point(620, 102);
            this.txtMaHoSo.Name = "txtMaHoSo";
            this.txtMaHoSo.Size = new System.Drawing.Size(160, 22);
            this.txtMaHoSo.TabIndex = 19;
            // 
            // lblMaHoSo
            // 
            this.lblMaHoSo.AutoSize = true;
            this.lblMaHoSo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHoSo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMaHoSo.Location = new System.Drawing.Point(525, 103);
            this.lblMaHoSo.Name = "lblMaHoSo";
            this.lblMaHoSo.Size = new System.Drawing.Size(77, 20);
            this.lblMaHoSo.TabIndex = 18;
            this.lblMaHoSo.Text = "Mã hồ sơ:";
            // 
            // txtGhiChuPDK
            // 
            this.txtGhiChuPDK.Location = new System.Drawing.Point(620, 65);
            this.txtGhiChuPDK.Name = "txtGhiChuPDK";
            this.txtGhiChuPDK.Size = new System.Drawing.Size(330, 22);
            this.txtGhiChuPDK.TabIndex = 17;
            // 
            // lblGhiChuPDK
            // 
            this.lblGhiChuPDK.AutoSize = true;
            this.lblGhiChuPDK.Location = new System.Drawing.Point(525, 68);
            this.lblGhiChuPDK.Name = "lblGhiChuPDK";
            this.lblGhiChuPDK.Size = new System.Drawing.Size(92, 17);
            this.lblGhiChuPDK.TabIndex = 16;
            this.lblGhiChuPDK.Text = "Ghi chú PDK:";
            // 
            // txtMaPDK
            // 
            this.txtMaPDK.Location = new System.Drawing.Point(620, 28);
            this.txtMaPDK.Name = "txtMaPDK";
            this.txtMaPDK.Size = new System.Drawing.Size(160, 22);
            this.txtMaPDK.TabIndex = 15;
            // 
            // lblMaPDK
            // 
            this.lblMaPDK.AutoSize = true;
            this.lblMaPDK.Location = new System.Drawing.Point(525, 31);
            this.lblMaPDK.Name = "lblMaPDK";
            this.lblMaPDK.Size = new System.Drawing.Size(90, 17);
            this.lblMaPDK.TabIndex = 14;
            this.lblMaPDK.Text = "Mã phiếu ĐK:";
            // 
            // txtAnh
            // 
            this.txtAnh.Location = new System.Drawing.Point(95, 225);
            this.txtAnh.Name = "txtAnh";
            this.txtAnh.Size = new System.Drawing.Size(400, 22);
            this.txtAnh.TabIndex = 13;
            // 
            // lblAnh
            // 
            this.lblAnh.AutoSize = true;
            this.lblAnh.Location = new System.Drawing.Point(15, 228);
            this.lblAnh.Name = "lblAnh";
            this.lblAnh.Size = new System.Drawing.Size(65, 17);
            this.lblAnh.TabIndex = 12;
            this.lblAnh.Text = "Ảnh 3x4:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(340, 185);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(155, 22);
            this.txtSDT.TabIndex = 11;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(265, 188);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(76, 17);
            this.lblSDT.TabIndex = 10;
            this.lblSDT.Text = "Điện thoại:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(95, 145);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(400, 22);
            this.txtDiaChi.TabIndex = 9;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 148);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(55, 17);
            this.lblDiaChi.TabIndex = 8;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(95, 185);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(120, 24);
            this.cboGioiTinh.TabIndex = 7;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(15, 188);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(64, 17);
            this.lblGioiTinh.TabIndex = 6;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgaySinh.Location = new System.Drawing.Point(95, 105);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(160, 22);
            this.dtNgaySinh.TabIndex = 5;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(15, 108);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(75, 17);
            this.lblNgaySinh.TabIndex = 4;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(95, 65);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(260, 22);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 68);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(54, 17);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtMaBN
            // 
            this.txtMaBN.Location = new System.Drawing.Point(95, 25);
            this.txtMaBN.Name = "txtMaBN";
            this.txtMaBN.Size = new System.Drawing.Size(160, 22);
            this.txtMaBN.TabIndex = 1;
            // 
            // lblMaBN
            // 
            this.lblMaBN.AutoSize = true;
            this.lblMaBN.Location = new System.Drawing.Point(15, 28);
            this.lblMaBN.Name = "lblMaBN";
            this.lblMaBN.Size = new System.Drawing.Size(54, 17);
            this.lblMaBN.TabIndex = 0;
            this.lblMaBN.Text = "Mã BN:";
            // 
            // tabDanhSachHoSo
            // 
            this.tabDanhSachHoSo.Controls.Add(this.dgvLePhi);
            this.tabDanhSachHoSo.Controls.Add(this.lblLePhiTitle);
            this.tabDanhSachHoSo.Controls.Add(this.pnlGiaHan);
            this.tabDanhSachHoSo.Controls.Add(this.dgvHoSo);
            this.tabDanhSachHoSo.Location = new System.Drawing.Point(4, 25);
            this.tabDanhSachHoSo.Name = "tabDanhSachHoSo";
            this.tabDanhSachHoSo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDanhSachHoSo.Size = new System.Drawing.Size(976, 581);
            this.tabDanhSachHoSo.TabIndex = 1;
            this.tabDanhSachHoSo.Text = "Danh sách hồ sơ bệnh án & Gia hạn lệ phí";
            this.tabDanhSachHoSo.UseVisualStyleBackColor = true;
            // 
            // dgvLePhi
            // 
            this.dgvLePhi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLePhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLePhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLePhi.Location = new System.Drawing.Point(3, 400);
            this.dgvLePhi.Name = "dgvLePhi";
            this.dgvLePhi.RowHeadersWidth = 51;
            this.dgvLePhi.RowTemplate.Height = 24;
            this.dgvLePhi.Size = new System.Drawing.Size(970, 178);
            this.dgvLePhi.TabIndex = 3;
            // 
            // lblLePhiTitle
            // 
            this.lblLePhiTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLePhiTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLePhiTitle.Location = new System.Drawing.Point(3, 375);
            this.lblLePhiTitle.Name = "lblLePhiTitle";
            this.lblLePhiTitle.Size = new System.Drawing.Size(970, 25);
            this.lblLePhiTitle.TabIndex = 2;
            this.lblLePhiTitle.Text = "Lịch sử các năm đã đóng lệ phí của hồ sơ đang chọn:";
            this.lblLePhiTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlGiaHan
            // 
            this.pnlGiaHan.Controls.Add(this.btnGiaHan);
            this.pnlGiaHan.Controls.Add(this.txtGiaHanGhiChu);
            this.pnlGiaHan.Controls.Add(this.lblGiaHanGhiChu);
            this.pnlGiaHan.Controls.Add(this.numGiaHanTien);
            this.pnlGiaHan.Controls.Add(this.lblGiaHanTien);
            this.pnlGiaHan.Controls.Add(this.numGiaHanNam);
            this.pnlGiaHan.Controls.Add(this.lblGiaHanNam);
            this.pnlGiaHan.Controls.Add(this.txtGiaHanHoSo);
            this.pnlGiaHan.Controls.Add(this.lblGiaHanHoSo);
            this.pnlGiaHan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGiaHan.Location = new System.Drawing.Point(3, 310);
            this.pnlGiaHan.Name = "pnlGiaHan";
            this.pnlGiaHan.Size = new System.Drawing.Size(970, 65);
            this.pnlGiaHan.TabIndex = 1;
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(825, 17);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(130, 32);
            this.btnGiaHan.TabIndex = 8;
            this.btnGiaHan.Text = "Đóng lệ phí năm";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // txtGiaHanGhiChu
            // 
            this.txtGiaHanGhiChu.Location = new System.Drawing.Point(620, 22);
            this.txtGiaHanGhiChu.Name = "txtGiaHanGhiChu";
            this.txtGiaHanGhiChu.Size = new System.Drawing.Size(185, 22);
            this.txtGiaHanGhiChu.TabIndex = 7;
            // 
            // lblGiaHanGhiChu
            // 
            this.lblGiaHanGhiChu.AutoSize = true;
            this.lblGiaHanGhiChu.Location = new System.Drawing.Point(555, 25);
            this.lblGiaHanGhiChu.Name = "lblGiaHanGhiChu";
            this.lblGiaHanGhiChu.Size = new System.Drawing.Size(61, 17);
            this.lblGiaHanGhiChu.TabIndex = 6;
            this.lblGiaHanGhiChu.Text = "Ghi chú:";
            // 
            // numGiaHanTien
            // 
            this.numGiaHanTien.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numGiaHanTien.Location = new System.Drawing.Point(420, 22);
            this.numGiaHanTien.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGiaHanTien.Name = "numGiaHanTien";
            this.numGiaHanTien.Size = new System.Drawing.Size(120, 22);
            this.numGiaHanTien.TabIndex = 5;
            // 
            // lblGiaHanTien
            // 
            this.lblGiaHanTien.AutoSize = true;
            this.lblGiaHanTien.Location = new System.Drawing.Point(360, 25);
            this.lblGiaHanTien.Name = "lblGiaHanTien";
            this.lblGiaHanTien.Size = new System.Drawing.Size(56, 17);
            this.lblGiaHanTien.TabIndex = 4;
            this.lblGiaHanTien.Text = "Số tiền:";
            // 
            // numGiaHanNam
            // 
            this.numGiaHanNam.Location = new System.Drawing.Point(260, 22);
            this.numGiaHanNam.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            this.numGiaHanNam.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numGiaHanNam.Name = "numGiaHanNam";
            this.numGiaHanNam.Size = new System.Drawing.Size(85, 22);
            this.numGiaHanNam.TabIndex = 3;
            this.numGiaHanNam.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblGiaHanNam
            // 
            this.lblGiaHanNam.AutoSize = true;
            this.lblGiaHanNam.Location = new System.Drawing.Point(215, 25);
            this.lblGiaHanNam.Name = "lblGiaHanNam";
            this.lblGiaHanNam.Size = new System.Drawing.Size(41, 17);
            this.lblGiaHanNam.TabIndex = 2;
            this.lblGiaHanNam.Text = "Năm:";
            // 
            // txtGiaHanHoSo
            // 
            this.txtGiaHanHoSo.Location = new System.Drawing.Point(85, 22);
            this.txtGiaHanHoSo.Name = "txtGiaHanHoSo";
            this.txtGiaHanHoSo.ReadOnly = true;
            this.txtGiaHanHoSo.Size = new System.Drawing.Size(115, 22);
            this.txtGiaHanHoSo.TabIndex = 1;
            // 
            // lblGiaHanHoSo
            // 
            this.lblGiaHanHoSo.AutoSize = true;
            this.lblGiaHanHoSo.Location = new System.Drawing.Point(15, 25);
            this.lblGiaHanHoSo.Name = "lblGiaHanHoSo";
            this.lblGiaHanHoSo.Size = new System.Drawing.Size(68, 17);
            this.lblGiaHanHoSo.TabIndex = 0;
            this.lblGiaHanHoSo.Text = "Mã hồ sơ:";
            // 
            // dgvHoSo
            // 
            this.dgvHoSo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoSo.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHoSo.Location = new System.Drawing.Point(3, 3);
            this.dgvHoSo.Name = "dgvHoSo";
            this.dgvHoSo.RowHeadersWidth = 51;
            this.dgvHoSo.RowTemplate.Height = 24;
            this.dgvHoSo.Size = new System.Drawing.Size(970, 307);
            this.dgvHoSo.TabIndex = 0;
            this.dgvHoSo.SelectionChanged += new System.EventHandler(this.dgvHoSo_SelectionChanged);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(860, 620);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDangKyHoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 662);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDangKyHoSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng ký Khám bệnh & Cấp Hồ sơ Bệnh án & Đóng Lệ phí năm";
            this.Load += new System.EventHandler(this.FrmDangKyHoSo_Load);
            this.tabMain.ResumeLayout(false);
            this.tabDangKyMoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBenhNhan)).EndInit();
            this.grpDangKy.ResumeLayout(false);
            this.grpDangKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienLePhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNamLePhi)).EndInit();
            this.tabDanhSachHoSo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLePhi)).EndInit();
            this.pnlGiaHan.ResumeLayout(false);
            this.pnlGiaHan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaHanTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaHanNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDangKyMoi;
        private System.Windows.Forms.TabPage tabDanhSachHoSo;
        private System.Windows.Forms.GroupBox grpDangKy;
        private System.Windows.Forms.Label lblMaBN;
        private System.Windows.Forms.TextBox txtMaBN;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtAnh;
        private System.Windows.Forms.Label lblAnh;
        private System.Windows.Forms.TextBox txtMaPDK;
        private System.Windows.Forms.Label lblMaPDK;
        private System.Windows.Forms.TextBox txtGhiChuPDK;
        private System.Windows.Forms.Label lblGhiChuPDK;
        private System.Windows.Forms.TextBox txtMaHoSo;
        private System.Windows.Forms.Label lblMaHoSo;
        private System.Windows.Forms.TextBox txtTienSuDiUng;
        private System.Windows.Forms.Label lblTienSuDiUng;
        private System.Windows.Forms.NumericUpDown numNamLePhi;
        private System.Windows.Forms.Label lblNamLePhi;
        private System.Windows.Forms.NumericUpDown numTienLePhi;
        private System.Windows.Forms.Label lblTienLePhi;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.DataGridView dgvBenhNhan;
        private System.Windows.Forms.DataGridView dgvHoSo;
        private System.Windows.Forms.Panel pnlGiaHan;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.TextBox txtGiaHanGhiChu;
        private System.Windows.Forms.Label lblGiaHanGhiChu;
        private System.Windows.Forms.NumericUpDown numGiaHanTien;
        private System.Windows.Forms.Label lblGiaHanTien;
        private System.Windows.Forms.NumericUpDown numGiaHanNam;
        private System.Windows.Forms.Label lblGiaHanNam;
        private System.Windows.Forms.TextBox txtGiaHanHoSo;
        private System.Windows.Forms.Label lblGiaHanHoSo;
        private System.Windows.Forms.Label lblLePhiTitle;
        private System.Windows.Forms.DataGridView dgvLePhi;
        private System.Windows.Forms.Button btnDong;
    }
}
