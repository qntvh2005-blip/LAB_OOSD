using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Xử lý quy trình chỉ định xét nghiệm và ghi nhận kết quả xét nghiệm theo phiếu khám.</summary>
    public class XetNghiemService
    {
        public DataTable LayXetNghiemTheoPhieuKham(string maPK)
        {
            return Db.Query(@"SELECT x.MaPhieuXN, x.MaPhieuKham, l.TenLoaiXN, x.NgayChiDinh,
                                     x.KetQua, x.DonGia, x.TrangThai, l.ChiSoBinhThuong
                              FROM PhieuXetNghiem x
                              JOIN LoaiXetNghiem l ON x.MaLoaiXN = l.MaLoaiXN
                              WHERE x.MaPhieuKham = @pk
                              ORDER BY x.NgayChiDinh DESC", Db.P("@pk", maPK));
        }

        public DataTable LayTatCaXetNghiem()
        {
            return Db.Query(@"SELECT x.MaPhieuXN, x.MaPhieuKham, b.HoTen AS TenBenhNhan, l.TenLoaiXN,
                                     x.NgayChiDinh, x.KetQua, x.DonGia, x.TrangThai
                              FROM PhieuXetNghiem x
                              JOIN LoaiXetNghiem l ON x.MaLoaiXN = l.MaLoaiXN
                              JOIN PhieuKhamBenh p ON x.MaPhieuKham = p.MaPhieuKham
                              JOIN HoSoBenhAn h ON p.MaHoSo = h.MaHoSo
                              JOIN BenhNhan b ON h.MaBN = b.MaBN
                              ORDER BY x.NgayChiDinh DESC");
        }

        public KetQuaXuLy ChiDinhXetNghiem(string maPXN, string maPK, string maLoaiXN)
        {
            if (string.IsNullOrWhiteSpace(maPXN) || string.IsNullOrWhiteSpace(maPK) || string.IsNullOrWhiteSpace(maLoaiXN))
                return KetQuaXuLy.Fail("Thông tin chỉ định xét nghiệm chưa đầy đủ.");

            try
            {
                object donGia = Db.Scalar("SELECT DonGia FROM LoaiXetNghiem WHERE MaLoaiXN = @lxn", Db.P("@lxn", maLoaiXN));
                if (donGia == null) return KetQuaXuLy.Fail("Loại xét nghiệm không tồn tại.");

                decimal gia = Convert.ToDecimal(donGia);

                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                    try
                    {
                        object tt = Db.Scalar(cn,tr,"SELECT TrangThai FROM PhieuKhamBenh WITH(UPDLOCK,HOLDLOCK) WHERE MaPhieuKham=@pk",Db.P("@pk",maPK));
                        if (tt == null || (tt.ToString() != QuyDinh.TrangThaiDangKham && tt.ToString() != QuyDinh.TrangThaiChoXetNghiem))
                            return KetQuaXuLy.Fail("Chỉ được chỉ định xét nghiệm cho phiếu đang khám hoặc chờ xét nghiệm.");
                        using (var cmd = new SqlCommand(@"INSERT INTO PhieuXetNghiem(MaPhieuXN, MaPhieuKham, MaLoaiXN, NgayChiDinh, DonGia, TrangThai)
                                                         VALUES(@xn, @pk, @lxn, SYSDATETIME(), @gia, N'Chờ kết quả')", cn, tr))
                        {
                            cmd.Parameters.Add(Db.P("@xn", maPXN));
                            cmd.Parameters.Add(Db.P("@pk", maPK));
                            cmd.Parameters.Add(Db.P("@lxn", maLoaiXN));
                            cmd.Parameters.Add(Db.P("@gia", gia));
                            cmd.ExecuteNonQuery();
                        }

                        // Cập nhật trạng thái phiếu khám thành Chờ xét nghiệm
                        using (var cmd = new SqlCommand("UPDATE PhieuKhamBenh SET TrangThai = @tt WHERE MaPhieuKham = @pk", cn, tr))
                        {
                            cmd.Parameters.Add(Db.P("@tt", QuyDinh.TrangThaiChoXetNghiem));
                            cmd.Parameters.Add(Db.P("@pk", maPK));
                            cmd.ExecuteNonQuery();
                        }

                        tr.Commit();
                        return KetQuaXuLy.Ok("Đã chỉ định xét nghiệm " + maPXN + " (Đơn giá: " + gia.ToString("N0") + " đ).");
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

        public KetQuaXuLy CapNhatKetQua(string maPXN, string ketQua)
        {
            if (string.IsNullOrWhiteSpace(maPXN) || string.IsNullOrWhiteSpace(ketQua))
                return KetQuaXuLy.Fail("Mã phiếu xét nghiệm và nội dung kết quả không được để trống.");

            try
            {
                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                // Lấy mã phiếu khám
                object oPK = Db.Scalar(cn,tr,"SELECT MaPhieuKham FROM PhieuXetNghiem WHERE MaPhieuXN = @xn", Db.P("@xn", maPXN));
                if (oPK == null) return KetQuaXuLy.Fail("Không tìm thấy phiếu xét nghiệm.");
                string maPK = oPK.ToString();
                object tt = Db.Scalar(cn,tr,"SELECT TrangThai FROM PhieuKhamBenh WITH(UPDLOCK,HOLDLOCK) WHERE MaPhieuKham=@pk",Db.P("@pk",maPK));
                if (tt == null || (tt.ToString() != QuyDinh.TrangThaiDangKham && tt.ToString() != QuyDinh.TrangThaiChoXetNghiem))
                    return KetQuaXuLy.Fail("Phiếu khám đã chốt; không được thay đổi kết quả xét nghiệm.");

                if (Db.Execute(cn,tr,"UPDATE PhieuXetNghiem SET KetQua = @kq, TrangThai = N'Đã có kết quả' WHERE MaPhieuXN = @xn AND TrangThai<>N'Đã hủy'",
                    Db.P("@kq", ketQua), Db.P("@xn", maPXN)) == 0)
                    return KetQuaXuLy.Fail("Phiếu xét nghiệm đã hủy hoặc không tồn tại.");

                // Kiểm tra xem còn xét nghiệm nào của phiếu khám chưa có kết quả không
                int choKQ = Convert.ToInt32(Db.Scalar(cn,tr,@"SELECT COUNT(*) FROM PhieuXetNghiem
                                                       WHERE MaPhieuKham = @pk AND TrangThai = N'Chờ kết quả'",
                                                       Db.P("@pk", maPK)));
                if (choKQ == 0)
                {
                    // Chuyển lại trạng thái phiếu khám về 'Đang khám'
                    Db.Execute(cn,tr,"UPDATE PhieuKhamBenh SET TrangThai = @tt WHERE MaPhieuKham = @pk",
                        Db.P("@tt", QuyDinh.TrangThaiDangKham), Db.P("@pk", maPK));
                }

                tr.Commit();
                return KetQuaXuLy.Ok("Đã lưu kết quả xét nghiệm cho phiếu " + maPXN + ".");
                }
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }
    }
}
