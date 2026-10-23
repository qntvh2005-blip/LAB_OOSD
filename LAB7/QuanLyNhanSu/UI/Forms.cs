using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.UI
{
    public class FrmMain : Form
    {
        public FrmMain()
        {
            Text = "Quản lý nhân sự công ty sơn Đông Á";
            ClientSize = new Size(800, 560);
            MinimumSize = new Size(760, 540);
            Font = new Font("Segoe UI", 10);
            BackColor = Color.FromArgb(240, 240, 240);
            StartPosition = FormStartPosition.CenterScreen;

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(50, 14, 50, 26),
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 64));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 94));
            Controls.Add(layout);

            var title = new Label
            {
                Text = "CÔNG TY SƠN ĐÔNG Á",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.FromArgb(0, 65, 120),
                Font = new Font("Segoe UI", 17, FontStyle.Bold),
            };
            layout.Controls.Add(title, 0, 0);

            var menu = new TableLayoutPanel
            {
                Name = "menuChucNang",
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 4,
            };
            menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            menu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            for (int row = 0; row < 4; row++)
            {
                menu.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            }

            Add(menu, "btnDanhMuc", "Danh mục", 0, 0, () => new FrmDanhMuc());
            Add(menu, "btnTuyenDung", "Tuyển dụng - thử việc", 1, 0, () => new FrmTuyenDung());
            Add(menu, "btnHopDong", "Hợp đồng - bảo hiểm", 0, 1, () => new FrmHopDongBaoHiem());
            Add(menu, "btnQuyetDinh", "Quyết định lương - chức vụ", 1, 1, () => new FrmQuyetDinh());
            Add(menu, "btnKeHoach", "Kế hoạch làm việc tuần", 0, 2, () => new FrmKeHoachTuan());
            Add(menu, "btnChamCong", "Chấm công - phụ trội", 1, 2, () => new FrmChamCongPhuTroi());
            Add(menu, "btnThuongPhat", "Khen thưởng - kỷ luật", 0, 3, () => new FrmThuongPhat());
            Add(menu, "btnBangLuong", "Bảng lương tháng", 1, 3, () => new FrmBangLuong());
            layout.Controls.Add(menu, 0, 1);

            var exitArea = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Padding = new Padding(0, 18, 0, 12),
            };
            exitArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            exitArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            exitArea.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));

            var exit = CreateMenuButton("btnThoat", "Thoát");
            exit.Click += (sender, args) => Close();
            exitArea.Controls.Add(exit, 1, 0);
            layout.Controls.Add(exitArea, 0, 2);
        }

        private Button CreateMenuButton(string name, string text)
        {
            return new Button
            {
                Name = name,
                Text = text,
                Dock = DockStyle.Fill,
                Margin = new Padding(8),
                BackColor = Color.FromArgb(225, 225, 225),
                UseVisualStyleBackColor = false,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderColor = Color.FromArgb(205, 205, 205) },
                Cursor = Cursors.Hand,
            };
        }

        private void Add(
            TableLayoutPanel menu,
            string name,
            string text,
            int column,
            int row,
            Func<Form> createForm
        )
        {
            var button = CreateMenuButton(name, text);
            button.Click += (sender, args) =>
            {
                using (var form = createForm())
                {
                    form.ShowDialog(this);
                }
            };
            menu.Controls.Add(button, column, row);
        }
    }

    public class FrmDanhMuc : ModuleForm
    {
        public FrmDanhMuc()
            : base("Danh mục")
        {
            var s = new DanhMucService();
            Op(
                "Phòng ban",
                "PhongBan",
                new[] { F("ma", "Mã phòng ban"), F("ten", "Tên phòng ban") },
                v => s.Phong(v.S("ma"), v.S("ten"))
            );
            Op(
                "Chức vụ",
                "ChucVu",
                new[] { F("ma", "Mã chức vụ"), F("ten", "Tên chức vụ") },
                v => s.ChucVu(v.S("ma"), v.S("ten"))
            );
            Op(
                "Ca làm",
                "CaLam",
                new[]
                {
                    F("ma", "Mã ca"),
                    F("ten", "Tên ca"),
                    F("gio", "Giờ chuẩn / ca", "T", "", "8"),
                },
                v => s.Ca(v.S("ma"), v.S("ten"), v.N("gio"))
            );
        }
    }

    public class FrmTuyenDung : ModuleForm
    {
        public FrmTuyenDung()
            : base("Tuyển dụng — Thử việc")
        {
            var s = new TuyenDungService();
            Op(
                "Tiếp nhận thử việc",
                "QuyetDinhTuyenDung",
                new[]
                {
                    F("nv", "Mã nhân viên"),
                    F("ten", "Họ tên"),
                    F("sinh", "Ngày sinh", "D"),
                    F("dt", "Điện thoại"),
                    F("dc", "Địa chỉ"),
                    F("pb", "Phòng ban", "C", "PhongBan.MaPB"),
                    F("qd", "Số QĐ tuyển dụng"),
                    F("ngay", "Ngày quyết định", "D"),
                    F("tu", "Bắt đầu thử việc", "D"),
                    F("den", "Kết thúc thử việc", "D"),
                    F("luong", "Lương thử việc"),
                    F("dk", "Điều khoản hai bên"),
                    F("ky", "Người ký quyết định"),
                },
                v =>
                    s.TuyenDung(
                        v.S("nv"),
                        v.S("ten"),
                        v.D("sinh"),
                        v.S("dt"),
                        v.S("dc"),
                        v.S("pb"),
                        v.S("qd"),
                        v.D("ngay"),
                        v.D("tu"),
                        v.D("den"),
                        v.N("luong"),
                        v.S("dk"),
                        v.S("ky")
                    )
            );
            Op(
                "Đánh giá kết thúc",
                "NhanVien",
                new[]
                {
                    F("nv", "Nhân viên", "C", "NhanVien.MaNV"),
                    F("kq", "Kết quả", "C", "Dat|KhongDat"),
                },
                v => s.DanhGia(v.S("nv"), v.S("kq") == "Dat")
            );
        }
    }

    public class FrmHopDongBaoHiem : ModuleForm
    {
        public FrmHopDongBaoHiem()
            : base("Ký hợp đồng — Bảo hiểm — Quyết định ban đầu")
        {
            Op(
                "Ký và lưu đồng thời",
                "HopDong",
                new[]
                {
                    F("hd", "Số hợp đồng"),
                    F("nv", "Nhân viên", "C", "NhanVien.MaNV"),
                    F("loai", "Loại hợp đồng", "C", "DaiHan|NganHan"),
                    F("ngay", "Ngày ký", "D"),
                    F("tu", "Ngày hiệu lực", "D"),
                    F("den", "Hết hạn (ngắn hạn)", "ND"),
                    F("dk", "Điều khoản"),
                    F("ky", "Người ký"),
                    F("ql", "Số QĐ lương"),
                    F("l", "Lương cơ bản"),
                    F("pc", "Phụ cấp lương", "T", "", "0"),
                    F("dh", "Phụ cấp độc hại", "T", "", "0"),
                    F("qc", "Số QĐ chức vụ"),
                    F("cv", "Chức vụ", "C", "ChucVu.MaCV"),
                    F("pccv", "Phụ cấp chức vụ", "T", "", "0"),
                    F("xh", "Mã BHXH"),
                    F("yt", "Mã BHYT"),
                    F("rx", "Tỷ lệ BHXH (0–1)", "T", "", "0"),
                    F("ry", "Tỷ lệ BHYT (0–1)", "T", "", "0"),
                },
                v =>
                    new HopDongService().KyHopDong(
                        v.S("hd"),
                        v.S("nv"),
                        v.S("loai"),
                        v.D("ngay"),
                        v.D("tu"),
                        v.OptionalDate("den"),
                        v.S("dk"),
                        v.S("ky"),
                        v.S("ql"),
                        v.N("l"),
                        v.N("pc"),
                        v.N("dh"),
                        v.S("qc"),
                        v.S("cv"),
                        v.N("pccv"),
                        v.S("xh"),
                        v.S("yt"),
                        v.N("rx"),
                        v.N("ry")
                    )
            );
        }
    }

    public class FrmQuyetDinh : ModuleForm
    {
        public FrmQuyetDinh()
            : base("Quyết định lương — Chức vụ")
        {
            var s = new QuyetDinhService();
            Op(
                "Quyết định lương",
                "QuyetDinhLuong",
                new[]
                {
                    F("qd", "Số quyết định"),
                    F("nv", "Nhân viên", "C", "NhanVien.MaNV"),
                    F("d", "Ngày hiệu lực", "D"),
                    F("l", "Lương cơ bản"),
                    F("pc", "Phụ cấp lương", "T", "", "0"),
                    F("dh", "Phụ cấp độc hại", "T", "", "0"),
                    F("ky", "Người ký"),
                },
                v =>
                    s.DoiLuong(
                        v.S("qd"),
                        v.S("nv"),
                        v.D("d"),
                        v.N("l"),
                        v.N("pc"),
                        v.N("dh"),
                        v.S("ky")
                    )
            );
            Op(
                "Quyết định chức vụ",
                "QuyetDinhChucVu",
                new[]
                {
                    F("qd", "Số quyết định"),
                    F("nv", "Nhân viên", "C", "NhanVien.MaNV"),
                    F("cv", "Chức vụ", "C", "ChucVu.MaCV"),
                    F("d", "Ngày hiệu lực", "D"),
                    F("pc", "Phụ cấp chức vụ", "T", "", "0"),
                    F("ky", "Người ký"),
                },
                v => s.BoNhiem(v.S("qd"), v.S("nv"), v.S("cv"), v.D("d"), v.N("pc"), v.S("ky"))
            );
        }
    }

    public class FrmKeHoachTuan : ModuleForm
    {
        public FrmKeHoachTuan()
            : base("Kế hoạch tuần")
        {
            Op(
                "Lập kế hoạch",
                "PhanCongCa",
                new[]
                {
                    F("ma", "Mã kế hoạch"),
                    F("pb", "Phòng ban", "C", "PhongBan.MaPB"),
                    F("d", "Thứ Hai đầu tuần", "D"),
                    F("lap", "Trưởng phòng lập"),
                    F("ds", "Mỗi dòng: NV|yyyy-MM-dd|Ca|Giờ PT|TangCa/NgayLe/NgayNghi", "L"),
                },
                v =>
                    new KeHoachService().Lap(
                        v.S("ma"),
                        v.S("pb"),
                        v.D("d"),
                        v.S("lap"),
                        v.Plans("ds")
                    )
            );
        }
    }

    public class FrmChamCongPhuTroi : ModuleForm
    {
        public FrmChamCongPhuTroi()
            : base("Chấm công — Phụ trội")
        {
            var s = new ChamCongService();
            Op(
                "Chấm công",
                "ChamCong",
                new[]
                {
                    F("nv", "Nhân viên", "C", "NhanVien.MaNV"),
                    F("d", "Ngày chấm công", "D"),
                    F("g", "Giờ thực tế", "T", "", "8"),
                    F("lap", "Người chấm"),
                },
                v => s.Ghi(v.S("nv"), v.D("d"), v.N("g"), v.S("lap"))
            );
            Op(
                "Phiếu phụ trội",
                "ChiTietPhuTroi",
                new[]
                {
                    F("p", "Số phiếu"),
                    F("d", "Ngày phụ trội", "D"),
                    F("h", "Hình thức", "C", "TangCa|NgayLe|NgayNghi"),
                    F("g", "Số giờ tối đa / người"),
                    F("lap", "Người lập"),
                    F("ds", "Mỗi dòng: MaNV|Số giờ thực tế", "L"),
                },
                v => s.PhuTroi(v.S("p"), v.D("d"), v.S("h"), v.N("g"), v.S("lap"), v.Lines("ds"))
            );
        }
    }

    public class FrmThuongPhat : ModuleForm
    {
        public FrmThuongPhat()
            : base("Khen thưởng — Kỷ luật — Thu chi")
        {
            var s = new ThuongPhatService();
            Op(
                "Lập quyết định",
                "QuyetDinhThuongPhat",
                new[]
                {
                    F("q", "Số quyết định"),
                    F("lo", "Loại", "C", "Thuong|Phat"),
                    F("nv", "Mã NV (cá nhân)"),
                    F("pb", "Mã PB (tập thể)"),
                    F("d", "Ngày quyết định", "D"),
                    F("ky", "Tháng hưởng (chọn ngày)", "D"),
                    F("nd", "Nội dung"),
                    F("tien", "Tổng tiền quyết định"),
                    F("ht", "Thanh toán", "C", "QuaLuong|TrucTiep"),
                    F("gdoc", "Giám đốc ký"),
                    F("ds", "Mỗi dòng: MaNV|Số tiền phân bổ", "L"),
                },
                v =>
                    s.Lap(
                        v.S("q"),
                        v.S("lo"),
                        v.S("nv"),
                        v.S("pb"),
                        v.D("d"),
                        v.D("ky"),
                        v.S("nd"),
                        v.N("tien"),
                        v.S("ht"),
                        v.S("gdoc"),
                        v.Lines("ds")
                    )
            );
            Op(
                "Phiếu thu / chi trực tiếp",
                "PhieuThuChi",
                new[]
                {
                    F("p", "Số phiếu"),
                    F("q", "Quyết định", "C", "QuyetDinhThuongPhat.SoQD"),
                    F("d", "Ngày thu/chi", "D"),
                },
                v => s.ThuChi(v.S("p"), v.S("q"), v.D("d"))
            );
        }
    }

    public class FrmBangLuong : ModuleForm
    {
        public FrmBangLuong()
            : base("Bảng lương tháng — chốt một lần")
        {
            Op(
                "Tính và chốt lương",
                "LuongTongHop",
                new[]
                {
                    F("ma", "Mã bảng lương"),
                    F("m", "Tháng", "T", "", DateTime.Today.Month.ToString()),
                    F("y", "Năm", "T", "", DateTime.Today.Year.ToString()),
                    F("g", "Giờ công chuẩn tháng", "T", "", "208"),
                },
                v => new BangLuongService().Lap(v.S("ma"), (int)v.N("m"), (int)v.N("y"), v.N("g"))
            );
        }
    }
}
