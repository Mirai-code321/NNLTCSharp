using Xunit;
using NNLTCSharp.Buoi02;

namespace NNLTCSharp.Tests
{
    public class UnitTestChuSoGiaiThua
    {
        [Fact]
        public void Test_K_1()
        {
            string ketQua = ChuSoGiaiThua.TinhChuSoCuoi(1);

            Assert.Equal("0", ketQua);
        }

        [Fact]
        public void Test_K_2()
        {
            string ketQua = ChuSoGiaiThua.TinhChuSoCuoi(2);

            Assert.Equal("00", ketQua);
        }

        [Fact]
        public void Test_K_3()
        {
            string ketQua = ChuSoGiaiThua.TinhChuSoCuoi(3);

            Assert.Equal("000", ketQua);
        }

        [Fact]
        public void Test_K_4()
        {
            string ketQua = ChuSoGiaiThua.TinhChuSoCuoi(4);

            Assert.Equal("0000", ketQua);
        }

        [Fact]
        public void Test_K_5()
        {
            string ketQua = ChuSoGiaiThua.TinhChuSoCuoi(5);

            Assert.Equal("00000", ketQua);
        }
    }
}

