using Xunit;
using SoNgayThangReNhanh;

namespace Bai5_SoNgayThangReNhanhTests
{
    public class SoNgayCuaThangTests
    {
        [Fact]
        public void SoNgayCuaThang_ViDuMau_Thang1Nam2015()
        {
            // Arrange
            int thang = 1, nam = 2015;

            // Act
            int ketQua = Program.SoNgayCuaThang(thang, nam);

            // Assert
            Assert.Equal(31, ketQua);
        }

        [Theory]
        [InlineData(2, 2015, 28)]  // Nam thuong
        [InlineData(2, 2016, 29)]  // Nam nhuan thong thuong (chia het 4)
        [InlineData(2, 2000, 29)]  // Nam nhuan dac biet (chia het 400)
        [InlineData(2, 1900, 28)]  // Nam KHONG nhuan (chia het 100 nhung khong chia het 400) - bay quan trong
        [InlineData(2, 2004, 29)]
        [InlineData(4, 2020, 30)]  // Thang co 30 ngay
        [InlineData(12, 2023, 31)] // Thang co 31 ngay
        public void SoNgayCuaThang_NhieuTruongHop(int thang, int nam, int soNgayMongMuon)
        {
            int ketQua = Program.SoNgayCuaThang(thang, nam);
            Assert.Equal(soNgayMongMuon, ketQua);
        }

        [Theory]
        [InlineData(0, 2020)]
        [InlineData(13, 2020)]
        [InlineData(-1, 2020)]
        public void SoNgayCuaThang_ThangKhongHopLe_TraVe0(int thang, int nam)
        {
            int ketQua = Program.SoNgayCuaThang(thang, nam);
            Assert.Equal(0, ketQua);
        }

        [Theory]
        [InlineData(2000, true)]
        [InlineData(1900, false)]
        [InlineData(2016, true)]
        [InlineData(2015, false)]
        public void LaNamNhuan_NhieuTruongHop(int nam, bool ketQuaMongMuon)
        {
            bool ketQua = Program.LaNamNhuan(nam);
            Assert.Equal(ketQuaMongMuon, ketQua);
        }
    }
}

