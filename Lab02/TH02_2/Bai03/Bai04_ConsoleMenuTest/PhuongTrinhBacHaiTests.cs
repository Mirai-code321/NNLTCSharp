using Xunit;
using Bai04ConsoleMenu;

namespace Bai04_ConsoleMenuTest;

public class PhuongTrinhBacHaiTests
{
    [Fact]
    public void Giai_A0B0C0_TraVeVoSoNghiem()
    {
        // Arrange.
        PhuongTrinhBacHai phuongTrinh =
            new PhuongTrinhBacHai(0, 0, 0);

        // Act.
        KetQuaPhuongTrinh ketQua =
            phuongTrinh.Giai();

        // Assert.
        Assert.Equal(
            LoaiNghiem.VoSoNghiem,
            ketQua.LoaiNghiem
        );
    }

    [Fact]
    public void Giai_PhuongTrinhBacNhat_TraVeMotNghiem()
    {
        // Arrange:
        // 2x - 4 = 0 co nghiem x = 2.
        PhuongTrinhBacHai phuongTrinh =
            new PhuongTrinhBacHai(0, 2, -4);

        // Act.
        KetQuaPhuongTrinh ketQua =
            phuongTrinh.Giai();

        // Assert.
        Assert.Equal(
            LoaiNghiem.MotNghiem,
            ketQua.LoaiNghiem
        );

        Assert.NotNull(ketQua.X1);

        Assert.Equal(
            2,
            ketQua.X1.Value,
            10
        );
    }

    [Fact]
    public void Giai_DeltaAm_TraVeVoNghiem()
    {
        // Arrange:
        // x^2 + x + 1 = 0 co delta = -3.
        PhuongTrinhBacHai phuongTrinh =
            new PhuongTrinhBacHai(1, 1, 1);

        // Act.
        KetQuaPhuongTrinh ketQua =
            phuongTrinh.Giai();

        // Assert.
        Assert.Equal(
            LoaiNghiem.VoNghiem,
            ketQua.LoaiNghiem
        );

        Assert.Null(ketQua.X1);
        Assert.Null(ketQua.X2);
    }

    [Fact]
    public void Giai_DeltaBangKhong_TraVeNghiemKep()
    {
        // Arrange:
        // x^2 - 2x + 1 = 0 co nghiem kep x = 1.
        PhuongTrinhBacHai phuongTrinh =
            new PhuongTrinhBacHai(1, -2, 1);

        // Act.
        KetQuaPhuongTrinh ketQua =
            phuongTrinh.Giai();

        // Assert.
        Assert.Equal(
            LoaiNghiem.NghiemKep,
            ketQua.LoaiNghiem
        );

        Assert.NotNull(ketQua.X1);
        Assert.NotNull(ketQua.X2);

        Assert.Equal(
            1,
            ketQua.X1.Value,
            10
        );

        Assert.Equal(
            1,
            ketQua.X2.Value,
            10
        );
    }

    [Fact]
    public void Giai_DeltaDuong_TraVeHaiNghiemPhanBiet()
    {
        // Arrange:
        // x^2 - 3x + 2 = 0 co hai nghiem 2 va 1.
        PhuongTrinhBacHai phuongTrinh =
            new PhuongTrinhBacHai(1, -3, 2);

        // Act.
        KetQuaPhuongTrinh ketQua =
            phuongTrinh.Giai();

        // Assert.
        Assert.Equal(
            LoaiNghiem.HaiNghiemPhanBiet,
            ketQua.LoaiNghiem
        );

        Assert.NotNull(ketQua.X1);
        Assert.NotNull(ketQua.X2);

        Assert.Equal(
            2,
            ketQua.X1.Value,
            10
        );

        Assert.Equal(
            1,
            ketQua.X2.Value,
            10
        );
    }
}