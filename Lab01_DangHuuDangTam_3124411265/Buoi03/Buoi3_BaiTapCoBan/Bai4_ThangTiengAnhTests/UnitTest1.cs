using Xunit;
using ThangTiengAnh;

namespace Bai4_ThangTiengAnhTests
{
    public class DocThangTests
    {
        [Fact]
        public void DocThang_ViDuMau_Thang5()
        {
            // Arrange
            int thang = 5;

            // Act
            string? ketQua = Program.DocThang(thang);

            // Assert
            Assert.Equal("May", ketQua);
        }

        [Theory]
        [InlineData(1, "January")]
        [InlineData(2, "February")]
        [InlineData(3, "March")]
        [InlineData(4, "April")]
        [InlineData(5, "May")]
        [InlineData(6, "June")]
        [InlineData(7, "July")]
        [InlineData(8, "August")]
        [InlineData(9, "September")]
        [InlineData(10, "October")]
        [InlineData(11, "November")]
        [InlineData(12, "December")]
        public void DocThang_TatCa12Thang(int thang, string tenMongMuon)
        {
            string? ketQua = Program.DocThang(thang);
            Assert.Equal(tenMongMuon, ketQua);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(13)]
        [InlineData(-1)]
        [InlineData(100)]
        public void DocThang_ThangKhongHopLe_TraVeNull(int thang)
        {
            string? ketQua = Program.DocThang(thang);
            Assert.Null(ketQua);
        }
    }
}

