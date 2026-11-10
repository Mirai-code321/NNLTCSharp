using Xunit;
using NNLTCSharp.Buoi02;

namespace NNLTCSharp.Tests
{
    public class UnitTestKiemTraTronThang
    {
        [Fact]
        public void Test_DuongThangCatDuongTron()
        {
            // Arrange
            double x = 0;
            double y = 0;
            double r = 5;

            double A = 1;
            double B = 0;
            double C = -3;

            // Act
            string ketQua = KiemTraTronThang.KiemTra(
                x, y, r, A, B, C);

            // Assert
            Assert.Equal("Cat", ketQua);
        }

        [Fact]
        public void Test_DuongThangTiepXucDuongTron()
        {
            // Arrange
            double x = 0;
            double y = 0;
            double r = 5;

            double A = 1;
            double B = 0;
            double C = -5;

            // Act
            string ketQua = KiemTraTronThang.KiemTra(
                x, y, r, A, B, C);

            // Assert
            Assert.Equal("TiepXuc", ketQua);
        }

        [Fact]
        public void Test_DuongThangKhongCatDuongTron()
        {
            // Arrange
            double x = 0;
            double y = 0;
            double r = 5;

            double A = 1;
            double B = 0;
            double C = -7;

            // Act
            string ketQua = KiemTraTronThang.KiemTra(
                x, y, r, A, B, C);

            // Assert
            Assert.Equal("KhongCat", ketQua);
        }
    }
}

