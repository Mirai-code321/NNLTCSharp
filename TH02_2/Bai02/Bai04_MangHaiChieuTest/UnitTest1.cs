using Bai04MangHaiChieu;

namespace Bai04_MangHaiChieuTest;

public class MangHaiChieuTests
{
    [Fact]
    public void Constructor_KichThuocHopLe_TaoDungSoDongVaSoCot()
    {
        // Arrange va Act.
        MangHaiChieu mang =
            new MangHaiChieu(2, 3);

        // Assert.
        Assert.Equal(2, mang.SoDong);
        Assert.Equal(3, mang.SoCot);
    }

    [Fact]
    public void ConstructorNhanMang_SaoChepDungDuLieu()
    {
        // Arrange.
        int[,] duLieu =
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };

        // Act.
        MangHaiChieu mang =
            new MangHaiChieu(duLieu);

        // Assert.
        Assert.Equal(2, mang.SoDong);
        Assert.Equal(3, mang.SoCot);

        Assert.Equal(1, mang[0, 0]);
        Assert.Equal(3, mang[0, 2]);
        Assert.Equal(4, mang[1, 0]);
        Assert.Equal(6, mang[1, 2]);
    }

    [Fact]
    public void Indexer_SetGiaTri_ThayDoiDungPhanTu()
    {
        // Arrange.
        MangHaiChieu mang =
            new MangHaiChieu(2, 2);

        // Act.
        mang[0, 1] = 10;
        mang[1, 0] = 20;

        // Assert.
        Assert.Equal(10, mang[0, 1]);
        Assert.Equal(20, mang[1, 0]);
    }

    [Fact]
    public void Indexer_ChiSoKhongHopLe_NemIndexOutOfRangeException()
    {
        // Arrange.
        MangHaiChieu mang =
            new MangHaiChieu(2, 3);

        // Act.
        Action hanhDong = () =>
        {
            int giaTri = mang[2, 0];
        };

        // Assert.
        Assert.Throws<IndexOutOfRangeException>(
            hanhDong
        );
    }

    [Fact]
    public void TimSoNguyenTo_MangCoSoNguyenTo_TraVeDungKetQua()
    {
        // Arrange.
        int[,] duLieu =
        {
            { -5, 0, 1, 2 },
            { 3, 4, 5, 6 },
            { 7, 8, 9, 11 }
        };

        MangHaiChieu mang =
            new MangHaiChieu(duLieu);

        // Act.
        List<int> ketQua =
            mang.TimSoNguyenTo();

        // Assert.
        int[] mongDoi = { 2, 3, 5, 7, 11 };

        Assert.Equal(mongDoi, ketQua);
    }
}