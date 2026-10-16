using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    /// <summary>Tiện ích dùng chung cho các Form WinForms.</summary>
    internal static class FormHelper
    {
        public static void Nap(ComboBox cbo, DataTable dt, string display, string value)
        {
            cbo.DataSource = null;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = dt;
        }

        public static string Gia(ComboBox cbo)
        {
            return cbo.SelectedValue == null || cbo.SelectedValue is DataRowView
                ? "" : cbo.SelectedValue.ToString();
        }

        public static string O(DataGridView dgv, string cot)
        {
            return dgv.CurrentRow == null || !dgv.Columns.Contains(cot) || dgv.CurrentRow.Cells[cot].Value == null
                ? ""
                : dgv.CurrentRow.Cells[cot].Value.ToString();
        }

        public static bool Bao(KetQuaXuLy k)
        {
            MessageBox.Show(k.ThongBao, k.ThanhCong ? "Thông báo" : "Không thực hiện được",
                MessageBoxButtons.OK, k.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            return k.ThanhCong;
        }
    }
}
