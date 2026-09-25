using System;
using System.Data;
using QuanLyKhachSan.Data;
namespace QuanLyKhachSan.Services
{
    public class PhongTienNghiService
    {
        public DataTable History() { return Db.Query("SELECT * FROM PhieuLapDat ORDER BY NgayLap DESC"); }
        public void Install(string id,string device,string room,DateTime date,string state,string staff,string note)
        {
            Db.Required(id,device,room,state,staff);
            Db.Require(date.Date<=DateTime.Today,"Chỉ ghi nhận việc lắp đặt đã thực hiện.");
            Db.Tx((c,t)=> {
                Db.Execute(c,t,"INSERT PhieuLapDat VALUES(@p0,@p1,@p2,@p3,@p4,@p5,@p6)",id,device,room,date.Date,state,staff,note);
                Db.Execute(c,t,@"UPDATE TienNghi SET TinhTrangHienTai=(SELECT TOP 1 TinhTrang FROM PhieuLapDat
WHERE MaTienNghi=@p0 ORDER BY NgayLap DESC) WHERE MaTienNghi=@p0",device);
            });
        }
    }
}
