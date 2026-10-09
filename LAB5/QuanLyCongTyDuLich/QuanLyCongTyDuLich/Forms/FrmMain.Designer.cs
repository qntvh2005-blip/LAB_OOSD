namespace QuanLyCongTyDuLich.Forms
{
    partial class FrmMain
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
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnTour = new System.Windows.Forms.Button();
            this.btnChuyenLe = new System.Windows.Forms.Button();
            this.btnDangKyLe = new System.Windows.Forms.Button();
            this.btnDangKyDoan = new System.Windows.Forms.Button();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Location = new System.Drawing.Point(67, 30);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(300, 40);
            this.btnDanhMuc.TabIndex = 0;
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnTour
            // 
            this.btnTour.Location = new System.Drawing.Point(67, 76);
            this.btnTour.Name = "btnTour";
            this.btnTour.Size = new System.Drawing.Size(300, 40);
            this.btnTour.TabIndex = 1;
            this.btnTour.Text = "Tour - hành trình";
            this.btnTour.UseVisualStyleBackColor = true;
            this.btnTour.Click += new System.EventHandler(this.btnTour_Click);
            // 
            // btnChuyenLe
            // 
            this.btnChuyenLe.Location = new System.Drawing.Point(67, 122);
            this.btnChuyenLe.Name = "btnChuyenLe";
            this.btnChuyenLe.Size = new System.Drawing.Size(300, 40);
            this.btnChuyenLe.TabIndex = 2;
            this.btnChuyenLe.Text = "Lịch chuyến khách lẻ";
            this.btnChuyenLe.UseVisualStyleBackColor = true;
            this.btnChuyenLe.Click += new System.EventHandler(this.btnChuyenLe_Click);
            // 
            // btnDangKyLe
            // 
            this.btnDangKyLe.Location = new System.Drawing.Point(67, 168);
            this.btnDangKyLe.Name = "btnDangKyLe";
            this.btnDangKyLe.Size = new System.Drawing.Size(300, 40);
            this.btnDangKyLe.TabIndex = 3;
            this.btnDangKyLe.Text = "Đăng ký khách lẻ";
            this.btnDangKyLe.UseVisualStyleBackColor = true;
            this.btnDangKyLe.Click += new System.EventHandler(this.btnDangKyLe_Click);
            // 
            // btnDangKyDoan
            // 
            this.btnDangKyDoan.Location = new System.Drawing.Point(67, 214);
            this.btnDangKyDoan.Name = "btnDangKyDoan";
            this.btnDangKyDoan.Size = new System.Drawing.Size(300, 40);
            this.btnDangKyDoan.TabIndex = 4;
            this.btnDangKyDoan.Text = "Đăng ký theo đoàn";
            this.btnDangKyDoan.UseVisualStyleBackColor = true;
            this.btnDangKyDoan.Click += new System.EventHandler(this.btnDangKyDoan_Click);
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Location = new System.Drawing.Point(67, 260);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(300, 40);
            this.btnPhanCong.TabIndex = 5;
            this.btnPhanCong.Text = "Phân công hướng dẫn viên";
            this.btnPhanCong.UseVisualStyleBackColor = true;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(67, 306);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(300, 40);
            this.btnKetThuc.TabIndex = 6;
            this.btnKetThuc.Text = "Kết thúc tour - khảo sát";
            this.btnKetThuc.UseVisualStyleBackColor = true;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(67, 352);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(300, 40);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Lương - thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(67, 398);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(300, 40);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 461);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.btnPhanCong);
            this.Controls.Add(this.btnDangKyDoan);
            this.Controls.Add(this.btnDangKyLe);
            this.Controls.Add(this.btnChuyenLe);
            this.Controls.Add(this.btnTour);
            this.Controls.Add(this.btnDanhMuc);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Công Ty Du Lịch Văn Hóa Việt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnTour;
        private System.Windows.Forms.Button btnChuyenLe;
        private System.Windows.Forms.Button btnDangKyLe;
        private System.Windows.Forms.Button btnDangKyDoan;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThoat;
    }
}
