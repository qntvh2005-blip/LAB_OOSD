namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmLuongThongKe
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
            this.tabTK = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.btnLuong = new System.Windows.Forms.Button();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnTongHop = new System.Windows.Forms.Button();
            this.dgvTongHop = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabTK.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).BeginInit();
            this.SuspendLayout();
            // 
            // tabTK
            // 
            this.tabTK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTK.Controls.Add(this.tabPage1);
            this.tabTK.Controls.Add(this.tabPage2);
            this.tabTK.Location = new System.Drawing.Point(12, 12);
            this.tabTK.Name = "tabTK";
            this.tabTK.SelectedIndex = 0;
            this.tabTK.Size = new System.Drawing.Size(810, 490);
            this.tabTK.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvLuong);
            this.tabPage1.Controls.Add(this.btnLuong);
            this.tabPage1.Controls.Add(this.numNam);
            this.tabPage1.Controls.Add(this.numThang);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lương hướng dẫn viên";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(100, 16);
            this.numThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(120, 20);
            this.numThang.TabIndex = 0;
            this.numThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(100, 42);
            this.numNam.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.numNam.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(120, 20);
            this.numNam.TabIndex = 1;
            this.numNam.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // btnLuong
            // 
            this.btnLuong.Location = new System.Drawing.Point(250, 16);
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Size = new System.Drawing.Size(100, 30);
            this.btnLuong.TabIndex = 2;
            this.btnLuong.Text = "Tính lương";
            this.btnLuong.UseVisualStyleBackColor = true;
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // dgvLuong
            // 
            this.dgvLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuong.Location = new System.Drawing.Point(6, 80);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.Size = new System.Drawing.Size(790, 378);
            this.dgvLuong.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvTongHop);
            this.tabPage2.Controls.Add(this.btnTongHop);
            this.tabPage2.Controls.Add(this.dtDen);
            this.tabPage2.Controls.Add(this.dtTu);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(802, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thống kê tổng hợp";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtTu
            // 
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTu.Location = new System.Drawing.Point(100, 16);
            this.dtTu.Name = "dtTu";
            this.dtTu.Size = new System.Drawing.Size(150, 20);
            this.dtTu.TabIndex = 0;
            // 
            // dtDen
            // 
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDen.Location = new System.Drawing.Point(100, 42);
            this.dtDen.Name = "dtDen";
            this.dtDen.Size = new System.Drawing.Size(150, 20);
            this.dtDen.TabIndex = 1;
            // 
            // btnTongHop
            // 
            this.btnTongHop.Location = new System.Drawing.Point(280, 16);
            this.btnTongHop.Name = "btnTongHop";
            this.btnTongHop.Size = new System.Drawing.Size(100, 30);
            this.btnTongHop.TabIndex = 2;
            this.btnTongHop.Text = "Thống kê";
            this.btnTongHop.UseVisualStyleBackColor = true;
            this.btnTongHop.Click += new System.EventHandler(this.btnTongHop_Click);
            // 
            // dgvTongHop
            // 
            this.dgvTongHop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTongHop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongHop.Location = new System.Drawing.Point(6, 80);
            this.dgvTongHop.Name = "dgvTongHop";
            this.dgvTongHop.Size = new System.Drawing.Size(790, 378);
            this.dgvTongHop.TabIndex = 3;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(722, 508);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmLuongThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 541);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabTK);
            this.Name = "FrmLuongThongKe";
            this.Text = "Lương - Thống kê";
            this.Load += new System.EventHandler(this.FrmLuongThongKe_Load);
            this.tabTK.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHop)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabTK;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Button btnLuong;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnTongHop;
        private System.Windows.Forms.DataGridView dgvTongHop;
        private System.Windows.Forms.Button btnDong;
    }
}
