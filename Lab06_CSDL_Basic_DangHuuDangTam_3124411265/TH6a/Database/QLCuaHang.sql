USE master;
GO

IF DB_ID(N'QLCuaHang') IS NULL
    EXEC(N'CREATE DATABASE QLCuaHang');
GO

USE QLCuaHang;
GO

-- 1. Sản phẩm: mã tự tăng.
IF OBJECT_ID(N'dbo.SANPHAM', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SANPHAM
    (
        MaSP INT IDENTITY(1,1) PRIMARY KEY,
        TenSP NVARCHAR(100) NOT NULL
    );
END;
GO

-- 2. Tồn kho theo từng sản phẩm và ngày.
IF OBJECT_ID(N'dbo.TONKHO', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.TONKHO
    (
        MaSP INT NOT NULL,
        NgayTon DATE NOT NULL,
        SLDau INT NOT NULL,
        SLNhap INT NOT NULL,
        SLBan INT NOT NULL,

        CONSTRAINT PK_TONKHO
            PRIMARY KEY (MaSP, NgayTon),

        CONSTRAINT FK_TONKHO_SANPHAM
            FOREIGN KEY (MaSP)
            REFERENCES dbo.SANPHAM(MaSP),

        CONSTRAINT CK_TONKHO_SoLuong
            CHECK
            (
                SLDau >= 0
                AND SLNhap >= 0
                AND SLBan >= 0
                AND CAST(SLDau AS BIGINT) + SLNhap >= SLBan
            )
    );
END;
GO

-- 3. Hóa đơn: mã tự tăng.
IF OBJECT_ID(N'dbo.HOADON', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.HOADON
    (
        MaHD INT IDENTITY(1,1) PRIMARY KEY,
        NgayTao DATE NOT NULL,
        TinhTrangThanhToan BIT NOT NULL DEFAULT 0
    );
END;
GO

-- 4. Chi tiết hóa đơn.
IF OBJECT_ID(N'dbo.CHITIET_HOADON', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CHITIET_HOADON
    (
        MaHD INT NOT NULL,
        MaSP INT NOT NULL,
        SoLuong INT NOT NULL,

        CONSTRAINT PK_CHITIET_HOADON
            PRIMARY KEY (MaHD, MaSP),

        CONSTRAINT FK_CHITIET_HD
            FOREIGN KEY (MaHD)
            REFERENCES dbo.HOADON(MaHD),

        CONSTRAINT FK_CHITIET_SP
            FOREIGN KEY (MaSP)
            REFERENCES dbo.SANPHAM(MaSP),

        CONSTRAINT CK_CHITIET_SoLuong
            CHECK (SoLuong > 0)
    );
END;
GO

-- Dữ liệu mẫu theo tên sản phẩm trong đề.
-- Dùng ngày hôm qua thay ngày 2016 trong hình để dễ thực hành.
-- Chỉ khởi tạo khi bảng sản phẩm đang rỗng.
IF NOT EXISTS (SELECT 1 FROM dbo.SANPHAM)
BEGIN
    INSERT INTO dbo.SANPHAM(TenSP)
    VALUES (N'Trà xanh'), (N'Mực dầu'), (N'Cafe');

    INSERT INTO dbo.TONKHO
        (MaSP, NgayTon, SLDau, SLNhap, SLBan)
    SELECT
        MaSP,
        DATEADD(DAY, -1, CONVERT(DATE, GETDATE())),
        50,
        0,
        0
    FROM dbo.SANPHAM;
END;
GO

-- Một thủ tục dùng chung, phân biệt thao tác bằng @TacVu.
CREATE OR ALTER PROCEDURE dbo.ThucHienCuaHang
    @TacVu VARCHAR(20),
    @MaHD INT = NULL,
    @MaSP INT = NULL,
    @SoLuong INT = NULL,
    @TenSP NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @Ngay DATE = CONVERT(DATE, GETDATE());
    DECLARE @KetQua INT = 0;
    DECLARE @Khoa INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Tuần tự hóa các thao tác ghi của ứng dụng.
        -- Tránh hai cửa sổ cùng kiểm tra và bán một lượng tồn.
        EXEC @Khoa = sys.sp_getapplock
            @Resource = N'QLCuaHang_ThaoTac',
            @LockMode = 'Exclusive',
            @LockOwner = 'Transaction',
            @LockTimeout = 10000;

        IF @Khoa < 0
            THROW 50001, N'Không lấy được khóa xử lý. Hãy thử lại.', 1;

        IF @TacVu = 'TAO_TON'
        BEGIN
            IF EXISTS
            (
                SELECT 1 FROM dbo.HOADON
                WHERE TinhTrangThanhToan = 0
                  AND NgayTao < @Ngay
            )
                THROW 50001,
                    N'Còn hóa đơn chưa thanh toán của ngày trước. Mở Bán hàng để hủy trước.',
                    1;

            IF EXISTS
            (
                SELECT 1 FROM dbo.TONKHO
                WHERE NgayTon = @Ngay
            )
                THROW 50001, N'Đã tạo tồn kho hôm nay, không tạo lại.', 1;

            -- Lấy tồn cuối của ngày có dữ liệu gần nhất trước hôm nay.
            -- Các ngày không hoạt động không phát sinh nhập hoặc bán.
            INSERT INTO dbo.TONKHO
                (MaSP, NgayTon, SLDau, SLNhap, SLBan)
            SELECT
                sp.MaSP,
                @Ngay,
                COALESCE(t.SLDau + t.SLNhap - t.SLBan, 0),
                0,
                0
            FROM dbo.SANPHAM AS sp
            OUTER APPLY
            (
                SELECT TOP (1)
                    tk.SLDau, tk.SLNhap, tk.SLBan
                FROM dbo.TONKHO AS tk
                WHERE tk.MaSP = sp.MaSP
                  AND tk.NgayTon < @Ngay
                ORDER BY tk.NgayTon DESC
            ) AS t;
        END
        ELSE IF @TacVu = 'THEM_SP'
        BEGIN
            IF NULLIF(LTRIM(RTRIM(@TenSP)), N'') IS NULL
                THROW 50001, N'Tên sản phẩm không được trống.', 1;

            IF EXISTS
            (
                SELECT 1
                FROM dbo.SANPHAM AS sp
                WHERE NOT EXISTS
                (
                    SELECT 1 FROM dbo.TONKHO AS tk
                    WHERE tk.MaSP = sp.MaSP
                      AND tk.NgayTon = @Ngay
                )
            )
                THROW 50001, N'Hãy tạo tồn kho hôm nay trước.', 1;

            INSERT INTO dbo.SANPHAM(TenSP)
            VALUES (@TenSP);

            SET @KetQua = CONVERT(INT, SCOPE_IDENTITY());

            INSERT INTO dbo.TONKHO
                (MaSP, NgayTon, SLDau, SLNhap, SLBan)
            VALUES
                (@KetQua, @Ngay, 0, 0, 0);
        END
        ELSE IF @TacVu = 'TAO_HD'
        BEGIN
            IF NOT EXISTS (SELECT 1 FROM dbo.SANPHAM)
                THROW 50001, N'Chưa có sản phẩm.', 1;

            IF EXISTS
            (
                SELECT 1
                FROM dbo.SANPHAM AS sp
                WHERE NOT EXISTS
                (
                    SELECT 1 FROM dbo.TONKHO AS tk
                    WHERE tk.MaSP = sp.MaSP
                      AND tk.NgayTon = @Ngay
                )
            )
                THROW 50001, N'Hãy tạo tồn kho hôm nay trước khi bán.', 1;

            IF EXISTS
            (
                SELECT 1 FROM dbo.HOADON
                WHERE TinhTrangThanhToan = 0
            )
                THROW 50001,
                    N'Còn hóa đơn chưa thanh toán. Mở lại Form Bán hàng để xử lý.',
                    1;

            INSERT INTO dbo.HOADON
                (NgayTao, TinhTrangThanhToan)
            VALUES (@Ngay, 0);

            SET @KetQua = CONVERT(INT, SCOPE_IDENTITY());
        END
        ELSE IF @TacVu = 'THEM_CT'
        BEGIN
            IF NOT EXISTS
            (
                SELECT 1 FROM dbo.HOADON
                WHERE MaHD = @MaHD
                  AND TinhTrangThanhToan = 0
                  AND NgayTao = @Ngay
            )
                THROW 50001,
                    N'Hóa đơn không hợp lệ hoặc không thuộc hôm nay.',
                    1;

            IF NOT EXISTS
                (SELECT 1 FROM dbo.SANPHAM WHERE MaSP = @MaSP)
                THROW 50001, N'Sản phẩm không tồn tại.', 1;

            IF EXISTS
            (
                SELECT 1 FROM dbo.CHITIET_HOADON
                WHERE MaHD = @MaHD AND MaSP = @MaSP
            )
                THROW 50001,
                    N'Sản phẩm đã có trong hóa đơn, không thêm trùng khóa.',
                    1;

            DECLARE @Ton BIGINT;

            SELECT @Ton = CAST(SLDau AS BIGINT) + SLNhap - SLBan
            FROM dbo.TONKHO
            WHERE MaSP = @MaSP AND NgayTon = @Ngay;

            IF @Ton IS NULL
                THROW 50001, N'Sản phẩm chưa có tồn kho hôm nay.', 1;

            -- Giữ điều kiện nhỏ hơn tồn theo đề.
            IF @SoLuong IS NULL OR @SoLuong <= 0 OR @SoLuong >= @Ton
                THROW 50001,
                    N'Số lượng phải lớn hơn 0 và nhỏ hơn tồn hiện tại.',
                    1;

            INSERT INTO dbo.CHITIET_HOADON(MaHD, MaSP, SoLuong)
            VALUES (@MaHD, @MaSP, @SoLuong);

            -- Bán hàng làm tổng số lượng bán tăng lên.
            UPDATE dbo.TONKHO
            SET SLBan = SLBan + @SoLuong
            WHERE MaSP = @MaSP AND NgayTon = @Ngay;
        END
        ELSE IF @TacVu = 'THANH_TOAN'
        BEGIN
            IF NOT EXISTS
            (
                SELECT 1 FROM dbo.HOADON
                WHERE MaHD = @MaHD
                  AND TinhTrangThanhToan = 0
                  AND NgayTao = @Ngay
            )
                THROW 50001,
                    N'Hóa đơn không hợp lệ hoặc không thuộc hôm nay.',
                    1;

            IF NOT EXISTS
                (SELECT 1 FROM dbo.CHITIET_HOADON WHERE MaHD = @MaHD)
                THROW 50001, N'Hóa đơn chưa có sản phẩm.', 1;

            UPDATE dbo.HOADON
            SET TinhTrangThanhToan = 1
            WHERE MaHD = @MaHD;
        END
        ELSE IF @TacVu = 'HUY_HD'
        BEGIN
            DECLARE @NgayHD DATE;

            SELECT @NgayHD = NgayTao
            FROM dbo.HOADON
            WHERE MaHD = @MaHD
              AND TinhTrangThanhToan = 0;

            IF @NgayHD IS NULL
                THROW 50001, N'Không tìm thấy hóa đơn chưa thanh toán.', 1;

            -- Hoàn lại số lượng đã ghi nhận bán của hóa đơn.
            UPDATE tk
            SET tk.SLBan = tk.SLBan - ct.SoLuong
            FROM dbo.TONKHO AS tk
            INNER JOIN dbo.CHITIET_HOADON AS ct
                ON tk.MaSP = ct.MaSP
            WHERE ct.MaHD = @MaHD
              AND tk.NgayTon = @NgayHD;

            DELETE FROM dbo.CHITIET_HOADON WHERE MaHD = @MaHD;
            DELETE FROM dbo.HOADON WHERE MaHD = @MaHD;
        END
        ELSE
            THROW 50001, N'Tác vụ không hợp lệ.', 1;

        COMMIT TRANSACTION;

        -- Trả mã sản phẩm hoặc hóa đơn vừa tạo.
        SELECT @KetQua;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH;
END;
GO

SELECT * FROM dbo.SANPHAM;
SELECT * FROM dbo.TONKHO;
GO