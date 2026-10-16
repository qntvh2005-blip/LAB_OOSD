namespace QuanLyBenhAn.Forms
{
    partial class FrmXetNghiem
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
            this.grpChiDinh = new System.Windows.Forms.GroupBox();
            this.btnChiDinh = new System.Windows.Forms.Button();
            this.cboLoaiXN = new System.Windows.Forms.ComboBox();
            this.lblLoaiXN = new System.Windows.Forms.Label();
            this.txtMaPXN = new System.Windows.Forms.TextBox();
            this.lblMaPXN = new System.Windows.Forms.Label();
            this.cboPhieuKham = new System.Windows.Forms.ComboBox();
            this.lblPhieuKham = new System.Windows.Forms.Label();
            this.grpKetQua = new System.Windows.Forms.GroupBox();
            this.btnLuuKQ = new System.Windows.Forms.Button();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.txtPXNChon = new System.Windows.Forms.TextBox();
            this.lblPXNChon = new System.Windows.Forms.Label();
            this.dgvXetNghiem = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpChiDinh.SuspendLayout();
            this.grpKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXetNghiem)).BeginInit();
            this.SuspendLayout();
            // 
            // grpChiDinh
            // 
            this.grpChiDinh.Controls.Add(this.btnChiDinh);
            this.grpChiDinh.Controls.Add(this.cboLoaiXN);
            this.grpChiDinh.Controls.Add(this.lblLoaiXN);
            this.grpChiDinh.Controls.Add(this.txtMaPXN);
            this.grpChiDinh.Controls.Add(this.lblMaPXN);
            this.grpChiDinh.Controls.Add(this.cboPhieuKham);
            this.grpChiDinh.Controls.Add(this.lblPhieuKham);
            this.grpChiDinh.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChiDinh.Location = new System.Drawing.Point(0, 0);
            this.grpChiDinh.Name = "grpChiDinh";
            this.grpChiDinh.Size = new System.Drawing.Size(954, 75);
            this.grpChiDinh.TabIndex = 0;
            this.grpChiDinh.TabStop = false;
            this.grpChiDinh.Text = "Chỉ định xét nghiệm cho đợt khám";
            // 
            // btnChiDinh
            // 
            this.btnChiDinh.Location = new System.Drawing.Point(790, 23);
            this.btnChiDinh.Name = "btnChiDinh";
            this.btnChiDinh.Size = new System.Drawing.Size(145, 32);
            this.btnChiDinh.TabIndex = 6;
            this.btnChiDinh.Text = "Chỉ định xét nghiệm";
            this.btnChiDinh.UseVisualStyleBackColor = true;
            this.btnChiDinh.Click += new System.EventHandler(this.btnChiDinh_Click);
            // 
            // cboLoaiXN
            // 
            this.cboLoaiXN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXN.FormattingEnabled = true;
            this.cboLoaiXN.Location = new System.Drawing.Point(550, 27);
            this.cboLoaiXN.Name = "cboLoaiXN";
            this.cboLoaiXN.Size = new System.Drawing.Size(220, 24);
            this.cboLoaiXN.TabIndex = 5;
            // 
            // lblLoaiXN
            // 
            this.lblLoaiXN.AutoSize = true;
            this.lblLoaiXN.Location = new System.Drawing.Point(485, 30);
            this.lblLoaiXN.Name = "lblLoaiXN";
            this.lblLoaiXN.Size = new System.Drawing.Size(60, 17);
            this.lblLoaiXN.TabIndex = 4;
            this.lblLoaiXN.Text = "Loại XN:";
            // 
            // txtMaPXN
            // 
            this.txtMaPXN.Location = new System.Drawing.Point(365, 27);
            this.txtMaPXN.Name = "txtMaPXN";
            this.txtMaPXN.Size = new System.Drawing.Size(100, 22);
            this.txtMaPXN.TabIndex = 3;
            // 
            // lblMaPXN
            // 
            this.lblMaPXN.AutoSize = true;
            this.lblMaPXN.Location = new System.Drawing.Point(300, 30);
            this.lblMaPXN.Name = "lblMaPXN";
            this.lblMaPXN.Size = new System.Drawing.Size(61, 17);
            this.lblMaPXN.TabIndex = 2;
            this.lblMaPXN.Text = "Mã PXN:";
            // 
            // cboPhieuKham
            // 
            this.cboPhieuKham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieuKham.FormattingEnabled = true;
            this.cboPhieuKham.Location = new System.Drawing.Point(100, 27);
            this.cboPhieuKham.Name = "cboPhieuKham";
            this.cboPhieuKham.Size = new System.Drawing.Size(180, 24);
            this.cboPhieuKham.TabIndex = 1;
            // 
            // lblPhieuKham
            // 
            this.lblPhieuKham.AutoSize = true;
            this.lblPhieuKham.Location = new System.Drawing.Point(15, 30);
            this.lblPhieuKham.Name = "lblPhieuKham";
            this.lblPhieuKham.Size = new System.Drawing.Size(86, 17);
            this.lblPhieuKham.TabIndex = 0;
            this.lblPhieuKham.Text = "Phiếu khám:";
            // 
            // grpKetQua
            // 
            this.grpKetQua.Controls.Add(this.btnLuuKQ);
            this.grpKetQua.Controls.Add(this.txtKetQua);
            this.grpKetQua.Controls.Add(this.lblKetQua);
            this.grpKetQua.Controls.Add(this.txtPXNChon);
            this.grpKetQua.Controls.Add(this.lblPXNChon);
            this.grpKetQua.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpKetQua.Location = new System.Drawing.Point(0, 75);
            this.grpKetQua.Name = "grpKetQua";
            this.grpKetQua.Size = new System.Drawing.Size(954, 75);
            this.grpKetQua.TabIndex = 1;
            this.grpKetQua.TabStop = false;
            this.grpKetQua.Text = "Ghi nhận kết quả xét nghiệm";
            // 
            // btnLuuKQ
            // 
            this.btnLuuKQ.Location = new System.Drawing.Point(790, 23);
            this.btnLuuKQ.Name = "btnLuuKQ";
            this.btnLuuKQ.Size = new System.Drawing.Size(145, 32);
            this.btnLuuKQ.TabIndex = 4;
            this.btnLuuKQ.Text = "Lưu kết quả XN";
            this.btnLuuKQ.UseVisualStyleBackColor = true;
            this.btnLuuKQ.Click += new System.EventHandler(this.btnLuuKQ_Click);
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(340, 27);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(430, 22);
            this.txtKetQua.TabIndex = 3;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(235, 30);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(100, 17);
            this.lblKetQua.TabIndex = 2;
            this.lblKetQua.Text = "Nội dung/Trị số:";
            // 
            // txtPXNChon
            // 
            this.txtPXNChon.Location = new System.Drawing.Point(100, 27);
            this.txtPXNChon.Name = "txtPXNChon";
            this.txtPXNChon.ReadOnly = true;
            this.txtPXNChon.Size = new System.Drawing.Size(115, 22);
            this.txtPXNChon.TabIndex = 1;
            // 
            // lblPXNChon
            // 
            this.lblPXNChon.AutoSize = true;
            this.lblPXNChon.Location = new System.Drawing.Point(15, 30);
            this.lblPXNChon.Name = "lblPXNChon";
            this.lblPXNChon.Size = new System.Drawing.Size(76, 17);
            this.lblPXNChon.TabIndex = 0;
            this.lblPXNChon.Text = "Phiếu XN:";
            // 
            // dgvXetNghiem
            // 
            this.dgvXetNghiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXetNghiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXetNghiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvXetNghiem.Location = new System.Drawing.Point(0, 150);
            this.dgvXetNghiem.Name = "dgvXetNghiem";
            this.dgvXetNghiem.RowHeadersWidth = 51;
            this.dgvXetNghiem.RowTemplate.Height = 24;
            this.dgvXetNghiem.Size = new System.Drawing.Size(954, 340);
            this.dgvXetNghiem.TabIndex = 2;
            this.dgvXetNghiem.SelectionChanged += new System.EventHandler(this.dgvXetNghiem_SelectionChanged);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(830, 500);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmXetNghiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 542);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvXetNghiem);
            this.Controls.Add(this.grpKetQua);
            this.Controls.Add(this.grpChiDinh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmXetNghiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉ Định Xét Nghiệm & Ghi Nhận Kết Quả";
            this.Load += new System.EventHandler(this.FrmXetNghiem_Load);
            this.grpChiDinh.ResumeLayout(false);
            this.grpChiDinh.PerformLayout();
            this.grpKetQua.ResumeLayout(false);
            this.grpKetQua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXetNghiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpChiDinh;
        private System.Windows.Forms.Label lblPhieuKham;
        private System.Windows.Forms.ComboBox cboPhieuKham;
        private System.Windows.Forms.Label lblMaPXN;
        private System.Windows.Forms.TextBox txtMaPXN;
        private System.Windows.Forms.Label lblLoaiXN;
        private System.Windows.Forms.ComboBox cboLoaiXN;
        private System.Windows.Forms.Button btnChiDinh;
        private System.Windows.Forms.GroupBox grpKetQua;
        private System.Windows.Forms.Label lblPXNChon;
        private System.Windows.Forms.TextBox txtPXNChon;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Button btnLuuKQ;
        private System.Windows.Forms.DataGridView dgvXetNghiem;
        private System.Windows.Forms.Button btnDong;
    }
}
