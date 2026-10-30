namespace QuanLyChoThueVanPhong.Forms
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
            this.layoutRoot = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menuChucNang = new System.Windows.Forms.TableLayoutPanel();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnHopDong = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnDichVu = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnNhanVienTheXe = new System.Windows.Forms.Button();
            this.btnKiemTraXuPhat = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.layoutExit = new System.Windows.Forms.TableLayoutPanel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.layoutRoot.SuspendLayout();
            this.menuChucNang.SuspendLayout();
            this.layoutExit.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutRoot
            // 
            this.layoutRoot.ColumnCount = 1;
            this.layoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRoot.Controls.Add(this.lblTitle, 0, 0);
            this.layoutRoot.Controls.Add(this.menuChucNang, 0, 1);
            this.layoutRoot.Controls.Add(this.layoutExit, 0, 2);
            this.layoutRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRoot.Location = new System.Drawing.Point(0, 0);
            this.layoutRoot.Name = "layoutRoot";
            this.layoutRoot.Padding = new System.Windows.Forms.Padding(50, 14, 50, 26);
            this.layoutRoot.RowCount = 3;
            this.layoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.layoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.layoutRoot.Size = new System.Drawing.Size(800, 560);
            this.layoutRoot.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.lblTitle.Location = new System.Drawing.Point(53, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(694, 64);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ CHO THUÊ VĂN PHÒNG CAO ỐC";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuChucNang
            // 
            this.menuChucNang.ColumnCount = 2;
            this.menuChucNang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.menuChucNang.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.menuChucNang.Controls.Add(this.btnDanhMuc, 0, 0);
            this.menuChucNang.Controls.Add(this.btnHopDong, 1, 0);
            this.menuChucNang.Controls.Add(this.btnThanhToan, 0, 1);
            this.menuChucNang.Controls.Add(this.btnDichVu, 1, 1);
            this.menuChucNang.Controls.Add(this.btnGiaHan, 0, 2);
            this.menuChucNang.Controls.Add(this.btnNhanVienTheXe, 1, 2);
            this.menuChucNang.Controls.Add(this.btnKiemTraXuPhat, 0, 3);
            this.menuChucNang.Controls.Add(this.btnThongKe, 1, 3);
            this.menuChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuChucNang.Location = new System.Drawing.Point(53, 81);
            this.menuChucNang.Name = "menuChucNang";
            this.menuChucNang.RowCount = 4;
            this.menuChucNang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuChucNang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuChucNang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuChucNang.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.menuChucNang.Size = new System.Drawing.Size(694, 356);
            this.menuChucNang.TabIndex = 1;
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDanhMuc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnDanhMuc.Location = new System.Drawing.Point(8, 8);
            this.btnDanhMuc.Margin = new System.Windows.Forms.Padding(8);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(331, 73);
            this.btnDanhMuc.TabIndex = 0;
            this.btnDanhMuc.Text = "Danh mục tầng & phòng";
            this.btnDanhMuc.UseVisualStyleBackColor = false;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnHopDong
            // 
            this.btnHopDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnHopDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHopDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnHopDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHopDong.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnHopDong.Location = new System.Drawing.Point(355, 8);
            this.btnHopDong.Margin = new System.Windows.Forms.Padding(8);
            this.btnHopDong.Name = "btnHopDong";
            this.btnHopDong.Size = new System.Drawing.Size(331, 73);
            this.btnHopDong.TabIndex = 1;
            this.btnHopDong.Text = "Hợp đồng cho thuê văn phòng";
            this.btnHopDong.UseVisualStyleBackColor = false;
            this.btnHopDong.Click += new System.EventHandler(this.btnHopDong_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThanhToan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnThanhToan.Location = new System.Drawing.Point(8, 97);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(8);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(331, 73);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "Thanh toán tiền thuê (Tháng 7+)";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnDichVu
            // 
            this.btnDichVu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnDichVu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDichVu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnDichVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDichVu.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnDichVu.Location = new System.Drawing.Point(355, 97);
            this.btnDichVu.Margin = new System.Windows.Forms.Padding(8);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(331, 73);
            this.btnDichVu.TabIndex = 3;
            this.btnDichVu.Text = "Hóa đơn dịch vụ (Điện, nước...)";
            this.btnDichVu.UseVisualStyleBackColor = false;
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnGiaHan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiaHan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGiaHan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnGiaHan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiaHan.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnGiaHan.Location = new System.Drawing.Point(8, 186);
            this.btnGiaHan.Margin = new System.Windows.Forms.Padding(8);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(331, 73);
            this.btnGiaHan.TabIndex = 4;
            this.btnGiaHan.Text = "Lập phiếu gia hạn hợp đồng";
            this.btnGiaHan.UseVisualStyleBackColor = false;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnNhanVienTheXe
            // 
            this.btnNhanVienTheXe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnNhanVienTheXe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhanVienTheXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNhanVienTheXe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnNhanVienTheXe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVienTheXe.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnNhanVienTheXe.Location = new System.Drawing.Point(355, 186);
            this.btnNhanVienTheXe.Margin = new System.Windows.Forms.Padding(8);
            this.btnNhanVienTheXe.Name = "btnNhanVienTheXe";
            this.btnNhanVienTheXe.Size = new System.Drawing.Size(331, 73);
            this.btnNhanVienTheXe.TabIndex = 5;
            this.btnNhanVienTheXe.Text = "Báo cáo nhân viên & Thẻ giữ xe";
            this.btnNhanVienTheXe.UseVisualStyleBackColor = false;
            this.btnNhanVienTheXe.Click += new System.EventHandler(this.btnNhanVienTheXe_Click);
            // 
            // btnKiemTraXuPhat
            // 
            this.btnKiemTraXuPhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnKiemTraXuPhat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKiemTraXuPhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKiemTraXuPhat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnKiemTraXuPhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTraXuPhat.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnKiemTraXuPhat.Location = new System.Drawing.Point(8, 275);
            this.btnKiemTraXuPhat.Margin = new System.Windows.Forms.Padding(8);
            this.btnKiemTraXuPhat.Name = "btnKiemTraXuPhat";
            this.btnKiemTraXuPhat.Size = new System.Drawing.Size(331, 73);
            this.btnKiemTraXuPhat.TabIndex = 6;
            this.btnKiemTraXuPhat.Text = "Kiểm tra phòng & Xử phạt kết cấu";
            this.btnKiemTraXuPhat.UseVisualStyleBackColor = false;
            this.btnKiemTraXuPhat.Click += new System.EventHandler(this.btnKiemTraXuPhat_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThongKe.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnThongKe.Location = new System.Drawing.Point(355, 275);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(8);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(331, 73);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Báo cáo doanh thu & Công nợ";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // layoutExit
            // 
            this.layoutExit.ColumnCount = 3;
            this.layoutExit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutExit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutExit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.layoutExit.Controls.Add(this.btnThoat, 1, 0);
            this.layoutExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutExit.Location = new System.Drawing.Point(53, 443);
            this.layoutExit.Name = "layoutExit";
            this.layoutExit.Padding = new System.Windows.Forms.Padding(0, 18, 0, 12);
            this.layoutExit.RowCount = 1;
            this.layoutExit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutExit.Size = new System.Drawing.Size(694, 88);
            this.layoutExit.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnThoat.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnThoat.Location = new System.Drawing.Point(181, 26);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(8);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(331, 42);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát hệ thống";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.layoutRoot);
            this.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(760, 540);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý cho thuê văn phòng ở cao ốc";
            this.layoutRoot.ResumeLayout(false);
            this.menuChucNang.ResumeLayout(false);
            this.layoutExit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutRoot;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel menuChucNang;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnHopDong;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnDichVu;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnNhanVienTheXe;
        private System.Windows.Forms.Button btnKiemTraXuPhat;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.TableLayoutPanel layoutExit;
        private System.Windows.Forms.Button btnThoat;
    }
}
