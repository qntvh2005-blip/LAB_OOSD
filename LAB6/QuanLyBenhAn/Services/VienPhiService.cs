using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>
    /// Xử lý tính toán và thanh toán viện phí, xuất viện.
    /// Phòng Chăm sóc & Theo dõi khách hàng ghi nhận lại diễn biến bệnh, phản ứng phụ của thuốc, hiệu quả điều trị.
    /// </summary>
    public class VienPhiService
    {
        public DataTable LayDanhSachChoThanhToan()
        {
            return Db.Query(@"SELECT p.MaPhieuKham, p.MaHoSo, b.HoTen AS TenBenhNhan, p.LoaiKham,
                                     p.NgayGioKham, k.TenKhoa, s.HoTen AS TenBacSi, p.ChanDoan, p.TienKham,
ISNULL((SELECT SUM(DonGia) FROM PhieuXetNghiem x WHERE x.MaPhieuKham = p.MaPhieuKham AND x.TrangThai<>N'Đã hủy'), 0) AS TienXN,
                                     ISNULL((SELECT TongTienThuoc FROM ToaThuoc t WHERE t.MaPhieuKham = p.MaPhieuKham), 0) AS TienThuoc
                              FROM PhieuKhamBenh p
                              JOIN HoSoBenhAn h ON p.MaHoSo = h.MaHoSo
                              JOIN BenhNhan b ON h.MaBN = b.MaBN
                              JOIN KhoaDieuTri k ON p.MaKhoa = k.MaKhoa
                              JOIN BacSi s ON p.MaBacSi = s.MaBacSi
                              WHERE p.TrangThai <> N'Đã hoàn tất'
                              ORDER BY p.NgayGioKham DESC");
        }

        public DataTable LayLichSuHoaDon()
        {
            return Db.Query(@"SELECT hd.MaHoaDon, hd.MaPhieuKham, b.HoTen AS TenBenhNhan, p.LoaiKham,
                                     hd.NgayThanhToan, hd.TienKham, hd.TienXetNghiem, hd.TienThuoc,
                                     hd.MienPhiDinhKy, hd.TongVienPhi, p.PhanUngPhuThuoc, p.HieuQuaDieuTri
                              FROM HoaDonVienPhi hd
                              JOIN PhieuKhamBenh p ON hd.MaPhieuKham = p.MaPhieuKham
                              JOIN HoSoBenhAn h ON p.MaHoSo = h.MaHoSo
                              JOIN BenhNhan b ON h.MaBN = b.MaBN
                              ORDER BY hd.NgayThanhToan DESC");
        }

        public KetQuaXuLy ThanhToanVaHoanTat(string maHD, string maPK, string phanUngPhu, string hieuQuaDieuTri, string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(maHD) || string.IsNullOrWhiteSpace(maPK))
                return KetQuaXuLy.Fail("Mã hóa đơn và mã phiếu khám không được để trống.");

            try
            {
                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                object trangThai = Db.Scalar(cn,tr,"SELECT TrangThai FROM PhieuKhamBenh WITH(UPDLOCK,HOLDLOCK) WHERE MaPhieuKham=@pk",Db.P("@pk",maPK));
                if (trangThai == null || trangThai.ToString() == QuyDinh.TrangThaiDaHoanTat)
                    return KetQuaXuLy.Fail("Phiếu khám không tồn tại hoặc đã hoàn tất.");
                if (Convert.ToInt32(Db.Scalar(cn,tr,"SELECT COUNT(*) FROM PhieuXetNghiem WHERE MaPhieuKham=@pk AND TrangThai=N'Chờ kết quả'",Db.P("@pk",maPK))) > 0)
                    return KetQuaXuLy.Fail("Chưa có đủ kết quả xét nghiệm để thanh toán và hoàn tất.");
                // Lấy thông tin phiếu khám
                var dtPK = new DataTable();
                using (var cmd = new SqlCommand(@"SELECT p.MaPhieuKham, p.LoaiKham, p.TienKham, p.TrangThai,
ISNULL((SELECT SUM(DonGia) FROM PhieuXetNghiem x WHERE x.MaPhieuKham = p.MaPhieuKham AND x.TrangThai<>N'Đã hủy'), 0) AS TienXN,
                                             ISNULL((SELECT TongTienThuoc FROM ToaThuoc t WHERE t.MaPhieuKham = p.MaPhieuKham), 0) AS TienThuoc
                                      FROM PhieuKhamBenh p
                                      WHERE p.MaPhieuKham = @pk", cn,tr))
                {
                    cmd.Parameters.Add(Db.P("@pk",maPK));
                    using (var da = new SqlDataAdapter(cmd)) da.Fill(dtPK);
                }

                if (dtPK.Rows.Count == 0) return KetQuaXuLy.Fail("Không tìm thấy phiếu khám bệnh.");
                if (dtPK.Rows[0]["TrangThai"].ToString() == QuyDinh.TrangThaiDaHoanTat)
                    return KetQuaXuLy.Fail("Phiếu khám bệnh này đã hoàn tất thanh toán và xuất viện rồi.");

                string loaiKham = dtPK.Rows[0]["LoaiKham"].ToString();
                decimal tienKham = Convert.ToDecimal(dtPK.Rows[0]["TienKham"]);
                decimal tienXN = Convert.ToDecimal(dtPK.Rows[0]["TienXN"]);
                decimal tienThuoc = Convert.ToDecimal(dtPK.Rows[0]["TienThuoc"]);

                // Quy tắc: Nếu là khám định kỳ theo quý của hồ sơ bệnh án -> Miễn phí tiền khám!
                decimal mienPhi = 0;
                if (loaiKham == QuyDinh.LoaiKhamDinhKy)
                {
                    mienPhi = tienKham; // Miễn phí hoàn toàn tiền khám định kỳ
                }

                decimal tongVienPhi = tienKham + tienXN + tienThuoc - mienPhi;

                    try
                    {
                        // 1. Tạo hóa đơn viện phí
                        using (var cmd = new SqlCommand(@"INSERT INTO HoaDonVienPhi(MaHoaDon, MaPhieuKham, NgayThanhToan, TienKham,
                                                                                 TienXetNghiem, TienThuoc, MienPhiDinhKy, TongVienPhi, DaThanhToan, GhiChu)
                                                         VALUES(@hd, @pk, SYSDATETIME(), @tk, @xn, @th, @mp, @tong, 1, @gc)", cn, tr))
                        {
                            cmd.Parameters.Add(Db.P("@hd", maHD));
                            cmd.Parameters.Add(Db.P("@pk", maPK));
                            cmd.Parameters.Add(Db.P("@tk", tienKham));
                            cmd.Parameters.Add(Db.P("@xn", tienXN));
                            cmd.Parameters.Add(Db.P("@th", tienThuoc));
                            cmd.Parameters.Add(Db.P("@mp", mienPhi));
                            cmd.Parameters.Add(Db.P("@tong", tongVienPhi));
                            cmd.Parameters.Add(Db.P("@gc", ghiChu));
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Cập nhật phiếu khám: hoàn tất xuất viện, ghi nhận phản ứng phụ, hiệu quả điều trị
                        using (var cmd = new SqlCommand(@"UPDATE PhieuKhamBenh
                                                         SET TrangThai = @tt,
                                                             PhanUngPhuThuoc = @pu,
                                                             HieuQuaDieuTri = @hq
                                                         WHERE MaPhieuKham = @pk", cn, tr))
                        {
                            cmd.Parameters.Add(Db.P("@tt", QuyDinh.TrangThaiDaHoanTat));
                            cmd.Parameters.Add(Db.P("@pu", phanUngPhu));
                            cmd.Parameters.Add(Db.P("@hq", hieuQuaDieuTri));
                            cmd.Parameters.Add(Db.P("@pk", maPK));
                            cmd.ExecuteNonQuery();
                        }

                        tr.Commit();
                        return KetQuaXuLy.Ok("Thanh toán viện phí thành công! Tổng số tiền thực thu: " +
                            tongVienPhi.ToString("N0") + " đ" + (mienPhi > 0 ? " (Đã miễn phí khám định kỳ " + mienPhi.ToString("N0") + " đ)" : "") +
                            ". Đã lưu trữ hồ sơ xuất viện.");
                    }
                    catch (Exception ex)
                    {
                        try { tr.Rollback(); } catch { }
                        return KetQuaXuLy.Fail(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }
    }
}
