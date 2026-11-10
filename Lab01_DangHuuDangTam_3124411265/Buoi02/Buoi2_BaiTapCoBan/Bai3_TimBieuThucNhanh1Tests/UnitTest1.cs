using Xunit;
using BieuThucNhanh1;

namespace Bai3_BieuThucNhanh1Tests
{
    public class TinhBieuThucTests
    {
        [Fact]
        public void TinhBieuThuc_X_Bang3()
        {
            // Arrange
            double x = 3;

            // Act
            double ketQua = Program.TinhBieuThuc(x);

            // Assert
            Assert.Equal(-74, ketQua);
        }

        [Theory]
        [InlineData(0, 1)]      // f(0) = 1
        [InlineData(1, 2)]      // f(1) = 1+2+3-4 = 2
        [InlineData(-1, 6)]     // f(-1) = 1-2+3+4 = 6 (đã sửa)
        [InlineData(2, -15)]    // f(2) = 1+4+12-32 = -15 (đã sửa)
        public void TinhBieuThuc_NhieuTruongHop(double x, double ketQuaMongMuon)
        {
            double ketQua = Program.TinhBieuThuc(x);
            Assert.Equal(ketQuaMongMuon, ketQua, precision: 10);
        }   
    }
}

