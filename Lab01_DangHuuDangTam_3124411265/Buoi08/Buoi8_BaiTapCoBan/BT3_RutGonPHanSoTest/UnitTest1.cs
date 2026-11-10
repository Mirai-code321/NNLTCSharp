using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class RutGonPhanSoTest
    {
        [Fact]
        public void Test_RutGon_12_18()
        {
            string ketQua = RutGonPhanSo.RutGon(12, 18);

            Assert.Equal("2/3", ketQua);
        }

        [Fact]
        public void Test_RutGon_20_30()
        {
            string ketQua = RutGonPhanSo.RutGon(20, 30);

            Assert.Equal("2/3", ketQua);
        }

        [Fact]
        public void Test_RutGon_8_4()
        {
            string ketQua = RutGonPhanSo.RutGon(8, 4);

            Assert.Equal("2/1", ketQua);
        }

        [Fact]
        public void Test_RutGon_15_25()
        {
            string ketQua = RutGonPhanSo.RutGon(15, 25);

            Assert.Equal("3/5", ketQua);
        }

        [Fact]
        public void Test_UCLN_12_18()
        {
            int ketQua = RutGonPhanSo.TimUCLN(12, 18);

            Assert.Equal(6, ketQua);
        }
    }
}