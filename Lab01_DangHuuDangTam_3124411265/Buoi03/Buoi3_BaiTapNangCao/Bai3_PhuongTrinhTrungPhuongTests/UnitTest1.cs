using Xunit;
using PhuongTrinhTrungPhuong;

namespace Bai3_PhuongTrinhTrungPhuongTests
{
    public class GiaiPhuongTrinhTrungPhuongTests
    {
        [Fact]
        public void Giai_BonNghiem()
        {
            // Arrange: x^4 - 5x^2 + 4 = 0 -> x = -2, -1, 1, 2
            var ketQua = Program.GiaiPhuongTrinhTrungPhuong(1, -5, 4);

            // Assert
            Assert.NotNull(ketQua);
            Assert.Equal(new double[] { -2, -1, 1, 2 }, ketQua!);
        }

        [Fact]
        public void Giai_HaiNghiem_TuTKep()
        {
            // x^4 - 4 = 0 -> t = 4 (duy nhat vi delta_t: b=0 => t=+-2 nhung chi t=2>0 hop le)
            var ketQua = Program.GiaiPhuongTrinhTrungPhuong(1, 0, -4);

            Assert.NotNull(ketQua);
            Assert.Equal(2, ketQua!.Length);
            Assert.Equal(-1.4142135623730951, ketQua[0], precision: 10);
            Assert.Equal(1.4142135623730951, ketQua[1], precision: 10);
        }

        [Fact]
        public void Giai_VoNghiem_CaHaiTAmHoacDeltaAm()
        {
            // x^4 + 2x^2 + 1 = 0 -> t=-1 (kep), am -> vo nghiem thuc
            var ketQua = Program.GiaiPhuongTrinhTrungPhuong(1, 2, 1);

            Assert.NotNull(ketQua);
            Assert.Empty(ketQua!);
        }

        [Fact]
        public void Giai_VoNghiem_DeltaAm()
        {
            // x^4 + x^2 + 1 = 0 -> delta_t < 0
            var ketQua = Program.GiaiPhuongTrinhTrungPhuong(1, 1, 1);

            Assert.NotNull(ketQua);
            Assert.Empty(ketQua!);
        }

        [Fact]
        public void Giai_ABang0_ThanhBac2Thuong()
        {
            // x^2 - 4 = 0 -> x = -2, 2
            var ketQua = Program.GiaiPhuongTrinhTrungPhuong(0, 1, -4);

            Assert.NotNull(ketQua);
            Assert.Equal(new double[] { -2, 2 }, ketQua!);
        }

        [Fact]
        public void Giai_TatCaBang0_VoSoNghiem()
        {
            var ketQua = Program.GiaiPhuongTrinhTrungPhuong(0, 0, 0);

            Assert.Null(ketQua);
        }

        [Fact]
        public void Giai_ABang0_BBang0_CKhac0_VoNghiem()
        {
            var ketQua = Program.GiaiPhuongTrinhTrungPhuong(0, 0, 5);

            Assert.NotNull(ketQua);
            Assert.Empty(ketQua!);
        }

        [Fact]
        public void Giai_BonNghiemKhongDep()
        {
            // x^4 - 4x^2 + 3 = 0 -> x = -sqrt3, -1, 1, sqrt3
            var ketQua = Program.GiaiPhuongTrinhTrungPhuong(1, -4, 3);

            Assert.NotNull(ketQua);
            Assert.Equal(4, ketQua!.Length);
            Assert.Equal(-1.7320508075688772, ketQua[0], precision: 10);
            Assert.Equal(-1.0, ketQua[1], precision: 10);
            Assert.Equal(1.0, ketQua[2], precision: 10);
            Assert.Equal(1.7320508075688772, ketQua[3], precision: 10);
        }
    }
}

