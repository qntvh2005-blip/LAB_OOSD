using System;
using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>
    /// Tra cứu lý lịch bệnh án, tiền sử dị ứng và toàn bộ lịch sử điều trị của bệnh nhân.
    /// Bác sĩ có thể nắm bắt phản ứng phụ, hiệu quả thuốc trước đây để đưa ra phác đồ thích hợp.
    /// </summary>
    public class TraCuuService
    {
        public DataTable TimKiemHoSo(string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(tuKhoa))
            {
                return Db.Query(@"SELECT h.MaHoSo, b.MaBN, b.HoTen, b.NgaySinh, b.GioiTinh, b.DiaChi, b.DienThoai,
                                         h.NgayLap, h.TienSuDiUng, h.TrangThai
                                  FROM HoSoBenhAn h
                                  JOIN BenhNhan b ON h.MaBN = b.MaBN
                                  ORDER BY h.MaHoSo");
            }

            string sql = @"SELECT h.MaHoSo, b.MaBN, b.HoTen, b.NgaySinh, b.GioiTinh, b.DiaChi, b.DienThoai,
                                  h.NgayLap, h.TienSuDiUng, h.TrangThai
                           FROM HoSoBenhAn h
                           JOIN BenhNhan b ON h.MaBN = b.MaBN
                           WHERE h.MaHoSo LIKE @kw OR b.MaBN LIKE @kw OR b.HoTen LIKE @kw OR b.DienThoai LIKE @kw
                           ORDER BY h.MaHoSo";

            return Db.Query(sql, Db.P("@kw", "%" + tuKhoa.Trim() + "%"));
        }

        public DataTable LayLichSuKhamBenh(string maHoSo)
        {
            return Db.Query(@"SELECT p.MaPhieuKham, p.NgayGioKham, p.LoaiKham, k.TenKhoa, s.HoTen AS TenBacSi,
                                     p.TrieuChung, p.ThanNhiet, p.HuyetAp, p.ChanDoan,
                                     p.PhanUngPhuThuoc, p.HieuQuaDieuTri, p.TrangThai
                              FROM PhieuKhamBenh p
                              JOIN KhoaDieuTri k ON p.MaKhoa = k.MaKhoa
                              JOIN BacSi s ON p.MaBacSi = s.MaBacSi
                              WHERE p.MaHoSo = @h
                              ORDER BY p.NgayGioKham DESC", Db.P("@h", maHoSo));
        }

        public DataTable LayChiTietXetNghiem(string maPK)
        {
            return Db.Query(@"SELECT x.MaPhieuXN, l.TenLoaiXN, x.KetQua, l.ChiSoBinhThuong, x.TrangThai
                              FROM PhieuXetNghiem x
                              JOIN LoaiXetNghiem l ON x.MaLoaiXN = l.MaLoaiXN
                              WHERE x.MaPhieuKham = @pk", Db.P("@pk", maPK));
        }

        public DataTable LayChiTietToaThuoc(string maPK)
        {
            return Db.Query(@"SELECT t.TenThuoc, t.DonViTinh, c.SoLuong, c.LieuDung, c.CachDung
                              FROM ToaThuoc toa
                              JOIN ChiTietToaThuoc c ON toa.MaToa = c.MaToa
                              JOIN Thuoc t ON c.MaThuoc = t.MaThuoc
                              WHERE toa.MaPhieuKham = @pk", Db.P("@pk", maPK));
        }
    }
}
