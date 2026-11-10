using Bai05DaThuc;
using Bai05DonThuc;

namespace Bai05_DaThucTest;

public class DaThucTests
{
    [Fact]
    public void ConstructorNhanMangHeSo_TaoDungDaThuc()
    {
        // Arrange va Act:
        // a0 = 1, a1 = 2, a2 = 3.
        DaThuc daThuc = new DaThuc(
            new double[] { 1, 2, 3 }
        );

        // Assert.
        Assert.Equal(2, daThuc.Bac);
        Assert.Equal(3, daThuc.Count);

        Assert.Equal(1, daThuc[0].HeSo);
        Assert.Equal(2, daThuc[1].HeSo);
        Assert.Equal(3, daThuc[2].HeSo);
    }

    [Fact]
    public void Indexer_SetDonThuc_ThayDoiDungHeSo()
    {
        // Arrange.
        DaThuc daThuc = new DaThuc(
            new double[] { 1, 2, 3 }
        );

        // Act:
        // Thay don thuc bac 1 thanh 5x.
        daThuc[1] = new DonThuc(5, 10);

        // Assert:
        // He so bang 5 va so mu duoc chuan hoa ve 1.
        Assert.Equal(5, daThuc[1].HeSo);
        Assert.Equal(1, daThuc[1].SoMu);
    }

    [Fact]
    public void TinhGiaTri_DaThucTaiXBang2_TraVe17()
    {
        // Arrange:
        // P(x) = 1 + 2x + 3x^2.
        DaThuc daThuc = new DaThuc(
            new double[] { 1, 2, 3 }
        );

        // Act.
        double ketQua =
            daThuc.TinhGiaTri(2);

        // Assert:
        // P(2) = 1 + 2*2 + 3*2^2 = 17.
        Assert.Equal(17, ketQua, 10);
    }

    [Fact]
    public void ToString_DaThucCoHeSoAm_HienThiDung()
    {
        // Arrange:
        // P(x) = 1 - 2x + 3x^2.
        DaThuc daThuc = new DaThuc(
            new double[] { 1, -2, 3 }
        );

        // Act.
        string ketQua = daThuc.ToString();

        // Assert.
        Assert.Equal(
            "3x^2 - 2x + 1",
            ketQua
        );
    }

    [Fact]
    public void CopyConstructor_SaoChepSauDaThuc()
    {
        // Arrange.
        DaThuc daThucGoc = new DaThuc(
            new double[] { 1, 2, 3 }
        );

        // Act.
        DaThuc banSao =
            new DaThuc(daThucGoc);

        banSao[0] = new DonThuc(100, 0);

        // Assert:
        // Ban sao da duoc thay doi.
        Assert.Equal(100, banSao[0].HeSo);

        // Da thuc goc khong bi thay doi.
        Assert.Equal(1, daThucGoc[0].HeSo);

        // Hai da thuc khong dung chung DonThuc.
        Assert.NotSame(
            daThucGoc[0],
            banSao[0]
        );
    }
}