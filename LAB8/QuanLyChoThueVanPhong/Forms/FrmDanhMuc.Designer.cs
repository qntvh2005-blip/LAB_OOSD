namespace QuanLyChoThueVanPhong.Forms
{
    partial class FrmDanhMuc
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
            this.tabDanhMuc = new System.Windows.Forms.TabControl();
            this.tabTang = new System.Windows.Forms.TabPage();
            this.dgvTang = new System.Windows.Forms.DataGridView();
            this.pnlTang = new System.Windows.Forms.Panel();
            this.btnThemTang = new System.Windows.Forms.Button();
            this.txtGhiChuTang = new System.Windows.Forms.TextBox();
            this.lblGhiChuTang = new System.Windows.Forms.Label();
            this.numHeSoGia = new System.Windows.Forms.NumericUpDown();
            this.lblHeSoGia = new System.Windows.Forms.Label();
            this.numDoCao = new System.Windows.Forms.NumericUpDown();
            this.lblDoCao = new System.Windows.Forms.Label();
            this.txtTenTang = new System.Windows.Forms.TextBox();
            this.lblTenTang = new System.Windows.Forms.Label();
            this.txtMaTang = new System.Windows.Forms.TextBox();
            this.lblMaTang = new System.Windows.Forms.Label();
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.pnlPhong = new System.Windows.Forms.Panel();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.numDonGiaCoBan = new System.Windows.Forms.NumericUpDown();
            this.lblDonGiaCoBan = new System.Windows.Forms.Label();
            this.cboHuong = new System.Windows.Forms.ComboBox();
            this.lblHuong = new System.Windows.Forms.Label();
            this.numDienTich = new System.Windows.Forms.NumericUpDown();
            this.lblDienTich = new System.Windows.Forms.Label();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.cboTangPhong = new System.Windows.Forms.ComboBox();
            this.lblTangPhong = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.pnlDichVu = new System.Windows.Forms.Panel();
            this.cboLoaiDV = new System.Windows.Forms.ComboBox();
            this.lblLoaiDV = new System.Windows.Forms.Label();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.numDonGiaDV = new System.Windows.Forms.NumericUpDown();
            this.lblDonGiaDV = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.lblTenDV = new System.Windows.Forms.Label();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.lblMaDV = new System.Windows.Forms.Label();
            this.tabKhachHang = new System.Windows.Forms.TabPage();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.pnlKhachHang = new System.Windows.Forms.Panel();
            this.txtDiaChiKH = new System.Windows.Forms.TextBox();
            this.lblDiaChiKH = new System.Windows.Forms.Label();
            this.txtEmailKH = new System.Windows.Forms.TextBox();
            this.lblEmailKH = new System.Windows.Forms.Label();
            this.txtSDTKH = new System.Windows.Forms.TextBox();
            this.lblSDTKH = new System.Windows.Forms.Label();
            this.txtMST = new System.Windows.Forms.TextBox();
            this.lblMST = new System.Windows.Forms.Label();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.txtNguoiDaiDien = new System.Windows.Forms.TextBox();
            this.lblNguoiDaiDien = new System.Windows.Forms.Label();
            this.txtTenCongTy = new System.Windows.Forms.TextBox();
            this.lblTenCongTy = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabDanhMuc.SuspendLayout();
            this.tabTang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTang)).BeginInit();
            this.pnlTang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeSoGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoCao)).BeginInit();
            this.tabPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.pnlPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaCoBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDienTich)).BeginInit();
            this.tabDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.pnlDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaDV)).BeginInit();
            this.tabKhachHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.pnlKhachHang.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Controls.Add(this.tabTang);
            this.tabDanhMuc.Controls.Add(this.tabPhong);
            this.tabDanhMuc.Controls.Add(this.tabDichVu);
            this.tabDanhMuc.Controls.Add(this.tabKhachHang);
            this.tabDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.SelectedIndex = 0;
            this.tabDanhMuc.Size = new System.Drawing.Size(920, 520);
            this.tabDanhMuc.TabIndex = 0;
            // 
            // tabTang
            // 
            this.tabTang.Controls.Add(this.dgvTang);
            this.tabTang.Controls.Add(this.pnlTang);
            this.tabTang.Location = new System.Drawing.Point(4, 25);
            this.tabTang.Name = "tabTang";
            this.tabTang.Padding = new System.Windows.Forms.Padding(3);
            this.tabTang.Size = new System.Drawing.Size(912, 491);
            this.tabTang.TabIndex = 0;
            this.tabTang.Text = "Tầng cao ốc";
            this.tabTang.UseVisualStyleBackColor = true;
            // 
            // dgvTang
            // 
            this.dgvTang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTang.Location = new System.Drawing.Point(3, 115);
            this.dgvTang.Name = "dgvTang";
            this.dgvTang.RowHeadersWidth = 51;
            this.dgvTang.RowTemplate.Height = 24;
            this.dgvTang.Size = new System.Drawing.Size(906, 373);
            this.dgvTang.TabIndex = 1;
            // 
            // pnlTang
            // 
            this.pnlTang.Controls.Add(this.btnThemTang);
            this.pnlTang.Controls.Add(this.txtGhiChuTang);
            this.pnlTang.Controls.Add(this.lblGhiChuTang);
            this.pnlTang.Controls.Add(this.numHeSoGia);
            this.pnlTang.Controls.Add(this.lblHeSoGia);
            this.pnlTang.Controls.Add(this.numDoCao);
            this.pnlTang.Controls.Add(this.lblDoCao);
            this.pnlTang.Controls.Add(this.txtTenTang);
            this.pnlTang.Controls.Add(this.lblTenTang);
            this.pnlTang.Controls.Add(this.txtMaTang);
            this.pnlTang.Controls.Add(this.lblMaTang);
            this.pnlTang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTang.Location = new System.Drawing.Point(3, 3);
            this.pnlTang.Name = "pnlTang";
            this.pnlTang.Size = new System.Drawing.Size(906, 112);
            this.pnlTang.TabIndex = 0;
            // 
            // btnThemTang
            // 
            this.btnThemTang.Location = new System.Drawing.Point(740, 60);
            this.btnThemTang.Name = "btnThemTang";
            this.btnThemTang.Size = new System.Drawing.Size(120, 32);
            this.btnThemTang.TabIndex = 10;
            this.btnThemTang.Text = "Thêm tầng";
            this.btnThemTang.UseVisualStyleBackColor = true;
            this.btnThemTang.Click += new System.EventHandler(this.btnThemTang_Click);
            // 
            // txtGhiChuTang
            // 
            this.txtGhiChuTang.Location = new System.Drawing.Point(330, 65);
            this.txtGhiChuTang.Name = "txtGhiChuTang";
            this.txtGhiChuTang.Size = new System.Drawing.Size(380, 22);
            this.txtGhiChuTang.TabIndex = 9;
            // 
            // lblGhiChuTang
            // 
            this.lblGhiChuTang.AutoSize = true;
            this.lblGhiChuTang.Location = new System.Drawing.Point(265, 68);
            this.lblGhiChuTang.Name = "lblGhiChuTang";
            this.lblGhiChuTang.Size = new System.Drawing.Size(61, 17);
            this.lblGhiChuTang.TabIndex = 8;
            this.lblGhiChuTang.Text = "Ghi chú:";
            // 
            // numHeSoGia
            // 
            this.numHeSoGia.DecimalPlaces = 2;
            this.numHeSoGia.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            this.numHeSoGia.Location = new System.Drawing.Point(100, 65);
            this.numHeSoGia.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numHeSoGia.Minimum = new decimal(new int[] { 5, 0, 0, 65536 });
            this.numHeSoGia.Name = "numHeSoGia";
            this.numHeSoGia.Size = new System.Drawing.Size(130, 22);
            this.numHeSoGia.TabIndex = 7;
            this.numHeSoGia.Value = new decimal(new int[] { 10, 0, 0, 65536 });
            // 
            // lblHeSoGia
            // 
            this.lblHeSoGia.AutoSize = true;
            this.lblHeSoGia.Location = new System.Drawing.Point(15, 68);
            this.lblHeSoGia.Name = "lblHeSoGia";
            this.lblHeSoGia.Size = new System.Drawing.Size(73, 17);
            this.lblHeSoGia.TabIndex = 6;
            this.lblHeSoGia.Text = "Hệ số giá:";
            // 
            // numDoCao
            // 
            this.numDoCao.Location = new System.Drawing.Point(630, 20);
            this.numDoCao.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDoCao.Name = "numDoCao";
            this.numDoCao.Size = new System.Drawing.Size(80, 22);
            this.numDoCao.TabIndex = 5;
            this.numDoCao.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblDoCao
            // 
            this.lblDoCao.AutoSize = true;
            this.lblDoCao.Location = new System.Drawing.Point(565, 23);
            this.lblDoCao.Name = "lblDoCao";
            this.lblDoCao.Size = new System.Drawing.Size(58, 17);
            this.lblDoCao.TabIndex = 4;
            this.lblDoCao.Text = "Độ cao:";
            // 
            // txtTenTang
            // 
            this.txtTenTang.Location = new System.Drawing.Point(330, 20);
            this.txtTenTang.Name = "txtTenTang";
            this.txtTenTang.Size = new System.Drawing.Size(210, 22);
            this.txtTenTang.TabIndex = 3;
            // 
            // lblTenTang
            // 
            this.lblTenTang.AutoSize = true;
            this.lblTenTang.Location = new System.Drawing.Point(255, 23);
            this.lblTenTang.Name = "lblTenTang";
            this.lblTenTang.Size = new System.Drawing.Size(69, 17);
            this.lblTenTang.TabIndex = 2;
            this.lblTenTang.Text = "Tên tầng:";
            // 
            // txtMaTang
            // 
            this.txtMaTang.Location = new System.Drawing.Point(100, 20);
            this.txtMaTang.Name = "txtMaTang";
            this.txtMaTang.Size = new System.Drawing.Size(130, 22);
            this.txtMaTang.TabIndex = 1;
            // 
            // lblMaTang
            // 
            this.lblMaTang.AutoSize = true;
            this.lblMaTang.Location = new System.Drawing.Point(15, 23);
            this.lblMaTang.Name = "lblMaTang";
            this.lblMaTang.Size = new System.Drawing.Size(63, 17);
            this.lblMaTang.TabIndex = 0;
            this.lblMaTang.Text = "Mã tầng:";
            // 
            // tabPhong
            // 
            this.tabPhong.Controls.Add(this.dgvPhong);
            this.tabPhong.Controls.Add(this.pnlPhong);
            this.tabPhong.Location = new System.Drawing.Point(4, 25);
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhong.Size = new System.Drawing.Size(912, 491);
            this.tabPhong.TabIndex = 1;
            this.tabPhong.Text = "Phòng văn phòng";
            this.tabPhong.UseVisualStyleBackColor = true;
            // 
            // dgvPhong
            // 
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhong.Location = new System.Drawing.Point(3, 125);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.RowHeadersWidth = 51;
            this.dgvPhong.RowTemplate.Height = 24;
            this.dgvPhong.Size = new System.Drawing.Size(906, 363);
            this.dgvPhong.TabIndex = 1;
            // 
            // pnlPhong
            // 
            this.pnlPhong.Controls.Add(this.btnThemPhong);
            this.pnlPhong.Controls.Add(this.numDonGiaCoBan);
            this.pnlPhong.Controls.Add(this.lblDonGiaCoBan);
            this.pnlPhong.Controls.Add(this.cboHuong);
            this.pnlPhong.Controls.Add(this.lblHuong);
            this.pnlPhong.Controls.Add(this.numDienTich);
            this.pnlPhong.Controls.Add(this.lblDienTich);
            this.pnlPhong.Controls.Add(this.txtTenPhong);
            this.pnlPhong.Controls.Add(this.lblTenPhong);
            this.pnlPhong.Controls.Add(this.cboTangPhong);
            this.pnlPhong.Controls.Add(this.lblTangPhong);
            this.pnlPhong.Controls.Add(this.txtMaPhong);
            this.pnlPhong.Controls.Add(this.lblMaPhong);
            this.pnlPhong.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPhong.Location = new System.Drawing.Point(3, 3);
            this.pnlPhong.Name = "pnlPhong";
            this.pnlPhong.Size = new System.Drawing.Size(906, 122);
            this.pnlPhong.TabIndex = 0;
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(750, 68);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(125, 32);
            this.btnThemPhong.TabIndex = 12;
            this.btnThemPhong.Text = "Thêm phòng";
            this.btnThemPhong.UseVisualStyleBackColor = true;
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // numDonGiaCoBan
            // 
            this.numDonGiaCoBan.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numDonGiaCoBan.Location = new System.Drawing.Point(585, 73);
            this.numDonGiaCoBan.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numDonGiaCoBan.Name = "numDonGiaCoBan";
            this.numDonGiaCoBan.Size = new System.Drawing.Size(140, 22);
            this.numDonGiaCoBan.TabIndex = 11;
            this.numDonGiaCoBan.Value = new decimal(new int[] { 350000, 0, 0, 0 });
            // 
            // lblDonGiaCoBan
            // 
            this.lblDonGiaCoBan.AutoSize = true;
            this.lblDonGiaCoBan.Location = new System.Drawing.Point(495, 76);
            this.lblDonGiaCoBan.Name = "lblDonGiaCoBan";
            this.lblDonGiaCoBan.Size = new System.Drawing.Size(89, 17);
            this.lblDonGiaCoBan.TabIndex = 10;
            this.lblDonGiaCoBan.Text = "Đơn giá/m2:";
            // 
            // cboHuong
            // 
            this.cboHuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHuong.FormattingEnabled = true;
            this.cboHuong.Items.AddRange(new object[] {
            "Đông",
            "Tây",
            "Nam",
            "Bắc",
            "Đông Nam",
            "Đông Bắc",
            "Tây Nam",
            "Tây Bắc"});
            this.cboHuong.Location = new System.Drawing.Point(330, 73);
            this.cboHuong.Name = "cboHuong";
            this.cboHuong.Size = new System.Drawing.Size(140, 24);
            this.cboHuong.TabIndex = 9;
            // 
            // lblHuong
            // 
            this.lblHuong.AutoSize = true;
            this.lblHuong.Location = new System.Drawing.Point(265, 76);
            this.lblHuong.Name = "lblHuong";
            this.lblHuong.Size = new System.Drawing.Size(55, 17);
            this.lblHuong.TabIndex = 8;
            this.lblHuong.Text = "Hướng:";
            // 
            // numDienTich
            // 
            this.numDienTich.DecimalPlaces = 2;
            this.numDienTich.Location = new System.Drawing.Point(100, 73);
            this.numDienTich.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            this.numDienTich.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numDienTich.Name = "numDienTich";
            this.numDienTich.Size = new System.Drawing.Size(130, 22);
            this.numDienTich.TabIndex = 7;
            this.numDienTich.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // lblDienTich
            // 
            this.lblDienTich.AutoSize = true;
            this.lblDienTich.Location = new System.Drawing.Point(15, 76);
            this.lblDienTich.Name = "lblDienTich";
            this.lblDienTich.Size = new System.Drawing.Size(67, 17);
            this.lblDienTich.TabIndex = 6;
            this.lblDienTich.Text = "Diện tích:";
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Location = new System.Drawing.Point(585, 20);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(200, 22);
            this.txtTenPhong.TabIndex = 5;
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Location = new System.Drawing.Point(500, 23);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(81, 17);
            this.lblTenPhong.TabIndex = 4;
            this.lblTenPhong.Text = "Tên phòng:";
            // 
            // cboTangPhong
            // 
            this.cboTangPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTangPhong.FormattingEnabled = true;
            this.cboTangPhong.Location = new System.Drawing.Point(330, 20);
            this.cboTangPhong.Name = "cboTangPhong";
            this.cboTangPhong.Size = new System.Drawing.Size(150, 24);
            this.cboTangPhong.TabIndex = 3;
            // 
            // lblTangPhong
            // 
            this.lblTangPhong.AutoSize = true;
            this.lblTangPhong.Location = new System.Drawing.Point(265, 23);
            this.lblTangPhong.Name = "lblTangPhong";
            this.lblTangPhong.Size = new System.Drawing.Size(45, 17);
            this.lblTangPhong.TabIndex = 2;
            this.lblTangPhong.Text = "Tầng:";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(100, 20);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(130, 22);
            this.txtMaPhong.TabIndex = 1;
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Location = new System.Drawing.Point(15, 23);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(75, 17);
            this.lblMaPhong.TabIndex = 0;
            this.lblMaPhong.Text = "Mã phòng:";
            // 
            // tabDichVu
            // 
            this.tabDichVu.Controls.Add(this.dgvDichVu);
            this.tabDichVu.Controls.Add(this.pnlDichVu);
            this.tabDichVu.Location = new System.Drawing.Point(4, 25);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDichVu.Size = new System.Drawing.Size(912, 491);
            this.tabDichVu.TabIndex = 2;
            this.tabDichVu.Text = "Dịch vụ tòa nhà";
            this.tabDichVu.UseVisualStyleBackColor = true;
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDichVu.Location = new System.Drawing.Point(3, 115);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.RowHeadersWidth = 51;
            this.dgvDichVu.RowTemplate.Height = 24;
            this.dgvDichVu.Size = new System.Drawing.Size(906, 373);
            this.dgvDichVu.TabIndex = 1;
            // 
            // pnlDichVu
            // 
            this.pnlDichVu.Controls.Add(this.cboLoaiDV);
            this.pnlDichVu.Controls.Add(this.lblLoaiDV);
            this.pnlDichVu.Controls.Add(this.btnThemDV);
            this.pnlDichVu.Controls.Add(this.numDonGiaDV);
            this.pnlDichVu.Controls.Add(this.lblDonGiaDV);
            this.pnlDichVu.Controls.Add(this.txtDVT);
            this.pnlDichVu.Controls.Add(this.lblDVT);
            this.pnlDichVu.Controls.Add(this.txtTenDV);
            this.pnlDichVu.Controls.Add(this.lblTenDV);
            this.pnlDichVu.Controls.Add(this.txtMaDV);
            this.pnlDichVu.Controls.Add(this.lblMaDV);
            this.pnlDichVu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDichVu.Location = new System.Drawing.Point(3, 3);
            this.pnlDichVu.Name = "pnlDichVu";
            this.pnlDichVu.Size = new System.Drawing.Size(906, 112);
            this.pnlDichVu.TabIndex = 0;
            // 
            // cboLoaiDV
            // 
            this.cboLoaiDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiDV.FormattingEnabled = true;
            this.cboLoaiDV.Items.AddRange(new object[] {
            "Điện",
            "Nước",
            "Internet",
            "Vệ sinh",
            "Gửi xe",
            "Khác"});
            this.cboLoaiDV.Location = new System.Drawing.Point(365, 65);
            this.cboLoaiDV.Name = "cboLoaiDV";
            this.cboLoaiDV.Size = new System.Drawing.Size(150, 24);
            this.cboLoaiDV.TabIndex = 10;
            // 
            // lblLoaiDV
            // 
            this.lblLoaiDV.AutoSize = true;
            this.lblLoaiDV.Location = new System.Drawing.Point(295, 68);
            this.lblLoaiDV.Name = "lblLoaiDV";
            this.lblLoaiDV.Size = new System.Drawing.Size(61, 17);
            this.lblLoaiDV.TabIndex = 9;
            this.lblLoaiDV.Text = "Loại DV:";
            // 
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(750, 60);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(120, 32);
            this.btnThemDV.TabIndex = 8;
            this.btnThemDV.Text = "Thêm dịch vụ";
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // numDonGiaDV
            // 
            this.numDonGiaDV.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numDonGiaDV.Location = new System.Drawing.Point(100, 65);
            this.numDonGiaDV.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numDonGiaDV.Name = "numDonGiaDV";
            this.numDonGiaDV.Size = new System.Drawing.Size(150, 22);
            this.numDonGiaDV.TabIndex = 7;
            this.numDonGiaDV.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // lblDonGiaDV
            // 
            this.lblDonGiaDV.AutoSize = true;
            this.lblDonGiaDV.Location = new System.Drawing.Point(15, 68);
            this.lblDonGiaDV.Name = "lblDonGiaDV";
            this.lblDonGiaDV.Size = new System.Drawing.Size(61, 17);
            this.lblDonGiaDV.TabIndex = 6;
            this.lblDonGiaDV.Text = "Đơn giá:";
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(620, 20);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(90, 22);
            this.txtDVT.TabIndex = 5;
            this.txtDVT.Text = "Tháng";
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Location = new System.Drawing.Point(565, 23);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(40, 17);
            this.lblDVT.TabIndex = 4;
            this.lblDVT.Text = "ĐVT:";
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(340, 20);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(200, 22);
            this.txtTenDV.TabIndex = 3;
            // 
            // lblTenDV
            // 
            this.lblTenDV.AutoSize = true;
            this.lblTenDV.Location = new System.Drawing.Point(265, 23);
            this.lblTenDV.Name = "lblTenDV";
            this.lblTenDV.Size = new System.Drawing.Size(60, 17);
            this.lblTenDV.TabIndex = 2;
            this.lblTenDV.Text = "Tên DV:";
            // 
            // txtMaDV
            // 
            this.txtMaDV.Location = new System.Drawing.Point(100, 20);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.Size = new System.Drawing.Size(130, 22);
            this.txtMaDV.TabIndex = 1;
            // 
            // lblMaDV
            // 
            this.lblMaDV.AutoSize = true;
            this.lblMaDV.Location = new System.Drawing.Point(15, 23);
            this.lblMaDV.Name = "lblMaDV";
            this.lblMaDV.Size = new System.Drawing.Size(54, 17);
            this.lblMaDV.TabIndex = 0;
            this.lblMaDV.Text = "Mã DV:";
            // 
            // tabKhachHang
            // 
            this.tabKhachHang.Controls.Add(this.dgvKhachHang);
            this.tabKhachHang.Controls.Add(this.pnlKhachHang);
            this.tabKhachHang.Location = new System.Drawing.Point(4, 25);
            this.tabKhachHang.Name = "tabKhachHang";
            this.tabKhachHang.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhachHang.Size = new System.Drawing.Size(912, 491);
            this.tabKhachHang.TabIndex = 3;
            this.tabKhachHang.Text = "Khách hàng / Công ty thuê";
            this.tabKhachHang.UseVisualStyleBackColor = true;
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.Location = new System.Drawing.Point(3, 140);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.RowTemplate.Height = 24;
            this.dgvKhachHang.Size = new System.Drawing.Size(906, 348);
            this.dgvKhachHang.TabIndex = 1;
            // 
            // pnlKhachHang
            // 
            this.pnlKhachHang.Controls.Add(this.txtDiaChiKH);
            this.pnlKhachHang.Controls.Add(this.lblDiaChiKH);
            this.pnlKhachHang.Controls.Add(this.txtEmailKH);
            this.pnlKhachHang.Controls.Add(this.lblEmailKH);
            this.pnlKhachHang.Controls.Add(this.txtSDTKH);
            this.pnlKhachHang.Controls.Add(this.lblSDTKH);
            this.pnlKhachHang.Controls.Add(this.txtMST);
            this.pnlKhachHang.Controls.Add(this.lblMST);
            this.pnlKhachHang.Controls.Add(this.btnThemKH);
            this.pnlKhachHang.Controls.Add(this.txtNguoiDaiDien);
            this.pnlKhachHang.Controls.Add(this.lblNguoiDaiDien);
            this.pnlKhachHang.Controls.Add(this.txtTenCongTy);
            this.pnlKhachHang.Controls.Add(this.lblTenCongTy);
            this.pnlKhachHang.Controls.Add(this.txtMaKH);
            this.pnlKhachHang.Controls.Add(this.lblMaKH);
            this.pnlKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKhachHang.Location = new System.Drawing.Point(3, 3);
            this.pnlKhachHang.Name = "pnlKhachHang";
            this.pnlKhachHang.Size = new System.Drawing.Size(906, 137);
            this.pnlKhachHang.TabIndex = 0;
            // 
            // txtDiaChiKH
            // 
            this.txtDiaChiKH.Location = new System.Drawing.Point(400, 95);
            this.txtDiaChiKH.Name = "txtDiaChiKH";
            this.txtDiaChiKH.Size = new System.Drawing.Size(320, 22);
            this.txtDiaChiKH.TabIndex = 14;
            // 
            // lblDiaChiKH
            // 
            this.lblDiaChiKH.AutoSize = true;
            this.lblDiaChiKH.Location = new System.Drawing.Point(335, 98);
            this.lblDiaChiKH.Name = "lblDiaChiKH";
            this.lblDiaChiKH.Size = new System.Drawing.Size(55, 17);
            this.lblDiaChiKH.TabIndex = 13;
            this.lblDiaChiKH.Text = "Địa chỉ:";
            // 
            // txtEmailKH
            // 
            this.txtEmailKH.Location = new System.Drawing.Point(100, 95);
            this.txtEmailKH.Name = "txtEmailKH";
            this.txtEmailKH.Size = new System.Drawing.Size(200, 22);
            this.txtEmailKH.TabIndex = 12;
            // 
            // lblEmailKH
            // 
            this.lblEmailKH.AutoSize = true;
            this.lblEmailKH.Location = new System.Drawing.Point(15, 98);
            this.lblEmailKH.Name = "lblEmailKH";
            this.lblEmailKH.Size = new System.Drawing.Size(46, 17);
            this.lblEmailKH.TabIndex = 11;
            this.lblEmailKH.Text = "Email:";
            // 
            // txtSDTKH
            // 
            this.txtSDTKH.Location = new System.Drawing.Point(620, 56);
            this.txtSDTKH.Name = "txtSDTKH";
            this.txtSDTKH.Size = new System.Drawing.Size(140, 22);
            this.txtSDTKH.TabIndex = 10;
            // 
            // lblSDTKH
            // 
            this.lblSDTKH.AutoSize = true;
            this.lblSDTKH.Location = new System.Drawing.Point(565, 59);
            this.lblSDTKH.Name = "lblSDTKH";
            this.lblSDTKH.Size = new System.Drawing.Size(40, 17);
            this.lblSDTKH.TabIndex = 9;
            this.lblSDTKH.Text = "SĐT:";
            // 
            // txtMST
            // 
            this.txtMST.Location = new System.Drawing.Point(400, 56);
            this.txtMST.Name = "txtMST";
            this.txtMST.Size = new System.Drawing.Size(140, 22);
            this.txtMST.TabIndex = 8;
            // 
            // lblMST
            // 
            this.lblMST.AutoSize = true;
            this.lblMST.Location = new System.Drawing.Point(335, 59);
            this.lblMST.Name = "lblMST";
            this.lblMST.Size = new System.Drawing.Size(41, 17);
            this.lblMST.TabIndex = 7;
            this.lblMST.Text = "MST:";
            // 
            // btnThemKH
            // 
            this.btnThemKH.Location = new System.Drawing.Point(740, 90);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(140, 32);
            this.btnThemKH.TabIndex = 6;
            this.btnThemKH.Text = "Thêm khách hàng";
            this.btnThemKH.UseVisualStyleBackColor = true;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // txtNguoiDaiDien
            // 
            this.txtNguoiDaiDien.Location = new System.Drawing.Point(100, 56);
            this.txtNguoiDaiDien.Name = "txtNguoiDaiDien";
            this.txtNguoiDaiDien.Size = new System.Drawing.Size(200, 22);
            this.txtNguoiDaiDien.TabIndex = 5;
            // 
            // lblNguoiDaiDien
            // 
            this.lblNguoiDaiDien.AutoSize = true;
            this.lblNguoiDaiDien.Location = new System.Drawing.Point(15, 59);
            this.lblNguoiDaiDien.Name = "lblNguoiDaiDien";
            this.lblNguoiDaiDien.Size = new System.Drawing.Size(64, 17);
            this.lblNguoiDaiDien.TabIndex = 4;
            this.lblNguoiDaiDien.Text = "Đại diện:";
            // 
            // txtTenCongTy
            // 
            this.txtTenCongTy.Location = new System.Drawing.Point(340, 20);
            this.txtTenCongTy.Name = "txtTenCongTy";
            this.txtTenCongTy.Size = new System.Drawing.Size(380, 22);
            this.txtTenCongTy.TabIndex = 3;
            // 
            // lblTenCongTy
            // 
            this.lblTenCongTy.AutoSize = true;
            this.lblTenCongTy.Location = new System.Drawing.Point(245, 23);
            this.lblTenCongTy.Name = "lblTenCongTy";
            this.lblTenCongTy.Size = new System.Drawing.Size(87, 17);
            this.lblTenCongTy.TabIndex = 2;
            this.lblTenCongTy.Text = "Tên công ty:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(100, 20);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(130, 22);
            this.txtMaKH.TabIndex = 1;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(15, 23);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(54, 17);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã KH:";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(785, 530);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 32);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 570);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabDanhMuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Danh Mục Nền Tảng (Tầng, Phòng, Dịch Vụ, Khách Hàng)";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabDanhMuc.ResumeLayout(false);
            this.tabTang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTang)).EndInit();
            this.pnlTang.ResumeLayout(false);
            this.pnlTang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeSoGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDoCao)).EndInit();
            this.tabPhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.pnlPhong.ResumeLayout(false);
            this.pnlPhong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaCoBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDienTich)).EndInit();
            this.tabDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.pnlDichVu.ResumeLayout(false);
            this.pnlDichVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaDV)).EndInit();
            this.tabKhachHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.pnlKhachHang.ResumeLayout(false);
            this.pnlKhachHang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDanhMuc;
        private System.Windows.Forms.TabPage tabTang;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.TabPage tabKhachHang;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel pnlTang;
        private System.Windows.Forms.Button btnThemTang;
        private System.Windows.Forms.TextBox txtGhiChuTang;
        private System.Windows.Forms.Label lblGhiChuTang;
        private System.Windows.Forms.NumericUpDown numHeSoGia;
        private System.Windows.Forms.Label lblHeSoGia;
        private System.Windows.Forms.NumericUpDown numDoCao;
        private System.Windows.Forms.Label lblDoCao;
        private System.Windows.Forms.TextBox txtTenTang;
        private System.Windows.Forms.Label lblTenTang;
        private System.Windows.Forms.TextBox txtMaTang;
        private System.Windows.Forms.Label lblMaTang;
        private System.Windows.Forms.DataGridView dgvTang;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.Panel pnlPhong;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.NumericUpDown numDonGiaCoBan;
        private System.Windows.Forms.Label lblDonGiaCoBan;
        private System.Windows.Forms.ComboBox cboHuong;
        private System.Windows.Forms.Label lblHuong;
        private System.Windows.Forms.NumericUpDown numDienTich;
        private System.Windows.Forms.Label lblDienTich;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.ComboBox cboTangPhong;
        private System.Windows.Forms.Label lblTangPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Panel pnlDichVu;
        private System.Windows.Forms.ComboBox cboLoaiDV;
        private System.Windows.Forms.Label lblLoaiDV;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.NumericUpDown numDonGiaDV;
        private System.Windows.Forms.Label lblDonGiaDV;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label lblTenDV;
        private System.Windows.Forms.TextBox txtMaDV;
        private System.Windows.Forms.Label lblMaDV;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Panel pnlKhachHang;
        private System.Windows.Forms.TextBox txtDiaChiKH;
        private System.Windows.Forms.Label lblDiaChiKH;
        private System.Windows.Forms.TextBox txtEmailKH;
        private System.Windows.Forms.Label lblEmailKH;
        private System.Windows.Forms.TextBox txtSDTKH;
        private System.Windows.Forms.Label lblSDTKH;
        private System.Windows.Forms.TextBox txtMST;
        private System.Windows.Forms.Label lblMST;
        private System.Windows.Forms.Button btnThemKH;
        private System.Windows.Forms.TextBox txtNguoiDaiDien;
        private System.Windows.Forms.Label lblNguoiDaiDien;
        private System.Windows.Forms.TextBox txtTenCongTy;
        private System.Windows.Forms.Label lblTenCongTy;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblMaKH;
    }
}
