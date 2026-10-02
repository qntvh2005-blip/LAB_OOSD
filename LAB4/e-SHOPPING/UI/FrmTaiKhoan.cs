using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_SHOPPING.Models;
using Context=e_SHOPPING.Services.AppContext;

namespace e_SHOPPING.UI
{
    public class FrmDangNhap : LabForm
    {
        readonly TextBox ten=Ui.Text(190,70,310,50),password=Ui.Text(190,120,310,128,true);
        public FrmDangNhap(Context app):base("Đăng nhập",550,260)
        {
            Controls.AddRange(new Control[]{Ui.Label("Tên đăng nhập",25,73),ten,Ui.Label("Mật khẩu",25,123),password,Ui.Label("Tài khoản mẫu: demo / Demo@123",25,20,480)});
            var login=Ui.Button("Đăng nhập",190,175);var register=Ui.Button("Đăng ký",350,175);Controls.AddRange(new Control[]{login,register});AcceptButton=login;
            login.Click+=async (s,e)=>await Run(async()=>{var u=ten.Text;var p=password.Text;var k=await Task.Run(()=>app.TaiKhoan.DangNhap(u,p));app.Khach=k;password.Clear();DialogResult=DialogResult.OK;Close();});
            register.Click+=(s,e)=>{using(var f=new FrmDangKy(app))f.ShowDialog(this);};
        }
    }
    public class FrmDangKy : LabForm
    {
        public FrmDangKy(Context app):base("Đăng ký tài khoản",620,555)
        {
            string[] names={"Họ tên","Ngày sinh","CMND / Passport","Địa chỉ","Điện thoại","Tên đăng nhập","Mật khẩu","Nhập lại mật khẩu","Email (không bắt buộc)"};
            var texts=new TextBox[9];var date=new DateTimePicker{Location=new System.Drawing.Point(235,67),Width=340,Format=DateTimePickerFormat.Short,Value=new DateTime(2000,1,1),MaxDate=DateTime.Today.AddDays(-1)};
            for(int i=0;i<9;i++){int y=25+i*43;Controls.Add(Ui.Label(names[i],20,y+3,210));if(i==1){Controls.Add(date);continue;}texts[i]=Ui.Text(235,y,340,i==3?250:i==8?254:i==2?30:i==4?20:i==5?50:i==6||i==7?128:100,i==6||i==7);Controls.Add(texts[i]);}
            var b=Ui.Button("Tạo tài khoản",235,440,180);Controls.Add(b);AcceptButton=b;
            b.Click+=async (s,e)=>await Run(async()=>{
                if(texts[6].Text!=texts[7].Text)throw new InvalidOperationException("Hai mật khẩu không khớp.");
                var k=new KhachHang{HoTen=texts[0].Text,NgaySinh=date.Value,CMNDPassport=texts[2].Text,DiaChi=texts[3].Text,DienThoai=texts[4].Text,TenDangNhap=texts[5].Text,Email=texts[8].Text};var p=texts[6].Text;
                await Task.Run(()=>app.TaiKhoan.DangKy(k,p));MessageBox.Show(this,"Đăng ký thành công. Bạn có thể đăng nhập.");DialogResult=DialogResult.OK;Close();});
        }
    }
}
