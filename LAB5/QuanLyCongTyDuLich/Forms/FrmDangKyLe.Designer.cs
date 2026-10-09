namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmDangKyLe
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
            this.txtSo = new System.Windows.Forms.TextBox();
            this.cboChuyen = new System.Windows.Forms.ComboBox();
            this.cboDiemBan = new System.Windows.Forms.ComboBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.numNguoi = new System.Windows.Forms.NumericUpDown();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.numNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            
            // label1 (Số đăng ký)
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số đăng ký:";
            
            // txtSo
            this.txtSo.Location = new System.Drawing.Point(100, 17);
            this.txtSo.Name = "txtSo";
            this.txtSo.Size = new System.Drawing.Size(150, 20);
            this.txtSo.TabIndex = 1;
            
            // label2 (Chuyến)
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Chuyến:";
            
            // cboChuyen
            this.cboChuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyen.FormattingEnabled = true;
            this.cboChuyen.Location = new System.Drawing.Point(100, 47);
            this.cboChuyen.Name = "cboChuyen";
            this.cboChuyen.Size = new System.Drawing.Size(350, 21);
            this.cboChuyen.TabIndex = 3;
            this.cboChuyen.SelectedIndexChanged += new System.EventHandler(this.TinhTien);
            
            // label3 (Điểm bán vé)
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Điểm bán vé:";
            
            // cboDiemBan
            this.cboDiemBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiemBan.FormattingEnabled = true;
            this.cboDiemBan.Location = new System.Drawing.Point(550, 47);
            this.cboDiemBan.Name = "cboDiemBan";
            this.cboDiemBan.Size = new System.Drawing.Size(200, 21);
            this.cboDiemBan.TabIndex = 5;
            
            // label4 (Người đăng ký)
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Người đăng ký:";
            
            // txtTen
            this.txtTen.Location = new System.Drawing.Point(100, 77);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(200, 20);
            this.txtTen.TabIndex = 7;
            
            // label5 (Điện thoại)
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Điện thoại:";
            
            // txtDT
            this.txtDT.Location = new System.Drawing.Point(380, 77);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(150, 20);
            this.txtDT.TabIndex = 9;
            
            // label6 (Số người)
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(550, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số người:";
            
            // numNguoi
            this.numNguoi.Location = new System.Drawing.Point(610, 77);
            this.numNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNguoi.Maximum = new decimal(new int[] { 11, 0, 0, 0 });
            this.numNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numNguoi.Name = "numNguoi";
            this.numNguoi.Size = new System.Drawing.Size(60, 20);
            this.numNguoi.TabIndex = 11;
            this.numNguoi.ValueChanged += new System.EventHandler(this.TinhTien);
            
            // label7 (Thành tiền)
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(690, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Thành tiền:";
            
            // lblThanhTien
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.ForeColor = System.Drawing.Color.Red;
            this.lblThanhTien.Location = new System.Drawing.Point(750, 80);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(25, 13);
            this.lblThanhTien.TabIndex = 13;
            this.lblThanhTien.Text = "0 đ";
            
            // btnDangKy
            this.btnDangKy.Location = new System.Drawing.Point(100, 110);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(150, 25);
            this.btnDangKy.TabIndex = 14;
            this.btnDangKy.Text = "Đăng ký và thanh toán vé";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            
            // dgv
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Location = new System.Drawing.Point(20, 150);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(840, 340);
            this.dgv.TabIndex = 15;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ReadOnly = true;
            
            // btnDong
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(785, 510);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 25);
            this.btnDong.TabIndex = 16;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            
            // FrmDangKyLe
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numNguoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboDiemBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboChuyen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSo);
            this.Controls.Add(this.label1);
            this.Name = "FrmDangKyLe";
            this.Text = "Đăng ký khách lẻ";
            this.Load += new System.EventHandler(this.FrmDangKyLe_Load);
            
            ((System.ComponentModel.ISupportInitialize)(this.numNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtSo;
        private System.Windows.Forms.ComboBox cboChuyen;
        private System.Windows.Forms.ComboBox cboDiemBan;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.NumericUpDown numNguoi;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDong;
        
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
