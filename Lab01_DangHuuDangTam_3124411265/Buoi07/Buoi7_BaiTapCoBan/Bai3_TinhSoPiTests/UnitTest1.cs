using Xunit;
using TinhSoPi;

namespace Bai3_TinhSoPiTests
{
    public class TinhPiTests
    {
        [Fact]
        public void TinhPi_ViDuMau_Epsilon_0_001()
        {
            // Arrange
            double epsilon = 0.001;

            // Act
            var (piTinhDuoc, saiSoThucTe) = Program.TinhPi(epsilon);

            // Assert
            Assert.Equal(3.1410926536210413, piTinhDuoc, precision: 10);
            Assert.Equal(0.0004999999687518297, saiSoThucTe, precision: 10);
        }

        [Theory]
        [InlineData(0.01, 3.136592684838816)]
        [InlineData(0.1, 3.09162380666784)]
        [InlineData(0.0001, 3.1415426535898248)]
        public void TinhPi_NhieuMucEpsilon(double epsilon, double piMongMuon)
        {
            var (piTinhDuoc, _) = Program.TinhPi(epsilon);
            Assert.Equal(piMongMuon, piTinhDuoc, precision: 10);
        }

        [Theory]
        [InlineData(0.001)]
        [InlineData(0.01)]
        [InlineData(0.1)]
        [InlineData(0.0001)]
        public void TinhPi_KetQuaLuonGanDungVoiSoPiThat(double epsilon)
        {
            var (_, saiSoThucTe) = Program.TinhPi(epsilon);

            // Sai so thuc te phai nho hon epsilon mot khoang hop ly (thuong nho hon epsilon/2)
            Assert.True(saiSoThucTe < epsilon);
        }

        [Fact]
        public void TinhPi_EpsilonCangNho_KetQuaCangChinhXac()
        {
            var (_, saiSoLon) = Program.TinhPi(0.1);
            var (_, saiSoNho) = Program.TinhPi(0.0001);

            // Epsilon nho hon thi sai so thuc te cung phai nho hon
            Assert.True(saiSoNho < saiSoLon);
        }
    }
}