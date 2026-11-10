using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestNhapTang
    {
        [Fact]
        public void Test_NhapTang()
        {
            double[] a = new double[5];

            NhapTang.Nhap(a, 0, 5);
            NhapTang.Nhap(a, 1, 2);
            NhapTang.Nhap(a, 2, 8);
            NhapTang.Nhap(a, 3, 4);
            NhapTang.Nhap(a, 4, 1);

            double[] mongDoi = { 1, 2, 4, 5, 8 };

            Assert.Equal(mongDoi, a);
        }

        [Fact]
        public void Test_NhapSoLonHonTatCa()
        {
            double[] a = new double[3];

            NhapTang.Nhap(a, 0, 2);
            NhapTang.Nhap(a, 1, 4);
            NhapTang.Nhap(a, 2, 8);

            double[] mongDoi = { 2, 4, 8 };

            Assert.Equal(mongDoi, a);
        }

        [Fact]
        public void Test_NhapSoNhoHonTatCa()
        {
            double[] a = new double[3];

            NhapTang.Nhap(a, 0, 5);
            NhapTang.Nhap(a, 1, 8);
            NhapTang.Nhap(a, 2, 2);

            double[] mongDoi = { 2, 5, 8 };

            Assert.Equal(mongDoi, a);
        }

        [Fact]
        public void Test_NhapSoVaoGiua()
        {
            double[] a = new double[4];

            NhapTang.Nhap(a, 0, 2);
            NhapTang.Nhap(a, 1, 8);
            NhapTang.Nhap(a, 2, 5);
            NhapTang.Nhap(a, 3, 6);

            double[] mongDoi = { 2, 5, 6, 8 };

            Assert.Equal(mongDoi, a);
        }
    }
}
