using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using QuanLyKhachSan.Data;
using QuanLyKhachSan.Services;
class IntegrationTests
{
    static int pass;
    static void Assert(bool condition,string title) {if(!condition)throw new Exception("FAIL: "+title); Console.WriteLine("PASS: "+title); pass++;}
    static void Reject(Action action,string title) {bool rejected=false; try {action();} catch(InvalidOperationException){rejected=true;} catch(SqlException){rejected=true;} Assert(rejected,title);}
    static List<PhongDatItem> Rooms(string room,int n) {return new List<PhongDatItem>{new PhongDatItem{SoPhong=room,SoNguoi=n}};}
    static decimal Value(string sql,params object[] args) {return Convert.ToDecimal(Db.Query(sql,args).Rows[0][0]);}
    static int Main()
    {
        try {
            var cs=new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["QuanLyKhachSanDB"].ConnectionString);
            if(cs.InitialCatalog!="QuanLyKhachSan_Test")throw new Exception("Chỉ cho phép chạy trên QuanLyKhachSan_Test.");
            string prefix="T"+Guid.NewGuid().ToString("N").Substring(0,8);
            var dm=new DanhMucService(); var booking=new DatPhongService(); var equip=new PhongTienNghiService();
            var dv=new DichVuService(); var checkout=new TraPhongService();
            string customer=prefix+"K",room=prefix+"R",room2=prefix+"S",device=prefix+"TV",stay=prefix+"D",invoice=prefix+"H";
            dm.Add("KhachHang",customer,"Khách kiểm thử",prefix+"CCCD","Việt Nam",DBNull.Value);
            dm.Add("Phong",room,"A",2,600000m); dm.Add("Phong",room2,"A",2,600000m);
            dm.Add("LoaiTienNghi",prefix+"L","Loại thử "+prefix);
            dm.Add("TienNghi",device,prefix+"L",1,"Tốt");
            dm.Add("QuyDinhDenBu",prefix+"QD",prefix+"L","Hư hỏng nhẹ",500000m);
            Reject(()=>booking.Book(prefix+"Bad",customer,"NV01",DateTime.Today,DateTime.Today.AddDays(1),0,"Trực tiếp",Rooms(room,3)),"Sức chứa vượt 2 bị từ chối");
            Assert(Value("SELECT COUNT(*) FROM PhieuDatPhong WHERE SoPhieuDat=@p0",prefix+"Bad")==0,"Không lưu dở phiếu lỗi");
            booking.Book(stay,customer,"NV01",DateTime.Today,DateTime.Today.AddDays(1),0,"Trực tiếp",Rooms(room,1));
            Assert(Value("SELECT COUNT(*) FROM PhieuDatPhong WHERE SoPhieuDat=@p0",stay)==1,"Đặt phòng hợp lệ");
            Reject(()=>booking.Book(prefix+"Overlap",customer,"NV01",DateTime.Today,DateTime.Today.AddDays(1),0,"Trực tiếp",Rooms(room,1)),"Chặn trùng lịch");
            Reject(()=>booking.Book(prefix+"Edge",customer,"NV01",DateTime.Today.AddDays(1),DateTime.Today.AddDays(2),0,"Trực tiếp",Rooms(room,1)),"Trùng ngày biên theo PDF");
            equip.Install(prefix+"LD",device,room,DateTime.Today,"Tốt","NV02","");
            Reject(()=>equip.Install(prefix+"LD2",device,room2,DateTime.Today,"Tốt","NV02",""),"Một thiết bị / một phòng / một ngày");
            Reject(()=>dv.Record(stay,room,DateTime.Today,"NV02","DV01",1),"Không ghi DV khi chưa nhận phòng");
            booking.AddGuest(stay,room,"Khách thử",prefix+"C1","Việt Nam");
            Reject(()=>booking.AddGuest(stay,room,"Khách thừa",prefix+"C2","Việt Nam"),"Giới hạn số người lưu trú đăng ký");
            booking.CheckIn(stay);
            dv.Record(stay,room,DateTime.Today,"NV02","DV01",1);
            dv.Record(stay,room,DateTime.Today,"NV02","DV01",2);
            Assert(Value(@"SELECT SUM(c.SoLuong) FROM ChiTietPhieuSuDungDV c JOIN PhieuSuDungDV p ON c.SoPhieuSDDV=p.SoPhieuSDDV WHERE p.SoPhieuDat=@p0",stay)==3,"DV cộng dồn 1+2=3");
            Assert(Value(@"SELECT COUNT(*) FROM ChiTietPhieuSuDungDV c JOIN PhieuSuDungDV p ON c.SoPhieuSDDV=p.SoPhieuSDDV WHERE p.SoPhieuDat=@p0",stay)==1,"DV chỉ có một dòng trong ngày");
            checkout.Damage(prefix+"DB",stay,room,"NV02",new List<DenBuItem>{new DenBuItem{MaTienNghi=device,MucDoThietHai="Hư hỏng nhẹ",SoTien=500000m}});
            Assert(Value("SELECT TongTien FROM PhieuDenBu WHERE SoPhieuDat=@p0",stay)==500000m,"Phiếu đền bù riêng");
            checkout.Invoice(invoice,stay,"NV03",1);
            Assert(Value("SELECT TongTien FROM HoaDon WHERE SoHoaDon=@p0",invoice)==960000m,"Hóa đơn 600000 + 3*120000 = 960000; không cộng đền bù");
            Reject(()=>checkout.Invoice(prefix+"H2",stay,"NV03",1),"Một hóa đơn trên một phiếu đặt");
            Reject(()=>dv.Record(stay,room,DateTime.Today,"NV02","DV01",1),"Chặn thêm DV sau chốt hóa đơn");
            Reject(()=>checkout.Pay(prefix+"Over",invoice,"Tiền mặt",960001m),"Chặn thanh toán vượt hóa đơn");
            Reject(()=>checkout.CheckOut(stay),"Chặn trả phòng khi chưa trả tiền");
            checkout.Pay(prefix+"TT1",invoice,"Tiền mặt",100000m);
            Reject(()=>checkout.CheckOut(stay),"Chặn trả phòng khi mới thanh toán một phần");
            checkout.Pay(prefix+"TT2",invoice,"Chuyển khoản",200000m);
            checkout.Pay(prefix+"TT3",invoice,"Thẻ",300000m);
            checkout.Pay(prefix+"TT4",invoice,"Ví điện tử",360000m);
            Assert(Value("SELECT SUM(SoTien) FROM ThanhToan WHERE SoHoaDon=@p0",invoice)==960000m,"Bốn phương thức thanh toán đủ tiền");
            Assert(Convert.ToString(checkout.Invoices(stay).Rows[0]["TrangThai"])=="Đã thanh toán","Cập nhật trạng thái hóa đơn");
            checkout.CheckOut(stay);
            Assert(Convert.ToString(Db.Query("SELECT TrangThai FROM Phong WHERE SoPhong=@p0",room).Rows[0][0])=="Trống","Trả phòng giải phóng phòng");
            int successes=0;
            Parallel.For(0,2,i=>{try {booking.Book(prefix+"Race"+i,customer,"NV01",DateTime.Today,DateTime.Today.AddDays(1),0,"Trực tiếp",Rooms(room2,1)); Interlocked.Increment(ref successes);} catch(InvalidOperationException){} });
            Assert(successes==1,"Hai yêu cầu đặt cùng phòng đồng thời: chỉ một thành công");
            Console.WriteLine("PASS TOTAL: "+pass+". Dữ liệu thử được giữ trong database Test. Prefix: "+prefix); return 0;
        } catch(Exception e) {Console.Error.WriteLine(e); return 1;}
    }
}
