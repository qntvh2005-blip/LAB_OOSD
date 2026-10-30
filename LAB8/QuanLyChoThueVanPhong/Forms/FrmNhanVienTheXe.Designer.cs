namespace QuanLyChoThueVanPhong.Forms
{
    partial class FrmNhanVienTheXe
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
            this.tabNV = new System.Windows.Forms.TabPage();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.pnlTopNV = new System.Windows.Forms.Panel();
            this.btnKhaiBaoNV = new System.Windows.Forms.Button();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.lblChucVu = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.lblCMND = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.tabTheXe = new System.Windows.Forms.TabPage();
            this.dgvTheXe = new System.Windows.Forms.DataGridView();
            this.pnlTopTheXe = new System.Windows.Forms.Panel();
            this.btnCapTheXe = new System.Windows.Forms.Button();
            this.txtMauXe = new System.Windows.Forms.TextBox();
            this.lblMauXe = new System.Windows.Forms.Label();
            this.txtNhanHieu = new System.Windows.Forms.TextBox();
            this.lblNhanHieu = new System.Windows.Forms.Label();
            this.cboLoaiXe = new System.Windows.Forms.ComboBox();
            this.lblLoaiXe = new System.Windows.Forms.Label();
            this.txtBienSo = new System.Windows.Forms.TextBox();
            this.lblBienSo = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.lblMaThe = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.pnlTopNV.SuspendLayout();
            this.tabTheXe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheXe)).BeginInit();
            this.pnlTopTheXe.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabNV);
            this.tabMain.Controls.Add(this.tabTheXe);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1004, 610);
            this.tabMain.TabIndex = 0;
            // 
            // tabNV
            // 
            this.tabNV.Controls.Add(this.dgvNhanVien);
            this.tabNV.Controls.Add(this.pnlTopNV);
            this.tabNV.Location = new System.Drawing.Point(4, 24);
            this.tabNV.Name = "tabNV";
            this.tabNV.Padding = new System.Windows.Forms.Padding(3);
            this.tabNV.Size = new System.Drawing.Size(996, 582);
            this.tabNV.TabIndex = 0;
            this.tabNV.Text = "Khai Báo Nhân Viên Làm Việc Tại Văn Phòng";
            this.tabNV.UseVisualStyleBackColor = true;
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.Location = new System.Drawing.Point(3, 113);
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Size = new System.Drawing.Size(990, 466);
            this.dgvNhanVien.TabIndex = 1;
            // 
            // pnlTopNV
            // 
            this.pnlTopNV.Controls.Add(this.btnKhaiBaoNV);
            this.pnlTopNV.Controls.Add(this.txtChucVu);
            this.pnlTopNV.Controls.Add(this.lblChucVu);
            this.pnlTopNV.Controls.Add(this.txtEmail);
            this.pnlTopNV.Controls.Add(this.lblEmail);
            this.pnlTopNV.Controls.Add(this.txtSDT);
            this.pnlTopNV.Controls.Add(this.lblSDT);
            this.pnlTopNV.Controls.Add(this.txtCMND);
            this.pnlTopNV.Controls.Add(this.lblCMND);
            this.pnlTopNV.Controls.Add(this.txtHoTen);
            this.pnlTopNV.Controls.Add(this.lblHoTen);
            this.pnlTopNV.Controls.Add(this.cboPhong);
            this.pnlTopNV.Controls.Add(this.lblPhong);
            this.pnlTopNV.Controls.Add(this.cboKhachHang);
            this.pnlTopNV.Controls.Add(this.lblKhachHang);
            this.pnlTopNV.Controls.Add(this.txtMaNV);
            this.pnlTopNV.Controls.Add(this.lblMaNV);
            this.pnlTopNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopNV.Location = new System.Drawing.Point(3, 3);
            this.pnlTopNV.Name = "pnlTopNV";
            this.pnlTopNV.Size = new System.Drawing.Size(990, 110);
            this.pnlTopNV.TabIndex = 0;
            // 
            // btnKhaiBaoNV
            // 
            this.btnKhaiBaoNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhaiBaoNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnKhaiBaoNV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhaiBaoNV.ForeColor = System.Drawing.Color.White;
            this.btnKhaiBaoNV.Location = new System.Drawing.Point(820, 60);
            this.btnKhaiBaoNV.Name = "btnKhaiBaoNV";
            this.btnKhaiBaoNV.Size = new System.Drawing.Size(155, 32);
            this.btnKhaiBaoNV.TabIndex = 16;
            this.btnKhaiBaoNV.Text = "+ Khai Báo NV";
            this.btnKhaiBaoNV.UseVisualStyleBackColor = false;
            this.btnKhaiBaoNV.Click += new System.EventHandler(this.btnKhaiBaoNV_Click);
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(620, 64);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(180, 23);
            this.txtChucVu.TabIndex = 15;
            // 
            // lblChucVu
            // 
            this.lblChucVu.AutoSize = true;
            this.lblChucVu.Location = new System.Drawing.Point(560, 67);
            this.lblChucVu.Name = "lblChucVu";
            this.lblChucVu.Size = new System.Drawing.Size(54, 15);
            this.lblChucVu.TabIndex = 14;
            this.lblChucVu.Text = "Chức vụ:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(340, 64);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);
            this.txtEmail.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(295, 67);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(85, 64);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(185, 23);
            this.txtSDT.TabIndex = 11;
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(15, 67);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(30, 15);
            this.lblSDT.TabIndex = 10;
            this.lblSDT.Text = "SĐT:";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(830, 20);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(145, 23);
            this.txtCMND.TabIndex = 9;
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Location = new System.Drawing.Point(780, 23);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(46, 15);
            this.lblCMND.TabIndex = 8;
            this.lblCMND.Text = "CCCD:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(620, 20);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(145, 23);
            this.txtHoTen.TabIndex = 7;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(560, 23);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(46, 15);
            this.lblHoTen.TabIndex = 6;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(395, 20);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(145, 23);
            this.cboPhong.TabIndex = 5;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(345, 23);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(45, 15);
            this.lblPhong.TabIndex = 4;
            this.lblPhong.Text = "Phòng:";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(185, 20);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(145, 23);
            this.cboKhachHang.TabIndex = 3;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.AutoSize = true;
            this.lblKhachHang.Location = new System.Drawing.Point(145, 23);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(37, 15);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "C.Ty:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(60, 20);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(75, 23);
            this.txtMaNV.TabIndex = 1;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(15, 23);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(46, 15);
            this.lblMaNV.TabIndex = 0;
            this.lblMaNV.Text = "Mã NV:";
            // 
            // tabTheXe
            // 
            this.tabTheXe.Controls.Add(this.dgvTheXe);
            this.tabTheXe.Controls.Add(this.pnlTopTheXe);
            this.tabTheXe.Location = new System.Drawing.Point(4, 24);
            this.tabTheXe.Name = "tabTheXe";
            this.tabTheXe.Padding = new System.Windows.Forms.Padding(3);
            this.tabTheXe.Size = new System.Drawing.Size(996, 582);
            this.tabTheXe.TabIndex = 1;
            this.tabTheXe.Text = "Cấp Thẻ Giữ Xe Cho Nhân Viên";
            this.tabTheXe.UseVisualStyleBackColor = true;
            // 
            // dgvTheXe
            // 
            this.dgvTheXe.AllowUserToAddRows = false;
            this.dgvTheXe.AllowUserToDeleteRows = false;
            this.dgvTheXe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTheXe.BackgroundColor = System.Drawing.Color.White;
            this.dgvTheXe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTheXe.Location = new System.Drawing.Point(3, 73);
            this.dgvTheXe.MultiSelect = false;
            this.dgvTheXe.Name = "dgvTheXe";
            this.dgvTheXe.ReadOnly = true;
            this.dgvTheXe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTheXe.Size = new System.Drawing.Size(990, 506);
            this.dgvTheXe.TabIndex = 1;
            // 
            // pnlTopTheXe
            // 
            this.pnlTopTheXe.Controls.Add(this.btnCapTheXe);
            this.pnlTopTheXe.Controls.Add(this.txtMauXe);
            this.pnlTopTheXe.Controls.Add(this.lblMauXe);
            this.pnlTopTheXe.Controls.Add(this.txtNhanHieu);
            this.pnlTopTheXe.Controls.Add(this.lblNhanHieu);
            this.pnlTopTheXe.Controls.Add(this.cboLoaiXe);
            this.pnlTopTheXe.Controls.Add(this.lblLoaiXe);
            this.pnlTopTheXe.Controls.Add(this.txtBienSo);
            this.pnlTopTheXe.Controls.Add(this.lblBienSo);
            this.pnlTopTheXe.Controls.Add(this.cboNhanVien);
            this.pnlTopTheXe.Controls.Add(this.lblNhanVien);
            this.pnlTopTheXe.Controls.Add(this.txtMaThe);
            this.pnlTopTheXe.Controls.Add(this.lblMaThe);
            this.pnlTopTheXe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopTheXe.Location = new System.Drawing.Point(3, 3);
            this.pnlTopTheXe.Name = "pnlTopTheXe";
            this.pnlTopTheXe.Size = new System.Drawing.Size(990, 70);
            this.pnlTopTheXe.TabIndex = 0;
            // 
            // btnCapTheXe
            // 
            this.btnCapTheXe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapTheXe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCapTheXe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapTheXe.ForeColor = System.Drawing.Color.White;
            this.btnCapTheXe.Location = new System.Drawing.Point(835, 20);
            this.btnCapTheXe.Name = "btnCapTheXe";
            this.btnCapTheXe.Size = new System.Drawing.Size(140, 30);
            this.btnCapTheXe.TabIndex = 12;
            this.btnCapTheXe.Text = "+ Cấp Thẻ Xe";
            this.btnCapTheXe.UseVisualStyleBackColor = false;
            this.btnCapTheXe.Click += new System.EventHandler(this.btnCapTheXe_Click);
            // 
            // txtMauXe
            // 
            this.txtMauXe.Location = new System.Drawing.Point(740, 24);
            this.txtMauXe.Name = "txtMauXe";
            this.txtMauXe.Size = new System.Drawing.Size(80, 23);
            this.txtMauXe.TabIndex = 11;
            // 
            // lblMauXe
            // 
            this.lblMauXe.AutoSize = true;
            this.lblMauXe.Location = new System.Drawing.Point(705, 27);
            this.lblMauXe.Name = "lblMauXe";
            this.lblMauXe.Size = new System.Drawing.Size(34, 15);
            this.lblMauXe.TabIndex = 10;
            this.lblMauXe.Text = "Màu:";
            // 
            // txtNhanHieu
            // 
            this.txtNhanHieu.Location = new System.Drawing.Point(615, 24);
            this.txtNhanHieu.Name = "txtNhanHieu";
            this.txtNhanHieu.Size = new System.Drawing.Size(80, 23);
            this.txtNhanHieu.TabIndex = 9;
            // 
            // lblNhanHieu
            // 
            this.lblNhanHieu.AutoSize = true;
            this.lblNhanHieu.Location = new System.Drawing.Point(550, 27);
            this.lblNhanHieu.Name = "lblNhanHieu";
            this.lblNhanHieu.Size = new System.Drawing.Size(65, 15);
            this.lblNhanHieu.TabIndex = 8;
            this.lblNhanHieu.Text = "Nhãn hiệu:";
            // 
            // cboLoaiXe
            // 
            this.cboLoaiXe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiXe.FormattingEnabled = true;
            this.cboLoaiXe.Items.AddRange(new object[] {
            "Xe máy",
            "Ô tô",
            "Xe đạp điện"});
            this.cboLoaiXe.Location = new System.Drawing.Point(445, 24);
            this.cboLoaiXe.Name = "cboLoaiXe";
            this.cboLoaiXe.Size = new System.Drawing.Size(95, 23);
            this.cboLoaiXe.TabIndex = 7;
            // 
            // lblLoaiXe
            // 
            this.lblLoaiXe.AutoSize = true;
            this.lblLoaiXe.Location = new System.Drawing.Point(395, 27);
            this.lblLoaiXe.Name = "lblLoaiXe";
            this.lblLoaiXe.Size = new System.Drawing.Size(47, 15);
            this.lblLoaiXe.TabIndex = 6;
            this.lblLoaiXe.Text = "Loại xe:";
            // 
            // txtBienSo
            // 
            this.txtBienSo.Location = new System.Drawing.Point(300, 24);
            this.txtBienSo.Name = "txtBienSo";
            this.txtBienSo.Size = new System.Drawing.Size(85, 23);
            this.txtBienSo.TabIndex = 5;
            // 
            // lblBienSo
            // 
            this.lblBienSo.AutoSize = true;
            this.lblBienSo.Location = new System.Drawing.Point(250, 27);
            this.lblBienSo.Name = "lblBienSo";
            this.lblBienSo.Size = new System.Drawing.Size(48, 15);
            this.lblBienSo.TabIndex = 4;
            this.lblBienSo.Text = "Biển số:";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(125, 24);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(115, 23);
            this.cboNhanVien.TabIndex = 3;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Location = new System.Drawing.Point(95, 27);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(26, 15);
            this.lblNhanVien.TabIndex = 2;
            this.lblNhanVien.Text = "NV:";
            // 
            // txtMaThe
            // 
            this.txtMaThe.Location = new System.Drawing.Point(50, 24);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(40, 23);
            this.txtMaThe.TabIndex = 1;
            // 
            // lblMaThe
            // 
            this.lblMaThe.AutoSize = true;
            this.lblMaThe.Location = new System.Drawing.Point(15, 27);
            this.lblMaThe.Name = "lblMaThe";
            this.lblMaThe.Size = new System.Drawing.Size(30, 15);
            this.lblMaThe.TabIndex = 0;
            this.lblMaThe.Text = "Thẻ:";
            // 
            // FrmNhanVienTheXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 610);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1020, 630);
            this.Name = "FrmNhanVienTheXe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Nhân Viên Văn Phòng & Thẻ Giữ Xe";
            this.tabMain.ResumeLayout(false);
            this.tabNV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.pnlTopNV.ResumeLayout(false);
            this.pnlTopNV.PerformLayout();
            this.tabTheXe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheXe)).EndInit();
            this.pnlTopTheXe.ResumeLayout(false);
            this.pnlTopTheXe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabNV;
        private System.Windows.Forms.Panel pnlTopNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label lblChucVu;
        private System.Windows.Forms.Button btnKhaiBaoNV;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.TabPage tabTheXe;
        private System.Windows.Forms.Panel pnlTopTheXe;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.Label lblMaThe;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.TextBox txtBienSo;
        private System.Windows.Forms.Label lblBienSo;
        private System.Windows.Forms.ComboBox cboLoaiXe;
        private System.Windows.Forms.Label lblLoaiXe;
        private System.Windows.Forms.TextBox txtNhanHieu;
        private System.Windows.Forms.Label lblNhanHieu;
        private System.Windows.Forms.TextBox txtMauXe;
        private System.Windows.Forms.Label lblMauXe;
        private System.Windows.Forms.Button btnCapTheXe;
        private System.Windows.Forms.DataGridView dgvTheXe;
    }
}
