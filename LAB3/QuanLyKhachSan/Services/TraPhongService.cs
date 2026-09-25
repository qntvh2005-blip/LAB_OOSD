using System;
using System.Data;
using System.Collections.Generic;
using QuanLyKhachSan.Data;
namespace QuanLyKhachSan.Services
{
    public class DenBuItem
    { public string MaTienNghi {get;set;} public string MucDoThietHai {get;set;} public decimal SoTien {get;set;} }
    public class TraPhongService
    {
        public DataTable Stays() { return Db.Query("SELECT SoPhieuDat FROM PhieuDatPhong WHERE TrangThai=N'Đang ở'"); }
        public DataTable Equipment(string room) { return Db.Query(@"WITH x AS(SELECT p.*,ROW_NUMBER() OVER(PARTITION BY MaTienNghi ORDER BY NgayLap DESC) AS rn
FROM PhieuLapDat p WHERE NgayLap<=CAST(GETDATE() AS date))
SELECT x.MaTienNghi,t.MaLoaiTN,l.TenLoaiTN,t.TinhTrangHienTai FROM x JOIN TienNghi t ON x.MaTienNghi=t.MaTienNghi
JOIN LoaiTienNghi l ON t.MaLoaiTN=l.MaLoaiTN WHERE x.rn=1 AND x.SoPhong=@p0",room); }
        public DataTable Rules(string type) { return Db.Query("SELECT * FROM QuyDinhDenBu WHERE MaLoaiTN=@p0",type); }
        public DataTable Damages(string id) { return Db.Query(@"SELECT p.SoPhieuDenBu,p.SoPhong,c.MaTienNghi,c.MucDoThietHai,c.SoTien FROM PhieuDenBu p
JOIN ChiTietPhieuDenBu c ON p.SoPhieuDenBu=c.SoPhieuDenBu WHERE p.SoPhieuDat=@p0",id); }
        public DataTable Invoices(string id) { return Db.Query(@"SELECT h.*,ISNULL((SELECT SUM(t.SoTien) FROM ThanhToan t WHERE t.SoHoaDon=h.SoHoaDon),0) AS DaThanhToan,
h.TongTien-ISNULL((SELECT SUM(t.SoTien) FROM ThanhToan t WHERE t.SoHoaDon=h.SoHoaDon),0) AS ConLai
FROM HoaDon h WHERE SoPhieuDat=@p0",id); }
        public DataTable Payments(string invoice) { return Db.Query("SELECT * FROM ThanhToan WHERE SoHoaDon=@p0 ORDER BY NgayThanhToan",invoice); }
        public void Damage(string slip,string stay,string room,string staff,List<DenBuItem> items)
        {
            Db.Required(slip,stay,room,staff); Db.Require(items.Count>0,"Chưa chọn tiện nghi đền bù.");
            Db.Tx((c,t)=> {
                Db.Require(Convert.ToString(Db.Scalar(c,t,"SELECT TrangThai FROM PhieuDatPhong WHERE SoPhieuDat=@p0",stay))=="Đang ở","Phiếu phải Đang ở.");
                decimal total=0; var seen=new HashSet<string>();
                foreach(var x in items) {
                    Db.Require(seen.Add(x.MaTienNghi),"Tiện nghi bị chọn trùng.");
                    Db.Require(Convert.ToString(Db.Scalar(c,t,"SELECT TOP 1 SoPhong FROM PhieuLapDat WHERE MaTienNghi=@p0 AND NgayLap<=CAST(GETDATE() AS date) ORDER BY NgayLap DESC",x.MaTienNghi))==room,"Tiện nghi không hiện ở phòng đã chọn.");
                    var amount=Db.Scalar(c,t,@"SELECT q.MucDenBu FROM QuyDinhDenBu q JOIN TienNghi tn ON q.MaLoaiTN=tn.MaLoaiTN
WHERE tn.MaTienNghi=@p0 AND q.MucDoThietHai=@p1",x.MaTienNghi,x.MucDoThietHai);
                    Db.Require(amount!=null && Convert.ToDecimal(amount)==x.SoTien,"Mức tiền phải khớp quy định đền bù.");
                    Db.Require(Convert.ToInt32(Db.Scalar(c,t,@"SELECT COUNT(*) FROM PhieuDenBu p JOIN ChiTietPhieuDenBu d ON p.SoPhieuDenBu=d.SoPhieuDenBu
WHERE p.SoPhieuDat=@p0 AND d.MaTienNghi=@p1",stay,x.MaTienNghi))==0,"Thiết bị đã được lập đền bù trong lượt này.");
                    total+=x.SoTien;
                }
                Db.Execute(c,t,"INSERT PhieuDenBu VALUES(@p0,@p1,@p2,GETDATE(),@p3,@p4)",slip,stay,room,staff,total);
                foreach(var x in items) {
                    Db.Execute(c,t,"INSERT ChiTietPhieuDenBu VALUES(@p0,@p1,@p2,@p3)",slip,x.MaTienNghi,x.MucDoThietHai,x.SoTien);
                    Db.Execute(c,t,"UPDATE TienNghi SET TinhTrangHienTai=@p1 WHERE MaTienNghi=@p0",x.MaTienNghi,x.MucDoThietHai);
                }
            });
        }
        public void Invoice(string invoice,string stay,string staff,int days)
        {
            Db.Required(invoice,stay,staff); Db.Require(days>0,"Số ngày tính tiền phải lớn hơn 0.");
            Db.Tx((c,t)=> {
                Db.Require(Convert.ToString(Db.Scalar(c,t,"SELECT TrangThai FROM PhieuDatPhong WHERE SoPhieuDat=@p0",stay))=="Đang ở","Chỉ lập hóa đơn cho phiếu Đang ở.");
                decimal room=Convert.ToDecimal(Db.Scalar(c,t,@"SELECT ISNULL(SUM(p.DonGiaNgay),0) FROM ChiTietDatPhong d JOIN Phong p ON d.SoPhong=p.SoPhong WHERE d.SoPhieuDat=@p0",stay))*days;
                decimal service=Convert.ToDecimal(Db.Scalar(c,t,@"SELECT ISNULL(SUM(d.ThanhTien),0) FROM PhieuSuDungDV p JOIN ChiTietPhieuSuDungDV d ON p.SoPhieuSDDV=d.SoPhieuSDDV WHERE p.SoPhieuDat=@p0",stay));
                Db.Execute(c,t,@"INSERT HoaDon(SoHoaDon,SoPhieuDat,NgayLap,MaNV,SoNgayTinhTien,TienPhong,TienDichVu,TrangThai)
VALUES(@p0,@p1,GETDATE(),@p2,@p3,@p4,@p5,@p6)",invoice,stay,staff,days,room,service,room+service==0?"Đã thanh toán":"Chưa thanh toán");
            });
        }
        public void Pay(string payment,string invoice,string method,decimal amount)
        {
            Db.Required(payment,invoice,method); Db.Require(amount>0,"Số tiền phải lớn hơn 0.");
            Db.Tx((c,t)=> {
                var total=Db.Scalar(c,t,"SELECT TongTien FROM HoaDon WHERE SoHoaDon=@p0",invoice);
                Db.Require(total!=null,"Chưa chọn hóa đơn.");
                decimal paid=Convert.ToDecimal(Db.Scalar(c,t,"SELECT ISNULL(SUM(SoTien),0) FROM ThanhToan WHERE SoHoaDon=@p0",invoice));
                Db.Require(paid+amount<=Convert.ToDecimal(total),"Số tiền vượt phần còn phải thanh toán.");
                Db.Execute(c,t,"INSERT ThanhToan VALUES(@p0,@p1,GETDATE(),@p2,@p3)",payment,invoice,method,amount);
                Db.Execute(c,t,"UPDATE HoaDon SET TrangThai=@p1 WHERE SoHoaDon=@p0",invoice,paid+amount==Convert.ToDecimal(total)?"Đã thanh toán":"Chưa thanh toán");
            });
        }
        public void CheckOut(string stay)
        {
            Db.Required(stay);
            Db.Tx((c,t)=> {
                Db.Require(Convert.ToString(Db.Scalar(c,t,"SELECT TrangThai FROM PhieuDatPhong WHERE SoPhieuDat=@p0",stay))=="Đang ở","Phiếu không Đang ở.");
                Db.Require(Convert.ToInt32(Db.Scalar(c,t,@"SELECT COUNT(*) FROM HoaDon h WHERE SoPhieuDat=@p0 AND h.TongTien=
ISNULL((SELECT SUM(t.SoTien) FROM ThanhToan t WHERE t.SoHoaDon=h.SoHoaDon),0)",stay))==1,"Cần lập hóa đơn và thanh toán đủ trước khi trả phòng.");
                Db.Execute(c,t,"UPDATE PhieuDatPhong SET TrangThai=N'Đã trả',NgayTraThucTe=GETDATE() WHERE SoPhieuDat=@p0",stay);
                DatPhongService.RefreshRooms(c,t);
            });
        }
    }
}
