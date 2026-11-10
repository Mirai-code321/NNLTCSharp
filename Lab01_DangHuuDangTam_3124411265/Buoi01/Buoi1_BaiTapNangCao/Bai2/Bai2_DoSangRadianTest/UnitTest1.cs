using DoSangRadian;

namespace Bai2_DoSangRadianTest;

public class ChuyenDoiGocTests
{
    // Test 1: 180 do phai bang chinh xac PI radian
    [Fact]
    public void DoiSangRadian_180Do_TraVePI()
    {
        double ketQua = ChuyenDoiGoc.DoiSangRadian(180);
        Assert.Equal(Math.PI, ketQua);
    }

    // Test 2: 90 do phai bang PI/2 radian
    [Fact]
    public void DoiSangRadian_90Do_TraVeNuaPI()
    {
        double ketQua = ChuyenDoiGoc.DoiSangRadian(90);
        Assert.Equal(Math.PI / 2, ketQua);
    }

    // Test 3: 0 do phai bang 0 radian
    [Fact]
    public void DoiSangRadian_0Do_TraVe0()
    {
        double ketQua = ChuyenDoiGoc.DoiSangRadian(0);
        Assert.Equal(0, ketQua);
    }
}

