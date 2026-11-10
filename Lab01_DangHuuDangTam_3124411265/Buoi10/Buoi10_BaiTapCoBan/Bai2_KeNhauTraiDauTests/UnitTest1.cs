using Bai2_KeNhauTraiDau;

namespace Bai2_KeNhauTraiDauTests
{
    public class UnitTest1
    {
        // Test đúng theo ví dụ trong đề
        // -2 5 -3 -4 -6 2 1
        // Các cặp được tính:
        // 5 và -3
        // -6 và 2
        // Kết quả = 2
        [Fact]
        public void DemKeNhauTraiDau_TheoViDu_TraVe2()
        {
            double[] a = { -2, 5, -3, -4, -6, 2, 1 };

            int ketQua = BT2.DemKeNhauTraiDau(a);

            Assert.Equal(2, ketQua);
        }

        // Kiểm tra dãy toàn số dương
        // Không có cặp trái dấu
        [Fact]
        public void DemKeNhauTraiDau_ToanDuong_TraVe0()
        {
            double[] a = { 1, 2, 3, 4, 5 };

            int ketQua = BT2.DemKeNhauTraiDau(a);

            Assert.Equal(0, ketQua);
        }

        // Kiểm tra dãy toàn số âm
        // Không có cặp trái dấu
        [Fact]
        public void DemKeNhauTraiDau_ToanAm_TraVe0()
        {
            double[] a = { -1, -2, -3, -4, -5 };

            int ketQua = BT2.DemKeNhauTraiDau(a);

            Assert.Equal(0, ketQua);
        }

        // Kiểm tra nhiều cặp trái dấu
        [Fact]
        public void DemKeNhauTraiDau_NhieuCap_TraVe3()
        {
            double[] a = { 1, -2, 3, -4, 5 };

            int ketQua = BT2.DemKeNhauTraiDau(a);

            Assert.Equal(3, ketQua);
        }

        // Kiểm tra số 0
        // 0 không được xem là trái dấu với số khác
        [Fact]
        public void DemKeNhauTraiDau_CoSo0_TraVe0()
        {
            double[] a = { 1, 0, -2, -3 };

            int ketQua = BT2.DemKeNhauTraiDau(a);

            Assert.Equal(0, ketQua);
        }

        // Kiểm tra số thực
        [Fact]
        public void DemKeNhauTraiDau_SoThuc()
        {
            double[] a = { 1.5, -2.5, -3.5, 4.5 };

            int ketQua = BT2.DemKeNhauTraiDau(a);

            Assert.Equal(1, ketQua);
        }
    }
}