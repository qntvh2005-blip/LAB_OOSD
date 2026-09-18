using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyThuVien.Data;

namespace QuanLyThuVien.Services
{
    public class ThongKeService
    {
        public ThongKeTongHop LayTongHop(
            DateTime tuNgay,
            DateTime denNgay)
        {
            if (tuNgay.Date > denNgay.Date)
            {
                DateTime tam = tuNgay;
                tuNgay = denNgay;
                denNgay = tam;
            }

            ThongKeTongHop ketQua = new ThongKeTongHop();

            ketQua.LuotSachMuon = Convert.ToInt32(Db.Scalar(@"
                SELECT COUNT(*)
                FROM PhieuMuon pm
                INNER JOIN ChiTietPhieuMuon ct
                    ON ct.MaPhieuMuon = pm.MaPhieuMuon
                WHERE pm.NgayMuon BETWEEN @Tu AND @Den",
                new SqlParameter("@Tu", tuNgay.Date),
                new SqlParameter("@Den", denNgay.Date)));

            ketQua.SachQuaHan = Convert.ToInt32(Db.Scalar(@"
                SELECT COUNT(*)
                FROM PhieuMuon pm
                INNER JOIN ChiTietPhieuMuon ct
                    ON ct.MaPhieuMuon = pm.MaPhieuMuon
                WHERE pm.NgayHenTra BETWEEN @Tu AND @Den
                  AND
                  (
                      (ct.NgayTraThucTe IS NULL
                       AND pm.NgayHenTra < CAST(GETDATE() AS DATE))
                      OR ct.NgayTraThucTe > pm.NgayHenTra
                  )",
                new SqlParameter("@Tu", tuNgay.Date),
                new SqlParameter("@Den", denNgay.Date)));

            ketQua.SachMat = Convert.ToInt32(Db.Scalar(@"
                SELECT COUNT(*)
                FROM ChiTietPhieuMuon
                WHERE TinhTrangTra = N'Mất'
                  AND NgayTraThucTe BETWEEN @Tu AND @Den",
                new SqlParameter("@Tu", tuNgay.Date),
                new SqlParameter("@Den", denNgay.Date)));

            ketQua.SachHuHong = Convert.ToInt32(Db.Scalar(@"
                SELECT COUNT(*)
                FROM ChiTietPhieuMuon
                WHERE
                    (
                        TinhTrangTra LIKE N'%Rách%'
                        OR TinhTrangTra LIKE N'%Hư%'
                    )
                  AND NgayTraThucTe BETWEEN @Tu AND @Den",
                new SqlParameter("@Tu", tuNgay.Date),
                new SqlParameter("@Den", denNgay.Date)));

            object tongPhi = Db.Scalar(@"
                SELECT ISNULL(SUM(PhiPhat), 0)
                FROM PhieuPhat
                WHERE NgayPhat BETWEEN @Tu AND @Den",
                new SqlParameter("@Tu", tuNgay.Date),
                new SqlParameter("@Den", denNgay.Date));

            ketQua.TongPhiPhat = Convert.ToDecimal(tongPhi);

            return ketQua;
        }

        public DataTable LayPhieuPhat(
            DateTime tuNgay,
            DateTime denNgay)
        {
            if (tuNgay.Date > denNgay.Date)
            {
                DateTime tam = tuNgay;
                tuNgay = denNgay;
                denNgay = tam;
            }

            return Db.Query(@"
                SELECT pp.MaPhieuPhat,
                       pp.NgayPhat,
                       ds.MaDauSach,
                       ds.TenSach,
                       pp.LyDo,
                       pp.PhiPhat,
                       nv.Ho + N' ' + nv.Ten AS NhanVienLap
                FROM PhieuPhat pp
                INNER JOIN ChiTietPhieuMuon ct
                    ON ct.MaChiTiet = pp.MaChiTiet
                INNER JOIN DauSach ds
                    ON ds.MaDauSach = ct.MaDauSach
                INNER JOIN NhanVien nv
                    ON nv.MaNhanVien = pp.MaNhanVien
                WHERE pp.NgayPhat BETWEEN @Tu AND @Den
                ORDER BY pp.NgayPhat DESC",
                new SqlParameter("@Tu", tuNgay.Date),
                new SqlParameter("@Den", denNgay.Date));
        }
    }
}