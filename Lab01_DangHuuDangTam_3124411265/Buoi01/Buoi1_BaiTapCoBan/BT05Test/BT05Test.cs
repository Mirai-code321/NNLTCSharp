using Xunit;
using NNLTCSharp.Buoi01;

namespace NNLTCSharp.Tests
{
    public class UnitTestBai05
    {
        [Fact]
        public void Test_Bai05_2_4_3()
        {
            // Arrange
            double a = 2;
            double b = 4;
            double c = 3;

            // Act
            double ketQua = TamGiac.TinhDienTich(a, b, c);

            // Assert
            Assert.Equal(2.90, Math.Round(ketQua, 2));
        }

        [Fact]
        public void Test_Bai05_3_4_5()
        {
            // Arrange
            double a = 3;
            double b = 4;
            double c = 5;

            // Act
            double ketQua = TamGiac.TinhDienTich(a, b, c);

            // Assert
            Assert.Equal(6.00, Math.Round(ketQua, 2));
        }

        [Fact]
        public void Test_Bai05_5_5_6()
        {
            // Arrange
            double a = 5;
            double b = 5;
            double c = 6;

            // Act
            double ketQua = TamGiac.TinhDienTich(a, b, c);

            // Assert
            Assert.Equal(12.00, Math.Round(ketQua, 2));
        }

        [Fact]
        public void Test_Bai05_6_8_10()
        {
            // Arrange
            double a = 6;
            double b = 8;
            double c = 10;

            // Act
            double ketQua = TamGiac.TinhDienTich(a, b, c);

            // Assert
            Assert.Equal(24.00, Math.Round(ketQua, 2));
        }
    }
}
