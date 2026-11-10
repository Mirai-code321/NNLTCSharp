using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class TinhExTest
    {
        [Fact]
        public void Test_TinhEx_0()
        {
            double ketQua = TinhEx.Tinh(0, 0.000001);

            Assert.Equal(1, ketQua, 6);
        }

        [Fact]
        public void Test_TinhEx_1()
        {
            double ketQua = TinhEx.Tinh(1, 0.000001);

            Assert.Equal(2.718281, ketQua, 5);
        }

        [Fact]
        public void Test_TinhEx_2()
        {
            double ketQua = TinhEx.Tinh(2, 0.000001);

            Assert.Equal(7.389056, ketQua, 5);
        }

        [Fact]
        public void Test_TinhEx_3()
        {
            double ketQua = TinhEx.Tinh(3, 0.000001);

            Assert.Equal(20.085537, ketQua, 5);
        }
    }
}