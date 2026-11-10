using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestSapNguyenTo
    {
        [Fact]
        public void Test_SapNguyenTo()
        {
            int[] a = { 5, 6, 4, 7, 8, 12, 2, 8, 3 };

            int[] ketQua = SapNguyenTo.SapXep(a);

            int[] mongDoi = { 2, 6, 4, 3, 8, 12, 5, 8, 7 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_KiemTraSoNguyenTo()
        {
            Assert.True(SapNguyenTo.LaSoNguyenTo(2));
            Assert.True(SapNguyenTo.LaSoNguyenTo(7));
            Assert.True(SapNguyenTo.LaSoNguyenTo(13));
        }

        [Fact]
        public void Test_KhongPhaiSoNguyenTo()
        {
            Assert.False(SapNguyenTo.LaSoNguyenTo(1));
            Assert.False(SapNguyenTo.LaSoNguyenTo(4));
            Assert.False(SapNguyenTo.LaSoNguyenTo(10));
        }

        [Fact]
        public void Test_TatCaLaSoNguyenTo()
        {
            int[] a = { 7, 3, 11, 2 };

            int[] ketQua = SapNguyenTo.SapXep(a);

            int[] mongDoi = { 2, 3, 7, 11 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_KhongCoSoNguyenTo()
        {
            int[] a = { 4, 6, 8, 10 };

            int[] ketQua = SapNguyenTo.SapXep(a);

            int[] mongDoi = { 4, 6, 8, 10 };

            Assert.Equal(mongDoi, ketQua);
        }
    }
}
