using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using QuanLyKhachSan.Data;
namespace QuanLyKhachSan.Services
{
    public class PhongDatItem
    { public string SoPhong {get;set;} public int SoNguoi {get;set;} public decimal DonGiaNgay {get;set;} }
    public class DatPhongService
    {
        public DataTable List() { return Db.Query("SELECT d.*,k.HoTen FROM PhieuDatPhong d JOIN KhachHang k ON d.MaKhach=k.MaKhach ORDER BY NgayLap DESC"); }
        public DataTable Rooms(string id) { return Db.Query("SELECT c.*,p.DonGiaNgay FROM ChiTietDatPhong c JOIN Phong p ON c.SoPhong=p.SoPhong WHERE c.SoPhieuDat=@p0",id); }
        public DataTable Guests(string id) { return Db.Query("SELECT * FROM NguoiLuuTru WHERE SoPhieuDat=@p0",id); }
        internal static void RefreshRooms(SqlConnection c,SqlTransaction t)
        {
            Db.Execute(c,t,@"UPDATE p SET TrangThai=CASE
WHEN EXISTS(SELECT 1 FROM ChiTietDatPhong x JOIN PhieuDatPhong d ON x.SoPhieuDat=d.SoPhieuDat WHERE x.SoPhong=p.SoPhong AND d.TrangThai=N'Đang ở') THEN N'Đang ở'
WHEN EXISTS(SELECT 1 FROM ChiTietDatPhong x JOIN PhieuDatPhong d ON x.SoPhieuDat=d.SoPhieuDat WHERE x.SoPhong=p.SoPhong AND d.TrangThai=N'Đã đặt') THEN N'Đã đặt'
ELSE N'Trống' END FROM Phong p WHERE p.TrangThai<>N'Bảo trì'");
        }
        public void Book(string id,string customer,string staff,DateTime arrival,DateTime departure,decimal deposit,string channel,List<PhongDatItem> rooms)
        {
            Db.Required(id,customer,staff,channel);
            Db.Require(departure.Date>=arrival.Date,"Ngày trả không được trước ngày nhận.");
            Db.Require(deposit>=0 && rooms.Count>0,"Tiền cọc không âm và phải chọn ít nhất một phòng.");
            Db.Tx((c,t)=> {
                var seen=new HashSet<string>();
                foreach(var r in rooms) {
                    Db.Require(seen.Add(r.SoPhong),"Phòng bị chọn trùng.");
                    var max=Db.Scalar(c,t,"SELECT SoNguoiToiDa FROM Phong WHERE SoPhong=@p0 AND TrangThai<>N'Bảo trì'",r.SoPhong);
                    Db.Require(max!=null,"Phòng không tồn tại hoặc đang bảo trì.");
                    Db.Require(r.SoNguoi>0 && r.SoNguoi<=Convert.ToInt32(max),"Số người vượt sức chứa phòng "+r.SoPhong);
                    int count=Convert.ToInt32(Db.Scalar(c,t,@"SELECT COUNT(*) FROM ChiTietDatPhong x JOIN PhieuDatPhong d ON x.SoPhieuDat=d.SoPhieuDat
WHERE x.SoPhong=@p0 AND d.TrangThai IN(N'Đã đặt',N'Đang ở') AND @p1<=d.NgayTraDuKien AND @p2>=d.NgayNhan",r.SoPhong,arrival.Date,departure.Date));
                    Db.Require(count==0,"Phòng "+r.SoPhong+" bị trùng lịch.");
                }
                Db.Execute(c,t,@"INSERT PhieuDatPhong(SoPhieuDat,MaKhach,MaNVLeTan,NgayLap,NgayNhan,NgayTraDuKien,TienCoc,KenhDat)
VALUES(@p0,@p1,@p2,GETDATE(),@p3,@p4,@p5,@p6)",id,customer,staff,arrival.Date,departure.Date,deposit,channel);
                foreach(var r in rooms) Db.Execute(c,t,"INSERT ChiTietDatPhong VALUES(@p0,@p1,@p2)",id,r.SoPhong,r.SoNguoi);
                RefreshRooms(c,t);
            });
        }
        public void AddGuest(string id,string room,string name,string citizen,string nationality)
        {
            Db.Required(id,room,name,citizen,nationality);
            Db.Tx((c,t)=> {
                var state=Convert.ToString(Db.Scalar(c,t,"SELECT TrangThai FROM PhieuDatPhong WHERE SoPhieuDat=@p0",id));
                Db.Require(state=="Đã đặt"||state=="Đang ở","Phiếu không còn được thêm người.");
                int max=Convert.ToInt32(Db.Scalar(c,t,"SELECT SoNguoi FROM ChiTietDatPhong WHERE SoPhieuDat=@p0 AND SoPhong=@p1",id,room));
                int count=Convert.ToInt32(Db.Scalar(c,t,"SELECT COUNT(*) FROM NguoiLuuTru WHERE SoPhieuDat=@p0 AND SoPhong=@p1",id,room));
                Db.Require(count<max,"Đã đủ số người đăng ký hoặc phòng không thuộc phiếu.");
                Db.Execute(c,t,"INSERT NguoiLuuTru(SoPhieuDat,SoPhong,HoTen,SoCMND,QuocTich) VALUES(@p0,@p1,@p2,@p3,@p4)",id,room,name,citizen,nationality);
            });
        }
        public void CheckIn(string id)
        {
            Db.Required(id);
            Db.Tx((c,t)=> {
                int ok=Convert.ToInt32(Db.Scalar(c,t,@"SELECT COUNT(*) FROM PhieuDatPhong WHERE SoPhieuDat=@p0 AND TrangThai=N'Đã đặt'
AND CAST(GETDATE() AS date) BETWEEN NgayNhan AND NgayTraDuKien",id));
                Db.Require(ok==1,"Chỉ nhận phòng cho phiếu Đã đặt trong khoảng ngày đặt.");
                int busy=Convert.ToInt32(Db.Scalar(c,t,@"SELECT COUNT(*) FROM ChiTietDatPhong x JOIN Phong p ON x.SoPhong=p.SoPhong
WHERE x.SoPhieuDat=@p0 AND (p.TrangThai=N'Bảo trì' OR EXISTS(SELECT 1 FROM ChiTietDatPhong y JOIN PhieuDatPhong d ON y.SoPhieuDat=d.SoPhieuDat WHERE y.SoPhong=x.SoPhong AND d.TrangThai=N'Đang ở'))",id));
                Db.Require(busy==0,"Phòng còn khách đang ở hoặc đang bảo trì.");
                int missing=Convert.ToInt32(Db.Scalar(c,t,@"SELECT COUNT(*) FROM ChiTietDatPhong x WHERE x.SoPhieuDat=@p0 AND
(SELECT COUNT(*) FROM NguoiLuuTru n WHERE n.SoPhieuDat=x.SoPhieuDat AND n.SoPhong=x.SoPhong)<>x.SoNguoi",id));
                Db.Require(missing==0,"Hãy nhập đủ thông tin người lưu trú cho từng phòng.");
                Db.Execute(c,t,"UPDATE PhieuDatPhong SET TrangThai=N'Đang ở',NgayNhanThucTe=GETDATE() WHERE SoPhieuDat=@p0",id);
                RefreshRooms(c,t);
            });
        }
        public void NoShow(string id)
        {
            Db.Required(id);
            Db.Tx((c,t)=> {
                Db.Require(Db.Execute(c,t,"UPDATE PhieuDatPhong SET TrangThai=N'No-show' WHERE SoPhieuDat=@p0 AND TrangThai=N'Đã đặt'",id)==1,"Chỉ đánh dấu No-show cho phiếu Đã đặt.");
                RefreshRooms(c,t);
            });
        }
    }
}
