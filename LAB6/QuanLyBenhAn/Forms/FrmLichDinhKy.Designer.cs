namespace QuanLyBenhAn.Forms
{
    partial class FrmLichDinhKy
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
            this.btnDatLich = new System.Windows.Forms.Button();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.dtGioHen = new System.Windows.Forms.DateTimePicker();
            this.lblGioHen = new System.Windows.Forms.Label();
            this.cboQuy = new System.Windows.Forms.ComboBox();
            this.lblQuy = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.cboHoSo = new System.Windows.Forms.ComboBox();
            this.lblHoSo = new System.Windows.Forms.Label();
            this.txtMaLich = new System.Windows.Forms.TextBox();
            this.lblMaLich = new System.Windows.Forms.Label();
            this.dgvLichHen = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnDatLich);
            this.pnlTop.Controls.Add(this.txtNoiDung);
            this.pnlTop.Controls.Add(this.lblNoiDung);
            this.pnlTop.Controls.Add(this.dtGioHen);
            this.pnlTop.Controls.Add(this.lblGioHen);
            this.pnlTop.Controls.Add(this.cboQuy);
            this.pnlTop.Controls.Add(this.lblQuy);
            this.pnlTop.Controls.Add(this.numNam);
            this.pnlTop.Controls.Add(this.lblNam);
            this.pnlTop.Controls.Add(this.cboHoSo);
            this.pnlTop.Controls.Add(this.lblHoSo);
            this.pnlTop.Controls.Add(this.txtMaLich);
            this.pnlTop.Controls.Add(this.lblMaLich);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(914, 150);
            this.pnlTop.TabIndex = 0;
            // 
            // btnDatLich
            // 
            this.btnDatLich.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDatLich.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatLich.ForeColor = System.Drawing.Color.White;
            this.btnDatLich.Location = new System.Drawing.Point(680, 85);
            this.btnDatLich.Name = "btnDatLich";
            this.btnDatLich.Size = new System.Drawing.Size(210, 42);
            this.btnDatLich.TabIndex = 12;
            this.btnDatLich.Text = "ĐẶT LỊCH HẸN ĐỊNH KỲ";
            this.btnDatLich.UseVisualStyleBackColor = false;
            this.btnDatLich.Click += new System.EventHandler(this.btnDatLich_Click);
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(100, 95);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(560, 22);
            this.txtNoiDung.TabIndex = 11;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(15, 98);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(69, 17);
            this.lblNoiDung.TabIndex = 10;
            this.lblNoiDung.Text = "Nội dung:";
            // 
            // dtGioHen
            // 
            this.dtGioHen.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtGioHen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtGioHen.Location = new System.Drawing.Point(680, 56);
            this.dtGioHen.Name = "dtGioHen";
            this.dtGioHen.Size = new System.Drawing.Size(210, 22);
            this.dtGioHen.TabIndex = 9;
            // 
            // lblGioHen
            // 
            this.lblGioHen.AutoSize = true;
            this.lblGioHen.Location = new System.Drawing.Point(595, 59);
            this.lblGioHen.Name = "lblGioHen";
            this.lblGioHen.Size = new System.Drawing.Size(84, 17);
            this.lblGioHen.TabIndex = 8;
            this.lblGioHen.Text = "Ngày giờ hẹn:";
            // 
            // cboQuy
            // 
            this.cboQuy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuy.FormattingEnabled = true;
            this.cboQuy.Items.AddRange(new object[] {
            "Quý 1",
            "Quý 2",
            "Quý 3",
            "Quý 4"});
            this.cboQuy.Location = new System.Drawing.Point(440, 56);
            this.cboQuy.Name = "cboQuy";
            this.cboQuy.Size = new System.Drawing.Size(120, 24);
            this.cboQuy.TabIndex = 7;
            // 
            // lblQuy
            // 
            this.lblQuy.AutoSize = true;
            this.lblQuy.Location = new System.Drawing.Point(395, 59);
            this.lblQuy.Name = "lblQuy";
            this.lblQuy.Size = new System.Drawing.Size(38, 17);
            this.lblQuy.TabIndex = 6;
            this.lblQuy.Text = "Quý:";
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(260, 56);
            this.numNam.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            this.numNam.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(100, 22);
            this.numNam.TabIndex = 5;
            this.numNam.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(215, 59);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(41, 17);
            this.lblNam.TabIndex = 4;
            this.lblNam.Text = "Năm:";
            // 
            // cboHoSo
            // 
            this.cboHoSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHoSo.FormattingEnabled = true;
            this.cboHoSo.Location = new System.Drawing.Point(340, 18);
            this.cboHoSo.Name = "cboHoSo";
            this.cboHoSo.Size = new System.Drawing.Size(220, 24);
            this.cboHoSo.TabIndex = 3;
            // 
            // lblHoSo
            // 
            this.lblHoSo.AutoSize = true;
            this.lblHoSo.Location = new System.Drawing.Point(260, 21);
            this.lblHoSo.Name = "lblHoSo";
            this.lblHoSo.Size = new System.Drawing.Size(68, 17);
            this.lblHoSo.TabIndex = 2;
            this.lblHoSo.Text = "Mã hồ sơ:";
            // 
            // txtMaLich
            // 
            this.txtMaLich.Location = new System.Drawing.Point(100, 18);
            this.txtMaLich.Name = "txtMaLich";
            this.txtMaLich.Size = new System.Drawing.Size(140, 22);
            this.txtMaLich.TabIndex = 1;
            // 
            // lblMaLich
            // 
            this.lblMaLich.AutoSize = true;
            this.lblMaLich.Location = new System.Drawing.Point(15, 21);
            this.lblMaLich.Name = "lblMaLich";
            this.lblMaLich.Size = new System.Drawing.Size(77, 17);
            this.lblMaLich.TabIndex = 0;
            this.lblMaLich.Text = "Mã lịch hẹn:";
            // 
            // dgvLichHen
            // 
            this.dgvLichHen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichHen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichHen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichHen.Location = new System.Drawing.Point(0, 150);
            this.dgvLichHen.Name = "dgvLichHen";
            this.dgvLichHen.RowHeadersWidth = 51;
            this.dgvLichHen.RowTemplate.Height = 24;
            this.dgvLichHen.Size = new System.Drawing.Size(914, 340);
            this.dgvLichHen.TabIndex = 1;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(790, 500);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmLichDinhKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 542);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvLichHen);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmLichDinhKy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đặt Lịch Khám Sức Khỏe Định Kỳ Theo Quý (Miễn Phí)";
            this.Load += new System.EventHandler(this.FrmLichDinhKy_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichHen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblMaLich;
        private System.Windows.Forms.TextBox txtMaLich;
        private System.Windows.Forms.Label lblHoSo;
        private System.Windows.Forms.ComboBox cboHoSo;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Label lblQuy;
        private System.Windows.Forms.ComboBox cboQuy;
        private System.Windows.Forms.Label lblGioHen;
        private System.Windows.Forms.DateTimePicker dtGioHen;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Button btnDatLich;
        private System.Windows.Forms.DataGridView dgvLichHen;
        private System.Windows.Forms.Button btnDong;
    }
}
