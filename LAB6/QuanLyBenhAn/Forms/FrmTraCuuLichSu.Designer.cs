namespace QuanLyBenhAn.Forms
{
    partial class FrmTraCuuLichSu
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.dgvHoSo = new System.Windows.Forms.DataGridView();
            this.lblThongTinBN = new System.Windows.Forms.Label();
            this.splitLichSu = new System.Windows.Forms.SplitContainer();
            this.dgvLichSuKham = new System.Windows.Forms.DataGridView();
            this.lblKhamTitle = new System.Windows.Forms.Label();
            this.splitChiTiet = new System.Windows.Forms.SplitContainer();
            this.dgvXN = new System.Windows.Forms.DataGridView();
            this.lblXNTitle = new System.Windows.Forms.Label();
            this.dgvToa = new System.Windows.Forms.DataGridView();
            this.lblToaTitle = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitLichSu)).BeginInit();
            this.splitLichSu.Panel1.SuspendLayout();
            this.splitLichSu.Panel2.SuspendLayout();
            this.splitLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuKham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitChiTiet)).BeginInit();
            this.splitChiTiet.Panel1.SuspendLayout();
            this.splitChiTiet.Panel2.SuspendLayout();
            this.splitChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToa)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnTim);
            this.pnlSearch.Controls.Add(this.txtTuKhoa);
            this.pnlSearch.Controls.Add(this.lblTuKhoa);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1004, 55);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(540, 14);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 28);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(180, 17);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(340, 22);
            this.txtTuKhoa.TabIndex = 1;
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(15, 20);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(155, 17);
            this.lblTuKhoa.TabIndex = 0;
            this.lblTuKhoa.Text = "Mã hồ sơ / Tên BN / SĐT:";
            // 
            // dgvHoSo
            // 
            this.dgvHoSo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoSo.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHoSo.Location = new System.Drawing.Point(0, 55);
            this.dgvHoSo.Name = "dgvHoSo";
            this.dgvHoSo.RowHeadersWidth = 51;
            this.dgvHoSo.RowTemplate.Height = 24;
            this.dgvHoSo.Size = new System.Drawing.Size(1004, 150);
            this.dgvHoSo.TabIndex = 1;
            this.dgvHoSo.SelectionChanged += new System.EventHandler(this.dgvHoSo_SelectionChanged);
            // 
            // lblThongTinBN
            // 
            this.lblThongTinBN.BackColor = System.Drawing.Color.AliceBlue;
            this.lblThongTinBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThongTinBN.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblThongTinBN.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinBN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblThongTinBN.Location = new System.Drawing.Point(0, 205);
            this.lblThongTinBN.Name = "lblThongTinBN";
            this.lblThongTinBN.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblThongTinBN.Size = new System.Drawing.Size(1004, 30);
            this.lblThongTinBN.TabIndex = 2;
            this.lblThongTinBN.Text = "Hồ sơ: - | Bệnh nhân: - | Tiền sử dị ứng: -";
            this.lblThongTinBN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitLichSu
            // 
            this.splitLichSu.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitLichSu.Location = new System.Drawing.Point(0, 235);
            this.splitLichSu.Name = "splitLichSu";
            this.splitLichSu.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLichSu.Panel1
            // 
            this.splitLichSu.Panel1.Controls.Add(this.dgvLichSuKham);
            this.splitLichSu.Panel1.Controls.Add(this.lblKhamTitle);
            // 
            // splitLichSu.Panel2
            // 
            this.splitLichSu.Panel2.Controls.Add(this.splitChiTiet);
            this.splitLichSu.Size = new System.Drawing.Size(1004, 370);
            this.splitLichSu.SplitterDistance = 180;
            this.splitLichSu.TabIndex = 3;
            // 
            // dgvLichSuKham
            // 
            this.dgvLichSuKham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuKham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuKham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuKham.Location = new System.Drawing.Point(0, 25);
            this.dgvLichSuKham.Name = "dgvLichSuKham";
            this.dgvLichSuKham.RowHeadersWidth = 51;
            this.dgvLichSuKham.RowTemplate.Height = 24;
            this.dgvLichSuKham.Size = new System.Drawing.Size(1004, 155);
            this.dgvLichSuKham.TabIndex = 1;
            this.dgvLichSuKham.SelectionChanged += new System.EventHandler(this.dgvLichSuKham_SelectionChanged);
            // 
            // lblKhamTitle
            // 
            this.lblKhamTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKhamTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhamTitle.Location = new System.Drawing.Point(0, 0);
            this.lblKhamTitle.Name = "lblKhamTitle";
            this.lblKhamTitle.Size = new System.Drawing.Size(1004, 25);
            this.lblKhamTitle.TabIndex = 0;
            this.lblKhamTitle.Text = "Lịch sử các đợt khám (triệu chứng, chẩn đoán, phản ứng phụ của thuốc, hiệu quả đi" +
    "ều trị):";
            this.lblKhamTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitChiTiet
            // 
            this.splitChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitChiTiet.Location = new System.Drawing.Point(0, 0);
            this.splitChiTiet.Name = "splitChiTiet";
            // 
            // splitChiTiet.Panel1
            // 
            this.splitChiTiet.Panel1.Controls.Add(this.dgvXN);
            this.splitChiTiet.Panel1.Controls.Add(this.lblXNTitle);
            // 
            // splitChiTiet.Panel2
            // 
            this.splitChiTiet.Panel2.Controls.Add(this.dgvToa);
            this.splitChiTiet.Panel2.Controls.Add(this.lblToaTitle);
            this.splitChiTiet.Size = new System.Drawing.Size(1004, 186);
            this.splitChiTiet.SplitterDistance = 490;
            this.splitChiTiet.TabIndex = 0;
            // 
            // dgvXN
            // 
            this.dgvXN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvXN.Location = new System.Drawing.Point(0, 25);
            this.dgvXN.Name = "dgvXN";
            this.dgvXN.RowHeadersWidth = 51;
            this.dgvXN.RowTemplate.Height = 24;
            this.dgvXN.Size = new System.Drawing.Size(490, 161);
            this.dgvXN.TabIndex = 1;
            // 
            // lblXNTitle
            // 
            this.lblXNTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblXNTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXNTitle.Location = new System.Drawing.Point(0, 0);
            this.lblXNTitle.Name = "lblXNTitle";
            this.lblXNTitle.Size = new System.Drawing.Size(490, 25);
            this.lblXNTitle.TabIndex = 0;
            this.lblXNTitle.Text = "Kết quả xét nghiệm đợt khám này:";
            this.lblXNTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvToa
            // 
            this.dgvToa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvToa.Location = new System.Drawing.Point(0, 25);
            this.dgvToa.Name = "dgvToa";
            this.dgvToa.RowHeadersWidth = 51;
            this.dgvToa.RowTemplate.Height = 24;
            this.dgvToa.Size = new System.Drawing.Size(510, 161);
            this.dgvToa.TabIndex = 1;
            // 
            // lblToaTitle
            // 
            this.lblToaTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblToaTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToaTitle.Location = new System.Drawing.Point(0, 0);
            this.lblToaTitle.Name = "lblToaTitle";
            this.lblToaTitle.Size = new System.Drawing.Size(510, 25);
            this.lblToaTitle.TabIndex = 0;
            this.lblToaTitle.Text = "Toa thuốc đã điều trị đợt khám này:";
            this.lblToaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(880, 615);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 32);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmTraCuuLichSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 658);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.splitLichSu);
            this.Controls.Add(this.lblThongTinBN);
            this.Controls.Add(this.dgvHoSo);
            this.Controls.Add(this.pnlSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmTraCuuLichSu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tra Cứu Lý Lịch Bệnh Án & Lịch Sử Điều Trị & Phản Ứng Phụ Thuốc";
            this.Load += new System.EventHandler(this.FrmTraCuuLichSu_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoSo)).EndInit();
            this.splitLichSu.Panel1.ResumeLayout(false);
            this.splitLichSu.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLichSu)).EndInit();
            this.splitLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuKham)).EndInit();
            this.splitChiTiet.Panel1.ResumeLayout(false);
            this.splitChiTiet.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitChiTiet)).EndInit();
            this.splitChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvXN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvHoSo;
        private System.Windows.Forms.Label lblThongTinBN;
        private System.Windows.Forms.SplitContainer splitLichSu;
        private System.Windows.Forms.DataGridView dgvLichSuKham;
        private System.Windows.Forms.Label lblKhamTitle;
        private System.Windows.Forms.SplitContainer splitChiTiet;
        private System.Windows.Forms.DataGridView dgvXN;
        private System.Windows.Forms.Label lblXNTitle;
        private System.Windows.Forms.DataGridView dgvToa;
        private System.Windows.Forms.Label lblToaTitle;
        private System.Windows.Forms.Button btnDong;
    }
}
