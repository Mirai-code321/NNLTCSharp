using Bai5_DoanDuongDaiNhat;

namespace Bai5_DoanDuongDaiNhatTests
{
    public class UnitTest1
    {
        // --------------------------------------------------
        // TEST 1: Đúng theo ví dụ trong đề
        //
        // Dãy:
        // -2 5 3 4 -6 2 -1
        //
        // Đoạn dương dài nhất:
        // [1, 3]
        //
        // Các phần tử:
        // 5 3 4
        // --------------------------------------------------
        [Fact]
        public void TimDoanDuong_TheoViDu_TraVe_1_3()
        {
            double[] a = { -2, 5, 3, 4, -6, 2, -1 };

            int[] ketQua = BT5.TimDoanDuongDaiNhat(a);

            Assert.Equal(1, ketQua[0]);
            Assert.Equal(3, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 2: Toàn bộ dãy là số dương
        //
        // 1 2 3 4 5
        //
        // Đoạn dài nhất là [0, 4]
        // --------------------------------------------------
        [Fact]
        public void TimDoanDuong_ToanDuong_TraVe_0_4()
        {
            double[] a = { 1, 2, 3, 4, 5 };

            int[] ketQua = BT5.TimDoanDuongDaiNhat(a);

            Assert.Equal(0, ketQua[0]);
            Assert.Equal(4, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 3: Không có số dương
        //
        // -1 -2 -3 -4
        //
        // Không có đoạn dương
        // --------------------------------------------------
        [Fact]
        public void TimDoanDuong_KhongCoSoDuong()
        {
            double[] a = { -1, -2, -3, -4 };

            int[] ketQua = BT5.TimDoanDuongDaiNhat(a);

            Assert.Equal(-1, ketQua[0]);
            Assert.Equal(-1, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 4: Chỉ có một số dương
        //
        // -1 5 -2
        //
        // Đoạn [1, 1]
        // --------------------------------------------------
        [Fact]
        public void TimDoanDuong_MotSoDuong_TraVe_1_1()
        {
            double[] a = { -1, 5, -2 };

            int[] ketQua = BT5.TimDoanDuongDaiNhat(a);

            Assert.Equal(1, ketQua[0]);
            Assert.Equal(1, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 5: Đoạn dương nằm ở cuối
        //
        // -2 -3 4 5 6
        //
        // Đoạn [2, 4]
        // --------------------------------------------------
        [Fact]
        public void TimDoanDuong_NamCuoi_TraVe_2_4()
        {
            double[] a = { -2, -3, 4, 5, 6 };

            int[] ketQua = BT5.TimDoanDuongDaiNhat(a);

            Assert.Equal(2, ketQua[0]);
            Assert.Equal(4, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 6: Đoạn dương nằm ở đầu
        //
        // 2 3 4 -1 -2
        //
        // Đoạn [0, 2]
        // --------------------------------------------------
        [Fact]
        public void TimDoanDuong_NamDau_TraVe_0_2()
        {
            double[] a = { 2, 3, 4, -1, -2 };

            int[] ketQua = BT5.TimDoanDuongDaiNhat(a);

            Assert.Equal(0, ketQua[0]);
            Assert.Equal(2, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 7: Có số 0
        //
        // 1 2 0 3 4
        //
        // 0 không phải số dương
        //
        // Đoạn dài nhất đầu tiên là [0, 1]
        // --------------------------------------------------
        [Fact]
        public void TimDoanDuong_CoSo0_TraVe_0_1()
        {
            double[] a = { 1, 2, 0, 3, 4 };

            int[] ketQua = BT5.TimDoanDuongDaiNhat(a);

            Assert.Equal(0, ketQua[0]);
            Assert.Equal(1, ketQua[1]);
        }


        // --------------------------------------------------
        // TEST 8: Số thực
        //
        // -1.5 2.5 3.5 -2
        //
        // Đoạn dương [1, 2]
        // --------------------------------------------------
        [Fact]
        public void TimDoanDuong_SoThuc_TraVe_1_2()
        {
            double[] a = { -1.5, 2.5, 3.5, -2 };

            int[] ketQua = BT5.TimDoanDuongDaiNhat(a);

            Assert.Equal(1, ketQua[0]);
            Assert.Equal(2, ketQua[1]);
        }
    }
}