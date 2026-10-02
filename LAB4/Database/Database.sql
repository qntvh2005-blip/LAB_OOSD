-- Du lieu cau hinh va phi chi la mau cho LAB. Khong xoa CSDL hien co.
IF DB_ID(N'ESHOPPING_LAB4') IS NULL CREATE DATABASE ESHOPPING_LAB4;
GO
USE ESHOPPING_LAB4;
GO
IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NULL
BEGIN
CREATE TABLE dbo.KhachHang (
 MaKhachHang varchar(40) NOT NULL PRIMARY KEY,
 HoTen nvarchar(100) NOT NULL, NgaySinh date NOT NULL,
 CMNDPassport nvarchar(30) NOT NULL, DiaChi nvarchar(250) NOT NULL,
 DienThoai varchar(20) NOT NULL, TenDangNhap nvarchar(50) NOT NULL UNIQUE,
 MatKhauBam varchar(100) NOT NULL, MuoiMatKhau varchar(100) NOT NULL,
 Email nvarchar(254) NULL
);
CREATE TABLE dbo.KhuVuc (MaKhuVuc varchar(10) PRIMARY KEY, TenKhuVuc nvarchar(100) NOT NULL);
CREATE TABLE dbo.LoaiGiaoHang (
 MaLoaiGiaoHang varchar(10) PRIMARY KEY, TenLoai nvarchar(100) NOT NULL,
 ThoiGianXuLyGio int NOT NULL CHECK (ThoiGianXuLyGio > 0)
);
CREATE TABLE dbo.BieuPhiGiaoHang (
 MaKhuVuc varchar(10) NOT NULL REFERENCES dbo.KhuVuc(MaKhuVuc),
 MaLoaiGiaoHang varchar(10) NOT NULL REFERENCES dbo.LoaiGiaoHang(MaLoaiGiaoHang),
 PhiCoBan decimal(19,2) NOT NULL CHECK(PhiCoBan >= 0),
 PRIMARY KEY(MaKhuVuc, MaLoaiGiaoHang)
);
CREATE TABLE dbo.LoaiThe (
 MaLoaiThe varchar(10) PRIMARY KEY, TenLoai nvarchar(100) NOT NULL,
 SoChuSo int NOT NULL CHECK (SoChuSo IN (15,16)),
 DoDaiCSV int NOT NULL CHECK (DoDaiCSV IN (3,4)),
 LePhiSuDung decimal(19,2) NOT NULL CHECK(LePhiSuDung >= 0)
);
CREATE TABLE dbo.DonHang (
 MaDonHang varchar(40) PRIMARY KEY, MaYeuCau uniqueidentifier NOT NULL UNIQUE,
 MaKhachHang varchar(40) NOT NULL REFERENCES dbo.KhachHang(MaKhachHang),
 MaKhuVuc varchar(10) NOT NULL REFERENCES dbo.KhuVuc(MaKhuVuc),
 MaLoaiGiaoHang varchar(10) NOT NULL REFERENCES dbo.LoaiGiaoHang(MaLoaiGiaoHang),
 ThoiDiemDat datetime2 NOT NULL,
 HoTenNguoiNhan nvarchar(100) NOT NULL, DiaChiNguoiNhan nvarchar(250) NOT NULL,
 DienThoaiNguoiNhan varchar(20) NOT NULL,
 TienHang decimal(19,2) NOT NULL CHECK(TienHang >= 0),
 PhiGiaoHang decimal(19,2) NOT NULL CHECK(PhiGiaoHang >= 0),
 LePhiThe decimal(19,2) NOT NULL CHECK(LePhiThe >= 0),
 TongThanhToan decimal(19,2) NOT NULL,
 CHECK(TongThanhToan = TienHang + PhiGiaoHang + LePhiThe),
 FOREIGN KEY(MaKhuVuc,MaLoaiGiaoHang) REFERENCES dbo.BieuPhiGiaoHang(MaKhuVuc,MaLoaiGiaoHang)
);
CREATE TABLE dbo.ChiTietDonHang (
 MaDonHang varchar(40) NOT NULL REFERENCES dbo.DonHang(MaDonHang),
 -- MaSanPham tham chieu he thong ngoai, khong co FK den bang SanPham cuc bo.
 MaSanPham varchar(40) NOT NULL, TenSanPhamLucDat nvarchar(200) NOT NULL,
 SoLuong int NOT NULL CHECK(SoLuong > 0),
 DonGiaLucDat decimal(19,2) NOT NULL CHECK(DonGiaLucDat >= 0),
 PRIMARY KEY(MaDonHang,MaSanPham)
);
CREATE TABLE dbo.XacNhanThanhToan (
 MaXacNhan varchar(40) PRIMARY KEY,
 MaDonHang varchar(40) NOT NULL UNIQUE REFERENCES dbo.DonHang(MaDonHang),
 MaLoaiThe varchar(10) NOT NULL REFERENCES dbo.LoaiThe(MaLoaiThe),
 MaThamChieu varchar(80) NOT NULL UNIQUE,
 BonSoCuoi char(4) NOT NULL CHECK(BonSoCuoi NOT LIKE '%[^0-9]%'),
 TrangThai varchar(20) NOT NULL CHECK(TrangThai='ChapNhan'),
 ThoiDiemXacMinh datetime2 NOT NULL
);
CREATE INDEX IX_DonHang_KhachHang ON dbo.DonHang(MaKhachHang,ThoiDiemDat);
END;
GO
IF NOT EXISTS(SELECT 1 FROM dbo.KhuVuc)
BEGIN
INSERT dbo.KhuVuc VALUES('NT',N'Nội thành'),('NG',N'Ngoại thành');
INSERT dbo.LoaiGiaoHang VALUES('THUONG',N'Giao hàng thường',72),('NHANH',N'Chuyển phát nhanh',24),('TRONGNGAY',N'Nhanh trong ngày',8);
INSERT dbo.BieuPhiGiaoHang VALUES ('NT','THUONG',20000),('NT','NHANH',40000),('NT','TRONGNGAY',80000),('NG','THUONG',35000),('NG','NHANH',60000),('NG','TRONGNGAY',120000);
INSERT dbo.LoaiThe VALUES('VISA',N'Visa',16,3,0),('MASTER',N'MasterCard',16,3,5000),('DISCOVER',N'Discover',16,3,5000),('AMEX',N'American Express',15,4,10000);
END;
GO
