using System;
using System.Data;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Services;

namespace QuanLyChoThueVanPhong.Forms
{
    /// <summary>Tiện ích dùng chung cho các Form WinForms.</summary>
    internal static class FormHelper
    {
        public static void Nap(ComboBox cbo, DataTable dt, string display, string value)
        {
            cbo.DataSource = dt;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
        }

        public static string Gia(ComboBox cbo)
        {
            return cbo.SelectedValue == null ? "" : cbo.SelectedValue.ToString();
        }

        public static string O(DataGridView dgv, string cot)
        {
            return dgv.CurrentRow == null || dgv.CurrentRow.Cells[cot] == null || dgv.CurrentRow.Cells[cot].Value == null
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
