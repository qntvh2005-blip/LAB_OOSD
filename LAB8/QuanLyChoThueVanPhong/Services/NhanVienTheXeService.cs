using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Quản lý thông tin nhân viên làm việc tại các văn phòng trong tòa nhà (đảm bảo an ninh)
    /// và cấp thẻ giữ xe (ghi rõ thông tin nhân viên và chiếc xe cần gửi).
    /// </summary>
    public class NhanVienTheXeService
    {
        public DataTable LayDanhSachNhanVien(string maKH = null, string maPhong = null)
        {
            string sql = @"SELECT nv.MaNVVP, nv.MaKH, k.TenCongTy, nv.MaPhong, p.TenPhong, t.TenTang,
                                  nv.HoTen, nv.NgaySinh, nv.GioiTinh, nv.CCCD, nv.DienThoai, nv.ChucVu,
                                  nv.HinhAnh, nv.NgayBaoCao, nv.DangLamViec
                           FROM dbo.NhanVienVanPhong nv
                           JOIN dbo.KhachHang k ON nv.MaKH = k.MaKH
                           JOIN dbo.Phong p ON nv.MaPhong = p.MaPhong
                           JOIN dbo.Tang t ON p.MaTang = t.MaTang
                           WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(maKH))
                sql += " AND nv.MaKH = '" + maKH.Trim().Replace("'", "''") + "'";
            if (!string.IsNullOrWhiteSpace(maPhong))
                sql += " AND nv.MaPhong = '" + maPhong.Trim().Replace("'", "''") + "'";

            sql += " ORDER BY nv.NgayBaoCao DESC, nv.MaNVVP DESC";
            return Db.Query(sql);
        }

        public DataTable LayDanhSachTheXe()
        {
            return Db.Query(@"SELECT tx.MaThe, tx.MaNVVP, nv.HoTen AS TenNhanVien, k.TenCongTy,
                                     p.TenPhong, tx.BienSoXe, tx.LoaiXe, tx.NhanHieu, tx.MauXe,
                                     tx.NgayCap, tx.TrangThai, tx.GhiChu
                              FROM dbo.TheGiuXe tx
                              JOIN dbo.NhanVienVanPhong nv ON tx.MaNVVP = nv.MaNVVP
                              JOIN dbo.KhachHang k ON nv.MaKH = k.MaKH
                              JOIN dbo.Phong p ON nv.MaPhong = p.MaPhong
                              ORDER BY tx.NgayCap DESC, tx.MaThe DESC");
        }

        public KetQuaXuLy KhaiBaoNhanVien(string maNV, string maKH, string maPhong, string hoTen,
            DateTime ngaySinh, string gioiTinh, string cccd, string sdt, string chucVu, string hinhAnh)
        {
            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(maKH) ||
                string.IsNullOrWhiteSpace(maPhong) || string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(cccd) || string.IsNullOrWhiteSpace(sdt))
                return KetQuaXuLy.Fail("Thông tin nhân viên văn phòng không được để trống.");

            try
            {
                Db.Execute(@"INSERT INTO dbo.NhanVienVanPhong(MaNVVP, MaKH, MaPhong, HoTen, NgaySinh, GioiTinh, CCCD, DienThoai, ChucVu, HinhAnh, NgayBaoCao, DangLamViec)
                             VALUES(@nv, @kh, @p, @ht, @ns, @gt, @cccd, @dt, @cv, @anh, CAST(SYSDATETIME() AS date), 1)",
                             Db.P("@nv", maNV), Db.P("@kh", maKH), Db.P("@p", maPhong),
                             Db.P("@ht", hoTen), Db.P("@ns", ngaySinh.Date), Db.P("@gt", gioiTinh),
                             Db.P("@cccd", cccd), Db.P("@dt", sdt), Db.P("@cv", chucVu), Db.P("@anh", hinhAnh));

                return KetQuaXuLy.Ok("Báo cáo và tiếp nhận nhân viên văn phòng mới thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi: " + ex.Message);
            }
        }

        public KetQuaXuLy CapTheGiuXe(string maThe, string maNVVP, string bienSo, string loaiXe, string nhanHieu, string mauXe)
        {
            if (string.IsNullOrWhiteSpace(maThe) || string.IsNullOrWhiteSpace(maNVVP) || string.IsNullOrWhiteSpace(bienSo))
                return KetQuaXuLy.Fail("Mã thẻ, nhân viên gửi và biển số xe không được để trống.");

            try
            {
                Db.Execute(@"INSERT INTO dbo.TheGiuXe(MaThe, MaNVVP, BienSoXe, LoaiXe, NhanHieu, MauXe, NgayCap, TrangThai)
                             VALUES(@the, @nv, @bs, @lx, @nh, @m, CAST(SYSDATETIME() AS date), N'Hoạt động')",
                             Db.P("@the", maThe), Db.P("@nv", maNVVP), Db.P("@bs", bienSo),
                             Db.P("@lx", loaiXe), Db.P("@nh", nhanHieu), Db.P("@m", mauXe));

                return KetQuaXuLy.Ok("Cấp thẻ giữ xe cho nhân viên thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi: " + ex.Message);
            }
        }
    }
}
