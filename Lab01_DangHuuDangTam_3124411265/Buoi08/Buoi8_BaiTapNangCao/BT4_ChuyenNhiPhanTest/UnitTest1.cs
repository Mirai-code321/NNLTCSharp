using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class ChuyenNhiPhanTest
    {
        [Fact]
        public void Test_Chuyen_3_5()
        {
            string ketQua = ChuyenNhiPhan.Chuyen(3.5);

            Assert.Equal("11.1000000000", ketQua);
        }

        [Fact]
        public void Test_Chuyen_5_3()
        {
            string ketQua = ChuyenNhiPhan.Chuyen(5.3);

            Assert.Equal("101.0100110011", ketQua);
        }

        [Fact]
        public void Test_Chuyen_0_5()
        {
            string ketQua = ChuyenNhiPhan.Chuyen(0.5);

            Assert.Equal("0.1000000000", ketQua);
        }

        [Fact]
        public void Test_Chuyen_10()
        {
            string ketQua = ChuyenNhiPhan.Chuyen(10);

            Assert.Equal("1010.0000000000", ketQua);
        }

        [Fact]
        public void Test_Chuyen_7_25()
        {
            string ketQua = ChuyenNhiPhan.Chuyen(7.25);

            Assert.Equal("111.0100000000", ketQua);
        }
    }
}