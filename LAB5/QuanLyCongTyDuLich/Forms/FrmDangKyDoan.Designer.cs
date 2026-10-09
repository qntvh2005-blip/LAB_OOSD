namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmDangKyDoan
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
            this.grpDoan = new System.Windows.Forms.GroupBox();
            this.txtMaDoan = new System.Windows.Forms.TextBox();
            this.txtTenCQ = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.txtDaiDien = new System.Windows.Forms.TextBox();
            
            this.grpDangKy = new System.Windows.Forms.GroupBox();
            this.txtSo = new System.Windows.Forms.TextBox();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.dtDi = new System.Windows.Forms.DateTimePicker();
            this.numNguoi = new System.Windows.Forms.NumericUpDown();
            this.txtDon = new System.Windows.Forms.TextBox();
            this.numCoc = new System.Windows.Forms.NumericUpDown();
            this.chkBH = new System.Windows.Forms.CheckBox();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.lblTong = new System.Windows.Forms.Label();
            
            this.dgvThanhVien = new System.Windows.Forms.DataGridView();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();

            // Labels
            this.lblMaDoan = new System.Windows.Forms.Label();
            this.lblTenCQ = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.lblDT = new System.Windows.Forms.Label();
            this.lblDaiDien = new System.Windows.Forms.Label();
            this.lblSo = new System.Windows.Forms.Label();
            this.lblTour = new System.Windows.Forms.Label();
            this.lblKHD = new System.Windows.Forms.Label();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.lblDon = new System.Windows.Forms.Label();
            this.lblCoc = new System.Windows.Forms.Label();
            this.lblKHKT = new System.Windows.Forms.Label();
            this.lblTT = new System.Windows.Forms.Label();

            this.grpDoan.SuspendLayout();
            this.grpDangKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            
            // grpDoan
            this.grpDoan.Controls.Add(this.lblDaiDien);
            this.grpDoan.Controls.Add(this.txtDaiDien);
            this.grpDoan.Controls.Add(this.lblDT);
            this.grpDoan.Controls.Add(this.txtDT);
            this.grpDoan.Controls.Add(this.lblDiaChi);
            this.grpDoan.Controls.Add(this.txtDiaChi);
            this.grpDoan.Controls.Add(this.lblTenCQ);
            this.grpDoan.Controls.Add(this.txtTenCQ);
            this.grpDoan.Controls.Add(this.lblMaDoan);
            this.grpDoan.Controls.Add(this.txtMaDoan);
            this.grpDoan.Location = new System.Drawing.Point(12, 12);
            this.grpDoan.Name = "grpDoan";
            this.grpDoan.Size = new System.Drawing.Size(350, 200);
            this.grpDoan.TabIndex = 0;
            this.grpDoan.TabStop = false;
            this.grpDoan.Text = "Thông tin đoàn khách";
            
            // lblMaDoan
            this.lblMaDoan.AutoSize = true;
            this.lblMaDoan.Location = new System.Drawing.Point(15, 30);
            this.lblMaDoan.Name = "lblMaDoan";
            this.lblMaDoan.Size = new System.Drawing.Size(53, 13);
            this.lblMaDoan.Text = "Mã đoàn:";
            // txtMaDoan
            this.txtMaDoan.Location = new System.Drawing.Point(110, 27);
            this.txtMaDoan.Name = "txtMaDoan";
            this.txtMaDoan.Size = new System.Drawing.Size(220, 20);
            
            // lblTenCQ
            this.lblTenCQ.AutoSize = true;
            this.lblTenCQ.Location = new System.Drawing.Point(15, 60);
            this.lblTenCQ.Name = "lblTenCQ";
            this.lblTenCQ.Size = new System.Drawing.Size(73, 13);
            this.lblTenCQ.Text = "Tên cơ quan:";
            // txtTenCQ
            this.txtTenCQ.Location = new System.Drawing.Point(110, 57);
            this.txtTenCQ.Name = "txtTenCQ";
            this.txtTenCQ.Size = new System.Drawing.Size(220, 20);
            
            // lblDiaChi
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 90);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(43, 13);
            this.lblDiaChi.Text = "Địa chỉ:";
            // txtDiaChi
            this.txtDiaChi.Location = new System.Drawing.Point(110, 87);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(220, 20);
            
            // lblDT
            this.lblDT.AutoSize = true;
            this.lblDT.Location = new System.Drawing.Point(15, 120);
            this.lblDT.Name = "lblDT";
            this.lblDT.Size = new System.Drawing.Size(58, 13);
            this.lblDT.Text = "Điện thoại:";
            // txtDT
            this.txtDT.Location = new System.Drawing.Point(110, 117);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(220, 20);
            
            // lblDaiDien
            this.lblDaiDien.AutoSize = true;
            this.lblDaiDien.Location = new System.Drawing.Point(15, 150);
            this.lblDaiDien.Name = "lblDaiDien";
            this.lblDaiDien.Size = new System.Drawing.Size(79, 13);
            this.lblDaiDien.Text = "Người đại diện:";
            // txtDaiDien
            this.txtDaiDien.Location = new System.Drawing.Point(110, 147);
            this.txtDaiDien.Name = "txtDaiDien";
            this.txtDaiDien.Size = new System.Drawing.Size(220, 20);

            // grpDangKy
            this.grpDangKy.Controls.Add(this.lblTT);
            this.grpDangKy.Controls.Add(this.lblTong);
            this.grpDangKy.Controls.Add(this.lblKHKT);
            this.grpDangKy.Controls.Add(this.lblKetThuc);
            this.grpDangKy.Controls.Add(this.chkBH);
            this.grpDangKy.Controls.Add(this.lblCoc);
            this.grpDangKy.Controls.Add(this.numCoc);
            this.grpDangKy.Controls.Add(this.lblDon);
            this.grpDangKy.Controls.Add(this.txtDon);
            this.grpDangKy.Controls.Add(this.lblSoNguoi);
            this.grpDangKy.Controls.Add(this.numNguoi);
            this.grpDangKy.Controls.Add(this.lblKHD);
            this.grpDangKy.Controls.Add(this.dtDi);
            this.grpDangKy.Controls.Add(this.lblTour);
            this.grpDangKy.Controls.Add(this.cboTour);
            this.grpDangKy.Controls.Add(this.lblSo);
            this.grpDangKy.Controls.Add(this.txtSo);
            this.grpDangKy.Location = new System.Drawing.Point(380, 12);
            this.grpDangKy.Name = "grpDangKy";
            this.grpDangKy.Size = new System.Drawing.Size(600, 200);
            this.grpDangKy.TabIndex = 1;
            this.grpDangKy.TabStop = false;
            this.grpDangKy.Text = "Đăng ký tour";
            
            // lblSo
            this.lblSo.AutoSize = true;
            this.lblSo.Location = new System.Drawing.Point(15, 30);
            this.lblSo.Size = new System.Drawing.Size(65, 13);
            this.lblSo.Text = "Số đăng ký:";
            // txtSo
            this.txtSo.Location = new System.Drawing.Point(100, 27);
            this.txtSo.Size = new System.Drawing.Size(150, 20);
            
            // lblTour
            this.lblTour.AutoSize = true;
            this.lblTour.Location = new System.Drawing.Point(15, 60);
            this.lblTour.Size = new System.Drawing.Size(32, 13);
            this.lblTour.Text = "Tour:";
            // cboTour
            this.cboTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTour.FormattingEnabled = true;
            this.cboTour.Location = new System.Drawing.Point(100, 57);
            this.cboTour.Size = new System.Drawing.Size(480, 21);
            this.cboTour.SelectedIndexChanged += new System.EventHandler(this.TinhTong);
            
            // lblKHD
            this.lblKHD.AutoSize = true;
            this.lblKHD.Location = new System.Drawing.Point(15, 90);
            this.lblKHD.Size = new System.Drawing.Size(81, 13);
            this.lblKHD.Text = "Ngày khởi hành:";
            // dtDi
            this.dtDi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDi.Location = new System.Drawing.Point(100, 87);
            this.dtDi.Size = new System.Drawing.Size(120, 20);
            this.dtDi.ValueChanged += new System.EventHandler(this.TinhTong);
            
            // lblKHKT
            this.lblKHKT.AutoSize = true;
            this.lblKHKT.Location = new System.Drawing.Point(240, 90);
            this.lblKHKT.Size = new System.Drawing.Size(77, 13);
            this.lblKHKT.Text = "Ngày kết thúc:";
            // lblKetThuc
            this.lblKetThuc.AutoSize = true;
            this.lblKetThuc.Location = new System.Drawing.Point(330, 90);
            this.lblKetThuc.Size = new System.Drawing.Size(10, 13);
            this.lblKetThuc.Text = "-";
            
            // lblSoNguoi
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Location = new System.Drawing.Point(15, 120);
            this.lblSoNguoi.Size = new System.Drawing.Size(52, 13);
            this.lblSoNguoi.Text = "Số người:";
            // numNguoi
            this.numNguoi.Location = new System.Drawing.Point(100, 117);
            this.numNguoi.Minimum = new decimal(new int[] { 13, 0, 0, 0 });
            this.numNguoi.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            this.numNguoi.Value = new decimal(new int[] { 13, 0, 0, 0 });
            this.numNguoi.Size = new System.Drawing.Size(80, 20);
            this.numNguoi.ValueChanged += new System.EventHandler(this.TinhTong);
            
            // chkBH
            this.chkBH.AutoSize = true;
            this.chkBH.Location = new System.Drawing.Point(240, 118);
            this.chkBH.Size = new System.Drawing.Size(160, 17);
            this.chkBH.Text = "Đăng ký bảo hiểm đoàn";
            this.chkBH.CheckedChanged += new System.EventHandler(this.chkBH_CheckedChanged);
            
            // lblDon
            this.lblDon.AutoSize = true;
            this.lblDon.Location = new System.Drawing.Point(15, 150);
            this.lblDon.Size = new System.Drawing.Size(65, 13);
            this.lblDon.Text = "Nơi đón trả:";
            // txtDon
            this.txtDon.Location = new System.Drawing.Point(100, 147);
            this.txtDon.Size = new System.Drawing.Size(480, 20);
            
            // lblCoc
            this.lblCoc.AutoSize = true;
            this.lblCoc.Location = new System.Drawing.Point(15, 180);
            this.lblCoc.Size = new System.Drawing.Size(51, 13);
            this.lblCoc.Text = "Tiền cọc:";
            // numCoc
            this.numCoc.Location = new System.Drawing.Point(100, 177);
            this.numCoc.Maximum = new decimal(new int[] { 1410065407, 2, 0, 0 });
            this.numCoc.DecimalPlaces = 0;
            this.numCoc.Size = new System.Drawing.Size(120, 20);
            
            // lblTT
            this.lblTT.AutoSize = true;
            this.lblTT.Location = new System.Drawing.Point(380, 120);
            this.lblTT.Size = new System.Drawing.Size(61, 13);
            this.lblTT.Text = "Tổng cộng:";
            // lblTong
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTong.ForeColor = System.Drawing.Color.Red;
            this.lblTong.Location = new System.Drawing.Point(450, 120);
            this.lblTong.Size = new System.Drawing.Size(25, 13);
            this.lblTong.Text = "0 đ";

            // dgvThanhVien
            this.dgvThanhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThanhVien.Location = new System.Drawing.Point(12, 230);
            this.dgvThanhVien.Name = "dgvThanhVien";
            this.dgvThanhVien.Size = new System.Drawing.Size(968, 150);
            this.dgvThanhVien.TabIndex = 2;
            
            // btnDangKy
            this.btnDangKy.Location = new System.Drawing.Point(12, 390);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(150, 25);
            this.btnDangKy.TabIndex = 3;
            this.btnDangKy.Text = "Lập phiếu đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            
            // btnHuy
            this.btnHuy.Location = new System.Drawing.Point(175, 390);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(150, 25);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy phiếu (mất cọc)";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            
            // dgv
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Location = new System.Drawing.Point(12, 430);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(968, 220);
            this.dgv.TabIndex = 5;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            
            // btnDong
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(905, 665);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 25);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            
            // FrmDangKyDoan
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.dgvThanhVien);
            this.Controls.Add(this.grpDangKy);
            this.Controls.Add(this.grpDoan);
            this.Name = "FrmDangKyDoan";
            this.Text = "Đăng ký theo đoàn";
            this.Load += new System.EventHandler(this.FrmDangKyDoan_Load);
            
            this.grpDoan.ResumeLayout(false);
            this.grpDoan.PerformLayout();
            this.grpDangKy.ResumeLayout(false);
            this.grpDangKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThanhVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox grpDoan;
        private System.Windows.Forms.TextBox txtMaDoan;
        private System.Windows.Forms.TextBox txtTenCQ;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.TextBox txtDaiDien;
        
        private System.Windows.Forms.GroupBox grpDangKy;
        private System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.DateTimePicker dtDi;
        private System.Windows.Forms.NumericUpDown numNguoi;
        private System.Windows.Forms.TextBox txtDon;
        private System.Windows.Forms.NumericUpDown numCoc;
        private System.Windows.Forms.CheckBox chkBH;
        private System.Windows.Forms.Label lblKetThuc;
        private System.Windows.Forms.Label lblTong;
        
        private System.Windows.Forms.DataGridView dgvThanhVien;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;

        // Labels
        private System.Windows.Forms.Label lblMaDoan;
        private System.Windows.Forms.Label lblTenCQ;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.Label lblDT;
        private System.Windows.Forms.Label lblDaiDien;
        private System.Windows.Forms.Label lblSo;
        private System.Windows.Forms.Label lblTour;
        private System.Windows.Forms.Label lblKHD;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.Label lblDon;
        private System.Windows.Forms.Label lblCoc;
        private System.Windows.Forms.Label lblKHKT;
        private System.Windows.Forms.Label lblTT;
    }
}
