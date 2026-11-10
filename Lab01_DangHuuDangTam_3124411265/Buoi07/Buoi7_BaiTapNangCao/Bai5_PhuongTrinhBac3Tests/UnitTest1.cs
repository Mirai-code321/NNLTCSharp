using Bai5_PhuongTrinhBac3;

namespace Bai5_PhuongTrinhBac3Tests
{
    public class UnitTest1
    {
        // -------------------------------------------------
        // Test phương trình có 3 nghiệm thực phân biệt
        //
        // x^3 - 6x^2 + 11x - 6 = 0
        //
        // Có 3 nghiệm:
        // x1 = 1
        // x2 = 2
        // x3 = 3
        // -------------------------------------------------
        [Fact]
        public void PhuongTrinh_Co3Nghiem()
        {
            string ketQua = BT5.GiaiPhuongTrinhBac3(
                1, -6, 11, -6);

            Assert.Contains("3 nghiem thuc phan biet", ketQua);
        }


        // -------------------------------------------------
        // Test phương trình có 1 nghiệm thực
        //
        // x^3 + x + 1 = 0
        //
        // Phương trình có 1 nghiệm thực
        // -------------------------------------------------
        [Fact]
        public void PhuongTrinh_Co1Nghiem()
        {
            string ketQua = BT5.GiaiPhuongTrinhBac3(
                1, 0, 1, 1);

            Assert.Contains("1 nghiem thuc", ketQua);
        }


        // -------------------------------------------------
        // Test phương trình có 2 nghiệm thực
        // Trong đó có 1 nghiệm kép
        //
        // x^3 - 3x + 2 = 0
        //
        // Phân tích:
        // (x - 1)^2(x + 2) = 0
        //
        // x = 1 là nghiệm kép
        // x = -2
        // -------------------------------------------------
        [Fact]
        public void PhuongTrinh_CoNghiemKep()
        {
            string ketQua = BT5.GiaiPhuongTrinhBac3(
                1, 0, -3, 2);

            Assert.Contains("2 nghiem thuc", ketQua);
        }


        // -------------------------------------------------
        // Test phương trình có nghiệm kép ba
        //
        // x^3 - 3x^2 + 3x - 1 = 0
        //
        // (x - 1)^3 = 0
        //
        // x = 1
        // -------------------------------------------------
        [Fact]
        public void PhuongTrinh_CoNghiemKepBa()
        {
            string ketQua = BT5.GiaiPhuongTrinhBac3(
                1, -3, 3, -1);

            Assert.Contains("nghiem kep ba", ketQua);
        }


        // -------------------------------------------------
        // Test hệ số a = 0
        // Khi a = 0 thì không còn là phương trình bậc 3
        // -------------------------------------------------
        [Fact]
        public void PhuongTrinh_ABang0()
        {
            string ketQua = BT5.GiaiPhuongTrinhBac3(
                0, 1, 2, 3);

            Assert.Equal("a phai khac 0", ketQua);
        }


        // -------------------------------------------------
        // Test phương trình:
        // x^3 - 1 = 0
        //
        // Có nghiệm thực x = 1
        // -------------------------------------------------
        [Fact]
        public void PhuongTrinh_XMu3Tru1()
        {
            string ketQua = BT5.GiaiPhuongTrinhBac3(
                1, 0, 0, -1);

            Assert.Contains("1 nghiem thuc", ketQua);
        }


        // -------------------------------------------------
        // Test phương trình:
        // x^3 - 4x = 0
        //
        // x(x - 2)(x + 2) = 0
        //
        // Có 3 nghiệm:
        // -2, 0, 2
        // -------------------------------------------------
        [Fact]
        public void PhuongTrinh_Co3Nghiem_DonGian()
        {
            string ketQua = BT5.GiaiPhuongTrinhBac3(
                1, 0, -4, 0);

            Assert.Contains("3 nghiem thuc phan biet", ketQua);
        }
    }
}