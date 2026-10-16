namespace QuanLyBenhAn.Forms
{
    partial class FrmKhamBenh
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
            this.btnTaoPhieu = new System.Windows.Forms.Button();
            this.txtChanDoan = new System.Windows.Forms.TextBox();
            this.lblChanDoan = new System.Windows.Forms.Label();
            this.txtHuyetAp = new System.Windows.Forms.TextBox();
            this.lblHuyetAp = new System.Windows.Forms.Label();
            this.numThanNhiet = new System.Windows.Forms.NumericUpDown();
            this.lblThanNhiet = new System.Windows.Forms.Label();
            this.txtTrieuChung = new System.Windows.Forms.TextBox();
            this.lblTrieuChung = new System.Windows.Forms.Label();
            this.cboLichHen = new System.Windows.Forms.ComboBox();
            this.lblLichHen = new System.Windows.Forms.Label();
            this.cboLoaiKham = new System.Windows.Forms.ComboBox();
            this.lblLoaiKham = new System.Windows.Forms.Label();
            this.cboBacSi = new System.Windows.Forms.ComboBox();
            this.lblBacSi = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboHoSo = new System.Windows.Forms.ComboBox();
            this.lblHoSo = new System.Windows.Forms.Label();
            this.txtMaPK = new System.Windows.Forms.TextBox();
            this.lblMaPK = new System.Windows.Forms.Label();
            this.dgvPhieuKham = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThanNhiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuKham)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnTaoPhieu);
            this.pnlTop.Controls.Add(this.txtChanDoan);
            this.pnlTop.Controls.Add(this.lblChanDoan);
            this.pnlTop.Controls.Add(this.txtHuyetAp);
            this.pnlTop.Controls.Add(this.lblHuyetAp);
            this.pnlTop.Controls.Add(this.numThanNhiet);
            this.pnlTop.Controls.Add(this.lblThanNhiet);
            this.pnlTop.Controls.Add(this.txtTrieuChung);
            this.pnlTop.Controls.Add(this.lblTrieuChung);
            this.pnlTop.Controls.Add(this.cboLichHen);
            this.pnlTop.Controls.Add(this.lblLichHen);
            this.pnlTop.Controls.Add(this.cboLoaiKham);
            this.pnlTop.Controls.Add(this.lblLoaiKham);
            this.pnlTop.Controls.Add(this.cboBacSi);
            this.pnlTop.Controls.Add(this.lblBacSi);
            this.pnlTop.Controls.Add(this.cboKhoa);
            this.pnlTop.Controls.Add(this.lblKhoa);
            this.pnlTop.Controls.Add(this.cboHoSo);
            this.pnlTop.Controls.Add(this.lblHoSo);
            this.pnlTop.Controls.Add(this.txtMaPK);
            this.pnlTop.Controls.Add(this.lblMaPK);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(984, 180);
            this.pnlTop.TabIndex = 0;
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTaoPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoPhieu.ForeColor = System.Drawing.Color.White;
            this.btnTaoPhieu.Location = new System.Drawing.Point(745, 125);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(220, 42);
            this.btnTaoPhieu.TabIndex = 20;
            this.btnTaoPhieu.Text = "TẠO PHIẾU KHÁM BỆNH";
            this.btnTaoPhieu.UseVisualStyleBackColor = false;
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.Location = new System.Drawing.Point(100, 135);
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.Size = new System.Drawing.Size(620, 22);
            this.txtChanDoan.TabIndex = 19;
            // 
            // lblChanDoan
            // 
            this.lblChanDoan.AutoSize = true;
            this.lblChanDoan.Location = new System.Drawing.Point(15, 138);
            this.lblChanDoan.Name = "lblChanDoan";
            this.lblChanDoan.Size = new System.Drawing.Size(81, 17);
            this.lblChanDoan.TabIndex = 18;
            this.lblChanDoan.Text = "Chẩn đoán:";
            // 
            // txtHuyetAp
            // 
            this.txtHuyetAp.Location = new System.Drawing.Point(860, 95);
            this.txtHuyetAp.Name = "txtHuyetAp";
            this.txtHuyetAp.Size = new System.Drawing.Size(105, 22);
            this.txtHuyetAp.TabIndex = 17;
            this.txtHuyetAp.Text = "120/80";
            // 
            // lblHuyetAp
            // 
            this.lblHuyetAp.AutoSize = true;
            this.lblHuyetAp.Location = new System.Drawing.Point(790, 98);
            this.lblHuyetAp.Name = "lblHuyetAp";
            this.lblHuyetAp.Size = new System.Drawing.Size(69, 17);
            this.lblHuyetAp.TabIndex = 16;
            this.lblHuyetAp.Text = "Huyết áp:";
            // 
            // numThanNhiet
            // 
            this.numThanNhiet.DecimalPlaces = 1;
            this.numThanNhiet.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            this.numThanNhiet.Location = new System.Drawing.Point(705, 95);
            this.numThanNhiet.Maximum = new decimal(new int[] { 43, 0, 0, 0 });
            this.numThanNhiet.Minimum = new decimal(new int[] { 34, 0, 0, 0 });
            this.numThanNhiet.Name = "numThanNhiet";
            this.numThanNhiet.Size = new System.Drawing.Size(70, 22);
            this.numThanNhiet.TabIndex = 15;
            this.numThanNhiet.Value = new decimal(new int[] { 370, 0, 0, 65536 });
            // 
            // lblThanNhiet
            // 
            this.lblThanNhiet.AutoSize = true;
            this.lblThanNhiet.Location = new System.Drawing.Point(620, 98);
            this.lblThanNhiet.Name = "lblThanNhiet";
            this.lblThanNhiet.Size = new System.Drawing.Size(81, 17);
            this.lblThanNhiet.TabIndex = 14;
            this.lblThanNhiet.Text = "Thân nhiệt:";
            // 
            // txtTrieuChung
            // 
            this.txtTrieuChung.Location = new System.Drawing.Point(100, 95);
            this.txtTrieuChung.Name = "txtTrieuChung";
            this.txtTrieuChung.Size = new System.Drawing.Size(500, 22);
            this.txtTrieuChung.TabIndex = 13;
            // 
            // lblTrieuChung
            // 
            this.lblTrieuChung.AutoSize = true;
            this.lblTrieuChung.Location = new System.Drawing.Point(15, 98);
            this.lblTrieuChung.Name = "lblTrieuChung";
            this.lblTrieuChung.Size = new System.Drawing.Size(88, 17);
            this.lblTrieuChung.TabIndex = 12;
            this.lblTrieuChung.Text = "Triệu chứng:";
            // 
            // cboLichHen
            // 
            this.cboLichHen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLichHen.Enabled = false;
            this.cboLichHen.FormattingEnabled = true;
            this.cboLichHen.Location = new System.Drawing.Point(705, 56);
            this.cboLichHen.Name = "cboLichHen";
            this.cboLichHen.Size = new System.Drawing.Size(260, 24);
            this.cboLichHen.TabIndex = 11;
            // 
            // lblLichHen
            // 
            this.lblLichHen.AutoSize = true;
            this.lblLichHen.Location = new System.Drawing.Point(620, 59);
            this.lblLichHen.Name = "lblLichHen";
            this.lblLichHen.Size = new System.Drawing.Size(87, 17);
            this.lblLichHen.TabIndex = 10;
            this.lblLichHen.Text = "Lịch định kỳ:";
            // 
            // cboLoaiKham
            // 
            this.cboLoaiKham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiKham.FormattingEnabled = true;
            this.cboLoaiKham.Location = new System.Drawing.Point(440, 56);
            this.cboLoaiKham.Name = "cboLoaiKham";
            this.cboLoaiKham.Size = new System.Drawing.Size(160, 24);
            this.cboLoaiKham.TabIndex = 9;
            this.cboLoaiKham.SelectedIndexChanged += new System.EventHandler(this.cboLoaiKham_SelectedIndexChanged);
            // 
            // lblLoaiKham
            // 
            this.lblLoaiKham.AutoSize = true;
            this.lblLoaiKham.Location = new System.Drawing.Point(355, 59);
            this.lblLoaiKham.Name = "lblLoaiKham";
            this.lblLoaiKham.Size = new System.Drawing.Size(78, 17);
            this.lblLoaiKham.TabIndex = 8;
            this.lblLoaiKham.Text = "Loại khám:";
            // 
            // cboBacSi
            // 
            this.cboBacSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBacSi.FormattingEnabled = true;
            this.cboBacSi.Location = new System.Drawing.Point(100, 56);
            this.cboBacSi.Name = "cboBacSi";
            this.cboBacSi.Size = new System.Drawing.Size(240, 24);
            this.cboBacSi.TabIndex = 7;
            // 
            // lblBacSi
            // 
            this.lblBacSi.AutoSize = true;
            this.lblBacSi.Location = new System.Drawing.Point(15, 59);
            this.lblBacSi.Name = "lblBacSi";
            this.lblBacSi.Size = new System.Drawing.Size(50, 17);
            this.lblBacSi.TabIndex = 6;
            this.lblBacSi.Text = "Bác sĩ:";
            // 
            // cboKhoa
            // 
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(620, 18);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(240, 24);
            this.cboKhoa.TabIndex = 5;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(545, 21);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(68, 17);
            this.lblKhoa.TabIndex = 4;
            this.lblKhoa.Text = "Khoa ĐT:";
            // 
            // cboHoSo
            // 
            this.cboHoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHoSo.FormattingEnabled = true;
            this.cboHoSo.Location = new System.Drawing.Point(340, 18);
            this.cboHoSo.Name = "cboHoSo";
            this.cboHoSo.Size = new System.Drawing.Size(180, 24);
            this.cboHoSo.TabIndex = 3;
            this.cboHoSo.SelectedIndexChanged += new System.EventHandler(this.cboHoSo_SelectedIndexChanged);
            // 
            // lblHoSo
            // 
            this.lblHoSo.AutoSize = true;
            this.lblHoSo.Location = new System.Drawing.Point(265, 21);
            this.lblHoSo.Name = "lblHoSo";
            this.lblHoSo.Size = new System.Drawing.Size(68, 17);
            this.lblHoSo.TabIndex = 2;
            this.lblHoSo.Text = "Mã hồ sơ:";
            // 
            // txtMaPK
            // 
            this.txtMaPK.Location = new System.Drawing.Point(100, 18);
            this.txtMaPK.Name = "txtMaPK";
            this.txtMaPK.Size = new System.Drawing.Size(140, 22);
            this.txtMaPK.TabIndex = 1;
            // 
            // lblMaPK
            // 
            this.lblMaPK.AutoSize = true;
            this.lblMaPK.Location = new System.Drawing.Point(15, 21);
            this.lblMaPK.Name = "lblMaPK";
            this.lblMaPK.Size = new System.Drawing.Size(53, 17);
            this.lblMaPK.TabIndex = 0;
            this.lblMaPK.Text = "Mã PK:";
            // 
            // dgvPhieuKham
            // 
            this.dgvPhieuKham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuKham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuKham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuKham.Location = new System.Drawing.Point(0, 180);
            this.dgvPhieuKham.Name = "dgvPhieuKham";
            this.dgvPhieuKham.RowHeadersWidth = 51;
            this.dgvPhieuKham.RowTemplate.Height = 24;
            this.dgvPhieuKham.Size = new System.Drawing.Size(984, 380);
            this.dgvPhieuKham.TabIndex = 1;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(860, 570);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmKhamBenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 612);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvPhieuKham);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmKhamBenh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Khám Bệnh - Ghi Nhận Triệu Chứng, Thân Nhiệt, Huyết Áp (Trang Sau Hồ Sơ Bệnh Án)" +
    "";
            this.Load += new System.EventHandler(this.FrmKhamBenh_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThanNhiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuKham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblMaPK;
        private System.Windows.Forms.TextBox txtMaPK;
        private System.Windows.Forms.Label lblHoSo;
        private System.Windows.Forms.ComboBox cboHoSo;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label lblBacSi;
        private System.Windows.Forms.ComboBox cboBacSi;
        private System.Windows.Forms.Label lblLoaiKham;
        private System.Windows.Forms.ComboBox cboLoaiKham;
        private System.Windows.Forms.Label lblLichHen;
        private System.Windows.Forms.ComboBox cboLichHen;
        private System.Windows.Forms.Label lblTrieuChung;
        private System.Windows.Forms.TextBox txtTrieuChung;
        private System.Windows.Forms.Label lblThanNhiet;
        private System.Windows.Forms.NumericUpDown numThanNhiet;
        private System.Windows.Forms.Label lblHuyetAp;
        private System.Windows.Forms.TextBox txtHuyetAp;
        private System.Windows.Forms.Label lblChanDoan;
        private System.Windows.Forms.TextBox txtChanDoan;
        private System.Windows.Forms.Button btnTaoPhieu;
        private System.Windows.Forms.DataGridView dgvPhieuKham;
        private System.Windows.Forms.Button btnDong;
    }
}
