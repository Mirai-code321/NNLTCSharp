using Xunit;
using Bai05TinhLuongDaHinh;

namespace Bai05_TinhLuongDaHinhTest;

public class TinhLuongDaHinhTests
{
    [Fact]
    public void NhanVienKinhDoanh_TinhLuong_TraVeDungKetQua()
    {
        // Arrange.
        NhanVienKinhDoanh nhanVien =
            new NhanVienKinhDoanh(
                "KD01",
                "Nguyen Van An",
                10_000_000m,
                4
            );

        // Act.
        decimal luong =
            nhanVien.TinhLuong();

        // Assert:
        // 10.000.000 + 4 * 500.000 = 12.000.000.
        Assert.Equal(
            12_000_000m,
            luong
        );
    }

    [Fact]
    public void NhanVienSanXuat_Dung3000SanPham_KhongDuocThuong()
    {
        // Arrange.
        NhanVienSanXuat nhanVien =
            new NhanVienSanXuat(
                "SX01",
                "Tran Thi Binh",
                3_000
            );

        // Act.
        decimal luong =
            nhanVien.TinhLuong();

        // Assert.
        Assert.Equal(
            3_000_000m,
            luong
        );
    }

    [Fact]
    public void NhanVienSanXuat_Tren3000SanPham_DuocThuong5PhanTram()
    {
        // Arrange.
        NhanVienSanXuat nhanVien =
            new NhanVienSanXuat(
                "SX01",
                "Tran Thi Binh",
                4_000
            );

        // Act.
        decimal luong =
            nhanVien.TinhLuong();

        // Assert:
        // 4.000.000 + 5% = 4.200.000.
        Assert.Equal(
            4_200_000m,
            luong
        );
    }

    [Fact]
    public void CongTy_TinhTongLuong_SuDungDaHinh()
    {
        // Arrange.
        CongTy congTy = new CongTy();

        NhanVien nhanVien1 =
            new NhanVienKinhDoanh(
                "KD01",
                "Nguyen Van An",
                10_000_000m,
                4
            );

        NhanVien nhanVien2 =
            new NhanVienSanXuat(
                "SX01",
                "Tran Thi Binh",
                4_000
            );

        NhanVien nhanVien3 =
            new NhanVienSanXuat(
                "SX02",
                "Le Van Cuong",
                3_000
            );

        congTy.Add(nhanVien1);
        congTy.Add(nhanVien2);
        congTy.Add(nhanVien3);

        // Act.
        decimal tongLuong =
            congTy.TinhTongLuong();

        // Assert.
        Assert.Equal(
            19_200_000m,
            tongLuong
        );
    }

    [Fact]
    public void NhanVienSanXuat_SoSanPhamAm_NemArgumentException()
    {
        // Act.
        Action hanhDong = () =>
            new NhanVienSanXuat(
                "SX01",
                "Tran Thi Binh",
                -1
            );

        // Assert.
        Assert.Throws<ArgumentException>(
            hanhDong
        );
    }
}