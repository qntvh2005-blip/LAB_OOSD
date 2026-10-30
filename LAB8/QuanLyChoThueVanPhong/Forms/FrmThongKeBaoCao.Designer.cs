namespace QuanLyChoThueVanPhong.Forms
{
    partial class FrmThongKeBaoCao
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
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.dgvPhongStatus = new System.Windows.Forms.DataGridView();
            this.tabDoanhThuThue = new System.Windows.Forms.TabPage();
            this.dgvDoanhThuThue = new System.Windows.Forms.DataGridView();
            this.pnlTopThue = new System.Windows.Forms.Panel();
            this.btnXemDoanhThuThue = new System.Windows.Forms.Button();
            this.numNamThue = new System.Windows.Forms.NumericUpDown();
            this.lblNamThue = new System.Windows.Forms.Label();
            this.tabDoanhThuDV = new System.Windows.Forms.TabPage();
            this.dgvDoanhThuDV = new System.Windows.Forms.DataGridView();
            this.pnlTopDV = new System.Windows.Forms.Panel();
            this.btnXemDoanhThuDV = new System.Windows.Forms.Button();
            this.numNamDV = new System.Windows.Forms.NumericUpDown();
            this.lblNamDV = new System.Windows.Forms.Label();
            this.tabCongNo = new System.Windows.Forms.TabPage();
            this.dgvCongNoToanBo = new System.Windows.Forms.DataGridView();
            this.pnlTopCongNo = new System.Windows.Forms.Panel();
            this.btnTaiLaiCongNo = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongStatus)).BeginInit();
            this.tabDoanhThuThue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThuThue)).BeginInit();
            this.pnlTopThue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamThue)).BeginInit();
            this.tabDoanhThuDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThuDV)).BeginInit();
            this.pnlTopDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDV)).BeginInit();
            this.tabCongNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongNoToanBo)).BeginInit();
            this.pnlTopCongNo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPhong);
            this.tabMain.Controls.Add(this.tabDoanhThuThue);
            this.tabMain.Controls.Add(this.tabDoanhThuDV);
            this.tabMain.Controls.Add(this.tabCongNo);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1004, 610);
            this.tabMain.TabIndex = 0;
            // 
            // tabPhong
            // 
            this.tabPhong.Controls.Add(this.dgvPhongStatus);
            this.tabPhong.Location = new System.Drawing.Point(4, 24);
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.Padding = new System.Windows.Forms.Padding(3);
            this.tabPhong.Size = new System.Drawing.Size(996, 582);
            this.tabPhong.TabIndex = 0;
            this.tabPhong.Text = "Tình Trạng & Tỷ Lệ Lấp Đầy Văn Phòng Theo Tầng";
            this.tabPhong.UseVisualStyleBackColor = true;
            // 
            // dgvPhongStatus
            // 
            this.dgvPhongStatus.AllowUserToAddRows = false;
            this.dgvPhongStatus.AllowUserToDeleteRows = false;
            this.dgvPhongStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhongStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhongStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhongStatus.Location = new System.Drawing.Point(3, 3);
            this.dgvPhongStatus.MultiSelect = false;
            this.dgvPhongStatus.Name = "dgvPhongStatus";
            this.dgvPhongStatus.ReadOnly = true;
            this.dgvPhongStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhongStatus.Size = new System.Drawing.Size(990, 576);
            this.dgvPhongStatus.TabIndex = 0;
            // 
            // tabDoanhThuThue
            // 
            this.tabDoanhThuThue.Controls.Add(this.dgvDoanhThuThue);
            this.tabDoanhThuThue.Controls.Add(this.pnlTopThue);
            this.tabDoanhThuThue.Location = new System.Drawing.Point(4, 24);
            this.tabDoanhThuThue.Name = "tabDoanhThuThue";
            this.tabDoanhThuThue.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThuThue.Size = new System.Drawing.Size(996, 582);
            this.tabDoanhThuThue.TabIndex = 1;
            this.tabDoanhThuThue.Text = "Báo Cáo Doanh Thu Cho Thuê Văn Phòng";
            this.tabDoanhThuThue.UseVisualStyleBackColor = true;
            // 
            // dgvDoanhThuThue
            // 
            this.dgvDoanhThuThue.AllowUserToAddRows = false;
            this.dgvDoanhThuThue.AllowUserToDeleteRows = false;
            this.dgvDoanhThuThue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThuThue.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThuThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThuThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThuThue.Location = new System.Drawing.Point(3, 53);
            this.dgvDoanhThuThue.MultiSelect = false;
            this.dgvDoanhThuThue.Name = "dgvDoanhThuThue";
            this.dgvDoanhThuThue.ReadOnly = true;
            this.dgvDoanhThuThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThuThue.Size = new System.Drawing.Size(990, 526);
            this.dgvDoanhThuThue.TabIndex = 1;
            // 
            // pnlTopThue
            // 
            this.pnlTopThue.Controls.Add(this.btnXemDoanhThuThue);
            this.pnlTopThue.Controls.Add(this.numNamThue);
            this.pnlTopThue.Controls.Add(this.lblNamThue);
            this.pnlTopThue.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopThue.Location = new System.Drawing.Point(3, 3);
            this.pnlTopThue.Name = "pnlTopThue";
            this.pnlTopThue.Size = new System.Drawing.Size(990, 50);
            this.pnlTopThue.TabIndex = 0;
            // 
            // btnXemDoanhThuThue
            // 
            this.btnXemDoanhThuThue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnXemDoanhThuThue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDoanhThuThue.ForeColor = System.Drawing.Color.White;
            this.btnXemDoanhThuThue.Location = new System.Drawing.Point(210, 10);
            this.btnXemDoanhThuThue.Name = "btnXemDoanhThuThue";
            this.btnXemDoanhThuThue.Size = new System.Drawing.Size(120, 30);
            this.btnXemDoanhThuThue.TabIndex = 2;
            this.btnXemDoanhThuThue.Text = "Xem Báo Cáo";
            this.btnXemDoanhThuThue.UseVisualStyleBackColor = false;
            this.btnXemDoanhThuThue.Click += new System.EventHandler(this.btnXemDoanhThuThue_Click);
            // 
            // numNamThue
            // 
            this.numNamThue.Location = new System.Drawing.Point(90, 14);
            this.numNamThue.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNamThue.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numNamThue.Name = "numNamThue";
            this.numNamThue.Size = new System.Drawing.Size(100, 23);
            this.numNamThue.TabIndex = 1;
            this.numNamThue.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblNamThue
            // 
            this.lblNamThue.AutoSize = true;
            this.lblNamThue.Location = new System.Drawing.Point(15, 17);
            this.lblNamThue.Name = "lblNamThue";
            this.lblNamThue.Size = new System.Drawing.Size(65, 15);
            this.lblNamThue.TabIndex = 0;
            this.lblNamThue.Text = "Chọn năm:";
            // 
            // tabDoanhThuDV
            // 
            this.tabDoanhThuDV.Controls.Add(this.dgvDoanhThuDV);
            this.tabDoanhThuDV.Controls.Add(this.pnlTopDV);
            this.tabDoanhThuDV.Location = new System.Drawing.Point(4, 24);
            this.tabDoanhThuDV.Name = "tabDoanhThuDV";
            this.tabDoanhThuDV.Padding = new System.Windows.Forms.Padding(3);
            this.tabDoanhThuDV.Size = new System.Drawing.Size(996, 582);
            this.tabDoanhThuDV.TabIndex = 2;
            this.tabDoanhThuDV.Text = "Báo Cáo Doanh Thu Dịch Vụ";
            this.tabDoanhThuDV.UseVisualStyleBackColor = true;
            // 
            // dgvDoanhThuDV
            // 
            this.dgvDoanhThuDV.AllowUserToAddRows = false;
            this.dgvDoanhThuDV.AllowUserToDeleteRows = false;
            this.dgvDoanhThuDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoanhThuDV.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThuDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThuDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDoanhThuDV.Location = new System.Drawing.Point(3, 53);
            this.dgvDoanhThuDV.MultiSelect = false;
            this.dgvDoanhThuDV.Name = "dgvDoanhThuDV";
            this.dgvDoanhThuDV.ReadOnly = true;
            this.dgvDoanhThuDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThuDV.Size = new System.Drawing.Size(990, 526);
            this.dgvDoanhThuDV.TabIndex = 2;
            // 
            // pnlTopDV
            // 
            this.pnlTopDV.Controls.Add(this.btnXemDoanhThuDV);
            this.pnlTopDV.Controls.Add(this.numNamDV);
            this.pnlTopDV.Controls.Add(this.lblNamDV);
            this.pnlTopDV.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopDV.Location = new System.Drawing.Point(3, 3);
            this.pnlTopDV.Name = "pnlTopDV";
            this.pnlTopDV.Size = new System.Drawing.Size(990, 50);
            this.pnlTopDV.TabIndex = 1;
            // 
            // btnXemDoanhThuDV
            // 
            this.btnXemDoanhThuDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnXemDoanhThuDV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDoanhThuDV.ForeColor = System.Drawing.Color.White;
            this.btnXemDoanhThuDV.Location = new System.Drawing.Point(210, 10);
            this.btnXemDoanhThuDV.Name = "btnXemDoanhThuDV";
            this.btnXemDoanhThuDV.Size = new System.Drawing.Size(120, 30);
            this.btnXemDoanhThuDV.TabIndex = 2;
            this.btnXemDoanhThuDV.Text = "Xem Báo Cáo";
            this.btnXemDoanhThuDV.UseVisualStyleBackColor = false;
            this.btnXemDoanhThuDV.Click += new System.EventHandler(this.btnXemDoanhThuDV_Click);
            // 
            // numNamDV
            // 
            this.numNamDV.Location = new System.Drawing.Point(90, 14);
            this.numNamDV.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNamDV.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numNamDV.Name = "numNamDV";
            this.numNamDV.Size = new System.Drawing.Size(100, 23);
            this.numNamDV.TabIndex = 1;
            this.numNamDV.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblNamDV
            // 
            this.lblNamDV.AutoSize = true;
            this.lblNamDV.Location = new System.Drawing.Point(15, 17);
            this.lblNamDV.Name = "lblNamDV";
            this.lblNamDV.Size = new System.Drawing.Size(65, 15);
            this.lblNamDV.TabIndex = 0;
            this.lblNamDV.Text = "Chọn năm:";
            // 
            // tabCongNo
            // 
            this.tabCongNo.Controls.Add(this.dgvCongNoToanBo);
            this.tabCongNo.Controls.Add(this.pnlTopCongNo);
            this.tabCongNo.Location = new System.Drawing.Point(4, 24);
            this.tabCongNo.Name = "tabCongNo";
            this.tabCongNo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCongNo.Size = new System.Drawing.Size(996, 582);
            this.tabCongNo.TabIndex = 3;
            this.tabCongNo.Text = "Tổng Hợp Công Nợ Toàn Cao Ốc";
            this.tabCongNo.UseVisualStyleBackColor = true;
            // 
            // dgvCongNoToanBo
            // 
            this.dgvCongNoToanBo.AllowUserToAddRows = false;
            this.dgvCongNoToanBo.AllowUserToDeleteRows = false;
            this.dgvCongNoToanBo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCongNoToanBo.BackgroundColor = System.Drawing.Color.White;
            this.dgvCongNoToanBo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCongNoToanBo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCongNoToanBo.Location = new System.Drawing.Point(3, 53);
            this.dgvCongNoToanBo.MultiSelect = false;
            this.dgvCongNoToanBo.Name = "dgvCongNoToanBo";
            this.dgvCongNoToanBo.ReadOnly = true;
            this.dgvCongNoToanBo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCongNoToanBo.Size = new System.Drawing.Size(990, 526);
            this.dgvCongNoToanBo.TabIndex = 2;
            // 
            // pnlTopCongNo
            // 
            this.pnlTopCongNo.Controls.Add(this.btnTaiLaiCongNo);
            this.pnlTopCongNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopCongNo.Location = new System.Drawing.Point(3, 3);
            this.pnlTopCongNo.Name = "pnlTopCongNo";
            this.pnlTopCongNo.Size = new System.Drawing.Size(990, 50);
            this.pnlTopCongNo.TabIndex = 1;
            // 
            // btnTaiLaiCongNo
            // 
            this.btnTaiLaiCongNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnTaiLaiCongNo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiLaiCongNo.ForeColor = System.Drawing.Color.White;
            this.btnTaiLaiCongNo.Location = new System.Drawing.Point(15, 10);
            this.btnTaiLaiCongNo.Name = "btnTaiLaiCongNo";
            this.btnTaiLaiCongNo.Size = new System.Drawing.Size(150, 30);
            this.btnTaiLaiCongNo.TabIndex = 2;
            this.btnTaiLaiCongNo.Text = "Tải Lại Công Nợ";
            this.btnTaiLaiCongNo.UseVisualStyleBackColor = false;
            this.btnTaiLaiCongNo.Click += new System.EventHandler(this.btnTaiLaiCongNo_Click);
            // 
            // FrmThongKeBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 610);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1020, 630);
            this.Name = "FrmThongKeBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo Cáo & Thống Kê Quản Lý Cao Ốc Văn Phòng";
            this.tabMain.ResumeLayout(false);
            this.tabPhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongStatus)).EndInit();
            this.tabDoanhThuThue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThuThue)).EndInit();
            this.pnlTopThue.ResumeLayout(false);
            this.pnlTopThue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamThue)).EndInit();
            this.tabDoanhThuDV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThuDV)).EndInit();
            this.pnlTopDV.ResumeLayout(false);
            this.pnlTopDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNamDV)).EndInit();
            this.tabCongNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCongNoToanBo)).EndInit();
            this.pnlTopCongNo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.DataGridView dgvPhongStatus;
        private System.Windows.Forms.TabPage tabDoanhThuThue;
        private System.Windows.Forms.Panel pnlTopThue;
        private System.Windows.Forms.Button btnXemDoanhThuThue;
        private System.Windows.Forms.NumericUpDown numNamThue;
        private System.Windows.Forms.Label lblNamThue;
        private System.Windows.Forms.DataGridView dgvDoanhThuThue;
        private System.Windows.Forms.TabPage tabDoanhThuDV;
        private System.Windows.Forms.Panel pnlTopDV;
        private System.Windows.Forms.Button btnXemDoanhThuDV;
        private System.Windows.Forms.NumericUpDown numNamDV;
        private System.Windows.Forms.Label lblNamDV;
        private System.Windows.Forms.DataGridView dgvDoanhThuDV;
        private System.Windows.Forms.TabPage tabCongNo;
        private System.Windows.Forms.Panel pnlTopCongNo;
        private System.Windows.Forms.Button btnTaiLaiCongNo;
        private System.Windows.Forms.DataGridView dgvCongNoToanBo;
    }
}
