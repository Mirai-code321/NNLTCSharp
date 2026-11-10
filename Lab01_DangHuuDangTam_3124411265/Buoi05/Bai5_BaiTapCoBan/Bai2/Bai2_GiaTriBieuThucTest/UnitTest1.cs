using Xunit;
using Bai2_GiaTriBieuThuc;

namespace Bai2_GiaTriBieuThucTest
{
    public class UnitTest1
    {
        // Vì S1, S2 là số thực (double), phép tính có thể bị sai số cực nhỏ ở phần thập phân
        // Nên không dùng Assert.Equal thông thường, mà dùng bản có tham số "độ chính xác" (precision)
        // Assert.Equal(mongDoi, thucTe, so_chu_so_thap_phan_can_khop)

        [Fact]
        public void Test_S1_n1()
        {
            // n = 1: S1 = 1/1 = 1
            Assert.Equal(1.0, BieuThuc.Tinh_S1(1), 4);
        }

        [Fact]
        public void Test_S1_n2()
        {
            // n = 2: S1 = 1/1 + 1/2 = 1.5
            Assert.Equal(1.5, BieuThuc.Tinh_S1(2), 4);
        }

        [Fact]
        public void Test_S1_n5()
        {
            // n = 5: S1 = 1 + 0.5 + 0.3333 + 0.25 + 0.2 = 2.2833
            Assert.Equal(2.2833, BieuThuc.Tinh_S1(5), 4);
        }

        [Fact]
        public void Test_S2_n1()
        {
            // n = 1: S2 chỉ có 1 số hạng = 1/1 = 1
            Assert.Equal(1.0, BieuThuc.Tinh_S2(1), 4);
        }

        [Fact]
        public void Test_S2_n3()
        {
            // n = 3: S2 = 1/3 - 1/2 + 1/1 = 0.3333 - 0.5 + 1 = 0.8333
            Assert.Equal(0.8333, BieuThuc.Tinh_S2(3), 4);
        }

        [Fact]
        public void Test_S2_n4()
        {
            // n = 4: S2 = 1/4 - 1/3 + 1/2 - 1/1 = 0.25 - 0.3333 + 0.5 - 1 = -0.5833
            Assert.Equal(-0.5833, BieuThuc.Tinh_S2(4), 4);
        }
    }
}

