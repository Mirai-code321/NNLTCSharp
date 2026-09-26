using Bai02Point;
using Bai06ArrayPoint;

namespace Bai06_ArrayPoint.Tests;

public class ArrayPointTests
{
    [Fact]
    public void ConstructorMacDinh_TaoDanhSachRong()
    {
        // Arrange va Act.
        ArrayPoint danhSach = new ArrayPoint();

        // Assert.
        Assert.Equal(0, danhSach.Count);
    }

    [Fact]
    public void Add_ThemMotDiem_TangSoLuongVaLuuDungDiem()
    {
        // Arrange.
        ArrayPoint danhSach = new ArrayPoint();
        Point point = new Point(1, 2);

        // Act.
        danhSach.Add(point);

        // Assert.
        Assert.Equal(1, danhSach.Count);
        Assert.Equal(1, danhSach[0].X);
        Assert.Equal(2, danhSach[0].Y);
    }

    [Fact]
    public void Indexer_SetPoint_ThayDoiDungPhanTu()
    {
        // Arrange.
        ArrayPoint danhSach = new ArrayPoint();
        danhSach.Add(new Point(1, 2));

        // Act.
        danhSach[0] = new Point(5, 6);

        // Assert.
        Assert.Equal(5, danhSach[0].X);
        Assert.Equal(6, danhSach[0].Y);
    }

    [Fact]
    public void Indexer_ChiSoKhongHopLe_NemIndexOutOfRangeException()
    {
        // Arrange.
        ArrayPoint danhSach = new ArrayPoint();
        danhSach.Add(new Point(1, 2));

        // Act.
        Action hanhDong = () =>
        {
            Point point = danhSach[1];
        };

        // Assert.
        Assert.Throws<IndexOutOfRangeException>(
            hanhDong
        );
    }

    [Fact]
    public void CopyConstructor_SaoChepSauDanhSach()
    {
        // Arrange.
        ArrayPoint danhSachGoc = new ArrayPoint();
        danhSachGoc.Add(new Point(1, 2));
        danhSachGoc.Add(new Point(3, 4));

        // Act.
        ArrayPoint banSao = new ArrayPoint(
            danhSachGoc
        );

        // Thay doi diem trong ban sao.
        banSao[0].X = 100;
        banSao[0].Y = 200;

        // Assert:
        // Ban sao co cung so luong voi danh sach goc.
        Assert.Equal(danhSachGoc.Count, banSao.Count);

        // Du lieu cua ban sao da thay doi.
        Assert.Equal(100, banSao[0].X);
        Assert.Equal(200, banSao[0].Y);

        // Danh sach goc khong bi thay doi.
        Assert.Equal(1, danhSachGoc[0].X);
        Assert.Equal(2, danhSachGoc[0].Y);

        // Hai danh sach khong dung chung doi tuong Point.
        Assert.NotSame(
            danhSachGoc[0],
            banSao[0]
        );
    }
}