namespace QuanLyBenhAn.Forms
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnDangKyHoSo = new System.Windows.Forms.Button();
            this.btnLichDinhKy = new System.Windows.Forms.Button();
            this.btnKhamBenh = new System.Windows.Forms.Button();
            this.btnXetNghiem = new System.Windows.Forms.Button();
            this.btnToaThuoc = new System.Windows.Forms.Button();
            this.btnVienPhi = new System.Windows.Forms.Button();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(12, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(460, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ HỒ SƠ BỆNH ÁN\nBỆNH VIỆN ĐA KHOA QUỐC TẾ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDanhMuc.Location = new System.Drawing.Point(67, 90);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(350, 42);
            this.btnDanhMuc.TabIndex = 1;
            this.btnDanhMuc.Text = "1. Quản lý Danh mục (Khoa, BS, Thuốc, XN)";
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnDangKyHoSo
            // 
            this.btnDangKyHoSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKyHoSo.Location = new System.Drawing.Point(67, 138);
            this.btnDangKyHoSo.Name = "btnDangKyHoSo";
            this.btnDangKyHoSo.Size = new System.Drawing.Size(350, 42);
            this.btnDangKyHoSo.TabIndex = 2;
            this.btnDangKyHoSo.Text = "2. Đăng ký bệnh nhân - Lệ phí - Cấp hồ sơ";
            this.btnDangKyHoSo.UseVisualStyleBackColor = true;
            this.btnDangKyHoSo.Click += new System.EventHandler(this.btnDangKyHoSo_Click);
            // 
            // btnLichDinhKy
            // 
            this.btnLichDinhKy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichDinhKy.Location = new System.Drawing.Point(67, 186);
            this.btnLichDinhKy.Name = "btnLichDinhKy";
            this.btnLichDinhKy.Size = new System.Drawing.Size(350, 42);
            this.btnLichDinhKy.TabIndex = 3;
            this.btnLichDinhKy.Text = "3. Đặt lịch khám sức khỏe định kỳ theo quý";
            this.btnLichDinhKy.UseVisualStyleBackColor = true;
            this.btnLichDinhKy.Click += new System.EventHandler(this.btnLichDinhKy_Click);
            // 
            // btnKhamBenh
            // 
            this.btnKhamBenh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhamBenh.Location = new System.Drawing.Point(67, 234);
            this.btnKhamBenh.Name = "btnKhamBenh";
            this.btnKhamBenh.Size = new System.Drawing.Size(350, 42);
            this.btnKhamBenh.TabIndex = 4;
            this.btnKhamBenh.Text = "4. Khám bệnh (Triệu chứng, Thân nhiệt, Huyết áp)";
            this.btnKhamBenh.UseVisualStyleBackColor = true;
            this.btnKhamBenh.Click += new System.EventHandler(this.btnKhamBenh_Click);
            // 
            // btnXetNghiem
            // 
            this.btnXetNghiem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXetNghiem.Location = new System.Drawing.Point(67, 282);
            this.btnXetNghiem.Name = "btnXetNghiem";
            this.btnXetNghiem.Size = new System.Drawing.Size(350, 42);
            this.btnXetNghiem.TabIndex = 5;
            this.btnXetNghiem.Text = "5. Chỉ định và Ghi nhận kết quả xét nghiệm";
            this.btnXetNghiem.UseVisualStyleBackColor = true;
            this.btnXetNghiem.Click += new System.EventHandler(this.btnXetNghiem_Click);
            // 
            // btnToaThuoc
            // 
            this.btnToaThuoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToaThuoc.Location = new System.Drawing.Point(67, 330);
            this.btnToaThuoc.Name = "btnToaThuoc";
            this.btnToaThuoc.Size = new System.Drawing.Size(350, 42);
            this.btnToaThuoc.TabIndex = 6;
            this.btnToaThuoc.Text = "6. Kê toa thuốc điều trị";
            this.btnToaThuoc.UseVisualStyleBackColor = true;
            this.btnToaThuoc.Click += new System.EventHandler(this.btnToaThuoc_Click);
            // 
            // btnVienPhi
            // 
            this.btnVienPhi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVienPhi.Location = new System.Drawing.Point(67, 378);
            this.btnVienPhi.Name = "btnVienPhi";
            this.btnVienPhi.Size = new System.Drawing.Size(350, 42);
            this.btnVienPhi.TabIndex = 7;
            this.btnVienPhi.Text = "7. Thanh toán viện phí & Hoàn tất đợt điều trị";
            this.btnVienPhi.UseVisualStyleBackColor = true;
            this.btnVienPhi.Click += new System.EventHandler(this.btnVienPhi_Click);
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraCuu.Location = new System.Drawing.Point(67, 426);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(350, 42);
            this.btnTraCuu.TabIndex = 8;
            this.btnTraCuu.Text = "8. Tra cứu lý lịch bệnh án & Tiền sử";
            this.btnTraCuu.UseVisualStyleBackColor = true;
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(67, 480);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(350, 38);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát chương trình";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 536);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTraCuu);
            this.Controls.Add(this.btnVienPhi);
            this.Controls.Add(this.btnToaThuoc);
            this.Controls.Add(this.btnXetNghiem);
            this.Controls.Add(this.btnKhamBenh);
            this.Controls.Add(this.btnLichDinhKy);
            this.Controls.Add(this.btnDangKyHoSo);
            this.Controls.Add(this.btnDanhMuc);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Bệnh Án - Bệnh Viện Đa Khoa Quốc Tế";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnDangKyHoSo;
        private System.Windows.Forms.Button btnLichDinhKy;
        private System.Windows.Forms.Button btnKhamBenh;
        private System.Windows.Forms.Button btnXetNghiem;
        private System.Windows.Forms.Button btnToaThuoc;
        private System.Windows.Forms.Button btnVienPhi;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.Button btnThoat;
    }
}
