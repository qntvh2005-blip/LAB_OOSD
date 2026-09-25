namespace QuanLyKhachSan.Forms
{
    partial class FrmDichVu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.lblField1 = new System.Windows.Forms.Label();
            this.cboLuot = new System.Windows.Forms.ComboBox();
            this.lblField2 = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblField3 = new System.Windows.Forms.Label();
            this.cboDV = new System.Windows.Forms.ComboBox();
            this.lblField4 = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.lblField5 = new System.Windows.Forms.Label();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.lblField6 = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.btnGhi = new System.Windows.Forms.Button();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.btnTai = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvLichSu_SoPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLichSu_NgaySuDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLichSu_TenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLichSu_SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLichSu_DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLichSu_ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // lblField1
            this.lblField1.Location = new System.Drawing.Point(25, 33);
            this.lblField1.Size = new System.Drawing.Size(110, 24);
            this.lblField1.Name = "lblField1";
            this.lblField1.TabIndex = 0;
            this.lblField1.Text = "Phiếu lưu trú:";
            this.lblField1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // cboLuot
            this.cboLuot.Location = new System.Drawing.Point(135, 30);
            this.cboLuot.Size = new System.Drawing.Size(250, 28);
            this.cboLuot.Name = "cboLuot";
            this.cboLuot.TabIndex = 1;
            this.cboLuot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLuot.FormattingEnabled = true;
            // lblField2
            this.lblField2.Location = new System.Drawing.Point(415, 33);
            this.lblField2.Size = new System.Drawing.Size(65, 24);
            this.lblField2.Name = "lblField2";
            this.lblField2.TabIndex = 2;
            this.lblField2.Text = "Phòng:";
            this.lblField2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // txtPhong
            this.txtPhong.Location = new System.Drawing.Point(480, 30);
            this.txtPhong.Size = new System.Drawing.Size(135, 28);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.TabIndex = 3;
            this.txtPhong.MaxLength = 120;
            this.txtPhong.ReadOnly = true;
            // lblField3
            this.lblField3.Location = new System.Drawing.Point(690, 33);
            this.lblField3.Size = new System.Drawing.Size(80, 24);
            this.lblField3.Name = "lblField3";
            this.lblField3.TabIndex = 4;
            this.lblField3.Text = "Dịch vụ:";
            this.lblField3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // cboDV
            this.cboDV.Location = new System.Drawing.Point(770, 30);
            this.cboDV.Size = new System.Drawing.Size(260, 28);
            this.cboDV.Name = "cboDV";
            this.cboDV.TabIndex = 5;
            this.cboDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDV.FormattingEnabled = true;
            // lblField4
            this.lblField4.Location = new System.Drawing.Point(25, 83);
            this.lblField4.Size = new System.Drawing.Size(110, 24);
            this.lblField4.Name = "lblField4";
            this.lblField4.TabIndex = 6;
            this.lblField4.Text = "Ngày sử dụng:";
            this.lblField4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // dtNgay
            this.dtNgay.Location = new System.Drawing.Point(135, 80);
            this.dtNgay.Size = new System.Drawing.Size(175, 28);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.TabIndex = 7;
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgay.CustomFormat = "dd/MM/yyyy";
            // lblField5
            this.lblField5.Location = new System.Drawing.Point(355, 83);
            this.lblField5.Size = new System.Drawing.Size(85, 24);
            this.lblField5.Name = "lblField5";
            this.lblField5.TabIndex = 8;
            this.lblField5.Text = "Số lượng:";
            this.lblField5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // numSL
            this.numSL.Location = new System.Drawing.Point(440, 80);
            this.numSL.Size = new System.Drawing.Size(100, 28);
            this.numSL.Name = "numSL";
            this.numSL.TabIndex = 9;
            this.numSL.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numSL.ThousandsSeparator = true;
            // lblField6
            this.lblField6.Location = new System.Drawing.Point(560, 83);
            this.lblField6.Size = new System.Drawing.Size(85, 24);
            this.lblField6.Name = "lblField6";
            this.lblField6.TabIndex = 10;
            this.lblField6.Text = "Nhân viên:";
            this.lblField6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // cboNV
            this.cboNV.Location = new System.Drawing.Point(645, 80);
            this.cboNV.Size = new System.Drawing.Size(190, 28);
            this.cboNV.Name = "cboNV";
            this.cboNV.TabIndex = 11;
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.FormattingEnabled = true;
            // btnGhi
            this.btnGhi.Location = new System.Drawing.Point(860, 79);
            this.btnGhi.Size = new System.Drawing.Size(170, 32);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.TabIndex = 12;
            this.btnGhi.Text = "Ghi nhận";
            this.btnGhi.UseVisualStyleBackColor = true;
            // dgvLichSu
            this.dgvLichSu.Location = new System.Drawing.Point(25, 145);
            this.dgvLichSu.Size = new System.Drawing.Size(1045, 425);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.TabIndex = 13;
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.AutoGenerateColumns = false;
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.MultiSelect = false;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvLichSu.RowHeadersWidth = 28;
            this.dgvLichSu.EnableHeadersVisualStyles = false;
            this.dgvLichSu.ColumnHeadersHeight = 30;
            this.dgvLichSu.RowTemplate.Height = 27;
            System.Windows.Forms.DataGridViewCellStyle dgvLichSuHeader = new System.Windows.Forms.DataGridViewCellStyle();
            dgvLichSuHeader.BackColor = System.Drawing.Color.FromArgb(220, 231, 241);
            dgvLichSuHeader.ForeColor = System.Drawing.Color.FromArgb(35, 45, 55);
            this.dgvLichSu.ColumnHeadersDefaultCellStyle = dgvLichSuHeader;
            this.dgvLichSu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgvLichSu_SoPhong, this.dgvLichSu_NgaySuDung, this.dgvLichSu_TenDV, this.dgvLichSu_SoLuong, this.dgvLichSu_DonGia, this.dgvLichSu_ThanhTien });
            // btnTai
            this.btnTai.Location = new System.Drawing.Point(780, 592);
            this.btnTai.Size = new System.Drawing.Size(130, 32);
            this.btnTai.Name = "btnTai";
            this.btnTai.TabIndex = 14;
            this.btnTai.Text = "Tải lại";
            this.btnTai.UseVisualStyleBackColor = true;
            // btnDong
            this.btnDong.Location = new System.Drawing.Point(940, 592);
            this.btnDong.Size = new System.Drawing.Size(130, 32);
            this.btnDong.Name = "btnDong";
            this.btnDong.TabIndex = 15;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.dgvLichSu_SoPhong.Name = "dgvLichSu_SoPhong";
            this.dgvLichSu_SoPhong.DataPropertyName = "SoPhong";
            this.dgvLichSu_SoPhong.HeaderText = "Phòng";
            this.dgvLichSu_SoPhong.ReadOnly = true;
            this.dgvLichSu_NgaySuDung.Name = "dgvLichSu_NgaySuDung";
            this.dgvLichSu_NgaySuDung.DataPropertyName = "NgaySuDung";
            this.dgvLichSu_NgaySuDung.HeaderText = "Ngày";
            this.dgvLichSu_NgaySuDung.ReadOnly = true;
            this.dgvLichSu_TenDV.Name = "dgvLichSu_TenDV";
            this.dgvLichSu_TenDV.DataPropertyName = "TenDV";
            this.dgvLichSu_TenDV.HeaderText = "Dịch vụ";
            this.dgvLichSu_TenDV.ReadOnly = true;
            this.dgvLichSu_SoLuong.Name = "dgvLichSu_SoLuong";
            this.dgvLichSu_SoLuong.DataPropertyName = "SoLuong";
            this.dgvLichSu_SoLuong.HeaderText = "Số lượng";
            this.dgvLichSu_SoLuong.ReadOnly = true;
            this.dgvLichSu_DonGia.Name = "dgvLichSu_DonGia";
            this.dgvLichSu_DonGia.DataPropertyName = "DonGia";
            this.dgvLichSu_DonGia.HeaderText = "Đơn giá";
            this.dgvLichSu_DonGia.ReadOnly = true;
            this.dgvLichSu_ThanhTien.Name = "dgvLichSu_ThanhTien";
            this.dgvLichSu_ThanhTien.DataPropertyName = "ThanhTien";
            this.dgvLichSu_ThanhTien.HeaderText = "Thành tiền";
            this.dgvLichSu_ThanhTien.ReadOnly = true;
            this.Controls.Add(this.lblField1);
            this.Controls.Add(this.cboLuot);
            this.Controls.Add(this.lblField2);
            this.Controls.Add(this.txtPhong);
            this.Controls.Add(this.lblField3);
            this.Controls.Add(this.cboDV);
            this.Controls.Add(this.lblField4);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.lblField5);
            this.Controls.Add(this.numSL);
            this.Controls.Add(this.lblField6);
            this.Controls.Add(this.cboNV);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.btnTai);
            this.Controls.Add(this.btnDong);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FrmDichVu";
            this.Text = "Sử dụng dịch vụ";
            this.Load += new System.EventHandler(this.FrmDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblField1;
        private System.Windows.Forms.ComboBox cboLuot;
        private System.Windows.Forms.Label lblField2;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblField3;
        private System.Windows.Forms.ComboBox cboDV;
        private System.Windows.Forms.Label lblField4;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label lblField5;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Label lblField6;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.Button btnTai;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLichSu_SoPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLichSu_NgaySuDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLichSu_TenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLichSu_SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLichSu_DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLichSu_ThanhTien;
    }
}
