using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Dịch vụ quản lý các danh mục nền tảng: Tầng, Phòng văn phòng, Dịch vụ tòa nhà và Khách hàng.
    /// </summary>
    public class DanhMucService
    {
        public DataTable LayDanhSachTang()
        {
            return Db.Query("SELECT MaTang, TenTang, DoCaoTang, HeSoGia, GhiChu FROM dbo.Tang ORDER BY DoCaoTang");
        }

        public DataTable LayDanhSachPhong(string maTang = null, string trangThai = null)
        {
            string sql = @"SELECT p.MaPhong, p.MaTang, t.TenTang, p.TenPhong, p.DienTich, p.Huong, 
                                  p.DonGiaCoBan, CAST((p.DienTich * p.DonGiaCoBan * t.HeSoGia) AS decimal(18,2)) AS GiaThueThang, p.TrangThai
                           FROM dbo.Phong p
                           JOIN dbo.Tang t ON p.MaTang = t.MaTang
                           WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(maTang))
                sql += " AND p.MaTang = '" + maTang.Trim().Replace("'", "''") + "'";
            if (!string.IsNullOrWhiteSpace(trangThai))
                sql += " AND p.TrangThai = N'" + trangThai.Trim().Replace("'", "''") + "'";

            sql += " ORDER BY t.DoCaoTang, p.MaPhong";
            return Db.Query(sql);
        }

        public DataTable LayDanhSachPhongTrong()
        {
            return LayDanhSachPhong(null, QuyDinhCaoOc.PhongTrong);
        }

        public DataTable LayDanhSachDichVu()
        {
            return Db.Query("SELECT MaDV, TenDV, DonViTinh, DonGia, LoaiDV FROM dbo.DichVu ORDER BY MaDV");
        }

        public DataTable LayDanhSachKhachHang()
        {
            return Db.Query("SELECT MaKH, TenCongTy, NguoiDaiDien, MaSoThue, DienThoai, Email, DiaChiTruSo FROM dbo.KhachHang ORDER BY MaKH");
        }

        public KetQuaXuLy ThemTang(string maTang, string tenTang, int doCao, decimal heSoGia, string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(maTang) || string.IsNullOrWhiteSpace(tenTang))
                return KetQuaXuLy.Fail("Mã tầng và tên tầng không được để trống.");
            if (doCao <= 0 || heSoGia <= 0)
                return KetQuaXuLy.Fail("Độ cao tầng và hệ số giá phải lớn hơn 0.");

            try
            {
                Db.Execute("INSERT INTO dbo.Tang(MaTang, TenTang, DoCaoTang, HeSoGia, GhiChu) VALUES(@m, @t, @dc, @hs, @gc)",
                    Db.P("@m", maTang), Db.P("@t", tenTang), Db.P("@dc", doCao), Db.P("@hs", heSoGia), Db.P("@gc", ghiChu));
                return KetQuaXuLy.Ok("Thêm tầng thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi: " + ex.Message);
            }
        }

        public KetQuaXuLy ThemPhong(string maPhong, string maTang, string tenPhong, decimal dienTich, string huong, decimal donGiaCoBan)
        {
            if (string.IsNullOrWhiteSpace(maPhong) || string.IsNullOrWhiteSpace(maTang) || string.IsNullOrWhiteSpace(tenPhong))
                return KetQuaXuLy.Fail("Thông tin phòng không được để trống.");
            if (dienTich <= 0 || donGiaCoBan <= 0)
                return KetQuaXuLy.Fail("Diện tích và đơn giá phòng phải lớn hơn 0.");

            try
            {
                Db.Execute(@"INSERT INTO dbo.Phong(MaPhong, MaTang, TenPhong, DienTich, Huong, DonGiaCoBan, TrangThai)
                             VALUES(@p, @t, @ten, @dt, @h, @gia, N'Trống')",
                             Db.P("@p", maPhong), Db.P("@t", maTang), Db.P("@ten", tenPhong),
                             Db.P("@dt", dienTich), Db.P("@h", huong), Db.P("@gia", donGiaCoBan));
                return KetQuaXuLy.Ok("Thêm phòng văn phòng thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi: " + ex.Message);
            }
        }

        public KetQuaXuLy ThemDichVu(string maDV, string tenDV, string dvt, decimal donGia, string loaiDV)
        {
            if (string.IsNullOrWhiteSpace(maDV) || string.IsNullOrWhiteSpace(tenDV))
                return KetQuaXuLy.Fail("Mã và tên dịch vụ không được để trống.");

            try
            {
                Db.Execute(@"INSERT INTO dbo.DichVu(MaDV, TenDV, DonViTinh, DonGia, LoaiDV)
                             VALUES(@m, @t, @dvt, @gia, @l)",
                             Db.P("@m", maDV), Db.P("@t", tenDV), Db.P("@dvt", dvt),
                             Db.P("@gia", donGia), Db.P("@l", loaiDV));
                return KetQuaXuLy.Ok("Thêm dịch vụ thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi: " + ex.Message);
            }
        }

        public KetQuaXuLy ThemKhachHang(string maKH, string tenCongTy, string nguoiDaiDien, string mst, string sdt, string email, string diaChi)
        {
            if (string.IsNullOrWhiteSpace(maKH) || string.IsNullOrWhiteSpace(tenCongTy) || string.IsNullOrWhiteSpace(sdt))
                return KetQuaXuLy.Fail("Mã khách hàng, tên công ty và số điện thoại không được để trống.");

            try
            {
                Db.Execute(@"INSERT INTO dbo.KhachHang(MaKH, TenCongTy, NguoiDaiDien, MaSoThue, DienThoai, Email, DiaChiTruSo)
                             VALUES(@m, @ten, @dd, @mst, @dt, @em, @dc)",
                             Db.P("@m", maKH), Db.P("@ten", tenCongTy), Db.P("@dd", nguoiDaiDien),
                             Db.P("@mst", mst), Db.P("@dt", sdt), Db.P("@em", email), Db.P("@dc", diaChi));
                return KetQuaXuLy.Ok("Thêm thông tin khách hàng/công ty thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi: " + ex.Message);
            }
        }
    }
}
