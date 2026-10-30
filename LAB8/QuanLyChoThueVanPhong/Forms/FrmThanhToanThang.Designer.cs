namespace QuanLyChoThueVanPhong.Forms
{
    partial class FrmThanhToanThang
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
            this.tabTienThue = new System.Windows.Forms.TabPage();
            this.dgvTienThue = new System.Windows.Forms.DataGridView();
            this.pnlTopThue = new System.Windows.Forms.Panel();
            this.btnThuTienThue = new System.Windows.Forms.Button();
            this.btnLocTienThue = new System.Windows.Forms.Button();
            this.cboTrangThaiThue = new System.Windows.Forms.ComboBox();
            this.lblTrangThaiThue = new System.Windows.Forms.Label();
            this.cboLocHDThue = new System.Windows.Forms.ComboBox();
            this.chkLocTheoHD = new System.Windows.Forms.CheckBox();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.splDV = new System.Windows.Forms.SplitContainer();
            this.grpLapHDDV = new System.Windows.Forms.GroupBox();
            this.btnLapHDDV = new System.Windows.Forms.Button();
            this.lblTongTienDV = new System.Windows.Forms.Label();
            this.btnXoaDichVuChon = new System.Windows.Forms.Button();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.dgvDichVuChon = new System.Windows.Forms.DataGridView();
            this.numSoLuongDV = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.numChiSoCuoi = new System.Windows.Forms.NumericUpDown();
            this.lblCuoi = new System.Windows.Forms.Label();
            this.numChiSoDau = new System.Windows.Forms.NumericUpDown();
            this.lblDau = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.lblDichVu = new System.Windows.Forms.Label();
            this.numNamDV = new System.Windows.Forms.NumericUpDown();
            this.lblNamDV = new System.Windows.Forms.Label();
            this.cboThangDV = new System.Windows.Forms.ComboBox();
            this.lblThangDV = new System.Windows.Forms.Label();
            this.cboPhongDV = new System.Windows.Forms.ComboBox();
            this.lblPhongDV = new System.Windows.Forms.Label();
            this.cboHDDV = new System.Windows.Forms.ComboBox();
            this.lblHDDV = new System.Windows.Forms.Label();
            this.txtMaHDDV = new System.Windows.Forms.TextBox();
            this.lblMaHDDV = new System.Windows.Forms.Label();
            this.splDanhSachDV = new System.Windows.Forms.SplitContainer();
            this.grpHoaDonDV = new System.Windows.Forms.GroupBox();
            this.dgvHoaDonDV = new System.Windows.Forms.DataGridView();
            this.pnlBotDV = new System.Windows.Forms.Panel();
            this.btnThuTienDV = new System.Windows.Forms.Button();
            this.grpChiTietDV = new System.Windows.Forms.GroupBox();
            this.dgvChiTietDV = new System.Windows.Forms.DataGridView();
            this.tabMain.SuspendLayout();
            this.tabTienThue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienThue)).BeginInit();
            this.pnlTopThue.SuspendLayout();
            this.tabDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splDV)).BeginInit();
            this.splDV.Panel1.SuspendLayout();
            this.splDV.Panel2.SuspendLayout();
            this.splDV.SuspendLayout();
            this.grpLapHDDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChiSoCuoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChiSoDau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splDanhSachDV)).BeginInit();
            this.splDanhSachDV.Panel1.SuspendLayout();
            this.splDanhSachDV.Panel2.SuspendLayout();
            this.splDanhSachDV.SuspendLayout();
            this.grpHoaDonDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonDV)).BeginInit();
            this.pnlBotDV.SuspendLayout();
            this.grpChiTietDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDV)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabTienThue);
            this.tabMain.Controls.Add(this.tabDichVu);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1084, 630);
            this.tabMain.TabIndex = 0;
            // 
            // tabTienThue
            // 
            this.tabTienThue.Controls.Add(this.dgvTienThue);
            this.tabTienThue.Controls.Add(this.pnlTopThue);
            this.tabTienThue.Location = new System.Drawing.Point(4, 24);
            this.tabTienThue.Name = "tabTienThue";
            this.tabTienThue.Padding = new System.Windows.Forms.Padding(3);
            this.tabTienThue.Size = new System.Drawing.Size(1076, 602);
            this.tabTienThue.TabIndex = 0;
            this.tabTienThue.Text = "Thanh Toán Tiền Thuê Văn Phòng (Tháng 7+ Hạn Ngày 1 Đầu Tháng)";
            this.tabTienThue.UseVisualStyleBackColor = true;
            // 
            // dgvTienThue
            // 
            this.dgvTienThue.AllowUserToAddRows = false;
            this.dgvTienThue.AllowUserToDeleteRows = false;
            this.dgvTienThue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTienThue.BackgroundColor = System.Drawing.Color.White;
            this.dgvTienThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTienThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTienThue.Location = new System.Drawing.Point(3, 53);
            this.dgvTienThue.MultiSelect = false;
            this.dgvTienThue.Name = "dgvTienThue";
            this.dgvTienThue.ReadOnly = true;
            this.dgvTienThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTienThue.Size = new System.Drawing.Size(1070, 546);
            this.dgvTienThue.TabIndex = 1;
            // 
            // pnlTopThue
            // 
            this.pnlTopThue.Controls.Add(this.btnThuTienThue);
            this.pnlTopThue.Controls.Add(this.btnLocTienThue);
            this.pnlTopThue.Controls.Add(this.cboTrangThaiThue);
            this.pnlTopThue.Controls.Add(this.lblTrangThaiThue);
            this.pnlTopThue.Controls.Add(this.cboLocHDThue);
            this.pnlTopThue.Controls.Add(this.chkLocTheoHD);
            this.pnlTopThue.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopThue.Location = new System.Drawing.Point(3, 3);
            this.pnlTopThue.Name = "pnlTopThue";
            this.pnlTopThue.Size = new System.Drawing.Size(1070, 50);
            this.pnlTopThue.TabIndex = 0;
            // 
            // btnThuTienThue
            // 
            this.btnThuTienThue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThuTienThue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnThuTienThue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuTienThue.ForeColor = System.Drawing.Color.White;
            this.btnThuTienThue.Location = new System.Drawing.Point(860, 9);
            this.btnThuTienThue.Name = "btnThuTienThue";
            this.btnThuTienThue.Size = new System.Drawing.Size(200, 32);
            this.btnThuTienThue.TabIndex = 5;
            this.btnThuTienThue.Text = "Thu Tiền Thuê Tháng";
            this.btnThuTienThue.UseVisualStyleBackColor = false;
            this.btnThuTienThue.Click += new System.EventHandler(this.btnThuTienThue_Click);
            // 
            // btnLocTienThue
            // 
            this.btnLocTienThue.Location = new System.Drawing.Point(580, 10);
            this.btnLocTienThue.Name = "btnLocTienThue";
            this.btnLocTienThue.Size = new System.Drawing.Size(90, 28);
            this.btnLocTienThue.TabIndex = 4;
            this.btnLocTienThue.Text = "Tải lại";
            this.btnLocTienThue.UseVisualStyleBackColor = true;
            this.btnLocTienThue.Click += new System.EventHandler(this.btnLocTienThue_Click);
            // 
            // cboTrangThaiThue
            // 
            this.cboTrangThaiThue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThaiThue.FormattingEnabled = true;
            this.cboTrangThaiThue.Items.AddRange(new object[] {
            "-- Tất cả trạng thái --",
            "Chưa thanh toán (Công nợ)",
            "Đã thanh toán"});
            this.cboTrangThaiThue.Location = new System.Drawing.Point(380, 13);
            this.cboTrangThaiThue.Name = "cboTrangThaiThue";
            this.cboTrangThaiThue.Size = new System.Drawing.Size(180, 23);
            this.cboTrangThaiThue.TabIndex = 3;
            // 
            // lblTrangThaiThue
            // 
            this.lblTrangThaiThue.AutoSize = true;
            this.lblTrangThaiThue.Location = new System.Drawing.Point(310, 16);
            this.lblTrangThaiThue.Name = "lblTrangThaiThue";
            this.lblTrangThaiThue.Size = new System.Drawing.Size(64, 15);
            this.lblTrangThaiThue.TabIndex = 2;
            this.lblTrangThaiThue.Text = "Trạng thái:";
            // 
            // cboLocHDThue
            // 
            this.cboLocHDThue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocHDThue.FormattingEnabled = true;
            this.cboLocHDThue.Location = new System.Drawing.Point(125, 13);
            this.cboLocHDThue.Name = "cboLocHDThue";
            this.cboLocHDThue.Size = new System.Drawing.Size(160, 23);
            this.cboLocHDThue.TabIndex = 1;
            // 
            // chkLocTheoHD
            // 
            this.chkLocTheoHD.AutoSize = true;
            this.chkLocTheoHD.Location = new System.Drawing.Point(15, 15);
            this.chkLocTheoHD.Name = "chkLocTheoHD";
            this.chkLocTheoHD.Size = new System.Drawing.Size(107, 19);
            this.chkLocTheoHD.TabIndex = 0;
            this.chkLocTheoHD.Text = "Theo hợp đồng:";
            this.chkLocTheoHD.UseVisualStyleBackColor = true;
            // 
            // tabDichVu
            // 
            this.tabDichVu.Controls.Add(this.splDV);
            this.tabDichVu.Location = new System.Drawing.Point(4, 24);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDichVu.Size = new System.Drawing.Size(1076, 602);
            this.tabDichVu.TabIndex = 1;
            this.tabDichVu.Text = "Hóa Đơn & Thu Phí Dịch Vụ Cuối Tháng (Điện, Nước, Internet...)";
            this.tabDichVu.UseVisualStyleBackColor = true;
            // 
            // splDV
            // 
            this.splDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splDV.Location = new System.Drawing.Point(3, 3);
            this.splDV.Name = "splDV";
            this.splDV.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splDV.Panel1
            // 
            this.splDV.Panel1.Controls.Add(this.grpLapHDDV);
            this.splDV.Panel1.Padding = new System.Windows.Forms.Padding(4);
            // 
            // splDV.Panel2
            // 
            this.splDV.Panel2.Controls.Add(this.splDanhSachDV);
            this.splDV.Panel2.Padding = new System.Windows.Forms.Padding(4);
            this.splDV.Size = new System.Drawing.Size(1070, 596);
            this.splDV.SplitterDistance = 230;
            this.splDV.TabIndex = 0;
            // 
            // grpLapHDDV
            // 
            this.grpLapHDDV.Controls.Add(this.btnLapHDDV);
            this.grpLapHDDV.Controls.Add(this.lblTongTienDV);
            this.grpLapHDDV.Controls.Add(this.btnXoaDichVuChon);
            this.grpLapHDDV.Controls.Add(this.btnThemDV);
            this.grpLapHDDV.Controls.Add(this.dgvDichVuChon);
            this.grpLapHDDV.Controls.Add(this.numSoLuongDV);
            this.grpLapHDDV.Controls.Add(this.lblSoLuong);
            this.grpLapHDDV.Controls.Add(this.numChiSoCuoi);
            this.grpLapHDDV.Controls.Add(this.lblCuoi);
            this.grpLapHDDV.Controls.Add(this.numChiSoDau);
            this.grpLapHDDV.Controls.Add(this.lblDau);
            this.grpLapHDDV.Controls.Add(this.cboDichVu);
            this.grpLapHDDV.Controls.Add(this.lblDichVu);
            this.grpLapHDDV.Controls.Add(this.numNamDV);
            this.grpLapHDDV.Controls.Add(this.lblNamDV);
            this.grpLapHDDV.Controls.Add(this.cboThangDV);
            this.grpLapHDDV.Controls.Add(this.lblThangDV);
            this.grpLapHDDV.Controls.Add(this.cboPhongDV);
            this.grpLapHDDV.Controls.Add(this.lblPhongDV);
            this.grpLapHDDV.Controls.Add(this.cboHDDV);
            this.grpLapHDDV.Controls.Add(this.lblHDDV);
            this.grpLapHDDV.Controls.Add(this.txtMaHDDV);
            this.grpLapHDDV.Controls.Add(this.lblMaHDDV);
            this.grpLapHDDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLapHDDV.Location = new System.Drawing.Point(4, 4);
            this.grpLapHDDV.Name = "grpLapHDDV";
            this.grpLapHDDV.Size = new System.Drawing.Size(1062, 222);
            this.grpLapHDDV.TabIndex = 0;
            this.grpLapHDDV.TabStop = false;
            this.grpLapHDDV.Text = "Lập Hóa Đơn Dịch Vụ Định Kỳ Cuối Tháng";
            // 
            // btnLapHDDV
            // 
            this.btnLapHDDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLapHDDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLapHDDV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapHDDV.ForeColor = System.Drawing.Color.White;
            this.btnLapHDDV.Location = new System.Drawing.Point(830, 182);
            this.btnLapHDDV.Name = "btnLapHDDV";
            this.btnLapHDDV.Size = new System.Drawing.Size(220, 32);
            this.btnLapHDDV.TabIndex = 22;
            this.btnLapHDDV.Text = "Lập Hóa Đơn Dịch Vụ";
            this.btnLapHDDV.UseVisualStyleBackColor = false;
            this.btnLapHDDV.Click += new System.EventHandler(this.btnLapHDDV_Click);
            // 
            // lblTongTienDV
            // 
            this.lblTongTienDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTienDV.AutoSize = true;
            this.lblTongTienDV.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTongTienDV.Location = new System.Drawing.Point(620, 190);
            this.lblTongTienDV.Name = "lblTongTienDV";
            this.lblTongTienDV.Size = new System.Drawing.Size(127, 17);
            this.lblTongTienDV.TabIndex = 21;
            this.lblTongTienDV.Text = "Tổng tiền DV: 0 đ";
            // 
            // btnXoaDichVuChon
            // 
            this.btnXoaDichVuChon.Location = new System.Drawing.Point(970, 58);
            this.btnXoaDichVuChon.Name = "btnXoaDichVuChon";
            this.btnXoaDichVuChon.Size = new System.Drawing.Size(80, 25);
            this.btnXoaDichVuChon.TabIndex = 20;
            this.btnXoaDichVuChon.Text = "Bỏ dòng";
            this.btnXoaDichVuChon.UseVisualStyleBackColor = true;
            this.btnXoaDichVuChon.Click += new System.EventHandler(this.btnXoaDichVuChon_Click);
            // 
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(885, 58);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(80, 25);
            this.btnThemDV.TabIndex = 19;
            this.btnThemDV.Text = "+ Thêm DV";
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // dgvDichVuChon
            // 
            this.dgvDichVuChon.AllowUserToAddRows = false;
            this.dgvDichVuChon.AllowUserToDeleteRows = false;
            this.dgvDichVuChon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDichVuChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVuChon.BackgroundColor = System.Drawing.Color.White;
            this.dgvDichVuChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuChon.Location = new System.Drawing.Point(490, 89);
            this.dgvDichVuChon.MultiSelect = false;
            this.dgvDichVuChon.Name = "dgvDichVuChon";
            this.dgvDichVuChon.ReadOnly = true;
            this.dgvDichVuChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVuChon.Size = new System.Drawing.Size(560, 87);
            this.dgvDichVuChon.TabIndex = 18;
            // 
            // numSoLuongDV
            // 
            this.numSoLuongDV.DecimalPlaces = 2;
            this.numSoLuongDV.Location = new System.Drawing.Point(815, 60);
            this.numSoLuongDV.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numSoLuongDV.Name = "numSoLuongDV";
            this.numSoLuongDV.Size = new System.Drawing.Size(65, 23);
            this.numSoLuongDV.TabIndex = 17;
            this.numSoLuongDV.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(785, 63);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(24, 15);
            this.lblSoLuong.TabIndex = 16;
            this.lblSoLuong.Text = "SL:";
            // 
            // numChiSoCuoi
            // 
            this.numChiSoCuoi.DecimalPlaces = 2;
            this.numChiSoCuoi.Location = new System.Drawing.Point(715, 60);
            this.numChiSoCuoi.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numChiSoCuoi.Name = "numChiSoCuoi";
            this.numChiSoCuoi.Size = new System.Drawing.Size(65, 23);
            this.numChiSoCuoi.TabIndex = 15;
            // 
            // lblCuoi
            // 
            this.lblCuoi.AutoSize = true;
            this.lblCuoi.Location = new System.Drawing.Point(675, 63);
            this.lblCuoi.Name = "lblCuoi";
            this.lblCuoi.Size = new System.Drawing.Size(35, 15);
            this.lblCuoi.TabIndex = 14;
            this.lblCuoi.Text = "Cuối:";
            // 
            // numChiSoDau
            // 
            this.numChiSoDau.DecimalPlaces = 2;
            this.numChiSoDau.Location = new System.Drawing.Point(605, 60);
            this.numChiSoDau.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numChiSoDau.Name = "numChiSoDau";
            this.numChiSoDau.Size = new System.Drawing.Size(65, 23);
            this.numChiSoDau.TabIndex = 13;
            // 
            // lblDau
            // 
            this.lblDau.AutoSize = true;
            this.lblDau.Location = new System.Drawing.Point(570, 63);
            this.lblDau.Name = "lblDau";
            this.lblDau.Size = new System.Drawing.Size(31, 15);
            this.lblDau.TabIndex = 12;
            this.lblDau.Text = "Đầu:";
            // 
            // cboDichVu
            // 
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(545, 24);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(200, 23);
            this.cboDichVu.TabIndex = 11;
            // 
            // lblDichVu
            // 
            this.lblDichVu.AutoSize = true;
            this.lblDichVu.Location = new System.Drawing.Point(490, 27);
            this.lblDichVu.Name = "lblDichVu";
            this.lblDichVu.Size = new System.Drawing.Size(50, 15);
            this.lblDichVu.TabIndex = 10;
            this.lblDichVu.Text = "Dịch vụ:";
            // 
            // numNamDV
            // 
            this.numNamDV.Location = new System.Drawing.Point(260, 95);
            this.numNamDV.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNamDV.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numNamDV.Name = "numNamDV";
            this.numNamDV.Size = new System.Drawing.Size(80, 23);
            this.numNamDV.TabIndex = 9;
            this.numNamDV.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblNamDV
            // 
            this.lblNamDV.AutoSize = true;
            this.lblNamDV.Location = new System.Drawing.Point(215, 97);
            this.lblNamDV.Name = "lblNamDV";
            this.lblNamDV.Size = new System.Drawing.Size(36, 15);
            this.lblNamDV.TabIndex = 8;
            this.lblNamDV.Text = "Năm:";
            // 
            // cboThangDV
            // 
            this.cboThangDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThangDV.FormattingEnabled = true;
            this.cboThangDV.Items.AddRange(new object[] {
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"});
            this.cboThangDV.Location = new System.Drawing.Point(85, 95);
            this.cboThangDV.Name = "cboThangDV";
            this.cboThangDV.Size = new System.Drawing.Size(110, 23);
            this.cboThangDV.TabIndex = 7;
            // 
            // lblThangDV
            // 
            this.lblThangDV.AutoSize = true;
            this.lblThangDV.Location = new System.Drawing.Point(15, 97);
            this.lblThangDV.Name = "lblThangDV";
            this.lblThangDV.Size = new System.Drawing.Size(58, 15);
            this.lblThangDV.TabIndex = 6;
            this.lblThangDV.Text = "Kỳ tháng:";
            // 
            // cboPhongDV
            // 
            this.cboPhongDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongDV.FormattingEnabled = true;
            this.cboPhongDV.Location = new System.Drawing.Point(85, 60);
            this.cboPhongDV.Name = "cboPhongDV";
            this.cboPhongDV.Size = new System.Drawing.Size(255, 23);
            this.cboPhongDV.TabIndex = 5;
            // 
            // lblPhongDV
            // 
            this.lblPhongDV.AutoSize = true;
            this.lblPhongDV.Location = new System.Drawing.Point(15, 63);
            this.lblPhongDV.Name = "lblPhongDV";
            this.lblPhongDV.Size = new System.Drawing.Size(45, 15);
            this.lblPhongDV.TabIndex = 4;
            this.lblPhongDV.Text = "Phòng:";
            // 
            // cboHDDV
            // 
            this.cboHDDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHDDV.FormattingEnabled = true;
            this.cboHDDV.Location = new System.Drawing.Point(260, 24);
            this.cboHDDV.Name = "cboHDDV";
            this.cboHDDV.Size = new System.Drawing.Size(180, 23);
            this.cboHDDV.TabIndex = 3;
            this.cboHDDV.SelectedIndexChanged += new System.EventHandler(this.cboHDDV_SelectedIndexChanged);
            // 
            // lblHDDV
            // 
            this.lblHDDV.AutoSize = true;
            this.lblHDDV.Location = new System.Drawing.Point(215, 27);
            this.lblHDDV.Name = "lblHDDV";
            this.lblHDDV.Size = new System.Drawing.Size(47, 15);
            this.lblHDDV.TabIndex = 2;
            this.lblHDDV.Text = "Mã HĐ:";
            // 
            // txtMaHDDV
            // 
            this.txtMaHDDV.Location = new System.Drawing.Point(85, 24);
            this.txtMaHDDV.Name = "txtMaHDDV";
            this.txtMaHDDV.Size = new System.Drawing.Size(110, 23);
            this.txtMaHDDV.TabIndex = 1;
            // 
            // lblMaHDDV
            // 
            this.lblMaHDDV.AutoSize = true;
            this.lblMaHDDV.Location = new System.Drawing.Point(15, 27);
            this.lblMaHDDV.Name = "lblMaHDDV";
            this.lblMaHDDV.Size = new System.Drawing.Size(62, 15);
            this.lblMaHDDV.TabIndex = 0;
            this.lblMaHDDV.Text = "Mã HĐDV:";
            // 
            // splDanhSachDV
            // 
            this.splDanhSachDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splDanhSachDV.Location = new System.Drawing.Point(4, 4);
            this.splDanhSachDV.Name = "splDanhSachDV";
            // 
            // splDanhSachDV.Panel1
            // 
            this.splDanhSachDV.Panel1.Controls.Add(this.grpHoaDonDV);
            // 
            // splDanhSachDV.Panel2
            // 
            this.splDanhSachDV.Panel2.Controls.Add(this.grpChiTietDV);
            this.splDanhSachDV.Size = new System.Drawing.Size(1062, 354);
            this.splDanhSachDV.SplitterDistance = 600;
            this.splDanhSachDV.TabIndex = 0;
            // 
            // grpHoaDonDV
            // 
            this.grpHoaDonDV.Controls.Add(this.dgvHoaDonDV);
            this.grpHoaDonDV.Controls.Add(this.pnlBotDV);
            this.grpHoaDonDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpHoaDonDV.Location = new System.Drawing.Point(0, 0);
            this.grpHoaDonDV.Name = "grpHoaDonDV";
            this.grpHoaDonDV.Size = new System.Drawing.Size(600, 354);
            this.grpHoaDonDV.TabIndex = 0;
            this.grpHoaDonDV.TabStop = false;
            this.grpHoaDonDV.Text = "Danh Sách Hóa Đơn Dịch Vụ";
            // 
            // dgvHoaDonDV
            // 
            this.dgvHoaDonDV.AllowUserToAddRows = false;
            this.dgvHoaDonDV.AllowUserToDeleteRows = false;
            this.dgvHoaDonDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDonDV.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDonDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHoaDonDV.Location = new System.Drawing.Point(3, 19);
            this.dgvHoaDonDV.MultiSelect = false;
            this.dgvHoaDonDV.Name = "dgvHoaDonDV";
            this.dgvHoaDonDV.ReadOnly = true;
            this.dgvHoaDonDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDonDV.Size = new System.Drawing.Size(594, 287);
            this.dgvHoaDonDV.TabIndex = 0;
            this.dgvHoaDonDV.SelectionChanged += new System.EventHandler(this.dgvHoaDonDV_SelectionChanged);
            // 
            // pnlBotDV
            // 
            this.pnlBotDV.Controls.Add(this.btnThuTienDV);
            this.pnlBotDV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotDV.Location = new System.Drawing.Point(3, 306);
            this.pnlBotDV.Name = "pnlBotDV";
            this.pnlBotDV.Size = new System.Drawing.Size(594, 45);
            this.pnlBotDV.TabIndex = 1;
            // 
            // btnThuTienDV
            // 
            this.btnThuTienDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnThuTienDV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThuTienDV.ForeColor = System.Drawing.Color.White;
            this.btnThuTienDV.Location = new System.Drawing.Point(10, 7);
            this.btnThuTienDV.Name = "btnThuTienDV";
            this.btnThuTienDV.Size = new System.Drawing.Size(220, 32);
            this.btnThuTienDV.TabIndex = 0;
            this.btnThuTienDV.Text = "Thu Tiền Hóa Đơn Dịch Vụ";
            this.btnThuTienDV.UseVisualStyleBackColor = false;
            this.btnThuTienDV.Click += new System.EventHandler(this.btnThuTienDV_Click);
            // 
            // grpChiTietDV
            // 
            this.grpChiTietDV.Controls.Add(this.dgvChiTietDV);
            this.grpChiTietDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTietDV.Location = new System.Drawing.Point(0, 0);
            this.grpChiTietDV.Name = "grpChiTietDV";
            this.grpChiTietDV.Size = new System.Drawing.Size(458, 354);
            this.grpChiTietDV.TabIndex = 0;
            this.grpChiTietDV.TabStop = false;
            this.grpChiTietDV.Text = "Chi Tiết Dịch Vụ Theo Hóa Đơn";
            // 
            // dgvChiTietDV
            // 
            this.dgvChiTietDV.AllowUserToAddRows = false;
            this.dgvChiTietDV.AllowUserToDeleteRows = false;
            this.dgvChiTietDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietDV.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietDV.Location = new System.Drawing.Point(3, 19);
            this.dgvChiTietDV.MultiSelect = false;
            this.dgvChiTietDV.Name = "dgvChiTietDV";
            this.dgvChiTietDV.ReadOnly = true;
            this.dgvChiTietDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietDV.Size = new System.Drawing.Size(452, 332);
            this.dgvChiTietDV.TabIndex = 0;
            // 
            // FrmThanhToanThang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 630);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "FrmThanhToanThang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Thanh Toán Tiền Thuê & Phí Dịch Vụ";
            this.tabMain.ResumeLayout(false);
            this.tabTienThue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienThue)).EndInit();
            this.pnlTopThue.ResumeLayout(false);
            this.pnlTopThue.PerformLayout();
            this.tabDichVu.ResumeLayout(false);
            this.splDV.Panel1.ResumeLayout(false);
            this.splDV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splDV)).EndInit();
            this.splDV.ResumeLayout(false);
            this.grpLapHDDV.ResumeLayout(false);
            this.grpLapHDDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChiSoCuoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChiSoDau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDV)).EndInit();
            this.splDanhSachDV.Panel1.ResumeLayout(false);
            this.splDanhSachDV.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splDanhSachDV)).EndInit();
            this.splDanhSachDV.ResumeLayout(false);
            this.grpHoaDonDV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonDV)).EndInit();
            this.pnlBotDV.ResumeLayout(false);
            this.grpChiTietDV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabTienThue;
        private System.Windows.Forms.Panel pnlTopThue;
        private System.Windows.Forms.CheckBox chkLocTheoHD;
        private System.Windows.Forms.ComboBox cboLocHDThue;
        private System.Windows.Forms.Label lblTrangThaiThue;
        private System.Windows.Forms.ComboBox cboTrangThaiThue;
        private System.Windows.Forms.Button btnLocTienThue;
        private System.Windows.Forms.Button btnThuTienThue;
        private System.Windows.Forms.DataGridView dgvTienThue;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.SplitContainer splDV;
        private System.Windows.Forms.GroupBox grpLapHDDV;
        private System.Windows.Forms.TextBox txtMaHDDV;
        private System.Windows.Forms.Label lblMaHDDV;
        private System.Windows.Forms.ComboBox cboHDDV;
        private System.Windows.Forms.Label lblHDDV;
        private System.Windows.Forms.ComboBox cboPhongDV;
        private System.Windows.Forms.Label lblPhongDV;
        private System.Windows.Forms.ComboBox cboThangDV;
        private System.Windows.Forms.Label lblThangDV;
        private System.Windows.Forms.NumericUpDown numNamDV;
        private System.Windows.Forms.Label lblNamDV;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label lblDichVu;
        private System.Windows.Forms.NumericUpDown numChiSoDau;
        private System.Windows.Forms.Label lblDau;
        private System.Windows.Forms.NumericUpDown numChiSoCuoi;
        private System.Windows.Forms.Label lblCuoi;
        private System.Windows.Forms.NumericUpDown numSoLuongDV;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.Button btnXoaDichVuChon;
        private System.Windows.Forms.DataGridView dgvDichVuChon;
        private System.Windows.Forms.Label lblTongTienDV;
        private System.Windows.Forms.Button btnLapHDDV;
        private System.Windows.Forms.SplitContainer splDanhSachDV;
        private System.Windows.Forms.GroupBox grpHoaDonDV;
        private System.Windows.Forms.DataGridView dgvHoaDonDV;
        private System.Windows.Forms.Panel pnlBotDV;
        private System.Windows.Forms.Button btnThuTienDV;
        private System.Windows.Forms.GroupBox grpChiTietDV;
        private System.Windows.Forms.DataGridView dgvChiTietDV;
    }
}
