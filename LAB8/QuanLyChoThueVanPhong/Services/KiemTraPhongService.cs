using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong.Services
{
    /// <summary>
    /// Xử lý việc kiểm tra tình trạng các phòng của cao ốc định kỳ cách 1 năm
    /// và lập biên bản xử phạt đối với các phòng tự ý thay đổi, chỉnh sửa kết cấu.
    /// </summary>
    public class KiemTraPhongService
    {
        public DataTable LayDanhSachKiemTra()
        {
            return Db.Query(@"SELECT kt.MaPhieuKT, kt.MaPhong, p.TenPhong, t.TenTang,
                                     kt.NgayKiemTra, kt.NguoiKiemTra, kt.TinhTrangKetCau,
                                     kt.TinhTrangNoiThat, kt.CoViPham, kt.GhiChuTuSua
                              FROM dbo.KiemTraPhong kt
                              JOIN dbo.Phong p ON kt.MaPhong = p.MaPhong
                              JOIN dbo.Tang t ON p.MaTang = t.MaTang
                              ORDER BY kt.NgayKiemTra DESC, kt.MaPhieuKT DESC");
        }

        public DataTable LayDanhSachXuPhat()
        {
            return Db.Query(@"SELECT bb.MaBienBan, bb.MaPhieuKT, bb.MaHD, k.TenCongTy,
                                     bb.MaPhong, p.TenPhong, bb.NgayLap, bb.HanhViViPham,
                                     bb.SoTienPhat, bb.HanNopPhat, bb.DaNopPhat, bb.NgayNopPhat
                              FROM dbo.BienBanXuPhat bb
                              JOIN dbo.HopDongThue h ON bb.MaHD = h.MaHD
                              JOIN dbo.KhachHang k ON h.MaKH = k.MaKH
                              JOIN dbo.Phong p ON bb.MaPhong = p.MaPhong
                              ORDER BY bb.NgayLap DESC, bb.MaBienBan DESC");
        }

        public KetQuaXuLy LapPhieuKiemTra(string maKT, string maPhong, string nguoiKT,
            string tinhTrangKetCau, string tinhTrangNoiThat, bool coViPham, string ghiChuTuSua)
        {
            if (string.IsNullOrWhiteSpace(maKT) || string.IsNullOrWhiteSpace(maPhong) || string.IsNullOrWhiteSpace(nguoiKT))
                return KetQuaXuLy.Fail("Mã phiếu kiểm tra, phòng và người kiểm tra không được để trống.");

            try
            {
                Db.Execute(@"INSERT INTO dbo.KiemTraPhong(MaPhieuKT, MaPhong, NgayKiemTra, NguoiKiemTra, TinhTrangKetCau, TinhTrangNoiThat, CoViPham, GhiChuTuSua)
                             VALUES(@kt, @p, CAST(SYSDATETIME() AS date), @ng, @kc, @nt, @vp, @gc)",
                             Db.P("@kt", maKT), Db.P("@p", maPhong), Db.P("@ng", nguoiKT),
                             Db.P("@kc", tinhTrangKetCau), Db.P("@nt", tinhTrangNoiThat),
                             Db.P("@vp", coViPham), Db.P("@gc", ghiChuTuSua));

                return KetQuaXuLy.Ok("Lập phiếu kiểm tra định kỳ phòng thành công.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi: " + ex.Message);
            }
        }

        public KetQuaXuLy LapBienBanXuPhat(string maBB, string maKT, string maHD, string maPhong,
            string hanhViViPham, decimal soTienPhat, DateTime hanNopPhat)
        {
            if (string.IsNullOrWhiteSpace(maBB) || string.IsNullOrWhiteSpace(maKT) || string.IsNullOrWhiteSpace(maHD) || string.IsNullOrWhiteSpace(maPhong))
                return KetQuaXuLy.Fail("Thông tin biên bản xử phạt không được để trống.");

            if (soTienPhat <= 0)
                return KetQuaXuLy.Fail("Số tiền phạt vi phạm kết cấu phải lớn hơn 0.");

            try
            {
                Db.Execute(@"INSERT INTO dbo.BienBanXuPhat(MaBienBan, MaPhieuKT, MaHD, MaPhong, NgayLap, HanhViViPham, SoTienPhat, HanNopPhat, DaNopPhat)
                             VALUES(@bb, @kt, @hd, @p, CAST(SYSDATETIME() AS date), @hv, @tien, @han, 0)",
                             Db.P("@bb", maBB), Db.P("@kt", maKT), Db.P("@hd", maHD), Db.P("@p", maPhong),
                             Db.P("@hv", hanhViViPham), Db.P("@tien", soTienPhat), Db.P("@han", hanNopPhat.Date));

                return KetQuaXuLy.Ok(string.Format("Lập biên bản xử phạt {0} thành công! Số tiền phạt: {1:N0} đ. Hạn nộp phạt: {2:dd/MM/yyyy}.",
                    maBB, soTienPhat, hanNopPhat));
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi: " + ex.Message);
            }
        }

        public KetQuaXuLy NopTienPhat(string maBB)
        {
            if (string.IsNullOrWhiteSpace(maBB))
                return KetQuaXuLy.Fail("Chưa chọn biên bản xử phạt.");

            try
            {
                Db.Execute(@"UPDATE dbo.BienBanXuPhat
                             SET DaNopPhat = 1, NgayNopPhat = SYSDATETIME()
                             WHERE MaBienBan = @bb", Db.P("@bb", maBB));

                return KetQuaXuLy.Ok("Xác nhận thu nộp tiền phạt thành công!");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi: " + ex.Message);
            }
        }
    }
}
