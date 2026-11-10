using Xunit;
using GiaTriHamSo1;

namespace Bai2_GiaTriHamSo1Tests
{
    public class TinhHamSoTests
    {
        [Fact]
        public void TinhF1F2_ViDuMau_X_Bang_1_2()
        {
            // Arrange
            double x = 1.2;

            // Act
            double f1 = Program.TinhF1(x);
            double f2 = Program.TinhF2(x);

            // Assert
            Assert.Equal(2.0736, f1, precision: 10);
            Assert.Equal(11.24, f2, precision: 10);
        }

        [Theory]
        [InlineData(-5, 0)]     // x <= 0
        [InlineData(0, 0)]      // x = 0 (bien)
        [InlineData(0.5, 0.5)]  // 0 < x <= 1
        [InlineData(1, 1)]      // x = 1 (bien)
        [InlineData(2, 16)]     // x > 1
        [InlineData(10, 10000)]
        public void TinhF1_NhieuTruongHop(double x, double f1MongMuon)
        {
            double ketQua = Program.TinhF1(x);
            Assert.Equal(f1MongMuon, ketQua, precision: 10);
        }

        [Theory]
        [InlineData(-5, 10)]
        [InlineData(0, 5)]
        [InlineData(2, 17)]                          // x = 2 (bien, dung nhanh x<=2)
        [InlineData(3, 0.038461538461538464)]        // x > 2
        [InlineData(10, 0.006896551724137931)]
        public void TinhF2_NhieuTruongHop(double x, double f2MongMuon)
        {
            double ketQua = Program.TinhF2(x);
            Assert.Equal(f2MongMuon, ketQua, precision: 10);
        }
    }
}

