using Bai1_DoanChuaGiaTri;

namespace Bai1_DoanChuaGiaTriTests
{
    public class UnitTest1
    {
        // --------------------------------------------------
        // TEST 1:
        // Kiểm tra một dãy số bình thường
        //
        // 2 -5 3 8 1
        //
        // Min = -5
        // Max = 8
        //
        // Đoạn cần tìm: [-5, 8]
        // --------------------------------------------------
        [Fact]
        public void TimDoan_DayBinhThuong_TraVeAm5_8()
        {
            double[] mang = { 2, -5, 3, 8, 1 };

            double[] ketQua = BT1.TimDoanChuaGiaTri(mang);

            Assert.Equal(-5, ketQua[0]);
            Assert.Equal(8, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 2:
        // Kiểm tra theo thứ tự giảm dần
        //
        // 10 8 5 2 -3
        //
        // Min = -3
        // Max = 10
        // --------------------------------------------------
        [Fact]
        public void TimDoan_DayGiam_TraVeAm3_10()
        {
            double[] mang = { 10, 8, 5, 2, -3 };

            double[] ketQua = BT1.TimDoanChuaGiaTri(mang);

            Assert.Equal(-3, ketQua[0]);
            Assert.Equal(10, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 3:
        // Toàn bộ phần tử đều dương
        //
        // 2 5 7 10
        //
        // Đoạn: [2, 10]
        // --------------------------------------------------
        [Fact]
        public void TimDoan_ToanSoDuong_TraVe2_10()
        {
            double[] mang = { 2, 5, 7, 10 };

            double[] ketQua = BT1.TimDoanChuaGiaTri(mang);

            Assert.Equal(2, ketQua[0]);
            Assert.Equal(10, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 4:
        // Toàn bộ phần tử đều âm
        //
        // -2 -5 -8 -1
        //
        // Min = -8
        // Max = -1
        // --------------------------------------------------
        [Fact]
        public void TimDoan_ToanSoAm_TraVeAm8_Am1()
        {
            double[] mang = { -2, -5, -8, -1 };

            double[] ketQua = BT1.TimDoanChuaGiaTri(mang);

            Assert.Equal(-8, ketQua[0]);
            Assert.Equal(-1, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 5:
        // Các phần tử giống nhau
        //
        // 5 5 5 5
        //
        // Min = Max = 5
        //
        // Đoạn: [5, 5]
        // --------------------------------------------------
        [Fact]
        public void TimDoan_CacPhanTuBangNhau_TraVe5_5()
        {
            double[] mang = { 5, 5, 5, 5 };

            double[] ketQua = BT1.TimDoanChuaGiaTri(mang);

            Assert.Equal(5, ketQua[0]);
            Assert.Equal(5, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 6:
        // Kiểm tra số thực
        //
        // 1.5 -2.5 3.7 0.5
        //
        // Min = -2.5
        // Max = 3.7
        // --------------------------------------------------
        [Fact]
        public void TimDoan_SoThuc_TraVeAm2_5_3_7()
        {
            double[] mang = { 1.5, -2.5, 3.7, 0.5 };

            double[] ketQua = BT1.TimDoanChuaGiaTri(mang);

            Assert.Equal(-2.5, ketQua[0]);
            Assert.Equal(3.7, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 7:
        // Số 0 nằm trong mảng
        //
        // -5 0 3 8
        //
        // Min = -5
        // Max = 8
        // --------------------------------------------------
        [Fact]
        public void TimDoan_CoSo0_TraVeAm5_8()
        {
            double[] mang = { -5, 0, 3, 8 };

            double[] ketQua = BT1.TimDoanChuaGiaTri(mang);

            Assert.Equal(-5, ketQua[0]);
            Assert.Equal(8, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 8:
        // Chỉ có một phần tử
        //
        // 7
        //
        // Min = Max = 7
        // --------------------------------------------------
        [Fact]
        public void TimDoan_MotPhanTu_TraVe7_7()
        {
            double[] mang = { 7 };

            double[] ketQua = BT1.TimDoanChuaGiaTri(mang);

            Assert.Equal(7, ketQua[0]);
            Assert.Equal(7, ketQua[1]);
        }
    }
}