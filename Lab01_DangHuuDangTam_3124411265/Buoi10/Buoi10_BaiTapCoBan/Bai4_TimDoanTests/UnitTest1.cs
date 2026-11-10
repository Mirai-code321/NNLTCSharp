using Bai4_TimDoan;

namespace Bai4_TimDoanTests
{
    public class UnitTest1
    {
        // --------------------------------------------------
        // TEST 1: Đúng theo ví dụ trong đề
        //
        // Dãy:
        // -2 5 -3 4 -6 2 -1
        //
        // k = 0
        //
        // -2 + 5 -3 + 4 -6 + 2 = 0
        //
        // Đoạn dài nhất là [0, 5]
        // --------------------------------------------------
        [Fact]
        public void TimDoan_TheoViDu_TraVe_0_5()
        {
            double[] a = { -2, 5, -3, 4, -6, 2, -1 };

            int[] ketQua = BT4.TimDoanDaiNhat(a, 0);

            Assert.Equal(0, ketQua[0]);
            Assert.Equal(5, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 2: Đoạn chỉ có một phần tử
        //
        // Dãy: 1 5 3
        // k = 5
        //
        // Đoạn [1, 1] có tổng bằng 5
        // --------------------------------------------------
        [Fact]
        public void TimDoan_MotPhanTu_TraVe_1_1()
        {
            double[] a = { 1, 5, 3 };

            int[] ketQua = BT4.TimDoanDaiNhat(a, 5);

            Assert.Equal(1, ketQua[0]);
            Assert.Equal(1, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 3: Đoạn nằm ở cuối dãy
        //
        // Dãy: 1 2 -1 4
        // k = 5
        //
        // 2 + (-1) + 4 = 5
        //
        // Đoạn [1, 3]
        // --------------------------------------------------
        [Fact]
        public void TimDoan_DoanNamCuoi_TraVe_1_3()
        {
            double[] a = { 1, 2, -1, 4 };

            int[] ketQua = BT4.TimDoanDaiNhat(a, 5);

            Assert.Equal(1, ketQua[0]);
            Assert.Equal(3, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 4: Không có đoạn nào có tổng bằng k
        //
        // Dãy: 1 2 3
        // k = 10
        //
        // Không có đoạn nào có tổng bằng 10
        // --------------------------------------------------
        [Fact]
        public void TimDoan_KhongCoDoan_TraVe_Am1()
        {
            double[] a = { 1, 2, 3 };

            int[] ketQua = BT4.TimDoanDaiNhat(a, 10);

            Assert.Equal(-1, ketQua[0]);
            Assert.Equal(-1, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 5: Toàn bộ dãy có tổng bằng k
        //
        // Dãy: 1 2 3
        // k = 6
        //
        // 1 + 2 + 3 = 6
        //
        // Đoạn dài nhất là [0, 2]
        // --------------------------------------------------
        [Fact]
        public void TimDoan_CaDay_TraVe_0_2()
        {
            double[] a = { 1, 2, 3 };

            int[] ketQua = BT4.TimDoanDaiNhat(a, 6);

            Assert.Equal(0, ketQua[0]);
            Assert.Equal(2, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 6: Dãy số thực
        //
        // 1.5 + 2.5 = 4
        //
        // Đoạn [0, 1]
        // --------------------------------------------------
        [Fact]
        public void TimDoan_SoThuc_TraVe_0_1()
        {
            double[] a = { 1.5, 2.5, 10 };

            int[] ketQua = BT4.TimDoanDaiNhat(a, 4);

            Assert.Equal(0, ketQua[0]);
            Assert.Equal(1, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 7: Có nhiều đoạn cùng tổng nhưng chọn đoạn dài nhất
        //
        // Dãy: 2 -2 3 -3 5
        // k = 0
        //
        // [0, 1] có tổng 0
        // [0, 3] có tổng 0
        //
        // Chọn [0, 3] vì dài hơn
        // --------------------------------------------------
        [Fact]
        public void TimDoan_UuTienDoanDai_TraVe_0_3()
        {
            double[] a = { 2, -2, 3, -3, 5 };

            int[] ketQua = BT4.TimDoanDaiNhat(a, 0);

            Assert.Equal(0, ketQua[0]);
            Assert.Equal(3, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 8: Có số âm
        //
        // Dãy: -5 2 3 -1
        // k = 0
        //
        // -5 + 2 + 3 = 0
        //
        // Đoạn dài nhất là [0, 2]
        //
        // LƯU Ý:
        // -5 + 2 + 3 - 1 = -1
        // nên không thể là [0, 3]
        // --------------------------------------------------
        [Fact]
        public void TimDoan_CoSoAm_TraVe_0_2()
        {
            double[] a = { -5, 2, 3, -1 };

            int[] ketQua = BT4.TimDoanDaiNhat(a, 0);

            Assert.Equal(0, ketQua[0]);
            Assert.Equal(2, ketQua[1]);
        }
    }
}