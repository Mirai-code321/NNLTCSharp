using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestXoaChan
    {
        [Fact]
        public void Test_XoaChan()
        {
            int[] a = { 2, 4, 3, 4, 2, 8, 2, 5 };

            int[] ketQua = XoaChan.Xoa(a);

            int[] mongDoi = { 3, 5 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_TatCaSoLe()
        {
            int[] a = { 1, 3, 5, 7 };

            int[] ketQua = XoaChan.Xoa(a);

            int[] mongDoi = { 1, 3, 5, 7 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_TatCaSoChan()
        {
            int[] a = { 2, 4, 6, 8 };

            int[] ketQua = XoaChan.Xoa(a);

            int[] mongDoi = { };

            Assert.Equal(mongDoi, ketQua);
        }
    }
}
