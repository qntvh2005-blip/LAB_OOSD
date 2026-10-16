namespace QuanLyBenhAn.Forms
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
            this.tabDanhMuc = new System.Windows.Forms.TabControl();
            this.tabKhoa = new System.Windows.Forms.TabPage();
            this.dgvKhoa = new System.Windows.Forms.DataGridView();
            this.pnlKhoa = new System.Windows.Forms.Panel();
            this.btnThemKhoa = new System.Windows.Forms.Button();
            this.txtSDTKhoa = new System.Windows.Forms.TextBox();
            this.lblSDTKhoa = new System.Windows.Forms.Label();
            this.txtViTri = new System.Windows.Forms.TextBox();
            this.lblViTri = new System.Windows.Forms.Label();
            this.txtTenKhoa = new System.Windows.Forms.TextBox();
            this.lblTenKhoa = new System.Windows.Forms.Label();
            this.txtMaKhoa = new System.Windows.Forms.TextBox();
            this.lblMaKhoa = new System.Windows.Forms.Label();
            this.tabBacSi = new System.Windows.Forms.TabPage();
            this.dgvBacSi = new System.Windows.Forms.DataGridView();
            this.pnlBacSi = new System.Windows.Forms.Panel();
            this.txtHocVi = new System.Windows.Forms.TextBox();
            this.lblHocVi = new System.Windows.Forms.Label();
            this.txtSDTBS = new System.Windows.Forms.TextBox();
            this.lblSDTBS = new System.Windows.Forms.Label();
            this.txtChuyenKhoa = new System.Windows.Forms.TextBox();
            this.lblChuyenKhoa = new System.Windows.Forms.Label();
            this.cboKhoaBS = new System.Windows.Forms.ComboBox();
            this.lblKhoaBS = new System.Windows.Forms.Label();
            this.btnThemBS = new System.Windows.Forms.Button();
            this.txtTenBS = new System.Windows.Forms.TextBox();
            this.lblTenBS = new System.Windows.Forms.Label();
            this.txtMaBS = new System.Windows.Forms.TextBox();
            this.lblMaBS = new System.Windows.Forms.Label();
            this.tabXetNghiem = new System.Windows.Forms.TabPage();
            this.dgvLoaiXN = new System.Windows.Forms.DataGridView();
            this.pnlXetNghiem = new System.Windows.Forms.Panel();
            this.btnThemXN = new System.Windows.Forms.Button();
            this.txtChiSo = new System.Windows.Forms.TextBox();
            this.lblChiSo = new System.Windows.Forms.Label();
            this.numGiaXN = new System.Windows.Forms.NumericUpDown();
            this.lblGiaXN = new System.Windows.Forms.Label();
            this.txtTenXN = new System.Windows.Forms.TextBox();
            this.lblTenXN = new System.Windows.Forms.Label();
            this.txtMaXN = new System.Windows.Forms.TextBox();
            this.lblMaXN = new System.Windows.Forms.Label();
            this.tabThuoc = new System.Windows.Forms.TabPage();
            this.dgvThuoc = new System.Windows.Forms.DataGridView();
            this.pnlThuoc = new System.Windows.Forms.Panel();
            this.txtCanhBao = new System.Windows.Forms.TextBox();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.txtCongDung = new System.Windows.Forms.TextBox();
            this.lblCongDung = new System.Windows.Forms.Label();
            this.btnThemThuoc = new System.Windows.Forms.Button();
            this.numGiaThuoc = new System.Windows.Forms.NumericUpDown();
            this.lblGiaThuoc = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.lblDVT = new System.Windows.Forms.Label();
            this.txtTenThuoc = new System.Windows.Forms.TextBox();
            this.lblTenThuoc = new System.Windows.Forms.Label();
            this.txtMaThuoc = new System.Windows.Forms.TextBox();
            this.lblMaThuoc = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabDanhMuc.SuspendLayout();
            this.tabKhoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).BeginInit();
            this.pnlKhoa.SuspendLayout();
            this.tabBacSi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBacSi)).BeginInit();
            this.pnlBacSi.SuspendLayout();
            this.tabXetNghiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiXN)).BeginInit();
            this.pnlXetNghiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaXN)).BeginInit();
            this.tabThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).BeginInit();
            this.pnlThuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDanhMuc
            // 
            this.tabDanhMuc.Controls.Add(this.tabKhoa);
            this.tabDanhMuc.Controls.Add(this.tabBacSi);
            this.tabDanhMuc.Controls.Add(this.tabXetNghiem);
            this.tabDanhMuc.Controls.Add(this.tabThuoc);
            this.tabDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.tabDanhMuc.Name = "tabDanhMuc";
            this.tabDanhMuc.SelectedIndex = 0;
            this.tabDanhMuc.Size = new System.Drawing.Size(834, 510);
            this.tabDanhMuc.TabIndex = 0;
            // 
            // tabKhoa
            // 
            this.tabKhoa.Controls.Add(this.dgvKhoa);
            this.tabKhoa.Controls.Add(this.pnlKhoa);
            this.tabKhoa.Location = new System.Drawing.Point(4, 25);
            this.tabKhoa.Name = "tabKhoa";
            this.tabKhoa.Padding = new System.Windows.Forms.Padding(3);
            this.tabKhoa.Size = new System.Drawing.Size(826, 481);
            this.tabKhoa.TabIndex = 0;
            this.tabKhoa.Text = "Khoa điều trị";
            this.tabKhoa.UseVisualStyleBackColor = true;
            // 
            // dgvKhoa
            // 
            this.dgvKhoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhoa.Location = new System.Drawing.Point(3, 115);
            this.dgvKhoa.Name = "dgvKhoa";
            this.dgvKhoa.RowHeadersWidth = 51;
            this.dgvKhoa.RowTemplate.Height = 24;
            this.dgvKhoa.Size = new System.Drawing.Size(820, 363);
            this.dgvKhoa.TabIndex = 1;
            // 
            // pnlKhoa
            // 
            this.pnlKhoa.Controls.Add(this.btnThemKhoa);
            this.pnlKhoa.Controls.Add(this.txtSDTKhoa);
            this.pnlKhoa.Controls.Add(this.lblSDTKhoa);
            this.pnlKhoa.Controls.Add(this.txtViTri);
            this.pnlKhoa.Controls.Add(this.lblViTri);
            this.pnlKhoa.Controls.Add(this.txtTenKhoa);
            this.pnlKhoa.Controls.Add(this.lblTenKhoa);
            this.pnlKhoa.Controls.Add(this.txtMaKhoa);
            this.pnlKhoa.Controls.Add(this.lblMaKhoa);
            this.pnlKhoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKhoa.Location = new System.Drawing.Point(3, 3);
            this.pnlKhoa.Name = "pnlKhoa";
            this.pnlKhoa.Size = new System.Drawing.Size(820, 112);
            this.pnlKhoa.TabIndex = 0;
            // 
            // btnThemKhoa
            // 
            this.btnThemKhoa.Location = new System.Drawing.Point(540, 58);
            this.btnThemKhoa.Name = "btnThemKhoa";
            this.btnThemKhoa.Size = new System.Drawing.Size(120, 32);
            this.btnThemKhoa.TabIndex = 8;
            this.btnThemKhoa.Text = "Thêm khoa";
            this.btnThemKhoa.UseVisualStyleBackColor = true;
            this.btnThemKhoa.Click += new System.EventHandler(this.btnThemKhoa_Click);
            // 
            // txtSDTKhoa
            // 
            this.txtSDTKhoa.Location = new System.Drawing.Point(365, 63);
            this.txtSDTKhoa.Name = "txtSDTKhoa";
            this.txtSDTKhoa.Size = new System.Drawing.Size(150, 22);
            this.txtSDTKhoa.TabIndex = 7;
            // 
            // lblSDTKhoa
            // 
            this.lblSDTKhoa.AutoSize = true;
            this.lblSDTKhoa.Location = new System.Drawing.Point(285, 66);
            this.lblSDTKhoa.Name = "lblSDTKhoa";
            this.lblSDTKhoa.Size = new System.Drawing.Size(71, 17);
            this.lblSDTKhoa.TabIndex = 6;
            this.lblSDTKhoa.Text = "Điện thoại:";
            // 
            // txtViTri
            // 
            this.txtViTri.Location = new System.Drawing.Point(95, 63);
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Size = new System.Drawing.Size(160, 22);
            this.txtViTri.TabIndex = 5;
            // 
            // lblViTri
            // 
            this.lblViTri.AutoSize = true;
            this.lblViTri.Location = new System.Drawing.Point(15, 66);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(39, 17);
            this.lblViTri.TabIndex = 4;
            this.lblViTri.Text = "Vị trí:";
            // 
            // txtTenKhoa
            // 
            this.txtTenKhoa.Location = new System.Drawing.Point(365, 20);
            this.txtTenKhoa.Name = "txtTenKhoa";
            this.txtTenKhoa.Size = new System.Drawing.Size(295, 22);
            this.txtTenKhoa.TabIndex = 3;
            // 
            // lblTenKhoa
            // 
            this.lblTenKhoa.AutoSize = true;
            this.lblTenKhoa.Location = new System.Drawing.Point(285, 23);
            this.lblTenKhoa.Name = "lblTenKhoa";
            this.lblTenKhoa.Size = new System.Drawing.Size(72, 17);
            this.lblTenKhoa.TabIndex = 2;
            this.lblTenKhoa.Text = "Tên khoa:";
            // 
            // txtMaKhoa
            // 
            this.txtMaKhoa.Location = new System.Drawing.Point(95, 20);
            this.txtMaKhoa.Name = "txtMaKhoa";
            this.txtMaKhoa.Size = new System.Drawing.Size(160, 22);
            this.txtMaKhoa.TabIndex = 1;
            // 
            // lblMaKhoa
            // 
            this.lblMaKhoa.AutoSize = true;
            this.lblMaKhoa.Location = new System.Drawing.Point(15, 23);
            this.lblMaKhoa.Name = "lblMaKhoa";
            this.lblMaKhoa.Size = new System.Drawing.Size(66, 17);
            this.lblMaKhoa.TabIndex = 0;
            this.lblMaKhoa.Text = "Mã khoa:";
            // 
            // tabBacSi
            // 
            this.tabBacSi.Controls.Add(this.dgvBacSi);
            this.tabBacSi.Controls.Add(this.pnlBacSi);
            this.tabBacSi.Location = new System.Drawing.Point(4, 25);
            this.tabBacSi.Name = "tabBacSi";
            this.tabBacSi.Padding = new System.Windows.Forms.Padding(3);
            this.tabBacSi.Size = new System.Drawing.Size(826, 481);
            this.tabBacSi.TabIndex = 1;
            this.tabBacSi.Text = "Bác sĩ";
            this.tabBacSi.UseVisualStyleBackColor = true;
            // 
            // dgvBacSi
            // 
            this.dgvBacSi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBacSi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBacSi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBacSi.Location = new System.Drawing.Point(3, 135);
            this.dgvBacSi.Name = "dgvBacSi";
            this.dgvBacSi.RowHeadersWidth = 51;
            this.dgvBacSi.RowTemplate.Height = 24;
            this.dgvBacSi.Size = new System.Drawing.Size(820, 343);
            this.dgvBacSi.TabIndex = 1;
            // 
            // pnlBacSi
            // 
            this.pnlBacSi.Controls.Add(this.txtHocVi);
            this.pnlBacSi.Controls.Add(this.lblHocVi);
            this.pnlBacSi.Controls.Add(this.txtSDTBS);
            this.pnlBacSi.Controls.Add(this.lblSDTBS);
            this.pnlBacSi.Controls.Add(this.txtChuyenKhoa);
            this.pnlBacSi.Controls.Add(this.lblChuyenKhoa);
            this.pnlBacSi.Controls.Add(this.cboKhoaBS);
            this.pnlBacSi.Controls.Add(this.lblKhoaBS);
            this.pnlBacSi.Controls.Add(this.btnThemBS);
            this.pnlBacSi.Controls.Add(this.txtTenBS);
            this.pnlBacSi.Controls.Add(this.lblTenBS);
            this.pnlBacSi.Controls.Add(this.txtMaBS);
            this.pnlBacSi.Controls.Add(this.lblMaBS);
            this.pnlBacSi.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBacSi.Location = new System.Drawing.Point(3, 3);
            this.pnlBacSi.Name = "pnlBacSi";
            this.pnlBacSi.Size = new System.Drawing.Size(820, 132);
            this.pnlBacSi.TabIndex = 0;
            // 
            // txtHocVi
            // 
            this.txtHocVi.Location = new System.Drawing.Point(380, 92);
            this.txtHocVi.Name = "txtHocVi";
            this.txtHocVi.Size = new System.Drawing.Size(150, 22);
            this.txtHocVi.TabIndex = 12;
            // 
            // lblHocVi
            // 
            this.lblHocVi.AutoSize = true;
            this.lblHocVi.Location = new System.Drawing.Point(285, 95);
            this.lblHocVi.Name = "lblHocVi";
            this.lblHocVi.Size = new System.Drawing.Size(51, 17);
            this.lblHocVi.TabIndex = 11;
            this.lblHocVi.Text = "Học vị:";
            // 
            // txtSDTBS
            // 
            this.txtSDTBS.Location = new System.Drawing.Point(95, 92);
            this.txtSDTBS.Name = "txtSDTBS";
            this.txtSDTBS.Size = new System.Drawing.Size(160, 22);
            this.txtSDTBS.TabIndex = 10;
            // 
            // lblSDTBS
            // 
            this.lblSDTBS.AutoSize = true;
            this.lblSDTBS.Location = new System.Drawing.Point(15, 95);
            this.lblSDTBS.Name = "lblSDTBS";
            this.lblSDTBS.Size = new System.Drawing.Size(71, 17);
            this.lblSDTBS.TabIndex = 9;
            this.lblSDTBS.Text = "Điện thoại:";
            // 
            // txtChuyenKhoa
            // 
            this.txtChuyenKhoa.Location = new System.Drawing.Point(380, 56);
            this.txtChuyenKhoa.Name = "txtChuyenKhoa";
            this.txtChuyenKhoa.Size = new System.Drawing.Size(200, 22);
            this.txtChuyenKhoa.TabIndex = 8;
            // 
            // lblChuyenKhoa
            // 
            this.lblChuyenKhoa.AutoSize = true;
            this.lblChuyenKhoa.Location = new System.Drawing.Point(285, 59);
            this.lblChuyenKhoa.Name = "lblChuyenKhoa";
            this.lblChuyenKhoa.Size = new System.Drawing.Size(95, 17);
            this.lblChuyenKhoa.TabIndex = 7;
            this.lblChuyenKhoa.Text = "Chuyên khoa:";
            // 
            // cboKhoaBS
            // 
            this.cboKhoaBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaBS.FormattingEnabled = true;
            this.cboKhoaBS.Location = new System.Drawing.Point(95, 56);
            this.cboKhoaBS.Name = "cboKhoaBS";
            this.cboKhoaBS.Size = new System.Drawing.Size(160, 24);
            this.cboKhoaBS.TabIndex = 6;
            // 
            // lblKhoaBS
            // 
            this.lblKhoaBS.AutoSize = true;
            this.lblKhoaBS.Location = new System.Drawing.Point(15, 59);
            this.lblKhoaBS.Name = "lblKhoaBS";
            this.lblKhoaBS.Size = new System.Drawing.Size(45, 17);
            this.lblKhoaBS.TabIndex = 5;
            this.lblKhoaBS.Text = "Khoa:";
            // 
            // btnThemBS
            // 
            this.btnThemBS.Location = new System.Drawing.Point(600, 85);
            this.btnThemBS.Name = "btnThemBS";
            this.btnThemBS.Size = new System.Drawing.Size(120, 32);
            this.btnThemBS.TabIndex = 4;
            this.btnThemBS.Text = "Thêm bác sĩ";
            this.btnThemBS.UseVisualStyleBackColor = true;
            this.btnThemBS.Click += new System.EventHandler(this.btnThemBS_Click);
            // 
            // txtTenBS
            // 
            this.txtTenBS.Location = new System.Drawing.Point(380, 20);
            this.txtTenBS.Name = "txtTenBS";
            this.txtTenBS.Size = new System.Drawing.Size(200, 22);
            this.txtTenBS.TabIndex = 3;
            // 
            // lblTenBS
            // 
            this.lblTenBS.AutoSize = true;
            this.lblTenBS.Location = new System.Drawing.Point(285, 23);
            this.lblTenBS.Name = "lblTenBS";
            this.lblTenBS.Size = new System.Drawing.Size(54, 17);
            this.lblTenBS.TabIndex = 2;
            this.lblTenBS.Text = "Họ tên:";
            // 
            // txtMaBS
            // 
            this.txtMaBS.Location = new System.Drawing.Point(95, 20);
            this.txtMaBS.Name = "txtMaBS";
            this.txtMaBS.Size = new System.Drawing.Size(160, 22);
            this.txtMaBS.TabIndex = 1;
            // 
            // lblMaBS
            // 
            this.lblMaBS.AutoSize = true;
            this.lblMaBS.Location = new System.Drawing.Point(15, 23);
            this.lblMaBS.Name = "lblMaBS";
            this.lblMaBS.Size = new System.Drawing.Size(52, 17);
            this.lblMaBS.TabIndex = 0;
            this.lblMaBS.Text = "Mã BS:";
            // 
            // tabXetNghiem
            // 
            this.tabXetNghiem.Controls.Add(this.dgvLoaiXN);
            this.tabXetNghiem.Controls.Add(this.pnlXetNghiem);
            this.tabXetNghiem.Location = new System.Drawing.Point(4, 25);
            this.tabXetNghiem.Name = "tabXetNghiem";
            this.tabXetNghiem.Padding = new System.Windows.Forms.Padding(3);
            this.tabXetNghiem.Size = new System.Drawing.Size(826, 481);
            this.tabXetNghiem.TabIndex = 2;
            this.tabXetNghiem.Text = "Loại xét nghiệm";
            this.tabXetNghiem.UseVisualStyleBackColor = true;
            // 
            // dgvLoaiXN
            // 
            this.dgvLoaiXN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiXN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiXN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoaiXN.Location = new System.Drawing.Point(3, 115);
            this.dgvLoaiXN.Name = "dgvLoaiXN";
            this.dgvLoaiXN.RowHeadersWidth = 51;
            this.dgvLoaiXN.RowTemplate.Height = 24;
            this.dgvLoaiXN.Size = new System.Drawing.Size(820, 363);
            this.dgvLoaiXN.TabIndex = 1;
            // 
            // pnlXetNghiem
            // 
            this.pnlXetNghiem.Controls.Add(this.btnThemXN);
            this.pnlXetNghiem.Controls.Add(this.txtChiSo);
            this.pnlXetNghiem.Controls.Add(this.lblChiSo);
            this.pnlXetNghiem.Controls.Add(this.numGiaXN);
            this.pnlXetNghiem.Controls.Add(this.lblGiaXN);
            this.pnlXetNghiem.Controls.Add(this.txtTenXN);
            this.pnlXetNghiem.Controls.Add(this.lblTenXN);
            this.pnlXetNghiem.Controls.Add(this.txtMaXN);
            this.pnlXetNghiem.Controls.Add(this.lblMaXN);
            this.pnlXetNghiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlXetNghiem.Location = new System.Drawing.Point(3, 3);
            this.pnlXetNghiem.Name = "pnlXetNghiem";
            this.pnlXetNghiem.Size = new System.Drawing.Size(820, 112);
            this.pnlXetNghiem.TabIndex = 0;
            // 
            // btnThemXN
            // 
            this.btnThemXN.Location = new System.Drawing.Point(620, 58);
            this.btnThemXN.Name = "btnThemXN";
            this.btnThemXN.Size = new System.Drawing.Size(120, 32);
            this.btnThemXN.TabIndex = 8;
            this.btnThemXN.Text = "Thêm loại XN";
            this.btnThemXN.UseVisualStyleBackColor = true;
            this.btnThemXN.Click += new System.EventHandler(this.btnThemXN_Click);
            // 
            // txtChiSo
            // 
            this.txtChiSo.Location = new System.Drawing.Point(120, 63);
            this.txtChiSo.Name = "txtChiSo";
            this.txtChiSo.Size = new System.Drawing.Size(460, 22);
            this.txtChiSo.TabIndex = 7;
            // 
            // lblChiSo
            // 
            this.lblChiSo.AutoSize = true;
            this.lblChiSo.Location = new System.Drawing.Point(15, 66);
            this.lblChiSo.Name = "lblChiSo";
            this.lblChiSo.Size = new System.Drawing.Size(101, 17);
            this.lblChiSo.TabIndex = 6;
            this.lblChiSo.Text = "Chỉ số b.thường:";
            // 
            // numGiaXN
            // 
            this.numGiaXN.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numGiaXN.Location = new System.Drawing.Point(620, 20);
            this.numGiaXN.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGiaXN.Name = "numGiaXN";
            this.numGiaXN.Size = new System.Drawing.Size(120, 22);
            this.numGiaXN.TabIndex = 5;
            // 
            // lblGiaXN
            // 
            this.lblGiaXN.AutoSize = true;
            this.lblGiaXN.Location = new System.Drawing.Point(555, 23);
            this.lblGiaXN.Name = "lblGiaXN";
            this.lblGiaXN.Size = new System.Drawing.Size(61, 17);
            this.lblGiaXN.TabIndex = 4;
            this.lblGiaXN.Text = "Đơn giá:";
            // 
            // txtTenXN
            // 
            this.txtTenXN.Location = new System.Drawing.Point(320, 20);
            this.txtTenXN.Name = "txtTenXN";
            this.txtTenXN.Size = new System.Drawing.Size(220, 22);
            this.txtTenXN.TabIndex = 3;
            // 
            // lblTenXN
            // 
            this.lblTenXN.AutoSize = true;
            this.lblTenXN.Location = new System.Drawing.Point(235, 23);
            this.lblTenXN.Name = "lblTenXN";
            this.lblTenXN.Size = new System.Drawing.Size(84, 17);
            this.lblTenXN.TabIndex = 2;
            this.lblTenXN.Text = "Tên loại XN:";
            // 
            // txtMaXN
            // 
            this.txtMaXN.Location = new System.Drawing.Point(120, 20);
            this.txtMaXN.Name = "txtMaXN";
            this.txtMaXN.Size = new System.Drawing.Size(100, 22);
            this.txtMaXN.TabIndex = 1;
            // 
            // lblMaXN
            // 
            this.lblMaXN.AutoSize = true;
            this.lblMaXN.Location = new System.Drawing.Point(15, 23);
            this.lblMaXN.Name = "lblMaXN";
            this.lblMaXN.Size = new System.Drawing.Size(83, 17);
            this.lblMaXN.TabIndex = 0;
            this.lblMaXN.Text = "Mã loại XN:";
            // 
            // tabThuoc
            // 
            this.tabThuoc.Controls.Add(this.dgvThuoc);
            this.tabThuoc.Controls.Add(this.pnlThuoc);
            this.tabThuoc.Location = new System.Drawing.Point(4, 25);
            this.tabThuoc.Name = "tabThuoc";
            this.tabThuoc.Padding = new System.Windows.Forms.Padding(3);
            this.tabThuoc.Size = new System.Drawing.Size(826, 481);
            this.tabThuoc.TabIndex = 3;
            this.tabThuoc.Text = "Danh mục thuốc";
            this.tabThuoc.UseVisualStyleBackColor = true;
            // 
            // dgvThuoc
            // 
            this.dgvThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThuoc.Location = new System.Drawing.Point(3, 125);
            this.dgvThuoc.Name = "dgvThuoc";
            this.dgvThuoc.RowHeadersWidth = 51;
            this.dgvThuoc.RowTemplate.Height = 24;
            this.dgvThuoc.Size = new System.Drawing.Size(820, 353);
            this.dgvThuoc.TabIndex = 1;
            // 
            // pnlThuoc
            // 
            this.pnlThuoc.Controls.Add(this.txtCanhBao);
            this.pnlThuoc.Controls.Add(this.lblCanhBao);
            this.pnlThuoc.Controls.Add(this.txtCongDung);
            this.pnlThuoc.Controls.Add(this.lblCongDung);
            this.pnlThuoc.Controls.Add(this.btnThemThuoc);
            this.pnlThuoc.Controls.Add(this.numGiaThuoc);
            this.pnlThuoc.Controls.Add(this.lblGiaThuoc);
            this.pnlThuoc.Controls.Add(this.txtDVT);
            this.pnlThuoc.Controls.Add(this.lblDVT);
            this.pnlThuoc.Controls.Add(this.txtTenThuoc);
            this.pnlThuoc.Controls.Add(this.lblTenThuoc);
            this.pnlThuoc.Controls.Add(this.txtMaThuoc);
            this.pnlThuoc.Controls.Add(this.lblMaThuoc);
            this.pnlThuoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThuoc.Location = new System.Drawing.Point(3, 3);
            this.pnlThuoc.Name = "pnlThuoc";
            this.pnlThuoc.Size = new System.Drawing.Size(820, 122);
            this.pnlThuoc.TabIndex = 0;
            // 
            // txtCanhBao
            // 
            this.txtCanhBao.Location = new System.Drawing.Point(410, 85);
            this.txtCanhBao.Name = "txtCanhBao";
            this.txtCanhBao.Size = new System.Drawing.Size(240, 22);
            this.txtCanhBao.TabIndex = 12;
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.AutoSize = true;
            this.lblCanhBao.Location = new System.Drawing.Point(330, 88);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(73, 17);
            this.lblCanhBao.TabIndex = 11;
            this.lblCanhBao.Text = "Cảnh báo:";
            // 
            // txtCongDung
            // 
            this.txtCongDung.Location = new System.Drawing.Point(95, 85);
            this.txtCongDung.Name = "txtCongDung";
            this.txtCongDung.Size = new System.Drawing.Size(220, 22);
            this.txtCongDung.TabIndex = 10;
            // 
            // lblCongDung
            // 
            this.lblCongDung.AutoSize = true;
            this.lblCongDung.Location = new System.Drawing.Point(15, 88);
            this.lblCongDung.Name = "lblCongDung";
            this.lblCongDung.Size = new System.Drawing.Size(81, 17);
            this.lblCongDung.TabIndex = 9;
            this.lblCongDung.Text = "Công dụng:";
            // 
            // btnThemThuoc
            // 
            this.btnThemThuoc.Location = new System.Drawing.Point(670, 78);
            this.btnThemThuoc.Name = "btnThemThuoc";
            this.btnThemThuoc.Size = new System.Drawing.Size(120, 32);
            this.btnThemThuoc.TabIndex = 8;
            this.btnThemThuoc.Text = "Thêm thuốc";
            this.btnThemThuoc.UseVisualStyleBackColor = true;
            this.btnThemThuoc.Click += new System.EventHandler(this.btnThemThuoc_Click);
            // 
            // numGiaThuoc
            // 
            this.numGiaThuoc.Increment = new decimal(new int[] { 500, 0, 0, 0 });
            this.numGiaThuoc.Location = new System.Drawing.Point(670, 20);
            this.numGiaThuoc.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGiaThuoc.Name = "numGiaThuoc";
            this.numGiaThuoc.Size = new System.Drawing.Size(120, 22);
            this.numGiaThuoc.TabIndex = 7;
            // 
            // lblGiaThuoc
            // 
            this.lblGiaThuoc.AutoSize = true;
            this.lblGiaThuoc.Location = new System.Drawing.Point(605, 23);
            this.lblGiaThuoc.Name = "lblGiaThuoc";
            this.lblGiaThuoc.Size = new System.Drawing.Size(61, 17);
            this.lblGiaThuoc.TabIndex = 6;
            this.lblGiaThuoc.Text = "Đơn giá:";
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(505, 20);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(80, 22);
            this.txtDVT.TabIndex = 5;
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Location = new System.Drawing.Point(460, 23);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(40, 17);
            this.lblDVT.TabIndex = 4;
            this.lblDVT.Text = "ĐVT:";
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.Location = new System.Drawing.Point(260, 20);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.Size = new System.Drawing.Size(185, 22);
            this.txtTenThuoc.TabIndex = 3;
            // 
            // lblTenThuoc
            // 
            this.lblTenThuoc.AutoSize = true;
            this.lblTenThuoc.Location = new System.Drawing.Point(180, 23);
            this.lblTenThuoc.Name = "lblTenThuoc";
            this.lblTenThuoc.Size = new System.Drawing.Size(76, 17);
            this.lblTenThuoc.TabIndex = 2;
            this.lblTenThuoc.Text = "Tên thuốc:";
            // 
            // txtMaThuoc
            // 
            this.txtMaThuoc.Location = new System.Drawing.Point(95, 20);
            this.txtMaThuoc.Name = "txtMaThuoc";
            this.txtMaThuoc.Size = new System.Drawing.Size(75, 22);
            this.txtMaThuoc.TabIndex = 1;
            // 
            // lblMaThuoc
            // 
            this.lblMaThuoc.AutoSize = true;
            this.lblMaThuoc.Location = new System.Drawing.Point(15, 23);
            this.lblMaThuoc.Name = "lblMaThuoc";
            this.lblMaThuoc.Size = new System.Drawing.Size(70, 17);
            this.lblMaThuoc.TabIndex = 0;
            this.lblMaThuoc.Text = "Mã thuốc:";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(710, 520);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 562);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabDanhMuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý Danh mục Cơ bản";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabDanhMuc.ResumeLayout(false);
            this.tabKhoa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoa)).EndInit();
            this.pnlKhoa.ResumeLayout(false);
            this.pnlKhoa.PerformLayout();
            this.tabBacSi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBacSi)).EndInit();
            this.pnlBacSi.ResumeLayout(false);
            this.pnlBacSi.PerformLayout();
            this.tabXetNghiem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiXN)).EndInit();
            this.pnlXetNghiem.ResumeLayout(false);
            this.pnlXetNghiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaXN)).EndInit();
            this.tabThuoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuoc)).EndInit();
            this.pnlThuoc.ResumeLayout(false);
            this.pnlThuoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiaThuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDanhMuc;
        private System.Windows.Forms.TabPage tabKhoa;
        private System.Windows.Forms.TabPage tabBacSi;
        private System.Windows.Forms.TabPage tabXetNghiem;
        private System.Windows.Forms.TabPage tabThuoc;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel pnlKhoa;
        private System.Windows.Forms.Button btnThemKhoa;
        private System.Windows.Forms.TextBox txtSDTKhoa;
        private System.Windows.Forms.Label lblSDTKhoa;
        private System.Windows.Forms.TextBox txtViTri;
        private System.Windows.Forms.Label lblViTri;
        private System.Windows.Forms.TextBox txtTenKhoa;
        private System.Windows.Forms.Label lblTenKhoa;
        private System.Windows.Forms.TextBox txtMaKhoa;
        private System.Windows.Forms.Label lblMaKhoa;
        private System.Windows.Forms.DataGridView dgvKhoa;
        private System.Windows.Forms.DataGridView dgvBacSi;
        private System.Windows.Forms.Panel pnlBacSi;
        private System.Windows.Forms.TextBox txtHocVi;
        private System.Windows.Forms.Label lblHocVi;
        private System.Windows.Forms.TextBox txtSDTBS;
        private System.Windows.Forms.Label lblSDTBS;
        private System.Windows.Forms.TextBox txtChuyenKhoa;
        private System.Windows.Forms.Label lblChuyenKhoa;
        private System.Windows.Forms.ComboBox cboKhoaBS;
        private System.Windows.Forms.Label lblKhoaBS;
        private System.Windows.Forms.Button btnThemBS;
        private System.Windows.Forms.TextBox txtTenBS;
        private System.Windows.Forms.Label lblTenBS;
        private System.Windows.Forms.TextBox txtMaBS;
        private System.Windows.Forms.Label lblMaBS;
        private System.Windows.Forms.DataGridView dgvLoaiXN;
        private System.Windows.Forms.Panel pnlXetNghiem;
        private System.Windows.Forms.Button btnThemXN;
        private System.Windows.Forms.TextBox txtChiSo;
        private System.Windows.Forms.Label lblChiSo;
        private System.Windows.Forms.NumericUpDown numGiaXN;
        private System.Windows.Forms.Label lblGiaXN;
        private System.Windows.Forms.TextBox txtTenXN;
        private System.Windows.Forms.Label lblTenXN;
        private System.Windows.Forms.TextBox txtMaXN;
        private System.Windows.Forms.Label lblMaXN;
        private System.Windows.Forms.DataGridView dgvThuoc;
        private System.Windows.Forms.Panel pnlThuoc;
        private System.Windows.Forms.TextBox txtCanhBao;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.TextBox txtCongDung;
        private System.Windows.Forms.Label lblCongDung;
        private System.Windows.Forms.Button btnThemThuoc;
        private System.Windows.Forms.NumericUpDown numGiaThuoc;
        private System.Windows.Forms.Label lblGiaThuoc;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.TextBox txtTenThuoc;
        private System.Windows.Forms.Label lblTenThuoc;
        private System.Windows.Forms.TextBox txtMaThuoc;
        private System.Windows.Forms.Label lblMaThuoc;
    }
}
