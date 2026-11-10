using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestSapChanLe
    {
        [Fact]
        public void Test_SapChanLe()
        {
            int[] a = { 2, 4, 3, 4, 2, 8, 2, 5 };

            int[] ketQua = SapChanLe.SapXep(a);

            int[] mongDoi = { 2, 2, 2, 4, 4, 8, 5, 3 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_TatCaSoChan()
        {
            int[] a = { 8, 2, 6, 4 };

            int[] ketQua = SapChanLe.SapXep(a);

            int[] mongDoi = { 2, 4, 6, 8 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_TatCaSoLe()
        {
            int[] a = { 3, 9, 1, 5 };

            int[] ketQua = SapChanLe.SapXep(a);

            int[] mongDoi = { 9, 5, 3, 1 };

            Assert.Equal(mongDoi, ketQua);
        }
    }
}
