using Bai4_GiaiHePhuongTrinh;

namespace Bai4_GiaiHePhuongTrinhTests
{
    public class UnitTest1
    {
        // Kiểm tra hệ:
        // x + y = 3
        // 2x + y = 4
        // Kết quả: x = 1, y = 2
        [Fact]
        public void HePhuongTrinh_CoNghiemDuyNhat()
        {
            string ketQua = BT4.GiaiHePhuongTrinh(
                1, 1, 3,
                2, 1, 4);

            Assert.Equal(
                "He co nghiem duy nhat: x = 1, y = 2",
                ketQua);
        }

        // Kiểm tra hệ:
        // 2x + y = 5
        // x - y = 1
        // Kết quả: x = 2, y = 1
        [Fact]
        public void HePhuongTrinh_NghiemX2Y1()
        {
            string ketQua = BT4.GiaiHePhuongTrinh(
                2, 1, 5,
                1, -1, 1);

            Assert.Equal(
                "He co nghiem duy nhat: x = 2, y = 1",
                ketQua);
        }

        // Kiểm tra hệ vô nghiệm:
        // x + y = 2
        // 2x + 2y = 5
        [Fact]
        public void HePhuongTrinh_VoNghiem()
        {
            string ketQua = BT4.GiaiHePhuongTrinh(
                1, 1, 2,
                2, 2, 5);

            Assert.Equal(
                "He vo nghiem",
                ketQua);
        }

        // Kiểm tra hệ vô số nghiệm:
        // x + y = 2
        // 2x + 2y = 4
        [Fact]
        public void HePhuongTrinh_VoSoNghiem()
        {
            string ketQua = BT4.GiaiHePhuongTrinh(
                1, 1, 2,
                2, 2, 4);

            Assert.Equal(
                "He co vo so nghiem",
                ketQua);
        }

        // Kiểm tra nghiệm âm:
        // x + y = 1
        // x - y = 3
        // Kết quả: x = 2, y = -1
        [Fact]
        public void HePhuongTrinh_CoNghiemAm()
        {
            string ketQua = BT4.GiaiHePhuongTrinh(
                1, 1, 1,
                1, -1, 3);

            Assert.Equal(
                "He co nghiem duy nhat: x = 2, y = -1",
                ketQua);
        }
    }
}