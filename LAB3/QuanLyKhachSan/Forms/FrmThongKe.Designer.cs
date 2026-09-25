namespace QuanLyKhachSan.Forms
{
    partial class FrmThongKe
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
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.lblField2 = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnTK = new System.Windows.Forms.Button();
            this.lblPhieu = new System.Windows.Forms.Label();
            this.lblDangO = new System.Windows.Forms.Label();
            this.lblHoaDon = new System.Windows.Forms.Label();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.lblDenBu = new System.Windows.Forms.Label();
            this.lblThucThu = new System.Windows.Forms.Label();
            this.lblField3 = new System.Windows.Forms.Label();
            this.dgvDV = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvDV_MaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDV_TenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDV_SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDV_ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            this.SuspendLayout();
            // lblField1
            this.lblField1.Location = new System.Drawing.Point(30, 33);
            this.lblField1.Size = new System.Drawing.Size(80, 24);
            this.lblField1.Name = "lblField1";
            this.lblField1.TabIndex = 0;
            this.lblField1.Text = "Từ ngày:";
            this.lblField1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // dtTu
            this.dtTu.Location = new System.Drawing.Point(110, 30);
            this.dtTu.Size = new System.Drawing.Size(175, 28);
            this.dtTu.Name = "dtTu";
            this.dtTu.TabIndex = 1;
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTu.CustomFormat = "dd/MM/yyyy";
            // lblField2
            this.lblField2.Location = new System.Drawing.Point(355, 33);
            this.lblField2.Size = new System.Drawing.Size(85, 24);
            this.lblField2.Name = "lblField2";
            this.lblField2.TabIndex = 2;
            this.lblField2.Text = "Đến ngày:";
            this.lblField2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // dtDen
            this.dtDen.Location = new System.Drawing.Point(440, 30);
            this.dtDen.Size = new System.Drawing.Size(175, 28);
            this.dtDen.Name = "dtDen";
            this.dtDen.TabIndex = 3;
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDen.CustomFormat = "dd/MM/yyyy";
            // btnTK
            this.btnTK.Location = new System.Drawing.Point(710, 28);
            this.btnTK.Size = new System.Drawing.Size(155, 32);
            this.btnTK.Name = "btnTK";
            this.btnTK.TabIndex = 4;
            this.btnTK.Text = "Thống kê";
            this.btnTK.UseVisualStyleBackColor = true;
            // lblPhieu
            this.lblPhieu.Location = new System.Drawing.Point(35, 105);
            this.lblPhieu.Size = new System.Drawing.Size(495, 33);
            this.lblPhieu.Name = "lblPhieu";
            this.lblPhieu.TabIndex = 5;
            this.lblPhieu.Text = "Phiếu đặt: —";
            this.lblPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhieu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPhieu.ForeColor = System.Drawing.Color.FromArgb(17, 60, 104);
            // lblDangO
            this.lblDangO.Location = new System.Drawing.Point(575, 105);
            this.lblDangO.Size = new System.Drawing.Size(495, 33);
            this.lblDangO.Name = "lblDangO";
            this.lblDangO.TabIndex = 6;
            this.lblDangO.Text = "Đang ở: —";
            this.lblDangO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDangO.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDangO.ForeColor = System.Drawing.Color.FromArgb(17, 60, 104);
            // lblHoaDon
            this.lblHoaDon.Location = new System.Drawing.Point(35, 155);
            this.lblHoaDon.Size = new System.Drawing.Size(495, 33);
            this.lblHoaDon.Name = "lblHoaDon";
            this.lblHoaDon.TabIndex = 7;
            this.lblHoaDon.Text = "Hóa đơn: —";
            this.lblHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHoaDon.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblHoaDon.ForeColor = System.Drawing.Color.FromArgb(17, 60, 104);
            // lblDoanhThu
            this.lblDoanhThu.Location = new System.Drawing.Point(575, 155);
            this.lblDoanhThu.Size = new System.Drawing.Size(495, 33);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.TabIndex = 8;
            this.lblDoanhThu.Text = "Doanh thu HĐ: —";
            this.lblDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.FromArgb(17, 60, 104);
            // lblDenBu
            this.lblDenBu.Location = new System.Drawing.Point(35, 205);
            this.lblDenBu.Size = new System.Drawing.Size(495, 33);
            this.lblDenBu.Name = "lblDenBu";
            this.lblDenBu.TabIndex = 9;
            this.lblDenBu.Text = "Tổng đền bù: —";
            this.lblDenBu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDenBu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblDenBu.ForeColor = System.Drawing.Color.FromArgb(17, 60, 104);
            // lblThucThu
            this.lblThucThu.Location = new System.Drawing.Point(575, 205);
            this.lblThucThu.Size = new System.Drawing.Size(495, 33);
            this.lblThucThu.Name = "lblThucThu";
            this.lblThucThu.TabIndex = 10;
            this.lblThucThu.Text = "Thực thu HĐ: —";
            this.lblThucThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblThucThu.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblThucThu.ForeColor = System.Drawing.Color.FromArgb(17, 60, 104);
            // lblField3
            this.lblField3.Location = new System.Drawing.Point(30, 270);
            this.lblField3.Size = new System.Drawing.Size(350, 24);
            this.lblField3.Name = "lblField3";
            this.lblField3.TabIndex = 11;
            this.lblField3.Text = "Dịch vụ sử dụng:";
            this.lblField3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // dgvDV
            this.dgvDV.Location = new System.Drawing.Point(30, 305);
            this.dgvDV.Size = new System.Drawing.Size(1040, 315);
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.TabIndex = 12;
            this.dgvDV.AllowUserToAddRows = false;
            this.dgvDV.AllowUserToDeleteRows = false;
            this.dgvDV.AutoGenerateColumns = false;
            this.dgvDV.ReadOnly = true;
            this.dgvDV.MultiSelect = false;
            this.dgvDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDV.BackgroundColor = System.Drawing.Color.White;
            this.dgvDV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvDV.RowHeadersWidth = 28;
            this.dgvDV.EnableHeadersVisualStyles = false;
            this.dgvDV.ColumnHeadersHeight = 30;
            this.dgvDV.RowTemplate.Height = 27;
            System.Windows.Forms.DataGridViewCellStyle dgvDVHeader = new System.Windows.Forms.DataGridViewCellStyle();
            dgvDVHeader.BackColor = System.Drawing.Color.FromArgb(220, 231, 241);
            dgvDVHeader.ForeColor = System.Drawing.Color.FromArgb(35, 45, 55);
            this.dgvDV.ColumnHeadersDefaultCellStyle = dgvDVHeader;
            this.dgvDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dgvDV_MaDV, this.dgvDV_TenDV, this.dgvDV_SoLuong, this.dgvDV_ThanhTien });
            // btnDong
            this.btnDong.Location = new System.Drawing.Point(940, 650);
            this.btnDong.Size = new System.Drawing.Size(130, 32);
            this.btnDong.Name = "btnDong";
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.dgvDV_MaDV.Name = "dgvDV_MaDV";
            this.dgvDV_MaDV.DataPropertyName = "MaDV";
            this.dgvDV_MaDV.HeaderText = "Mã DV";
            this.dgvDV_MaDV.ReadOnly = true;
            this.dgvDV_TenDV.Name = "dgvDV_TenDV";
            this.dgvDV_TenDV.DataPropertyName = "TenDV";
            this.dgvDV_TenDV.HeaderText = "Tên dịch vụ";
            this.dgvDV_TenDV.ReadOnly = true;
            this.dgvDV_SoLuong.Name = "dgvDV_SoLuong";
            this.dgvDV_SoLuong.DataPropertyName = "SoLuong";
            this.dgvDV_SoLuong.HeaderText = "Tổng số lượng";
            this.dgvDV_SoLuong.ReadOnly = true;
            this.dgvDV_ThanhTien.Name = "dgvDV_ThanhTien";
            this.dgvDV_ThanhTien.DataPropertyName = "ThanhTien";
            this.dgvDV_ThanhTien.HeaderText = "Tổng tiền";
            this.dgvDV_ThanhTien.ReadOnly = true;
            this.Controls.Add(this.lblField1);
            this.Controls.Add(this.dtTu);
            this.Controls.Add(this.lblField2);
            this.Controls.Add(this.dtDen);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.lblPhieu);
            this.Controls.Add(this.lblDangO);
            this.Controls.Add(this.lblHoaDon);
            this.Controls.Add(this.lblDoanhThu);
            this.Controls.Add(this.lblDenBu);
            this.Controls.Add(this.lblThucThu);
            this.Controls.Add(this.lblField3);
            this.Controls.Add(this.dgvDV);
            this.Controls.Add(this.btnDong);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 710);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FrmThongKe";
            this.Text = "Thống kê khách sạn";
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblField1;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label lblField2;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Label lblPhieu;
        private System.Windows.Forms.Label lblDangO;
        private System.Windows.Forms.Label lblHoaDon;
        private System.Windows.Forms.Label lblDoanhThu;
        private System.Windows.Forms.Label lblDenBu;
        private System.Windows.Forms.Label lblThucThu;
        private System.Windows.Forms.Label lblField3;
        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDV_MaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDV_TenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDV_SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDV_ThanhTien;
    }
}
