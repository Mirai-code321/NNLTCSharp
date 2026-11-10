using Xunit;
using NNLTCShrap.Buoi01;

namespace BT02Test
{
    public class Bai02Test
    {
        [Fact]
        public void Test_DienTich_R_5()
        {
            // Arrange
            double r = 5;
            HinhTron hinhTron = new HinhTron(r);

            // Act
            double ketQua = hinhTron.TinhDienTich();

            // Assert
            Assert.Equal(78.5, ketQua);
        }

        [Fact]
        public void Test_ChuVi_R_5()
        {
            // Arrange
            double r = 5;
            HinhTron hinhTron = new HinhTron(r);

            // Act
            double ketQua = hinhTron.TinhChuVi();

            // Assert
            Assert.Equal(31.4, ketQua);
        }
    }
}
