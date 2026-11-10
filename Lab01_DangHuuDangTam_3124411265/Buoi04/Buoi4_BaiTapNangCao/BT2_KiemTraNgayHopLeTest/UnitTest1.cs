using Xunit;
using NNLTCSharp.Buoi04;

namespace NNLTCSharp.Tests
{
    public class UnitTestKiemTraNgayHopLe
    {
        [Fact]
        public void Test_NgayHopLe()
        {
            Assert.True(KiemTraNgayHopLe.KiemTra(31, 10, 2013));
        }

        [Fact]
        public void Test_NgayKhongHopLe()
        {
            Assert.False(KiemTraNgayHopLe.KiemTra(32, 10, 2013));
        }

        [Fact]
        public void Test_Thang2_NamThuong()
        {
            Assert.True(KiemTraNgayHopLe.KiemTra(28, 2, 2013));
            Assert.False(KiemTraNgayHopLe.KiemTra(29, 2, 2013));
        }

        [Fact]
        public void Test_Thang2_NamNhuan()
        {
            Assert.True(KiemTraNgayHopLe.KiemTra(29, 2, 2016));
            Assert.False(KiemTraNgayHopLe.KiemTra(30, 2, 2016));
        }

        [Fact]
        public void Test_Thang30Ngay()
        {
            Assert.True(KiemTraNgayHopLe.KiemTra(30, 4, 2013));
            Assert.False(KiemTraNgayHopLe.KiemTra(31, 4, 2013));
        }

        [Fact]
        public void Test_ThangKhongHopLe()
        {
            Assert.False(KiemTraNgayHopLe.KiemTra(10, 13, 2013));
            Assert.False(KiemTraNgayHopLe.KiemTra(0, 1, 2013));
        }
    }
}

