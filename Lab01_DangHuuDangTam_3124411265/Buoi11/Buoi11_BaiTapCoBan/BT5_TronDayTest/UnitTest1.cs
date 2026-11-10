using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestTronDay
    {
        [Fact]
        public void Test_TronDay()
        {
            int[] a = { 1, 5, 8, 10 };
            int[] b = { 2, 3, 7, 9 };

            int[] ketQua = TronDay.Tron(a, b);

            int[] mongDoi = { 1, 2, 3, 5, 7, 8, 9, 10 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_DayB_Rong()
        {
            int[] a = { 1, 3, 5 };
            int[] b = { };

            int[] ketQua = TronDay.Tron(a, b);

            int[] mongDoi = { 1, 3, 5 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_DayA_Rong()
        {
            int[] a = { };
            int[] b = { 2, 4, 6 };

            int[] ketQua = TronDay.Tron(a, b);

            int[] mongDoi = { 2, 4, 6 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_HaiDayCoPhanTuTrungNhau()
        {
            int[] a = { 1, 3, 5 };
            int[] b = { 2, 3, 6 };

            int[] ketQua = TronDay.Tron(a, b);

            int[] mongDoi = { 1, 2, 3, 3, 5, 6 };

            Assert.Equal(mongDoi, ketQua);
        }
    }
}
