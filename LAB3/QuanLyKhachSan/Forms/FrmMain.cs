using System;
using System.Windows.Forms;
namespace QuanLyKhachSan.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain() {InitializeComponent();}
        private void FrmMain_Load(object sender,EventArgs e)
        {
            if(IsDesign)return;
            FitToScreen();
            Wire(btnDanhMuc,()=>Open(()=>new FrmDanhMuc()));
            Wire(btnPhong,()=>Open(()=>new FrmPhongTienNghi()));
            Wire(btnDatPhong,()=>Open(()=>new FrmDatPhong()));
            Wire(btnDichVu,()=>Open(()=>new FrmDichVu()));
            Wire(btnTraPhong,()=>Open(()=>new FrmTraPhong()));
            Wire(btnThongKe,()=>Open(()=>new FrmThongKe()));
            Wire(btnThoat,()=> {
                if(MessageBox.Show(this,"Bạn muốn thoát chương trình?","Xác nhận",MessageBoxButtons.YesNo)==DialogResult.Yes) Close();
            });
        }
        private void Open(Func<Form> create) {using(var form=create())form.ShowDialog(this);}
        private static bool IsDesign { get { return System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime; } }
        private void FitToScreen()
        {
            var bounds=System.Windows.Forms.Screen.FromControl(this).WorkingArea;
            AutoScroll=true; AutoScrollMinSize=ClientSize;
            Size=new System.Drawing.Size(Math.Min(Width,bounds.Width-20),Math.Min(Height,bounds.Height-20));
            Location=new System.Drawing.Point(bounds.Left+(bounds.Width-Width)/2,bounds.Top+(bounds.Height-Height)/2);
        }
        private void Run(System.Action action)
        {
            try { action(); }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(this,ex.Message,"Không thực hiện được",
                    System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Warning);
            }
        }
        private void Wire(System.Windows.Forms.Button button,System.Action action)
        { button.Click+=(s,e)=>Run(action); }
    }
}
