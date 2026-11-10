using Xunit;
using InHinhTamGiacVaVuong;

namespace Bai1_InHinhTamGiacVaVuongTests
{
    public class TaoHinhTests
    {
        [Fact]
        public void TaoHinhTamGiac_H_Bang3()
        {
            // Arrange
            int h = 3;
            string mongMuon = "    *\n   *  *\n * * * * *\n";

            // Act
            string ketQua = Program.TaoHinhTamGiac(h).Replace("\r\n", "\n");

            // Assert
            Assert.Equal(mongMuon, ketQua);
        }

        [Fact]
        public void TaoHinhTamGiac_H_Bang1_ChiCoDinh()
        {
            string ketQua = Program.TaoHinhTamGiac(1).Replace("\r\n", "\n");
            Assert.Equal(" *\n", ketQua);
        }
    }
}