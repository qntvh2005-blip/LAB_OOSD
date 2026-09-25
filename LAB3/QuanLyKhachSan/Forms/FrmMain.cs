using System;
using System.Windows.Forms;
namespace QuanLyKhachSan.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain() {InitializeComponent();}
        private void FrmMain_Load(object sender,EventArgs e)
        {
            if(UI.IsDesign)return;
            UI.Fit(this);
            UI.Wire(this,btnDanhMuc,()=>Open(()=>new FrmDanhMuc()));
            UI.Wire(this,btnPhong,()=>Open(()=>new FrmPhongTienNghi()));
            UI.Wire(this,btnDatPhong,()=>Open(()=>new FrmDatPhong()));
            UI.Wire(this,btnDichVu,()=>Open(()=>new FrmDichVu()));
            UI.Wire(this,btnTraPhong,()=>Open(()=>new FrmTraPhong()));
            UI.Wire(this,btnThongKe,()=>Open(()=>new FrmThongKe()));
            UI.Wire(this,btnThoat,()=> {
                if(MessageBox.Show(this,"Bạn muốn thoát chương trình?","Xác nhận",MessageBoxButtons.YesNo)==DialogResult.Yes) Close();
            });
        }
        private void Open(Func<Form> create) {using(var form=create())form.ShowDialog(this);}
    }
}
