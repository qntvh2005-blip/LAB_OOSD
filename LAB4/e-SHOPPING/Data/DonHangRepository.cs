using System;
using System.Data;
using System.Data.SqlClient;
using e_SHOPPING.Models;

namespace e_SHOPPING.Data
{
    public class DonHangRepository
    {
        public CauHinh LayCauHinh()
        {
            var x=new CauHinh();
            using(var c=Db.Open()) using(var cmd=Db.Command(c,"SELECT * FROM dbo.KhuVuc; SELECT * FROM dbo.LoaiGiaoHang; SELECT * FROM dbo.BieuPhiGiaoHang; SELECT * FROM dbo.LoaiThe;"))
            using(var r=cmd.ExecuteReader())
            {
                while(r.Read())x.KhuVuc.Add(new KhuVuc{MaKhuVuc=(string)r["MaKhuVuc"],TenKhuVuc=(string)r["TenKhuVuc"]});
                r.NextResult();while(r.Read())x.GiaoHang.Add(new LoaiGiaoHang{MaLoaiGiaoHang=(string)r["MaLoaiGiaoHang"],TenLoai=(string)r["TenLoai"],ThoiGianXuLyGio=(int)r["ThoiGianXuLyGio"]});
                r.NextResult();while(r.Read())x.BieuPhi.Add(new BieuPhiGiaoHang{MaKhuVuc=(string)r["MaKhuVuc"],MaLoaiGiaoHang=(string)r["MaLoaiGiaoHang"],PhiCoBan=(decimal)r["PhiCoBan"]});
                r.NextResult();while(r.Read())x.The.Add(new LoaiThe{MaLoaiThe=(string)r["MaLoaiThe"],TenLoai=(string)r["TenLoai"],SoChuSo=(int)r["SoChuSo"],DoDaiCSV=(int)r["DoDaiCSV"],LePhiSuDung=(decimal)r["LePhiSuDung"]});
            }
            return x;
        }
        public DonHang TimTheoYeuCau(Guid ma)
        {
            using(var c=Db.Open()) using(var cmd=Db.Command(c,"SELECT * FROM dbo.DonHang WHERE MaYeuCau=@ma"))
            {
                Db.Param(cmd,"@ma",SqlDbType.UniqueIdentifier,ma);
                using(var r=cmd.ExecuteReader())
                {
                    if(!r.Read())return null;
                    return new DonHang {MaDonHang=(string)r["MaDonHang"],MaYeuCau=(Guid)r["MaYeuCau"],MaKhachHang=(string)r["MaKhachHang"],
                        TongThanhToan=(decimal)r["TongThanhToan"],ThoiDiemDat=(DateTime)r["ThoiDiemDat"]};
                }
            }
        }
        public DonHang LuuDonHang(DonHang d)
        {
            if(d.ChiTiet.Count==0 || d.XacNhan==null || !d.XacNhan.DaChapNhan()) throw new InvalidOperationException("Đơn cần chi tiết và xác minh được chấp nhận.");
            using(var c=Db.Open()) using(var tx=c.BeginTransaction())
            {
                try
                {
                    using(var cmd=Db.Command(c,"INSERT dbo.DonHang VALUES(@id,@yc,@kh,@kv,@gh,@tg,@ten,@dc,@dt,@hang,@phi,@lephi,@tong)",tx))
                    {
                        Db.Param(cmd,"@id",SqlDbType.VarChar,d.MaDonHang,40);Db.Param(cmd,"@yc",SqlDbType.UniqueIdentifier,d.MaYeuCau);
                        Db.Param(cmd,"@kh",SqlDbType.VarChar,d.MaKhachHang,40);Db.Param(cmd,"@kv",SqlDbType.VarChar,d.MaKhuVuc,10);Db.Param(cmd,"@gh",SqlDbType.VarChar,d.MaLoaiGiaoHang,10);
                        Db.Param(cmd,"@tg",SqlDbType.DateTime2,d.ThoiDiemDat);Db.Param(cmd,"@ten",SqlDbType.NVarChar,d.HoTenNguoiNhan,100);
                        Db.Param(cmd,"@dc",SqlDbType.NVarChar,d.DiaChiNguoiNhan,250);Db.Param(cmd,"@dt",SqlDbType.VarChar,d.DienThoaiNguoiNhan,20);
                        Db.Money(cmd,"@hang",d.TienHang);Db.Money(cmd,"@phi",d.PhiGiaoHang);Db.Money(cmd,"@lephi",d.LePhiThe);Db.Money(cmd,"@tong",d.TongThanhToan);
                        cmd.ExecuteNonQuery();
                    }
                    foreach(var item in d.ChiTiet)using(var cmd=Db.Command(c,"INSERT dbo.ChiTietDonHang VALUES(@id,@sp,@ten,@sl,@gia)",tx))
                    {
                        Db.Param(cmd,"@id",SqlDbType.VarChar,d.MaDonHang,40);Db.Param(cmd,"@sp",SqlDbType.VarChar,item.MaSanPham,40);
                        Db.Param(cmd,"@ten",SqlDbType.NVarChar,item.TenSanPhamLucDat,200);Db.Param(cmd,"@sl",SqlDbType.Int,item.SoLuong);Db.Money(cmd,"@gia",item.DonGiaLucDat);cmd.ExecuteNonQuery();
                    }
                    var v=d.XacNhan;
                    using(var cmd=Db.Command(c,"INSERT dbo.XacNhanThanhToan VALUES(@id,@don,@loai,@ref,@cuoi,@tt,@tg)",tx))
                    {
                        Db.Param(cmd,"@id",SqlDbType.VarChar,v.MaXacNhan,40);Db.Param(cmd,"@don",SqlDbType.VarChar,d.MaDonHang,40);
                        Db.Param(cmd,"@loai",SqlDbType.VarChar,v.MaLoaiThe,10);Db.Param(cmd,"@ref",SqlDbType.VarChar,v.MaThamChieu,80);
                        Db.Param(cmd,"@cuoi",SqlDbType.Char,v.BonSoCuoi,4);Db.Param(cmd,"@tt",SqlDbType.VarChar,v.TrangThai,20);Db.Param(cmd,"@tg",SqlDbType.DateTime2,v.ThoiDiemXacMinh);cmd.ExecuteNonQuery();
                    }
                    tx.Commit();return d;
                }
                catch(SqlException ex)
                {
                    tx.Rollback();
                    if(ex.Number==2601 || ex.Number==2627)
                    {
                        var existing=TimTheoYeuCau(d.MaYeuCau);
                        if(existing!=null && existing.MaKhachHang==d.MaKhachHang)return existing;
                    }
                    throw;
                }
                catch {tx.Rollback();throw;}
            }
        }
    }
}
