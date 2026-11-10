using TinhCan;

namespace Bai4_TinhCanTest;

public class TinhCanBacNTests
{
    [Fact]
    public void TinhCan_CanBacHaiCua16_TraVe4()
    {
        double ketQua = TinhCanBacN.TinhCan(16, 2);
        Assert.Equal(4, ketQua);
    }

    [Fact]
    public void TinhCan_CanBacBaCua27_TraVe3()
    {
        double ketQua = TinhCanBacN.TinhCan(27, 3);
        Assert.Equal(3, ketQua, 3); // sai so cho phep 0.001 do Math.Pow co lam tron
    }

    [Fact]
    public void TinhCan_CanBacMotCuaBatKy_BangChinhNo()
    {
        double ketQua = TinhCanBacN.TinhCan(7, 1);
        Assert.Equal(7, ketQua);
    }
}

