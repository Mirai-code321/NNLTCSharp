using Xunit;
using NNLTCSharp.Buoi04;

namespace NNLTCSharp.Tests
{
    public class UnitTestHePhuongTrinh
    {
        [Fact]
        public void Test_CoNghiemDuyNhat()
        {
            // x + y = 5
            // x - y = 1
            string ketQua = HePhuongTrinh.GiaiHe(1, 1, 5, 1, -1, 1);

            Assert.Equal("x = 3.00, y = 2.00", ketQua);
        }

        [Fact]
        public void Test_VoNghiem()
        {
            // x + y = 5
            // 2x + 2y = 12
            string ketQua = HePhuongTrinh.GiaiHe(1, 1, 5, 2, 2, 12);

            Assert.Equal("He phuong trinh vo nghiem.", ketQua);
        }

        [Fact]
        public void Test_VoSoNghiem()
        {
            // x + y = 5
            // 2x + 2y = 10
            string ketQua = HePhuongTrinh.GiaiHe(1, 1, 5, 2, 2, 10);

            Assert.Equal("He phuong trinh co vo so nghiem.", ketQua);
        }
    }
}

