namespace QuanLyKhachSan.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnPhong = new System.Windows.Forms.Button();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.btnDichVu = new System.Windows.Forms.Button();
            this.btnTraPhong = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // lblTitle
            this.lblTitle.Location = new System.Drawing.Point(35, 30);
            this.lblTitle.Size = new System.Drawing.Size(930, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(17, 60, 104);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // btnDanhMuc
            this.btnDanhMuc.Location = new System.Drawing.Point(30, 135);
            this.btnDanhMuc.Size = new System.Drawing.Size(290, 85);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.TabIndex = 1;
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("btnDanhMuc.Image")));
            this.btnDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhMuc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDanhMuc.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);
            this.btnDanhMuc.Font = new System.Drawing.Font("Segoe UI", 11F);
            // btnPhong
            this.btnPhong.Location = new System.Drawing.Point(355, 135);
            this.btnPhong.Size = new System.Drawing.Size(290, 85);
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.TabIndex = 2;
            this.btnPhong.Text = "Phòng - Tiện nghi";
            this.btnPhong.UseVisualStyleBackColor = true;
            this.btnPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnPhong.Image")));
            this.btnPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPhong.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);
            this.btnPhong.Font = new System.Drawing.Font("Segoe UI", 11F);
            // btnDatPhong
            this.btnDatPhong.Location = new System.Drawing.Point(680, 135);
            this.btnDatPhong.Size = new System.Drawing.Size(290, 85);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.TabIndex = 3;
            this.btnDatPhong.Text = "Đặt / Nhận phòng";
            this.btnDatPhong.UseVisualStyleBackColor = true;
            this.btnDatPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnDatPhong.Image")));
            this.btnDatPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDatPhong.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);
            this.btnDatPhong.Font = new System.Drawing.Font("Segoe UI", 11F);
            // btnDichVu
            this.btnDichVu.Location = new System.Drawing.Point(30, 250);
            this.btnDichVu.Size = new System.Drawing.Size(290, 85);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.TabIndex = 4;
            this.btnDichVu.Text = "Sử dụng dịch vụ";
            this.btnDichVu.UseVisualStyleBackColor = true;
            this.btnDichVu.Image = ((System.Drawing.Image)(resources.GetObject("btnDichVu.Image")));
            this.btnDichVu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDichVu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDichVu.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);
            this.btnDichVu.Font = new System.Drawing.Font("Segoe UI", 11F);
            // btnTraPhong
            this.btnTraPhong.Location = new System.Drawing.Point(355, 250);
            this.btnTraPhong.Size = new System.Drawing.Size(290, 85);
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.TabIndex = 5;
            this.btnTraPhong.Text = "Trả phòng - Thanh toán";
            this.btnTraPhong.UseVisualStyleBackColor = true;
            this.btnTraPhong.Image = ((System.Drawing.Image)(resources.GetObject("btnTraPhong.Image")));
            this.btnTraPhong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTraPhong.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);
            this.btnTraPhong.Font = new System.Drawing.Font("Segoe UI", 11F);
            // btnThongKe
            this.btnThongKe.Location = new System.Drawing.Point(680, 250);
            this.btnThongKe.Size = new System.Drawing.Size(290, 85);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.TabIndex = 6;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 11F);
            // btnThoat
            this.btnThoat.Location = new System.Drawing.Point(355, 365);
            this.btnThoat.Size = new System.Drawing.Size(290, 80);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.Padding = new System.Windows.Forms.Padding(16, 0, 8, 0);
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDanhMuc);
            this.Controls.Add(this.btnPhong);
            this.Controls.Add(this.btnDatPhong);
            this.Controls.Add(this.btnDichVu);
            this.Controls.Add(this.btnTraPhong);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnThoat);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 520);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "FrmMain";
            this.Text = "Quản lý khách sạn";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnPhong;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.Button btnDichVu;
        private System.Windows.Forms.Button btnTraPhong;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThoat;
    }
}
