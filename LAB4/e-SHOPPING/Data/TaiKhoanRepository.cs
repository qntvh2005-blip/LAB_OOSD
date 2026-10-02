using System;
using System.Data;
using e_SHOPPING.Models;

namespace e_SHOPPING.Data
{
    public class TaiKhoanRepository
    {
        public KhachHang LayKhachHang(string ten)
        {
            using(var c=Db.Open()) using(var cmd=Db.Command(c,"SELECT * FROM dbo.KhachHang WHERE TenDangNhap=@ten"))
            {
                Db.Param(cmd,"@ten",SqlDbType.NVarChar,ten,50);
                using(var r=cmd.ExecuteReader())
                {
                    if(!r.Read()) return null;
                    return new KhachHang { MaKhachHang=(string)r["MaKhachHang"],HoTen=(string)r["HoTen"],NgaySinh=(DateTime)r["NgaySinh"],
                        CMNDPassport=(string)r["CMNDPassport"],DiaChi=(string)r["DiaChi"],DienThoai=(string)r["DienThoai"],
                        TenDangNhap=(string)r["TenDangNhap"],MatKhauBam=(string)r["MatKhauBam"],MuoiMatKhau=(string)r["MuoiMatKhau"],
                        Email=r["Email"]==DBNull.Value?null:(string)r["Email"] };
                }
            }
        }
        public void Luu(KhachHang k)
        {
            using(var c=Db.Open()) using(var cmd=Db.Command(c,"INSERT dbo.KhachHang VALUES(@id,@hoten,@ngaysinh,@cmnd,@diachi,@dt,@ten,@hash,@salt,@email)"))
            {
                Db.Param(cmd,"@id",SqlDbType.VarChar,k.MaKhachHang,40); Db.Param(cmd,"@hoten",SqlDbType.NVarChar,k.HoTen,100);
                Db.Param(cmd,"@ngaysinh",SqlDbType.Date,k.NgaySinh); Db.Param(cmd,"@cmnd",SqlDbType.NVarChar,k.CMNDPassport,30);
                Db.Param(cmd,"@diachi",SqlDbType.NVarChar,k.DiaChi,250); Db.Param(cmd,"@dt",SqlDbType.VarChar,k.DienThoai,20);
                Db.Param(cmd,"@ten",SqlDbType.NVarChar,k.TenDangNhap,50); Db.Param(cmd,"@hash",SqlDbType.VarChar,k.MatKhauBam,100);
                Db.Param(cmd,"@salt",SqlDbType.VarChar,k.MuoiMatKhau,100); Db.Param(cmd,"@email",SqlDbType.NVarChar,k.Email,254);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
