using Bai04PhanSo;
using Bai06DayPhanSo;

namespace Bai06_DayPhanSoTest;

public class DayPhanSoTests
{
    [Fact]
    public void ConstructorMacDinh_TaoDayRong()
    {
        // Arrange va Act.
        DayPhanSo dayPhanSo =
            new DayPhanSo();

        // Assert.
        Assert.Equal(0, dayPhanSo.Count);
        Assert.Equal(
            new PhanSo(0, 1),
            dayPhanSo.TinhTong()
        );
    }

    [Fact]
    public void ConstructorNhanMang_SaoChepDungDuLieu()
    {
        // Arrange.
        PhanSo[] mang =
        {
            new PhanSo(1, 2),
            new PhanSo(1, 3),
            new PhanSo(1, 6)
        };

        // Act.
        DayPhanSo dayPhanSo =
            new DayPhanSo(mang);

        // Assert.
        Assert.Equal(3, dayPhanSo.Count);
        Assert.Equal(
            new PhanSo(1, 2),
            dayPhanSo[0]
        );

        Assert.Equal(
            new PhanSo(1, 3),
            dayPhanSo[1]
        );

        Assert.Equal(
            new PhanSo(1, 6),
            dayPhanSo[2]
        );
    }

    [Fact]
    public void Indexer_SetPhanSo_ThayDoiDungPhanTu()
    {
        // Arrange.
        DayPhanSo dayPhanSo =
            new DayPhanSo(
                new[]
                {
                    new PhanSo(1, 2),
                    new PhanSo(1, 3)
                }
            );

        // Act.
        dayPhanSo[1] =
            new PhanSo(3, 4);

        // Assert.
        Assert.Equal(
            new PhanSo(3, 4),
            dayPhanSo[1]
        );
    }

    [Fact]
    public void TinhTong_BaPhanSo_TraVeMot()
    {
        // Arrange.
        DayPhanSo dayPhanSo =
            new DayPhanSo(
                new[]
                {
                    new PhanSo(1, 2),
                    new PhanSo(1, 3),
                    new PhanSo(1, 6)
                }
            );

        // Act.
        PhanSo tong =
            dayPhanSo.TinhTong();

        // Assert.
        Assert.Equal(
            new PhanSo(1, 1),
            tong
        );

        Assert.Equal("1", tong.ToString());
    }

    [Fact]
    public void CopyConstructor_SaoChepDocLapDayPhanSo()
    {
        // Arrange.
        DayPhanSo dayGoc =
            new DayPhanSo(
                new[]
                {
                    new PhanSo(1, 2),
                    new PhanSo(1, 3)
                }
            );

        // Act.
        DayPhanSo banSao =
            new DayPhanSo(dayGoc);

        banSao[0] =
            new PhanSo(5, 6);

        // Assert:
        // Ban sao da thay doi.
        Assert.Equal(
            new PhanSo(5, 6),
            banSao[0]
        );

        // Day goc khong bi thay doi.
        Assert.Equal(
            new PhanSo(1, 2),
            dayGoc[0]
        );

        Assert.NotSame(
            dayGoc[0],
            banSao[0]
        );
    }
}