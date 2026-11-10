using Xunit;
using ChuSoLonNhat;

namespace Bai1_ChuSoLonNhatTests
{
    public class TimChuSoLonNhatTests
    {
        [Fact]
        public void TimChuSoLonNhat_So1234()
        {
            // Arrange
            int n = 1234;

            // Act
            int ketQua = Program.TimChuSoLonNhat(n);

            // Assert
            Assert.Equal(4, ketQua);
        }

        [Theory]
        [InlineData(1234, 4)]
        [InlineData(9999, 9)]   // Tat ca chu so giong nhau
        [InlineData(1000, 1)]   // Nhieu chu so 0
        [InlineData(4321, 4)]   // Chu so lon nhat o dau
        [InlineData(5678, 8)]   // Chu so lon nhat o cuoi
        [InlineData(1111, 1)]   // Tat ca chu so giong nhau (nho)
        [InlineData(9081, 9)]   // Co chu so 0 o giua
        public void TimChuSoLonNhat_NhieuTruongHop(int n, int chuSoMongMuon)
        {
            int ketQua = Program.TimChuSoLonNhat(n);
            Assert.Equal(chuSoMongMuon, ketQua);
        }
    }
}

