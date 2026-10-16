using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>
    /// Xử lý nghiệp vụ đăng ký bệnh nhân mới, lập phiếu đăng ký, đóng lệ phí năm và cấp hồ sơ bệnh án.
    /// Dùng mã varchar và transaction C#, không yêu cầu stored procedure.
    /// </summary>
    public class BenhNhanService
    {
        public DataTable LayDanhSachBenhNhan()
        {
            return Db.Query(@"SELECT b.MaBN, b.HoTen, b.NgaySinh, b.GioiTinh, b.DiaChi, b.DienThoai,
                                     h.MaHoSo, h.NgayLap, h.TienSuDiUng, h.TrangThai
                              FROM dbo.BenhNhan b
                              LEFT JOIN dbo.HoSoBenhAn h ON b.MaBN = h.MaBN
                              ORDER BY b.MaBN DESC");
        }

        public DataTable LayDanhSachHoSo()
        {
            return Db.Query(@"SELECT h.MaHoSo, h.MaBN, b.HoTen, b.NgaySinh, b.GioiTinh, b.DienThoai,
                                     h.NgayLap, h.TienSuDiUng, h.TrangThai,
                                     (SELECT TOP 1 Nam FROM dbo.LePhiNam l WHERE l.MaHoSo = h.MaHoSo ORDER BY Nam DESC) AS NamDongLePhiGanNhat
                              FROM dbo.HoSoBenhAn h
                              JOIN dbo.BenhNhan b ON h.MaBN = b.MaBN
                              ORDER BY h.MaHoSo DESC");
        }

        public DataTable LayLePhiCuaHoSo(string maHoSo)
        {
            return Db.Query(@"SELECT MaLePhi, MaHoSo, Nam, NgayDong, SoTien, NgayHetHan
                              FROM dbo.LePhiNam WHERE MaHoSo = @h ORDER BY Nam DESC", Db.P("@h", maHoSo));
        }

        /// <summary>
        /// Đăng ký lần đầu: bốn bảng được lưu cùng một transaction.
        /// </summary>
        public KetQuaXuLy DangKyLanDau(string maBN, string hoTen, DateTime ngaySinh, string gioiTinh,
            string diaChi, string sdt, string anh3x4, string maPhieuDK, string ghiChu,
            string maHoSo, string tienSuDiUng, int nam, decimal soTienLePhi)
        {
            if (string.IsNullOrWhiteSpace(maBN) || string.IsNullOrWhiteSpace(maPhieuDK) || string.IsNullOrWhiteSpace(maHoSo)
                || maBN.Trim().Length > 20 || maPhieuDK.Trim().Length > 20 || maHoSo.Trim().Length > 20)
                return KetQuaXuLy.Fail("Nhập mã bệnh nhân, phiếu đăng ký và hồ sơ (tối đa 20 ký tự).");
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(diaChi) || string.IsNullOrWhiteSpace(sdt))
                return KetQuaXuLy.Fail("Thông tin cá nhân bệnh nhân không được để trống.");
            if (ngaySinh.Date > DateTime.Today || (gioiTinh != "Nam" && gioiTinh != "Nữ"))
                return KetQuaXuLy.Fail("Ngày sinh hoặc giới tính không hợp lệ.");
            if (nam != DateTime.Today.Year)
                return KetQuaXuLy.Fail("Đăng ký lần đầu phải đóng lệ phí cho năm hiện tại.");
            if (soTienLePhi <= 0)
                return KetQuaXuLy.Fail("Bệnh nhân phải đóng lệ phí một năm để được cấp hồ sơ và khám định kỳ.");
            try
            {
                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                    Db.Execute(cn, tr, @"INSERT INTO BenhNhan(MaBN,HoTen,NgaySinh,GioiTinh,DiaChi,DienThoai,Anh3x4)
                        VALUES(@m,@t,@ns,@gt,@dc,@sdt,@anh)", Db.P("@m",maBN), Db.P("@t",hoTen),
                        Db.P("@ns",ngaySinh.Date), Db.P("@gt",gioiTinh), Db.P("@dc",diaChi), Db.P("@sdt",sdt), Db.P("@anh",anh3x4));
                    Db.Execute(cn, tr, @"INSERT INTO PhieuDangKy(MaPhieuDK,MaBN,GhiChu) VALUES(@m,@bn,@gc)",
                        Db.P("@m",maPhieuDK), Db.P("@bn",maBN), Db.P("@gc",ghiChu));
                    Db.Execute(cn, tr, @"INSERT INTO HoSoBenhAn(MaHoSo,MaBN,TienSuDiUng) VALUES(@m,@bn,@du)",
                        Db.P("@m",maHoSo), Db.P("@bn",maBN), Db.P("@du",tienSuDiUng));
                    Db.Execute(cn, tr, @"INSERT INTO LePhiNam(MaLePhi,MaHoSo,Nam,SoTien,NgayHetHan)
                        VALUES(@m,@hs,@n,@tien,@hh)", Db.P("@m",Db.TaoMaLePhi()), Db.P("@hs",maHoSo),
                        Db.P("@n",nam), Db.P("@tien",soTienLePhi), Db.P("@hh",DateTime.Today.AddYears(1)));
                    tr.Commit();
                }
                return KetQuaXuLy.Ok("Đăng ký thành công. Đã cấp hồ sơ " + maHoSo + " và thu lệ phí năm " + nam + ".");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi khi đăng ký bệnh nhân: " + ex.Message);
            }
        }

        /// <summary>Gia hạn đóng lệ phí cho năm tiếp theo.</summary>
        public KetQuaXuLy GiaHanLePhiNam(string maHoSo, int nam, decimal soTien, string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(maHoSo) || nam < DateTime.Today.Year || nam > DateTime.Today.Year + 1 || soTien <= 0)
                return KetQuaXuLy.Fail("Thông tin hồ sơ, năm hoặc số tiền lệ phí không hợp lệ.");

            try
            {
                object tonTai = Db.Scalar("SELECT 1 FROM dbo.LePhiNam WHERE MaHoSo = @h AND Nam = @n",
                    Db.P("@h", maHoSo), Db.P("@n", nam));
                if (tonTai != null)
                    return KetQuaXuLy.Fail("Hồ sơ này đã đóng lệ phí cho năm " + nam + " rồi.");

                DateTime ngayDong = DateTime.Today;
                // Giữ cách tính 12 tháng như dữ liệu SQL cũ; cho phép thu trước năm kế tiếp.
                DateTime batDau = nam == ngayDong.Year ? ngayDong : new DateTime(nam, 1, 1);
                DateTime ngayHetHan = batDau.AddYears(1);
                Db.Execute(@"INSERT INTO dbo.LePhiNam(MaLePhi, MaHoSo, Nam, NgayDong, SoTien, NgayHetHan, GhiChu)
                             VALUES(@m, @h, @n, @d, @tien, @hh, @gc)",
                             Db.P("@m",Db.TaoMaLePhi()), Db.P("@gc",ghiChu),
                             Db.P("@h", maHoSo), Db.P("@n", nam),
                             Db.P("@d", ngayDong), Db.P("@tien", soTien), Db.P("@hh", ngayHetHan));
                return KetQuaXuLy.Ok("Đã thu lệ phí năm " + nam + " cho hồ sơ " + maHoSo + " (Hết hạn: " + ngayHetHan.ToString("dd/MM/yyyy") + ").");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }
    }
}
