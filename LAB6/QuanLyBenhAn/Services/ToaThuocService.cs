using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    /// <summary>
    /// Xử lý nghiệp vụ lập toa thuốc và lưu chi tiết thuốc.
    /// Lưu toa và chi tiết bằng transaction C#, tương thích CSDL mã varchar cũ.
    /// </summary>
    public class ToaThuocService
    {
        public DataTable LayToaTheoPhieuKham(string maPK)
        {
            return Db.Query(@"SELECT t.MaToa, t.MaPhieuKham, t.NgayKe, t.LoiDanBacSi,
                                     t.TongTienThuoc
                              FROM dbo.ToaThuoc t WHERE t.MaPhieuKham = @pk", Db.P("@pk", maPK));
        }

        public DataTable LayChiTietToa(string maToa)
        {
            return Db.Query(@"SELECT c.MaToa, c.MaThuoc, t.TenThuoc, t.DonViTinh, c.SoLuong,
                                     c.LieuDung, c.CachDung, c.DonGia, (c.SoLuong * c.DonGia) AS ThanhTien
                              FROM dbo.ChiTietToaThuoc c
                              JOIN dbo.Thuoc t ON c.MaThuoc = t.MaThuoc
                              WHERE c.MaToa = @toa
                              ORDER BY t.TenThuoc", Db.P("@toa", maToa));
        }

        public DataTable LayTatCaToaThuoc()
        {
            return Db.Query(@"SELECT t.MaToa, t.MaPhieuKham, b.HoTen AS TenBenhNhan, s.HoTen AS TenBacSi,
                                     t.NgayKe, t.TongTienThuoc, t.LoiDanBacSi
                              FROM dbo.ToaThuoc t
                              JOIN dbo.PhieuKhamBenh p ON t.MaPhieuKham = p.MaPhieuKham
                              JOIN dbo.HoSoBenhAn h ON p.MaHoSo = h.MaHoSo
                              JOIN dbo.BenhNhan b ON h.MaBN = b.MaBN
                              JOIN dbo.BacSi s ON p.MaBacSi = s.MaBacSi
                              ORDER BY t.NgayKe DESC");
        }

        public KetQuaXuLy LapToaThuoc(string maToa, string maPK, string loiDan, List<ChiTietToaItem> dsThuoc)
        {
            if (string.IsNullOrWhiteSpace(maToa) || string.IsNullOrWhiteSpace(maPK) || maToa.Trim().Length > 20)
                return KetQuaXuLy.Fail("Nhập mã toa (tối đa 20 ký tự) và chọn phiếu khám.");

            if (dsThuoc == null || dsThuoc.Count == 0)
                return KetQuaXuLy.Fail("Toa thuốc phải có ít nhất một loại thuốc.");

            if (dsThuoc.Select(x => x.MaThuoc).Distinct(StringComparer.OrdinalIgnoreCase).Count() != dsThuoc.Count)
                return KetQuaXuLy.Fail("Một thuốc chỉ được xuất hiện một lần trong toa.");
            foreach (var item in dsThuoc)
            {
                if (string.IsNullOrWhiteSpace(item.MaThuoc) || item.SoLuong <= 0)
                    return KetQuaXuLy.Fail("Số lượng thuốc phải lớn hơn 0 (" + item.TenThuoc + ").");
                if (string.IsNullOrWhiteSpace(item.LieuDung) || string.IsNullOrWhiteSpace(item.CachDung))
                    return KetQuaXuLy.Fail("Liều dùng và cách dùng không được để trống (" + item.TenThuoc + ").");

            }

            try
            {
                using (var cn = Db.OpenConnection())
                using (var tr = cn.BeginTransaction())
                {
                    object tt = Db.Scalar(cn, tr, "SELECT TrangThai FROM PhieuKhamBenh WITH(UPDLOCK,HOLDLOCK) WHERE MaPhieuKham=@pk", Db.P("@pk",maPK));
                    if (tt == null || tt.ToString() == QuyDinh.TrangThaiDaHoanTat)
                        return KetQuaXuLy.Fail("Phiếu khám không tồn tại hoặc đã hoàn tất.");
                    if (Convert.ToInt32(Db.Scalar(cn,tr,"SELECT COUNT(*) FROM PhieuXetNghiem WHERE MaPhieuKham=@pk AND TrangThai=@tt",
                        Db.P("@pk",maPK), Db.P("@tt",QuyDinh.XNChoKetQua))) > 0)
                        return KetQuaXuLy.Fail("Cần có đủ kết quả xét nghiệm trước khi lập toa.");
                    Db.Execute(cn,tr,"INSERT INTO ToaThuoc(MaToa,MaPhieuKham,LoiDanBacSi,TongTienThuoc) VALUES(@t,@pk,@ld,0)",
                        Db.P("@t",maToa),Db.P("@pk",maPK),Db.P("@ld",loiDan));
                    decimal tongTien = 0;
                    foreach (var item in dsThuoc)
                    {
                        object gia = Db.Scalar(cn,tr,"SELECT DonGia FROM Thuoc WHERE MaThuoc=@m",Db.P("@m",item.MaThuoc));
                        if (gia == null) throw new InvalidOperationException("Thuốc không tồn tại: " + item.MaThuoc);
                        decimal donGia = Convert.ToDecimal(gia), thanhTien = item.SoLuong * donGia;
                        Db.Execute(cn,tr,@"INSERT INTO ChiTietToaThuoc(MaToa,MaThuoc,SoLuong,LieuDung,CachDung,DonGia,ThanhTien)
                            VALUES(@t,@m,@sl,@ld,@cd,@g,@tt)",Db.P("@t",maToa),Db.P("@m",item.MaThuoc),Db.P("@sl",item.SoLuong),
                            Db.P("@ld",item.LieuDung),Db.P("@cd",item.CachDung),Db.P("@g",donGia),Db.P("@tt",thanhTien));
                        tongTien += thanhTien;
                    }
                    Db.Execute(cn,tr,"UPDATE ToaThuoc SET TongTienThuoc=@tong WHERE MaToa=@t",Db.P("@tong",tongTien),Db.P("@t",maToa));
                    Db.Execute(cn,tr,"UPDATE PhieuKhamBenh SET TrangThai=@tt WHERE MaPhieuKham=@pk",
                        Db.P("@tt",QuyDinh.TrangThaiChoThanhToan),Db.P("@pk",maPK));
                    tr.Commit();
                    return KetQuaXuLy.Ok(string.Format("Đã lập toa {0}. Tổng tiền thuốc: {1:N0} đ.",maToa,tongTien));
                }
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Lỗi lập toa thuốc: " + ex.Message);
            }
        }
    }
}
