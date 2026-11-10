using Bai3_InLich;

namespace Bai3_InLichTest
{
    public class UnitTest1
    {
        // Kiểm tra năm nhuận
        [Fact]
        public void KiemTraNamNhuan()
        {
            InLich lich = new InLich();

            Assert.True(lich.LaNamNhuan(2000));
            Assert.True(lich.LaNamNhuan(2004));

            Assert.False(lich.LaNamNhuan(1900));
            Assert.False(lich.LaNamNhuan(2006));
        }

        // Kiểm tra số ngày trong tháng
        [Fact]
        public void KiemTraSoNgayTrongThang()
        {
            InLich lich = new InLich();

            Assert.Equal(31, lich.SoNgayTrongThang(2006, 1));
            Assert.Equal(28, lich.SoNgayTrongThang(2006, 2));
            Assert.Equal(31, lich.SoNgayTrongThang(2006, 3));
            Assert.Equal(30, lich.SoNgayTrongThang(2006, 4));
        }

        // Kiểm tra tháng 2 của năm nhuận
        [Fact]
        public void KiemTraThangHaiNamNhuan()
        {
            InLich lich = new InLich();

            Assert.Equal(29, lich.SoNgayTrongThang(2000, 2));
        }

        // Kiểm tra thứ của ngày 01/05/2006
        // Ngày này là thứ hai nên kết quả là 1
        [Fact]
        public void KiemTraThuTrongTuan()
        {
            InLich lich = new InLich();

            Assert.Equal(1, lich.ThuTrongTuan(1, 5, 2006));
        }

        // Kiểm tra ngày Chủ nhật
        // 07/05/2006 là Chủ nhật nên kết quả là 0
        [Fact]
        public void KiemTraChuNhat()
        {
            InLich lich = new InLich();

            Assert.Equal(0, lich.ThuTrongTuan(7, 5, 2006));
        }
    }
}