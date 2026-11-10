-- Tạo cơ sở dữ liệu nếu chưa tồn tại.
USE master;
GO

IF DB_ID(N'QLSinhVien') IS NULL
BEGIN
    EXEC(N'CREATE DATABASE QLSinhVien');
END;
GO

USE QLSinhVien;
GO

-- 1. Bảng Khoa.
IF OBJECT_ID(N'dbo.Khoa', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Khoa
    (
        MaKhoa VARCHAR(20) NOT NULL
            CONSTRAINT PK_Khoa PRIMARY KEY,

        TenKhoa NVARCHAR(100) NOT NULL
    );
END;
GO

-- 2. Bảng Lớp.
IF OBJECT_ID(N'dbo.Lop', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Lop
    (
        MaLop VARCHAR(20) NOT NULL
            CONSTRAINT PK_Lop PRIMARY KEY,

        TenLop NVARCHAR(100) NOT NULL,

        MaKhoa VARCHAR(20) NOT NULL,

        CONSTRAINT FK_Lop_Khoa
            FOREIGN KEY (MaKhoa)
            REFERENCES dbo.Khoa(MaKhoa)
    );
END;
GO

-- 3. Bảng Sinh viên.
IF OBJECT_ID(N'dbo.SinhVien', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SinhVien
    (
        MaSinhVien VARCHAR(20) NOT NULL
            CONSTRAINT PK_SinhVien PRIMARY KEY,

        HoTen NVARCHAR(100) NOT NULL,

        NgaySinh DATE NOT NULL,

        MaLop VARCHAR(20) NOT NULL,

        CONSTRAINT FK_SinhVien_Lop
            FOREIGN KEY (MaLop)
            REFERENCES dbo.Lop(MaLop)
    );
END;
GO

-- 4. Bảng Môn học.
IF OBJECT_ID(N'dbo.MonHoc', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MonHoc
    (
        MaMonHoc VARCHAR(20) NOT NULL
            CONSTRAINT PK_MonHoc PRIMARY KEY,

        TenMonHoc NVARCHAR(100) NOT NULL
    );
END;
GO

-- 5. Bảng Điểm.
IF OBJECT_ID(N'dbo.Diem', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Diem
    (
        MaSinhVien VARCHAR(20) NOT NULL,
        MaMonHoc VARCHAR(20) NOT NULL,
        Diem DECIMAL(4, 2) NOT NULL,

        CONSTRAINT PK_Diem
            PRIMARY KEY (MaSinhVien, MaMonHoc),

        CONSTRAINT FK_Diem_SinhVien
            FOREIGN KEY (MaSinhVien)
            REFERENCES dbo.SinhVien(MaSinhVien),

        CONSTRAINT FK_Diem_MonHoc
            FOREIGN KEY (MaMonHoc)
            REFERENCES dbo.MonHoc(MaMonHoc),

        CONSTRAINT CK_Diem_GiaTri
            CHECK (Diem BETWEEN 0 AND 10)
    );
END;
GO

-- Thêm dữ liệu mẫu, bỏ qua các mã đã tồn tại.

INSERT INTO dbo.Khoa (MaKhoa, TenKhoa)
SELECT v.MaKhoa, v.TenKhoa
FROM
(
    VALUES
        ('CNTT', N'Công nghệ thông tin'),
        ('QTKD', N'Quản trị kinh doanh'),
        ('KT',   N'Kế toán'),
        ('NN',   N'Ngoại ngữ'),
        ('DL',   N'Du lịch')
) AS v(MaKhoa, TenKhoa)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Khoa AS k
    WHERE k.MaKhoa = v.MaKhoa
);
GO

INSERT INTO dbo.Lop (MaLop, TenLop, MaKhoa)
SELECT v.MaLop, v.TenLop, v.MaKhoa
FROM
(
    VALUES
        ('L01', N'Công nghệ thông tin 1', 'CNTT'),
        ('L02', N'Quản trị kinh doanh 1', 'QTKD'),
        ('L03', N'Kế toán 1', 'KT'),
        ('L04', N'Ngoại ngữ 1', 'NN'),
        ('L05', N'Du lịch 1', 'DL')
) AS v(MaLop, TenLop, MaKhoa)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Lop AS l
    WHERE l.MaLop = v.MaLop
);
GO

INSERT INTO dbo.SinhVien
    (MaSinhVien, HoTen, NgaySinh, MaLop)
SELECT
    v.MaSinhVien,
    v.HoTen,
    CONVERT(DATE, v.NgaySinh, 112),
    v.MaLop
FROM
(
    VALUES
        ('SV001', N'Nguyễn Văn An',   '20050115', 'L01'),
        ('SV002', N'Trần Ngọc Bình',  '20050320', 'L02'),
        ('SV003', N'Lê Minh Châu',    '20050610', 'L03'),
        ('SV004', N'Phạm Thanh Dũng', '20050905', 'L04'),
        ('SV005', N'Hoàng Thu Hà',    '20051212', 'L05')
) AS v(MaSinhVien, HoTen, NgaySinh, MaLop)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.SinhVien AS s
    WHERE s.MaSinhVien = v.MaSinhVien
);
GO

INSERT INTO dbo.MonHoc (MaMonHoc, TenMonHoc)
SELECT v.MaMonHoc, v.TenMonHoc
FROM
(
    VALUES
        ('MH001', N'Lập trình C#'),
        ('MH002', N'Cơ sở dữ liệu'),
        ('MH003', N'Mạng máy tính'),
        ('MH004', N'Công nghệ phần mềm'),
        ('MH005', N'Tiếng Anh')
) AS v(MaMonHoc, TenMonHoc)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.MonHoc AS m
    WHERE m.MaMonHoc = v.MaMonHoc6
);
GO

INSERT INTO dbo.Diem (MaSinhVien, MaMonHoc, Diem)
SELECT v.MaSinhVien, v.MaMonHoc, v.Diem
FROM
(
    VALUES
        ('SV001', 'MH001', 8.50),
        ('SV002', 'MH002', 7.00),
        ('SV003', 'MH003', 9.00),
        ('SV004', 'MH004', 6.50),
        ('SV005', 'MH005', 8.00)
) AS v(MaSinhVien, MaMonHoc, Diem)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Diem AS d
    WHERE d.MaSinhVien = v.MaSinhVien
      AND d.MaMonHoc = v.MaMonHoc
);
GO

-- Xem dữ liệu của các bảng.
SELECT * FROM dbo.Khoa;
SELECT * FROM dbo.Lop;
SELECT * FROM dbo.SinhVien;
SELECT * FROM dbo.MonHoc;
SELECT * FROM dbo.Diem;
GO
