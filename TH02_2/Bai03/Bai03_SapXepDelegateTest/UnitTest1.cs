using Bai03DelegateSort;

namespace Bai03_DelegateSortTest;

public class DelegateSortTests
{
    [Fact]
    public void SapXep_SoNguyenTangDan_TraVeDungThuTu()
    {
        // Arrange.
        int[] mang =
        {
            5, 2, 8, 1, 4
        };

        SoSanh<int> tangDan =
            (a, b) => a.CompareTo(b);

        // Act.
        BoSapXep.SapXep(
            mang,
            tangDan
        );

        // Assert.
        int[] mongDoi =
        {
            1, 2, 4, 5, 8
        };

        Assert.Equal(mongDoi, mang);
    }

    [Fact]
    public void SapXep_SoNguyenGiamDan_TraVeDungThuTu()
    {
        // Arrange.
        int[] mang =
        {
            5, 2, 8, 1, 4
        };

        SoSanh<int> giamDan =
            (a, b) => b.CompareTo(a);

        // Act.
        BoSapXep.SapXep(
            mang,
            giamDan
        );

        // Assert.
        int[] mongDoi =
        {
            8, 5, 4, 2, 1
        };

        Assert.Equal(mongDoi, mang);
    }

    [Fact]
    public void SapXep_ChuoiTheoDoDai_TraVeDungThuTu()
    {
        // Arrange.
        string[] mang =
        {
            "Chuoi dai",
            "A",
            "Bon",
            "Hai"
        };

        SoSanh<string> theoDoDai =
            (a, b) => a.Length.CompareTo(
                b.Length
            );

        // Act.
        BoSapXep.SapXep(
            mang,
            theoDoDai
        );

        // Assert.
        Assert.Equal("A", mang[0]);
        Assert.Equal(3, mang[1].Length);
        Assert.Equal(3, mang[2].Length);
        Assert.Equal("Chuoi dai", mang[3]);
    }

    [Fact]
    public void SapXep_SinhVienTheoDiemGiamDan_TraVeDungThuTu()
    {
        // Arrange.
        SinhVien[] danhSach =
        {
            new SinhVien(
                "SV01",
                "Nguyen Van A",
                8.5
            ),

            new SinhVien(
                "SV02",
                "Tran Thi B",
                6.5
            ),

            new SinhVien(
                "SV03",
                "Le Van C",
                9
            )
        };

        SoSanh<SinhVien> theoDiem =
            (a, b) =>
                b.DiemTrungBinh.CompareTo(
                    a.DiemTrungBinh
                );

        // Act.
        BoSapXep.SapXep(
            danhSach,
            theoDiem
        );

        // Assert.
        Assert.Equal(
            "SV03",
            danhSach[0].MaSinhVien
        );

        Assert.Equal(
            "SV01",
            danhSach[1].MaSinhVien
        );

        Assert.Equal(
            "SV02",
            danhSach[2].MaSinhVien
        );
    }

    [Fact]
    public void SapXep_DelegateNull_NemArgumentNullException()
    {
        // Arrange.
        int[] mang =
        {
            3, 2, 1
        };

        SoSanh<int>? hamSoSanh = null;

        // Act.
        Action hanhDong = () =>
            BoSapXep.SapXep(
                mang,
                hamSoSanh!
            );

        // Assert.
        Assert.Throws<ArgumentNullException>(
            hanhDong
        );
    }
}