namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmTour
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
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.tabTour = new System.Windows.Forms.TabControl();
            this.tabTourThongTin = new System.Windows.Forms.TabPage();
            this.dgvTour = new System.Windows.Forms.DataGridView();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.numNgay = new System.Windows.Forms.NumericUpDown();
            this.numDem = new System.Windows.Forms.NumericUpDown();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnThemTour = new System.Windows.Forms.Button();
            this.tabDiemDung = new System.Windows.Forms.TabPage();
            this.dgvDiemDung = new System.Windows.Forms.DataGridView();
            this.numThuTu = new System.Windows.Forms.NumericUpDown();
            this.txtDiemDung = new System.Windows.Forms.TextBox();
            this.chkDoiPT = new System.Windows.Forms.CheckBox();
            this.chkAn = new System.Windows.Forms.CheckBox();
            this.chkKS = new System.Windows.Forms.CheckBox();
            this.numSao = new System.Windows.Forms.NumericUpDown();
            this.txtGhiChuDD = new System.Windows.Forms.TextBox();
            this.btnThemDD = new System.Windows.Forms.Button();
            this.tabPhuongTien = new System.Windows.Forms.TabPage();
            this.dgvChang = new System.Windows.Forms.DataGridView();
            this.numChang = new System.Windows.Forms.NumericUpDown();
            this.cboPT = new System.Windows.Forms.ComboBox();
            this.txtGhiChuPT = new System.Windows.Forms.TextBox();
            this.btnThemChang = new System.Windows.Forms.Button();
            this.tabDiemTQ = new System.Windows.Forms.TabPage();
            this.dgvTQ = new System.Windows.Forms.DataGridView();
            this.cboDTQ = new System.Windows.Forms.ComboBox();
            this.numThuTuTQ = new System.Windows.Forms.NumericUpDown();
            this.btnThemTQ = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.labelCboTour = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTuTQ)).BeginInit();
            this.tabTour.SuspendLayout();
            this.tabTourThongTin.SuspendLayout();
            this.tabDiemDung.SuspendLayout();
            this.tabPhuongTien.SuspendLayout();
            this.tabDiemTQ.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTour
            // 
            this.cboTour.FormattingEnabled = true;
            this.cboTour.Location = new System.Drawing.Point(120, 15);
            this.cboTour.Name = "cboTour";
            this.cboTour.Size = new System.Drawing.Size(300, 24);
            this.cboTour.TabIndex = 0;
            this.cboTour.SelectedIndexChanged += new System.EventHandler(this.cboTour_SelectedIndexChanged);
            // 
            // labelCboTour
            // 
            this.labelCboTour.AutoSize = true;
            this.labelCboTour.Location = new System.Drawing.Point(12, 18);
            this.labelCboTour.Name = "labelCboTour";
            this.labelCboTour.Size = new System.Drawing.Size(102, 16);
            this.labelCboTour.TabIndex = 2;
            this.labelCboTour.Text = "Tour đang chọn:";
            // 
            // tabTour
            // 
            this.tabTour.Controls.Add(this.tabTourThongTin);
            this.tabTour.Controls.Add(this.tabDiemDung);
            this.tabTour.Controls.Add(this.tabPhuongTien);
            this.tabTour.Controls.Add(this.tabDiemTQ);
            this.tabTour.Location = new System.Drawing.Point(15, 60);
            this.tabTour.Name = "tabTour";
            this.tabTour.SelectedIndex = 0;
            this.tabTour.Size = new System.Drawing.Size(850, 500);
            this.tabTour.TabIndex = 1;
            // 
            // tabTourThongTin
            // 
            this.tabTourThongTin.Controls.Add(this.btnThemTour);
            this.tabTourThongTin.Controls.Add(this.txtMoTa);
            this.tabTourThongTin.Controls.Add(this.numGia);
            this.tabTourThongTin.Controls.Add(this.numDem);
            this.tabTourThongTin.Controls.Add(this.numNgay);
            this.tabTourThongTin.Controls.Add(this.txtTen);
            this.tabTourThongTin.Controls.Add(this.txtMa);
            this.tabTourThongTin.Controls.Add(this.dgvTour);
            this.tabTourThongTin.Location = new System.Drawing.Point(4, 25);
            this.tabTourThongTin.Name = "tabTourThongTin";
            this.tabTourThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.tabTourThongTin.Size = new System.Drawing.Size(842, 471);
            this.tabTourThongTin.TabIndex = 0;
            this.tabTourThongTin.Text = "Tour";
            this.tabTourThongTin.UseVisualStyleBackColor = true;
            // 
            // dgvTour
            // 
            this.dgvTour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTour.Location = new System.Drawing.Point(6, 6);
            this.dgvTour.Name = "dgvTour";
            this.dgvTour.RowHeadersWidth = 51;
            this.dgvTour.Size = new System.Drawing.Size(830, 250);
            this.dgvTour.TabIndex = 0;
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(20, 275);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(100, 22);
            this.txtMa.TabIndex = 1;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(140, 275);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(150, 22);
            this.txtTen.TabIndex = 2;
            // 
            // numNgay
            // 
            this.numNgay.Location = new System.Drawing.Point(310, 275);
            this.numNgay.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.numNgay.Name = "numNgay";
            this.numNgay.Size = new System.Drawing.Size(60, 22);
            this.numNgay.TabIndex = 3;
            // 
            // numDem
            // 
            this.numDem.Location = new System.Drawing.Point(390, 275);
            this.numDem.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.numDem.Name = "numDem";
            this.numDem.Size = new System.Drawing.Size(60, 22);
            this.numDem.TabIndex = 4;
            // 
            // numGia
            // 
            this.numGia.Location = new System.Drawing.Point(470, 275);
            this.numGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(100, 22);
            this.numGia.TabIndex = 5;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(590, 275);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(150, 22);
            this.txtMoTa.TabIndex = 6;
            // 
            // btnThemTour
            // 
            this.btnThemTour.Location = new System.Drawing.Point(20, 315);
            this.btnThemTour.Name = "btnThemTour";
            this.btnThemTour.Size = new System.Drawing.Size(100, 30);
            this.btnThemTour.TabIndex = 7;
            this.btnThemTour.Text = "Thêm";
            this.btnThemTour.UseVisualStyleBackColor = true;
            this.btnThemTour.Click += new System.EventHandler(this.btnThemTour_Click);
            // 
            // tabDiemDung
            // 
            this.tabDiemDung.Controls.Add(this.btnThemDD);
            this.tabDiemDung.Controls.Add(this.txtGhiChuDD);
            this.tabDiemDung.Controls.Add(this.numSao);
            this.tabDiemDung.Controls.Add(this.chkKS);
            this.tabDiemDung.Controls.Add(this.chkAn);
            this.tabDiemDung.Controls.Add(this.chkDoiPT);
            this.tabDiemDung.Controls.Add(this.txtDiemDung);
            this.tabDiemDung.Controls.Add(this.numThuTu);
            this.tabDiemDung.Controls.Add(this.dgvDiemDung);
            this.tabDiemDung.Location = new System.Drawing.Point(4, 25);
            this.tabDiemDung.Name = "tabDiemDung";
            this.tabDiemDung.Padding = new System.Windows.Forms.Padding(3);
            this.tabDiemDung.Size = new System.Drawing.Size(842, 471);
            this.tabDiemDung.TabIndex = 1;
            this.tabDiemDung.Text = "Điểm dừng";
            this.tabDiemDung.UseVisualStyleBackColor = true;
            // 
            // dgvDiemDung
            // 
            this.dgvDiemDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiemDung.Location = new System.Drawing.Point(6, 6);
            this.dgvDiemDung.Name = "dgvDiemDung";
            this.dgvDiemDung.RowHeadersWidth = 51;
            this.dgvDiemDung.Size = new System.Drawing.Size(830, 250);
            this.dgvDiemDung.TabIndex = 0;
            // 
            // numThuTu
            // 
            this.numThuTu.Location = new System.Drawing.Point(20, 275);
            this.numThuTu.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numThuTu.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThuTu.Name = "numThuTu";
            this.numThuTu.Size = new System.Drawing.Size(60, 22);
            this.numThuTu.TabIndex = 1;
            this.numThuTu.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtDiemDung
            // 
            this.txtDiemDung.Location = new System.Drawing.Point(100, 275);
            this.txtDiemDung.Name = "txtDiemDung";
            this.txtDiemDung.Size = new System.Drawing.Size(150, 22);
            this.txtDiemDung.TabIndex = 2;
            // 
            // chkDoiPT
            // 
            this.chkDoiPT.AutoSize = true;
            this.chkDoiPT.Location = new System.Drawing.Point(270, 277);
            this.chkDoiPT.Name = "chkDoiPT";
            this.chkDoiPT.Size = new System.Drawing.Size(68, 20);
            this.chkDoiPT.TabIndex = 3;
            this.chkDoiPT.Text = "Đổi PT";
            this.chkDoiPT.UseVisualStyleBackColor = true;
            // 
            // chkAn
            // 
            this.chkAn.AutoSize = true;
            this.chkAn.Location = new System.Drawing.Point(360, 277);
            this.chkAn.Name = "chkAn";
            this.chkAn.Size = new System.Drawing.Size(46, 20);
            this.chkAn.TabIndex = 4;
            this.chkAn.Text = "Ăn";
            this.chkAn.UseVisualStyleBackColor = true;
            // 
            // chkKS
            // 
            this.chkKS.AutoSize = true;
            this.chkKS.Location = new System.Drawing.Point(430, 277);
            this.chkKS.Name = "chkKS";
            this.chkKS.Size = new System.Drawing.Size(46, 20);
            this.chkKS.TabIndex = 5;
            this.chkKS.Text = "KS";
            this.chkKS.UseVisualStyleBackColor = true;
            this.chkKS.CheckedChanged += new System.EventHandler(this.chkKS_CheckedChanged);
            // 
            // numSao
            // 
            this.numSao.Enabled = false;
            this.numSao.Location = new System.Drawing.Point(490, 275);
            this.numSao.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numSao.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            this.numSao.Name = "numSao";
            this.numSao.Size = new System.Drawing.Size(60, 22);
            this.numSao.TabIndex = 6;
            this.numSao.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // txtGhiChuDD
            // 
            this.txtGhiChuDD.Location = new System.Drawing.Point(570, 275);
            this.txtGhiChuDD.Name = "txtGhiChuDD";
            this.txtGhiChuDD.Size = new System.Drawing.Size(150, 22);
            this.txtGhiChuDD.TabIndex = 7;
            // 
            // btnThemDD
            // 
            this.btnThemDD.Location = new System.Drawing.Point(20, 315);
            this.btnThemDD.Name = "btnThemDD";
            this.btnThemDD.Size = new System.Drawing.Size(100, 30);
            this.btnThemDD.TabIndex = 8;
            this.btnThemDD.Text = "Thêm";
            this.btnThemDD.UseVisualStyleBackColor = true;
            this.btnThemDD.Click += new System.EventHandler(this.btnThemDD_Click);
            // 
            // tabPhuongTien
            // 
            this.tabPhuongTien.Controls.Add(this.btnThemChang);
            this.tabPhuongTien.Controls.Add(this.txtGhiChuPT);
            this.tabPhuongTien.Controls.Add(this.cboPT);
            this.tabPhuongTien.Controls.Add(this.numChang);
            this.tabPhuongTien.Controls.Add(this.dgvChang);
            this.tabPhuongTien.Location = new System.Drawing.Point(4, 25);
            this.tabPhuongTien.Name = "tabPhuongTien";
            this.tabPhuongTien.Size = new System.Drawing.Size(842, 471);
            this.tabPhuongTien.TabIndex = 2;
            this.tabPhuongTien.Text = "Phương tiện theo chặng";
            this.tabPhuongTien.UseVisualStyleBackColor = true;
            // 
            // dgvChang
            // 
            this.dgvChang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChang.Location = new System.Drawing.Point(6, 6);
            this.dgvChang.Name = "dgvChang";
            this.dgvChang.RowHeadersWidth = 51;
            this.dgvChang.Size = new System.Drawing.Size(830, 250);
            this.dgvChang.TabIndex = 0;
            // 
            // numChang
            // 
            this.numChang.Location = new System.Drawing.Point(20, 275);
            this.numChang.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numChang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numChang.Name = "numChang";
            this.numChang.Size = new System.Drawing.Size(60, 22);
            this.numChang.TabIndex = 1;
            this.numChang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboPT
            // 
            this.cboPT.FormattingEnabled = true;
            this.cboPT.Location = new System.Drawing.Point(100, 275);
            this.cboPT.Name = "cboPT";
            this.cboPT.Size = new System.Drawing.Size(150, 24);
            this.cboPT.TabIndex = 2;
            // 
            // txtGhiChuPT
            // 
            this.txtGhiChuPT.Location = new System.Drawing.Point(270, 275);
            this.txtGhiChuPT.Name = "txtGhiChuPT";
            this.txtGhiChuPT.Size = new System.Drawing.Size(200, 22);
            this.txtGhiChuPT.TabIndex = 3;
            // 
            // btnThemChang
            // 
            this.btnThemChang.Location = new System.Drawing.Point(20, 315);
            this.btnThemChang.Name = "btnThemChang";
            this.btnThemChang.Size = new System.Drawing.Size(100, 30);
            this.btnThemChang.TabIndex = 4;
            this.btnThemChang.Text = "Thêm";
            this.btnThemChang.UseVisualStyleBackColor = true;
            this.btnThemChang.Click += new System.EventHandler(this.btnThemChang_Click);
            // 
            // tabDiemTQ
            // 
            this.tabDiemTQ.Controls.Add(this.btnThemTQ);
            this.tabDiemTQ.Controls.Add(this.numThuTuTQ);
            this.tabDiemTQ.Controls.Add(this.cboDTQ);
            this.tabDiemTQ.Controls.Add(this.dgvTQ);
            this.tabDiemTQ.Location = new System.Drawing.Point(4, 25);
            this.tabDiemTQ.Name = "tabDiemTQ";
            this.tabDiemTQ.Size = new System.Drawing.Size(842, 471);
            this.tabDiemTQ.TabIndex = 3;
            this.tabDiemTQ.Text = "Điểm tham quan";
            this.tabDiemTQ.UseVisualStyleBackColor = true;
            // 
            // dgvTQ
            // 
            this.dgvTQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTQ.Location = new System.Drawing.Point(6, 6);
            this.dgvTQ.Name = "dgvTQ";
            this.dgvTQ.RowHeadersWidth = 51;
            this.dgvTQ.Size = new System.Drawing.Size(830, 250);
            this.dgvTQ.TabIndex = 0;
            // 
            // cboDTQ
            // 
            this.cboDTQ.FormattingEnabled = true;
            this.cboDTQ.Location = new System.Drawing.Point(20, 275);
            this.cboDTQ.Name = "cboDTQ";
            this.cboDTQ.Size = new System.Drawing.Size(200, 24);
            this.cboDTQ.TabIndex = 1;
            // 
            // numThuTuTQ
            // 
            this.numThuTuTQ.Location = new System.Drawing.Point(240, 275);
            this.numThuTuTQ.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.numThuTuTQ.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThuTuTQ.Name = "numThuTuTQ";
            this.numThuTuTQ.Size = new System.Drawing.Size(60, 22);
            this.numThuTuTQ.TabIndex = 2;
            this.numThuTuTQ.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemTQ
            // 
            this.btnThemTQ.Location = new System.Drawing.Point(20, 315);
            this.btnThemTQ.Name = "btnThemTQ";
            this.btnThemTQ.Size = new System.Drawing.Size(100, 30);
            this.btnThemTQ.TabIndex = 3;
            this.btnThemTQ.Text = "Thêm";
            this.btnThemTQ.UseVisualStyleBackColor = true;
            this.btnThemTQ.Click += new System.EventHandler(this.btnThemTQ_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(765, 570);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.labelCboTour);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabTour);
            this.Controls.Add(this.cboTour);
            this.Name = "FrmTour";
            this.Text = "Tour - Hành trình";
            this.Load += new System.EventHandler(this.FrmTour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numChang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThuTuTQ)).EndInit();
            this.tabTour.ResumeLayout(false);
            this.tabTourThongTin.ResumeLayout(false);
            this.tabTourThongTin.PerformLayout();
            this.tabDiemDung.ResumeLayout(false);
            this.tabDiemDung.PerformLayout();
            this.tabPhuongTien.ResumeLayout(false);
            this.tabPhuongTien.PerformLayout();
            this.tabDiemTQ.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.TabControl tabTour;
        private System.Windows.Forms.TabPage tabTourThongTin;
        private System.Windows.Forms.TabPage tabDiemDung;
        private System.Windows.Forms.TabPage tabPhuongTien;
        private System.Windows.Forms.TabPage tabDiemTQ;
        private System.Windows.Forms.DataGridView dgvTour;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.NumericUpDown numNgay;
        private System.Windows.Forms.NumericUpDown numDem;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnThemTour;
        private System.Windows.Forms.DataGridView dgvDiemDung;
        private System.Windows.Forms.NumericUpDown numThuTu;
        private System.Windows.Forms.TextBox txtDiemDung;
        private System.Windows.Forms.CheckBox chkDoiPT;
        private System.Windows.Forms.CheckBox chkAn;
        private System.Windows.Forms.CheckBox chkKS;
        private System.Windows.Forms.NumericUpDown numSao;
        private System.Windows.Forms.TextBox txtGhiChuDD;
        private System.Windows.Forms.Button btnThemDD;
        private System.Windows.Forms.DataGridView dgvChang;
        private System.Windows.Forms.NumericUpDown numChang;
        private System.Windows.Forms.ComboBox cboPT;
        private System.Windows.Forms.TextBox txtGhiChuPT;
        private System.Windows.Forms.Button btnThemChang;
        private System.Windows.Forms.DataGridView dgvTQ;
        private System.Windows.Forms.ComboBox cboDTQ;
        private System.Windows.Forms.NumericUpDown numThuTuTQ;
        private System.Windows.Forms.Button btnThemTQ;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label labelCboTour;
    }
}
