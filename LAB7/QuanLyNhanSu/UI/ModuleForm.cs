using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.UI
{
    public class Field
    {
        public string Key,
            Label,
            Mode,
            Source,
            Default;

        public Field(string k, string l, string mode = "T", string source = "", string value = "")
        {
            Key = k;
            Label = l;
            Mode = mode;
            Source = source;
            Default = value;
        }
    }

    public class Input
    {
        Dictionary<string, Control> controls;

        public Input(Dictionary<string, Control> c)
        {
            controls = c;
        }

        public string S(string k)
        {
            var c = controls[k];
            if (c is ComboBox)
                return ((ComboBox)c).SelectedValue == null
                    ? c.Text
                    : ((ComboBox)c).SelectedValue.ToString();
            return c.Text.Trim();
        }

        public decimal N(string k)
        {
            decimal n;
            Rules.Need(
                decimal.TryParse(S(k), NumberStyles.Number, CultureInfo.InvariantCulture, out n),
                "Số không hợp lệ: " + k + ". Dùng dấu chấm cho phần thập phân."
            );
            return n;
        }

        public DateTime D(string k)
        {
            return ((DateTimePicker)controls[k]).Value.Date;
        }

        public DateTime? OptionalDate(string k)
        {
            var d = (DateTimePicker)controls[k];
            return d.Checked ? (DateTime?)d.Value.Date : null;
        }

        public List<PhanBo> Lines(string k)
        {
            return S(k)
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line =>
                {
                    var x = line.Split('|');
                    Rules.Need(x.Length == 2, "Mỗi dòng: MaNV|Số tiền hoặc số giờ");
                    return new PhanBo(
                        x[0].Trim(),
                        decimal.Parse(x[1], CultureInfo.InvariantCulture)
                    );
                })
                .ToList();
        }

        public List<PhanCong> Plans(string k)
        {
            return S(k)
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(line =>
                {
                    var x = line.Split('|');
                    Rules.Need(x.Length == 5, "Mỗi dòng: MaNV|yyyy-MM-dd|MaCa|Giờ PT|Hình thức");
                    return new PhanCong
                    {
                        MaNV = x[0].Trim(),
                        Ngay = DateTime.ParseExact(
                            x[1].Trim(),
                            "yyyy-MM-dd",
                            CultureInfo.InvariantCulture
                        ),
                        MaCa = x[2].Trim(),
                        GioPhuTroi = decimal.Parse(x[3], CultureInfo.InvariantCulture),
                        HinhThuc = x[4].Trim(),
                    };
                })
                .ToList();
        }
    }

    public class ModuleForm : Form
    {
        private static readonly Color Accent = Color.FromArgb(20, 83, 135);
        private static readonly Color Ink = Color.FromArgb(35, 52, 72);
        private static readonly Color Muted = Color.FromArgb(99, 115, 133);
        private readonly TabControl tabs;
        private readonly ToolTip tips = new ToolTip();

        public ModuleForm(string title)
        {
            Text = title;
            AutoScaleDimensions = new SizeF(96, 96);
            AutoScaleMode = AutoScaleMode.Dpi;
            Font = new Font("Segoe UI", 10);
            ClientSize = new Size(1200, 810);
            MinimumSize = new Size(960, 700);
            BackColor = Color.FromArgb(243, 246, 250);
            ForeColor = Ink;
            StartPosition = FormStartPosition.CenterParent;

            var shell = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(18, 0, 18, 14),
            };
            shell.RowStyles.Add(new RowStyle(SizeType.Absolute, 82));
            shell.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            Controls.Add(shell);

            var header = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                Padding = new Padding(4, 14, 4, 10),
                Margin = Padding.Empty,
            };
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            header.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
            header.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            header.Controls.Add(
                new Label
                {
                    Text = title,
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Accent,
                    Dock = DockStyle.Fill,
                    AutoEllipsis = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                },
                0,
                0
            );
            header.Controls.Add(
                new Label
                {
                    Text = "CÔNG TY SƠN ĐÔNG Á  /  QUẢN LÝ NHÂN SỰ",
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Muted,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                },
                0,
                1
            );
            var close = ActionButton("Đóng", false);
            close.Name = "btnDong";
            close.Anchor = AnchorStyles.Right;
            close.Size = new Size(86, 34);
            close.Click += (sender, args) => Close();
            header.Controls.Add(close, 1, 0);
            header.SetRowSpan(close, 2);
            shell.Controls.Add(header, 0, 0);

            tabs = new TabControl
            {
                Dock = DockStyle.Fill,
                Padding = new Point(18, 8),
                ItemSize = new Size(0, 34),
                Margin = Padding.Empty,
            };
            shell.Controls.Add(tabs, 0, 1);
        }

        protected void Op(string title, string table, Field[] fields, Action<Input> save)
        {
            var tab = new TabPage(title) { BackColor = BackColor, Padding = new Padding(12) };
            tabs.TabPages.Add(tab);
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                Margin = Padding.Empty,
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 200));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tab.Controls.Add(layout);

            var editor = new CardPanel
            {
                Name = "pnlNhapLieu",
                Dock = DockStyle.Fill,
                Padding = new Padding(14, 8, 14, 8),
                Margin = Padding.Empty,
            };
            var editorShell = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Margin = Padding.Empty,
            };
            editorShell.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
            editorShell.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            editorShell.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
            editor.Controls.Add(editorShell);
            editorShell.Controls.Add(
                new Label
                {
                    Text = "THÔNG TIN NHẬP",
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = Accent,
                    TextAlign = ContentAlignment.MiddleLeft,
                },
                0,
                0
            );

            var scroll = new Panel
            {
                Name = "pnlCuonNhapLieu",
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Margin = Padding.Empty,
            };
            editorShell.Controls.Add(scroll, 0, 1);
            var details = fields.Where(field => field.Mode == "L").ToArray();
            var controls = new Dictionary<string, Control>();
            var reloads = new List<Action>();
            int contentHeight;
            scroll.Controls.Add(
                BuildEditor(table, fields, controls, reloads, scroll, out contentHeight)
            );

            string hintText =
                details.Length > 0 ? details[0].Label + ". " + Hint(table) : Hint(table);
            var hint = new Label
            {
                Text = hintText,
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                ForeColor = Muted,
                Font = new Font("Segoe UI", 9),
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(6, 2, 6, 0),
            };
            tips.SetToolTip(hint, hintText);
            editorShell.Controls.Add(hint, 0, 2);
            layout.Controls.Add(editor, 0, 0);

            var actions = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 1,
                Padding = new Padding(0, 10, 0, 6),
                Margin = Padding.Empty,
            };
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180));
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            var button = ActionButton(SaveTitle(table), true);
            button.Name = "btnLuu";
            var refresh = ActionButton("Tải lại", false);
            refresh.Name = "btnTaiLai";
            var toggle = ActionButton("Thu gọn phần nhập", false);
            toggle.Name = "btnThuGon";
            var status = new Label
            {
                Text = "Sẵn sàng",
                Dock = DockStyle.Fill,
                AutoEllipsis = true,
                ForeColor = Muted,
                Font = new Font("Segoe UI", 9),
                TextAlign = ContentAlignment.MiddleRight,
            };
            actions.Controls.Add(button, 0, 0);
            actions.Controls.Add(refresh, 1, 0);
            actions.Controls.Add(toggle, 2, 0);
            actions.Controls.Add(status, 3, 0);
            layout.Controls.Add(actions, 0, 1);

            var listBar = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                Padding = new Padding(0, 6, 0, 6),
                Margin = Padding.Empty,
            };
            listBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            listBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            listBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240));
            var count = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                AutoEllipsis = true,
            };
            listBar.Controls.Add(count, 0, 0);
            listBar.Controls.Add(
                new Label
                {
                    Text = "Tìm kiếm",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    ForeColor = Muted,
                },
                1,
                0
            );
            var search = new TextBox
            {
                Name = "txtTimKiem",
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 1, 0, 0),
            };
            tips.SetToolTip(search, "Tìm mã, họ tên hoặc nội dung trong danh sách đang xem.");
            listBar.Controls.Add(search, 2, 0);
            layout.Controls.Add(listBar, 0, 2);

            var gridCard = new CardPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(1),
                Margin = Padding.Empty,
            };
            var grid = CreateGrid();
            grid.Tag = table;
            gridCard.Controls.Add(grid);
            layout.Controls.Add(gridCard, 0, 3);

            DataView view = null;
            int total = 0;
            Action filter = () =>
            {
                if (view == null)
                    return;
                string value = search
                    .Text.Trim()
                    .Replace("'", "''")
                    .Replace("[", "[[]")
                    .Replace("%", "[%]")
                    .Replace("*", "[*]");
                view.RowFilter =
                    value.Length == 0
                        ? ""
                        : string.Join(
                            " OR ",
                            view.Table.Columns.Cast<DataColumn>()
                                .Select(column =>
                                    "CONVERT(["
                                    + column.ColumnName
                                    + "], 'System.String') LIKE '%"
                                    + value
                                    + "%'"
                                )
                        );
                string listTitle;
                if (!ListTitles.TryGetValue(table, out listTitle))
                    listTitle = title.ToLower(CultureInfo.GetCultureInfo("vi-VN"));
                count.Text =
                    "Danh sách "
                    + listTitle
                    + "  •  "
                    + (view.Count == total ? total.ToString() : view.Count + "/" + total)
                    + " bản ghi";
            };
            Action load = () =>
            {
                foreach (var reload in reloads)
                    reload();
                var data =
                    table == "LuongTongHop"
                        ? new BangLuongService().Xem()
                        : new TraCuuService().Bang(table);
                view = data.DefaultView;
                total = data.Rows.Count;
                grid.DataSource = view;
                StyleColumns(grid);
                filter();
                status.Text = "Đã tải dữ liệu • " + DateTime.Now.ToString("HH:mm");
                status.ForeColor = Muted;
            };
            Action tryLoad = () =>
            {
                try
                {
                    load();
                }
                catch (Exception exception)
                {
                    status.Text = "Không tải được dữ liệu";
                    status.ForeColor = Color.Firebrick;
                    MessageBox.Show(
                        "Kiểm tra kết nối trong App.config.\n" + exception.Message,
                        "Không thể tải dữ liệu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            };
            search.TextChanged += (sender, args) => filter();
            refresh.Click += (sender, args) => tryLoad();
            button.Click += (sender, args) =>
            {
                if (
                    MessageBox.Show(
                        "Xác nhận " + button.Text.ToLower() + "?",
                        "LAB7",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    ) != DialogResult.Yes
                )
                    return;
                try
                {
                    save(new Input(controls));
                    load();
                    status.Text = "Đã lưu thành công";
                    status.ForeColor = Color.FromArgb(25, 120, 75);
                    MessageBox.Show(
                        "Đã lưu thành công.",
                        "LAB7",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                catch (Exception exception)
                {
                    status.Text = exception.Message;
                    status.ForeColor = Color.Firebrick;
                    tips.SetToolTip(status, exception.Message);
                    MessageBox.Show(
                        exception.Message,
                        "Không thể lưu",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            };

            bool expanded = true;
            int desired = 90 + contentHeight;
            Action resize = () =>
            {
                int available = Math.Max(Pixels(120), layout.ClientSize.Height - Pixels(300));
                layout.RowStyles[0].Height = expanded ? Math.Min(Pixels(desired), available) : 0;
                StyleColumns(grid);
            };
            toggle.Click += (sender, args) =>
            {
                expanded = !expanded;
                editor.Visible = expanded;
                button.Enabled = expanded;
                toggle.Text = expanded ? "Thu gọn phần nhập" : "Hiện phần nhập";
                resize();
            };
            tab.SizeChanged += (sender, args) => resize();
            tab.Enter += (sender, args) =>
            {
                if (Visible)
                    tryLoad();
                resize();
            };
            Shown += (sender, args) =>
            {
                if (tabs.SelectedTab == tab)
                    tryLoad();
                resize();
            };
        }

        private Control BuildEditor(
            string table,
            Field[] fields,
            Dictionary<string, Control> controls,
            List<Action> reloads,
            Panel scroll,
            out int height
        )
        {
            FieldGroup[] groups = null;
            if (table == "HopDong")
            {
                groups = new[]
                {
                    new FieldGroup("Hợp đồng", "hd", "nv", "loai", "ngay", "tu", "den", "dk", "ky"),
                    new FieldGroup("Lương và chức vụ", "ql", "l", "pc", "dh", "qc", "cv", "pccv"),
                    new FieldGroup("Bảo hiểm", "xh", "yt", "rx", "ry"),
                };
            }
            else if (table == "QuyetDinhTuyenDung")
            {
                groups = new[]
                {
                    new FieldGroup("Hồ sơ nhân viên", "nv", "ten", "sinh", "dt", "dc", "pb"),
                    new FieldGroup(
                        "Quyết định thử việc",
                        "qd",
                        "ngay",
                        "tu",
                        "den",
                        "luong",
                        "dk",
                        "ky"
                    ),
                };
            }
            else if (table == "QuyetDinhThuongPhat")
            {
                groups = new[]
                {
                    new FieldGroup(
                        "Nội dung quyết định",
                        "q",
                        "lo",
                        "nv",
                        "pb",
                        "d",
                        "ky",
                        "nd",
                        "tien"
                    ),
                    new FieldGroup("Thanh toán và phân bổ", "ht", "gdoc", "ds"),
                };
            }

            if (groups == null)
                return BuildFields(table, fields, controls, reloads, scroll, out height);

            var sections = new TabControl
            {
                Name = "tabNhomNhap",
                Dock = DockStyle.Top,
                Padding = new Point(12, 6),
                ItemSize = new Size(0, 30),
            };
            int maximum = 0;
            foreach (var group in groups)
            {
                var page = new TabPage(group.Title)
                {
                    BackColor = Color.White,
                    Padding = new Padding(4),
                };
                int groupHeight;
                page.Controls.Add(
                    BuildFields(
                        table,
                        group
                            .Keys.Select(key => fields.Single(field => field.Key == key))
                            .ToArray(),
                        controls,
                        reloads,
                        scroll,
                        out groupHeight
                    )
                );
                maximum = Math.Max(maximum, groupHeight);
                sections.TabPages.Add(page);
            }
            height = maximum + 46;
            sections.Height = height;
            return sections;
        }

        private TableLayoutPanel BuildFields(
            string table,
            Field[] fields,
            Dictionary<string, Control> controls,
            List<Action> reloads,
            Panel scroll,
            out int height
        )
        {
            var normal = fields.Where(field => field.Mode != "L").ToArray();
            var details = fields.Where(field => field.Mode == "L").ToArray();
            bool sideDetail = details.Length == 1;
            int columns = normal.Length >= (sideDetail ? 9 : 7) ? 3 : 2;
            int rows = Math.Max(sideDetail ? 2 : 1, (normal.Length + columns - 1) / columns);
            int totalColumns = columns + (sideDetail ? 1 : 0);
            var entry = new TableLayoutPanel
            {
                Name = "tblTruongNhap",
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                ColumnCount = totalColumns,
                RowCount = rows + (sideDetail ? 0 : details.Length),
                Margin = Padding.Empty,
            };
            float share = sideDetail ? (columns == 3 ? 70f : 62f) : 100f;
            for (int i = 0; i < columns; i++)
                entry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, share / columns));
            if (sideDetail)
                entry.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f - share));
            for (int i = 0; i < rows; i++)
                entry.RowStyles.Add(new RowStyle(SizeType.Absolute, 64));
            if (!sideDetail)
                foreach (var field in details)
                    entry.RowStyles.Add(new RowStyle(SizeType.Absolute, 128));

            for (int i = 0; i < normal.Length; i++)
            {
                var control = CreateInput(normal[i], reloads);
                controls[normal[i].Key] = control;
                entry.Controls.Add(FieldBox(normal[i].Label, control), i % columns, i / columns);
                control.Enter += (sender, args) => scroll.ScrollControlIntoView(control.Parent);
            }
            for (int i = 0; i < details.Length; i++)
            {
                var control = CreateInput(details[i], reloads);
                controls[details[i].Key] = control;
                var box = FieldBox(DetailTitle(table), control);
                if (sideDetail)
                {
                    entry.Controls.Add(box, columns, 0);
                    entry.SetRowSpan(box, rows);
                }
                else
                {
                    entry.Controls.Add(box, 0, rows + i);
                    entry.SetColumnSpan(box, totalColumns);
                }
                control.Enter += (sender, args) => scroll.ScrollControlIntoView(control.Parent);
            }
            height = rows * 64 + (sideDetail ? 0 : details.Length * 128);
            return entry;
        }

        private Control CreateInput(Field field, List<Action> reloads)
        {
            Control control;
            if (field.Mode == "D" || field.Mode == "ND")
            {
                control = new DateTimePicker
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "dd/MM/yyyy",
                    ShowCheckBox = field.Mode == "ND",
                    Checked = field.Mode != "ND",
                };
            }
            else if (field.Mode == "C")
            {
                var combo = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    FlatStyle = FlatStyle.Standard,
                    IntegralHeight = false,
                    MaxDropDownItems = 10,
                };
                if (field.Source.Contains("."))
                {
                    var key = field.Source.Split('.');
                    reloads.Add(() =>
                    {
                        string selected = Convert.ToString(combo.SelectedValue);
                        var data = new TraCuuService().Ma(key[0], key[1]);
                        combo.DisplayMember = "HienThi";
                        combo.ValueMember = key[1];
                        combo.DataSource = data;
                        if (
                            data
                                .Rows.Cast<DataRow>()
                                .Any(row => Convert.ToString(row[key[1]]) == selected)
                        )
                            combo.SelectedValue = selected;
                        combo.DropDownWidth = Math.Max(combo.Width, Pixels(360));
                    });
                }
                else
                {
                    combo.DisplayMember = "Text";
                    combo.ValueMember = "Value";
                    combo.DataSource = field
                        .Source.Split('|')
                        .Select(value => new Choice { Value = value, Text = DisplayValue(value) })
                        .ToList();
                }
                control = combo;
            }
            else
            {
                var text = new TextBox
                {
                    Multiline = field.Mode == "L",
                    AcceptsReturn = field.Mode == "L",
                    ScrollBars = field.Mode == "L" ? ScrollBars.Vertical : ScrollBars.None,
                    BorderStyle = BorderStyle.FixedSingle,
                    Text = field.Default,
                };
                if (field.Mode == "L")
                    text.Font = new Font("Consolas", 10);
                text.Enter += (sender, args) => text.BackColor = Color.FromArgb(245, 250, 255);
                text.Leave += (sender, args) => text.BackColor = Color.White;
                control = text;
            }
            control.Name = field.Key;
            control.Dock = DockStyle.Fill;
            control.Margin = new Padding(0, 2, 0, 0);
            tips.SetToolTip(control, field.Label);
            return control;
        }

        private TableLayoutPanel FieldBox(string title, Control control)
        {
            var box = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1,
                Margin = new Padding(6, 2, 12, 8),
            };
            box.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            box.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            box.Controls.Add(
                new Label
                {
                    Text = title,
                    Dock = DockStyle.Fill,
                    AutoEllipsis = true,
                    ForeColor = Muted,
                    Font = new Font("Segoe UI", 9),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Margin = Padding.Empty,
                },
                0,
                0
            );
            box.Controls.Add(control, 0, 1);
            return box;
        }

        private Button ActionButton(string title, bool primary)
        {
            var button = new Button
            {
                Text = title,
                Dock = DockStyle.Fill,
                BackColor = primary ? Accent : Color.White,
                ForeColor = primary ? Color.White : Ink,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 10, 0),
                UseVisualStyleBackColor = false,
            };
            button.FlatAppearance.BorderColor = primary ? Accent : Color.FromArgb(210, 220, 231);
            button.FlatAppearance.MouseOverBackColor = primary
                ? Color.FromArgb(13, 65, 110)
                : Color.FromArgb(235, 243, 251);
            return button;
        }

        private DataGridView CreateGrid()
        {
            var grid = new DataGridView
            {
                Name = "grdDanhSach",
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                MultiSelect = false,
                EnableHeadersVisualStyles = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                GridColor = Color.FromArgb(231, 237, 244),
                ColumnHeadersHeight = 42,
                ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            };
            grid.RowTemplate.Height = 34;
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(232, 240, 249),
                ForeColor = Accent,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Padding = new Padding(8, 0, 4, 0),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                WrapMode = DataGridViewTriState.False,
                SelectionBackColor = Color.FromArgb(232, 240, 249),
                SelectionForeColor = Accent,
            };
            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                ForeColor = Ink,
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(218, 235, 253),
                SelectionForeColor = Ink,
                Padding = new Padding(8, 0, 4, 0),
                NullValue = "—",
                FormatProvider = CultureInfo.GetCultureInfo("vi-VN"),
            };
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 253);
            grid.CellFormatting += (sender, args) =>
            {
                if (args.Value is string && args.ColumnIndex >= 0)
                {
                    string column = grid.Columns[args.ColumnIndex].Name;
                    if (
                        new[] { "TrangThai", "KetQua", "LoaiHD", "HinhThuc", "Loai" }.Contains(
                            column
                        )
                    )
                        args.Value = DisplayValue((string)args.Value);
                }
            };
            return grid;
        }

        private static void StyleColumns(DataGridView grid)
        {
            if (grid.Columns.Count == 0)
                return;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            int totalWidth = 0;
            foreach (DataGridViewColumn column in grid.Columns)
            {
                string name = column.Name;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                string title;
                column.HeaderText = ColumnTitles.TryGetValue(name, out title) ? title : name;
                if (name == "Ngay")
                {
                    string table = Convert.ToString(grid.Tag);
                    column.HeaderText =
                        table == "PhieuThuChi" ? "Ngày thu / chi"
                        : table == "ChiTietPhuTroi" ? "Ngày phụ trội"
                        : table == "ChamCong" ? "Ngày chấm công"
                        : "Ngày làm việc";
                }
                int width = Math.Max(
                    100,
                    TextRenderer
                        .MeasureText(column.HeaderText, grid.ColumnHeadersDefaultCellStyle.Font)
                        .Width + 26
                );
                if (
                    name == "HoTen"
                    || name == "NguoiCham"
                    || name == "NguoiLap"
                    || name == "NguoiKy"
                )
                    width = Math.Max(175, width);
                if (
                    name == "DoiTuong"
                    || name == "NoiDung"
                    || name == "DieuKhoan"
                    || name == "DiaChi"
                )
                    width = Math.Max(230, width);
                if (name == "MaKH" || name == "MaBHXH" || name == "MaBHYT")
                    width = Math.Max(165, width);
                if (name == "Loai" || name == "LoaiHD" || name == "HinhThuc" || name == "TrangThai")
                    width = Math.Max(155, width);
                if (name == "KetQua" || name == "TenPB" || name == "TenCV")
                    width = Math.Max(160, width);
                if (name == "Nam" || name == "Thang")
                    width = 72;
                if (column.ValueType == typeof(DateTime))
                {
                    column.DefaultCellStyle.Format =
                        name == "NgayLap" ? "dd/MM/yyyy HH:mm" : "dd/MM/yyyy";
                    width = name == "NgayLap" ? 170 : Math.Max(120, width);
                }
                if (column.ValueType == typeof(decimal))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    column.DefaultCellStyle.Format =
                        name.StartsWith("TyLe") ? "P0"
                        : name.Contains("Gio") ? "N2"
                        : "N0";
                    width = Math.Max(120, width);
                }
                column.MinimumWidth = width;
                column.Width = width;
                column.FillWeight = width;
                totalWidth += width;
            }
            if (totalWidth < grid.ClientSize.Width - 24)
            {
                var stretch = grid
                    .Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(column =>
                        new[]
                        {
                            "TenPB",
                            "TenCV",
                            "TenCa",
                            "NguoiCham",
                            "HoTen",
                            "NoiDung",
                        }.Contains(column.Name)
                    );
                if (stretch == null)
                    stretch = grid.Columns[grid.Columns.Count - 1];
                stretch.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (grid.Columns.Contains("ThucLinh"))
            {
                string[] order =
                {
                    "HoTen",
                    "MaNV",
                    "Nam",
                    "Thang",
                    "ThucLinh",
                    "LuongTheoCong",
                    "TienPhuTroi",
                    "TruBHXH",
                    "TruBHYT",
                    "TienThuong",
                    "TienPhat",
                    "GioThuong",
                    "GioPhuTroi",
                    "MaBL",
                };
                int position = 0;
                foreach (string name in order.Where(name => grid.Columns.Contains(name)))
                    grid.Columns[name].DisplayIndex = position++;
                grid.Columns["ThucLinh"].DefaultCellStyle.BackColor = Color.FromArgb(237, 246, 255);
                if (grid.Columns["ThucLinh"].DefaultCellStyle.Font == null)
                    grid.Columns["ThucLinh"].DefaultCellStyle.Font = new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold
                    );
            }
        }

        private int Pixels(int value)
        {
            return (int)Math.Round(value * DeviceDpi / 96.0);
        }

        private static string DisplayValue(string value)
        {
            string title;
            return ValueTitles.TryGetValue(value, out title) ? title : value;
        }

        private static string DetailTitle(string table)
        {
            return table == "PhanCongCa" ? "Chi tiết phân công theo ngày"
                : table == "ChiTietPhuTroi" ? "Nhân viên tham gia và số giờ phụ trội"
                : "Phân bổ số tiền theo nhân viên";
        }

        private static string SaveTitle(string table)
        {
            if (table == "ChamCong")
                return "Lưu chấm công";
            if (table == "LuongTongHop")
                return "Tính và chốt lương";
            if (table == "NhanVien")
                return "Lưu đánh giá";
            if (table == "HopDong")
                return "Lưu hợp đồng";
            if (table == "PhanCongCa")
                return "Lưu kế hoạch";
            if (table == "ChiTietPhuTroi")
                return "Lưu phiếu phụ trội";
            if (table == "PhieuThuChi")
                return "Lưu phiếu thu / chi";
            if (table.StartsWith("QuyetDinh"))
                return "Lưu quyết định";
            return "Thêm mới";
        }

        private static string Hint(string table)
        {
            if (table == "PhongBan" || table == "ChucVu")
                return "Nhập mã không trùng và tên đầy đủ. Bảng bên dưới hiển thị danh mục hiện có.";
            if (table == "CaLam")
                return "Nhập mã ca, tên ca và số giờ chuẩn lớn hơn 0, không quá 24 giờ.";
            if (table == "QuyetDinhLuong" || table == "QuyetDinhChucVu")
                return "Quyết định mới được lưu theo ngày hiệu lực, không ghi đè lịch sử. Số tiền nhập không có dấu phân cách hàng nghìn.";
            if (table == "ChamCong")
                return "Chọn nhân viên đã được phân ca; nhập số giờ thực tế không vượt giờ ca.";
            if (table == "LuongTongHop")
                return "Kiểm tra đủ công, phụ trội và thưởng/phạt trước khi chốt. Mỗi tháng chỉ chốt một lần.";
            if (table == "HopDong")
                return "Điền cả 3 nhóm trước khi lưu. Hợp đồng dài hạn cần đủ BHXH và BHYT.";
            if (table == "QuyetDinhTuyenDung")
                return "Điền cả Hồ sơ nhân viên và Quyết định thử việc trước khi lưu. Ngày kết thúc không trước ngày bắt đầu.";
            if (table == "NhanVien")
                return "Chỉ đánh giá khi đã hết thời gian thử việc; chọn Đạt hoặc Không đạt.";
            if (table == "PhanCongCa")
                return "Ví dụ: NV001|2026-10-23|CA01|2|TangCa. Chọn thứ Hai đầu tuần.";
            if (table == "ChiTietPhuTroi")
                return "Ví dụ: NV001|2. Mỗi nhân viên một dòng, số giờ không vượt kế hoạch.";
            if (table == "QuyetDinhThuongPhat")
                return "Ví dụ: NV001|50000. Chỉ nhập mã NV (cá nhân) hoặc mã PB (tập thể).";
            if (table == "PhieuThuChi")
                return "Chỉ lập tại đây cho thanh toán trực tiếp; qua lương sinh phiếu khi chốt.";
            return "Nhập số không có dấu phân cách hàng nghìn; phần thập phân dùng dấu chấm. Danh sách bên dưới chỉ đọc.";
        }

        private static readonly Dictionary<string, string> ValueTitles = new Dictionary<
            string,
            string
        >
        {
            { "ThuViec", "Thử việc" },
            { "ChinhThuc", "Chính thức" },
            { "KhongDat", "Không đạt" },
            { "Dat", "Đạt" },
            { "ChoDanhGia", "Chờ đánh giá" },
            { "DaiHan", "Dài hạn" },
            { "NganHan", "Ngắn hạn" },
            { "TangCa", "Tăng ca" },
            { "NgayLe", "Ngày lễ" },
            { "NgayNghi", "Ngày nghỉ" },
            { "QuaLuong", "Qua bảng lương" },
            { "TrucTiep", "Trực tiếp" },
            { "Thuong", "Khen thưởng" },
            { "Phat", "Kỷ luật / phạt" },
            { "Thu", "Phiếu thu" },
            { "Chi", "Phiếu chi" },
        };

        private static readonly Dictionary<string, string> ColumnTitles = new Dictionary<
            string,
            string
        >
        {
            { "MaPB", "Mã phòng ban" },
            { "TenPB", "Phòng ban" },
            { "MaCV", "Mã chức vụ" },
            { "TenCV", "Chức vụ" },
            { "MaCa", "Mã ca" },
            { "TenCa", "Ca làm" },
            { "GioChuan", "Giờ chuẩn" },
            { "MaNV", "Mã nhân viên" },
            { "HoTen", "Họ và tên" },
            { "NgaySinh", "Ngày sinh" },
            { "DienThoai", "Điện thoại" },
            { "DiaChi", "Địa chỉ" },
            { "TrangThai", "Trạng thái" },
            { "SoQD", "Số quyết định" },
            { "NgayQD", "Ngày quyết định" },
            { "TuNgay", "Từ ngày" },
            { "DenNgay", "Đến ngày" },
            { "LuongThuViec", "Lương thử việc" },
            { "DieuKhoan", "Điều khoản" },
            { "NguoiKy", "Người ký" },
            { "KetQua", "Kết quả" },
            { "SoHD", "Số hợp đồng" },
            { "LoaiHD", "Loại hợp đồng" },
            { "NgayKy", "Ngày ký" },
            { "MaBHXH", "Mã BHXH" },
            { "MaBHYT", "Mã BHYT" },
            { "TyLeBHXH", "Tỷ lệ BHXH" },
            { "TyLeBHYT", "Tỷ lệ BHYT" },
            { "NgayHieuLuc", "Ngày hiệu lực" },
            { "LuongCoBan", "Lương cơ bản" },
            { "PhuCapLuong", "Phụ cấp lương" },
            { "PhuCapDocHai", "Phụ cấp độc hại" },
            { "PhuCapChucVu", "Phụ cấp chức vụ" },
            { "MaKH", "Mã kế hoạch" },
            { "NgayDauTuan", "Đầu tuần" },
            { "NguoiLap", "Người lập" },
            { "Id", "Mã phân công" },
            { "IdPhanCong", "Mã phân công" },
            { "Ngay", "Ngày làm việc" },
            { "GioPhuTroiDuKien", "Giờ PT dự kiến" },
            { "HinhThuc", "Hình thức" },
            { "GioThucTe", "Giờ thực tế" },
            { "NguoiCham", "Người chấm" },
            { "SoPhieu", "Số phiếu" },
            { "SoGio", "Số giờ phụ trội" },
            { "Loai", "Loại" },
            { "KyApDung", "Kỳ áp dụng" },
            { "NoiDung", "Nội dung" },
            { "SoTien", "Số tiền" },
            { "DoiTuong", "Đối tượng" },
            { "MaBL", "Mã bảng lương" },
            { "Thang", "Tháng" },
            { "Nam", "Năm" },
            { "NgayLap", "Ngày lập" },
            { "GioThuong", "Giờ thường" },
            { "GioPhuTroi", "Giờ phụ trội" },
            { "LuongTheoCong", "Lương theo công" },
            { "TienPhuTroi", "Tiền phụ trội" },
            { "TruBHXH", "Trừ BHXH" },
            { "TruBHYT", "Trừ BHYT" },
            { "TienThuong", "Tiền thưởng" },
            { "TienPhat", "Tiền phạt" },
            { "ThucLinh", "Thực lĩnh" },
        };

        private static readonly Dictionary<string, string> ListTitles = new Dictionary<
            string,
            string
        >
        {
            { "PhongBan", "phòng ban" },
            { "ChucVu", "chức vụ" },
            { "CaLam", "ca làm" },
            { "QuyetDinhTuyenDung", "quyết định tuyển dụng" },
            { "NhanVien", "nhân viên" },
            { "HopDong", "hợp đồng" },
            { "QuyetDinhLuong", "quyết định lương" },
            { "QuyetDinhChucVu", "quyết định chức vụ" },
            { "PhanCongCa", "phân công" },
            { "ChamCong", "chấm công" },
            { "ChiTietPhuTroi", "phụ trội" },
            { "QuyetDinhThuongPhat", "quyết định thưởng / phạt" },
            { "PhieuThuChi", "phiếu thu / chi" },
            { "LuongTongHop", "bảng lương" },
        };

        private sealed class Choice
        {
            public string Value { get; set; }
            public string Text { get; set; }
        }

        private sealed class FieldGroup
        {
            public string Title;
            public string[] Keys;

            public FieldGroup(string title, params string[] keys)
            {
                Title = title;
                Keys = keys;
            }
        }

        private sealed class CardPanel : Panel
        {
            public CardPanel()
            {
                BackColor = Color.White;
                DoubleBuffered = true;
            }

            protected override void OnPaint(PaintEventArgs args)
            {
                base.OnPaint(args);
                using (var pen = new Pen(Color.FromArgb(216, 225, 235)))
                    args.Graphics.DrawRectangle(
                        pen,
                        0,
                        0,
                        Math.Max(0, Width - 1),
                        Math.Max(0, Height - 1)
                    );
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                tips.Dispose();
            base.Dispose(disposing);
        }

        protected Field F(
            string k,
            string l,
            string mode = "T",
            string source = "",
            string value = ""
        )
        {
            return new Field(k, l, mode, source, value);
        }
    }
}
