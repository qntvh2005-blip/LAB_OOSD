using System;
using System.Drawing;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_SHOPPING.UI

{
    public class LabForm : Form

    {
        public LabForm() : this("e-SHOPPING")
        {
        }
        public LabForm(string title,int width=640,int height=520)
        {
            Text=title;ClientSize=new Size(width,height);MinimumSize=new Size(width+16,height+39);
            StartPosition=FormStartPosition.CenterParent;Font=new Font("Segoe UI",10);BackColor=Color.White;
            AutoScaleMode=AutoScaleMode.Dpi;
        }
        protected async Task Run(Func<Task> action)
        {
            Enabled=false;UseWaitCursor=true;
            try{await action();}
            catch(SqlException){MessageBox.Show(this,"Không đọc/ghi được SQL Server. Kiểm tra App.config và chạy SetupDatabase.ps1 trước. Đơn chưa được ghi nhận nếu chưa có thông báo thành công.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);}
            catch(Exception ex){MessageBox.Show(this,ex.Message,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);}
            finally{if(!IsDisposed){Enabled=true;UseWaitCursor=false;}}
        }
    }
    public static class Ui
    {
        public static Label Label(string text,int x,int y,int width=160,int height=28)
        {return new Label{Text=text,Location=new Point(x,y),Size=new Size(width,height),AutoSize=false};}
        public static TextBox Text(int x,int y,int width=340,int max=100,bool password=false)
        {return new TextBox{Location=new Point(x,y),Width=width,MaxLength=max,UseSystemPasswordChar=password};}
        public static Button Button(string text,int x,int y,int width=150)
        {return new Button{Text=text,Location=new Point(x,y),Size=new Size(width,36),BackColor=Color.FromArgb(235,242,252),FlatStyle=FlatStyle.Flat};}
        public static DataGridView Grid(int x,int y,int width,int height)
        {return new DataGridView{Location=new Point(x,y),Size=new Size(width,height),ReadOnly=true,AllowUserToAddRows=false,AllowUserToDeleteRows=false,RowHeadersVisible=false,MultiSelect=false,SelectionMode=DataGridViewSelectionMode.FullRowSelect,AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill,BackgroundColor=Color.White,AutoGenerateColumns=false,ColumnHeadersHeight=32,ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.DisableResizing};}
        public static void Column(DataGridView g,string name,string title,string property,int weight=100,string format=null)
        {var c=new DataGridViewTextBoxColumn{Name=name,HeaderText=title,DataPropertyName=property,FillWeight=weight};if(format!=null)c.DefaultCellStyle.Format=format;g.Columns.Add(c);}
        public static void Bind(ComboBox c,object data,string display,string value){c.DisplayMember=display;c.ValueMember=value;c.DataSource=data;}
        public static ComboBox Combo(int x,int y,int width=340){return new ComboBox{Location=new Point(x,y),Width=width,DropDownStyle=ComboBoxStyle.DropDownList};}
        public static string Money(decimal n){return n.ToString("N0",System.Globalization.CultureInfo.GetCultureInfo("vi-VN"))+" đ";}
        public static Bitmap ProductImage(string code)
        {
            var image=new Bitmap(180,180);
            using(var g=Graphics.FromImage(image)){g.Clear(Color.FromArgb(237,243,252));using(var f=new Font("Segoe UI",18,FontStyle.Bold))g.DrawString(code,f,Brushes.SteelBlue,40,65);}
            return image;
        }
    }
}
