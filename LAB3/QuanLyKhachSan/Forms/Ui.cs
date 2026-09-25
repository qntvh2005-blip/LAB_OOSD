using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
namespace QuanLyKhachSan.Forms
{
    // Chỉ hỗ trợ dữ liệu và sự kiện lúc chạy. Toàn bộ control nằm trong Designer.
    internal static class UI
    {
        internal static void Fit(Form form)
        {
            // Màn hình nhỏ vẫn xem được toàn bộ bố cục bằng thanh cuộn.
            var bounds = Screen.FromControl(form).WorkingArea;
            form.AutoScroll = true;
            form.AutoScrollMinSize = form.ClientSize;
            form.Size = new System.Drawing.Size(Math.Min(form.Width, bounds.Width - 20), Math.Min(form.Height, bounds.Height - 20));
            form.Location = new System.Drawing.Point(bounds.Left + (bounds.Width - form.Width) / 2, bounds.Top + (bounds.Height - form.Height) / 2);
        }
        internal static bool IsDesign { get { return LicenseManager.UsageMode == LicenseUsageMode.Designtime; } }
        internal static void Run(Form owner, Action action)
        { try { action(); } catch (Exception ex) { MessageBox.Show(owner, ex.Message, "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Warning); } }
        internal static void Done(Form owner) { MessageBox.Show(owner, "Thực hiện thành công.", "Thông báo"); }
        internal static void Bind(ComboBox control, DataTable data, string value, string display = null)
        {
            control.DataSource = null; control.DisplayMember = display ?? value;
            control.ValueMember = value; control.DataSource = data;
        }
        internal static string V(ComboBox control)
        { var row = control.SelectedItem as DataRowView; return row == null ? control.Text : Convert.ToString(row[control.ValueMember]); }
        internal static string Cell(DataGridView grid, string property)
        {
            if (grid.CurrentRow == null) return "";
            var row = grid.CurrentRow.DataBoundItem as DataRowView;
            if (row != null) return Convert.ToString(row[property]);
            foreach (DataGridViewColumn column in grid.Columns)
                if (column.DataPropertyName == property) return Convert.ToString(grid.CurrentRow.Cells[column.Index].Value);
            return "";
        }
        internal static void FormatGrid(DataGridView grid)
        {
            foreach (DataGridViewColumn col in grid.Columns)
            {
                string p = col.DataPropertyName;
                if (p.Contains("Tien") || p.Contains("Gia") || p == "ConLai" || p == "MucDenBu")
                {
                    // Mã thiết bị MaTienNghi là chuỗi, không phải trường tiền.
                    if (p == "MaTienNghi") continue;
                    col.DefaultCellStyle.Format = "N0";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                if (p.StartsWith("Ngay")) col.DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
        internal static void Wire(Form owner, Button button, Action action)
        { button.Click += (s, e) => Run(owner, action); }
    }
}
