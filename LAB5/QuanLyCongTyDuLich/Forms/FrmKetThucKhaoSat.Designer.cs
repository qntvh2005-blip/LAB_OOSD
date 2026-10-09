namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmKetThucKhaoSat
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

        private void InitializeComponent()
        {
            this.tabKT = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDoan = new System.Windows.Forms.DataGridView();
            this.txtSoTT = new System.Windows.Forms.TextBox();
            this.txtSoDK = new System.Windows.Forms.TextBox();
            this.dtTT = new System.Windows.Forms.DateTimePicker();
            this.numTien = new System.Windows.Forms.NumericUpDown();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboLoaiKS = new System.Windows.Forms.ComboBox();
            this.cboDangKy = new System.Windows.Forms.ComboBox();
            this.txtMaKS = new System.Windows.Forms.TextBox();
            this.dtGui = new System.Windows.Forms.DateTimePicker();
            this.btnGui = new System.Windows.Forms.Button();
            this.dgvKS = new System.Windows.Forms.DataGridView();
            this.txtKSChon = new System.Windows.Forms.TextBox();
            this.dtPH = new System.Windows.Forms.DateTimePicker();
            this.numDiem = new System.Windows.Forms.NumericUpDown();
            this.txtGopY = new System.Windows.Forms.TextBox();
            this.btnGhiPH = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabKT.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTien)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // tabKT
            // 
            this.tabKT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabKT.Controls.Add(this.tabPage1);
            this.tabKT.Controls.Add(this.tabPage2);
            this.tabKT.Location = new System.Drawing.Point(12, 12);
            this.tabKT.Name = "tabKT";
            this.tabKT.SelectedIndex = 0;
            this.tabKT.Size = new System.Drawing.Size(910, 560);
            this.tabKT.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnThanhToan);
            this.tabPage1.Controls.Add(this.txtGhiChu);
            this.tabPage1.Controls.Add(this.numTien);
            this.tabPage1.Controls.Add(this.dtTT);
            this.tabPage1.Controls.Add(this.txtSoDK);
            this.tabPage1.Controls.Add(this.txtSoTT);
            this.tabPage1.Controls.Add(this.dgvDoan);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(902, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thanh toán sau tour (đoàn)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDoan
            // 
            this.dgvDoan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoan.Location = new System.Drawing.Point(6, 172);
            this.dgvDoan.Name = "dgvDoan";
            this.dgvDoan.Size = new System.Drawing.Size(890, 356);
            this.dgvDoan.TabIndex = 0;
            this.dgvDoan.SelectionChanged += new System.EventHandler(this.dgvDoan_SelectionChanged);
            // 
            // txtSoTT
            // 
            this.txtSoTT.Location = new System.Drawing.Point(100, 16);
            this.txtSoTT.Name = "txtSoTT";
            this.txtSoTT.Size = new System.Drawing.Size(200, 20);
            this.txtSoTT.TabIndex = 1;
            // 
            // txtSoDK
            // 
            this.txtSoDK.Location = new System.Drawing.Point(100, 42);
            this.txtSoDK.Name = "txtSoDK";
            this.txtSoDK.Size = new System.Drawing.Size(200, 20);
            this.txtSoDK.TabIndex = 2;
            // 
            // dtTT
            // 
            this.dtTT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTT.Location = new System.Drawing.Point(100, 68);
            this.dtTT.Name = "dtTT";
            this.dtTT.Size = new System.Drawing.Size(200, 20);
            this.dtTT.TabIndex = 3;
            // 
            // numTien
            // 
            this.numTien.Location = new System.Drawing.Point(100, 94);
            this.numTien.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.numTien.Name = "numTien";
            this.numTien.Size = new System.Drawing.Size(200, 20);
            this.numTien.TabIndex = 4;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(100, 120);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(200, 20);
            this.txtGhiChu.TabIndex = 5;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(320, 14);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(120, 30);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Ghi nhận thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGhiPH);
            this.tabPage2.Controls.Add(this.txtGopY);
            this.tabPage2.Controls.Add(this.numDiem);
            this.tabPage2.Controls.Add(this.dtPH);
            this.tabPage2.Controls.Add(this.txtKSChon);
            this.tabPage2.Controls.Add(this.dgvKS);
            this.tabPage2.Controls.Add(this.btnGui);
            this.tabPage2.Controls.Add(this.dtGui);
            this.tabPage2.Controls.Add(this.txtMaKS);
            this.tabPage2.Controls.Add(this.cboDangKy);
            this.tabPage2.Controls.Add(this.cboLoaiKS);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(902, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Khảo sát khách hàng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboLoaiKS
            // 
            this.cboLoaiKS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiKS.FormattingEnabled = true;
            this.cboLoaiKS.Location = new System.Drawing.Point(100, 16);
            this.cboLoaiKS.Name = "cboLoaiKS";
            this.cboLoaiKS.Size = new System.Drawing.Size(200, 21);
            this.cboLoaiKS.TabIndex = 0;
            this.cboLoaiKS.SelectedIndexChanged += new System.EventHandler(this.cboLoaiKS_SelectedIndexChanged);
            // 
            // cboDangKy
            // 
            this.cboDangKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDangKy.FormattingEnabled = true;
            this.cboDangKy.Location = new System.Drawing.Point(100, 43);
            this.cboDangKy.Name = "cboDangKy";
            this.cboDangKy.Size = new System.Drawing.Size(200, 21);
            this.cboDangKy.TabIndex = 1;
            // 
            // txtMaKS
            // 
            this.txtMaKS.Location = new System.Drawing.Point(100, 70);
            this.txtMaKS.Name = "txtMaKS";
            this.txtMaKS.Size = new System.Drawing.Size(200, 20);
            this.txtMaKS.TabIndex = 2;
            // 
            // dtGui
            // 
            this.dtGui.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtGui.Location = new System.Drawing.Point(100, 96);
            this.dtGui.Name = "dtGui";
            this.dtGui.Size = new System.Drawing.Size(200, 20);
            this.dtGui.TabIndex = 3;
            // 
            // btnGui
            // 
            this.btnGui.Location = new System.Drawing.Point(100, 122);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(100, 30);
            this.btnGui.TabIndex = 4;
            this.btnGui.Text = "Gửi khảo sát";
            this.btnGui.UseVisualStyleBackColor = true;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // dgvKS
            // 
            this.dgvKS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKS.Location = new System.Drawing.Point(6, 172);
            this.dgvKS.Name = "dgvKS";
            this.dgvKS.Size = new System.Drawing.Size(890, 237);
            this.dgvKS.TabIndex = 5;
            this.dgvKS.SelectionChanged += new System.EventHandler(this.dgvKS_SelectionChanged);
            // 
            // txtKSChon
            // 
            this.txtKSChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtKSChon.Location = new System.Drawing.Point(100, 420);
            this.txtKSChon.Name = "txtKSChon";
            this.txtKSChon.ReadOnly = true;
            this.txtKSChon.Size = new System.Drawing.Size(200, 20);
            this.txtKSChon.TabIndex = 6;
            // 
            // dtPH
            // 
            this.dtPH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtPH.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPH.Location = new System.Drawing.Point(100, 446);
            this.dtPH.Name = "dtPH";
            this.dtPH.Size = new System.Drawing.Size(200, 20);
            this.dtPH.TabIndex = 7;
            // 
            // numDiem
            // 
            this.numDiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numDiem.Location = new System.Drawing.Point(100, 472);
            this.numDiem.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numDiem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDiem.Name = "numDiem";
            this.numDiem.Size = new System.Drawing.Size(200, 20);
            this.numDiem.TabIndex = 8;
            this.numDiem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtGopY
            // 
            this.txtGopY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGopY.Location = new System.Drawing.Point(100, 498);
            this.txtGopY.Name = "txtGopY";
            this.txtGopY.Size = new System.Drawing.Size(200, 20);
            this.txtGopY.TabIndex = 9;
            // 
            // btnGhiPH
            // 
            this.btnGhiPH.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGhiPH.Location = new System.Drawing.Point(320, 420);
            this.btnGhiPH.Name = "btnGhiPH";
            this.btnGhiPH.Size = new System.Drawing.Size(120, 30);
            this.btnGhiPH.TabIndex = 10;
            this.btnGhiPH.Text = "Ghi phản hồi";
            this.btnGhiPH.UseVisualStyleBackColor = true;
            this.btnGhiPH.Click += new System.EventHandler(this.btnGhiPH_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(822, 580);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmKetThucKhaoSat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 621);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabKT);
            this.Name = "FrmKetThucKhaoSat";
            this.Text = "Kết thúc tour - Khảo sát";
            this.Load += new System.EventHandler(this.FrmKetThucKhaoSat_Load);
            this.tabKT.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTien)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiem)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabKT;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDoan;
        private System.Windows.Forms.TextBox txtSoTT;
        private System.Windows.Forms.TextBox txtSoDK;
        private System.Windows.Forms.DateTimePicker dtTT;
        private System.Windows.Forms.NumericUpDown numTien;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cboLoaiKS;
        private System.Windows.Forms.ComboBox cboDangKy;
        private System.Windows.Forms.TextBox txtMaKS;
        private System.Windows.Forms.DateTimePicker dtGui;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.DataGridView dgvKS;
        private System.Windows.Forms.TextBox txtKSChon;
        private System.Windows.Forms.DateTimePicker dtPH;
        private System.Windows.Forms.NumericUpDown numDiem;
        private System.Windows.Forms.TextBox txtGopY;
        private System.Windows.Forms.Button btnGhiPH;
        private System.Windows.Forms.Button btnDong;
    }
}
