using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Xử lý thanh toán tiền thuê từ tháng thứ 7 trở đi (vào đầu mỗi tháng)
    /// và thanh toán chi phí các dịch vụ điện, nước, internet... (vào cuối tháng).
    /// </summary>
    public class ThanhToanService
    {
        public DataTable LayDanhSachHoaDonTienThue(string maHD = null, bool? daThanhToan = null)
        {
            string sql = @"SELECT t.MaHDTT, t.MaHD, k.TenCongTy, t.KyThanhToan, t.Thang, t.Nam,
                                  t.SoTien, t.NgayHenTra, t.NgayThanhToan, t.DaThanhToan, t.GhiChu
                           FROM dbo.HoaDonTienThue t
                           JOIN dbo.HopDongThue h ON t.MaHD = h.MaHD
                           JOIN dbo.KhachHang k ON h.MaKH = k.MaKH
                           WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(maHD))
                sql += " AND t.MaHD = '" + maHD.Trim().Replace("'", "''") + "'";
            if (daThanhToan.HasValue)
                sql += " AND t.DaThanhToan = " + (daThanhToan.Value ? "1" : "0");

            sql += " ORDER BY t.Nam DESC, t.Thang DESC, t.MaHDTT";
            return Db.Query(sql);
        }

        public DataTable LayDanhSachHoaDonDichVu(string maHD = null)
        {
            string sql = @"SELECT v.MaHDDV, v.MaHD, k.TenCongTy, v.MaPhong, v.Thang, v.Nam,
                                  v.NgayLap, v.NgayHenTra, v.TongTien, v.DaThanhToan, v.NgayThanhToan, v.GhiChu
                           FROM dbo.HoaDonDichVu v
                           JOIN dbo.HopDongThue h ON v.MaHD = h.MaHD
                           JOIN dbo.KhachHang k ON h.MaKH = k.MaKH
                           WHERE 1=1";
            if (!string.IsNullOrWhiteSpace(maHD))
                sql += " AND v.MaHD = '" + maHD.Trim().Replace("'", "''") + "'";

            sql += " ORDER BY v.Nam DESC, v.Thang DESC, v.MaHDDV";
            return Db.Query(sql);
        }

        public DataTable LayChiTietDichVu(string maHDDV)
        {
            return Db.Query(@"SELECT c.MaHDDV, c.MaDV, d.TenDV, d.DonViTinh, c.ChiSoDau, c.ChiSoCuoi,
                                     c.SoLuong, c.DonGia, c.ThanhTien
                              FROM dbo.ChiTietHoaDonDichVu c
                              JOIN dbo.DichVu d ON c.MaDV = d.MaDV
                              WHERE c.MaHDDV = @hddv", Db.P("@hddv", maHDDV));
        }

        public KetQuaXuLy ThanhToanTienThue(string maHDTT)
        {
            if (string.IsNullOrWhiteSpace(maHDTT))
                return KetQuaXuLy.Fail("Chưa chọn hóa đơn tiền thuê.");

            try
            {
                Db.ExecuteProc("dbo.sp_ThanhToanTienThue", Db.P("@MaHDTT", maHDTT));
                return KetQuaXuLy.Ok("Thanh toán tiền thuê thành công!");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }

        public KetQuaXuLy ThanhToanDichVu(string maHDDV)
        {
            if (string.IsNullOrWhiteSpace(maHDDV))
                return KetQuaXuLy.Fail("Chưa chọn hóa đơn dịch vụ.");

            try
            {
                Db.ExecuteProc("dbo.sp_ThanhToanDichVu", Db.P("@MaHDDV", maHDDV));
                return KetQuaXuLy.Ok("Thanh toán hóa đơn dịch vụ thành công!");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }

        public KetQuaXuLy LapHoaDonDichVuCuoiThang(string maHDDV, string maHD, string maPhong,
            int thang, int nam, List<ChiTietDichVuItem> dsChiTiet)
        {
            if (string.IsNullOrWhiteSpace(maHDDV) || string.IsNullOrWhiteSpace(maHD) || string.IsNullOrWhiteSpace(maPhong))
                return KetQuaXuLy.Fail("Thông tin hóa đơn dịch vụ không được để trống.");

            if (dsChiTiet == null || dsChiTiet.Count == 0)
                return KetQuaXuLy.Fail("Hóa đơn phải có ít nhất một khoản dịch vụ.");

            // Ngày hẹn trả là ngày cuối cùng của tháng
            int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);
            DateTime ngayCuoiThang = new DateTime(nam, thang, soNgayTrongThang);

            decimal tongTien = 0;
            foreach (var item in dsChiTiet)
            {
                if (item.SoLuong <= 0)
                    return KetQuaXuLy.Fail("Số lượng tiêu thụ của dịch vụ " + item.TenDV + " phải lớn hơn 0.");
                tongTien += item.ThanhTien;
            }

            using (var cn = Db.OpenConnection())
            using (var tr = cn.BeginTransaction())
            {
                try
                {
                    // 1. Thêm hóa đơn dịch vụ
                    using (var cmd = new SqlCommand(@"INSERT INTO dbo.HoaDonDichVu(MaHDDV, MaHD, MaPhong, Thang, Nam, NgayLap, NgayHenTra, TongTien, DaThanhToan, GhiChu)
                                                     VALUES(@hddv, @hd, @p, @th, @n, SYSDATETIME(), @hen, @tong, 0, N'Hóa đơn dịch vụ cuối tháng')", cn, tr))
                    {
                        cmd.Parameters.Add(Db.P("@hddv", maHDDV));
                        cmd.Parameters.Add(Db.P("@hd", maHD));
                        cmd.Parameters.Add(Db.P("@p", maPhong));
                        cmd.Parameters.Add(Db.P("@th", thang));
                        cmd.Parameters.Add(Db.P("@n", nam));
                        cmd.Parameters.Add(Db.P("@hen", ngayCuoiThang));
                        cmd.Parameters.Add(Db.P("@tong", tongTien));
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Thêm từng chi tiết dịch vụ
                    foreach (var item in dsChiTiet)
                    {
                        using (var cmd = new SqlCommand(@"INSERT INTO dbo.ChiTietHoaDonDichVu(MaHDDV, MaDV, ChiSoDau, ChiSoCuoi, SoLuong, DonGia)
                                                         VALUES(@hddv, @dv, @dau, @cuoi, @sl, @gia)", cn, tr))
                        {
                            cmd.Parameters.Add(Db.P("@hddv", maHDDV));
                            cmd.Parameters.Add(Db.P("@dv", item.MaDV));
                            cmd.Parameters.Add(Db.P("@dau", item.ChiSoDau.HasValue ? (object)item.ChiSoDau.Value : DBNull.Value));
                            cmd.Parameters.Add(Db.P("@cuoi", item.ChiSoCuoi.HasValue ? (object)item.ChiSoCuoi.Value : DBNull.Value));
                            cmd.Parameters.Add(Db.P("@sl", item.SoLuong));
                            cmd.Parameters.Add(Db.P("@gia", item.DonGia));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tr.Commit();
                    return KetQuaXuLy.Ok(string.Format("Lập hóa đơn dịch vụ cuối tháng thành công! Tổng tiền: {0:N0} đ. Hạn thanh toán: {1:dd/MM/yyyy}.",
                        tongTien, ngayCuoiThang));
                }
                catch (Exception ex)
                {
                    try { tr.Rollback(); } catch { }
                    return KetQuaXuLy.Fail("Lỗi lập hóa đơn dịch vụ: " + ex.Message);
                }
            }
        }
    }
}
