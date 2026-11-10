using Xunit;
using Bai3_TongPhanSoSaiSo;

namespace Bai3_TongPhanSoSaiSoTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test_TongPhanSo_a1_epsilon01()
        {
            // a = 1, epsilon = 0.1
            // Số hạng: 1/1=1 (>=0.1, cộng), 1/2=0.5 (cộng), 1/3=0.333(cộng),
            // 1/4=0.25(cộng), 1/5=0.2(cộng), 1/6=0.1667(cộng), 1/7=0.1429(cộng),
            // 1/8=0.125(cộng), 1/9=0.1111(cộng), 1/10=0.1(cộng, vì 0.1 >= 0.1),
            // 1/11=0.0909 (< 0.1 -> dừng, KHÔNG cộng)
            // Tổng = 1+0.5+0.333+0.25+0.2+0.1667+0.1429+0.125+0.1111+0.1 = 2.9290 (xấp xỉ)
            double ketQua = TongPhanSo.TinhTong(1, 0.1);
            Assert.True(ketQua > 2.9 && ketQua < 3.0); // Kiểm tra khoảng giá trị hợp lý
        }

        [Fact]
        public void Test_TongPhanSo_ChiCoMotSoHang()
        {
            // a = 20, epsilon = 0.1
            // Số hạng đầu: 1/20 = 0.05, đã nhỏ hơn epsilon = 0.1 ngay từ đầu
            // -> Vòng lặp không chạy lần nào, tổng = 0
            double ketQua = TongPhanSo.TinhTong(20, 0.1);
            Assert.Equal(0.0, ketQua, 4);
        }

        [Fact]
        public void Test_TongPhanSo_a1_epsilon05()
        {
            // a = 1, epsilon = 0.5
            // Số hạng: 1/1=1 (cộng), 1/2=0.5 (cộng, vì 0.5>=0.5), 1/3=0.333 (<0.5 -> dừng)
            // Tổng = 1 + 0.5 = 1.5
            double ketQua = TongPhanSo.TinhTong(1, 0.5);
            Assert.Equal(1.5, ketQua, 4);
        }

        [Fact]
        public void Test_TongPhanSo_DungNgaySoHangDau()
        {
            // a = 2, epsilon = 0.5
            // Số hạng đầu: 1/2 = 0.5 (cộng vì >= 0.5), 1/3=0.333 (<0.5 -> dừng)
            // Tổng = 0.5
            double ketQua = TongPhanSo.TinhTong(2, 0.5);
            Assert.Equal(0.5, ketQua, 4);
        }
    }
}

