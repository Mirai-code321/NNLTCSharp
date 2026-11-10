using Bai07TinhLuong;

namespace Bai07_TinhLuongTest;

public class TinhLuongTests
{
    [Fact]
    public void TinhLuongThucNhan_KhongVang_TraVeDuLuong()
    {
        // Arrange.
        NhanVien nhanVien = new NhanVien(
            "Nguyen Van A",
            10_000_000m,
            0
        );

        // Act.
        decimal ketQua =
            nhanVien.TinhLuongThucNhan();

        // Assert.
        Assert.Equal(
            10_000_000m,
            ketQua
        );
    }

    [Fact]
    public void TinhLuongThucNhan_VangHaiNgay_TruHaiTramNghin()
    {
        // Arrange.
        NhanVien nhanVien = new NhanVien(
            "Nguyen Van A",
            10_000_000m,
            2
        );

        // Act.
        decimal ketQua =
            nhanVien.TinhLuongThucNhan();

        // Assert.
        Assert.Equal(
            9_800_000m,
            ketQua
        );
    }

    [Fact]
    public void Constructor_SoNgayVangAm_NemArgumentException()
    {
        // Act.
        Action hanhDong = () =>
            new NhanVien(
                "Nguyen Van A",
                10_000_000m,
                -1
            );

        // Assert.
        Assert.Throws<ArgumentException>(
            hanhDong
        );
    }

    [Fact]
    public void Add_ThemNhanVien_TangSoLuong()
    {
        // Arrange.
        PhongBan phongBan = new PhongBan();

        NhanVien nhanVien = new NhanVien(
            "Nguyen Van A",
            10_000_000m,
            2
        );

        // Act.
        phongBan.Add(nhanVien);

        // Assert.
        Assert.Equal(1, phongBan.Count);
        Assert.Equal(
            "Nguyen Van A",
            phongBan[0].HoTen
        );
    }

    [Fact]
    public void TinhTongLuong_HaiNhanVien_TraVeDungKetQua()
    {
        // Arrange.
        PhongBan phongBan = new PhongBan();

        phongBan.Add(
            new NhanVien(
                "Nguyen Van A",
                10_000_000m,
                2
            )
        );

        phongBan.Add(
            new NhanVien(
                "Tran Thi B",
                12_000_000m,
                1
            )
        );

        // Act.
        decimal tongLuong =
            phongBan.TinhTongLuong();

        // Assert:
        // NV1: 10.000.000 - 2 * 100.000 = 9.800.000.
        // NV2: 12.000.000 - 1 * 100.000 = 11.900.000.
        // Tong: 21.700.000.
        Assert.Equal(
            21_700_000m,
            tongLuong
        );
    }
}