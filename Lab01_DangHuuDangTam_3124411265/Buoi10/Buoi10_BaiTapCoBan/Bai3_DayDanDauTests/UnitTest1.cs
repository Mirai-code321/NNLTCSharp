using Bai3_DayDanDau;

namespace Bai3_DayDanDauTests
{
    public class UnitTest1
    {
        // Test đúng theo ví dụ trong đề
        // -2 5 -3 4 -6 2 -1
        // Dấu: - + - + - + -
        // Đây là dãy đan dấu
        [Fact]
        public void KiemTraDayDanDau_TheoViDu_TraVeTrue()
        {
            double[] a = { -2, 5, -3, 4, -6, 2, -1 };

            bool ketQua = BT3.KiemTraDayDanDau(a);

            Assert.True(ketQua);
        }

        // Kiểm tra dãy toàn số dương
        // Không phải dãy đan dấu
        [Fact]
        public void KiemTraDayDanDau_ToanDuong_TraVeFalse()
        {
            double[] a = { 1, 2, 3, 4, 5 };

            bool ketQua = BT3.KiemTraDayDanDau(a);

            Assert.False(ketQua);
        }

        // Kiểm tra dãy toàn số âm
        // Không phải dãy đan dấu
        [Fact]
        public void KiemTraDayDanDau_ToanAm_TraVeFalse()
        {
            double[] a = { -1, -2, -3, -4 };

            bool ketQua = BT3.KiemTraDayDanDau(a);

            Assert.False(ketQua);
        }

        // Kiểm tra dãy có hai phần tử cùng dấu
        [Fact]
        public void KiemTraDayDanDau_CungDau_TraVeFalse()
        {
            double[] a = { -2, 5, 3, -4 };

            bool ketQua = BT3.KiemTraDayDanDau(a);

            Assert.False(ketQua);
        }

        // Kiểm tra dãy đan dấu bắt đầu bằng số dương
        // 2 -3 4 -5 6
        [Fact]
        public void KiemTraDayDanDau_BatDauDuong_TraVeTrue()
        {
            double[] a = { 2, -3, 4, -5, 6 };

            bool ketQua = BT3.KiemTraDayDanDau(a);

            Assert.True(ketQua);
        }

        // Kiểm tra dãy có số 0
        // 0 không có dấu nên không phải dãy đan dấu
        [Fact]
        public void KiemTraDayDanDau_CoSo0_TraVeFalse()
        {
            double[] a = { -2, 5, 0, -4 };

            bool ketQua = BT3.KiemTraDayDanDau(a);

            Assert.False(ketQua);
        }

        // Kiểm tra số thực
        [Fact]
        public void KiemTraDayDanDau_SoThuc_TraVeTrue()
        {
            double[] a = { -1.5, 2.5, -3.5, 4.5 };

            bool ketQua = BT3.KiemTraDayDanDau(a);

            Assert.True(ketQua);
        }

        // Kiểm tra trường hợp chỉ có 1 phần tử
        // Không có cặp nào vi phạm điều kiện
        [Fact]
        public void KiemTraDayDanDau_MotPhanTu_TraVeTrue()
        {
            double[] a = { 5 };

            bool ketQua = BT3.KiemTraDayDanDau(a);

            Assert.True(ketQua);
        }
    }
}