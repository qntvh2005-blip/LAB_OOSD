namespace QuanLyChoThueVanPhong.Forms
{
    partial class FrmKiemTraXuPhat
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
            this.tabKiemTra = new System.Windows.Forms.TabPage();
            this.dgvKiemTra = new System.Windows.Forms.DataGridView();
            this.pnlTopKT = new System.Windows.Forms.Panel();
            this.btnLuuKiemTra = new System.Windows.Forms.Button();
            this.txtGhiChuKT = new System.Windows.Forms.TextBox();
            this.lblGhiChuKT = new System.Windows.Forms.Label();
            this.chkDatYeuCau = new System.Windows.Forms.CheckBox();
            this.chkThayDoiKetCau = new System.Windows.Forms.CheckBox();
            this.txtHienTrang = new System.Windows.Forms.TextBox();
            this.lblHienTrang = new System.Windows.Forms.Label();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.txtNguoiKT = new System.Windows.Forms.TextBox();
            this.lblNguoiKT = new System.Windows.Forms.Label();
            this.cboPhongKT = new System.Windows.Forms.ComboBox();
            this.lblPhongKT = new System.Windows.Forms.Label();
            this.txtMaKT = new System.Windows.Forms.TextBox();
            this.lblMaKT = new System.Windows.Forms.Label();
            this.tabXuPhat = new System.Windows.Forms.TabPage();
            this.dgvXuPhat = new System.Windows.Forms.DataGridView();
            this.pnlBotXP = new System.Windows.Forms.Panel();
            this.btnNopTienPhat = new System.Windows.Forms.Button();
            this.pnlTopXP = new System.Windows.Forms.Panel();
            this.btnLapBienBan = new System.Windows.Forms.Button();
            this.txtBienPhap = new System.Windows.Forms.TextBox();
            this.lblBienPhap = new System.Windows.Forms.Label();
            this.dtpHanKhacPhuc = new System.Windows.Forms.DateTimePicker();
            this.lblHanKhacPhuc = new System.Windows.Forms.Label();
            this.numTienPhat = new System.Windows.Forms.NumericUpDown();
            this.lblTienPhat = new System.Windows.Forms.Label();
            this.txtLoiViPham = new System.Windows.Forms.TextBox();
            this.lblLoiViPham = new System.Windows.Forms.Label();
            this.cboPhongBB = new System.Windows.Forms.ComboBox();
            this.lblPhongBB = new System.Windows.Forms.Label();
            this.cboHopDongBB = new System.Windows.Forms.ComboBox();
            this.lblHopDongBB = new System.Windows.Forms.Label();
            this.cboPhieuKT = new System.Windows.Forms.ComboBox();
            this.lblPhieuKT = new System.Windows.Forms.Label();
            this.txtMaBB = new System.Windows.Forms.TextBox();
            this.lblMaBB = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabKiemTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemTra)).BeginInit();
            this.pnlTopKT.SuspendLayout();
            this.tabXuPhat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuPhat)).BeginInit();
            this.pnlBotXP.SuspendLayout();
            this.pnlTopXP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienPhat)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabKiemTra);
            this.tabMain.Controls.Add(this.tabXuPhat);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1004, 610);
            this.tabMain.TabIndex = 0;
            // 
            // tabKiemTra
            // 
            this.tabKiemTra.Controls.Add(this.dgvKiemTra);
            this.tabKiemTra.Controls.Add(this.pnlTopKT);
            this.tabKiemTra.Location = new System.Drawing.Point(4, 24);
            this.tabKiemTra.Name = "tabKiemTra";
            this.tabKiemTra.Padding = new System.Windows.Forms.Padding(3);
            this.tabKiemTra.Size = new System.Drawing.Size(996, 582);
            this.tabKiemTra.TabIndex = 0;
            this.tabKiemTra.Text = "Kiểm Tra Phòng Định Kỳ (1 năm/lần hoặc Đột Xuất)";
            this.tabKiemTra.UseVisualStyleBackColor = true;
            // 
            // dgvKiemTra
            // 
            this.dgvKiemTra.AllowUserToAddRows = false;
            this.dgvKiemTra.AllowUserToDeleteRows = false;
            this.dgvKiemTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKiemTra.BackgroundColor = System.Drawing.Color.White;
            this.dgvKiemTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKiemTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKiemTra.Location = new System.Drawing.Point(3, 118);
            this.dgvKiemTra.MultiSelect = false;
            this.dgvKiemTra.Name = "dgvKiemTra";
            this.dgvKiemTra.ReadOnly = true;
            this.dgvKiemTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKiemTra.Size = new System.Drawing.Size(990, 461);
            this.dgvKiemTra.TabIndex = 1;
            // 
            // pnlTopKT
            // 
            this.pnlTopKT.Controls.Add(this.btnLuuKiemTra);
            this.pnlTopKT.Controls.Add(this.txtGhiChuKT);
            this.pnlTopKT.Controls.Add(this.lblGhiChuKT);
            this.pnlTopKT.Controls.Add(this.chkDatYeuCau);
            this.pnlTopKT.Controls.Add(this.chkThayDoiKetCau);
            this.pnlTopKT.Controls.Add(this.txtHienTrang);
            this.pnlTopKT.Controls.Add(this.lblHienTrang);
            this.pnlTopKT.Controls.Add(this.dtpNgayKT);
            this.pnlTopKT.Controls.Add(this.lblNgayKT);
            this.pnlTopKT.Controls.Add(this.txtNguoiKT);
            this.pnlTopKT.Controls.Add(this.lblNguoiKT);
            this.pnlTopKT.Controls.Add(this.cboPhongKT);
            this.pnlTopKT.Controls.Add(this.lblPhongKT);
            this.pnlTopKT.Controls.Add(this.txtMaKT);
            this.pnlTopKT.Controls.Add(this.lblMaKT);
            this.pnlTopKT.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopKT.Location = new System.Drawing.Point(3, 3);
            this.pnlTopKT.Name = "pnlTopKT";
            this.pnlTopKT.Size = new System.Drawing.Size(990, 115);
            this.pnlTopKT.TabIndex = 0;
            // 
            // btnLuuKiemTra
            // 
            this.btnLuuKiemTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuKiemTra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLuuKiemTra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuKiemTra.ForeColor = System.Drawing.Color.White;
            this.btnLuuKiemTra.Location = new System.Drawing.Point(825, 67);
            this.btnLuuKiemTra.Name = "btnLuuKiemTra";
            this.btnLuuKiemTra.Size = new System.Drawing.Size(150, 32);
            this.btnLuuKiemTra.TabIndex = 14;
            this.btnLuuKiemTra.Text = "Lưu Phiếu KT";
            this.btnLuuKiemTra.UseVisualStyleBackColor = false;
            this.btnLuuKiemTra.Click += new System.EventHandler(this.btnLuuKiemTra_Click);
            // 
            // txtGhiChuKT
            // 
            this.txtGhiChuKT.Location = new System.Drawing.Point(440, 71);
            this.txtGhiChuKT.Name = "txtGhiChuKT";
            this.txtGhiChuKT.Size = new System.Drawing.Size(360, 23);
            this.txtGhiChuKT.TabIndex = 13;
            // 
            // lblGhiChuKT
            // 
            this.lblGhiChuKT.AutoSize = true;
            this.lblGhiChuKT.Location = new System.Drawing.Point(380, 75);
            this.lblGhiChuKT.Name = "lblGhiChuKT";
            this.lblGhiChuKT.Size = new System.Drawing.Size(51, 15);
            this.lblGhiChuKT.TabIndex = 12;
            this.lblGhiChuKT.Text = "Ghi chú:";
            // 
            // chkDatYeuCau
            // 
            this.chkDatYeuCau.AutoSize = true;
            this.chkDatYeuCau.Checked = true;
            this.chkDatYeuCau.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDatYeuCau.Location = new System.Drawing.Point(260, 74);
            this.chkDatYeuCau.Name = "chkDatYeuCau";
            this.chkDatYeuCau.Size = new System.Drawing.Size(91, 19);
            this.chkDatYeuCau.TabIndex = 11;
            this.chkDatYeuCau.Text = "Đạt yêu cầu";
            this.chkDatYeuCau.UseVisualStyleBackColor = true;
            // 
            // chkThayDoiKetCau
            // 
            this.chkThayDoiKetCau.AutoSize = true;
            this.chkThayDoiKetCau.ForeColor = System.Drawing.Color.Red;
            this.chkThayDoiKetCau.Location = new System.Drawing.Point(85, 74);
            this.chkThayDoiKetCau.Name = "chkThayDoiKetCau";
            this.chkThayDoiKetCau.Size = new System.Drawing.Size(149, 19);
            this.chkThayDoiKetCau.TabIndex = 10;
            this.chkThayDoiKetCau.Text = "TỰ Ý ĐỔI KẾT CẤU (!)";
            this.chkThayDoiKetCau.UseVisualStyleBackColor = true;
            // 
            // txtHienTrang
            // 
            this.txtHienTrang.Location = new System.Drawing.Point(750, 24);
            this.txtHienTrang.Name = "txtHienTrang";
            this.txtHienTrang.Size = new System.Drawing.Size(225, 23);
            this.txtHienTrang.TabIndex = 9;
            this.txtHienTrang.Text = "Văn phòng ngăn nắp, thiết bị hoạt động tốt";
            // 
            // lblHienTrang
            // 
            this.lblHienTrang.AutoSize = true;
            this.lblHienTrang.Location = new System.Drawing.Point(680, 27);
            this.lblHienTrang.Name = "lblHienTrang";
            this.lblHienTrang.Size = new System.Drawing.Size(65, 15);
            this.lblHienTrang.TabIndex = 8;
            this.lblHienTrang.Text = "Hiện trạng:";
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKT.Location = new System.Drawing.Point(545, 24);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(115, 23);
            this.dtpNgayKT.TabIndex = 7;
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.AutoSize = true;
            this.lblNgayKT.Location = new System.Drawing.Point(485, 27);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(55, 15);
            this.lblNgayKT.TabIndex = 6;
            this.lblNgayKT.Text = "Ngày KT:";
            // 
            // txtNguoiKT
            // 
            this.txtNguoiKT.Location = new System.Drawing.Point(340, 24);
            this.txtNguoiKT.Name = "txtNguoiKT";
            this.txtNguoiKT.Size = new System.Drawing.Size(125, 23);
            this.txtNguoiKT.TabIndex = 5;
            this.txtNguoiKT.Text = "Kỹ thuật tòa nhà";
            // 
            // lblNguoiKT
            // 
            this.lblNguoiKT.AutoSize = true;
            this.lblNguoiKT.Location = new System.Drawing.Point(275, 27);
            this.lblNguoiKT.Name = "lblNguoiKT";
            this.lblNguoiKT.Size = new System.Drawing.Size(60, 15);
            this.lblNguoiKT.TabIndex = 4;
            this.lblNguoiKT.Text = "Người KT:";
            // 
            // cboPhongKT
            // 
            this.cboPhongKT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongKT.FormattingEnabled = true;
            this.cboPhongKT.Location = new System.Drawing.Point(175, 24);
            this.cboPhongKT.Name = "cboPhongKT";
            this.cboPhongKT.Size = new System.Drawing.Size(85, 23);
            this.cboPhongKT.TabIndex = 3;
            // 
            // lblPhongKT
            // 
            this.lblPhongKT.AutoSize = true;
            this.lblPhongKT.Location = new System.Drawing.Point(125, 27);
            this.lblPhongKT.Name = "lblPhongKT";
            this.lblPhongKT.Size = new System.Drawing.Size(45, 15);
            this.lblPhongKT.TabIndex = 2;
            this.lblPhongKT.Text = "Phòng:";
            // 
            // txtMaKT
            // 
            this.txtMaKT.Location = new System.Drawing.Point(60, 24);
            this.txtMaKT.Name = "txtMaKT";
            this.txtMaKT.Size = new System.Drawing.Size(55, 23);
            this.txtMaKT.TabIndex = 1;
            // 
            // lblMaKT
            // 
            this.lblMaKT.AutoSize = true;
            this.lblMaKT.Location = new System.Drawing.Point(15, 27);
            this.lblMaKT.Name = "lblMaKT";
            this.lblMaKT.Size = new System.Drawing.Size(45, 15);
            this.lblMaKT.TabIndex = 0;
            this.lblMaKT.Text = "Mã KT:";
            // 
            // tabXuPhat
            // 
            this.tabXuPhat.Controls.Add(this.dgvXuPhat);
            this.tabXuPhat.Controls.Add(this.pnlBotXP);
            this.tabXuPhat.Controls.Add(this.pnlTopXP);
            this.tabXuPhat.Location = new System.Drawing.Point(4, 24);
            this.tabXuPhat.Name = "tabXuPhat";
            this.tabXuPhat.Padding = new System.Windows.Forms.Padding(3);
            this.tabXuPhat.Size = new System.Drawing.Size(996, 582);
            this.tabXuPhat.TabIndex = 1;
            this.tabXuPhat.Text = "Biên Bản Xử Phạt Vi Phạm Kết Cấu";
            this.tabXuPhat.UseVisualStyleBackColor = true;
            // 
            // dgvXuPhat
            // 
            this.dgvXuPhat.AllowUserToAddRows = false;
            this.dgvXuPhat.AllowUserToDeleteRows = false;
            this.dgvXuPhat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXuPhat.BackgroundColor = System.Drawing.Color.White;
            this.dgvXuPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXuPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvXuPhat.Location = new System.Drawing.Point(3, 118);
            this.dgvXuPhat.MultiSelect = false;
            this.dgvXuPhat.Name = "dgvXuPhat";
            this.dgvXuPhat.ReadOnly = true;
            this.dgvXuPhat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvXuPhat.Size = new System.Drawing.Size(990, 416);
            this.dgvXuPhat.TabIndex = 2;
            // 
            // pnlBotXP
            // 
            this.pnlBotXP.Controls.Add(this.btnNopTienPhat);
            this.pnlBotXP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotXP.Location = new System.Drawing.Point(3, 534);
            this.pnlBotXP.Name = "pnlBotXP";
            this.pnlBotXP.Size = new System.Drawing.Size(990, 45);
            this.pnlBotXP.TabIndex = 1;
            // 
            // btnNopTienPhat
            // 
            this.btnNopTienPhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnNopTienPhat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNopTienPhat.ForeColor = System.Drawing.Color.White;
            this.btnNopTienPhat.Location = new System.Drawing.Point(15, 6);
            this.btnNopTienPhat.Name = "btnNopTienPhat";
            this.btnNopTienPhat.Size = new System.Drawing.Size(200, 32);
            this.btnNopTienPhat.TabIndex = 0;
            this.btnNopTienPhat.Text = "Xác Nhận Nộp Tiền Phạt";
            this.btnNopTienPhat.UseVisualStyleBackColor = false;
            this.btnNopTienPhat.Click += new System.EventHandler(this.btnNopTienPhat_Click);
            // 
            // pnlTopXP
            // 
            this.pnlTopXP.Controls.Add(this.btnLapBienBan);
            this.pnlTopXP.Controls.Add(this.txtBienPhap);
            this.pnlTopXP.Controls.Add(this.lblBienPhap);
            this.pnlTopXP.Controls.Add(this.dtpHanKhacPhuc);
            this.pnlTopXP.Controls.Add(this.lblHanKhacPhuc);
            this.pnlTopXP.Controls.Add(this.numTienPhat);
            this.pnlTopXP.Controls.Add(this.lblTienPhat);
            this.pnlTopXP.Controls.Add(this.txtLoiViPham);
            this.pnlTopXP.Controls.Add(this.lblLoiViPham);
            this.pnlTopXP.Controls.Add(this.cboPhongBB);
            this.pnlTopXP.Controls.Add(this.lblPhongBB);
            this.pnlTopXP.Controls.Add(this.cboHopDongBB);
            this.pnlTopXP.Controls.Add(this.lblHopDongBB);
            this.pnlTopXP.Controls.Add(this.cboPhieuKT);
            this.pnlTopXP.Controls.Add(this.lblPhieuKT);
            this.pnlTopXP.Controls.Add(this.txtMaBB);
            this.pnlTopXP.Controls.Add(this.lblMaBB);
            this.pnlTopXP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopXP.Location = new System.Drawing.Point(3, 3);
            this.pnlTopXP.Name = "pnlTopXP";
            this.pnlTopXP.Size = new System.Drawing.Size(990, 115);
            this.pnlTopXP.TabIndex = 0;
            // 
            // btnLapBienBan
            // 
            this.btnLapBienBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLapBienBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLapBienBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapBienBan.ForeColor = System.Drawing.Color.White;
            this.btnLapBienBan.Location = new System.Drawing.Point(825, 68);
            this.btnLapBienBan.Name = "btnLapBienBan";
            this.btnLapBienBan.Size = new System.Drawing.Size(150, 32);
            this.btnLapBienBan.TabIndex = 16;
            this.btnLapBienBan.Text = "Lập Biên Bản Phạt";
            this.btnLapBienBan.UseVisualStyleBackColor = false;
            this.btnLapBienBan.Click += new System.EventHandler(this.btnLapBienBan_Click);
            // 
            // txtBienPhap
            // 
            this.txtBienPhap.Location = new System.Drawing.Point(535, 74);
            this.txtBienPhap.Name = "txtBienPhap";
            this.txtBienPhap.Size = new System.Drawing.Size(275, 23);
            this.txtBienPhap.TabIndex = 15;
            this.txtBienPhap.Text = "Yêu cầu khôi phục nguyên trạng trong 15 ngày";
            // 
            // lblBienPhap
            // 
            this.lblBienPhap.AutoSize = true;
            this.lblBienPhap.Location = new System.Drawing.Point(465, 77);
            this.lblBienPhap.Name = "lblBienPhap";
            this.lblBienPhap.Size = new System.Drawing.Size(63, 15);
            this.lblBienPhap.TabIndex = 14;
            this.lblBienPhap.Text = "Biện pháp:";
            // 
            // dtpHanKhacPhuc
            // 
            this.dtpHanKhacPhuc.CustomFormat = "dd/MM/yyyy";
            this.dtpHanKhacPhuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanKhacPhuc.Location = new System.Drawing.Point(340, 74);
            this.dtpHanKhacPhuc.Name = "dtpHanKhacPhuc";
            this.dtpHanKhacPhuc.Size = new System.Drawing.Size(110, 23);
            this.dtpHanKhacPhuc.TabIndex = 13;
            // 
            // lblHanKhacPhuc
            // 
            this.lblHanKhacPhuc.AutoSize = true;
            this.lblHanKhacPhuc.Location = new System.Drawing.Point(280, 77);
            this.lblHanKhacPhuc.Name = "lblHanKhacPhuc";
            this.lblHanKhacPhuc.Size = new System.Drawing.Size(53, 15);
            this.lblHanKhacPhuc.TabIndex = 12;
            this.lblHanKhacPhuc.Text = "Hạn KP:";
            // 
            // numTienPhat
            // 
            this.numTienPhat.DecimalPlaces = 0;
            this.numTienPhat.Increment = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numTienPhat.Location = new System.Drawing.Point(145, 74);
            this.numTienPhat.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numTienPhat.Name = "numTienPhat";
            this.numTienPhat.Size = new System.Drawing.Size(125, 23);
            this.numTienPhat.TabIndex = 11;
            this.numTienPhat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTienPhat.ThousandsSeparator = true;
            this.numTienPhat.Value = new decimal(new int[] { 10000000, 0, 0, 0 });
            // 
            // lblTienPhat
            // 
            this.lblTienPhat.AutoSize = true;
            this.lblTienPhat.Location = new System.Drawing.Point(80, 77);
            this.lblTienPhat.Name = "lblTienPhat";
            this.lblTienPhat.Size = new System.Drawing.Size(59, 15);
            this.lblTienPhat.TabIndex = 10;
            this.lblTienPhat.Text = "Tiền phạt:";
            // 
            // txtLoiViPham
            // 
            this.txtLoiViPham.Location = new System.Drawing.Point(680, 24);
            this.txtLoiViPham.Name = "txtLoiViPham";
            this.txtLoiViPham.Size = new System.Drawing.Size(295, 23);
            this.txtLoiViPham.TabIndex = 9;
            this.txtLoiViPham.Text = "Tự ý đập vách ngăn thạch cao không xin phép";
            // 
            // lblLoiViPham
            // 
            this.lblLoiViPham.AutoSize = true;
            this.lblLoiViPham.Location = new System.Drawing.Point(605, 27);
            this.lblLoiViPham.Name = "lblLoiViPham";
            this.lblLoiViPham.Size = new System.Drawing.Size(71, 15);
            this.lblLoiViPham.TabIndex = 8;
            this.lblLoiViPham.Text = "Lỗi vi phạm:";
            // 
            // cboPhongBB
            // 
            this.cboPhongBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongBB.FormattingEnabled = true;
            this.cboPhongBB.Location = new System.Drawing.Point(495, 24);
            this.cboPhongBB.Name = "cboPhongBB";
            this.cboPhongBB.Size = new System.Drawing.Size(95, 23);
            this.cboPhongBB.TabIndex = 7;
            // 
            // lblPhongBB
            // 
            this.lblPhongBB.AutoSize = true;
            this.lblPhongBB.Location = new System.Drawing.Point(445, 27);
            this.lblPhongBB.Name = "lblPhongBB";
            this.lblPhongBB.Size = new System.Drawing.Size(45, 15);
            this.lblPhongBB.TabIndex = 6;
            this.lblPhongBB.Text = "Phòng:";
            // 
            // cboHopDongBB
            // 
            this.cboHopDongBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHopDongBB.FormattingEnabled = true;
            this.cboHopDongBB.Location = new System.Drawing.Point(315, 24);
            this.cboHopDongBB.Name = "cboHopDongBB";
            this.cboHopDongBB.Size = new System.Drawing.Size(120, 23);
            this.cboHopDongBB.TabIndex = 5;
            // 
            // lblHopDongBB
            // 
            this.lblHopDongBB.AutoSize = true;
            this.lblHopDongBB.Location = new System.Drawing.Point(260, 27);
            this.lblHopDongBB.Name = "lblHopDongBB";
            this.lblHopDongBB.Size = new System.Drawing.Size(47, 15);
            this.lblHopDongBB.TabIndex = 4;
            this.lblHopDongBB.Text = "Mã HĐ:";
            // 
            // cboPhieuKT
            // 
            this.cboPhieuKT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieuKT.FormattingEnabled = true;
            this.cboPhieuKT.Location = new System.Drawing.Point(155, 24);
            this.cboPhieuKT.Name = "cboPhieuKT";
            this.cboPhieuKT.Size = new System.Drawing.Size(95, 23);
            this.cboPhieuKT.TabIndex = 3;
            // 
            // lblPhieuKT
            // 
            this.lblPhieuKT.AutoSize = true;
            this.lblPhieuKT.Location = new System.Drawing.Point(95, 27);
            this.lblPhieuKT.Name = "lblPhieuKT";
            this.lblPhieuKT.Size = new System.Drawing.Size(56, 15);
            this.lblPhieuKT.TabIndex = 2;
            this.lblPhieuKT.Text = "Phiếu KT:";
            // 
            // txtMaBB
            // 
            this.txtMaBB.Location = new System.Drawing.Point(45, 24);
            this.txtMaBB.Name = "txtMaBB";
            this.txtMaBB.Size = new System.Drawing.Size(45, 23);
            this.txtMaBB.TabIndex = 1;
            // 
            // lblMaBB
            // 
            this.lblMaBB.AutoSize = true;
            this.lblMaBB.Location = new System.Drawing.Point(15, 27);
            this.lblMaBB.Name = "lblMaBB";
            this.lblMaBB.Size = new System.Drawing.Size(26, 15);
            this.lblMaBB.TabIndex = 0;
            this.lblMaBB.Text = "BB:";
            // 
            // FrmKiemTraXuPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 610);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1020, 630);
            this.Name = "FrmKiemTraXuPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Kiểm Tra Phòng & Xử Phạt Vi Phạm Kết Cấu";
            this.tabMain.ResumeLayout(false);
            this.tabKiemTra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemTra)).EndInit();
            this.pnlTopKT.ResumeLayout(false);
            this.pnlTopKT.PerformLayout();
            this.tabXuPhat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuPhat)).EndInit();
            this.pnlBotXP.ResumeLayout(false);
            this.pnlTopXP.ResumeLayout(false);
            this.pnlTopXP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienPhat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabKiemTra;
        private System.Windows.Forms.Panel pnlTopKT;
        private System.Windows.Forms.TextBox txtMaKT;
        private System.Windows.Forms.Label lblMaKT;
        private System.Windows.Forms.ComboBox cboPhongKT;
        private System.Windows.Forms.Label lblPhongKT;
        private System.Windows.Forms.TextBox txtNguoiKT;
        private System.Windows.Forms.Label lblNguoiKT;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.TextBox txtHienTrang;
        private System.Windows.Forms.Label lblHienTrang;
        private System.Windows.Forms.CheckBox chkThayDoiKetCau;
        private System.Windows.Forms.CheckBox chkDatYeuCau;
        private System.Windows.Forms.TextBox txtGhiChuKT;
        private System.Windows.Forms.Label lblGhiChuKT;
        private System.Windows.Forms.Button btnLuuKiemTra;
        private System.Windows.Forms.DataGridView dgvKiemTra;
        private System.Windows.Forms.TabPage tabXuPhat;
        private System.Windows.Forms.Panel pnlTopXP;
        private System.Windows.Forms.TextBox txtMaBB;
        private System.Windows.Forms.Label lblMaBB;
        private System.Windows.Forms.ComboBox cboPhieuKT;
        private System.Windows.Forms.Label lblPhieuKT;
        private System.Windows.Forms.ComboBox cboHopDongBB;
        private System.Windows.Forms.Label lblHopDongBB;
        private System.Windows.Forms.ComboBox cboPhongBB;
        private System.Windows.Forms.Label lblPhongBB;
        private System.Windows.Forms.TextBox txtLoiViPham;
        private System.Windows.Forms.Label lblLoiViPham;
        private System.Windows.Forms.NumericUpDown numTienPhat;
        private System.Windows.Forms.Label lblTienPhat;
        private System.Windows.Forms.DateTimePicker dtpHanKhacPhuc;
        private System.Windows.Forms.Label lblHanKhacPhuc;
        private System.Windows.Forms.TextBox txtBienPhap;
        private System.Windows.Forms.Label lblBienPhap;
        private System.Windows.Forms.Button btnLapBienBan;
        private System.Windows.Forms.DataGridView dgvXuPhat;
        private System.Windows.Forms.Panel pnlBotXP;
        private System.Windows.Forms.Button btnNopTienPhat;
    }
}
