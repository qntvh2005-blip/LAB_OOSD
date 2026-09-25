using System;
using System.Data;
using QuanLyKhachSan.Data;
namespace QuanLyKhachSan.Services
{
    public class DichVuService
    {
        public DataTable Stays() { return Db.Query(@"SELECT d.SoPhieuDat,c.SoPhong,d.SoPhieuDat+' / '+c.SoPhong AS HienThi
FROM PhieuDatPhong d JOIN ChiTietDatPhong c ON d.SoPhieuDat=c.SoPhieuDat WHERE d.TrangThai=N'Đang ở'"); }
        public DataTable History(string id) { return Db.Query(@"SELECT p.SoPhong,p.NgaySuDung,d.TenDV,c.SoLuong,c.DonGia,c.ThanhTien
FROM PhieuSuDungDV p JOIN ChiTietPhieuSuDungDV c ON p.SoPhieuSDDV=c.SoPhieuSDDV JOIN DichVu d ON c.MaDV=d.MaDV WHERE p.SoPhieuDat=@p0",id); }
        public void Record(string id,string room,DateTime date,string staff,string service,int quantity)
        {
            Db.Required(id,room,staff,service); Db.Require(quantity>0,"Số lượng phải lớn hơn 0.");
            Db.Tx((c,t)=> {
                Db.Require(Convert.ToInt32(Db.Scalar(c,t,@"SELECT COUNT(*) FROM PhieuDatPhong WHERE SoPhieuDat=@p0 AND TrangThai=N'Đang ở'
AND @p1>=CAST(NgayNhanThucTe AS date) AND @p1<=CAST(GETDATE() AS date)",id,date.Date))==1,"Phiếu phải Đang ở; ngày dịch vụ từ ngày nhận thực tế đến hôm nay.");
                Db.Require(Convert.ToInt32(Db.Scalar(c,t,"SELECT COUNT(*) FROM HoaDon WHERE SoPhieuDat=@p0",id))==0,"Đã chốt hóa đơn, không thể thêm dịch vụ.");
                var price=Db.Scalar(c,t,"SELECT DonGia FROM DichVu WHERE MaDV=@p0",service);
                Db.Require(price!=null,"Không tìm thấy dịch vụ.");
                string slip=Convert.ToString(Db.Scalar(c,t,"SELECT SoPhieuSDDV FROM PhieuSuDungDV WHERE SoPhieuDat=@p0 AND SoPhong=@p1 AND NgaySuDung=@p2",id,room,date.Date));
                if(string.IsNullOrEmpty(slip)) {
                    slip=Db.Id("SD");
                    Db.Execute(c,t,"INSERT PhieuSuDungDV VALUES(@p0,@p1,@p2,@p3,@p4)",slip,id,room,date.Date,staff);
                }
                // Giữ đơn giá lần đầu trong ngày; danh mục mẫu chỉ cho thêm, không đổi giá giữa ngày.
                int n=Db.Execute(c,t,"UPDATE ChiTietPhieuSuDungDV SET SoLuong=SoLuong+@p2 WHERE SoPhieuSDDV=@p0 AND MaDV=@p1",slip,service,quantity);
                if(n==0) Db.Execute(c,t,"INSERT ChiTietPhieuSuDungDV(SoPhieuSDDV,MaDV,SoLuong,DonGia) VALUES(@p0,@p1,@p2,@p3)",slip,service,quantity,price);
            });
        }
    }
}
