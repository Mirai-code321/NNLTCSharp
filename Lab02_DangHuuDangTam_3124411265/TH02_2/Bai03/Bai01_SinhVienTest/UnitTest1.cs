using Bai01ArraySort;

namespace Bai01_ArraySortTest;

public class ArraySortTests
{
    [Fact]
    public void ArraySort_DiemKhacNhau_SapXepTangDanTheoDiem()
    {
        // Arrange.
        SinhVien[] danhSach =
        {
            new SinhVien("SV01", "Nguyen Van A", 8.5),
            new SinhVien("SV02", "Tran Thi B", 6.5),
            new SinhVien("SV03", "Le Van C", 9.0)
        };

        // Act.
        Array.Sort(danhSach);

        // Assert.
        Assert.Equal("SV02", danhSach[0].MaSinhVien);
        Assert.Equal("SV01", danhSach[1].MaSinhVien);
        Assert.Equal("SV03", danhSach[2].MaSinhVien);

        Assert.Equal(6.5, danhSach[0].DiemTrungBinh);
        Assert.Equal(8.5, danhSach[1].DiemTrungBinh);
        Assert.Equal(9.0, danhSach[2].DiemTrungBinh);
    }

    [Fact]
    public void ArraySort_CungDiem_SapXepTheoHoTen()
    {
        // Arrange.
        SinhVien[] danhSach =
        {
            new SinhVien("SV01", "Tran Van B", 8),
            new SinhVien("SV02", "Nguyen Van A", 8),
            new SinhVien("SV03", "Le Van C", 8)
        };

        // Act.
        Array.Sort(danhSach);

        // Assert.
        Assert.Equal("Le Van C", danhSach[0].HoTen);
        Assert.Equal("Nguyen Van A", danhSach[1].HoTen);
        Assert.Equal("Tran Van B", danhSach[2].HoTen);
    }

    [Fact]
    public void ArraySort_CungDiemCungTen_SapXepTheoMaSinhVien()
    {
        // Arrange.
        SinhVien[] danhSach =
        {
            new SinhVien("SV03", "Nguyen Van A", 8),
            new SinhVien("SV01", "Nguyen Van A", 8),
            new SinhVien("SV02", "Nguyen Van A", 8)
        };

        // Act.
        Array.Sort(danhSach);

        // Assert.
        Assert.Equal("SV01", danhSach[0].MaSinhVien);
        Assert.Equal("SV02", danhSach[1].MaSinhVien);
        Assert.Equal("SV03", danhSach[2].MaSinhVien);
    }

    [Fact]
    public void ArraySort_MangRong_KhongPhatSinhLoi()
    {
        // Arrange.
        SinhVien[] danhSach =
            Array.Empty<SinhVien>();

        // Act.
        Array.Sort(danhSach);

        // Assert.
        Assert.Empty(danhSach);
    }

    [Fact]
    public void Constructor_DiemNgoaiKhoang_NemArgumentException()
    {
        // Act.
        Action hanhDong = () =>
            new SinhVien(
                "SV01",
                "Nguyen Van A",
                11
            );

        // Assert.
        Assert.Throws<ArgumentException>(
            hanhDong
        );
    }
}