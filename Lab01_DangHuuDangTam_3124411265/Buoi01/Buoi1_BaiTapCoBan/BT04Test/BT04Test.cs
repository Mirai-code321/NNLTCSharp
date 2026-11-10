using Xunit;
using NNLTCSharp.Buoi01;

namespace NNLTCSharp.Tests
{
    public class UnitTestBai04
    {
        [Fact]
        public void Test_Bai04_4810()
        {
            // Arrange
            long tongGiay = 4810;

            // Act
            string ketQua = ThoiGian.DoiThoiGian(tongGiay);

            // Assert
            Assert.Equal("1:20:10", ketQua);
        }

        [Fact]
        public void Test_Bai04_3600()
        {
            // Arrange
            long tongGiay = 3600;

            // Act
            string ketQua = ThoiGian.DoiThoiGian(tongGiay);

            // Assert
            Assert.Equal("1:0:0", ketQua);
        }

        [Fact]
        public void Test_Bai04_60()
        {
            // Arrange
            long tongGiay = 60;

            // Act
            string ketQua = ThoiGian.DoiThoiGian(tongGiay);

            // Assert
            Assert.Equal("0:1:0", ketQua);
        }

        [Fact]
        public void Test_Bai04_0()
        {
            // Arrange
            long tongGiay = 0;

            // Act
            string ketQua = ThoiGian.DoiThoiGian(tongGiay);

            // Assert
            Assert.Equal("0:0:0", ketQua);
        }
    }
}
