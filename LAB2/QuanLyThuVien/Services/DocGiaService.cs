using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyThuVien.Data;

namespace QuanLyThuVien.Services
{
    public class DocGiaService
    {
        public DataTable LayDanhSach()
        {
            return Db.Query(@"
                SELECT dg.MaDocGia,
                       dg.Ho,
                       dg.Ten,
                       dg.NgaySinh,
                       dg.Phai,
                       dg.SoDienThoai,
                       dg.DiaChi,
                       dg.Email,
                       dg.Anh3x4,
                       t.MaThe,
                       t.NgayCap,
                       t.HanSuDung,
                       t.DaDongLePhi,
                       t.TrangThai
                FROM DocGia dg
                OUTER APPLY
                (
                    SELECT TOP 1 *
                    FROM TheDocGia x
                    WHERE x.MaDocGia = dg.MaDocGia
                    ORDER BY x.TrangThai DESC, x.HanSuDung DESC
                ) t
                ORDER BY dg.MaDocGia");
        }

        public DataTable LayComboDocGia()
        {
            return Db.Query(@"
                SELECT MaDocGia,
                       Ho + N' ' + Ten AS HoTen
                FROM DocGia
                ORDER BY Ho, Ten");
        }

        public KetQuaXuLy Luu(DocGia docGia, bool capNhat)
        {
            if (docGia == null ||
                string.IsNullOrWhiteSpace(docGia.MaDocGia) ||
                string.IsNullOrWhiteSpace(docGia.Ho) ||
                string.IsNullOrWhiteSpace(docGia.Ten) ||
                string.IsNullOrWhiteSpace(docGia.Phai) ||
                string.IsNullOrWhiteSpace(docGia.DiaChi) ||
                string.IsNullOrWhiteSpace(docGia.Email))
            {
                return KetQuaXuLy.Loi(
                    "Vui lòng nhập đầy đủ các trường bắt buộc của độc giả.");
            }

            if (!docGia.Email.Contains("@"))
            {
                return KetQuaXuLy.Loi(
                    "Email không đúng định dạng cơ bản.");
            }

            try
            {
                string sql;

                if (capNhat)
                {
                    sql = @"
                        UPDATE DocGia
                        SET Ho = @Ho,
                            Ten = @Ten,
                            NgaySinh = @NgaySinh,
                            Phai = @Phai,
                            SoDienThoai = @SDT,
                            DiaChi = @DiaChi,
                            Email = @Email,
                            Anh3x4 = @Anh
                        WHERE MaDocGia = @Ma";
                }
                else
                {
                    sql = @"
                        INSERT INTO DocGia
                        (MaDocGia, Ho, Ten, NgaySinh, Phai,
                         SoDienThoai, DiaChi, Email, Anh3x4)
                        VALUES
                        (@Ma, @Ho, @Ten, @NgaySinh, @Phai,
                         @SDT, @DiaChi, @Email, @Anh)";
                }

                int soDong = Db.Execute(sql,
                    new SqlParameter("@Ma", docGia.MaDocGia.Trim()),
                    new SqlParameter("@Ho", docGia.Ho.Trim()),
                    new SqlParameter("@Ten", docGia.Ten.Trim()),
                    new SqlParameter("@NgaySinh", docGia.NgaySinh.Date),
                    new SqlParameter("@Phai", docGia.Phai.Trim()),
                    new SqlParameter("@SDT", docGia.SoDienThoai ?? ""),
                    new SqlParameter("@DiaChi", docGia.DiaChi.Trim()),
                    new SqlParameter("@Email", docGia.Email.Trim()),
                    new SqlParameter("@Anh", docGia.Anh3x4 ?? ""));

                return soDong > 0
                    ? KetQuaXuLy.Ok(capNhat
                        ? "Cập nhật độc giả thành công."
                        : "Thêm độc giả thành công.")
                    : KetQuaXuLy.Loi("Không có dữ liệu được thay đổi.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    return KetQuaXuLy.Loi("Mã độc giả đã tồn tại.");

                return KetQuaXuLy.Loi(
                    "Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }

        public KetQuaXuLy CapThe(
            string maDocGia,
            DateTime ngayCap,
            DateTime hanSuDung,
            bool daDongLePhi)
        {
            if (hanSuDung.Date < ngayCap.Date)
            {
                return KetQuaXuLy.Loi(
                    "Hạn sử dụng phải từ ngày cấp trở đi.");
            }

            object tonTai = Db.Scalar(
                "SELECT COUNT(*) FROM DocGia WHERE MaDocGia = @Ma",
                new SqlParameter("@Ma", maDocGia));

            if (Convert.ToInt32(tonTai) == 0)
            {
                return KetQuaXuLy.Loi("Không tìm thấy độc giả.");
            }

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                try
                {
                    using (SqlCommand check = new SqlCommand(@"
                        SELECT COUNT(*)
                        FROM TheDocGia
                        WHERE MaDocGia = @Ma
                          AND TrangThai = 1
                          AND HanSuDung >= @NgayCap", cn, tx))
                    {
                        check.Parameters.AddWithValue("@Ma", maDocGia);
                        check.Parameters.AddWithValue("@NgayCap", ngayCap.Date);

                        if (Convert.ToInt32(check.ExecuteScalar()) > 0)
                        {
                            return KetQuaXuLy.Loi(
                                "Độc giả đang có một thẻ còn giá trị sử dụng.");
                        }
                    }

                    using (SqlCommand tatTheCu = new SqlCommand(@"
                        UPDATE TheDocGia
                        SET TrangThai = 0
                        WHERE MaDocGia = @Ma AND TrangThai = 1", cn, tx))
                    {
                        tatTheCu.Parameters.AddWithValue("@Ma", maDocGia);
                        tatTheCu.ExecuteNonQuery();
                    }

                    string maThe = "THE_" + maDocGia + "_" +
                        DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    using (SqlCommand themThe = new SqlCommand(@"
                        INSERT INTO TheDocGia
                        (MaThe, MaDocGia, NgayCap, HanSuDung,
                         DaDongLePhi, TrangThai)
                        VALUES
                        (@MaThe, @MaDG, @NgayCap, @Han, @LePhi, 1)",
                        cn, tx))
                    {
                        themThe.Parameters.AddWithValue("@MaThe", maThe);
                        themThe.Parameters.AddWithValue("@MaDG", maDocGia);
                        themThe.Parameters.AddWithValue("@NgayCap", ngayCap.Date);
                        themThe.Parameters.AddWithValue("@Han", hanSuDung.Date);
                        themThe.Parameters.AddWithValue("@LePhi", daDongLePhi);
                        themThe.ExecuteNonQuery();
                    }

                    tx.Commit();

                    return KetQuaXuLy.Ok(
                        "Cấp thẻ thành công. Mã thẻ: " + maThe);
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }

                    return KetQuaXuLy.Loi(
                        "Không thể cấp thẻ: " + ex.Message);
                }
            }
        }

        public KetQuaXuLy GiaHanThe(
            string maDocGia,
            DateTime hanMoi,
            bool daDongLePhi)
        {
            using (SqlConnection cn = Db.OpenConnection())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT TOP 1 MaThe, HanSuDung
                FROM TheDocGia
                WHERE MaDocGia = @Ma AND TrangThai = 1
                ORDER BY HanSuDung DESC", cn))
            {
                cmd.Parameters.AddWithValue("@Ma", maDocGia);

                string maThe;
                DateTime hanCu;

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                    {
                        return KetQuaXuLy.Loi(
                            "Độc giả chưa có thẻ đang hoạt động.");
                    }

                    maThe = rd.GetString(0);
                    hanCu = rd.GetDateTime(1);
                }

                if (hanMoi.Date <= hanCu.Date)
                {
                    return KetQuaXuLy.Loi(
                        "Hạn sử dụng mới phải sau hạn sử dụng hiện tại.");
                }

                using (SqlCommand update = new SqlCommand(@"
                    UPDATE TheDocGia
                    SET HanSuDung = @Han,
                        DaDongLePhi = @LePhi
                    WHERE MaThe = @MaThe", cn))
                {
                    update.Parameters.AddWithValue("@Han", hanMoi.Date);
                    update.Parameters.AddWithValue("@LePhi", daDongLePhi);
                    update.Parameters.AddWithValue("@MaThe", maThe);
                    update.ExecuteNonQuery();
                }

                return KetQuaXuLy.Ok(
                    "Gia hạn thẻ thành công đến " +
                    hanMoi.ToString("dd/MM/yyyy") + ".");
            }
        }
    }
}