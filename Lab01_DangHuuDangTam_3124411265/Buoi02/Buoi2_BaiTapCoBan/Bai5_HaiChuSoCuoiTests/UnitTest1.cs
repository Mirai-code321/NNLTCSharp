using Xunit;
using HaiChuSoCuoi;

namespace Bai5_HaiChuSoCuoiTests
{
    public class TinhHaiChuSoCuoiTests
    {
        [Fact]
        public void TinhHaiChuSoCuoi_N_Bang2()
        {
            // Arrange
            long n = 2;

            // Act
            int ketQua = Program.TinhHaiChuSoCuoi(n);

            // Assert
            Assert.Equal(44, ketQua);
        }

        [Theory]
        [InlineData(2, 44)]
        [InlineData(3, 89)]
        [InlineData(5, 25)]
        [InlineData(7, 49)]
        [InlineData(10, 0)]
        [InlineData(-3, 89)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(99, 1)]
        public void TinhHaiChuSoCuoi_NhieuTruongHop(long n, int ketQuaMongMuon)
        {
            int ketQua = Program.TinhHaiChuSoCuoi(n);
            Assert.Equal(ketQuaMongMuon, ketQua);
        }
    }
}

