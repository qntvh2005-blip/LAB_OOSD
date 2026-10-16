/* =====================================================================
   HUTECH - THỰC HÀNH PHÂN TÍCH THIẾT KẾ HƯỚNG ĐỐI TƯỢNG
   BÀI 5: QUẢN LÝ HỒ SƠ BỆNH ÁN CỦA BỆNH NHÂN (BỆNH VIỆN ĐA KHOA QUỐC TẾ)
   Script tạo CSDL QuanLyBenhAn (SQL Server / LocalDB)
   ===================================================================== */

--IF DB_ID(N'QuanLyBenhAn') IS NULL CREATE DATABASE QuanLyBenhAn;
--GO
USE QuanLyBenhAn;
GO

-- Xóa bảng theo thứ tự khóa ngoại từ con đến cha
IF OBJECT_ID('HoaDonVienPhi', 'U') IS NOT NULL DROP TABLE HoaDonVienPhi;
IF OBJECT_ID('ChiTietToaThuoc', 'U') IS NOT NULL DROP TABLE ChiTietToaThuoc;
IF OBJECT_ID('ToaThuoc', 'U') IS NOT NULL DROP TABLE ToaThuoc;
IF OBJECT_ID('PhieuXetNghiem', 'U') IS NOT NULL DROP TABLE PhieuXetNghiem;
IF OBJECT_ID('LoaiXetNghiem', 'U') IS NOT NULL DROP TABLE LoaiXetNghiem;
IF OBJECT_ID('Thuoc', 'U') IS NOT NULL DROP TABLE Thuoc;
IF OBJECT_ID('PhieuKhamBenh', 'U') IS NOT NULL DROP TABLE PhieuKhamBenh;
IF OBJECT_ID('LichKhamDinhKy', 'U') IS NOT NULL DROP TABLE LichKhamDinhKy;
IF OBJECT_ID('LePhiNam', 'U') IS NOT NULL DROP TABLE LePhiNam;
IF OBJECT_ID('HoSoBenhAn', 'U') IS NOT NULL DROP TABLE HoSoBenhAn;
IF OBJECT_ID('PhieuDangKy', 'U') IS NOT NULL DROP TABLE PhieuDangKy;
IF OBJECT_ID('BenhNhan', 'U') IS NOT NULL DROP TABLE BenhNhan;
IF OBJECT_ID('BacSi', 'U') IS NOT NULL DROP TABLE BacSi;
IF OBJECT_ID('KhoaDieuTri', 'U') IS NOT NULL DROP TABLE KhoaDieuTri;
GO

-- 1. Khoa điều trị & Bác sĩ
CREATE TABLE KhoaDieuTri(
    MaKhoa varchar(20) NOT NULL PRIMARY KEY,
    TenKhoa nvarchar(150) NOT NULL,
    ViTri nvarchar(200) NOT NULL,
    DienThoai varchar(20) NULL
);

CREATE TABLE BacSi(
    MaBacSi varchar(20) NOT NULL PRIMARY KEY,
    MaKhoa varchar(20) NOT NULL,
    HoTen nvarchar(120) NOT NULL,
    ChuyenKhoa nvarchar(100) NOT NULL,
    DienThoai varchar(20) NULL,
    HocVi nvarchar(50) NULL,
    CONSTRAINT FK_BacSi_Khoa FOREIGN KEY(MaKhoa) REFERENCES KhoaDieuTri(MaKhoa)
);

-- 2. Bệnh nhân & Phiếu đăng ký & Hồ sơ bệnh án
CREATE TABLE BenhNhan(
    MaBN varchar(20) NOT NULL PRIMARY KEY,
    HoTen nvarchar(120) NOT NULL,
    NgaySinh date NOT NULL,
    GioiTinh nvarchar(10) NOT NULL CHECK(GioiTinh IN (N'Nam', N'Nữ')),
    DiaChi nvarchar(250) NOT NULL,
    DienThoai varchar(20) NOT NULL,
    Anh3x4 nvarchar(250) NULL
);

CREATE TABLE PhieuDangKy(
    MaPhieuDK varchar(20) NOT NULL PRIMARY KEY,
    MaBN varchar(20) NOT NULL UNIQUE,
    NgayDangKy datetime2 NOT NULL DEFAULT SYSDATETIME(),
    GhiChu nvarchar(500) NULL,
    CONSTRAINT FK_PDK_BenhNhan FOREIGN KEY(MaBN) REFERENCES BenhNhan(MaBN)
);

CREATE TABLE HoSoBenhAn(
    MaHoSo varchar(20) NOT NULL PRIMARY KEY,
    MaBN varchar(20) NOT NULL UNIQUE,
    NgayLap date NOT NULL DEFAULT CAST(SYSDATETIME() AS date),
    TienSuDiUng nvarchar(500) NULL,
    TrangThai nvarchar(50) NOT NULL DEFAULT N'Đang theo dõi' CHECK(TrangThai IN (N'Đang theo dõi', N'Tạm khóa', N'Đã hoàn tất')),
    CONSTRAINT FK_HSBA_BenhNhan FOREIGN KEY(MaBN) REFERENCES BenhNhan(MaBN)
);

-- 3. Lệ phí năm & Lịch khám định kỳ theo quý
CREATE TABLE LePhiNam(
    MaLePhi varchar(20) NOT NULL PRIMARY KEY,
    MaHoSo varchar(20) NOT NULL,
    Nam int NOT NULL CHECK(Nam >= 2020),
    NgayDong datetime2 NOT NULL DEFAULT SYSDATETIME(),
    SoTien decimal(18,2) NOT NULL CHECK(SoTien > 0),
    NgayHetHan date NOT NULL,
    GhiChu nvarchar(300) NULL,
    CONSTRAINT FK_LePhi_HoSo FOREIGN KEY(MaHoSo) REFERENCES HoSoBenhAn(MaHoSo),
    CONSTRAINT UQ_LePhi_HoSo_Nam UNIQUE(MaHoSo, Nam)
);

CREATE TABLE LichKhamDinhKy(
    MaLichHen varchar(20) NOT NULL PRIMARY KEY,
    MaHoSo varchar(20) NOT NULL,
    Nam int NOT NULL,
    Quy int NOT NULL CHECK(Quy BETWEEN 1 AND 4),
    NgayGioHen datetime2 NOT NULL,
    NoiDung nvarchar(500) NULL,
    TrangThai nvarchar(50) NOT NULL DEFAULT N'Đã đặt hẹn' CHECK(TrangThai IN (N'Đã đặt hẹn', N'Đã khám', N'Hủy hẹn')),
    CONSTRAINT FK_DinhKy_HoSo FOREIGN KEY(MaHoSo) REFERENCES HoSoBenhAn(MaHoSo),
    CONSTRAINT UQ_DinhKy_HoSo_Quy UNIQUE(MaHoSo, Nam, Quy)
);

-- 4. Phiếu khám bệnh (Trang sau của hồ sơ bệnh án)
CREATE TABLE PhieuKhamBenh(
    MaPhieuKham varchar(20) NOT NULL PRIMARY KEY,
    MaHoSo varchar(20) NOT NULL,
    MaKhoa varchar(20) NOT NULL,
    MaBacSi varchar(20) NOT NULL,
    MaLichHen varchar(20) NULL,
    NgayGioKham datetime2 NOT NULL DEFAULT SYSDATETIME(),
    LoaiKham nvarchar(50) NOT NULL DEFAULT N'Khám thường' CHECK(LoaiKham IN (N'Khám thường', N'Khám định kỳ')),
    TrieuChung nvarchar(500) NOT NULL,
    ThanNhiet decimal(4,1) NULL CHECK(ThanNhiet BETWEEN 34 AND 43),
    HuyetAp nvarchar(20) NULL,
    ChanDoan nvarchar(500) NULL,
    PhanUngPhuThuoc nvarchar(500) NULL,
    HieuQuaDieuTri nvarchar(500) NULL,
    TienKham decimal(18,2) NOT NULL DEFAULT 150000 CHECK(TienKham >= 0),
    TrangThai nvarchar(50) NOT NULL DEFAULT N'Đang khám' CHECK(TrangThai IN (N'Đang khám', N'Chờ xét nghiệm', N'Chờ thanh toán', N'Đã hoàn tất')),
    CONSTRAINT FK_PK_HoSo FOREIGN KEY(MaHoSo) REFERENCES HoSoBenhAn(MaHoSo),
    CONSTRAINT FK_PK_Khoa FOREIGN KEY(MaKhoa) REFERENCES KhoaDieuTri(MaKhoa),
    CONSTRAINT FK_PK_BacSi FOREIGN KEY(MaBacSi) REFERENCES BacSi(MaBacSi),
    CONSTRAINT FK_PK_LichHen FOREIGN KEY(MaLichHen) REFERENCES LichKhamDinhKy(MaLichHen)
);

-- 5. Xét nghiệm
CREATE TABLE LoaiXetNghiem(
    MaLoaiXN varchar(20) NOT NULL PRIMARY KEY,
    TenLoaiXN nvarchar(150) NOT NULL,
    DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0),
    ChiSoBinhThuong nvarchar(250) NULL
);

CREATE TABLE PhieuXetNghiem(
    MaPhieuXN varchar(20) NOT NULL PRIMARY KEY,
    MaPhieuKham varchar(20) NOT NULL,
    MaLoaiXN varchar(20) NOT NULL,
    NgayChiDinh datetime2 NOT NULL DEFAULT SYSDATETIME(),
    KetQua nvarchar(1000) NULL,
    DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0),
    TrangThai nvarchar(50) NOT NULL DEFAULT N'Chờ kết quả' CHECK(TrangThai IN (N'Chờ kết quả', N'Đã có kết quả', N'Đã hủy')),
    CONSTRAINT FK_PXN_PhieuKham FOREIGN KEY(MaPhieuKham) REFERENCES PhieuKhamBenh(MaPhieuKham),
    CONSTRAINT FK_PXN_LoaiXN FOREIGN KEY(MaLoaiXN) REFERENCES LoaiXetNghiem(MaLoaiXN)
);

-- 6. Thuốc & Toa thuốc
CREATE TABLE Thuoc(
    MaThuoc varchar(20) NOT NULL PRIMARY KEY,
    TenThuoc nvarchar(150) NOT NULL,
    DonViTinh nvarchar(50) NOT NULL,
    DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0),
    CongDung nvarchar(500) NULL,
    TacDungPhuCanhBao nvarchar(500) NULL
);

CREATE TABLE ToaThuoc(
    MaToa varchar(20) NOT NULL PRIMARY KEY,
    MaPhieuKham varchar(20) NOT NULL UNIQUE,
    NgayKe datetime2 NOT NULL DEFAULT SYSDATETIME(),
    LoiDanBacSi nvarchar(500) NULL,
    TongTienThuoc decimal(18,2) NOT NULL DEFAULT 0 CHECK(TongTienThuoc >= 0),
    CONSTRAINT FK_Toa_PhieuKham FOREIGN KEY(MaPhieuKham) REFERENCES PhieuKhamBenh(MaPhieuKham)
);

CREATE TABLE ChiTietToaThuoc(
    MaToa varchar(20) NOT NULL,
    MaThuoc varchar(20) NOT NULL,
    SoLuong int NOT NULL CHECK(SoLuong > 0),
    LieuDung nvarchar(150) NOT NULL,
    CachDung nvarchar(250) NOT NULL,
    DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0),
    ThanhTien decimal(18,2) NOT NULL CHECK(ThanhTien >= 0),
    PRIMARY KEY(MaToa, MaThuoc),
    CONSTRAINT FK_CTToa_Toa FOREIGN KEY(MaToa) REFERENCES ToaThuoc(MaToa) ON DELETE CASCADE,
    CONSTRAINT FK_CTToa_Thuoc FOREIGN KEY(MaThuoc) REFERENCES Thuoc(MaThuoc)
);

-- 7. Viện phí & Xuất viện
CREATE TABLE HoaDonVienPhi(
    MaHoaDon varchar(20) NOT NULL PRIMARY KEY,
    MaPhieuKham varchar(20) NOT NULL UNIQUE,
    NgayThanhToan datetime2 NOT NULL DEFAULT SYSDATETIME(),
    TienKham decimal(18,2) NOT NULL CHECK(TienKham >= 0),
    TienXetNghiem decimal(18,2) NOT NULL CHECK(TienXetNghiem >= 0),
    TienThuoc decimal(18,2) NOT NULL CHECK(TienThuoc >= 0),
    MienPhiDinhKy decimal(18,2) NOT NULL DEFAULT 0 CHECK(MienPhiDinhKy >= 0),
    TongVienPhi decimal(18,2) NOT NULL CHECK(TongVienPhi >= 0),
    DaThanhToan bit NOT NULL DEFAULT 1,
    GhiChu nvarchar(300) NULL,
    CONSTRAINT FK_HD_PhieuKham FOREIGN KEY(MaPhieuKham) REFERENCES PhieuKhamBenh(MaPhieuKham)
);
GO

-- 8. Dữ liệu mẫu kiểm thử
INSERT INTO KhoaDieuTri VALUES
('K01', N'Khoa Khám Bệnh Tổng Quát', N'Tầng 1 - Khu A', '0283800001'),
('K02', N'Khoa Nội Tim Mạch', N'Tầng 2 - Khu B', '0283800002'),
('K03', N'Khoa Nội Tiêu Hóa', N'Tầng 3 - Khu B', '0283800003'),
('K04', N'Khoa Thần Kinh', N'Tầng 4 - Khu C', '0283800004');

INSERT INTO BacSi VALUES
('BS01', 'K01', N'TS.BS. Nguyễn Văn Hùng', N'Bác sĩ Đa khoa', '0912111001', N'Tiến sĩ'),
('BS02', 'K02', N'ThS.BS. Lê Thị Mai', N'Nội Tim Mạch', '0912111002', N'Thạc sĩ'),
('BS03', 'K03', N'BS.CKI. Trần Quốc Toản', N'Nội Tiêu Hóa', '0912111003', N'Chuyên khoa I');

INSERT INTO LoaiXetNghiem VALUES
('XN01', N'Công thức máu toàn phần (CBC)', 120000, N'WBC: 4-10 k/uL, RBC: 4.2-5.4 M/uL'),
('XN02', N'Sinh hóa máu (Glucose)', 80000, N'3.9 - 6.4 mmol/L'),
('XN03', N'Đo điện tim thường (ECG)', 150000, N'Nhịp xoang đều 60-90 bpm');

INSERT INTO Thuoc VALUES
('TH01', N'Paracetamol 500mg', N'Viên', 2000, N'Giảm đau hạ sốt', N'Thận trọng người bệnh gan'),
('TH02', N'Amoxicillin 500mg', N'Viên', 5000, N'Kháng sinh', N'Dị ứng nổi mề đay, mẩn ngứa'),
('TH03', N'Amlodipine 5mg', N'Viên', 4500, N'Hạ huyết áp', N'Phù cổ chân nhẹ');

INSERT INTO BenhNhan VALUES
('BN001', N'Trần Đình Long', '1985-05-12', N'Nam', N'123 Lê Duẩn, Q1, TP.HCM', '0903123456', 'anh_bn001.jpg'),
('BN002', N'Nguyễn Thị Thu Hà', '1990-11-20', N'Nữ', N'45 Hai Bà Trưng, Q3, TP.HCM', '0903654321', 'anh_bn002.jpg');

INSERT INTO PhieuDangKy VALUES
('PDK001', 'BN001', '2026-01-10 08:30:00', N'Bệnh nhân đăng ký khám lần đầu'),
('PDK002', 'BN002', '2026-02-15 09:00:00', N'Đăng ký theo dõi sức khỏe');

INSERT INTO HoSoBenhAn VALUES
('HSBA001', 'BN001', '2026-01-10', N'Dị ứng hải sản', N'Đang theo dõi'),
('HSBA002', 'BN002', '2026-02-15', N'Tiền sử dị ứng Penicillin', N'Đang theo dõi');

INSERT INTO LePhiNam VALUES
('LP202601', 'HSBA001', 2026, '2026-01-10 08:35:00', 1200000, '2027-01-10', N'Lệ phí năm đầu tiên + quyền lợi khám định kỳ 4 quý'),
('LP202602', 'HSBA002', 2026, '2026-02-15 09:05:00', 1200000, '2027-02-15', N'Lệ phí năm 2026');

INSERT INTO LichKhamDinhKy VALUES
('LH001', 'HSBA001', 2026, 1, '2026-01-20 09:00:00', N'Khám định kỳ Quý 1/2026', N'Đã khám'),
('LH002', 'HSBA001', 2026, 2, '2026-04-15 09:30:00', N'Khám định kỳ Quý 2/2026', N'Đã đặt hẹn');

INSERT INTO PhieuKhamBenh VALUES
('PK001', 'HSBA001', 'K01', 'BS01', 'LH001', '2026-01-20 09:15:00', N'Khám định kỳ', N'Sức khỏe ổn định', 36.8, '120/80', N'Thể trạng tốt', NULL, N'Bình thường', 150000, N'Đã hoàn tất'),
('PK002', 'HSBA002', 'K02', 'BS02', NULL, '2026-03-10 14:00:00', N'Khám thường', N'Đau đầu, chóng mặt', 37.0, '145/95', N'Tăng huyết áp vô căn', N'Không phản ứng phụ', N'Ổn định', 150000, N'Đã hoàn tất');

INSERT INTO PhieuXetNghiem VALUES
('PXN001', 'PK002', 'XN03', '2026-03-10 14:20:00', N'Nhịp xoang 78 bpm', 150000, N'Đã có kết quả');

INSERT INTO ToaThuoc VALUES
('TOA001', 'PK002', '2026-03-10 15:00:00', N'Uống buổi sáng sau ăn', 135000);

INSERT INTO ChiTietToaThuoc VALUES
('TOA001', 'TH03', 30, N'1 viên / ngày', N'Uống buổi sáng sau ăn', 4500, 135000);

INSERT INTO HoaDonVienPhi VALUES
('HD001', 'PK001', '2026-01-20 10:00:00', 150000, 0, 0, 150000, 0, 1, N'Khám định kỳ Quý 1 miễn phí tiền khám'),
('HD002', 'PK002', '2026-03-10 15:30:00', 150000, 150000, 135000, 0, 435000, 1, N'Thanh toán đợt điều trị');
GO

PRINT N'ĐÃ TẠO THÀNH CÔNG CSDL QuanLyBenhAn VÀ DỮ LIỆU MẪU.';