namespace QuanLyBenhAn.Forms
{
    partial class FrmVienPhiHoanTat
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
            this.tabThanhToan = new System.Windows.Forms.TabPage();
            this.dgvChoThanhToan = new System.Windows.Forms.DataGridView();
            this.pnlThanhToan = new System.Windows.Forms.Panel();
            this.lblTongThu = new System.Windows.Forms.Label();
            this.lblChiTietTien = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtHieuQua = new System.Windows.Forms.TextBox();
            this.lblHieuQua = new System.Windows.Forms.Label();
            this.txtPhanUngPhu = new System.Windows.Forms.TextBox();
            this.lblPhanUngPhu = new System.Windows.Forms.Label();
            this.txtMaPK = new System.Windows.Forms.TextBox();
            this.lblMaPK = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.tabLichSu = new System.Windows.Forms.TabPage();
            this.dgvLichSuHD = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoThanhToan)).BeginInit();
            this.pnlThanhToan.SuspendLayout();
            this.tabLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuHD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabThanhToan);
            this.tabMain.Controls.Add(this.tabLichSu);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(984, 560);
            this.tabMain.TabIndex = 0;
            // 
            // tabThanhToan
            // 
            this.tabThanhToan.Controls.Add(this.dgvChoThanhToan);
            this.tabThanhToan.Controls.Add(this.pnlThanhToan);
            this.tabThanhToan.Location = new System.Drawing.Point(4, 25);
            this.tabThanhToan.Name = "tabThanhToan";
            this.tabThanhToan.Padding = new System.Windows.Forms.Padding(3);
            this.tabThanhToan.Size = new System.Drawing.Size(976, 531);
            this.tabThanhToan.TabIndex = 0;
            this.tabThanhToan.Text = "Thanh toán viện phí & Ghi nhận phản ứng thuốc / hiệu quả";
            this.tabThanhToan.UseVisualStyleBackColor = true;
            // 
            // dgvChoThanhToan
            // 
            this.dgvChoThanhToan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChoThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChoThanhToan.Location = new System.Drawing.Point(3, 190);
            this.dgvChoThanhToan.Name = "dgvChoThanhToan";
            this.dgvChoThanhToan.RowHeadersWidth = 51;
            this.dgvChoThanhToan.RowTemplate.Height = 24;
            this.dgvChoThanhToan.Size = new System.Drawing.Size(970, 338);
            this.dgvChoThanhToan.TabIndex = 1;
            this.dgvChoThanhToan.SelectionChanged += new System.EventHandler(this.dgvChoThanhToan_SelectionChanged);
            // 
            // pnlThanhToan
            // 
            this.pnlThanhToan.Controls.Add(this.lblTongThu);
            this.pnlThanhToan.Controls.Add(this.lblChiTietTien);
            this.pnlThanhToan.Controls.Add(this.btnThanhToan);
            this.pnlThanhToan.Controls.Add(this.txtGhiChu);
            this.pnlThanhToan.Controls.Add(this.lblGhiChu);
            this.pnlThanhToan.Controls.Add(this.txtHieuQua);
            this.pnlThanhToan.Controls.Add(this.lblHieuQua);
            this.pnlThanhToan.Controls.Add(this.txtPhanUngPhu);
            this.pnlThanhToan.Controls.Add(this.lblPhanUngPhu);
            this.pnlThanhToan.Controls.Add(this.txtMaPK);
            this.pnlThanhToan.Controls.Add(this.lblMaPK);
            this.pnlThanhToan.Controls.Add(this.txtMaHD);
            this.pnlThanhToan.Controls.Add(this.lblMaHD);
            this.pnlThanhToan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThanhToan.Location = new System.Drawing.Point(3, 3);
            this.pnlThanhToan.Name = "pnlThanhToan";
            this.pnlThanhToan.Size = new System.Drawing.Size(970, 187);
            this.pnlThanhToan.TabIndex = 0;
            // 
            // lblTongThu
            // 
            this.lblTongThu.AutoSize = true;
            this.lblTongThu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongThu.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongThu.Location = new System.Drawing.Point(15, 150);
            this.lblTongThu.Name = "lblTongThu";
            this.lblTongThu.Size = new System.Drawing.Size(262, 25);
            this.lblTongThu.TabIndex = 12;
            this.lblTongThu.Text = "TỔNG THỰC THU: 0 VNĐ";
            // 
            // lblChiTietTien
            // 
            this.lblChiTietTien.AutoSize = true;
            this.lblChiTietTien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiTietTien.ForeColor = System.Drawing.Color.Navy;
            this.lblChiTietTien.Location = new System.Drawing.Point(15, 125);
            this.lblChiTietTien.Name = "lblChiTietTien";
            this.lblChiTietTien.Size = new System.Drawing.Size(534, 20);
            this.lblChiTietTien.TabIndex = 11;
            this.lblChiTietTien.Text = "Tiền khám: 0 đ | Tiền XN: 0 đ | Tiền thuốc: 0 đ | Miễn phí định kỳ: 0 đ";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(680, 125);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(275, 48);
            this.btnThanhToan.TabIndex = 10;
            this.btnThanhToan.Text = "THANH TOÁN && HOÀN TẤT";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(620, 88);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(335, 22);
            this.txtGhiChu.TabIndex = 9;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(545, 91);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(61, 17);
            this.lblGhiChu.TabIndex = 8;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtHieuQua
            // 
            this.txtHieuQua.Location = new System.Drawing.Point(145, 88);
            this.txtHieuQua.Name = "txtHieuQua";
            this.txtHieuQua.Size = new System.Drawing.Size(380, 22);
            this.txtHieuQua.TabIndex = 7;
            // 
            // lblHieuQua
            // 
            this.lblHieuQua.AutoSize = true;
            this.lblHieuQua.Location = new System.Drawing.Point(15, 91);
            this.lblHieuQua.Name = "lblHieuQua";
            this.lblHieuQua.Size = new System.Drawing.Size(123, 17);
            this.lblHieuQua.TabIndex = 6;
            this.lblHieuQua.Text = "Hiệu quả điều trị:";
            // 
            // txtPhanUngPhu
            // 
            this.txtPhanUngPhu.Location = new System.Drawing.Point(145, 52);
            this.txtPhanUngPhu.Name = "txtPhanUngPhu";
            this.txtPhanUngPhu.Size = new System.Drawing.Size(810, 22);
            this.txtPhanUngPhu.TabIndex = 5;
            // 
            // lblPhanUngPhu
            // 
            this.lblPhanUngPhu.AutoSize = true;
            this.lblPhanUngPhu.Location = new System.Drawing.Point(15, 55);
            this.lblPhanUngPhu.Name = "lblPhanUngPhu";
            this.lblPhanUngPhu.Size = new System.Drawing.Size(123, 17);
            this.lblPhanUngPhu.TabIndex = 4;
            this.lblPhanUngPhu.Text = "Phản ứng phụ thuốc:";
            // 
            // txtMaPK
            // 
            this.txtMaPK.Location = new System.Drawing.Point(400, 18);
            this.txtMaPK.Name = "txtMaPK";
            this.txtMaPK.ReadOnly = true;
            this.txtMaPK.Size = new System.Drawing.Size(150, 22);
            this.txtMaPK.TabIndex = 3;
            // 
            // lblMaPK
            // 
            this.lblMaPK.AutoSize = true;
            this.lblMaPK.Location = new System.Drawing.Point(310, 21);
            this.lblMaPK.Name = "lblMaPK";
            this.lblMaPK.Size = new System.Drawing.Size(86, 17);
            this.lblMaPK.TabIndex = 2;
            this.lblMaPK.Text = "Phiếu khám:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(145, 18);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(140, 22);
            this.txtMaHD.TabIndex = 1;
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(15, 21);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(87, 17);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã hóa đơn:";
            // 
            // tabLichSu
            // 
            this.tabLichSu.Controls.Add(this.dgvLichSuHD);
            this.tabLichSu.Location = new System.Drawing.Point(4, 25);
            this.tabLichSu.Name = "tabLichSu";
            this.tabLichSu.Padding = new System.Windows.Forms.Padding(3);
            this.tabLichSu.Size = new System.Drawing.Size(976, 531);
            this.tabLichSu.TabIndex = 1;
            this.tabLichSu.Text = "Lịch sử hóa đơn viện phí đã thanh toán";
            this.tabLichSu.UseVisualStyleBackColor = true;
            // 
            // dgvLichSuHD
            // 
            this.dgvLichSuHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuHD.Location = new System.Drawing.Point(3, 3);
            this.dgvLichSuHD.Name = "dgvLichSuHD";
            this.dgvLichSuHD.RowHeadersWidth = 51;
            this.dgvLichSuHD.RowTemplate.Height = 24;
            this.dgvLichSuHD.Size = new System.Drawing.Size(970, 525);
            this.dgvLichSuHD.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(860, 570);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmVienPhiHoanTat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 612);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmVienPhiHoanTat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh Toán Viện Phí & Xuất Viện (Theo Dõi Phản Ứng Thuốc && Hiệu Quả)";
            this.Load += new System.EventHandler(this.FrmVienPhiHoanTat_Load);
            this.tabMain.ResumeLayout(false);
            this.tabThanhToan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoThanhToan)).EndInit();
            this.pnlThanhToan.ResumeLayout(false);
            this.pnlThanhToan.PerformLayout();
            this.tabLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuHD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabThanhToan;
        private System.Windows.Forms.TabPage tabLichSu;
        private System.Windows.Forms.Panel pnlThanhToan;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblMaPK;
        private System.Windows.Forms.TextBox txtMaPK;
        private System.Windows.Forms.Label lblPhanUngPhu;
        private System.Windows.Forms.TextBox txtPhanUngPhu;
        private System.Windows.Forms.Label lblHieuQua;
        private System.Windows.Forms.TextBox txtHieuQua;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblChiTietTien;
        private System.Windows.Forms.Label lblTongThu;
        private System.Windows.Forms.DataGridView dgvChoThanhToan;
        private System.Windows.Forms.DataGridView dgvLichSuHD;
        private System.Windows.Forms.Button btnDong;
    }
}
