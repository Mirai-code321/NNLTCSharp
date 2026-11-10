using KhoangCach;

namespace Bai1NC_KhoangCachTest;

public class TinhKhoangCachTests
{
    // Test 1: dung tam giac Pythagoras kinh dien 3-4-5
    // A(0,0), B(3,4) => khoang cach phai bang 5
    [Fact]
    public void TinhKC_TamGiac345_TraVe5()
    {
        double ketQua = TinhKhoangCach.TinhKC(0, 0, 3, 4);
        Assert.Equal(5, ketQua);
    }

    // Test 2: truong hop bien - 2 diem trung nhau
    // Khoang cach phai bang 0
    [Fact]
    public void TinhKC_HaiDiemTrungNhau_TraVe0()
    {
        double ketQua = TinhKhoangCach.TinhKC(2, 2, 2, 2);
        Assert.Equal(0, ketQua);
    }

    // Test 3: toa do co gia tri am
    // Kiem tra Math.Pow binh phuong dung du hieu so am
    [Fact]
    public void TinhKC_ToaDoAm_TinhDungKetQua()
    {
        double ketQua = TinhKhoangCach.TinhKC(-1, -1, 2, 3);
        Assert.Equal(5, ketQua);
    }
}

