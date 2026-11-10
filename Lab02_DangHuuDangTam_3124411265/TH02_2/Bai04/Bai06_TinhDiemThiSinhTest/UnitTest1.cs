using Xunit;
using Bai06TinhDiemThiSinh;

namespace Bai06_TinhDiemThiSinhTest;

public class TinhDiemThiSinhTests
{
    [Fact]
    public void ThiSinhChuyen_TiengAnh7Den8_CongMotDiem()
    {
        // Arrange.
        ThiSinhChuyen thiSinh =
            new ThiSinhChuyen(
                "C01",
                "Nguyen Van An",
                8,
                7,
                9,
                8
            );

        // Act.
        double tongDiem =
            thiSinh.TinhTongDiem();

        // Assert:
        // 8 + 7 + 9 + 1 = 25.
        Assert.Equal(1, thiSinh.TinhDiemThuong());
        Assert.Equal(25, tongDiem, 10);
    }

    [Fact]
    public void ThiSinhChuyen_TiengAnh9Den10_CongHaiDiem()
    {
        // Arrange.
        ThiSinhChuyen thiSinh =
            new ThiSinhChuyen(
                "C01",
                "Nguyen Van An",
                8,
                7,
                9,
                9
            );

        // Act.
        double tongDiem =
            thiSinh.TinhTongDiem();

        // Assert:
        // 8 + 7 + 9 + 2 = 26.
        Assert.Equal(2, thiSinh.TinhDiemThuong());
        Assert.Equal(26, tongDiem, 10);
    }

    [Fact]
    public void ThiSinhChuyen_TiengAnhNgoaiKhoangThuong_KhongCongDiem()
    {
        // Arrange.
        ThiSinhChuyen thiSinh =
            new ThiSinhChuyen(
                "C01",
                "Nguyen Van An",
                8,
                7,
                9,
                6.5
            );

        // Act.
        double tongDiem =
            thiSinh.TinhTongDiem();

        // Assert:
        // 8 + 7 + 9 = 24.
        Assert.Equal(0, thiSinh.TinhDiemThuong());
        Assert.Equal(24, tongDiem, 10);
    }

    [Fact]
    public void ThiSinhSieuCup_TinhTongBonBai_TraVeDungKetQua()
    {
        // Arrange.
        ThiSinhSieuCup thiSinh =
            new ThiSinhSieuCup(
                "S01",
                "Tran Thi Binh",
                8,
                7,
                9,
                8
            );

        // Act.
        double tongDiem =
            thiSinh.TinhTongDiem();

        // Assert:
        // 8 + 7 + 9 + 8 = 32.
        Assert.Equal(32, tongDiem, 10);
    }

    [Fact]
    public void CuocThi_DanhSachHaiLoaiThiSinh_SuDungDaHinh()
    {
        // Arrange.
        CuocThi cuocThi = new CuocThi();

        ThiSinh thiSinhChuyen =
            new ThiSinhChuyen(
                "C01",
                "Nguyen Van An",
                8,
                7,
                9,
                9
            );

        ThiSinh thiSinhSieuCup =
            new ThiSinhSieuCup(
                "S01",
                "Tran Thi Binh",
                8,
                7,
                9,
                8
            );

        cuocThi.Add(thiSinhChuyen);
        cuocThi.Add(thiSinhSieuCup);

        // Act va Assert.
        Assert.Equal(2, cuocThi.Count);

        Assert.IsType<ThiSinhChuyen>(
            cuocThi[0]
        );

        Assert.IsType<ThiSinhSieuCup>(
            cuocThi[1]
        );

        // Goi cung mot property nhung ket qua duoc
        // tinh theo dung lop con.
        Assert.Equal(
            26,
            cuocThi[0].TongDiem,
            10
        );

        Assert.Equal(
            32,
            cuocThi[1].TongDiem,
            10
        );
    }
}