using DoiSangGiay;

namespace Bai3_DoiSangGiayTest;

public class ChuyenDoiTests
{
    [Fact]
    public void TinhTongGiay_ViDuTrongDe_TraVe4810()
    {
        int ketQua = ChuyenDoi.TinhTongGiay(1, 20, 10);
        Assert.Equal(4810, ketQua);
    }

    [Fact]
    public void TinhTongGiay_MotGioTron_TraVe3600()
    {
        int ketQua = ChuyenDoi.TinhTongGiay(1, 0, 0);
        Assert.Equal(3600, ketQua);
    }

    [Fact]
    public void TinhTongGiay_TatCaBangKhong_TraVe0()
    {
        int ketQua = ChuyenDoi.TinhTongGiay(0, 0, 0);
        Assert.Equal(0, ketQua);
    }
}
