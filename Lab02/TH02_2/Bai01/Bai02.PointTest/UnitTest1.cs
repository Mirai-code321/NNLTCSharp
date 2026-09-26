using Bai02Point;

namespace Bai02_Point.Tests;

public class PointTests
{
    [Fact]
    public void Constructor_CoThamSo_GanDungToaDo()
    {
        // Arrange va Act:
        // Tao diem co toa do (3, 5).
        Point point = new Point(3, 5);

        // Assert:
        // Kiem tra toa do duoc luu dung.
        Assert.Equal(3, point.X);
        Assert.Equal(5, point.Y);
    }

    [Fact]
    public void ToanTuCong_HaiDiem_TraVeTongToaDo()
    {
        // Arrange:
        // Tao hai diem A va B.
        Point a = new Point(1, 2);
        Point b = new Point(4, 6);

        // Act:
        // Cong toa do tuong ung cua hai diem.
        Point ketQua = a + b;

        // Assert:
        // (1, 2) + (4, 6) = (5, 8).
        Assert.Equal(5, ketQua.X);
        Assert.Equal(8, ketQua.Y);
    }

    [Fact]
    public void ToanTuTruVaLayAm_TraVeToaDoDung()
    {
        // Arrange.
        Point a = new Point(1, 2);
        Point b = new Point(4, 6);

        // Act.
        Point hieu = a - b;
        Point doiDau = -a;

        // Assert:
        // (1, 2) - (4, 6) = (-3, -4).
        Assert.Equal(-3, hieu.X);
        Assert.Equal(-4, hieu.Y);

        // -(1, 2) = (-1, -2).
        Assert.Equal(-1, doiDau.X);
        Assert.Equal(-2, doiDau.Y);
    }

    [Fact]
    public void KhoangCach_HaiCachTinh_TraVeKetQuaBangNhau()
    {
        // Arrange.
        Point a = new Point(1, 2);
        Point b = new Point(4, 6);

        // Act:
        // Tinh khoang cach bang phuong thuc thanh vien.
        double ketQuaThanhVien =
            a.KhoangCachDen(b);

        // Tinh khoang cach bang phuong thuc tinh.
        double ketQuaTinh =
            Point.KhoangCach(a, b);

        // Assert:
        // Khoang cach giua (1, 2) va (4, 6) bang 5.
        Assert.Equal(5, ketQuaThanhVien, 10);
        Assert.Equal(5, ketQuaTinh, 10);

        // Hai cach tinh phai cho cung mot ket qua.
        Assert.Equal(
            ketQuaThanhVien,
            ketQuaTinh,
            10
        );
    }

    [Fact]
    public void TrungDiem_HaiCachTinh_TraVeKetQuaBangNhau()
    {
        // Arrange.
        Point a = new Point(1, 2);
        Point b = new Point(4, 6);

        // Act:
        // Tim trung diem bang phuong thuc thanh vien.
        Point ketQuaThanhVien =
            a.TrungDiemVoi(b);

        // Tim trung diem bang phuong thuc tinh.
        Point ketQuaTinh =
            Point.TrungDiem(a, b);

        // Assert:
        // Trung diem cua (1, 2) va (4, 6) la (2.5, 4).
        Assert.Equal(2.5, ketQuaThanhVien.X);
        Assert.Equal(4, ketQuaThanhVien.Y);

        // Hai cach tinh phai tra ve cung toa do.
        Assert.Equal(
            ketQuaThanhVien.X,
            ketQuaTinh.X
        );

        Assert.Equal(
            ketQuaThanhVien.Y,
            ketQuaTinh.Y
        );
    }
}