using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Xử lý quy trình khám bệnh: tạo phiếu khám, ghi nhận triệu chứng, thân nhiệt, huyết áp, chẩn đoán.</summary>
    public class KhamBenhService
    {
        public DataTable LayDanhSachPhieuKham(string trangThai = null)
        {
            string sql = @"SELECT p.MaPhieuKham, p.MaHoSo, b.HoTen AS TenBenhNhan, k.TenKhoa, s.HoTen AS TenBacSi,
                                  p.LoaiKham, p.NgayGioKham, p.TrieuChung, p.ThanNhiet, p.HuyetAp, p.ChanDoan,
                                  p.TienKham, p.TrangThai, p.MaLichHen
                           FROM PhieuKhamBenh p
                           JOIN HoSoBenhAn h ON p.MaHoSo = h.MaHoSo
                           JOIN BenhNhan b ON h.MaBN = b.MaBN
                           JOIN KhoaDieuTri k ON p.MaKhoa = k.MaKhoa
                           JOIN BacSi s ON p.MaBacSi = s.MaBacSi";
            if (!string.IsNullOrWhiteSpace(trangThai))
            {
                sql += " WHERE p.TrangThai = @tt ORDER BY p.NgayGioKham DESC";
                return Db.Query(sql, Db.P("@tt", trangThai));
            }
            sql += " ORDER BY p.NgayGioKham DESC";
            return Db.Query(sql);
        }

        public DataTable LayPhieuKhamChoXetNghiemHoacToa()
        {
            return Db.Query(@"SELECT p.MaPhieuKham, p.MaPhieuKham + ' - ' + b.HoTen + ' (' + p.LoaiKham + ')' AS HienThi,
                                     p.MaHoSo, b.HoTen, p.ChanDoan
                              FROM PhieuKhamBenh p
                              JOIN HoSoBenhAn h ON p.MaHoSo = h.MaHoSo
                              JOIN BenhNhan b ON h.MaBN = b.MaBN
                              WHERE p.TrangThai IN (N'Đang khám', N'Chờ xét nghiệm')
                              ORDER BY p.NgayGioKham DESC");
        }

        public KetQuaXuLy TaoPhieuKham(string maPK, string maHoSo, string maKhoa, string maBacSi,
            string loaiKham, string trieuChung, decimal? thanNhiet, string huyetAp, string chanDoan,
            string maLichHen = null)
        {
            if (string.IsNullOrWhiteSpace(maPK) || string.IsNullOrWhiteSpace(maHoSo) ||
                string.IsNullOrWhiteSpace(maKhoa) || string.IsNullOrWhiteSpace(maBacSi) ||
                string.IsNullOrWhiteSpace(trieuChung))
                return KetQuaXuLy.Fail("Thông tin phiếu khám chưa đầy đủ.");

            try
            {
                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                // Kiểm tra hồ sơ bệnh án có tồn tại không
                object oHS = Db.Scalar(cn,tr,"SELECT TrangThai FROM HoSoBenhAn WHERE MaHoSo = @h", Db.P("@h", maHoSo));
                if (oHS == null || oHS.ToString() != QuyDinh.HSDangTheoDoi)
                    return KetQuaXuLy.Fail("Hồ sơ bệnh án không tồn tại hoặc không hoạt động.");
                if (Db.Scalar(cn,tr,"SELECT 1 FROM BacSi WHERE MaBacSi=@bs AND MaKhoa=@k",Db.P("@bs",maBacSi),Db.P("@k",maKhoa)) == null)
                    return KetQuaXuLy.Fail("Bác sĩ không thuộc khoa đã chọn.");
                if (loaiKham != QuyDinh.LoaiKhamThuong && loaiKham != QuyDinh.LoaiKhamDinhKy)
                    return KetQuaXuLy.Fail("Loại khám không hợp lệ.");

                // Tiền khám mặc định: 150.000 đ
                decimal tienKham = QuyDinh.TienKhamMacDinh;

                // Nếu là khám định kỳ có gắn mã lịch hẹn
                if (loaiKham == QuyDinh.LoaiKhamDinhKy)
                {
                    object lich = Db.Scalar(cn,tr,@"SELECT 1 FROM LichKhamDinhKy l WITH(UPDLOCK,HOLDLOCK)
                        WHERE l.MaLichHen=@lh AND l.MaHoSo=@hs AND l.TrangThai=@tt
                        AND NOT EXISTS(SELECT 1 FROM PhieuKhamBenh p WHERE p.MaLichHen=l.MaLichHen)
                        AND EXISTS(SELECT 1 FROM LePhiNam lp WHERE lp.MaHoSo=l.MaHoSo
                            AND lp.Nam=l.Nam AND CAST(SYSDATETIME() AS date) BETWEEN CAST(lp.NgayDong AS date) AND lp.NgayHetHan)",
                        Db.P("@lh",maLichHen),Db.P("@hs",maHoSo),Db.P("@tt",QuyDinh.HenDaDat));
                    if (lich == null) return KetQuaXuLy.Fail("Chọn lịch hẹn chưa khám, đúng hồ sơ và còn hiệu lực lệ phí.");
                    // Cập nhật trạng thái lịch hẹn thành 'Đã khám'
                    Db.Execute(cn,tr,"UPDATE LichKhamDinhKy SET TrangThai = @tt WHERE MaLichHen = @lh",
                        Db.P("@tt", QuyDinh.HenDaKham), Db.P("@lh", maLichHen));
                }
                else maLichHen = null;

                Db.Execute(cn,tr,@"INSERT INTO PhieuKhamBenh(MaPhieuKham, MaHoSo, MaKhoa, MaBacSi, MaLichHen, NgayGioKham,
                                                      LoaiKham, TrieuChung, ThanNhiet, HuyetAp, ChanDoan, TienKham, TrangThai)
                             VALUES(@pk, @hs, @k, @bs, @lh, SYSDATETIME(), @lk, @tc, @tn, @ha, @cd, @tien, @tt)",
                             Db.P("@pk", maPK), Db.P("@hs", maHoSo), Db.P("@k", maKhoa), Db.P("@bs", maBacSi),
                             Db.P("@lh", maLichHen), Db.P("@lk", loaiKham), Db.P("@tc", trieuChung),
                             Db.P("@tn", thanNhiet.HasValue ? (object)thanNhiet.Value : DBNull.Value),
                             Db.P("@ha", huyetAp), Db.P("@cd", chanDoan), Db.P("@tien", tienKham),
                             Db.P("@tt", QuyDinh.TrangThaiDangKham));

                tr.Commit();
                return KetQuaXuLy.Ok("Đã tạo phiếu khám bệnh: " + maPK + ".");
                }
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }

        public KetQuaXuLy CapNhatChanDoan(string maPK, string chanDoan)
        {
            if (string.IsNullOrWhiteSpace(maPK)) return KetQuaXuLy.Fail("Chưa chọn phiếu khám.");
            int n = Db.Execute("UPDATE PhieuKhamBenh SET ChanDoan = @cd WHERE MaPhieuKham = @pk",
                Db.P("@cd", chanDoan), Db.P("@pk", maPK));
            return n > 0 ? KetQuaXuLy.Ok("Đã cập nhật chẩn đoán.") : KetQuaXuLy.Fail("Không tìm thấy phiếu khám.");
        }
    }
}
