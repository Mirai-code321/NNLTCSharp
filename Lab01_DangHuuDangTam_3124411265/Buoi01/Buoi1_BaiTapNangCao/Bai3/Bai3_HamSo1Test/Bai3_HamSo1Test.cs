using HamSo1;

namespace Bai3_HamSo1Test;

public class TinhHamSoTests
{
    // Test 1: x=0 -> y1 = 4*(0 + 0 + 0 + 1) = 4
    [Fact]
    public void TinhY1_XBangKhong_TraVe4()
    {
        double ketQua = TinhHamSo.TinhY1(0);
        Assert.Equal(4, ketQua);
    }

    // Test 2: x=1 -> y1 = 4*(1 + 10*1*1 + 3 + 1) = 4*15 = 60
    [Fact]
    public void TinhY1_XBangMot_TraVe60()
    {
        double ketQua = TinhHamSo.TinhY1(1);
        Assert.Equal(60, ketQua);
    }

    // Test 3: x=0 -> tu so = sin(0)+can(1) = 1, mau so = e^0+cos(0) = 2 -> y2 = 0.5
    [Fact]
    public void TinhY2_XBangKhong_TraVe05()
    {
        double ketQua = TinhHamSo.TinhY2(0);
        Assert.Equal(0.5, ketQua);
    }
}

