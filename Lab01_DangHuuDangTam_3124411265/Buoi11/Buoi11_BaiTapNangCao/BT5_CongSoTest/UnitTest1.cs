using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestCongSo
    {
        [Fact]
        public void Test_CongHaiSo()
        {
            int[] a = { 9, 8, 7 };
            int[] b = { 5, 6 };

            int[] ketQua = CongSo.Cong(a, b);

            int[] mongDoi = { 1, 0, 4, 3 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_HaiSoCungDoDai()
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 4, 5, 6 };

            int[] ketQua = CongSo.Cong(a, b);

            int[] mongDoi = { 5, 7, 9 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_CongCoNho()
        {
            int[] a = { 9, 9 };
            int[] b = { 1 };

            int[] ketQua = CongSo.Cong(a, b);

            int[] mongDoi = { 1, 0, 0 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_MangB_DaiHonMangA()
        {
            int[] a = { 5, 6 };
            int[] b = { 9, 8, 7 };

            int[] ketQua = CongSo.Cong(a, b);

            int[] mongDoi = { 1, 0, 4, 3 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_KhongCoNho()
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 4, 5, 6 };

            int[] ketQua = CongSo.Cong(a, b);

            int[] mongDoi = { 5, 7, 9 };

            Assert.Equal(mongDoi, ketQua);
        }
    }
}
