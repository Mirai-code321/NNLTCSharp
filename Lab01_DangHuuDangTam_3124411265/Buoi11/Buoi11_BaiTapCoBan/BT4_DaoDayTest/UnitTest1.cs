using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestDaoDay
    {
        [Fact]
        public void Test_DaoDay()
        {
            int[] a = { 2, 4, 3, 4, 2, 8, 2, 5 };

            int[] ketQua = DaoDay.Dao(a);

            int[] mongDoi = { 5, 2, 8, 2, 4, 3, 4, 2 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_DaoDay_3PhanTu()
        {
            int[] a = { 1, 2, 3 };

            int[] ketQua = DaoDay.Dao(a);

            int[] mongDoi = { 3, 2, 1 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_DaoDay_1PhanTu()
        {
            int[] a = { 10 };

            int[] ketQua = DaoDay.Dao(a);

            int[] mongDoi = { 10 };

            Assert.Equal(mongDoi, ketQua);
        }
    }
}
