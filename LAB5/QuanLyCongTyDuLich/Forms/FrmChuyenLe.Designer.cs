namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmChuyenLe
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
            this.txtMa = new System.Windows.Forms.TextBox();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.dtDi = new System.Windows.Forms.DateTimePicker();
            this.lblNgayVe = new System.Windows.Forms.Label();
            this.txtDon = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnDongDK = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTour = new System.Windows.Forms.Label();
            this.lblNgayDi = new System.Windows.Forms.Label();
            this.lblNgayVeTitle = new System.Windows.Forms.Label();
            this.lblDon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(120, 20);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(150, 22);
            this.txtMa.TabIndex = 0;
            // 
            // cboTour
            // 
            this.cboTour.FormattingEnabled = true;
            this.cboTour.Location = new System.Drawing.Point(120, 60);
            this.cboTour.Name = "cboTour";
            this.cboTour.Size = new System.Drawing.Size(300, 24);
            this.cboTour.TabIndex = 1;
            this.cboTour.SelectedIndexChanged += new System.EventHandler(this.TinhNgayVe);
            // 
            // dtDi
            // 
            this.dtDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDi.Location = new System.Drawing.Point(120, 100);
            this.dtDi.Name = "dtDi";
            this.dtDi.Size = new System.Drawing.Size(150, 22);
            this.dtDi.TabIndex = 2;
            this.dtDi.ValueChanged += new System.EventHandler(this.TinhNgayVe);
            // 
            // lblNgayVe
            // 
            this.lblNgayVe.AutoSize = true;
            this.lblNgayVe.Location = new System.Drawing.Point(350, 105);
            this.lblNgayVe.Name = "lblNgayVe";
            this.lblNgayVe.Size = new System.Drawing.Size(11, 16);
            this.lblNgayVe.TabIndex = 3;
            this.lblNgayVe.Text = "-";
            // 
            // txtDon
            // 
            this.txtDon.Location = new System.Drawing.Point(120, 140);
            this.txtDon.Name = "txtDon";
            this.txtDon.Size = new System.Drawing.Size(300, 22);
            this.txtDon.TabIndex = 4;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(120, 180);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 35);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Tạo chuyến";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnDongDK
            // 
            this.btnDongDK.Location = new System.Drawing.Point(260, 180);
            this.btnDongDK.Name = "btnDongDK";
            this.btnDongDK.Size = new System.Drawing.Size(120, 35);
            this.btnDongDK.TabIndex = 6;
            this.btnDongDK.Text = "Đóng đăng ký";
            this.btnDongDK.UseVisualStyleBackColor = true;
            this.btnDongDK.Click += new System.EventHandler(this.btnDongDK_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(20, 230);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.Size = new System.Drawing.Size(800, 250);
            this.dgv.TabIndex = 7;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(720, 500);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(20, 23);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(75, 16);
            this.lblMa.TabIndex = 9;
            this.lblMa.Text = "Mã chuyến:";
            // 
            // lblTour
            // 
            this.lblTour.AutoSize = true;
            this.lblTour.Location = new System.Drawing.Point(20, 63);
            this.lblTour.Name = "lblTour";
            this.lblTour.Size = new System.Drawing.Size(38, 16);
            this.lblTour.TabIndex = 10;
            this.lblTour.Text = "Tour:";
            // 
            // lblNgayDi
            // 
            this.lblNgayDi.AutoSize = true;
            this.lblNgayDi.Location = new System.Drawing.Point(20, 105);
            this.lblNgayDi.Name = "lblNgayDi";
            this.lblNgayDi.Size = new System.Drawing.Size(57, 16);
            this.lblNgayDi.TabIndex = 11;
            this.lblNgayDi.Text = "Ngày đi:";
            // 
            // lblNgayVeTitle
            // 
            this.lblNgayVeTitle.AutoSize = true;
            this.lblNgayVeTitle.Location = new System.Drawing.Point(280, 105);
            this.lblNgayVeTitle.Name = "lblNgayVeTitle";
            this.lblNgayVeTitle.Size = new System.Drawing.Size(61, 16);
            this.lblNgayVeTitle.TabIndex = 12;
            this.lblNgayVeTitle.Text = "Ngày về:";
            // 
            // lblDon
            // 
            this.lblDon.AutoSize = true;
            this.lblDon.Location = new System.Drawing.Point(20, 143);
            this.lblDon.Name = "lblDon";
            this.lblDon.Size = new System.Drawing.Size(89, 16);
            this.lblDon.TabIndex = 13;
            this.lblDon.Text = "Địa điểm đón:";
            // 
            // FrmChuyenLe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.lblDon);
            this.Controls.Add(this.lblNgayVeTitle);
            this.Controls.Add(this.lblNgayDi);
            this.Controls.Add(this.lblTour);
            this.Controls.Add(this.lblMa);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnDongDK);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDon);
            this.Controls.Add(this.lblNgayVe);
            this.Controls.Add(this.dtDi);
            this.Controls.Add(this.cboTour);
            this.Controls.Add(this.txtMa);
            this.Name = "FrmChuyenLe";
            this.Text = "Lịch chuyến khách lẻ";
            this.Load += new System.EventHandler(this.FrmChuyenLe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.DateTimePicker dtDi;
        private System.Windows.Forms.Label lblNgayVe;
        private System.Windows.Forms.TextBox txtDon;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnDongDK;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTour;
        private System.Windows.Forms.Label lblNgayDi;
        private System.Windows.Forms.Label lblNgayVeTitle;
        private System.Windows.Forms.Label lblDon;
    }
}
