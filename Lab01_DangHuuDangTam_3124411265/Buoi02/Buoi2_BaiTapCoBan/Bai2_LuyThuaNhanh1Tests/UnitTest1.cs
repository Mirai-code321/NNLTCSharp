using Xunit;
using LuyThuaNhanh1;

namespace Bai2_LuyThuaNhanh1Tests
{
    public class TinhLuyThuaTests
    {
        [Fact]
        public void TinhLuyThua_A_Bang2()
        {
            // Arrange
            double a = 2;

            // Act
            var (aMu2, aMu5, aMu17) = Program.TinhLuyThua(a);

            // Assert
            Assert.Equal(4, aMu2);
            Assert.Equal(32, aMu5);
            Assert.Equal(131072, aMu17);
        }

        [Theory]
        [InlineData(1, 1, 1, 1)]
        [InlineData(3, 9, 243, 129140163)]
        [InlineData(0.5, 0.25, 0.03125, 0.00000762939453125)]
        public void TinhLuyThua_NhieuTruongHop(double a, double kqA2, double kqA5, double kqA17)
        {
            var (aMu2, aMu5, aMu17) = Program.TinhLuyThua(a);

            Assert.Equal(kqA2, aMu2, precision: 10);
            Assert.Equal(kqA5, aMu5, precision: 10);
            Assert.Equal(kqA17, aMu17, precision: 10);
        }
    }
}

