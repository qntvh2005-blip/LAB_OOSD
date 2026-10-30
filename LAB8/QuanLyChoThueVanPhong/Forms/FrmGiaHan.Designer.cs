namespace QuanLyChoThueVanPhong.Forms
{
    partial class FrmGiaHan
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
            this.grpGiaHan = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLapPhieuGiaHan = new System.Windows.Forms.Button();
            this.lblTrangThaiNoDV = new System.Windows.Forms.Label();
            this.lblTrangThaiNoThue = new System.Windows.Forms.Label();
            this.lblThoiHanGoc = new System.Windows.Forms.Label();
            this.numDonGiaMoi = new System.Windows.Forms.NumericUpDown();
            this.lblDonGiaMoi = new System.Windows.Forms.Label();
            this.numSoThangGiaHan = new System.Windows.Forms.NumericUpDown();
            this.lblSoThangGiaHan = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboHopDong = new System.Windows.Forms.ComboBox();
            this.lblHopDong = new System.Windows.Forms.Label();
            this.txtMaPGH = new System.Windows.Forms.TextBox();
            this.lblMaPGH = new System.Windows.Forms.Label();
            this.tabGiaHan = new System.Windows.Forms.TabControl();
            this.tabPhieuGH = new System.Windows.Forms.TabPage();
            this.dgvPhieuGiaHan = new System.Windows.Forms.DataGridView();
            this.tabNoThue = new System.Windows.Forms.TabPage();
            this.dgvNoTienThue = new System.Windows.Forms.DataGridView();
            this.tabNoDV = new System.Windows.Forms.TabPage();
            this.dgvNoDichVu = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.grpGiaHan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaMoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThangGiaHan)).BeginInit();
            this.tabGiaHan.SuspendLayout();
            this.tabPhieuGH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuGiaHan)).BeginInit();
            this.tabNoThue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoTienThue)).BeginInit();
            this.tabNoDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoDichVu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.grpGiaHan);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(8);
            this.pnlTop.Size = new System.Drawing.Size(1004, 210);
            this.pnlTop.TabIndex = 0;
            // 
            // grpGiaHan
            // 
            this.grpGiaHan.Controls.Add(this.btnLamMoi);
            this.grpGiaHan.Controls.Add(this.btnLapPhieuGiaHan);
            this.grpGiaHan.Controls.Add(this.lblTrangThaiNoDV);
            this.grpGiaHan.Controls.Add(this.lblTrangThaiNoThue);
            this.grpGiaHan.Controls.Add(this.lblThoiHanGoc);
            this.grpGiaHan.Controls.Add(this.numDonGiaMoi);
            this.grpGiaHan.Controls.Add(this.lblDonGiaMoi);
            this.grpGiaHan.Controls.Add(this.numSoThangGiaHan);
            this.grpGiaHan.Controls.Add(this.lblSoThangGiaHan);
            this.grpGiaHan.Controls.Add(this.cboPhong);
            this.grpGiaHan.Controls.Add(this.lblPhong);
            this.grpGiaHan.Controls.Add(this.cboHopDong);
            this.grpGiaHan.Controls.Add(this.lblHopDong);
            this.grpGiaHan.Controls.Add(this.txtMaPGH);
            this.grpGiaHan.Controls.Add(this.lblMaPGH);
            this.grpGiaHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGiaHan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGiaHan.Location = new System.Drawing.Point(8, 8);
            this.grpGiaHan.Name = "grpGiaHan";
            this.grpGiaHan.Size = new System.Drawing.Size(988, 194);
            this.grpGiaHan.TabIndex = 0;
            this.grpGiaHan.TabStop = false;
            this.grpGiaHan.Text = "Lập Phiếu Gia Hạn Hợp Đồng Thuê (Quy định: <= 1/2 thời gian gốc và Không còn nợ)" +
    "";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(845, 148);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 32);
            this.btnLamMoi.TabIndex = 14;
            this.btnLamMoi.Text = "Tải lại";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnLapPhieuGiaHan
            // 
            this.btnLapPhieuGiaHan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnLapPhieuGiaHan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapPhieuGiaHan.ForeColor = System.Drawing.Color.White;
            this.btnLapPhieuGiaHan.Location = new System.Drawing.Point(630, 148);
            this.btnLapPhieuGiaHan.Name = "btnLapPhieuGiaHan";
            this.btnLapPhieuGiaHan.Size = new System.Drawing.Size(200, 32);
            this.btnLapPhieuGiaHan.TabIndex = 13;
            this.btnLapPhieuGiaHan.Text = "Lập Phiếu Gia Hạn";
            this.btnLapPhieuGiaHan.UseVisualStyleBackColor = false;
            this.btnLapPhieuGiaHan.Click += new System.EventHandler(this.btnLapPhieuGiaHan_Click);
            // 
            // lblTrangThaiNoDV
            // 
            this.lblTrangThaiNoDV.AutoSize = true;
            this.lblTrangThaiNoDV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThaiNoDV.ForeColor = System.Drawing.Color.Green;
            this.lblTrangThaiNoDV.Location = new System.Drawing.Point(20, 160);
            this.lblTrangThaiNoDV.Name = "lblTrangThaiNoDV";
            this.lblTrangThaiNoDV.Size = new System.Drawing.Size(147, 15);
            this.lblTrangThaiNoDV.TabIndex = 12;
            this.lblTrangThaiNoDV.Text = "Nợ dịch vụ: 0 đ (HỢP LỆ)";
            // 
            // lblTrangThaiNoThue
            // 
            this.lblTrangThaiNoThue.AutoSize = true;
            this.lblTrangThaiNoThue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThaiNoThue.ForeColor = System.Drawing.Color.Green;
            this.lblTrangThaiNoThue.Location = new System.Drawing.Point(20, 135);
            this.lblTrangThaiNoThue.Name = "lblTrangThaiNoThue";
            this.lblTrangThaiNoThue.Size = new System.Drawing.Size(158, 15);
            this.lblTrangThaiNoThue.TabIndex = 11;
            this.lblTrangThaiNoThue.Text = "Nợ tiền thuê: 0 đ (HỢP LỆ)";
            // 
            // lblThoiHanGoc
            // 
            this.lblThoiHanGoc.AutoSize = true;
            this.lblThoiHanGoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiHanGoc.ForeColor = System.Drawing.Color.Navy;
            this.lblThoiHanGoc.Location = new System.Drawing.Point(20, 110);
            this.lblThoiHanGoc.Name = "lblThoiHanGoc";
            this.lblThoiHanGoc.Size = new System.Drawing.Size(325, 15);
            this.lblThoiHanGoc.TabIndex = 10;
            this.lblThoiHanGoc.Text = "Thời hạn ban đầu: 12 tháng | Tối đa được gia hạn: 6 tháng";
            // 
            // numDonGiaMoi
            // 
            this.numDonGiaMoi.DecimalPlaces = 0;
            this.numDonGiaMoi.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numDonGiaMoi.Location = new System.Drawing.Point(540, 68);
            this.numDonGiaMoi.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numDonGiaMoi.Name = "numDonGiaMoi";
            this.numDonGiaMoi.Size = new System.Drawing.Size(180, 23);
            this.numDonGiaMoi.TabIndex = 9;
            this.numDonGiaMoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numDonGiaMoi.ThousandsSeparator = true;
            // 
            // lblDonGiaMoi
            // 
            this.lblDonGiaMoi.AutoSize = true;
            this.lblDonGiaMoi.Location = new System.Drawing.Point(420, 70);
            this.lblDonGiaMoi.Name = "lblDonGiaMoi";
            this.lblDonGiaMoi.Size = new System.Drawing.Size(107, 15);
            this.lblDonGiaMoi.TabIndex = 8;
            this.lblDonGiaMoi.Text = "Đơn giá mới (đ/m²):";
            // 
            // numSoThangGiaHan
            // 
            this.numSoThangGiaHan.Location = new System.Drawing.Point(140, 68);
            this.numSoThangGiaHan.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.numSoThangGiaHan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoThangGiaHan.Name = "numSoThangGiaHan";
            this.numSoThangGiaHan.Size = new System.Drawing.Size(180, 23);
            this.numSoThangGiaHan.TabIndex = 7;
            this.numSoThangGiaHan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSoThangGiaHan.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // lblSoThangGiaHan
            // 
            this.lblSoThangGiaHan.AutoSize = true;
            this.lblSoThangGiaHan.Location = new System.Drawing.Point(20, 70);
            this.lblSoThangGiaHan.Name = "lblSoThangGiaHan";
            this.lblSoThangGiaHan.Size = new System.Drawing.Size(100, 15);
            this.lblSoThangGiaHan.TabIndex = 6;
            this.lblSoThangGiaHan.Text = "Số tháng gia hạn:";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(740, 29);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(225, 23);
            this.cboPhong.TabIndex = 5;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(685, 32);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(45, 15);
            this.lblPhong.TabIndex = 4;
            this.lblPhong.Text = "Phòng:";
            // 
            // cboHopDong
            // 
            this.cboHopDong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHopDong.FormattingEnabled = true;
            this.cboHopDong.Location = new System.Drawing.Point(440, 29);
            this.cboHopDong.Name = "cboHopDong";
            this.cboHopDong.Size = new System.Drawing.Size(200, 23);
            this.cboHopDong.TabIndex = 3;
            this.cboHopDong.SelectedIndexChanged += new System.EventHandler(this.cboHopDong_SelectedIndexChanged);
            // 
            // lblHopDong
            // 
            this.lblHopDong.AutoSize = true;
            this.lblHopDong.Location = new System.Drawing.Point(365, 32);
            this.lblHopDong.Name = "lblHopDong";
            this.lblHopDong.Size = new System.Drawing.Size(64, 15);
            this.lblHopDong.TabIndex = 2;
            this.lblHopDong.Text = "Hợp đồng:";
            // 
            // txtMaPGH
            // 
            this.txtMaPGH.Location = new System.Drawing.Point(140, 29);
            this.txtMaPGH.Name = "txtMaPGH";
            this.txtMaPGH.Size = new System.Drawing.Size(180, 23);
            this.txtMaPGH.TabIndex = 1;
            // 
            // lblMaPGH
            // 
            this.lblMaPGH.AutoSize = true;
            this.lblMaPGH.Location = new System.Drawing.Point(20, 32);
            this.lblMaPGH.Name = "lblMaPGH";
            this.lblMaPGH.Size = new System.Drawing.Size(107, 15);
            this.lblMaPGH.TabIndex = 0;
            this.lblMaPGH.Text = "Mã phiếu gia hạn:";
            // 
            // tabGiaHan
            // 
            this.tabGiaHan.Controls.Add(this.tabPhieuGH);
            this.tabGiaHan.Controls.Add(this.tabNoThue);
            this.tabGiaHan.Controls.Add(this.tabNoDV);
            this.tabGiaHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGiaHan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabGiaHan.Location = new System.Drawing.Point(0, 210);
            this.tabGiaHan.Name = "tabGiaHan";
            this.tabGiaHan.SelectedIndex = 0;
            this.tabGiaHan.Size = new System.Drawing.Size(1004, 400);
            this.tabGiaHan.TabIndex = 1;
            // 
            // tabPhieuGH
            // 
            this.tabPhieuGH.Controls.Add(this.dgvPhieuGiaHan);
            this.tabPhieuGH.Location = new System.Drawing.Point(4, 24);
            this.tabPhieuGH.Name = "tabPhieuGH";
            this.tabPhieuGH.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhieuGH.Size = new System.Drawing.Size(996, 372);
            this.tabPhieuGH.TabIndex = 0;
            this.tabPhieuGH.Text = "Danh Sách Phiếu Gia Hạn Đã Lập";
            this.tabPhieuGH.UseVisualStyleBackColor = true;
            // 
            // dgvPhieuGiaHan
            // 
            this.dgvPhieuGiaHan.AllowUserToAddRows = false;
            this.dgvPhieuGiaHan.AllowUserToDeleteRows = false;
            this.dgvPhieuGiaHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuGiaHan.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieuGiaHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuGiaHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuGiaHan.Location = new System.Drawing.Point(3, 3);
            this.dgvPhieuGiaHan.MultiSelect = false;
            this.dgvPhieuGiaHan.Name = "dgvPhieuGiaHan";
            this.dgvPhieuGiaHan.ReadOnly = true;
            this.dgvPhieuGiaHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuGiaHan.Size = new System.Drawing.Size(990, 366);
            this.dgvPhieuGiaHan.TabIndex = 0;
            // 
            // tabNoThue
            // 
            this.tabNoThue.Controls.Add(this.dgvNoTienThue);
            this.tabNoThue.Location = new System.Drawing.Point(4, 24);
            this.tabNoThue.Name = "tabNoThue";
            this.tabNoThue.Padding = new System.Windows.Forms.Padding(3);
            this.tabNoThue.Size = new System.Drawing.Size(996, 372);
            this.tabNoThue.TabIndex = 1;
            this.tabNoThue.Text = "Chi Tiết Nợ Tiền Thuê (Của HĐ đang chọn)";
            this.tabNoThue.UseVisualStyleBackColor = true;
            // 
            // dgvNoTienThue
            // 
            this.dgvNoTienThue.AllowUserToAddRows = false;
            this.dgvNoTienThue.AllowUserToDeleteRows = false;
            this.dgvNoTienThue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNoTienThue.BackgroundColor = System.Drawing.Color.White;
            this.dgvNoTienThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoTienThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNoTienThue.Location = new System.Drawing.Point(3, 3);
            this.dgvNoTienThue.MultiSelect = false;
            this.dgvNoTienThue.Name = "dgvNoTienThue";
            this.dgvNoTienThue.ReadOnly = true;
            this.dgvNoTienThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNoTienThue.Size = new System.Drawing.Size(990, 366);
            this.dgvNoTienThue.TabIndex = 0;
            // 
            // tabNoDV
            // 
            this.tabNoDV.Controls.Add(this.dgvNoDichVu);
            this.tabNoDV.Location = new System.Drawing.Point(4, 24);
            this.tabNoDV.Name = "tabNoDV";
            this.tabNoDV.Padding = new System.Windows.Forms.Padding(3);
            this.tabNoDV.Size = new System.Drawing.Size(996, 372);
            this.tabNoDV.TabIndex = 2;
            this.tabNoDV.Text = "Chi Tiết Nợ Dịch Vụ (Của HĐ đang chọn)";
            this.tabNoDV.UseVisualStyleBackColor = true;
            // 
            // dgvNoDichVu
            // 
            this.dgvNoDichVu.AllowUserToAddRows = false;
            this.dgvNoDichVu.AllowUserToDeleteRows = false;
            this.dgvNoDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNoDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvNoDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNoDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNoDichVu.Location = new System.Drawing.Point(3, 3);
            this.dgvNoDichVu.MultiSelect = false;
            this.dgvNoDichVu.Name = "dgvNoDichVu";
            this.dgvNoDichVu.ReadOnly = true;
            this.dgvNoDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNoDichVu.Size = new System.Drawing.Size(990, 366);
            this.dgvNoDichVu.TabIndex = 0;
            // 
            // FrmGiaHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 610);
            this.Controls.Add(this.tabGiaHan);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1020, 630);
            this.Name = "FrmGiaHan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nghiệp Vụ Lập Phiếu Gia Hạn Hợp Đồng";
            this.pnlTop.ResumeLayout(false);
            this.grpGiaHan.ResumeLayout(false);
            this.grpGiaHan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGiaMoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThangGiaHan)).EndInit();
            this.tabGiaHan.ResumeLayout(false);
            this.tabPhieuGH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuGiaHan)).EndInit();
            this.tabNoThue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoTienThue)).EndInit();
            this.tabNoDV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoDichVu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox grpGiaHan;
        private System.Windows.Forms.TextBox txtMaPGH;
        private System.Windows.Forms.Label lblMaPGH;
        private System.Windows.Forms.ComboBox cboHopDong;
        private System.Windows.Forms.Label lblHopDong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.NumericUpDown numSoThangGiaHan;
        private System.Windows.Forms.Label lblSoThangGiaHan;
        private System.Windows.Forms.NumericUpDown numDonGiaMoi;
        private System.Windows.Forms.Label lblDonGiaMoi;
        private System.Windows.Forms.Label lblThoiHanGoc;
        private System.Windows.Forms.Label lblTrangThaiNoThue;
        private System.Windows.Forms.Label lblTrangThaiNoDV;
        private System.Windows.Forms.Button btnLapPhieuGiaHan;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TabControl tabGiaHan;
        private System.Windows.Forms.TabPage tabPhieuGH;
        private System.Windows.Forms.DataGridView dgvPhieuGiaHan;
        private System.Windows.Forms.TabPage tabNoThue;
        private System.Windows.Forms.DataGridView dgvNoTienThue;
        private System.Windows.Forms.TabPage tabNoDV;
        private System.Windows.Forms.DataGridView dgvNoDichVu;
    }
}
