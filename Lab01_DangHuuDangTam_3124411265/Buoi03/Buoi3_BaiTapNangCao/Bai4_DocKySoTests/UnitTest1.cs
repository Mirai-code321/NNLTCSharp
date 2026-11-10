using Xunit;
using DocKySo;

namespace Bai4_DocKySoTests
{
    public class DocKySoTests
    {
        [Fact]
        public void DocKySo_ViDuMau_1234()
        {
            // Arrange
            int n = 1234;

            // Act
            string ketQua = Program.DocKySo(n);

            // Assert
            Assert.Equal("mot hai ba bon", ketQua);
        }

        [Theory]
        [InlineData(1000, "mot khong khong khong")]  // Co nhieu so 0
        [InlineData(9999, "chin chin chin chin")]    // Cac chu so giong nhau
        [InlineData(5678, "nam sau bay tam")]
        [InlineData(1010, "mot khong mot khong")]    // So 0 xen ke
        [InlineData(2005, "hai khong khong nam")]
        [InlineData(4321, "bon ba hai mot")]          // Thu tu giam dan
        public void DocKySo_NhieuTruongHop(int n, string ketQuaMongMuon)
        {
            string ketQua = Program.DocKySo(n);
            Assert.Equal(ketQuaMongMuon, ketQua);
        }
    }
}

