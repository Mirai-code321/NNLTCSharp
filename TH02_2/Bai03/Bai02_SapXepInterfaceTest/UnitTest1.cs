using Bai02InterfaceSort;

namespace Bai02_InterfaceSortTest;

public class InterfaceSortTests
{
    [Fact]
    public void SapXep_MangSoNguyen_SapXepTangDan()
    {
        // Arrange.
        int[] mang =
        {
            5, 2, 8, 1, 4
        };

        // Act.
        BoSapXep.SapXep(mang);

        // Assert.
        int[] mongDoi =
        {
            1, 2, 4, 5, 8
        };

        Assert.Equal(mongDoi, mang);
    }

    [Fact]
    public void SapXep_MangChuoi_SapXepTheoBangChuCai()
    {
        // Arrange.
        string[] mang =
        {
            "Cam",
            "Buoi",
            "Tao",
            "Dua"
        };

        // Act.
        BoSapXep.SapXep(mang);

        // Assert.
        string[] mongDoi =
        {
            "Buoi",
            "Cam",
            "Dua",
            "Tao"
        };

        Assert.Equal(mongDoi, mang);
    }

    [Fact]
    public void SapXep_MangSinhVien_SapXepTangDanTheoDiem()
    {
        // Arrange.
        SinhVien[] danhSach =
        {
            new SinhVien("SV01", "Nguyen Van A", 8.5),
            new SinhVien("SV02", "Tran Thi B", 6.5),
            new SinhVien("SV03", "Le Van C", 9.0)
        };

        // Act.
        BoSapXep.SapXep(danhSach);

        // Assert.
        Assert.Equal(
            "SV02",
            danhSach[0].MaSinhVien
        );

        Assert.Equal(
            "SV01",
            danhSach[1].MaSinhVien
        );

        Assert.Equal(
            "SV03",
            danhSach[2].MaSinhVien
        );
    }

    [Fact]
    public void SapXep_MangCoPhanTuTrungLap_GiuDayDuPhanTu()
    {
        // Arrange.
        int[] mang =
        {
            3, 1, 3, 2, 1
        };

        // Act.
        BoSapXep.SapXep(mang);

        // Assert.
        int[] mongDoi =
        {
            1, 1, 2, 3, 3
        };

        Assert.Equal(mongDoi, mang);
    }

    [Fact]
    public void SapXep_MangRong_KhongPhatSinhLoi()
    {
        // Arrange.
        int[] mang =
            Array.Empty<int>();

        // Act.
        BoSapXep.SapXep(mang);

        // Assert.
        Assert.Empty(mang);
    }
}