using Xunit;
using GiaTriHamSo2;

namespace Bai2_GiaTriHamSo2Tests
{
    public class TinhFTests
    {
        [Fact]
        public void TinhF_A_Bang1()
        {
            // Arrange
            double a = 1;

            // Act
            double ketQua = Program.TinhF(a);

            // Assert
            Assert.Equal(0.25, ketQua, precision: 10);
        }

        [Theory]
        [InlineData(-10, -0.5)]                        // Xa ben trai
        [InlineData(0, -0.5)]
        [InlineData(0.5, -0.5)]                         // Bien trai (dung nhanh <=)
        [InlineData(1, 0.25)]                           // Giua doan doc
        [InlineData(1.5, 1)]                            // Bien phai
        [InlineData(2, 1)]
        [InlineData(10, 1)]                             // Xa ben phai
        [InlineData(0.8, -0.04999999999999993)]
        [InlineData(1.2, 0.5499999999999998)]
        public void TinhF_NhieuTruongHop(double a, double ketQuaMongMuon)
        {
            double ketQua = Program.TinhF(a);
            Assert.Equal(ketQuaMongMuon, ketQua, precision: 10);
        }
    }
}

