-- LAB 7 - QUAN LY NHAN SU CONG TY SON DONG A
-- Mot file duy nhat: tao CSDL + 19 bang + du lieu mau.
-- Mo toan bo file trong SSMS, ket noi dung SQL Server va nhan F5.
-- Khong DROP CSDL/bang, khong xoa hoac ghi de du lieu da nhap.
-- Neu doi ten CSDL, thay ca ba cho QuanLyNhanSu_LAB7 o phan dau
-- va sua Initial Catalog trong QuanLyNhanSu/App.config.

USE [master];
GO

IF DB_ID(N'QuanLyNhanSu_LAB7') IS NULL
BEGIN
    EXEC(N'CREATE DATABASE [QuanLyNhanSu_LAB7];');
END;
GO

USE [QuanLyNhanSu_LAB7];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;
SET DATEFIRST 1;

DECLARE @SoBangLab INT;

SELECT @SoBangLab = COUNT(*)
FROM sys.tables
WHERE schema_id = SCHEMA_ID(N'dbo')
      AND name IN (
          N'PhongBan', N'ChucVu', N'CaLam', N'NhanVien',
          N'QuyetDinhTuyenDung', N'HopDong', N'HoSoBaoHiem',
          N'QuyetDinhLuong', N'QuyetDinhChucVu', N'KeHoachTuan',
          N'PhanCongCa', N'ChamCong', N'PhieuPhuTroi',
          N'ChiTietPhuTroi', N'QuyetDinhThuongPhat', N'BangLuong',
          N'ChiTietThuongPhat', N'PhieuThuChi', N'ChiTietBangLuong'
      );

-- Chi tao bang khi CSDL trong; khong tu sua mot schema thieu/khac phien ban.
IF @SoBangLab NOT IN (0, 19)
BEGIN
    THROW 50001, N'CSDL dang thieu bang LAB7. Hay dung CSDL moi de khoi tao, khong xoa du lieu cu.', 1;
END;

IF @SoBangLab = 0
   AND EXISTS (SELECT 1 FROM sys.tables WHERE is_ms_shipped = 0)
BEGIN
    THROW 50002, N'CSDL da co bang khac. Hay doi ten CSDL LAB7 trong file SQL va App.config.', 1;
END;

BEGIN TRY
    BEGIN TRANSACTION;

    -- PHAN 1. CAU TRUC BANG, KHOA VA DANH MUC BAN DAU
    IF @SoBangLab = 0
    BEGIN
        CREATE TABLE dbo.PhongBan (
            MaPB  VARCHAR (20)   PRIMARY KEY,
            TenPB NVARCHAR (120) NOT NULL
        );

        CREATE TABLE dbo.ChucVu (
            MaCV  VARCHAR (20)   PRIMARY KEY,
            TenCV NVARCHAR (120) NOT NULL
        );

        CREATE TABLE dbo.CaLam (
            MaCa     VARCHAR (20)   PRIMARY KEY,
            TenCa    NVARCHAR (100) NOT NULL,
            GioChuan DECIMAL (5, 2) NOT NULL CHECK (GioChuan > 0
                                                    AND GioChuan <= 24)
        );

        CREATE TABLE dbo.NhanVien (
            MaNV      VARCHAR (20)   PRIMARY KEY,
            HoTen     NVARCHAR (120) NOT NULL,
            NgaySinh  DATE           NOT NULL,
            DienThoai VARCHAR (20)   NULL,
            DiaChi    NVARCHAR (250) NULL,
            MaPB      VARCHAR (20)   NOT NULL FOREIGN KEY REFERENCES dbo.PhongBan (MaPB),
            TrangThai VARCHAR (20)   NOT NULL CHECK (TrangThai IN ('ThuViec', 'ChinhThuc', 'KhongDat'))
        );

        CREATE TABLE dbo.QuyetDinhTuyenDung (
            SoQD         VARCHAR (20)    PRIMARY KEY,
            MaNV         VARCHAR (20)    NOT NULL UNIQUE FOREIGN KEY REFERENCES dbo.NhanVien (MaNV),
            NgayQD       DATE            NOT NULL,
            TuNgay       DATE            NOT NULL,
            DenNgay      DATE            NOT NULL,
            LuongThuViec DECIMAL (18, 2) NOT NULL CHECK (LuongThuViec > 0),
            DieuKhoan    NVARCHAR (1000) NOT NULL,
            NguoiKy      NVARCHAR (120)  NOT NULL,
            KetQua       VARCHAR (20)    DEFAULT 'ChoDanhGia' NOT NULL CHECK (KetQua IN ('ChoDanhGia', 'Dat', 'KhongDat')),
            CHECK (DenNgay >= TuNgay),
            CHECK (NgayQD <= TuNgay)
        );

        CREATE TABLE dbo.HopDong (
            SoHD      VARCHAR (20)    PRIMARY KEY,
            MaNV      VARCHAR (20)    NOT NULL FOREIGN KEY REFERENCES dbo.NhanVien (MaNV),
            LoaiHD    VARCHAR (10)    NOT NULL CHECK (LoaiHD IN ('DaiHan', 'NganHan')),
            NgayKy    DATE            NOT NULL,
            TuNgay    DATE            NOT NULL,
            DenNgay   DATE            NULL,
            DieuKhoan NVARCHAR (1000) NOT NULL,
            NguoiKy   NVARCHAR (120)  NOT NULL,
            CHECK (NgayKy <= TuNgay),
            CHECK ((LoaiHD = 'DaiHan'
                    AND DenNgay IS NULL)
                   OR (LoaiHD = 'NganHan'
                       AND DenNgay >= TuNgay))
        );

        CREATE TABLE dbo.HoSoBaoHiem (
            SoHD     VARCHAR (20)   PRIMARY KEY FOREIGN KEY REFERENCES dbo.HopDong (SoHD),
            MaBHXH   VARCHAR (30)   NOT NULL UNIQUE,
            MaBHYT   VARCHAR (30)   NOT NULL UNIQUE,
            TyLeBHXH DECIMAL (8, 6) NOT NULL CHECK (TyLeBHXH BETWEEN 0 AND 1),
            TyLeBHYT DECIMAL (8, 6) NOT NULL CHECK (TyLeBHYT BETWEEN 0 AND 1),
            CHECK (TyLeBHXH + TyLeBHYT <= 1)
        );

        CREATE TABLE dbo.QuyetDinhLuong (
            SoQD         VARCHAR (20)    PRIMARY KEY,
            MaNV         VARCHAR (20)    NOT NULL FOREIGN KEY REFERENCES dbo.NhanVien (MaNV),
            NgayHieuLuc  DATE            NOT NULL,
            LuongCoBan   DECIMAL (18, 2) NOT NULL CHECK (LuongCoBan > 0),
            PhuCapLuong  DECIMAL (18, 2) NOT NULL CHECK (PhuCapLuong >= 0),
            PhuCapDocHai DECIMAL (18, 2) NOT NULL CHECK (PhuCapDocHai >= 0),
            NguoiKy      NVARCHAR (120)  NOT NULL,
            UNIQUE (MaNV, NgayHieuLuc)
        );

        CREATE TABLE dbo.QuyetDinhChucVu (
            SoQD         VARCHAR (20)    PRIMARY KEY,
            MaNV         VARCHAR (20)    NOT NULL FOREIGN KEY REFERENCES dbo.NhanVien (MaNV),
            MaCV         VARCHAR (20)    NOT NULL FOREIGN KEY REFERENCES dbo.ChucVu (MaCV),
            NgayHieuLuc  DATE            NOT NULL,
            PhuCapChucVu DECIMAL (18, 2) NOT NULL CHECK (PhuCapChucVu >= 0),
            NguoiKy      NVARCHAR (120)  NOT NULL,
            UNIQUE (MaNV, NgayHieuLuc)
        );

        CREATE TABLE dbo.KeHoachTuan (
            MaKH        VARCHAR (20)   PRIMARY KEY,
            MaPB        VARCHAR (20)   NOT NULL FOREIGN KEY REFERENCES dbo.PhongBan (MaPB),
            NgayDauTuan DATE           NOT NULL,
            NguoiLap    NVARCHAR (120) NOT NULL,
            UNIQUE (MaPB, NgayDauTuan)
        );

        CREATE TABLE dbo.PhanCongCa (
            Id               INT            IDENTITY PRIMARY KEY,
            MaKH             VARCHAR (20)   NOT NULL FOREIGN KEY REFERENCES dbo.KeHoachTuan (MaKH),
            MaNV             VARCHAR (20)   NOT NULL FOREIGN KEY REFERENCES dbo.NhanVien (MaNV),
            Ngay             DATE           NOT NULL,
            MaCa             VARCHAR (20)   NOT NULL FOREIGN KEY REFERENCES dbo.CaLam (MaCa),
            GioPhuTroiDuKien DECIMAL (5, 2) NOT NULL CHECK (GioPhuTroiDuKien BETWEEN 0 AND 24),
            HinhThuc         VARCHAR (10)   NULL CHECK (HinhThuc IN ('TangCa', 'NgayLe', 'NgayNghi')),
            UNIQUE (MaNV, Ngay)
        );

        CREATE TABLE dbo.ChamCong (
            IdPhanCong INT            PRIMARY KEY FOREIGN KEY REFERENCES dbo.PhanCongCa (Id),
            GioThucTe  DECIMAL (5, 2) NOT NULL CHECK (GioThucTe BETWEEN 0 AND 24),
            NguoiCham  NVARCHAR (120) NOT NULL
        );

        CREATE TABLE dbo.PhieuPhuTroi (
            SoPhieu  VARCHAR (20)   PRIMARY KEY,
            Ngay     DATE           NOT NULL,
            HinhThuc VARCHAR (10)   NOT NULL CHECK (HinhThuc IN ('TangCa', 'NgayLe', 'NgayNghi')),
            SoGio    DECIMAL (5, 2) NOT NULL CHECK (SoGio > 0
                                                    AND SoGio <= 24),
            NguoiLap NVARCHAR (120) NOT NULL
        );

        CREATE TABLE dbo.ChiTietPhuTroi (
            SoPhieu VARCHAR (20)   NOT NULL FOREIGN KEY REFERENCES dbo.PhieuPhuTroi (SoPhieu),
            MaNV    VARCHAR (20)   NOT NULL FOREIGN KEY REFERENCES dbo.NhanVien (MaNV),
            SoGio   DECIMAL (5, 2) NOT NULL CHECK (SoGio > 0
                                                   AND SoGio <= 24),
            PRIMARY KEY (SoPhieu, MaNV)
        );

        CREATE TABLE dbo.QuyetDinhThuongPhat (
            SoQD     VARCHAR (20)    PRIMARY KEY,
            Loai     VARCHAR (10)    NOT NULL CHECK (Loai IN ('Thuong', 'Phat')),
            MaNV     VARCHAR (20)    NULL FOREIGN KEY REFERENCES dbo.NhanVien (MaNV),
            MaPB     VARCHAR (20)    NULL FOREIGN KEY REFERENCES dbo.PhongBan (MaPB),
            NgayQD   DATE            NOT NULL,
            KyApDung DATE            NOT NULL,
            NoiDung  NVARCHAR (1000) NOT NULL,
            SoTien   DECIMAL (18, 2) NOT NULL CHECK (SoTien > 0),
            HinhThuc VARCHAR (10)    NOT NULL CHECK (HinhThuc IN ('QuaLuong', 'TrucTiep')),
            NguoiKy  NVARCHAR (120)  NOT NULL,
            CHECK ((MaNV IS NOT NULL
                    AND MaPB IS NULL)
                   OR (MaNV IS NULL
                       AND MaPB IS NOT NULL))
        );

        CREATE TABLE dbo.BangLuong (
            MaBL     VARCHAR (20)   PRIMARY KEY,
            Thang    INT            NOT NULL CHECK (Thang BETWEEN 1 AND 12),
            Nam      INT            NOT NULL CHECK (Nam BETWEEN 2000 AND 2100),
            GioChuan DECIMAL (7, 2) NOT NULL CHECK (GioChuan > 0),
            NgayLap  DATETIME2      DEFAULT SYSDATETIME() NOT NULL,
            UNIQUE (Nam, Thang)
        );

        CREATE TABLE dbo.ChiTietThuongPhat (
            SoQD   VARCHAR (20)    NOT NULL FOREIGN KEY REFERENCES dbo.QuyetDinhThuongPhat (SoQD),
            MaNV   VARCHAR (20)    NOT NULL FOREIGN KEY REFERENCES dbo.NhanVien (MaNV),
            SoTien DECIMAL (18, 2) NOT NULL CHECK (SoTien > 0),
            MaBL   VARCHAR (20)    NULL FOREIGN KEY REFERENCES dbo.BangLuong (MaBL),
            PRIMARY KEY (SoQD, MaNV)
        );

        CREATE TABLE dbo.PhieuThuChi (
            SoPhieu VARCHAR (20)    PRIMARY KEY,
            SoQD    VARCHAR (20)    NOT NULL UNIQUE FOREIGN KEY REFERENCES dbo.QuyetDinhThuongPhat (SoQD),
            Ngay    DATE            NOT NULL,
            Loai    VARCHAR (3)     NOT NULL CHECK (Loai IN ('Thu', 'Chi')),
            SoTien  DECIMAL (18, 2) NOT NULL CHECK (SoTien > 0),
            MaBL    VARCHAR (20)    NULL FOREIGN KEY REFERENCES dbo.BangLuong (MaBL)
        );

        CREATE TABLE dbo.ChiTietBangLuong (
            MaBL          VARCHAR (20)    NOT NULL FOREIGN KEY REFERENCES dbo.BangLuong (MaBL),
            MaNV          VARCHAR (20)    NOT NULL FOREIGN KEY REFERENCES dbo.NhanVien (MaNV),
            GioThuong     DECIMAL (9, 2)  NOT NULL CHECK (GioThuong >= 0),
            GioPhuTroi    DECIMAL (9, 2)  NOT NULL CHECK (GioPhuTroi >= 0),
            LuongTheoCong DECIMAL (18, 2) NOT NULL CHECK (LuongTheoCong >= 0),
            TienPhuTroi   DECIMAL (18, 2) NOT NULL CHECK (TienPhuTroi >= 0),
            TruBHXH       DECIMAL (18, 2) NOT NULL CHECK (TruBHXH >= 0),
            TruBHYT       DECIMAL (18, 2) NOT NULL CHECK (TruBHYT >= 0),
            TienThuong    DECIMAL (18, 2) NOT NULL CHECK (TienThuong >= 0),
            TienPhat      DECIMAL (18, 2) NOT NULL CHECK (TienPhat >= 0),
            ThucLinh      DECIMAL (18, 2) NOT NULL CHECK (ThucLinh >= 0),
            PRIMARY KEY (MaBL, MaNV)
        );

        INSERT INTO dbo.PhongBan
        VALUES ('PB01', N'Phòng kỹ thuật'),
        ('PB02', N'Phòng sản xuất');

        INSERT INTO dbo.ChucVu
        VALUES ('CV01', N'Nhân viên'),
        ('CV02', N'Trưởng phòng');

        INSERT INTO dbo.CaLam
        VALUES ('CA01', N'Ca ngày', 8),
        ('CA02', N'Ca tối', 8);
    END;

    -- PHAN 2. DU LIEU MAU
    -- Chi nap khi chua co nhan vien; chay lai khong tao trung.
    -- Ty le BHXH 10% va BHYT 2% la du lieu gia lap cho bai LAB.
    IF EXISTS (SELECT 1 FROM dbo.NhanVien WITH (TABLOCKX, HOLDLOCK))
    BEGIN
        COMMIT TRANSACTION;
        PRINT N'CSDL da co nhan vien. Giu nguyen du lieu, khong nap lai bo mau.';
        RETURN;
    END;

    IF NOT EXISTS (SELECT 1 FROM dbo.PhongBan WHERE MaPB = 'PB01')
        INSERT INTO dbo.PhongBan (MaPB, TenPB)
        VALUES ('PB01', N'Phòng kỹ thuật');

    IF NOT EXISTS (SELECT 1 FROM dbo.PhongBan WHERE MaPB = 'PB02')
        INSERT INTO dbo.PhongBan (MaPB, TenPB)
        VALUES ('PB02', N'Phòng sản xuất');

    IF NOT EXISTS (SELECT 1 FROM dbo.ChucVu WHERE MaCV = 'CV01')
        INSERT INTO dbo.ChucVu (MaCV, TenCV)
        VALUES ('CV01', N'Nhân viên');

    IF NOT EXISTS (SELECT 1 FROM dbo.ChucVu WHERE MaCV = 'CV02')
        INSERT INTO dbo.ChucVu (MaCV, TenCV)
        VALUES ('CV02', N'Trưởng phòng');

    IF NOT EXISTS (SELECT 1 FROM dbo.CaLam WHERE MaCa = 'CA01')
        INSERT INTO dbo.CaLam (MaCa, TenCa, GioChuan)
        VALUES ('CA01', N'Ca ngày', 8);

    -- 1. Ho so nhan vien va quyet dinh thu viec
    INSERT INTO dbo.NhanVien (
        MaNV, HoTen, NgaySinh, DienThoai, DiaChi, MaPB, TrangThai
    )
    VALUES
        ('NV001', N'Trần Minh An', '1995-03-12', '0900000001', N'TP. Hồ Chí Minh', 'PB01', 'ChinhThuc'),
        ('NV002', N'Nguyễn Thị Bích', '1998-07-20', '0900000002', N'TP. Hồ Chí Minh', 'PB01', 'ChinhThuc'),
        ('NV003', N'Lê Quốc Cường', '1990-11-05', '0900000003', N'Bình Dương', 'PB02', 'ChinhThuc'),
        ('NV004', N'Phạm Thu Dung', '1997-02-18', '0900000004', N'Đồng Nai', 'PB02', 'ChinhThuc'),
        ('NV005', N'Võ Gia Huy', '2001-06-09', '0900000005', N'TP. Hồ Chí Minh', 'PB01', 'ThuViec');

    INSERT INTO dbo.QuyetDinhTuyenDung (
        SoQD, MaNV, NgayQD, TuNgay, DenNgay,
        LuongThuViec, DieuKhoan, NguoiKy, KetQua
    )
    VALUES
        ('TD001', 'NV001', '2026-06-29', '2026-07-01', '2026-07-31', 3000000,
         N'Dữ liệu mẫu LAB7 - thử việc phòng kỹ thuật', N'Giám đốc (mẫu)', 'Dat'),
        ('TD002', 'NV002', '2026-06-29', '2026-07-01', '2026-07-31', 2800000,
         N'Dữ liệu mẫu LAB7 - thử việc phòng kỹ thuật', N'Giám đốc (mẫu)', 'Dat'),
        ('TD003', 'NV003', '2026-06-29', '2026-07-01', '2026-07-31', 5000000,
         N'Dữ liệu mẫu LAB7 - thử việc phòng sản xuất', N'Giám đốc (mẫu)', 'Dat'),
        ('TD004', 'NV004', '2026-06-29', '2026-07-01', '2026-07-31', 3200000,
         N'Dữ liệu mẫu LAB7 - thử việc phòng sản xuất', N'Giám đốc (mẫu)', 'Dat'),
        ('TD005', 'NV005', '2026-09-28', '2026-10-01', '2026-10-31', 3000000,
         N'Dữ liệu mẫu LAB7 - đang thử việc, chưa ký hợp đồng', N'Giám đốc (mẫu)', 'ChoDanhGia');

    -- 2. Hop dong, bao hiem va quyet dinh ban dau
    INSERT INTO dbo.HopDong (
        SoHD, MaNV, LoaiHD, NgayKy, TuNgay, DenNgay, DieuKhoan, NguoiKy
    )
    VALUES
        ('HD001', 'NV001', 'DaiHan', '2026-08-01', '2026-08-01', NULL,
         N'Dữ liệu mẫu LAB7 - hợp đồng dài hạn', N'Giám đốc (mẫu)'),
        ('HD002', 'NV002', 'NganHan', '2026-08-01', '2026-08-01', '2027-01-31',
         N'Dữ liệu mẫu LAB7 - hợp đồng ngắn hạn', N'Giám đốc (mẫu)'),
        ('HD003', 'NV003', 'DaiHan', '2026-08-01', '2026-08-01', NULL,
         N'Dữ liệu mẫu LAB7 - hợp đồng dài hạn', N'Giám đốc (mẫu)'),
        ('HD004', 'NV004', 'NganHan', '2026-08-01', '2026-08-01', '2027-01-31',
         N'Dữ liệu mẫu LAB7 - hợp đồng ngắn hạn', N'Giám đốc (mẫu)');

    INSERT INTO dbo.HoSoBaoHiem (SoHD, MaBHXH, MaBHYT, TyLeBHXH, TyLeBHYT)
    VALUES
        ('HD001', 'BHXH-MAU-001', 'BHYT-MAU-001', 0.10, 0.02),
        ('HD003', 'BHXH-MAU-003', 'BHYT-MAU-003', 0.10, 0.02);

    INSERT INTO dbo.QuyetDinhLuong (
        SoQD, MaNV, NgayHieuLuc, LuongCoBan, PhuCapLuong, PhuCapDocHai, NguoiKy
    )
    VALUES
        ('L001', 'NV001', '2026-08-01', 4160000, 208000, 208000, N'Giám đốc (mẫu)'),
        ('L002', 'NV002', '2026-08-01', 3900000, 200000, 0, N'Giám đốc (mẫu)'),
        ('L003', 'NV003', '2026-08-01', 7500000, 500000, 250000, N'Giám đốc (mẫu)'),
        ('L004', 'NV004', '2026-08-01', 4800000, 300000, 150000, N'Giám đốc (mẫu)');

    INSERT INTO dbo.QuyetDinhChucVu (
        SoQD, MaNV, MaCV, NgayHieuLuc, PhuCapChucVu, NguoiKy
    )
    VALUES
        ('CV001', 'NV001', 'CV01', '2026-08-01', 208000, N'Giám đốc (mẫu)'),
        ('CV002', 'NV002', 'CV01', '2026-08-01', 0, N'Giám đốc (mẫu)'),
        ('CV003', 'NV003', 'CV02', '2026-08-01', 1000000, N'Giám đốc (mẫu)'),
        ('CV004', 'NV004', 'CV01', '2026-08-01', 0, N'Giám đốc (mẫu)');

    -- 3. Ke hoach tuan, phan ca va cham cong thang 09/2026
    DECLARE @DauTuan date = '2026-08-31';
    DECLARE @Ngay date = '2026-09-01';

    WHILE @DauTuan <= '2026-09-28'
    BEGIN
        INSERT INTO dbo.KeHoachTuan (MaKH, MaPB, NgayDauTuan, NguoiLap)
        VALUES
            ('KH' + CONVERT(char(8), @DauTuan, 112) + 'PB01', 'PB01', @DauTuan, N'Trưởng phòng kỹ thuật (mẫu)'),
            ('KH' + CONVERT(char(8), @DauTuan, 112) + 'PB02', 'PB02', @DauTuan, N'Trưởng phòng sản xuất (mẫu)');

        SET @DauTuan = DATEADD(day, 7, @DauTuan);
    END;

    WHILE @Ngay <= '2026-09-30'
    BEGIN
        IF DATEPART(weekday, @Ngay) BETWEEN 1 AND 5
        BEGIN
            SET @DauTuan = DATEADD(day, 1 - DATEPART(weekday, @Ngay), @Ngay);

            INSERT INTO dbo.PhanCongCa (
                MaKH, MaNV, Ngay, MaCa, GioPhuTroiDuKien, HinhThuc
            )
            SELECT
                'KH' + CONVERT(char(8), @DauTuan, 112) + MaPB,
                MaNV,
                @Ngay,
                'CA01',
                CASE
                    WHEN MaNV = 'NV001' AND @Ngay IN ('2026-09-02', '2026-09-15', '2026-09-22') THEN 2
                    WHEN MaNV = 'NV003' AND @Ngay = '2026-09-18' THEN 3
                    ELSE 0
                END,
                CASE
                    WHEN MaNV = 'NV001' AND @Ngay = '2026-09-02' THEN 'NgayLe'
                    WHEN MaNV = 'NV001' AND @Ngay IN ('2026-09-15', '2026-09-22') THEN 'TangCa'
                    WHEN MaNV = 'NV003' AND @Ngay = '2026-09-18' THEN 'TangCa'
                    ELSE NULL
                END
            FROM dbo.NhanVien
            WHERE MaNV IN ('NV001', 'NV002', 'NV003', 'NV004');

            INSERT INTO dbo.ChamCong (IdPhanCong, GioThucTe, NguoiCham)
            SELECT
                Id,
                CASE
                    WHEN MaNV = 'NV002' AND @Ngay = '2026-09-10' THEN 4
                    WHEN MaNV = 'NV004' AND @Ngay IN ('2026-09-21', '2026-09-22') THEN 0
                    ELSE 8
                END,
                N'Ban chấm công (mẫu)'
            FROM dbo.PhanCongCa
            WHERE Ngay = @Ngay;
        END;

        SET @Ngay = DATEADD(day, 1, @Ngay);
    END;

    INSERT INTO dbo.PhieuPhuTroi (SoPhieu, Ngay, HinhThuc, SoGio, NguoiLap)
    VALUES
        ('PT001', '2026-09-02', 'NgayLe', 2, N'Ban chấm công (mẫu)'),
        ('PT002', '2026-09-15', 'TangCa', 2, N'Ban chấm công (mẫu)'),
        ('PT003', '2026-09-22', 'TangCa', 2, N'Ban chấm công (mẫu)'),
        ('PT004', '2026-09-18', 'TangCa', 3, N'Ban chấm công (mẫu)');

    INSERT INTO dbo.ChiTietPhuTroi (SoPhieu, MaNV, SoGio)
    VALUES
        ('PT001', 'NV001', 2),
        ('PT002', 'NV001', 2),
        ('PT003', 'NV001', 2),
        ('PT004', 'NV003', 3);

    -- 4. Thuong/phat ca nhan, tap the va thu/chi truc tiep
    INSERT INTO dbo.QuyetDinhThuongPhat (
        SoQD, Loai, MaNV, MaPB, NgayQD, KyApDung,
        NoiDung, SoTien, HinhThuc, NguoiKy
    )
    VALUES
        ('KT001', 'Thuong', 'NV001', NULL, '2026-09-25', '2026-09-01',
         N'Dữ liệu mẫu - thưởng sáng kiến kỹ thuật', 100000, 'QuaLuong', N'Giám đốc (mẫu)'),
        ('KT002', 'Thuong', NULL, 'PB01', '2026-09-25', '2026-09-01',
         N'Dữ liệu mẫu - thưởng tập thể phòng kỹ thuật', 150000, 'QuaLuong', N'Giám đốc (mẫu)'),
        ('KT003', 'Thuong', NULL, 'PB02', '2026-09-25', '2026-09-01',
         N'Dữ liệu mẫu - thưởng tập thể phòng sản xuất', 250000, 'QuaLuong', N'Giám đốc (mẫu)'),
        ('KL001', 'Phat', 'NV002', NULL, '2026-09-25', '2026-09-01',
         N'Dữ liệu mẫu - kỷ luật vi phạm nội quy', 50000, 'QuaLuong', N'Giám đốc (mẫu)'),
        ('KT004', 'Thuong', 'NV004', NULL, '2026-09-25', '2026-09-01',
         N'Dữ liệu mẫu - chi thưởng trực tiếp', 70000, 'TrucTiep', N'Giám đốc (mẫu)'),
        ('KL002', 'Phat', 'NV003', NULL, '2026-09-25', '2026-09-01',
         N'Dữ liệu mẫu - thu phạt trực tiếp', 30000, 'TrucTiep', N'Giám đốc (mẫu)');

    INSERT INTO dbo.ChiTietThuongPhat (SoQD, MaNV, SoTien)
    VALUES
        ('KT001', 'NV001', 100000),
        ('KT002', 'NV001', 50000),
        ('KT002', 'NV002', 100000),
        ('KT003', 'NV003', 150000),
        ('KT003', 'NV004', 100000),
        ('KL001', 'NV002', 50000),
        ('KT004', 'NV004', 70000),
        ('KL002', 'NV003', 30000);

    INSERT INTO dbo.PhieuThuChi (SoPhieu, SoQD, Ngay, Loai, SoTien)
    VALUES
        ('CHI001', 'KT004', '2026-09-26', 'Chi', 70000),
        ('THU001', 'KL002', '2026-09-26', 'Thu', 30000);

    -- 5. Bang luong mau da chot (22 ngay x 8 gio = 176 gio chuan)
    -- Cac ket qua duoi day duoc doi chieu voi BangLuongService.Lap.
    INSERT INTO dbo.BangLuong (MaBL, Thang, Nam, GioChuan, NgayLap)
    VALUES ('BL0926', 9, 2026, 176, '2026-10-01');

    INSERT INTO dbo.ChiTietBangLuong (
        MaBL, MaNV, GioThuong, GioPhuTroi, LuongTheoCong, TienPhuTroi,
        TruBHXH, TruBHYT, TienThuong, TienPhat, ThucLinh
    )
    VALUES
        ('BL0926', 'NV001', 176, 6, 4784000, 212727, 416000, 83200, 150000, 0, 4647527),
        ('BL0926', 'NV002', 172, 0, 4006818, 0, 0, 0, 100000, 50000, 4056818),
        ('BL0926', 'NV003', 176, 3, 9250000, 191761, 750000, 150000, 150000, 0, 8691761),
        ('BL0926', 'NV004', 160, 0, 4772727, 0, 0, 0, 100000, 0, 4872727),
        ('BL0926', 'NV005', 0, 0, 0, 0, 0, 0, 0, 0, 0);

    UPDATE ct
    SET MaBL = 'BL0926'
    FROM dbo.ChiTietThuongPhat AS ct
    INNER JOIN dbo.QuyetDinhThuongPhat AS qd ON qd.SoQD = ct.SoQD
    WHERE qd.HinhThuc = 'QuaLuong';

    INSERT INTO dbo.PhieuThuChi (SoPhieu, SoQD, Ngay, Loai, SoTien, MaBL)
    VALUES
        ('CHI-LUONG001', 'KT001', '2026-10-01', 'Chi', 100000, 'BL0926'),
        ('CHI-LUONG002', 'KT002', '2026-10-01', 'Chi', 150000, 'BL0926'),
        ('CHI-LUONG003', 'KT003', '2026-10-01', 'Chi', 250000, 'BL0926'),
        ('THU-LUONG001', 'KL001', '2026-10-01', 'Thu', 50000, 'BL0926');

    COMMIT TRANSACTION;

    PRINT N'Da khoi tao LAB7: 19 bang va du lieu mau. Thang 09/2026 da chot; thang 10/2026 chua chot.';

    -- Ket qua de doi chieu sau khi chay.
    SELECT MaNV, HoTen, TrangThai
    FROM dbo.NhanVien
    ORDER BY MaNV;

    SELECT MaBL, MaNV, GioThuong, GioPhuTroi, ThucLinh
    FROM dbo.ChiTietBangLuong
    WHERE MaBL = 'BL0926'
    ORDER BY MaNV;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION;
    END;

    THROW;
END CATCH;
