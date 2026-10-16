namespace QuanLyBenhAn.Forms
{
    partial class FrmToaThuoc
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
            this.pnlToa = new System.Windows.Forms.Panel();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnLapToa = new System.Windows.Forms.Button();
            this.txtLoiDan = new System.Windows.Forms.TextBox();
            this.lblLoiDan = new System.Windows.Forms.Label();
            this.cboPhieuKham = new System.Windows.Forms.ComboBox();
            this.lblPhieuKham = new System.Windows.Forms.Label();
            this.txtMaToa = new System.Windows.Forms.TextBox();
            this.lblMaToa = new System.Windows.Forms.Label();
            this.grpThemThuoc = new System.Windows.Forms.GroupBox();
            this.btnXoaThuoc = new System.Windows.Forms.Button();
            this.btnThemThuoc = new System.Windows.Forms.Button();
            this.txtCachDung = new System.Windows.Forms.TextBox();
            this.lblCachDung = new System.Windows.Forms.Label();
            this.txtLieuDung = new System.Windows.Forms.TextBox();
            this.lblLieuDung = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.cboThuoc = new System.Windows.Forms.ComboBox();
            this.lblThuoc = new System.Windows.Forms.Label();
            this.dgvThuocTrongToa = new System.Windows.Forms.DataGridView();
            this.dgvToaThuoc = new System.Windows.Forms.DataGridView();
            this.lblToaDaKe = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlToa.SuspendLayout();
            this.grpThemThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuocTrongToa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToaThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlToa
            // 
            this.pnlToa.Controls.Add(this.lblTongTien);
            this.pnlToa.Controls.Add(this.btnLapToa);
            this.pnlToa.Controls.Add(this.txtLoiDan);
            this.pnlToa.Controls.Add(this.lblLoiDan);
            this.pnlToa.Controls.Add(this.cboPhieuKham);
            this.pnlToa.Controls.Add(this.lblPhieuKham);
            this.pnlToa.Controls.Add(this.txtMaToa);
            this.pnlToa.Controls.Add(this.lblMaToa);
            this.pnlToa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToa.Location = new System.Drawing.Point(0, 0);
            this.pnlToa.Name = "pnlToa";
            this.pnlToa.Size = new System.Drawing.Size(984, 105);
            this.pnlToa.TabIndex = 0;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongTien.Location = new System.Drawing.Point(545, 62);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(182, 23);
            this.lblTongTien.TabIndex = 7;
            this.lblTongTien.Text = "Tổng tiền thuốc: 0 đ";
            // 
            // btnLapToa
            // 
            this.btnLapToa.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnLapToa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapToa.ForeColor = System.Drawing.Color.White;
            this.btnLapToa.Location = new System.Drawing.Point(790, 48);
            this.btnLapToa.Name = "btnLapToa";
            this.btnLapToa.Size = new System.Drawing.Size(175, 45);
            this.btnLapToa.TabIndex = 6;
            this.btnLapToa.Text = "LẬP TOA THUỐC";
            this.btnLapToa.UseVisualStyleBackColor = false;
            this.btnLapToa.Click += new System.EventHandler(this.btnLapToa_Click);
            // 
            // txtLoiDan
            // 
            this.txtLoiDan.Location = new System.Drawing.Point(100, 60);
            this.txtLoiDan.Name = "txtLoiDan";
            this.txtLoiDan.Size = new System.Drawing.Size(430, 22);
            this.txtLoiDan.TabIndex = 5;
            // 
            // lblLoiDan
            // 
            this.lblLoiDan.AutoSize = true;
            this.lblLoiDan.Location = new System.Drawing.Point(15, 63);
            this.lblLoiDan.Name = "lblLoiDan";
            this.lblLoiDan.Size = new System.Drawing.Size(59, 17);
            this.lblLoiDan.TabIndex = 4;
            this.lblLoiDan.Text = "Lời dặn:";
            // 
            // cboPhieuKham
            // 
            this.cboPhieuKham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieuKham.FormattingEnabled = true;
            this.cboPhieuKham.Location = new System.Drawing.Point(365, 20);
            this.cboPhieuKham.Name = "cboPhieuKham";
            this.cboPhieuKham.Size = new System.Drawing.Size(400, 24);
            this.cboPhieuKham.TabIndex = 3;
            // 
            // lblPhieuKham
            // 
            this.lblPhieuKham.AutoSize = true;
            this.lblPhieuKham.Location = new System.Drawing.Point(275, 23);
            this.lblPhieuKham.Name = "lblPhieuKham";
            this.lblPhieuKham.Size = new System.Drawing.Size(86, 17);
            this.lblPhieuKham.TabIndex = 2;
            this.lblPhieuKham.Text = "Phiếu khám:";
            // 
            // txtMaToa
            // 
            this.txtMaToa.Location = new System.Drawing.Point(100, 20);
            this.txtMaToa.Name = "txtMaToa";
            this.txtMaToa.Size = new System.Drawing.Size(150, 22);
            this.txtMaToa.TabIndex = 1;
            // 
            // lblMaToa
            // 
            this.lblMaToa.AutoSize = true;
            this.lblMaToa.Location = new System.Drawing.Point(15, 23);
            this.lblMaToa.Name = "lblMaToa";
            this.lblMaToa.Size = new System.Drawing.Size(55, 17);
            this.lblMaToa.TabIndex = 0;
            this.lblMaToa.Text = "Mã toa:";
            // 
            // grpThemThuoc
            // 
            this.grpThemThuoc.Controls.Add(this.btnXoaThuoc);
            this.grpThemThuoc.Controls.Add(this.btnThemThuoc);
            this.grpThemThuoc.Controls.Add(this.txtCachDung);
            this.grpThemThuoc.Controls.Add(this.lblCachDung);
            this.grpThemThuoc.Controls.Add(this.txtLieuDung);
            this.grpThemThuoc.Controls.Add(this.lblLieuDung);
            this.grpThemThuoc.Controls.Add(this.numSoLuong);
            this.grpThemThuoc.Controls.Add(this.lblSoLuong);
            this.grpThemThuoc.Controls.Add(this.cboThuoc);
            this.grpThemThuoc.Controls.Add(this.lblThuoc);
            this.grpThemThuoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThemThuoc.Location = new System.Drawing.Point(0, 105);
            this.grpThemThuoc.Name = "grpThemThuoc";
            this.grpThemThuoc.Size = new System.Drawing.Size(984, 85);
            this.grpThemThuoc.TabIndex = 1;
            this.grpThemThuoc.TabStop = false;
            this.grpThemThuoc.Text = "Chọn thuốc đưa vào toa";
            // 
            // btnXoaThuoc
            // 
            this.btnXoaThuoc.Location = new System.Drawing.Point(880, 48);
            this.btnXoaThuoc.Name = "btnXoaThuoc";
            this.btnXoaThuoc.Size = new System.Drawing.Size(85, 28);
            this.btnXoaThuoc.TabIndex = 9;
            this.btnXoaThuoc.Text = "Xóa dòng";
            this.btnXoaThuoc.UseVisualStyleBackColor = true;
            this.btnXoaThuoc.Click += new System.EventHandler(this.btnXoaThuoc_Click);
            // 
            // btnThemThuoc
            // 
            this.btnThemThuoc.Location = new System.Drawing.Point(765, 48);
            this.btnThemThuoc.Name = "btnThemThuoc";
            this.btnThemThuoc.Size = new System.Drawing.Size(105, 28);
            this.btnThemThuoc.TabIndex = 8;
            this.btnThemThuoc.Text = "Thêm thuốc";
            this.btnThemThuoc.UseVisualStyleBackColor = true;
            this.btnThemThuoc.Click += new System.EventHandler(this.btnThemThuoc_Click);
            // 
            // txtCachDung
            // 
            this.txtCachDung.Location = new System.Drawing.Point(440, 52);
            this.txtCachDung.Name = "txtCachDung";
            this.txtCachDung.Size = new System.Drawing.Size(305, 22);
            this.txtCachDung.TabIndex = 7;
            // 
            // lblCachDung
            // 
            this.lblCachDung.AutoSize = true;
            this.lblCachDung.Location = new System.Drawing.Point(360, 55);
            this.lblCachDung.Name = "lblCachDung";
            this.lblCachDung.Size = new System.Drawing.Size(80, 17);
            this.lblCachDung.TabIndex = 6;
            this.lblCachDung.Text = "Cách dùng:";
            // 
            // txtLieuDung
            // 
            this.txtLieuDung.Location = new System.Drawing.Point(100, 52);
            this.txtLieuDung.Name = "txtLieuDung";
            this.txtLieuDung.Size = new System.Drawing.Size(240, 22);
            this.txtLieuDung.TabIndex = 5;
            // 
            // lblLieuDung
            // 
            this.lblLieuDung.AutoSize = true;
            this.lblLieuDung.Location = new System.Drawing.Point(15, 55);
            this.lblLieuDung.Name = "lblLieuDung";
            this.lblLieuDung.Size = new System.Drawing.Size(75, 17);
            this.lblLieuDung.TabIndex = 4;
            this.lblLieuDung.Text = "Liều dùng:";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(440, 21);
            this.numSoLuong.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(90, 22);
            this.numSoLuong.TabIndex = 3;
            this.numSoLuong.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(365, 24);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(68, 17);
            this.lblSoLuong.TabIndex = 2;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // cboThuoc
            // 
            this.cboThuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThuoc.FormattingEnabled = true;
            this.cboThuoc.Location = new System.Drawing.Point(100, 20);
            this.cboThuoc.Name = "cboThuoc";
            this.cboThuoc.Size = new System.Drawing.Size(240, 24);
            this.cboThuoc.TabIndex = 1;
            // 
            // lblThuoc
            // 
            this.lblThuoc.AutoSize = true;
            this.lblThuoc.Location = new System.Drawing.Point(15, 24);
            this.lblThuoc.Name = "lblThuoc";
            this.lblThuoc.Size = new System.Drawing.Size(52, 17);
            this.lblThuoc.TabIndex = 0;
            this.lblThuoc.Text = "Thuốc:";
            // 
            // dgvThuocTrongToa
            // 
            this.dgvThuocTrongToa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuocTrongToa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuocTrongToa.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvThuocTrongToa.Location = new System.Drawing.Point(0, 190);
            this.dgvThuocTrongToa.Name = "dgvThuocTrongToa";
            this.dgvThuocTrongToa.RowHeadersWidth = 51;
            this.dgvThuocTrongToa.RowTemplate.Height = 24;
            this.dgvThuocTrongToa.Size = new System.Drawing.Size(984, 160);
            this.dgvThuocTrongToa.TabIndex = 2;
            // 
            // dgvToaThuoc
            // 
            this.dgvToaThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToaThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToaThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvToaThuoc.Location = new System.Drawing.Point(0, 375);
            this.dgvToaThuoc.Name = "dgvToaThuoc";
            this.dgvToaThuoc.RowHeadersWidth = 51;
            this.dgvToaThuoc.RowTemplate.Height = 24;
            this.dgvToaThuoc.Size = new System.Drawing.Size(984, 185);
            this.dgvToaThuoc.TabIndex = 3;
            // 
            // lblToaDaKe
            // 
            this.lblToaDaKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblToaDaKe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToaDaKe.Location = new System.Drawing.Point(0, 350);
            this.lblToaDaKe.Name = "lblToaDaKe";
            this.lblToaDaKe.Size = new System.Drawing.Size(984, 25);
            this.lblToaDaKe.TabIndex = 4;
            this.lblToaDaKe.Text = "Danh sách các toa thuốc đã kê trong hệ thống:";
            this.lblToaDaKe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(860, 565);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmToaThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 602);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvToaThuoc);
            this.Controls.Add(this.lblToaDaKe);
            this.Controls.Add(this.dgvThuocTrongToa);
            this.Controls.Add(this.grpThemThuoc);
            this.Controls.Add(this.pnlToa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmToaThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kê Toa Thuốc Điều Trị Theo Đợt Khám (Nhiều Thuốc Trong 1 Toa)";
            this.Load += new System.EventHandler(this.FrmToaThuoc_Load);
            this.pnlToa.ResumeLayout(false);
            this.pnlToa.PerformLayout();
            this.grpThemThuoc.ResumeLayout(false);
            this.grpThemThuoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuocTrongToa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToaThuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToa;
        private System.Windows.Forms.Label lblMaToa;
        private System.Windows.Forms.TextBox txtMaToa;
        private System.Windows.Forms.Label lblPhieuKham;
        private System.Windows.Forms.ComboBox cboPhieuKham;
        private System.Windows.Forms.Label lblLoiDan;
        private System.Windows.Forms.TextBox txtLoiDan;
        private System.Windows.Forms.Button btnLapToa;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.GroupBox grpThemThuoc;
        private System.Windows.Forms.Label lblThuoc;
        private System.Windows.Forms.ComboBox cboThuoc;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblLieuDung;
        private System.Windows.Forms.TextBox txtLieuDung;
        private System.Windows.Forms.Label lblCachDung;
        private System.Windows.Forms.TextBox txtCachDung;
        private System.Windows.Forms.Button btnThemThuoc;
        private System.Windows.Forms.Button btnXoaThuoc;
        private System.Windows.Forms.DataGridView dgvThuocTrongToa;
        private System.Windows.Forms.DataGridView dgvToaThuoc;
        private System.Windows.Forms.Label lblToaDaKe;
        private System.Windows.Forms.Button btnDong;
    }
}
