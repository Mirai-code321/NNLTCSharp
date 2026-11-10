using Xunit;
using NNLTCSharp.Buoi02;

namespace NNLTCSharp.Tests
{
    public class UnitTestDienTichToDam
    {
        [Fact]
        public void Test_A_Bang_1()
        {
            double ketQua = DienTichToDam.TinhDienTich(1);

            Assert.Equal(Math.PI / 2, ketQua, 10);
        }

        [Fact]
        public void Test_A_Bang_2()
        {
            double ketQua = DienTichToDam.TinhDienTich(2);

            Assert.Equal(2 * Math.PI, ketQua, 10);
        }

        [Fact]
        public void Test_A_Bang_3()
        {
            double ketQua = DienTichToDam.TinhDienTich(3);

            Assert.Equal(9 * Math.PI / 2, ketQua, 10);
        }

        [Fact]
        public void Test_A_Bang_5()
        {
            double ketQua = DienTichToDam.TinhDienTich(5);

            Assert.Equal(25 * Math.PI / 2, ketQua, 10);
        }
    }
}

