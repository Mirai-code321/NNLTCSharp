using Xunit;
using PhanTichThuaSo1;

namespace Bai3_PhanTichThuaSo1.Tests
{
    public class PhanTichThuaSoTests
    {
        [Fact]
        public void PhanTich_100_TraVe2Mu2Nhan5Mu2()
        {
            // 100 = 2 x 2 x 5 x 5
            // => 100 = 2^2 x 5^2
            string ketQua = new PhanTichThuaSo().PhanTich(100);

            Assert.Equal("2^2 x 5^2", ketQua);
        }

        [Fact]
        public void PhanTich_60_TraVe2Mu2Nhan3Nhan5()
        {
            // 60 = 2 x 2 x 3 x 5
            // => 60 = 2^2 x 3 x 5
            string ketQua = new PhanTichThuaSo().PhanTich(60);

            Assert.Equal("2^2 x 3 x 5", ketQua);
        }

        [Fact]
        public void PhanTich_12_TraVe2Mu2Nhan3()
        {
            // 12 = 2 x 2 x 3
            // => 12 = 2^2 x 3
            string ketQua = new PhanTichThuaSo().PhanTich(12);

            Assert.Equal("2^2 x 3", ketQua);
        }

        [Fact]
        public void PhanTich_SoNguyenTo_TraVeChinhSoDo()
        {
            // 7 là số nguyên tố
            // => kết quả chỉ có 7
            string ketQua = new PhanTichThuaSo().PhanTich(7);

            Assert.Equal("7", ketQua);
        }

        [Fact]
        public void PhanTich_2_TraVe2()
        {
            // 2 là số nguyên tố nhỏ nhất
            string ketQua = new PhanTichThuaSo().PhanTich(2);

            Assert.Equal("2", ketQua);
        }

        [Theory]
        [InlineData(8, "2^3")]
        [InlineData(18, "2 x 3^2")]
        [InlineData(24, "2^3 x 3")]
        [InlineData(36, "2^2 x 3^2")]
        [InlineData(72, "2^3 x 3^2")]
        public void PhanTich_NhieuTruongHop(
            int n,
            string ketQuaMongMuon)
        {
            // Phân tích n thành thừa số nguyên tố
            string ketQua = new PhanTichThuaSo().PhanTich(n);

            // Kiểm tra kết quả
            Assert.Equal(ketQuaMongMuon, ketQua);
        }
    }
}