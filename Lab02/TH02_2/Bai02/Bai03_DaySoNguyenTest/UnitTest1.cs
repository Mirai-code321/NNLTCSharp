using Bai03DaySoNguyen;

namespace Bai03_DaySoNguyenTest;

public class DaySoNguyenTests
{
    [Fact]
    public void ConstructorMacDinh_TaoDayRong()
    {
        // Arrange va Act.
        DaySoNguyen daySo = new DaySoNguyen();

        // Assert.
        Assert.Equal(0, daySo.Count);
        Assert.Equal("Day rong", daySo.ToString());
    }

    [Fact]
    public void ConstructorNhanMang_SaoChepDungDuLieu()
    {
        // Arrange.
        int[] mang = { 1, 2, 3, 4 };

        // Act.
        DaySoNguyen daySo = new DaySoNguyen(mang);

        // Assert.
        Assert.Equal(4, daySo.Count);
        Assert.Equal(1, daySo[0]);
        Assert.Equal(2, daySo[1]);
        Assert.Equal(3, daySo[2]);
        Assert.Equal(4, daySo[3]);
    }

    [Fact]
    public void Indexer_SetGiaTri_ThayDoiDungPhanTu()
    {
        // Arrange.
        DaySoNguyen daySo = new DaySoNguyen(
            new[] { 1, 2, 3 }
        );

        // Act.
        daySo[1] = 100;

        // Assert.
        Assert.Equal(1, daySo[0]);
        Assert.Equal(100, daySo[1]);
        Assert.Equal(3, daySo[2]);
    }

    [Fact]
    public void Indexer_ChiSoKhongHopLe_NemIndexOutOfRangeException()
    {
        // Arrange.
        DaySoNguyen daySo = new DaySoNguyen(
            new[] { 1, 2, 3 }
        );

        // Act.
        Action hanhDong = () =>
        {
            int giaTri = daySo[3];
        };

        // Assert.
        Assert.Throws<IndexOutOfRangeException>(
            hanhDong
        );
    }

    [Fact]
    public void TimSoChan_DayCoSoChan_TraVeDungKetQua()
    {
        // Arrange.
        DaySoNguyen daySo = new DaySoNguyen(
            new[] { 1, 2, 3, 4, 5, 6 }
        );

        // Act.
        DaySoNguyen daySoChan =
            daySo.TimSoChan();

        // Assert.
        Assert.Equal(3, daySoChan.Count);
        Assert.Equal(2, daySoChan[0]);
        Assert.Equal(4, daySoChan[1]);
        Assert.Equal(6, daySoChan[2]);
    }
}