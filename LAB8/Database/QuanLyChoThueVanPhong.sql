/* =====================================================================
   ĐẠI HỌC CÔNG NGHỆ TP.HCM (HUTECH)
   THỰC HÀNH PHÂN TÍCH THIẾT KẾ HƯỚNG ĐỐI TƯỢNG (OOSD)
   BÀI 4: QUẢN LÝ CHO THUÊ VĂN PHÒNG Ở CAO ỐC
   Sinh viên: Trần Văn Hiếu - MSSV: 1250080054
   Script tạo CSDL QuanLyChoThueVanPhong (SQL Server / LocalDB)
   ===================================================================== */

IF DB_ID(N'QuanLyChoThueVanPhong') IS NULL 
    CREATE DATABASE QuanLyChoThueVanPhong;
GO

USE QuanLyChoThueVanPhong;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

-- Xóa đối tượng cũ nếu đã có theo thứ tự khóa ngoại
IF OBJECT_ID('dbo.sp_LapPhieuGiaHan', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_LapPhieuGiaHan;
IF OBJECT_ID('dbo.sp_LapHopDongThue', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_LapHopDongThue;
IF OBJECT_ID('dbo.sp_ThanhToanTienThue', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_ThanhToanTienThue;
IF OBJECT_ID('dbo.sp_ThanhToanDichVu', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_ThanhToanDichVu;

IF OBJECT_ID('dbo.BienBanXuPhat', 'U') IS NOT NULL DROP TABLE dbo.BienBanXuPhat;
IF OBJECT_ID('dbo.KiemTraPhong', 'U') IS NOT NULL DROP TABLE dbo.KiemTraPhong;
IF OBJECT_ID('dbo.TheGiuXe', 'U') IS NOT NULL DROP TABLE dbo.TheGiuXe;
IF OBJECT_ID('dbo.NhanVienVanPhong', 'U') IS NOT NULL DROP TABLE dbo.NhanVienVanPhong;
IF OBJECT_ID('dbo.PhieuGiaHan', 'U') IS NOT NULL DROP TABLE dbo.PhieuGiaHan;
IF OBJECT_ID('dbo.ChiTietHoaDonDichVu', 'U') IS NOT NULL DROP TABLE dbo.ChiTietHoaDonDichVu;
IF OBJECT_ID('dbo.HoaDonDichVu', 'U') IS NOT NULL DROP TABLE dbo.HoaDonDichVu;
IF OBJECT_ID('dbo.DichVu', 'U') IS NOT NULL DROP TABLE dbo.DichVu;
IF OBJECT_ID('dbo.HoaDonTienThue', 'U') IS NOT NULL DROP TABLE dbo.HoaDonTienThue;
IF OBJECT_ID('dbo.ChiTietHopDong', 'U') IS NOT NULL DROP TABLE dbo.ChiTietHopDong;
IF OBJECT_ID('dbo.HopDongThue', 'U') IS NOT NULL DROP TABLE dbo.HopDongThue;
IF OBJECT_ID('dbo.KhachHang', 'U') IS NOT NULL DROP TABLE dbo.KhachHang;
IF OBJECT_ID('dbo.Phong', 'U') IS NOT NULL DROP TABLE dbo.Phong;
IF OBJECT_ID('dbo.Tang', 'U') IS NOT NULL DROP TABLE dbo.Tang;
GO

/* =====================================================================
   1. ĐẶC TẢ CÁC BẢNG DỮ LIỆU (14 BẢNG CHUẨN 3NF)
   ===================================================================== */

-- 1. Bảng Tầng (Quản lý các tầng trong cao ốc, độ cao, hệ số giá)
CREATE TABLE dbo.Tang (
    MaTang varchar(20) NOT NULL PRIMARY KEY,
    TenTang nvarchar(100) NOT NULL,
    DoCaoTang int NOT NULL DEFAULT 1 CHECK(DoCaoTang > 0),
    HeSoGia decimal(4,2) NOT NULL DEFAULT 1.00 CHECK(HeSoGia > 0),
    GhiChu nvarchar(250) NULL
);

-- 2. Bảng Phòng (Văn phòng cho thuê, diện tích, hướng, đơn giá)
CREATE TABLE dbo.Phong (
    MaPhong varchar(20) NOT NULL PRIMARY KEY,
    MaTang varchar(20) NOT NULL REFERENCES dbo.Tang(MaTang),
    TenPhong nvarchar(100) NOT NULL,
    DienTich decimal(10,2) NOT NULL CHECK(DienTich > 0),
    Huong nvarchar(50) NOT NULL,
    DonGiaCoBan decimal(18,2) NOT NULL CHECK(DonGiaCoBan > 0),
    TrangThai nvarchar(50) NOT NULL DEFAULT N'Trống' CHECK(TrangThai IN (N'Trống', N'Đang thuê', N'Bảo trì'))
);

-- 3. Bảng Khách hàng (Doanh nghiệp hoặc cá nhân thuê văn phòng)
CREATE TABLE dbo.KhachHang (
    MaKH varchar(20) NOT NULL PRIMARY KEY,
    TenCongTy nvarchar(200) NOT NULL,
    NguoiDaiDien nvarchar(120) NOT NULL,
    MaSoThue varchar(30) NULL,
    DienThoai varchar(20) NOT NULL,
    Email varchar(100) NULL,
    DiaChiTruSo nvarchar(250) NOT NULL
);

-- 4. Bảng Hợp đồng thuê văn phòng (Thời hạn thuê tối thiểu 6 tháng)
CREATE TABLE dbo.HopDongThue (
    MaHD varchar(20) NOT NULL PRIMARY KEY,
    MaKH varchar(20) NOT NULL REFERENCES dbo.KhachHang(MaKH),
    NgayKy date NOT NULL DEFAULT CAST(SYSDATETIME() AS date),
    NgayBatDau date NOT NULL,
    NgayKetThuc date NOT NULL,
    ThoiHanThueThang int NOT NULL CHECK(ThoiHanThueThang >= 6),
    TienDatCoc decimal(18,2) NOT NULL DEFAULT 0 CHECK(TienDatCoc >= 0),
    TongTienThang decimal(18,2) NOT NULL DEFAULT 0 CHECK(TongTienThang >= 0),
    TienTraTruoc6Thang decimal(18,2) NOT NULL DEFAULT 0 CHECK(TienTraTruoc6Thang >= 0),
    TrangThai nvarchar(50) NOT NULL DEFAULT N'Hiệu lực' CHECK(TrangThai IN (N'Hiệu lực', N'Đã thanh lý', N'Đã gia hạn')),
    GhiChu nvarchar(500) NULL,
    CONSTRAINT CK_NgayThue CHECK(NgayKetThuc > NgayBatDau)
);

-- 5. Bảng Chi tiết hợp đồng (Khách hàng có thể thuê cùng lúc nhiều văn phòng)
CREATE TABLE dbo.ChiTietHopDong (
    MaHD varchar(20) NOT NULL REFERENCES dbo.HopDongThue(MaHD) ON DELETE CASCADE,
    MaPhong varchar(20) NOT NULL REFERENCES dbo.Phong(MaPhong),
    DienTichThue decimal(10,2) NOT NULL CHECK(DienTichThue > 0),
    DonGiaThueThang decimal(18,2) NOT NULL CHECK(DonGiaThueThang > 0),
    ThanhTienThang AS (DienTichThue * DonGiaThueThang) PERSISTED,
    PRIMARY KEY (MaHD, MaPhong)
);

-- 6. Bảng Hóa đơn tiền thuê (6 tháng đầu trả trước; từ tháng 7+ trả đầu tháng)
CREATE TABLE dbo.HoaDonTienThue (
    MaHDTT varchar(20) NOT NULL PRIMARY KEY,
    MaHD varchar(20) NOT NULL REFERENCES dbo.HopDongThue(MaHD),
    KyThanhToan nvarchar(100) NOT NULL,
    Thang int NOT NULL CHECK(Thang BETWEEN 1 AND 12),
    Nam int NOT NULL CHECK(Nam >= 2020),
    SoTien decimal(18,2) NOT NULL CHECK(SoTien > 0),
    NgayHenTra date NOT NULL,
    NgayThanhToan datetime2 NULL,
    DaThanhToan bit NOT NULL DEFAULT 0,
    GhiChu nvarchar(250) NULL
);

-- 7. Bảng Dịch vụ (Điện, nước, internet, vệ sinh, giữ xe...)
CREATE TABLE dbo.DichVu (
    MaDV varchar(20) NOT NULL PRIMARY KEY,
    TenDV nvarchar(100) NOT NULL UNIQUE,
    DonViTinh nvarchar(30) NOT NULL,
    DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0),
    LoaiDV nvarchar(50) NOT NULL
);

-- 8. Bảng Hóa đơn dịch vụ (Thanh toán vào cuối tháng)
CREATE TABLE dbo.HoaDonDichVu (
    MaHDDV varchar(20) NOT NULL PRIMARY KEY,
    MaHD varchar(20) NOT NULL REFERENCES dbo.HopDongThue(MaHD),
    MaPhong varchar(20) NOT NULL REFERENCES dbo.Phong(MaPhong),
    Thang int NOT NULL CHECK(Thang BETWEEN 1 AND 12),
    Nam int NOT NULL CHECK(Nam >= 2020),
    NgayLap date NOT NULL DEFAULT CAST(SYSDATETIME() AS date),
    NgayHenTra date NOT NULL,
    TongTien decimal(18,2) NOT NULL DEFAULT 0 CHECK(TongTien >= 0),
    DaThanhToan bit NOT NULL DEFAULT 0,
    NgayThanhToan datetime2 NULL,
    GhiChu nvarchar(250) NULL,
    CONSTRAINT UQ_HoaDonDV UNIQUE(MaHD, MaPhong, Thang, Nam)
);

-- 9. Bảng Chi tiết hóa đơn dịch vụ
CREATE TABLE dbo.ChiTietHoaDonDichVu (
    MaHDDV varchar(20) NOT NULL REFERENCES dbo.HoaDonDichVu(MaHDDV) ON DELETE CASCADE,
    MaDV varchar(20) NOT NULL REFERENCES dbo.DichVu(MaDV),
    ChiSoDau decimal(10,2) NULL,
    ChiSoCuoi decimal(10,2) NULL,
    SoLuong decimal(10,2) NOT NULL CHECK(SoLuong > 0),
    DonGia decimal(18,2) NOT NULL CHECK(DonGia >= 0),
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    PRIMARY KEY (MaHDDV, MaDV)
);

-- 10. Bảng Phiếu gia hạn (Gia hạn <= 1/2 thời gian thuê và không nợ)
CREATE TABLE dbo.PhieuGiaHan (
    MaPGH varchar(20) NOT NULL PRIMARY KEY,
    MaHD varchar(20) NOT NULL REFERENCES dbo.HopDongThue(MaHD),
    MaPhong varchar(20) NOT NULL REFERENCES dbo.Phong(MaPhong),
    NgayGiaHan date NOT NULL DEFAULT CAST(SYSDATETIME() AS date),
    SoThangGiaHan int NOT NULL CHECK(SoThangGiaHan > 0),
    NgayBatDauMoi date NOT NULL,
    NgayKetThucMoi date NOT NULL,
    DonGiaMoi decimal(18,2) NOT NULL CHECK(DonGiaMoi > 0),
    TongTienGiaHan decimal(18,2) NOT NULL CHECK(TongTienGiaHan > 0),
    TrangThai nvarchar(50) NOT NULL DEFAULT N'Đã duyệt' CHECK(TrangThai IN (N'Chờ duyệt', N'Đã duyệt', N'Từ chối')),
    GhiChu nvarchar(250) NULL
);

-- 11. Bảng Nhân viên văn phòng (Công ty báo cáo nhân viên cho ban quản lý cao ốc)
CREATE TABLE dbo.NhanVienVanPhong (
    MaNVVP varchar(20) NOT NULL PRIMARY KEY,
    MaKH varchar(20) NOT NULL REFERENCES dbo.KhachHang(MaKH),
    MaPhong varchar(20) NOT NULL REFERENCES dbo.Phong(MaPhong),
    HoTen nvarchar(120) NOT NULL,
    NgaySinh date NOT NULL,
    GioiTinh nvarchar(10) NOT NULL CHECK(GioiTinh IN (N'Nam', N'Nữ')),
    CCCD varchar(20) NOT NULL UNIQUE,
    DienThoai varchar(20) NOT NULL,
    ChucVu nvarchar(100) NOT NULL,
    HinhAnh nvarchar(250) NULL,
    NgayBaoCao date NOT NULL DEFAULT CAST(SYSDATETIME() AS date),
    DangLamViec bit NOT NULL DEFAULT 1
);

-- 12. Bảng Thẻ giữ xe (Cấp cho nhân viên làm việc tại văn phòng)
CREATE TABLE dbo.TheGiuXe (
    MaThe varchar(20) NOT NULL PRIMARY KEY,
    MaNVVP varchar(20) NOT NULL REFERENCES dbo.NhanVienVanPhong(MaNVVP),
    BienSoXe varchar(20) NOT NULL,
    LoaiXe nvarchar(30) NOT NULL CHECK(LoaiXe IN (N'Xe máy', N'Ô tô', N'Xe đạp điện')),
    NhanHieu nvarchar(50) NULL,
    MauXe nvarchar(30) NULL,
    NgayCap date NOT NULL DEFAULT CAST(SYSDATETIME() AS date),
    TrangThai nvarchar(50) NOT NULL DEFAULT N'Hoạt động' CHECK(TrangThai IN (N'Hoạt động', N'Bị khóa', N'Đã thu hồi')),
    GhiChu nvarchar(250) NULL
);

-- 13. Bảng Kiểm tra phòng (Định kỳ cách 1 năm kiểm tra tình trạng kết cấu)
CREATE TABLE dbo.KiemTraPhong (
    MaPhieuKT varchar(20) NOT NULL PRIMARY KEY,
    MaPhong varchar(20) NOT NULL REFERENCES dbo.Phong(MaPhong),
    NgayKiemTra date NOT NULL DEFAULT CAST(SYSDATETIME() AS date),
    NguoiKiemTra nvarchar(120) NOT NULL,
    TinhTrangKetCau nvarchar(250) NOT NULL,
    TinhTrangNoiThat nvarchar(250) NULL,
    CoViPham bit NOT NULL DEFAULT 0,
    GhiChuTuSua nvarchar(500) NULL
);

-- 14. Bảng Biên bản xử phạt (Xử phạt tự ý thay đổi, chỉnh sửa kết cấu văn phòng)
CREATE TABLE dbo.BienBanXuPhat (
    MaBienBan varchar(20) NOT NULL PRIMARY KEY,
    MaPhieuKT varchar(20) NOT NULL REFERENCES dbo.KiemTraPhong(MaPhieuKT),
    MaHD varchar(20) NOT NULL REFERENCES dbo.HopDongThue(MaHD),
    MaPhong varchar(20) NOT NULL REFERENCES dbo.Phong(MaPhong),
    NgayLap date NOT NULL DEFAULT CAST(SYSDATETIME() AS date),
    HanhViViPham nvarchar(500) NOT NULL,
    SoTienPhat decimal(18,2) NOT NULL CHECK(SoTienPhat > 0),
    HanNopPhat date NOT NULL,
    DaNopPhat bit NOT NULL DEFAULT 0,
    NgayNopPhat datetime2 NULL
);
GO

/* =====================================================================
   2. CÁC STORED PROCEDURES QUẢN LÝ GIAO DỊCH (TRANSACTION)
   ===================================================================== */

-- Thủ tục 1: Lập hợp đồng thuê văn phòng (nhiều phòng, tối thiểu 6 tháng, trả trước 6 tháng)
CREATE PROCEDURE dbo.sp_LapHopDongThue
    @MaHD varchar(20),
    @MaKH varchar(20),
    @NgayKy date,
    @NgayBatDau date,
    @ThoiHanThueThang int,
    @TienDatCoc decimal(18,2),
    @DanhSachPhong xml -- <root><item MaPhong="P101" DonGia="250000" /><item MaPhong="P102" DonGia="300000" /></root>
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    -- Kiểm tra quy tắc: Thời gian thuê ít nhất 6 tháng
    IF @ThoiHanThueThang < 6
    BEGIN
        RAISERROR(N'Quy định cao ốc: Thời hạn thuê tối thiểu phải từ 6 tháng trở lên!', 16, 1);
        RETURN;
    END

    -- Tính ngày kết thúc
    DECLARE @NgayKetThuc date = DATEADD(month, @ThoiHanThueThang, @NgayBatDau);

    BEGIN TRY
        BEGIN TRAN;

        -- Tạo bảng tạm chứa danh sách phòng thuê
        DECLARE @TblPhong TABLE (
            MaPhong varchar(20),
            DonGia decimal(18,2),
            DienTich decimal(10,2)
        );

        INSERT INTO @TblPhong (MaPhong, DonGia, DienTich)
        SELECT 
            T.Item.value('@MaPhong', 'varchar(20)'),
            T.Item.value('@DonGia', 'decimal(18,2)'),
            p.DienTich
        FROM @DanhSachPhong.nodes('/root/item') AS T(Item)
        JOIN dbo.Phong p ON p.MaPhong = T.Item.value('@MaPhong', 'varchar(20)');

        -- Kiểm tra có phòng nào không trống không
        IF EXISTS (SELECT 1 FROM dbo.Phong p JOIN @TblPhong t ON p.MaPhong = t.MaPhong WHERE p.TrangThai <> N'Trống')
        BEGIN
            RAISERROR(N'Một trong các phòng đã chọn hiện không ở trạng thái Trống!', 16, 1);
            ROLLBACK TRAN;
            RETURN;
        END

        -- Tính tổng tiền thuê 1 tháng cho tất cả các phòng
        DECLARE @TongTienThang decimal(18,2) = 0;
        SELECT @TongTienThang = SUM(DienTich * DonGia) FROM @TblPhong;

        -- Tiền trả trước 6 tháng đầu tiên
        DECLARE @TienTraTruoc6Thang decimal(18,2) = @TongTienThang * 6;

        -- 1. Thêm hợp đồng
        INSERT INTO dbo.HopDongThue (MaHD, MaKH, NgayKy, NgayBatDau, NgayKetThuc, ThoiHanThueThang, TienDatCoc, TongTienThang, TienTraTruoc6Thang, TrangThai)
        VALUES (@MaHD, @MaKH, @NgayKy, @NgayBatDau, @NgayKetThuc, @ThoiHanThueThang, @TienDatCoc, @TongTienThang, @TienTraTruoc6Thang, N'Hiệu lực');

        -- 2. Thêm chi tiết hợp đồng & Cập nhật trạng thái phòng sang 'Đang thuê'
        INSERT INTO dbo.ChiTietHopDong (MaHD, MaPhong, DienTichThue, DonGiaThueThang)
        SELECT @MaHD, MaPhong, DienTich, DonGia FROM @TblPhong;

        UPDATE dbo.Phong
        SET TrangThai = N'Đang thuê'
        WHERE MaPhong IN (SELECT MaPhong FROM @TblPhong);

        -- 3. Tự động sinh hóa đơn tiền thuê cho 6 tháng đầu tiên (đã trả trước)
        DECLARE @MaHDTT_6Thang varchar(20) = 'HDTT_' + @MaHD + '_6T';
        INSERT INTO dbo.HoaDonTienThue (MaHDTT, MaHD, KyThanhToan, Thang, Nam, SoTien, NgayHenTra, NgayThanhToan, DaThanhToan, GhiChu)
        VALUES (@MaHDTT_6Thang, @MaHD, N'Trả trước 6 tháng đầu tiên', MONTH(@NgayBatDau), YEAR(@NgayBatDau), @TienTraTruoc6Thang, @NgayBatDau, SYSDATETIME(), 1, N'Thanh toán trả trước 6 tháng lúc ký hợp đồng');

        -- 4. Nếu thời hạn thuê > 6 tháng, tự động sinh các đợt thanh toán từ tháng thứ 7 trở đi (trả đầu mỗi tháng)
        IF @ThoiHanThueThang > 6
        BEGIN
            DECLARE @i int = 7;
            WHILE @i <= @ThoiHanThueThang
            BEGIN
                DECLARE @NgayDauThang date = DATEADD(month, @i - 1, @NgayBatDau);
                DECLARE @MaHDTT_Thang varchar(20) = 'HDTT_' + @MaHD + '_T' + CAST(@i AS varchar);
                DECLARE @KyTen nvarchar(100) = N'Tiền thuê tháng thứ ' + CAST(@i AS nvarchar) + ' (Tháng ' + CAST(MONTH(@NgayDauThang) AS nvarchar) + '/' + CAST(YEAR(@NgayDauThang) AS nvarchar) + ')';

                INSERT INTO dbo.HoaDonTienThue (MaHDTT, MaHD, KyThanhToan, Thang, Nam, SoTien, NgayHenTra, NgayThanhToan, DaThanhToan, GhiChu)
                VALUES (@MaHDTT_Thang, @MaHD, @KyTen, MONTH(@NgayDauThang), YEAR(@NgayDauThang), @TongTienThang, @NgayDauThang, NULL, 0, N'Hạn thanh toán vào đầu tháng');

                SET @i = @i + 1;
            END
        END

        COMMIT TRAN;
        SELECT N'Thành công' AS KetQua, @TienTraTruoc6Thang AS TienTraTruoc6Thang, @TongTienThang AS TongTienThang;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRAN;
        DECLARE @ErrMsg nvarchar(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg, 16, 1);
    END CATCH
END;
GO

-- Thủ tục 2: Lập phiếu gia hạn hợp đồng (Kiểm tra <= 1/2 thời gian thuê và sạch nợ thuê + dịch vụ)
CREATE PROCEDURE dbo.sp_LapPhieuGiaHan
    @MaPGH varchar(20),
    @MaHD varchar(20),
    @MaPhong varchar(20),
    @SoThangGiaHan int,
    @DonGiaMoi decimal(18,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    -- Lấy thông tin hợp đồng hiện tại
    DECLARE @ThoiHanThueThang int, @NgayKetThuc date, @TrangThaiHD nvarchar(50);
    SELECT @ThoiHanThueThang = ThoiHanThueThang, @NgayKetThuc = NgayKetThuc, @TrangThaiHD = TrangThai
    FROM dbo.HopDongThue WHERE MaHD = @MaHD;

    IF @ThoiHanThueThang IS NULL
    BEGIN
        RAISERROR(N'Hợp đồng không tồn tại!', 16, 1);
        RETURN;
    END

    -- 1. Kiểm tra quy tắc gia hạn: Thời gian gia hạn <= 1/2 thời gian thuê ban đầu
    DECLARE @MaxGiaHan int = @ThoiHanThueThang / 2;
    IF @SoThangGiaHan > @MaxGiaHan
    BEGIN
        DECLARE @Msg1 nvarchar(250) = N'Thời gian gia hạn (' + CAST(@SoThangGiaHan AS nvarchar) + N' tháng) vượt quá 1/2 thời gian thuê ban đầu (Tối đa ' + CAST(@MaxGiaHan AS nvarchar) + N' tháng)!';
        RAISERROR(@Msg1, 16, 1);
        RETURN;
    END

    -- 2. Kiểm tra điều kiện sạch nợ tiền thuê mặt bằng
    IF EXISTS (SELECT 1 FROM dbo.HoaDonTienThue WHERE MaHD = @MaHD AND DaThanhToan = 0)
    BEGIN
        RAISERROR(N'Văn phòng thuê còn nợ tiền thuê mặt bằng chưa thanh toán. Không đủ điều kiện gia hạn!', 16, 1);
        RETURN;
    END

    -- 3. Kiểm tra điều kiện sạch nợ hóa đơn dịch vụ
    IF EXISTS (SELECT 1 FROM dbo.HoaDonDichVu WHERE MaHD = @MaHD AND DaThanhToan = 0)
    BEGIN
        RAISERROR(N'Văn phòng thuê còn nợ hóa đơn dịch vụ chưa thanh toán. Không đủ điều kiện gia hạn!', 16, 1);
        RETURN;
    END

    -- Lấy diện tích và đơn giá phòng
    DECLARE @DienTich decimal(10,2), @DonGiaCu decimal(18,2);
    SELECT @DienTich = DienTichThue, @DonGiaCu = DonGiaThueThang
    FROM dbo.ChiTietHopDong WHERE MaHD = @MaHD AND MaPhong = @MaPhong;

    IF @DonGiaMoi IS NULL OR @DonGiaMoi <= 0
        SET @DonGiaMoi = @DonGiaCu;

    DECLARE @TongTienGiaHan decimal(18,2) = @DienTich * @DonGiaMoi * @SoThangGiaHan;
    DECLARE @NgayBatDauMoi date = DATEADD(day, 1, @NgayKetThuc);
    DECLARE @NgayKetThucMoi date = DATEADD(month, @SoThangGiaHan, @NgayKetThuc);

    BEGIN TRY
        BEGIN TRAN;

        -- 1. Thêm phiếu gia hạn
        INSERT INTO dbo.PhieuGiaHan (MaPGH, MaHD, MaPhong, NgayGiaHan, SoThangGiaHan, NgayBatDauMoi, NgayKetThucMoi, DonGiaMoi, TongTienGiaHan, TrangThai)
        VALUES (@MaPGH, @MaHD, @MaPhong, CAST(SYSDATETIME() AS date), @SoThangGiaHan, @NgayBatDauMoi, @NgayKetThucMoi, @DonGiaMoi, @TongTienGiaHan, N'Đã duyệt');

        -- 2. Cập nhật ngày kết thúc của hợp đồng
        UPDATE dbo.HopDongThue
        SET NgayKetThuc = @NgayKetThucMoi,
            TrangThai = N'Đã gia hạn'
        WHERE MaHD = @MaHD;

        -- 3. Tạo các đợt thu tiền thuê cho các tháng gia hạn (thu vào đầu mỗi tháng)
        DECLARE @k int = 1;
        WHILE @k <= @SoThangGiaHan
        BEGIN
            DECLARE @NgayThu date = DATEADD(month, @k - 1, @NgayBatDauMoi);
            DECLARE @MaHDTT_GH varchar(20) = 'HDTT_' + @MaPGH + '_' + CAST(@k AS varchar);
            DECLARE @KyGH nvarchar(100) = N'Tiền thuê gia hạn tháng ' + CAST(@k AS nvarchar) + ' (Tháng ' + CAST(MONTH(@NgayThu) AS nvarchar) + '/' + CAST(YEAR(@NgayThu) AS nvarchar) + ')';
            DECLARE @Tien1Thang decimal(18,2) = @DienTich * @DonGiaMoi;

            INSERT INTO dbo.HoaDonTienThue (MaHDTT, MaHD, KyThanhToan, Thang, Nam, SoTien, NgayHenTra, NgayThanhToan, DaThanhToan, GhiChu)
            VALUES (@MaHDTT_GH, @MaHD, @KyGH, MONTH(@NgayThu), YEAR(@NgayThu), @Tien1Thang, @NgayThu, NULL, 0, N'Gia hạn theo phiếu ' + @MaPGH);

            SET @k = @k + 1;
        END

        COMMIT TRAN;
        SELECT N'Thành công' AS KetQua, @NgayKetThucMoi AS NgayKetThucMoi, @TongTienGiaHan AS TongTienGiaHan;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRAN;
        DECLARE @ErrMsg2 nvarchar(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrMsg2, 16, 1);
    END CATCH
END;
GO

-- Thủ tục 3: Thanh toán tiền thuê tháng thứ 7+ (trả vào đầu tháng)
CREATE PROCEDURE dbo.sp_ThanhToanTienThue
    @MaHDTT varchar(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.HoaDonTienThue WHERE MaHDTT = @MaHDTT)
    BEGIN
        RAISERROR(N'Hóa đơn tiền thuê không tồn tại!', 16, 1);
        RETURN;
    END

    UPDATE dbo.HoaDonTienThue
    SET DaThanhToan = 1,
        NgayThanhToan = SYSDATETIME()
    WHERE MaHDTT = @MaHDTT;

    SELECT N'Thanh toán tiền thuê thành công!' AS ThongBao;
END;
GO

-- Thủ tục 4: Thanh toán hóa đơn dịch vụ cuối tháng
CREATE PROCEDURE dbo.sp_ThanhToanDichVu
    @MaHDDV varchar(20)
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS (SELECT 1 FROM dbo.HoaDonDichVu WHERE MaHDDV = @MaHDDV)
    BEGIN
        RAISERROR(N'Hóa đơn dịch vụ không tồn tại!', 16, 1);
        RETURN;
    END

    UPDATE dbo.HoaDonDichVu
    SET DaThanhToan = 1,
        NgayThanhToan = SYSDATETIME()
    WHERE MaHDDV = @MaHDDV;

    SELECT N'Thanh toán dịch vụ thành công!' AS ThongBao;
END;
GO

/* =====================================================================
   3. NẠP DỮ LIỆU MẪU KIỂM THỬ BAN ĐẦU
   ===================================================================== */

-- 1. Nạp Tầng
INSERT INTO dbo.Tang (MaTang, TenTang, DoCaoTang, HeSoGia, GhiChu) VALUES
('T01', N'Tầng 1 (Trệt & Sảnh đón tiếp)', 1, 1.00, N'Thuận tiện giao dịch khách vãng lai'),
('T02', N'Tầng 2 (Khu tài chính - ngân hàng)', 2, 1.05, N'Độ cao vừa phải, lối đi thang cuốn'),
('T03', N'Tầng 3 (Khu công nghệ - phần mềm)', 3, 1.10, N'Yên tĩnh, hạ tầng cáp quang mạnh'),
('T04', N'Tầng 4 (Khu tập đoàn - đa quốc gia)', 4, 1.15, N'View thoáng, diện tích sàn lớn'),
('T05', N'Tầng 5 (Khu Penthouse - VIP)', 5, 1.25, N'Tầm nhìn toàn cảnh thành phố');

-- 2. Nạp Phòng
INSERT INTO dbo.Phong (MaPhong, MaTang, TenPhong, DienTich, Huong, DonGiaCoBan, TrangThai) VALUES
('P101', 'T01', N'Phòng 101', 80.00, N'Đông Nam', 350000, N'Trống'),
('P102', 'T01', N'Phòng 102', 120.00, N'Nam', 350000, N'Trống'),
('P201', 'T02', N'Phòng 201', 65.00, N'Đông', 380000, N'Trống'),
('P202', 'T02', N'Phòng 202', 90.00, N'Đông Nam', 380000, N'Trống'),
('P301', 'T03', N'Phòng 301', 100.00, N'Nam', 400000, N'Trống'),
('P302', 'T03', N'Phòng 302', 150.00, N'Đông', 400000, N'Trống'),
('P401', 'T04', N'Phòng 401', 200.00, N'Đông Nam', 450000, N'Trống'),
('P402', 'T04', N'Phòng 402', 180.00, N'Bắc', 430000, N'Trống'),
('P501', 'T05', N'Phòng 501 VIP', 250.00, N'Chính Nam', 500000, N'Trống');

-- 3. Nạp Dịch vụ
INSERT INTO dbo.DichVu (MaDV, TenDV, DonViTinh, DonGia, LoaiDV) VALUES
('DV_DIEN', N'Điện năng tiêu thụ', N'kWh', 3800, N'Điện'),
('DV_NUOC', N'Nước sinh hoạt', N'm3', 25000, N'Nước'),
('DV_INTERNET', N'Internet cáp quang doanh nghiệp', N'Tháng', 1200000, N'Internet'),
('DV_VESINH', N'Vệ sinh văn phòng định kỳ', N'Tháng', 1500000, N'Vệ sinh'),
('DV_GUIXE_MAY', N'Giữ xe máy nhân viên', N'Chiếc/Tháng', 150000, N'Gửi xe'),
('DV_GUIXE_OTO', N'Giữ ô tô nhân viên', N'Chiếc/Tháng', 1800000, N'Gửi xe');

-- 4. Nạp Khách hàng mẫu
INSERT INTO dbo.KhachHang (MaKH, TenCongTy, NguoiDaiDien, MaSoThue, DienThoai, Email, DiaChiTruSo) VALUES
('KH01', N'Công ty Cổ phần Công nghệ Sao Việt', N'Nguyễn Hoàng Nam', '0312456789', '0903123456', 'nam.nguyen@saoviet.vn', N'Tòa nhà Cao ốc, TP.HCM'),
('KH02', N'Tập đoàn Thương mại Dịch vụ Á Châu', N'Lê Thị Hương', '0319876543', '0908765432', 'huong.le@achaucorp.com', N'Quận 1, TP.HCM'),
('KH03', N'Công ty TNHH Tư vấn Thiết kế Kiến Trúc Xanh', N'Trần Minh Đức', '0301122334', '0912334455', 'duc.tran@kientrucxanh.vn', N'Bình Thạnh, TP.HCM');

-- 5. Thực thi mẫu hợp đồng thuê văn phòng (HĐ thuê 8 tháng, gồm phòng P301 và P302)
-- Sẽ tự động trả trước 6 tháng đầu và sinh hóa đơn tháng 7, 8
EXEC dbo.sp_LapHopDongThue
    @MaHD = 'HD001',
    @MaKH = 'KH01',
    @NgayKy = '2026-01-05',
    @NgayBatDau = '2026-01-15',
    @ThoiHanThueThang = 8,
    @TienDatCoc = 100000000,
    @DanhSachPhong = N'<root><item MaPhong="P301" DonGia="400000" /><item MaPhong="P302" DonGia="400000" /></root>';

-- 6. Hợp đồng thứ 2: KH02 thuê P201 trong 6 tháng
EXEC dbo.sp_LapHopDongThue
    @MaHD = 'HD002',
    @MaKH = 'KH02',
    @NgayKy = '2026-02-01',
    @NgayBatDau = '2026-02-15',
    @ThoiHanThueThang = 6,
    @TienDatCoc = 50000000,
    @DanhSachPhong = N'<root><item MaPhong="P201" DonGia="380000" /></root>';

-- 7. Nạp Nhân viên văn phòng cho KH01
INSERT INTO dbo.NhanVienVanPhong (MaNVVP, MaKH, MaPhong, HoTen, NgaySinh, GioiTinh, CCCD, DienThoai, ChucVu, HinhAnh, NgayBaoCao, DangLamViec) VALUES
('NV001', 'KH01', 'P301', N'Trần Văn An', '1990-04-12', N'Nam', '079090001111', '0901111222', N'Trưởng phòng Kỹ thuật', 'an_tran.jpg', '2026-01-16', 1),
('NV002', 'KH01', 'P301', N'Nguyễn Thị Mai', '1995-08-20', N'Nữ', '079195002222', '0903333444', N'Chuyên viên Lập trình', 'mai_nguyen.jpg', '2026-01-16', 1),
('NV003', 'KH01', 'P302', N'Phạm Quốc Bảo', '1992-11-05', N'Nam', '079092003333', '0905555666', N'Kế toán trưởng', 'bao_pham.jpg', '2026-01-18', 1);

-- 8. Cấp thẻ giữ xe cho nhân viên
INSERT INTO dbo.TheGiuXe (MaThe, MaNVVP, BienSoXe, LoaiXe, NhanHieu, MauXe, NgayCap, TrangThai) VALUES
('TX001', 'NV001', '59-B1 123.45', N'Xe máy', 'Honda SH 150i', N'Trắng', '2026-01-17', N'Hoạt động'),
('TX002', 'NV002', '59-S2 678.90', N'Xe máy', 'Yamaha Grande', N'Đỏ', '2026-01-17', N'Hoạt động'),
('TX003', 'NV003', '51-K 999.88', N'Ô tô', 'Toyota Camry', N'Đen', '2026-01-19', N'Hoạt động');

-- 9. Hóa đơn dịch vụ mẫu cuối tháng 1/2026 cho P301
INSERT INTO dbo.HoaDonDichVu (MaHDDV, MaHD, MaPhong, Thang, Nam, NgayLap, NgayHenTra, TongTien, DaThanhToan, NgayThanhToan) VALUES
('HDDV_0126_P301', 'HD001', 'P301', 1, 2026, '2026-01-31', '2026-01-31', 3480000, 1, '2026-01-31 16:30:00');

INSERT INTO dbo.ChiTietHoaDonDichVu (MaHDDV, MaDV, ChiSoDau, ChiSoCuoi, SoLuong, DonGia) VALUES
('HDDV_0126_P301', 'DV_DIEN', 1000, 1600, 600, 3800), -- 2.280.000 đ
('HDDV_0126_P301', 'DV_INTERNET', NULL, NULL, 1, 1200000); -- 1.200.000 đ

-- 10. Kiểm tra phòng định kỳ 1 năm
INSERT INTO dbo.KiemTraPhong (MaPhieuKT, MaPhong, NgayKiemTra, NguoiKiemTra, TinhTrangKetCau, TinhTrangNoiThat, CoViPham, GhiChuTuSua) VALUES
('KT2026_01', 'P101', '2026-01-10', N'Kỹ sư Lê Hoàng', N'Kết cấu tường và sàn chịu lực hoàn toàn bình thường', N'Sơn nước còn mới, hệ thống đèn tốt', 0, N'Đạt tiêu chuẩn an toàn'),
('KT2026_02', 'P401', '2026-02-15', N'Kỹ sư Lê Hoàng', N'Phát hiện tự ý đập vách ngăn chịu lực phân chia phòng sai thiết kế', N'Thiết bị điện câu móc không đúng vị trí an toàn', 1, N'Yêu cầu phục hồi hiện trạng và lập biên bản phạt');

-- 11. Biên bản xử phạt vi phạm kết cấu phòng P401
INSERT INTO dbo.BienBanXuPhat (MaBienBan, MaPhieuKT, MaHD, MaPhong, NgayLap, HanhViViPham, SoTienPhat, HanNopPhat, DaNopPhat) VALUES
('BBXP001', 'KT2026_02', 'HD001', 'P401', '2026-02-16', N'Tự ý chỉnh sửa, đập phá kết cấu vách tường chịu lực của cao ốc mà không được ban quản lý phê duyệt', 20000000, '2026-02-28', 0);
GO

PRINT N'=====================================================================';
PRINT N'ĐÃ TẠO THÀNH CÔNG CSDL QuanLyChoThueVanPhong VÀ DỮ LIỆU MẪU KIỂM THỬ.';
PRINT N'=====================================================================';
GO
