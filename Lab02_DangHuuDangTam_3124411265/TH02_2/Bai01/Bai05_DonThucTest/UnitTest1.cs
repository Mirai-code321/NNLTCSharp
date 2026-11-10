using Bai05_DonThuc;
using Bai05DonThuc;
using Xunit;
namespace Bai05_DonThuc.Tests;

public class DonThucTests
{
    [Fact]
    public void Constructor_CoThamSo_GanDungDuLieu()
    {
        // Arrange va Act.
        DonThuc donThuc = new DonThuc(2, 3);

        // Assert.
        Assert.Equal(2, donThuc.HeSo);
        Assert.Equal(3, donThuc.SoMu);
        Assert.Equal("2x^3", donThuc.ToString());
    }

    [Fact]
    public void Constructor_SoMuAm_NemArgumentException()
    {
        // Act.
        Action hanhDong = () =>
            new DonThuc(2, -1);

        // Assert.
        Assert.Throws<ArgumentException>(hanhDong);
    }

    [Fact]
    public void TinhGiaTri_DonThuc2xMu3TaiXBang2_TraVe16()
    {
        // Arrange.
        DonThuc donThuc = new DonThuc(2, 3);

        // Act.
        double ketQua = donThuc.TinhGiaTri(2);

        // Assert.
        Assert.Equal(16, ketQua, 10);
    }

    [Fact]
    public void DaoHam_DonThuc2xMu3_TraVe6xMu2()
    {
        // Arrange.
        DonThuc donThuc = new DonThuc(2, 3);

        // Act.
        DonThuc daoHam = donThuc.DaoHam();

        // Assert.
        Assert.Equal(6, daoHam.HeSo);
        Assert.Equal(2, daoHam.SoMu);
        Assert.Equal("6x^2", daoHam.ToString());
    }

    [Fact]
    public void DaoHam_HangSo_TraVeKhong()
    {
        // Arrange:
        // Don thuc co so mu bang 0 la mot hang so.
        DonThuc donThuc = new DonThuc(5, 0);

        // Act.
        DonThuc daoHam = donThuc.DaoHam();

        // Assert:
        // Dao ham cua hang so bang 0.
        Assert.Equal(0, daoHam.HeSo);
        Assert.Equal(0, daoHam.SoMu);
        Assert.Equal("0", daoHam.ToString());
    }
}