namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmDanhMuc
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPT = new System.Windows.Forms.TabPage();
            this.dgvPT = new System.Windows.Forms.DataGridView();
            this.txtPTMa = new System.Windows.Forms.TextBox();
            this.txtPTTen = new System.Windows.Forms.TextBox();
            this.txtPTGhiChu = new System.Windows.Forms.TextBox();
            this.btnThemPT = new System.Windows.Forms.Button();
            
            this.tabDB = new System.Windows.Forms.TabPage();
            this.dgvDB = new System.Windows.Forms.DataGridView();
            this.txtDBMa = new System.Windows.Forms.TextBox();
            this.txtDBTen = new System.Windows.Forms.TextBox();
            this.txtDBDiaChi = new System.Windows.Forms.TextBox();
            this.txtDBDT = new System.Windows.Forms.TextBox();
            this.btnThemDB = new System.Windows.Forms.Button();
            
            this.tabHDV = new System.Windows.Forms.TabPage();
            this.dgvHDV = new System.Windows.Forms.DataGridView();
            this.txtHDVMa = new System.Windows.Forms.TextBox();
            this.txtHDVTen = new System.Windows.Forms.TextBox();
            this.txtHDVDT = new System.Windows.Forms.TextBox();
            this.numLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemHDV = new System.Windows.Forms.Button();
            
            this.tabDTQ = new System.Windows.Forms.TabPage();
            this.dgvDTQ = new System.Windows.Forms.DataGridView();
            this.txtDTQMa = new System.Windows.Forms.TextBox();
            this.txtDTQTen = new System.Windows.Forms.TextBox();
            this.txtDTQDiaDiem = new System.Windows.Forms.TextBox();
            this.txtDTQNoiDung = new System.Windows.Forms.TextBox();
            this.txtDTQYNghia = new System.Windows.Forms.TextBox();
            this.btnThemDTQ = new System.Windows.Forms.Button();
            
            this.btnDong = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPT)).BeginInit();
            this.tabDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).BeginInit();
            this.tabHDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuong)).BeginInit();
            this.tabDTQ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTQ)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPT);
            this.tabControl1.Controls.Add(this.tabDB);
            this.tabControl1.Controls.Add(this.tabHDV);
            this.tabControl1.Controls.Add(this.tabDTQ);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 480);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPT
            // 
            this.tabPT.Controls.Add(this.btnThemPT);
            this.tabPT.Controls.Add(this.txtPTGhiChu);
            this.tabPT.Controls.Add(this.txtPTTen);
            this.tabPT.Controls.Add(this.txtPTMa);
            this.tabPT.Controls.Add(this.dgvPT);
            this.tabPT.Location = new System.Drawing.Point(4, 25);
            this.tabPT.Name = "tabPT";
            this.tabPT.Padding = new System.Windows.Forms.Padding(3);
            this.tabPT.Size = new System.Drawing.Size(752, 451);
            this.tabPT.TabIndex = 0;
            this.tabPT.Text = "Phương tiện";
            this.tabPT.UseVisualStyleBackColor = true;
            // 
            // dgvPT
            // 
            this.dgvPT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPT.Location = new System.Drawing.Point(6, 6);
            this.dgvPT.Name = "dgvPT";
            this.dgvPT.RowHeadersWidth = 51;
            this.dgvPT.RowTemplate.Height = 24;
            this.dgvPT.Size = new System.Drawing.Size(740, 300);
            this.dgvPT.TabIndex = 0;
            // 
            // txtPTMa
            // 
            this.txtPTMa.Location = new System.Drawing.Point(6, 320);
            this.txtPTMa.Name = "txtPTMa";
            this.txtPTMa.Size = new System.Drawing.Size(100, 22);
            this.txtPTMa.TabIndex = 1;
            // 
            // txtPTTen
            // 
            this.txtPTTen.Location = new System.Drawing.Point(120, 320);
            this.txtPTTen.Name = "txtPTTen";
            this.txtPTTen.Size = new System.Drawing.Size(150, 22);
            this.txtPTTen.TabIndex = 2;
            // 
            // txtPTGhiChu
            // 
            this.txtPTGhiChu.Location = new System.Drawing.Point(280, 320);
            this.txtPTGhiChu.Name = "txtPTGhiChu";
            this.txtPTGhiChu.Size = new System.Drawing.Size(150, 22);
            this.txtPTGhiChu.TabIndex = 3;
            // 
            // btnThemPT
            // 
            this.btnThemPT.Location = new System.Drawing.Point(450, 318);
            this.btnThemPT.Name = "btnThemPT";
            this.btnThemPT.Size = new System.Drawing.Size(100, 30);
            this.btnThemPT.TabIndex = 4;
            this.btnThemPT.Text = "Thêm";
            this.btnThemPT.UseVisualStyleBackColor = true;
            this.btnThemPT.Click += new System.EventHandler(this.btnThemPT_Click);
            // 
            // tabDB
            // 
            this.tabDB.Controls.Add(this.btnThemDB);
            this.tabDB.Controls.Add(this.txtDBDT);
            this.tabDB.Controls.Add(this.txtDBDiaChi);
            this.tabDB.Controls.Add(this.txtDBTen);
            this.tabDB.Controls.Add(this.txtDBMa);
            this.tabDB.Controls.Add(this.dgvDB);
            this.tabDB.Location = new System.Drawing.Point(4, 25);
            this.tabDB.Name = "tabDB";
            this.tabDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabDB.Size = new System.Drawing.Size(752, 451);
            this.tabDB.TabIndex = 1;
            this.tabDB.Text = "Điểm bán vé";
            this.tabDB.UseVisualStyleBackColor = true;
            // 
            // dgvDB
            // 
            this.dgvDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDB.Location = new System.Drawing.Point(6, 6);
            this.dgvDB.Name = "dgvDB";
            this.dgvDB.RowHeadersWidth = 51;
            this.dgvDB.RowTemplate.Height = 24;
            this.dgvDB.Size = new System.Drawing.Size(740, 300);
            this.dgvDB.TabIndex = 0;
            // 
            // txtDBMa
            // 
            this.txtDBMa.Location = new System.Drawing.Point(6, 320);
            this.txtDBMa.Name = "txtDBMa";
            this.txtDBMa.Size = new System.Drawing.Size(100, 22);
            this.txtDBMa.TabIndex = 1;
            // 
            // txtDBTen
            // 
            this.txtDBTen.Location = new System.Drawing.Point(120, 320);
            this.txtDBTen.Name = "txtDBTen";
            this.txtDBTen.Size = new System.Drawing.Size(150, 22);
            this.txtDBTen.TabIndex = 2;
            // 
            // txtDBDiaChi
            // 
            this.txtDBDiaChi.Location = new System.Drawing.Point(280, 320);
            this.txtDBDiaChi.Name = "txtDBDiaChi";
            this.txtDBDiaChi.Size = new System.Drawing.Size(150, 22);
            this.txtDBDiaChi.TabIndex = 3;
            // 
            // txtDBDT
            // 
            this.txtDBDT.Location = new System.Drawing.Point(440, 320);
            this.txtDBDT.Name = "txtDBDT";
            this.txtDBDT.Size = new System.Drawing.Size(150, 22);
            this.txtDBDT.TabIndex = 4;
            // 
            // btnThemDB
            // 
            this.btnThemDB.Location = new System.Drawing.Point(600, 318);
            this.btnThemDB.Name = "btnThemDB";
            this.btnThemDB.Size = new System.Drawing.Size(100, 30);
            this.btnThemDB.TabIndex = 5;
            this.btnThemDB.Text = "Thêm";
            this.btnThemDB.UseVisualStyleBackColor = true;
            this.btnThemDB.Click += new System.EventHandler(this.btnThemDB_Click);
            // 
            // tabHDV
            // 
            this.tabHDV.Controls.Add(this.btnThemHDV);
            this.tabHDV.Controls.Add(this.numLuong);
            this.tabHDV.Controls.Add(this.txtHDVDT);
            this.tabHDV.Controls.Add(this.txtHDVTen);
            this.tabHDV.Controls.Add(this.txtHDVMa);
            this.tabHDV.Controls.Add(this.dgvHDV);
            this.tabHDV.Location = new System.Drawing.Point(4, 25);
            this.tabHDV.Name = "tabHDV";
            this.tabHDV.Size = new System.Drawing.Size(752, 451);
            this.tabHDV.TabIndex = 2;
            this.tabHDV.Text = "Hướng dẫn viên";
            this.tabHDV.UseVisualStyleBackColor = true;
            // 
            // dgvHDV
            // 
            this.dgvHDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDV.Location = new System.Drawing.Point(6, 6);
            this.dgvHDV.Name = "dgvHDV";
            this.dgvHDV.RowHeadersWidth = 51;
            this.dgvHDV.RowTemplate.Height = 24;
            this.dgvHDV.Size = new System.Drawing.Size(740, 300);
            this.dgvHDV.TabIndex = 0;
            // 
            // txtHDVMa
            // 
            this.txtHDVMa.Location = new System.Drawing.Point(6, 320);
            this.txtHDVMa.Name = "txtHDVMa";
            this.txtHDVMa.Size = new System.Drawing.Size(100, 22);
            this.txtHDVMa.TabIndex = 1;
            // 
            // txtHDVTen
            // 
            this.txtHDVTen.Location = new System.Drawing.Point(120, 320);
            this.txtHDVTen.Name = "txtHDVTen";
            this.txtHDVTen.Size = new System.Drawing.Size(150, 22);
            this.txtHDVTen.TabIndex = 2;
            // 
            // txtHDVDT
            // 
            this.txtHDVDT.Location = new System.Drawing.Point(280, 320);
            this.txtHDVDT.Name = "txtHDVDT";
            this.txtHDVDT.Size = new System.Drawing.Size(150, 22);
            this.txtHDVDT.TabIndex = 3;
            // 
            // numLuong
            // 
            this.numLuong.Location = new System.Drawing.Point(440, 320);
            this.numLuong.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numLuong.Name = "numLuong";
            this.numLuong.Size = new System.Drawing.Size(120, 22);
            this.numLuong.TabIndex = 4;
            // 
            // btnThemHDV
            // 
            this.btnThemHDV.Location = new System.Drawing.Point(570, 318);
            this.btnThemHDV.Name = "btnThemHDV";
            this.btnThemHDV.Size = new System.Drawing.Size(100, 30);
            this.btnThemHDV.TabIndex = 5;
            this.btnThemHDV.Text = "Thêm";
            this.btnThemHDV.UseVisualStyleBackColor = true;
            this.btnThemHDV.Click += new System.EventHandler(this.btnThemHDV_Click);
            // 
            // tabDTQ
            // 
            this.tabDTQ.Controls.Add(this.btnThemDTQ);
            this.tabDTQ.Controls.Add(this.txtDTQYNghia);
            this.tabDTQ.Controls.Add(this.txtDTQNoiDung);
            this.tabDTQ.Controls.Add(this.txtDTQDiaDiem);
            this.tabDTQ.Controls.Add(this.txtDTQTen);
            this.tabDTQ.Controls.Add(this.txtDTQMa);
            this.tabDTQ.Controls.Add(this.dgvDTQ);
            this.tabDTQ.Location = new System.Drawing.Point(4, 25);
            this.tabDTQ.Name = "tabDTQ";
            this.tabDTQ.Size = new System.Drawing.Size(752, 451);
            this.tabDTQ.TabIndex = 3;
            this.tabDTQ.Text = "Điểm tham quan";
            this.tabDTQ.UseVisualStyleBackColor = true;
            // 
            // dgvDTQ
            // 
            this.dgvDTQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDTQ.Location = new System.Drawing.Point(6, 6);
            this.dgvDTQ.Name = "dgvDTQ";
            this.dgvDTQ.RowHeadersWidth = 51;
            this.dgvDTQ.RowTemplate.Height = 24;
            this.dgvDTQ.Size = new System.Drawing.Size(740, 300);
            this.dgvDTQ.TabIndex = 0;
            // 
            // txtDTQMa
            // 
            this.txtDTQMa.Location = new System.Drawing.Point(6, 320);
            this.txtDTQMa.Name = "txtDTQMa";
            this.txtDTQMa.Size = new System.Drawing.Size(100, 22);
            this.txtDTQMa.TabIndex = 1;
            // 
            // txtDTQTen
            // 
            this.txtDTQTen.Location = new System.Drawing.Point(120, 320);
            this.txtDTQTen.Name = "txtDTQTen";
            this.txtDTQTen.Size = new System.Drawing.Size(120, 22);
            this.txtDTQTen.TabIndex = 2;
            // 
            // txtDTQDiaDiem
            // 
            this.txtDTQDiaDiem.Location = new System.Drawing.Point(250, 320);
            this.txtDTQDiaDiem.Name = "txtDTQDiaDiem";
            this.txtDTQDiaDiem.Size = new System.Drawing.Size(120, 22);
            this.txtDTQDiaDiem.TabIndex = 3;
            // 
            // txtDTQNoiDung
            // 
            this.txtDTQNoiDung.Location = new System.Drawing.Point(380, 320);
            this.txtDTQNoiDung.Name = "txtDTQNoiDung";
            this.txtDTQNoiDung.Size = new System.Drawing.Size(120, 22);
            this.txtDTQNoiDung.TabIndex = 4;
            // 
            // txtDTQYNghia
            // 
            this.txtDTQYNghia.Location = new System.Drawing.Point(510, 320);
            this.txtDTQYNghia.Name = "txtDTQYNghia";
            this.txtDTQYNghia.Size = new System.Drawing.Size(120, 22);
            this.txtDTQYNghia.TabIndex = 5;
            // 
            // btnThemDTQ
            // 
            this.btnThemDTQ.Location = new System.Drawing.Point(640, 318);
            this.btnThemDTQ.Name = "btnThemDTQ";
            this.btnThemDTQ.Size = new System.Drawing.Size(100, 30);
            this.btnThemDTQ.TabIndex = 6;
            this.btnThemDTQ.Text = "Thêm";
            this.btnThemDTQ.UseVisualStyleBackColor = true;
            this.btnThemDTQ.Click += new System.EventHandler(this.btnThemDTQ_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(350, 510);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 35);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPT.ResumeLayout(false);
            this.tabPT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPT)).EndInit();
            this.tabDB.ResumeLayout(false);
            this.tabDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDB)).EndInit();
            this.tabHDV.ResumeLayout(false);
            this.tabHDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuong)).EndInit();
            this.tabDTQ.ResumeLayout(false);
            this.tabDTQ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDTQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPT;
        private System.Windows.Forms.DataGridView dgvPT;
        private System.Windows.Forms.TextBox txtPTMa;
        private System.Windows.Forms.TextBox txtPTTen;
        private System.Windows.Forms.TextBox txtPTGhiChu;
        private System.Windows.Forms.Button btnThemPT;
        
        private System.Windows.Forms.TabPage tabDB;
        private System.Windows.Forms.DataGridView dgvDB;
        private System.Windows.Forms.TextBox txtDBMa;
        private System.Windows.Forms.TextBox txtDBTen;
        private System.Windows.Forms.TextBox txtDBDiaChi;
        private System.Windows.Forms.TextBox txtDBDT;
        private System.Windows.Forms.Button btnThemDB;
        
        private System.Windows.Forms.TabPage tabHDV;
        private System.Windows.Forms.DataGridView dgvHDV;
        private System.Windows.Forms.TextBox txtHDVMa;
        private System.Windows.Forms.TextBox txtHDVTen;
        private System.Windows.Forms.TextBox txtHDVDT;
        private System.Windows.Forms.NumericUpDown numLuong;
        private System.Windows.Forms.Button btnThemHDV;
        
        private System.Windows.Forms.TabPage tabDTQ;
        private System.Windows.Forms.DataGridView dgvDTQ;
        private System.Windows.Forms.TextBox txtDTQMa;
        private System.Windows.Forms.TextBox txtDTQTen;
        private System.Windows.Forms.TextBox txtDTQDiaDiem;
        private System.Windows.Forms.TextBox txtDTQNoiDung;
        private System.Windows.Forms.TextBox txtDTQYNghia;
        private System.Windows.Forms.Button btnThemDTQ;
        
        private System.Windows.Forms.Button btnDong;
    }
}
