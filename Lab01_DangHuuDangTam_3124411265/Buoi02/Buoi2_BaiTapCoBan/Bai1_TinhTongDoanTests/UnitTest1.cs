using Xunit;
using TongDoan;

namespace Bai1_TinhTongDoan.Tests
{
    public class TinhTongDoanTests
    {
        [Fact]
        public void TinhTong_TuBaDenNam_TraVe12()
        {
            // Arrange
            // Cần tính tổng đoạn [3, 5]
            int a = 3;
            int b = 5;

            // Act
            // 3 + 4 + 5 = 12
            long ketQua = Program.TinhTongDoan(a, b);

            // Assert
            Assert.Equal(12, ketQua);
        }

        [Fact]
        public void TinhTong_ABangB_TraVeChinhSoDo()
        {
            // Khi a = b thì đoạn chỉ có một số
            // Ví dụ: [7, 7] => 7
            long ketQua = Program.TinhTongDoan(7, 7);

            // Kiểm tra kết quả
            Assert.Equal(7, ketQua);
        }

        [Theory]
        [InlineData(1, 10, 55)]
        [InlineData(1, 100, 5050)]
        [InlineData(-3, 3, 0)]
        public void TinhTong_NhieuTruongHop(
            int a,
            int b,
            long ketQuaMongMuon)
        {
            // Tính tổng đoạn [a, b]
            long ketQua = Program.TinhTongDoan(a, b);

            // So sánh kết quả thực tế với kết quả mong muốn
            Assert.Equal(ketQuaMongMuon, ketQua);
        }
    }
}