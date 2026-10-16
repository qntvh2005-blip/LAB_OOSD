using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>Dịch vụ quản lý các danh mục nền tảng: Khoa điều trị, Bác sĩ, Loại xét nghiệm, Thuốc.</summary>
    public class DanhMucService
    {
        public DataTable LayKhoa()
        {
            return Db.Query("SELECT MaKhoa, TenKhoa, ViTri, DienThoai FROM KhoaDieuTri ORDER BY MaKhoa");
        }

        public DataTable LayBacSi(string maKhoa = null)
        {
            if (string.IsNullOrWhiteSpace(maKhoa))
                return Db.Query(@"SELECT b.MaBacSi, b.HoTen, b.ChuyenKhoa, b.HocVi, b.DienThoai, k.TenKhoa, b.MaKhoa
                                  FROM BacSi b JOIN KhoaDieuTri k ON b.MaKhoa = k.MaKhoa ORDER BY b.MaBacSi");
            return Db.Query(@"SELECT b.MaBacSi, b.HoTen, b.ChuyenKhoa, b.HocVi, b.DienThoai, k.TenKhoa, b.MaKhoa
                              FROM BacSi b JOIN KhoaDieuTri k ON b.MaKhoa = k.MaKhoa WHERE b.MaKhoa = @k ORDER BY b.HoTen",
                              Db.P("@k", maKhoa));
        }

        public DataTable LayLoaiXetNghiem()
        {
            return Db.Query("SELECT MaLoaiXN, TenLoaiXN, DonGia, ChiSoBinhThuong FROM LoaiXetNghiem ORDER BY MaLoaiXN");
        }

        public DataTable LayThuoc()
        {
            return Db.Query("SELECT MaThuoc, TenThuoc, DonViTinh, DonGia, CongDung, TacDungPhuCanhBao FROM Thuoc ORDER BY TenThuoc");
        }

        public KetQuaXuLy ThemKhoa(string ma, string ten, string viTri, string sdt)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
                return KetQuaXuLy.Fail("Mã và tên khoa không được để trống.");
            return Chay("INSERT INTO KhoaDieuTri(MaKhoa, TenKhoa, ViTri, DienThoai) VALUES(@m, @t, @v, @p)",
                "Đã thêm khoa điều trị.", Db.P("@m", ma), Db.P("@t", ten), Db.P("@v", viTri), Db.P("@p", sdt));
        }

        public KetQuaXuLy ThemBacSi(string ma, string maKhoa, string hoTen, string chuyenKhoa, string sdt, string hocVi)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(maKhoa) || string.IsNullOrWhiteSpace(hoTen))
                return KetQuaXuLy.Fail("Thông tin bác sĩ không được để trống.");
            return Chay("INSERT INTO BacSi(MaBacSi, MaKhoa, HoTen, ChuyenKhoa, DienThoai, HocVi) VALUES(@m, @k, @t, @ck, @p, @hv)",
                "Đã thêm bác sĩ.", Db.P("@m", ma), Db.P("@k", maKhoa), Db.P("@t", hoTen), Db.P("@ck", chuyenKhoa), Db.P("@p", sdt), Db.P("@hv", hocVi));
        }

        public KetQuaXuLy ThemLoaiXN(string ma, string ten, decimal donGia, string chiSo)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || donGia < 0)
                return KetQuaXuLy.Fail("Thông tin loại xét nghiệm không hợp lệ.");
            return Chay("INSERT INTO LoaiXetNghiem(MaLoaiXN, TenLoaiXN, DonGia, ChiSoBinhThuong) VALUES(@m, @t, @g, @cs)",
                "Đã thêm loại xét nghiệm.", Db.P("@m", ma), Db.P("@t", ten), Db.P("@g", donGia), Db.P("@cs", chiSo));
        }

        public KetQuaXuLy ThemThuoc(string ma, string ten, string dvt, decimal donGia, string congDung, string canhBao)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(dvt) || donGia < 0)
                return KetQuaXuLy.Fail("Thông tin thuốc không hợp lệ.");
            return Chay("INSERT INTO Thuoc(MaThuoc, TenThuoc, DonViTinh, DonGia, CongDung, TacDungPhuCanhBao) VALUES(@m, @t, @dvt, @g, @cd, @cb)",
                "Đã thêm thuốc mới vào danh mục.", Db.P("@m", ma), Db.P("@t", ten), Db.P("@dvt", dvt), Db.P("@g", donGia), Db.P("@cd", congDung), Db.P("@cb", canhBao));
        }

        private static KetQuaXuLy Chay(string sql, string thongBao, params SqlParameter[] ps)
        {
            try
            {
                Db.Execute(sql, ps);
                return KetQuaXuLy.Ok(thongBao);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }
    }
}
