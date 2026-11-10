using Xunit;
using NNLTCSharp.Buoi04;

namespace NNLTCSharp.Tests
{
    public class UnitTestPhuongTrinhBac3
    {
        [Fact]
        public void Test_3NghiemPhanBiet()
        {
            string ketQua =
                PhuongTrinhBac3.Giai(1, -6, 11, -6);

                Assert.Contains("1.00", ketQua);
                Assert.Contains("2.00", ketQua);
                Assert.Contains("3.00", ketQua);
        }

        [Fact]
        public void Test_1NghiemThuc()
        {
            // x^3 - x - 1 = 0
            string ketQua =
                PhuongTrinhBac3.Giai(1, 0, -1, -1);

            Assert.Contains("1 nghiem thuc", ketQua);
        }

        [Fact]
        public void Test_NghiemKep()
        {
            // x^3 - 3x + 2 = 0
            // (x - 1)^2(x + 2) = 0
            string ketQua =
                PhuongTrinhBac3.Giai(1, 0, -3, 2);

            Assert.Contains("x1 = -2.00", ketQua);
            Assert.Contains("x2 = 1.00", ketQua);
        }
    }
}

