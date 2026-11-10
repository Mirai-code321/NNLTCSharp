using Xunit;
using XuLyChuSo1;

namespace Bai2_XuLyChuSo1.Tests
{
    public class XuLyChuSo1Tests
    {
        [Fact]
        public void LayChuSoThuK_ViTriHai_TraVe8()
        {
            // 182345:
            // Vị trí 1 = 1
            // Vị trí 2 = 8
            int ketQua = new XuLyChuSo().LayChuSoThuK(182345, 2);

            Assert.Equal(8, ketQua);
        }

        [Fact]
        public void TongChuSoLe_TraVe9()
        {
            // Các chữ số lẻ của 182345 là 1, 3, 5
            // Tổng = 1 + 3 + 5 = 9
            int ketQua = new XuLyChuSo().TongChuSoLe(182345);

            Assert.Equal(9, ketQua);
        }

        [Fact]
        public void TimChuSoLeNhoNhatLonNhat_TraVe1Va5()
        {
            // Các chữ số lẻ của 182345 là 1, 3, 5
            // Nhỏ nhất = 1
            // Lớn nhất = 5
            int nhoNhat;
            int lonNhat;

            new XuLyChuSo().TimChuSoLeNhoNhatLonNhat(
                182345,
                out nhoNhat,
                out lonNhat
            );

            Assert.Equal(1, nhoNhat);
            Assert.Equal(5, lonNhat);
        }

        [Theory]
        [InlineData(12345, 1, 1)]
        [InlineData(12345, 3, 3)]
        [InlineData(12345, 5, 5)]
        [InlineData(987654, 2, 8)]
        public void LayChuSoThuK_NhieuTruongHop(
            int n,
            int k,
            int ketQuaMongMuon)
        {
            // Kiểm tra nhiều vị trí khác nhau
            int ketQua = new XuLyChuSo().LayChuSoThuK(n, k);

            Assert.Equal(ketQuaMongMuon, ketQua);
        }

        [Theory]
        [InlineData(12345, 9)]
        [InlineData(2468, 0)]
        [InlineData(11111, 5)]
        public void TongChuSoLe_NhieuTruongHop(
            int n,
            int ketQuaMongMuon)
        {
            // Tính tổng các chữ số lẻ
            int ketQua = new XuLyChuSo().TongChuSoLe(n);

            Assert.Equal(ketQuaMongMuon, ketQua);
        }
    }
}