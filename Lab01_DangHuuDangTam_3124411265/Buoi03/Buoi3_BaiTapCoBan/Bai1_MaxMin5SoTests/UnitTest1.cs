using Xunit;
using MaxMin5So;

namespace Bai1_MaxMin5SoTests
{
    public class TimMaxMinTests
    {
        [Fact]
        public void TimMaxMin_VoiViDuMau()
        {
            // Arrange
            int a = 1, b = 5, c = 6, d = 2, e = 8;

            // Act
            var (max, min) = Program.TimMaxMin(a, b, c, d, e);

            // Assert
            Assert.Equal(8, max);
            Assert.Equal(1, min);
        }

        [Theory]
        [InlineData(1, 5, 6, 2, 8, 8, 1)]
        [InlineData(10, 10, 10, 10, 10, 10, 10)]     // 5 so bang nhau
        [InlineData(-3, -1, -7, 0, -2, 0, -7)]       // co so am
        [InlineData(100, 1, 50, 99, 2, 100, 1)]      // max o vi tri dau
        [InlineData(0, 0, 0, 0, 1, 1, 0)]             // min lap lai nhieu lan
        public void TimMaxMin_NhieuTruongHop(int a, int b, int c, int d, int e, int maxMongMuon, int minMongMuon)
        {
            var (max, min) = Program.TimMaxMin(a, b, c, d, e);

            Assert.Equal(maxMongMuon, max);
            Assert.Equal(minMongMuon, min);
        }
    }
}

