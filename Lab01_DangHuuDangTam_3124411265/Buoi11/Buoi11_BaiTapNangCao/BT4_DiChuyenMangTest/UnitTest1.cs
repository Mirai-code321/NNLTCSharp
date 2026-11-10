using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestDiChuyen
    {
        [Fact]
        public void Test_DiChuyen_3PhanTu()
        {
            int[] a = { 5, 7, 2, 5, 7, 9, 8, 2 };

            int[] ketQua = DiChuyen.DiChuyenKPhanTu(a, 3);

            int[] mongDoi = { 5, 7, 9, 8, 2, 5, 7, 2 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_DiChuyen_1PhanTu()
        {
            int[] a = { 1, 2, 3, 4, 5 };

            int[] ketQua = DiChuyen.DiChuyenKPhanTu(a, 1);

            int[] mongDoi = { 2, 3, 4, 5, 1 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_DiChuyen_KBangNTru1()
        {
            int[] a = { 1, 2, 3, 4, 5 };

            int[] ketQua = DiChuyen.DiChuyenKPhanTu(a, 4);

            int[] mongDoi = { 5, 1, 2, 3, 4 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_KBang0()
        {
            int[] a = { 1, 2, 3, 4, 5 };

            int[] ketQua = DiChuyen.DiChuyenKPhanTu(a, 0);

            int[] mongDoi = { 1, 2, 3, 4, 5 };

            Assert.Equal(mongDoi, ketQua);
        }
    }
}
