using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyThuVien.Data;

namespace QuanLyThuVien.Services
{
    public class SachService
    {
        public DataTable LayDanhSach(string tuKhoa)
        {
            string sql = @"
                SELECT s.MaDauSach,
                       s.TenSach,
                       s.NamXuatBan,
                       s.SoLuongHienCo,
                       s.MaTheLoai,
                       tl.TenTheLoai,
                       s.MaNhaXuatBan,
                       nxb.DiaChi AS DiaChiNXB,
                       nxb.SoDienThoai AS SDTNXB
                FROM DauSach s
                INNER JOIN TheLoai tl
                    ON tl.MaTheLoai = s.MaTheLoai
                INNER JOIN NhaXuatBan nxb
                    ON nxb.MaNhaXuatBan = s.MaNhaXuatBan
                WHERE (@TuKhoa = ''
                    OR s.MaDauSach LIKE @Like
                    OR s.TenSach LIKE @Like)
                ORDER BY s.MaDauSach";

            string key = (tuKhoa ?? "").Trim();

            return Db.Query(sql,
                new SqlParameter("@TuKhoa", key),
                new SqlParameter("@Like", "%" + key + "%"));
        }

        public DataTable LaySachConTrongKho()
        {
            return Db.Query(@"
                SELECT MaDauSach, TenSach, NamXuatBan, SoLuongHienCo
                FROM DauSach
                WHERE SoLuongHienCo > 0
                ORDER BY TenSach");
        }

        public KetQuaXuLy Luu(DauSach sach, bool capNhat)
        {
            if (sach == null ||
                string.IsNullOrWhiteSpace(sach.MaDauSach) ||
                string.IsNullOrWhiteSpace(sach.TenSach) ||
                string.IsNullOrWhiteSpace(sach.MaTheLoai) ||
                string.IsNullOrWhiteSpace(sach.MaNhaXuatBan))
            {
                return KetQuaXuLy.Loi(
                    "Vui lòng nhập đầy đủ thông tin đầu sách.");
            }

            if (sach.NamXuatBan < 1000 ||
                sach.NamXuatBan > DateTime.Today.Year + 1)
            {
                return KetQuaXuLy.Loi("Năm xuất bản không hợp lệ.");
            }

            if (sach.SoLuongHienCo < 0)
            {
                return KetQuaXuLy.Loi(
                    "Số lượng hiện có không được âm.");
            }

            try
            {
                string sql;

                if (capNhat)
                {
                    sql = @"
                        UPDATE DauSach
                        SET TenSach = @Ten,
                            NamXuatBan = @Nam,
                            SoLuongHienCo = @SL,
                            MaTheLoai = @TL,
                            MaNhaXuatBan = @NXB
                        WHERE MaDauSach = @Ma";
                }
                else
                {
                    sql = @"
                        INSERT INTO DauSach
                        (MaDauSach, TenSach, NamXuatBan,
                         SoLuongHienCo, MaTheLoai, MaNhaXuatBan)
                        VALUES
                        (@Ma, @Ten, @Nam, @SL, @TL, @NXB)";
                }

                int soDong = Db.Execute(sql,
                    new SqlParameter("@Ma", sach.MaDauSach.Trim()),
                    new SqlParameter("@Ten", sach.TenSach.Trim()),
                    new SqlParameter("@Nam", sach.NamXuatBan),
                    new SqlParameter("@SL", sach.SoLuongHienCo),
                    new SqlParameter("@TL", sach.MaTheLoai),
                    new SqlParameter("@NXB", sach.MaNhaXuatBan));

                return soDong > 0
                    ? KetQuaXuLy.Ok(capNhat
                        ? "Cập nhật đầu sách thành công."
                        : "Thêm đầu sách thành công.")
                    : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    return KetQuaXuLy.Loi("Mã đầu sách đã tồn tại.");

                if (ex.Number == 547)
                    return KetQuaXuLy.Loi(
                        "Thể loại hoặc nhà xuất bản không hợp lệ.");

                return KetQuaXuLy.Loi(
                    "Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        public KetQuaXuLy Xoa(string maDauSach)
        {
            try
            {
                int soDong = Db.Execute(
                    "DELETE FROM DauSach WHERE MaDauSach = @Ma",
                    new SqlParameter("@Ma", maDauSach));

                return soDong > 0
                    ? KetQuaXuLy.Ok("Xóa đầu sách thành công.")
                    : KetQuaXuLy.Loi("Không tìm thấy đầu sách.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    return KetQuaXuLy.Loi(
                        "Không thể xóa đầu sách đã phát sinh giao dịch mượn/trả.");
                }

                return KetQuaXuLy.Loi(
                    "Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }
    }
}