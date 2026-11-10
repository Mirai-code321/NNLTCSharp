using Xunit;
using NgayTruoc;

namespace Bai4_NgayTruocTests
{
    public class NgayTruocDoTests
    {
        [Fact]
        public void NgayTruocDo_ViDuMau_1_2_2015()
        {
            // Arrange
            int ngay = 1, thang = 2, nam = 2015;

            // Act
            var (ngayTruoc, thangTruoc, namTruoc) = Program.NgayTruocDo(ngay, thang, nam);

            // Assert
            Assert.Equal(31, ngayTruoc);
            Assert.Equal(1, thangTruoc);
            Assert.Equal(2015, namTruoc);
        }

        [Fact]
        public void NgayTruocDo_NgayBinhThuong_ChiLuiMotNgay()
        {
            // 15/6/2020 -> 14/6/2020
            var (ngayTruoc, thangTruoc, namTruoc) = Program.NgayTruocDo(15, 6, 2020);

            Assert.Equal(14, ngayTruoc);
            Assert.Equal(6, thangTruoc);
            Assert.Equal(2020, namTruoc);
        }

        [Fact]
        public void NgayTruocDo_Mung1Thang1_LuiVeNamTruoc()
        {
            // 1/1/2015 -> 31/12/2014 (truong hop dac biet: dau nam)
            var (ngayTruoc, thangTruoc, namTruoc) = Program.NgayTruocDo(1, 1, 2015);

            Assert.Equal(31, ngayTruoc);
            Assert.Equal(12, thangTruoc);
            Assert.Equal(2014, namTruoc);
        }

        [Fact]
        public void NgayTruocDo_Mung1Thang3_NamNhuan_LuiVe29Thang2()
        {
            // 1/3/2016 -> 29/2/2016 (2016 la nam nhuan, thang 2 co 29 ngay)
            var (ngayTruoc, thangTruoc, namTruoc) = Program.NgayTruocDo(1, 3, 2016);

            Assert.Equal(29, ngayTruoc);
            Assert.Equal(2, thangTruoc);
            Assert.Equal(2016, namTruoc);
        }

        [Fact]
        public void NgayTruocDo_Mung1Thang3_NamThuong_LuiVe28Thang2()
        {
            // 1/3/2015 -> 28/2/2015 (2015 la nam thuong, thang 2 chi co 28 ngay)
            var (ngayTruoc, thangTruoc, namTruoc) = Program.NgayTruocDo(1, 3, 2015);

            Assert.Equal(28, ngayTruoc);
            Assert.Equal(2, thangTruoc);
            Assert.Equal(2015, namTruoc);
        }

        [Fact]
        public void NgayTruocDo_Ngay29Thang2_LuiVe28Thang2()
        {
            // 29/2/2016 -> 28/2/2016 (chi la lui 1 ngay binh thuong trong cung thang)
            var (ngayTruoc, thangTruoc, namTruoc) = Program.NgayTruocDo(29, 2, 2016);

            Assert.Equal(28, ngayTruoc);
            Assert.Equal(2, thangTruoc);
            Assert.Equal(2016, namTruoc);
        }
    }
}