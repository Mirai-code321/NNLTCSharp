using Xunit;
using PhuongTrinhBac2;

namespace Bai3_PhuongTrinhBac2Tests
{
    public class GiaiPhuongTrinhBac2Tests
    {
        [Fact]
        public void GiaiPhuongTrinh_ViDuMau_HaiNghiem()
        {
            // Arrange
            double a = 1, b = 5, c = 6;

            // Act
            var (soNghiem, x1, x2) = Program.GiaiPhuongTrinhBac2(a, b, c);

            // Assert
            Assert.Equal(2, soNghiem);
            Assert.Equal(-2.0, x1, precision: 10);
            Assert.Equal(-3.0, x2, precision: 10);
        }

        [Fact]
        public void GiaiPhuongTrinh_NghiemKep()
        {
            var (soNghiem, x1, x2) = Program.GiaiPhuongTrinhBac2(1, -2, 1);

            Assert.Equal(1, soNghiem);
            Assert.Equal(1.0, x1, precision: 10);
        }

        [Fact]
        public void GiaiPhuongTrinh_VoNghiem()
        {
            var (soNghiem, _, _) = Program.GiaiPhuongTrinhBac2(1, 0, 1);

            Assert.Equal(0, soNghiem);
        }

        [Fact]
        public void GiaiPhuongTrinh_ABang0_ThanhBac1()
        {
            // 2x + 4 = 0 -> x = -2
            var (soNghiem, x1, _) = Program.GiaiPhuongTrinhBac2(0, 2, 4);

            Assert.Equal(1, soNghiem);
            Assert.Equal(-2.0, x1, precision: 10);
        }

        [Fact]
        public void GiaiPhuongTrinh_ABang0_BBang0_CKhac0_VoNghiem()
        {
            // 5 = 0 -> vo nghiem
            var (soNghiem, _, _) = Program.GiaiPhuongTrinhBac2(0, 0, 5);

            Assert.Equal(0, soNghiem);
        }

        [Fact]
        public void GiaiPhuongTrinh_TatCaBang0_VoSoNghiem()
        {
            // 0 = 0 -> vo so nghiem
            var (soNghiem, _, _) = Program.GiaiPhuongTrinhBac2(0, 0, 0);

            Assert.Equal(-1, soNghiem);
        }

        [Fact]
        public void GiaiPhuongTrinh_HeSoAmVaLe()
        {
            // 2x^2 - 3x - 2 = 0 -> x1 = 2, x2 = -0.5
            var (soNghiem, x1, x2) = Program.GiaiPhuongTrinhBac2(2, -3, -2);

            Assert.Equal(2, soNghiem);
            Assert.Equal(2.0, x1, precision: 10);
            Assert.Equal(-0.5, x2, precision: 10);
        }
    }
}

