using System;
using System.Data;
using QuanLyKhachSan.Data;
namespace QuanLyKhachSan.Services
{
    public class DanhMucService
    {
        // Tên bảng chỉ lấy từ danh sách cố định trong chương trình.
        public DataTable List(string table)
        {
            switch(table) {
                case "KhuVuc": case "NhanVien": case "LoaiTienNghi": case "DichVu":
                case "QuyDinhDenBu": case "Phong": case "TienNghi": case "KhachHang":
                    return Db.Query("SELECT * FROM " + table);
                default: throw new ArgumentException("Danh mục không hợp lệ.");
            }
        }
        public void Add(string table, params object[] v)
        {
            foreach(var x in v) if(x is string) Db.Required((string)x);
            string sql;
            switch(table) {
                case "KhuVuc": sql="INSERT KhuVuc VALUES(@p0,@p1)"; break;
                case "NhanVien": sql="INSERT NhanVien VALUES(@p0,@p1,@p2,@p3)"; break;
                case "LoaiTienNghi": sql="INSERT LoaiTienNghi VALUES(@p0,@p1)"; break;
                case "DichVu": sql="INSERT DichVu VALUES(@p0,@p1,@p2,@p3)"; break;
                case "QuyDinhDenBu": sql="INSERT QuyDinhDenBu VALUES(@p0,@p1,@p2,@p3)"; break;
                case "Phong": sql="INSERT Phong(SoPhong,MaKhuVuc,SoNguoiToiDa,DonGiaNgay) VALUES(@p0,@p1,@p2,@p3)"; break;
                case "TienNghi": sql="INSERT TienNghi VALUES(@p0,@p1,@p2,@p3)"; break;
                case "KhachHang": sql="INSERT KhachHang VALUES(@p0,@p1,@p2,@p3,@p4)"; break;
                default: throw new ArgumentException("Danh mục không hợp lệ.");
            }
            Db.Tx((c,t)=>Db.Execute(c,t,sql,v));
        }
    }
}
