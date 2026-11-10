using Bai04PhanSo;

namespace Bai04_PhanSo.Tests;

public class PhanSoTests
{
    [Fact]
    public void Constructor_PhanSoChuaRutGon_TuDongRutGon()
    {
        // Arrange va Act.
        PhanSo phanSo = new PhanSo(6, 8);

        // Assert:
        // 6/8 sau khi rut gon phai bang 3/4.
        Assert.Equal(3, phanSo.TuSo);
        Assert.Equal(4, phanSo.MauSo);
        Assert.Equal("3/4", phanSo.ToString());
    }

    [Fact]
    public void Constructor_MauSoBangKhong_NemArgumentException()
    {
        // Act.
        Action hanhDong = () => new PhanSo(1, 0);

        // Assert.
        Assert.Throws<ArgumentException>(hanhDong);
    }

    [Fact]
    public void CongTruNhanChia_HaiPhanSo_TraVeKetQuaDung()
    {
        // Arrange.
        PhanSo a = new PhanSo(1, 2);
        PhanSo b = new PhanSo(3, 4);

        // Act va Assert.
        Assert.Equal(
            new PhanSo(5, 4),
            a + b
        );

        Assert.Equal(
            new PhanSo(-1, 4),
            a - b
        );

        Assert.Equal(
            new PhanSo(3, 8),
            a * b
        );

        Assert.Equal(
            new PhanSo(2, 3),
            a / b
        );
    }

    [Fact]
    public void Chia_ChoPhanSoBangKhong_NemDivideByZeroException()
    {
        // Arrange.
        PhanSo a = new PhanSo(1, 2);
        PhanSo b = new PhanSo(0, 5);

        // Act.
        Action hanhDong = () =>
        {
            PhanSo ketQua = a / b;
        };

        // Assert.
        Assert.Throws<DivideByZeroException>(hanhDong);
    }

    [Fact]
    public void ToanTuSoSanh_HaiPhanSo_TraVeKetQuaDung()
    {
        // Arrange.
        PhanSo a = new PhanSo(1, 2);
        PhanSo b = new PhanSo(3, 4);
        PhanSo c = new PhanSo(2, 4);

        // Act va Assert.
        Assert.True(a < b);
        Assert.True(b > a);
        Assert.True(a <= c);
        Assert.True(a >= c);
        Assert.True(a == c);
        Assert.True(a != b);
    }
}