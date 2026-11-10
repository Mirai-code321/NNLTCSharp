using Xunit;
using ThuTuNgayNam;

namespace Bai5_ThuTuNgayNamTests
{
    public class SoNgayCachDauNamTests
    {
        [Fact]
        public void SoNgayCachDauNam_ViDuMau_2_2_2015()
        {
            // Arrange
            int ngay = 2, thang = 2, nam = 2015;

            // Act
            int ketQua = Program.SoNgayCachDauNam(ngay, thang, nam);

            // Assert
            Assert.Equal(32, ketQua);
        }

        [Theory]
        [InlineData(1, 1, 2015, 0)]     // Chinh ngay dau nam
        [InlineData(31, 12, 2015, 364)] // Ngay cuoi nam thuong
        [InlineData(1, 3, 2016, 60)]    // Sau thang 2 nam nhuan
        [InlineData(1, 3, 2015, 59)]    // Sau thang 2 nam thuong
        [InlineData(29, 2, 2016, 59)]   // Ngay 29/2 chi ton tai trong nam nhuan
        [InlineData(1, 1, 2000, 0)]
        [InlineData(31, 12, 2000, 365)] // Ngay cuoi nam nhuan (366 ngay, index tu 0)
        public void SoNgayCachDauNam_NhieuTruongHop(int ngay, int thang, int nam, int ketQuaMongMuon)
        {
            int ketQua = Program.SoNgayCachDauNam(ngay, thang, nam);
            Assert.Equal(ketQuaMongMuon, ketQua);
        }
    }
}

