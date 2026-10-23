using System;
using System.Collections.Generic;
using System.Data;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public class TraCuuService
    {
        static readonly HashSet<string> Tables = new HashSet<string>
        {
            "PhongBan",
            "ChucVu",
            "CaLam",
            "NhanVien",
            "QuyetDinhTuyenDung",
            "HopDong",
            "HoSoBaoHiem",
            "QuyetDinhLuong",
            "QuyetDinhChucVu",
            "KeHoachTuan",
            "PhanCongCa",
            "ChamCong",
            "PhieuPhuTroi",
            "ChiTietPhuTroi",
            "QuyetDinhThuongPhat",
            "ChiTietThuongPhat",
            "PhieuThuChi",
            "BangLuong",
            "ChiTietBangLuong",
        };

        public DataTable Bang(string table)
        {
            Rules.Need(Tables.Contains(table), "Tên bảng không hợp lệ.");
            // Các truy vấn chỉ phục vụ hiển thị, không sửa dữ liệu nghiệp vụ.
            switch (table)
            {
                case "ChamCong":
                    return Db.Query(
                        @"
                        SELECT c.IdPhanCong, p.MaNV, n.HoTen, p.Ngay,
                               ca.TenCa, c.GioThucTe, c.NguoiCham
                        FROM ChamCong AS c
                        INNER JOIN PhanCongCa AS p ON p.Id = c.IdPhanCong
                        INNER JOIN NhanVien AS n ON n.MaNV = p.MaNV
                        INNER JOIN CaLam AS ca ON ca.MaCa = p.MaCa
                        ORDER BY p.Ngay DESC, p.MaNV;
                    "
                    );
                case "PhanCongCa":
                    return Db.Query(
                        @"
                        SELECT p.Id, p.MaKH, p.MaNV, n.HoTen, p.Ngay,
                               ca.TenCa, p.GioPhuTroiDuKien, p.HinhThuc
                        FROM PhanCongCa AS p
                        INNER JOIN NhanVien AS n ON n.MaNV = p.MaNV
                        INNER JOIN CaLam AS ca ON ca.MaCa = p.MaCa
                        ORDER BY p.Ngay DESC, p.MaNV;
                    "
                    );
                case "ChiTietPhuTroi":
                    return Db.Query(
                        @"
                        SELECT p.SoPhieu, p.Ngay, ct.MaNV, n.HoTen,
                               p.HinhThuc, ct.SoGio, p.NguoiLap
                        FROM ChiTietPhuTroi AS ct
                        INNER JOIN PhieuPhuTroi AS p ON p.SoPhieu = ct.SoPhieu
                        INNER JOIN NhanVien AS n ON n.MaNV = ct.MaNV
                        ORDER BY p.Ngay DESC, ct.MaNV;
                    "
                    );
                case "QuyetDinhTuyenDung":
                    return Db.Query(
                        @"
                        SELECT q.SoQD, q.MaNV, n.HoTen, n.MaPB, q.NgayQD,
                               q.TuNgay, q.DenNgay, q.LuongThuViec,
                               q.KetQua, q.NguoiKy, q.DieuKhoan
                        FROM QuyetDinhTuyenDung AS q
                        INNER JOIN NhanVien AS n ON n.MaNV = q.MaNV
                        ORDER BY q.NgayQD DESC, q.MaNV;
                    "
                    );
                case "NhanVien":
                    return Db.Query(
                        @"
                        SELECT n.MaNV, n.HoTen, p.TenPB, n.TrangThai,
                               q.TuNgay, q.DenNgay, q.KetQua, n.NgaySinh,
                               n.DienThoai, n.DiaChi
                        FROM NhanVien AS n
                        INNER JOIN PhongBan AS p ON p.MaPB = n.MaPB
                        LEFT JOIN QuyetDinhTuyenDung AS q ON q.MaNV = n.MaNV
                        ORDER BY n.MaNV;
                    "
                    );
                case "HopDong":
                    return Db.Query(
                        @"
                        SELECT h.SoHD, h.MaNV, n.HoTen, h.LoaiHD,
                               h.NgayKy, h.TuNgay, h.DenNgay,
                               b.MaBHXH, b.MaBHYT, b.TyLeBHXH, b.TyLeBHYT,
                               h.NguoiKy, h.DieuKhoan
                        FROM HopDong AS h
                        INNER JOIN NhanVien AS n ON n.MaNV = h.MaNV
                        LEFT JOIN HoSoBaoHiem AS b ON b.SoHD = h.SoHD
                        ORDER BY h.TuNgay DESC, h.MaNV;
                    "
                    );
                case "QuyetDinhLuong":
                    return Db.Query(
                        @"
                        SELECT q.SoQD, q.MaNV, n.HoTen, q.NgayHieuLuc,
                               q.LuongCoBan, q.PhuCapLuong, q.PhuCapDocHai, q.NguoiKy
                        FROM QuyetDinhLuong AS q
                        INNER JOIN NhanVien AS n ON n.MaNV = q.MaNV
                        ORDER BY q.NgayHieuLuc DESC, q.MaNV;
                    "
                    );
                case "QuyetDinhChucVu":
                    return Db.Query(
                        @"
                        SELECT q.SoQD, q.MaNV, n.HoTen, cv.TenCV,
                               q.NgayHieuLuc, q.PhuCapChucVu, q.NguoiKy
                        FROM QuyetDinhChucVu AS q
                        INNER JOIN NhanVien AS n ON n.MaNV = q.MaNV
                        INNER JOIN ChucVu AS cv ON cv.MaCV = q.MaCV
                        ORDER BY q.NgayHieuLuc DESC, q.MaNV;
                    "
                    );
                case "QuyetDinhThuongPhat":
                    return Db.Query(
                        @"
                        SELECT q.SoQD, q.Loai,
                               CASE WHEN q.MaNV IS NOT NULL
                                    THEN q.MaNV + N' - ' + n.HoTen
                                    ELSE q.MaPB + N' - ' + p.TenPB END AS DoiTuong,
                               q.NgayQD, q.SoTien, q.HinhThuc,
                               q.KyApDung, q.NguoiKy, q.NoiDung
                        FROM QuyetDinhThuongPhat AS q
                        LEFT JOIN NhanVien AS n ON n.MaNV = q.MaNV
                        LEFT JOIN PhongBan AS p ON p.MaPB = q.MaPB
                        ORDER BY q.NgayQD DESC, q.SoQD;
                    "
                    );
                case "PhieuThuChi":
                    return Db.Query(
                        @"
                        SELECT p.SoPhieu, p.SoQD, p.Ngay, p.Loai,
                               p.SoTien, p.MaBL, q.NoiDung
                        FROM PhieuThuChi AS p
                        INNER JOIN QuyetDinhThuongPhat AS q ON q.SoQD = p.SoQD
                        ORDER BY p.Ngay DESC, p.SoPhieu;
                    "
                    );
            }
            return Db.Query("SELECT * FROM [" + table + "]");
        }

        public DataTable Ma(string table, string col)
        {
            Rules.Need(
                (table == "NhanVien" && col == "MaNV")
                    || (table == "PhongBan" && col == "MaPB")
                    || (table == "CaLam" && col == "MaCa")
                    || (table == "ChucVu" && col == "MaCV")
                    || (table == "QuyetDinhThuongPhat" && col == "SoQD"),
                "Tra cứu không hợp lệ."
            );
            string description =
                table == "NhanVien" ? "HoTen"
                : table == "PhongBan" ? "TenPB"
                : table == "ChucVu" ? "TenCV"
                : table == "CaLam" ? "TenCa"
                : "NoiDung";
            // Cả tên bảng, khóa và cột mô tả đều lấy từ danh sách cố định ở trên.
            return Db.Query(
                "SELECT ["
                    + col
                    + "], ["
                    + col
                    + "] + N' - ' + ["
                    + description
                    + "] AS HienThi FROM ["
                    + table
                    + "] ORDER BY ["
                    + col
                    + "]"
            );
        }
    }
}
