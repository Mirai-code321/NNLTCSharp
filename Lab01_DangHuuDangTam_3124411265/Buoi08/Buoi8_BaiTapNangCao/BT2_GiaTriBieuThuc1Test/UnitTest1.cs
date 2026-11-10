using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class GiaTriBieuThuc1Test
    {
        [Fact]
        public void Test_TinhF_0()
        {
            double ketQua = GiaTriBieuThuc1.TinhF(0);

            Assert.Equal(1, ketQua, 6);
        }

        [Fact]
        public void Test_TinhF_1()
        {
            double ketQua = GiaTriBieuThuc1.TinhF(1);

            double expected = (1 * 1 + 1) * Math.Pow(Math.Cos(1), 2);

            Assert.Equal(expected, ketQua, 6);
        }

        [Fact]
        public void Test_TinhG_1()
        {
            double ketQua = GiaTriBieuThuc1.TinhG(1, 1, 1);

            double expected =
                GiaTriBieuThuc1.TinhF(1)
                + GiaTriBieuThuc1.TinhF(2);

            Assert.Equal(expected, ketQua, 6);
        }

        [Fact]
        public void Test_TinhG_3()
        {
            double ketQua = GiaTriBieuThuc1.TinhG(0, 1, 3);

            double expected =
                GiaTriBieuThuc1.TinhF(0)
                + GiaTriBieuThuc1.TinhF(1)
                + GiaTriBieuThuc1.TinhF(2)
                + GiaTriBieuThuc1.TinhF(3);

            Assert.Equal(expected, ketQua, 6);
        }
    }
}