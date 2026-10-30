namespace QuanLyChoThueVanPhong.Forms
{
    partial class FrmHopDongThue
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.grpLapHD = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLapHopDong = new System.Windows.Forms.Button();
            this.lblTraTruoc6Thang = new System.Windows.Forms.Label();
            this.lblTongTienThang = new System.Windows.Forms.Label();
            this.lblTongDienTich = new System.Windows.Forms.Label();
            this.btnXoaPhong = new System.Windows.Forms.Button();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.dgvPhongChon = new System.Windows.Forms.DataGridView();
            this.cboPhongTrong = new System.Windows.Forms.ComboBox();
            this.lblChonPhong = new System.Windows.Forms.Label();
            this.numDatCoc = new System.Windows.Forms.NumericUpDown();
            this.lblDatCoc = new System.Windows.Forms.Label();
            this.numThoiHan = new System.Windows.Forms.NumericUpDown();
            this.lblThoiHan = new System.Windows.Forms.Label();
            this.dtpNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.lblNgayBatDau = new System.Windows.Forms.Label();
            this.dtpNgayKy = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKy = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.splMid = new System.Windows.Forms.SplitContainer();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvHopDong = new System.Windows.Forms.DataGridView();
            this.tabChiTiet = new System.Windows.Forms.TabControl();
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.dgvChiTietPhong = new System.Windows.Forms.DataGridView();
            this.tabLichTT = new System.Windows.Forms.TabPage();
            this.dgvLichThanhToan = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpLapHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDatCoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiHan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMid)).BeginInit();
            this.splMid.Panel1.SuspendLayout();
            this.splMid.Panel2.SuspendLayout();
            this.splMid.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).BeginInit();
            this.tabChiTiet.SuspendLayout();
            this.tabPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhong)).BeginInit();
            this.tabLichTT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpLapHD);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(8);
            this.pnlTop.Size = new System.Drawing.Size(1084, 250);
            this.pnlTop.TabIndex = 0;
            // 
            // grpLapHD
            // 
            this.grpLapHD.Controls.Add(this.btnLamMoi);
            this.grpLapHD.Controls.Add(this.btnLapHopDong);
            this.grpLapHD.Controls.Add(this.lblTraTruoc6Thang);
            this.grpLapHD.Controls.Add(this.lblTongTienThang);
            this.grpLapHD.Controls.Add(this.lblTongDienTich);
            this.grpLapHD.Controls.Add(this.btnXoaPhong);
            this.grpLapHD.Controls.Add(this.btnThemPhong);
            this.grpLapHD.Controls.Add(this.dgvPhongChon);
            this.grpLapHD.Controls.Add(this.cboPhongTrong);
            this.grpLapHD.Controls.Add(this.lblChonPhong);
            this.grpLapHD.Controls.Add(this.numDatCoc);
            this.grpLapHD.Controls.Add(this.lblDatCoc);
            this.grpLapHD.Controls.Add(this.numThoiHan);
            this.grpLapHD.Controls.Add(this.lblThoiHan);
            this.grpLapHD.Controls.Add(this.dtpNgayBatDau);
            this.grpLapHD.Controls.Add(this.lblNgayBatDau);
            this.grpLapHD.Controls.Add(this.dtpNgayKy);
            this.grpLapHD.Controls.Add(this.lblNgayKy);
            this.grpLapHD.Controls.Add(this.cboKhachHang);
            this.grpLapHD.Controls.Add(this.lblKhachHang);
            this.grpLapHD.Controls.Add(this.txtMaHD);
            this.grpLapHD.Controls.Add(this.lblMaHD);
            this.grpLapHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLapHD.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLapHD.Location = new System.Drawing.Point(8, 8);
            this.grpLapHD.Name = "grpLapHD";
            this.grpLapHD.Size = new System.Drawing.Size(1068, 234);
            this.grpLapHD.TabIndex = 0;
            this.grpLapHD.TabStop = false;
            this.grpLapHD.Text = "Lập Hợp Đồng Thuê Văn Phòng Mới (Tối thiểu 6 tháng, thanh toán trước 6 tháng đầu)";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Location = new System.Drawing.Point(920, 192);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(130, 32);
            this.btnLamMoi.TabIndex = 21;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnLapHopDong
            // 
            this.btnLapHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLapHopDong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapHopDong.ForeColor = System.Drawing.Color.White;
            this.btnLapHopDong.Location = new System.Drawing.Point(740, 192);
            this.btnLapHopDong.Name = "btnLapHopDong";
            this.btnLapHopDong.Size = new System.Drawing.Size(170, 32);
            this.btnLapHopDong.TabIndex = 20;
            this.btnLapHopDong.Text = "Lập Hợp Đồng (F2)";
            this.btnLapHopDong.UseVisualStyleBackColor = false;
            this.btnLapHopDong.Click += new System.EventHandler(this.btnLapHopDong_Click);
            // 
            // lblTraTruoc6Thang
            // 
            this.lblTraTruoc6Thang.AutoSize = true;
            this.lblTraTruoc6Thang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraTruoc6Thang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTraTruoc6Thang.Location = new System.Drawing.Point(460, 200);
            this.lblTraTruoc6Thang.Name = "lblTraTruoc6Thang";
            this.lblTraTruoc6Thang.Size = new System.Drawing.Size(149, 17);
            this.lblTraTruoc6Thang.TabIndex = 19;
            this.lblTraTruoc6Thang.Text = "Trả trước 6 tháng: 0 đ";
            // 
            // lblTongTienThang
            // 
            this.lblTongTienThang.AutoSize = true;
            this.lblTongTienThang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienThang.ForeColor = System.Drawing.Color.Green;
            this.lblTongTienThang.Location = new System.Drawing.Point(230, 200);
            this.lblTongTienThang.Name = "lblTongTienThang";
            this.lblTongTienThang.Size = new System.Drawing.Size(117, 15);
            this.lblTongTienThang.TabIndex = 18;
            this.lblTongTienThang.Text = "Tiền/tháng: 0 đ";
            // 
            // lblTongDienTich
            // 
            this.lblTongDienTich.AutoSize = true;
            this.lblTongDienTich.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDienTich.Location = new System.Drawing.Point(16, 200);
            this.lblTongDienTich.Name = "lblTongDienTich";
            this.lblTongDienTich.Size = new System.Drawing.Size(117, 15);
            this.lblTongDienTich.TabIndex = 17;
            this.lblTongDienTich.Text = "Tổng DT: 0.0 m²";
            // 
            // btnXoaPhong
            // 
            this.btnXoaPhong.Location = new System.Drawing.Point(965, 23);
            this.btnXoaPhong.Name = "btnXoaPhong";
            this.btnXoaPhong.Size = new System.Drawing.Size(85, 25);
            this.btnXoaPhong.TabIndex = 16;
            this.btnXoaPhong.Text = "Bỏ chọn";
            this.btnXoaPhong.UseVisualStyleBackColor = true;
            this.btnXoaPhong.Click += new System.EventHandler(this.btnXoaPhong_Click);
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(865, 23);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(95, 25);
            this.btnThemPhong.TabIndex = 15;
            this.btnThemPhong.Text = "+ Chọn thuê";
            this.btnThemPhong.UseVisualStyleBackColor = true;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // dgvPhongChon
            // 
            this.dgvPhongChon.AllowUserToAddRows = false;
            this.dgvPhongChon.AllowUserToDeleteRows = false;
            this.dgvPhongChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhongChon.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhongChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongChon.Location = new System.Drawing.Point(540, 55);
            this.dgvPhongChon.MultiSelect = false;
            this.dgvPhongChon.Name = "dgvPhongChon";
            this.dgvPhongChon.ReadOnly = true;
            this.dgvPhongChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhongChon.Size = new System.Drawing.Size(510, 125);
            this.dgvPhongChon.TabIndex = 14;
            // 
            // cboPhongTrong
            // 
            this.cboPhongTrong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongTrong.FormattingEnabled = true;
            this.cboPhongTrong.Location = new System.Drawing.Point(625, 24);
            this.cboPhongTrong.Name = "cboPhongTrong";
            this.cboPhongTrong.Size = new System.Drawing.Size(230, 23);
            this.cboPhongTrong.TabIndex = 13;
            // 
            // lblChonPhong
            // 
            this.lblChonPhong.AutoSize = true;
            this.lblChonPhong.Location = new System.Drawing.Point(537, 27);
            this.lblChonPhong.Name = "lblChonPhong";
            this.lblChonPhong.Size = new System.Drawing.Size(81, 15);
            this.lblChonPhong.TabIndex = 12;
            this.lblChonPhong.Text = "Phòng trống:";
            // 
            // numDatCoc
            // 
            this.numDatCoc.DecimalPlaces = 0;
            this.numDatCoc.Increment = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numDatCoc.Location = new System.Drawing.Point(365, 95);
            this.numDatCoc.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numDatCoc.Name = "numDatCoc";
            this.numDatCoc.Size = new System.Drawing.Size(150, 23);
            this.numDatCoc.TabIndex = 11;
            this.numDatCoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDatCoc.ThousandsSeparator = true;
            // 
            // lblDatCoc
            // 
            this.lblDatCoc.AutoSize = true;
            this.lblDatCoc.Location = new System.Drawing.Point(280, 97);
            this.lblDatCoc.Name = "lblDatCoc";
            this.lblDatCoc.Size = new System.Drawing.Size(76, 15);
            this.lblDatCoc.TabIndex = 10;
            this.lblDatCoc.Text = "Tiền đặt cọc:";
            // 
            // numThoiHan
            // 
            this.numThoiHan.Location = new System.Drawing.Point(100, 95);
            this.numThoiHan.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.numThoiHan.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            this.numThoiHan.Name = "numThoiHan";
            this.numThoiHan.Size = new System.Drawing.Size(160, 23);
            this.numThoiHan.TabIndex = 9;
            this.numThoiHan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numThoiHan.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // lblThoiHan
            // 
            this.lblThoiHan.AutoSize = true;
            this.lblThoiHan.Location = new System.Drawing.Point(16, 97);
            this.lblThoiHan.Name = "lblThoiHan";
            this.lblThoiHan.Size = new System.Drawing.Size(84, 15);
            this.lblThoiHan.TabIndex = 8;
            this.lblThoiHan.Text = "Thời hạn (th):";
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(365, 59);
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.Size = new System.Drawing.Size(150, 23);
            this.dtpNgayBatDau.TabIndex = 7;
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.AutoSize = true;
            this.lblNgayBatDau.Location = new System.Drawing.Point(280, 63);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(81, 15);
            this.lblNgayBatDau.TabIndex = 6;
            this.lblNgayBatDau.Text = "Ngày bắt đầu:";
            // 
            // dtpNgayKy
            // 
            this.dtpNgayKy.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKy.Location = new System.Drawing.Point(100, 59);
            this.dtpNgayKy.Name = "dtpNgayKy";
            this.dtpNgayKy.Size = new System.Drawing.Size(160, 23);
            this.dtpNgayKy.TabIndex = 5;
            // 
            // lblNgayKy
            // 
            this.lblNgayKy.AutoSize = true;
            this.lblNgayKy.Location = new System.Drawing.Point(16, 63);
            this.lblNgayKy.Name = "lblNgayKy";
            this.lblNgayKy.Size = new System.Drawing.Size(54, 15);
            this.lblNgayKy.TabIndex = 4;
            this.lblNgayKy.Text = "Ngày ký:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(365, 24);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(150, 23);
            this.cboKhachHang.TabIndex = 3;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(280, 27);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(73, 15);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(100, 24);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(160, 23);
            this.txtMaHD.TabIndex = 1;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(16, 27);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(47, 15);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã HĐ:";
            // 
            // splMid
            // 
            this.splMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMid.Location = new System.Drawing.Point(0, 250);
            this.splMid.Name = "splMid";
            // 
            // splMid.Panel1
            // 
            this.splMid.Panel1.Controls.Add(this.grpDanhSach);
            this.splMid.Panel1.Padding = new System.Windows.Forms.Padding(8);
            // 
            // splMid.Panel2
            // 
            this.splMid.Panel2.Controls.Add(this.tabChiTiet);
            this.splMid.Panel2.Padding = new System.Windows.Forms.Padding(8);
            this.splMid.Size = new System.Drawing.Size(1084, 380);
            this.splMid.SplitterDistance = 530;
            this.splMid.TabIndex = 1;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvHopDong);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSach.Location = new System.Drawing.Point(8, 8);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(514, 364);
            this.grpDanhSach.TabIndex = 0;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh Sách Hợp Đồng Thuê";
            // 
            // dgvHopDong
            // 
            this.dgvHopDong.AllowUserToAddRows = false;
            this.dgvHopDong.AllowUserToDeleteRows = false;
            this.dgvHopDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHopDong.BackgroundColor = System.Drawing.Color.White;
            this.dgvHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHopDong.Location = new System.Drawing.Point(3, 19);
            this.dgvHopDong.MultiSelect = false;
            this.dgvHopDong.Name = "dgvHopDong";
            this.dgvHopDong.ReadOnly = true;
            this.dgvHopDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHopDong.Size = new System.Drawing.Size(508, 342);
            this.dgvHopDong.TabIndex = 0;
            this.dgvHopDong.SelectionChanged += new System.EventHandler(this.dgvHopDong_SelectionChanged);
            // 
            // tabChiTiet
            // 
            this.tabChiTiet.Controls.Add(this.tabPhong);
            this.tabChiTiet.Controls.Add(this.tabLichTT);
            this.tabChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChiTiet.Location = new System.Drawing.Point(8, 8);
            this.tabChiTiet.Name = "tabChiTiet";
            this.tabChiTiet.SelectedIndex = 0;
            this.tabChiTiet.Size = new System.Drawing.Size(534, 364);
            this.tabChiTiet.TabIndex = 0;
            // 
            // tabPhong
            // 
            this.tabPhong.Controls.Add(this.dgvChiTietPhong);
            this.tabPhong.Location = new System.Drawing.Point(4, 24);
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhong.Size = new System.Drawing.Size(526, 336);
            this.tabPhong.TabIndex = 0;
            this.tabPhong.Text = "Chi Tiết Phòng Thuê";
            this.tabPhong.UseVisualStyleBackColor = true;
            // 
            // dgvChiTietPhong
            // 
            this.dgvChiTietPhong.AllowUserToAddRows = false;
            this.dgvChiTietPhong.AllowUserToDeleteRows = false;
            this.dgvChiTietPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhong.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPhong.Location = new System.Drawing.Point(3, 3);
            this.dgvChiTietPhong.MultiSelect = false;
            this.dgvChiTietPhong.Name = "dgvChiTietPhong";
            this.dgvChiTietPhong.ReadOnly = true;
            this.dgvChiTietPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietPhong.Size = new System.Drawing.Size(520, 330);
            this.dgvChiTietPhong.TabIndex = 0;
            // 
            // tabLichTT
            // 
            this.tabLichTT.Controls.Add(this.dgvLichThanhToan);
            this.tabLichTT.Location = new System.Drawing.Point(4, 24);
            this.tabLichTT.Name = "tabLichTT";
            this.tabLichTT.Padding = new System.Windows.Forms.Padding(3);
            this.tabLichTT.Size = new System.Drawing.Size(526, 336);
            this.tabLichTT.TabIndex = 1;
            this.tabLichTT.Text = "Lịch Thanh Toán Tiền Thuê";
            this.tabLichTT.UseVisualStyleBackColor = true;
            // 
            // dgvLichThanhToan
            // 
            this.dgvLichThanhToan.AllowUserToAddRows = false;
            this.dgvLichThanhToan.AllowUserToDeleteRows = false;
            this.dgvLichThanhToan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichThanhToan.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichThanhToan.Location = new System.Drawing.Point(3, 3);
            this.dgvLichThanhToan.MultiSelect = false;
            this.dgvLichThanhToan.Name = "dgvLichThanhToan";
            this.dgvLichThanhToan.ReadOnly = true;
            this.dgvLichThanhToan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichThanhToan.Size = new System.Drawing.Size(520, 330);
            this.dgvLichThanhToan.TabIndex = 0;
            // 
            // FrmHopDongThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 630);
            this.Controls.Add(this.splMid);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "FrmHopDongThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Hợp Đồng Cho Thuê Văn Phòng";
            this.pnlTop.ResumeLayout(false);
            this.grpLapHD.ResumeLayout(false);
            this.grpLapHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDatCoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThoiHan)).EndInit();
            this.splMid.Panel1.ResumeLayout(false);
            this.splMid.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMid)).EndInit();
            this.splMid.ResumeLayout(false);
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHopDong)).EndInit();
            this.tabChiTiet.ResumeLayout(false);
            this.tabPhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhong)).EndInit();
            this.tabLichTT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichThanhToan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox grpLapHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.DateTimePicker dtpNgayKy;
        private System.Windows.Forms.Label lblNgayKy;
        private System.Windows.Forms.DateTimePicker dtpNgayBatDau;
        private System.Windows.Forms.Label lblNgayBatDau;
        private System.Windows.Forms.NumericUpDown numThoiHan;
        private System.Windows.Forms.Label lblThoiHan;
        private System.Windows.Forms.NumericUpDown numDatCoc;
        private System.Windows.Forms.Label lblDatCoc;
        private System.Windows.Forms.ComboBox cboPhongTrong;
        private System.Windows.Forms.Label lblChonPhong;
        private System.Windows.Forms.DataGridView dgvPhongChon;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.Button btnXoaPhong;
        private System.Windows.Forms.Label lblTongDienTich;
        private System.Windows.Forms.Label lblTongTienThang;
        private System.Windows.Forms.Label lblTraTruoc6Thang;
        private System.Windows.Forms.Button btnLapHopDong;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.SplitContainer splMid;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvHopDong;
        private System.Windows.Forms.TabControl tabChiTiet;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.DataGridView dgvChiTietPhong;
        private System.Windows.Forms.TabPage tabLichTT;
        private System.Windows.Forms.DataGridView dgvLichThanhToan;
    }
}
