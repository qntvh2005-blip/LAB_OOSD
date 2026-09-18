using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyThuVien.Data;

namespace QuanLyThuVien.Services
{
    public class MuonTraService
    {
        public KetQuaXuLy KiemTraDieuKienMuon(
            string maDocGia,
            int soSachMuonMoi)
        {
            if (string.IsNullOrWhiteSpace(maDocGia))
                return KetQuaXuLy.Loi("Vui lòng chọn độc giả.");

            if (soSachMuonMoi < 1)
                return KetQuaXuLy.Loi("Phải chọn ít nhất 1 đầu sách.");

            if (soSachMuonMoi > 3)
                return KetQuaXuLy.Loi(
                    "Một lần chỉ được mượn tối đa 3 đầu sách.");

            DataTable the = Db.Query(@"
                SELECT TOP 1 MaThe, HanSuDung, DaDongLePhi, TrangThai
                FROM TheDocGia
                WHERE MaDocGia = @Ma AND TrangThai = 1
                ORDER BY HanSuDung DESC",
                new SqlParameter("@Ma", maDocGia));

            if (the.Rows.Count == 0)
            {
                return KetQuaXuLy.Loi(
                    "Độc giả chưa có thẻ thư viện đang hoạt động.");
            }

            DateTime han = Convert.ToDateTime(the.Rows[0]["HanSuDung"]);
            bool daDongLePhi = Convert.ToBoolean(
                the.Rows[0]["DaDongLePhi"]);

            if (han.Date < DateTime.Today)
                return KetQuaXuLy.Loi("Thẻ thư viện đã hết hạn.");

            if (!daDongLePhi)
                return KetQuaXuLy.Loi(
                    "Độc giả chưa đóng lệ phí năm.");

            int quaHan = Convert.ToInt32(Db.Scalar(@"
                SELECT COUNT(*)
                FROM PhieuMuon pm
                INNER JOIN ChiTietPhieuMuon ct
                    ON ct.MaPhieuMuon = pm.MaPhieuMuon
                WHERE pm.MaDocGia = @Ma
                  AND ct.NgayTraThucTe IS NULL
                  AND pm.NgayHenTra < CAST(GETDATE() AS DATE)",
                new SqlParameter("@Ma", maDocGia)));

            if (quaHan > 0)
            {
                return KetQuaXuLy.Loi(
                    "Độc giả còn sách quá hạn chưa trả nên không được mượn thêm.");
            }

            int dangMuon = Convert.ToInt32(Db.Scalar(@"
                SELECT COUNT(*)
                FROM PhieuMuon pm
                INNER JOIN ChiTietPhieuMuon ct
                    ON ct.MaPhieuMuon = pm.MaPhieuMuon
                WHERE pm.MaDocGia = @Ma
                  AND ct.NgayTraThucTe IS NULL",
                new SqlParameter("@Ma", maDocGia)));

            if (dangMuon + soSachMuonMoi > 3)
            {
                return KetQuaXuLy.Loi(
                    "Tổng sách đang mượn và sắp mượn không được vượt quá 3.");
            }

            return KetQuaXuLy.Ok(
                "Độc giả đủ điều kiện mượn sách.");
        }

        public KetQuaXuLy LapPhieuMuon(
            string maDocGia,
            string maNhanVien,
            IList<string> maDauSach,
            DateTime ngayMuon,
            DateTime ngayHenTra)
        {
            if (maDauSach == null)
                return KetQuaXuLy.Loi("Danh sách sách mượn không hợp lệ.");

            HashSet<string> danhSach = new HashSet<string>(
                StringComparer.OrdinalIgnoreCase);

            foreach (string ma in maDauSach)
            {
                if (!string.IsNullOrWhiteSpace(ma))
                    danhSach.Add(ma.Trim());
            }

            KetQuaXuLy kiemTra = KiemTraDieuKienMuon(
                maDocGia,
                danhSach.Count);

            if (!kiemTra.ThanhCong)
                return kiemTra;

            if (string.IsNullOrWhiteSpace(maNhanVien))
                return KetQuaXuLy.Loi(
                    "Vui lòng chọn nhân viên lập phiếu.");

            if (ngayHenTra.Date < ngayMuon.Date)
                return KetQuaXuLy.Loi(
                    "Ngày hẹn trả không được trước ngày mượn.");

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx =
                cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    foreach (string maSach in danhSach)
                    {
                        using (SqlCommand check = new SqlCommand(@"
                            SELECT SoLuongHienCo
                            FROM DauSach WITH (UPDLOCK, HOLDLOCK)
                            WHERE MaDauSach = @Ma", cn, tx))
                        {
                            check.Parameters.AddWithValue("@Ma", maSach);

                            object soLuong = check.ExecuteScalar();

                            if (soLuong == null)
                            {
                                tx.Rollback();
                                return KetQuaXuLy.Loi(
                                    "Không tìm thấy đầu sách: " + maSach);
                            }

                            if (Convert.ToInt32(soLuong) <= 0)
                            {
                                tx.Rollback();
                                return KetQuaXuLy.Loi(
                                    "Đầu sách " + maSach + " đã hết trong kho.");
                            }
                        }
                    }

                    string maPhieuMuon = "PM" +
                        DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    using (SqlCommand themPhieu = new SqlCommand(@"
                        INSERT INTO PhieuMuon
                        (MaPhieuMuon, MaDocGia, MaNhanVien,
                         NgayMuon, NgayHenTra)
                        VALUES
                        (@MaPM, @MaDG, @MaNV, @NgayMuon, @HenTra)",
                        cn, tx))
                    {
                        themPhieu.Parameters.AddWithValue("@MaPM", maPhieuMuon);
                        themPhieu.Parameters.AddWithValue("@MaDG", maDocGia);
                        themPhieu.Parameters.AddWithValue("@MaNV", maNhanVien);
                        themPhieu.Parameters.AddWithValue("@NgayMuon", ngayMuon.Date);
                        themPhieu.Parameters.AddWithValue("@HenTra", ngayHenTra.Date);
                        themPhieu.ExecuteNonQuery();
                    }

                    int stt = 1;

                    foreach (string maSach in danhSach)
                    {
                        string maChiTiet = maPhieuMuon + "_" +
                            stt.ToString("00");

                        using (SqlCommand themChiTiet = new SqlCommand(@"
                            INSERT INTO ChiTietPhieuMuon
                            (MaChiTiet, MaPhieuMuon, MaDauSach)
                            VALUES(@MaCT, @MaPM, @MaSach)", cn, tx))
                        {
                            themChiTiet.Parameters.AddWithValue("@MaCT", maChiTiet);
                            themChiTiet.Parameters.AddWithValue("@MaPM", maPhieuMuon);
                            themChiTiet.Parameters.AddWithValue("@MaSach", maSach);
                            themChiTiet.ExecuteNonQuery();
                        }

                        using (SqlCommand giamKho = new SqlCommand(@"
                            UPDATE DauSach
                            SET SoLuongHienCo = SoLuongHienCo - 1
                            WHERE MaDauSach = @MaSach", cn, tx))
                        {
                            giamKho.Parameters.AddWithValue("@MaSach", maSach);
                            giamKho.ExecuteNonQuery();
                        }

                        stt++;
                    }

                    tx.Commit();

                    return KetQuaXuLy.Ok(
                        "Lập phiếu mượn thành công. Mã phiếu: " + maPhieuMuon);
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }

                    return KetQuaXuLy.Loi(
                        "Không thể lập phiếu mượn: " + ex.Message);
                }
            }
        }

        public DataTable LaySachDangMuon(string maDocGia)
        {
            return Db.Query(@"
                SELECT ct.MaChiTiet,
                       pm.MaPhieuMuon,
                       ds.MaDauSach,
                       ds.TenSach,
                       pm.NgayMuon,
                       pm.NgayHenTra
                FROM PhieuMuon pm
                INNER JOIN ChiTietPhieuMuon ct
                    ON ct.MaPhieuMuon = pm.MaPhieuMuon
                INNER JOIN DauSach ds
                    ON ds.MaDauSach = ct.MaDauSach
                WHERE pm.MaDocGia = @Ma
                  AND ct.NgayTraThucTe IS NULL
                ORDER BY pm.NgayHenTra",
                new SqlParameter("@Ma", maDocGia));
        }

        public KetQuaXuLy TraSach(
            string maChiTiet,
            string maNhanVien,
            DateTime ngayTra,
            string tinhTrang,
            decimal phiPhat)
        {
            if (string.IsNullOrWhiteSpace(maChiTiet))
                return KetQuaXuLy.Loi("Vui lòng chọn sách cần trả.");

            if (string.IsNullOrWhiteSpace(maNhanVien))
                return KetQuaXuLy.Loi(
                    "Vui lòng chọn nhân viên nhận trả.");

            if (string.IsNullOrWhiteSpace(tinhTrang))
                return KetQuaXuLy.Loi(
                    "Vui lòng chọn tình trạng sách.");

            using (SqlConnection cn = Db.OpenConnection())
            using (SqlTransaction tx =
                cn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    string maDauSach;
                    DateTime ngayMuon;
                    DateTime ngayHenTra;

                    using (SqlCommand cmd = new SqlCommand(@"
                        SELECT ct.MaDauSach,
                               ct.NgayTraThucTe,
                               pm.NgayMuon,
                               pm.NgayHenTra
                        FROM ChiTietPhieuMuon ct
                        INNER JOIN PhieuMuon pm
                            ON pm.MaPhieuMuon = ct.MaPhieuMuon
                        WHERE ct.MaChiTiet = @MaCT", cn, tx))
                    {
                        cmd.Parameters.AddWithValue("@MaCT", maChiTiet);

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read())
                                return KetQuaXuLy.Loi(
                                    "Không tìm thấy chi tiết mượn.");

                            if (!rd.IsDBNull(1))
                                return KetQuaXuLy.Loi(
                                    "Sách này đã được trả trước đó.");

                            maDauSach = rd.GetString(0);
                            ngayMuon = rd.GetDateTime(2);
                            ngayHenTra = rd.GetDateTime(3);
                        }
                    }

                    if (ngayTra.Date < ngayMuon.Date)
                    {
                        return KetQuaXuLy.Loi(
                            "Ngày trả không thể trước ngày mượn.");
                    }

                    string tt = tinhTrang.Trim();

                    bool quaHan = ngayTra.Date > ngayHenTra.Date;
                    bool mat = tt.Equals("Mất",
                        StringComparison.OrdinalIgnoreCase);

                    bool huHong =
                        tt.IndexOf("Rách",
                            StringComparison.OrdinalIgnoreCase) >= 0 ||
                        tt.IndexOf("Hư",
                            StringComparison.OrdinalIgnoreCase) >= 0;

                    bool canPhat = quaHan || mat || huHong;

                    if (canPhat && phiPhat <= 0)
                    {
                        return KetQuaXuLy.Loi(
                            "Trường hợp trả trễ, mất hoặc hư hỏng phải nhập phí phạt lớn hơn 0.");
                    }

                    using (SqlCommand capNhatTra = new SqlCommand(@"
                        UPDATE ChiTietPhieuMuon
                        SET NgayTraThucTe = @NgayTra,
                            TinhTrangTra = @TinhTrang
                        WHERE MaChiTiet = @MaCT
                          AND NgayTraThucTe IS NULL", cn, tx))
                    {
                        capNhatTra.Parameters.AddWithValue("@NgayTra", ngayTra.Date);
                        capNhatTra.Parameters.AddWithValue("@TinhTrang", tt);
                        capNhatTra.Parameters.AddWithValue("@MaCT", maChiTiet);

                        if (capNhatTra.ExecuteNonQuery() != 1)
                        {
                            throw new InvalidOperationException(
                                "Không cập nhật được trạng thái trả sách.");
                        }
                    }

                    if (!mat && !huHong)
                    {
                        using (SqlCommand tangKho = new SqlCommand(@"
                            UPDATE DauSach
                            SET SoLuongHienCo = SoLuongHienCo + 1
                            WHERE MaDauSach = @MaSach", cn, tx))
                        {
                            tangKho.Parameters.AddWithValue("@MaSach", maDauSach);
                            tangKho.ExecuteNonQuery();
                        }
                    }

                    if (canPhat)
                    {
                        string lyDo = "";

                        if (quaHan) lyDo = "Trả sách trễ hạn";
                        if (mat)
                            lyDo += (lyDo == "" ? "" : "; ") + "Mất sách";
                        if (huHong)
                            lyDo += (lyDo == "" ? "" : "; ") +
                                "Rách hoặc hư hỏng sách";

                        string maPhat = "PP" +
                            DateTime.Now.ToString("yyyyMMddHHmmssfff");

                        using (SqlCommand themPhat = new SqlCommand(@"
                            INSERT INTO PhieuPhat
                            (MaPhieuPhat, MaChiTiet, MaNhanVien,
                             NgayPhat, LyDo, PhiPhat)
                            VALUES
                            (@MaPP, @MaCT, @MaNV,
                             @NgayPhat, @LyDo, @PhiPhat)", cn, tx))
                        {
                            themPhat.Parameters.AddWithValue("@MaPP", maPhat);
                            themPhat.Parameters.AddWithValue("@MaCT", maChiTiet);
                            themPhat.Parameters.AddWithValue("@MaNV", maNhanVien);
                            themPhat.Parameters.AddWithValue("@NgayPhat", ngayTra.Date);
                            themPhat.Parameters.AddWithValue("@LyDo", lyDo);
                            themPhat.Parameters.AddWithValue("@PhiPhat", phiPhat);
                            themPhat.ExecuteNonQuery();
                        }
                    }

                    tx.Commit();

                    return KetQuaXuLy.Ok("Trả sách thành công.");
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }

                    return KetQuaXuLy.Loi(
                        "Không thể trả sách: " + ex.Message);
                }
            }
        }
    }
}