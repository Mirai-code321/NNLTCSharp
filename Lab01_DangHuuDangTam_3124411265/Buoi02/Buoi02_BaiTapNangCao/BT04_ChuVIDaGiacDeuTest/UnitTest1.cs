using Xunit;
using NNLTCSharp.Buoi02;

namespace NNLTCSharp.Tests
{
    public class UnitTestChuViDaGiacDeu
    {
        [Fact]
        public void Test_HinhVuong()
        {
            // Arrange
            int n = 4;
            double R = 5;

            // Act
            double ketQua = ChuViDaGiacDeu.TinhChuVi(n, R);

            // Assert
            Assert.Equal(28.28, Math.Round(ketQua, 2));
        }

        [Fact]
        public void Test_TamGiacDeu()
        {
            // Arrange
            int n = 3;
            double R = 2;

            // Act
            double ketQua = ChuViDaGiacDeu.TinhChuVi(n, R);

            // Assert
            Assert.Equal(10.39, Math.Round(ketQua, 2));
        }

        [Fact]
        public void Test_NguGiacDeu()
        {
            // Arrange
            int n = 5;
            double R = 3;

            // Act
            double ketQua = ChuViDaGiacDeu.TinhChuVi(n, R);

            // Assert
            Assert.Equal(17.63, Math.Round(ketQua, 2));
        }

        [Fact]
        public void Test_LucGiacDeu()
        {
            // Arrange
            int n = 6;
            double R = 4;

            // Act
            double ketQua = ChuViDaGiacDeu.TinhChuVi(n, R);

            // Assert
            Assert.Equal(24.00, Math.Round(ketQua, 2));
        }
    }
}

