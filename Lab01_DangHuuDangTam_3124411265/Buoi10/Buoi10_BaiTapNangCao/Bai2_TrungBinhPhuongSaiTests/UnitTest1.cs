using Bai2_TrungBinhPhuongSai;

namespace Bai2_TrungBinhPhuongSaiTests
{
    public class UnitTest1
    {
        // --------------------------------------------------
        // TEST 1:
        // Dãy: 1 2 3 4 5
        //
        // Trung bình = 3
        //
        // Phương sai:
        // ((1-3)^2 + (2-3)^2 + (3-3)^2
        //  + (4-3)^2 + (5-3)^2) / (5-1)
        //
        // = 10 / 4
        // = 2.5
        //
        // Độ lệch chuẩn = sqrt(2.5)
        // --------------------------------------------------
        [Fact]
        public void TinhTrungBinh_Day1Den5_TraVe3()
        {
            double[] a = { 1, 2, 3, 4, 5 };

            double ketQua = BT2.TinhTrungBinh(a);

            Assert.Equal(3, ketQua);
        }

        [Fact]
        public void TinhPhuongSai_Day1Den5_TraVe2_5()
        {
            double[] a = { 1, 2, 3, 4, 5 };

            double ketQua = BT2.TinhPhuongSai(a);

            Assert.Equal(2.5, ketQua, 10);
        }

        [Fact]
        public void TinhDoLechChuan_Day1Den5()
        {
            double[] a = { 1, 2, 3, 4, 5 };

            double ketQua = BT2.TinhDoLechChuan(a);

            Assert.Equal(Math.Sqrt(2.5), ketQua, 10);
        }


        // --------------------------------------------------
        // TEST 2:
        // Các phần tử bằng nhau
        //
        // 5 5 5 5
        //
        // Trung bình = 5
        // Phương sai = 0
        // Độ lệch chuẩn = 0
        // --------------------------------------------------
        [Fact]
        public void TinhTrungBinh_CacPhanTuBangNhau()
        {
            double[] a = { 5, 5, 5, 5 };

            double ketQua = BT2.TinhTrungBinh(a);

            Assert.Equal(5, ketQua);
        }

        [Fact]
        public void TinhPhuongSai_CacPhanTuBangNhau()
        {
            double[] a = { 5, 5, 5, 5 };

            double ketQua = BT2.TinhPhuongSai(a);

            Assert.Equal(0, ketQua);
        }


        // --------------------------------------------------
        // TEST 3:
        // Dãy số âm
        //
        // -1 -2 -3
        //
        // Trung bình = -2
        //
        // Phương sai:
        // ((-1 + 2)^2 + (-2 + 2)^2
        //  + (-3 + 2)^2) / 2
        //
        // = 1
        // --------------------------------------------------
        [Fact]
        public void TinhTrungBinh_DayAm_TraVeAm2()
        {
            double[] a = { -1, -2, -3 };

            double ketQua = BT2.TinhTrungBinh(a);

            Assert.Equal(-2, ketQua);
        }

        [Fact]
        public void TinhPhuongSai_DayAm_TraVe1()
        {
            double[] a = { -1, -2, -3 };

            double ketQua = BT2.TinhPhuongSai(a);

            Assert.Equal(1, ketQua, 10);
        }


        // --------------------------------------------------
        // TEST 4:
        // Kiểm tra số thực
        //
        // 1.5 2.5 3.5
        //
        // Trung bình = 2.5
        // Phương sai = 1
        // --------------------------------------------------
        [Fact]
        public void TinhTrungBinh_SoThuc_TraVe2_5()
        {
            double[] a = { 1.5, 2.5, 3.5 };

            double ketQua = BT2.TinhTrungBinh(a);

            Assert.Equal(2.5, ketQua);
        }

        [Fact]
        public void TinhPhuongSai_SoThuc_TraVe1()
        {
            double[] a = { 1.5, 2.5, 3.5 };

            double ketQua = BT2.TinhPhuongSai(a);

            Assert.Equal(1, ketQua, 10);
        }


        // --------------------------------------------------
        // TEST 5:
        // Chỉ có 2 phần tử
        //
        // 2 4
        //
        // Trung bình = 3
        //
        // Phương sai:
        // ((2-3)^2 + (4-3)^2) / (2-1)
        // = 2
        // --------------------------------------------------
        [Fact]
        public void TinhTrungBinh_HaiPhanTu_TraVe3()
        {
            double[] a = { 2, 4 };

            double ketQua = BT2.TinhTrungBinh(a);

            Assert.Equal(3, ketQua);
        }

        [Fact]
        public void TinhPhuongSai_HaiPhanTu_TraVe2()
        {
            double[] a = { 2, 4 };

            double ketQua = BT2.TinhPhuongSai(a);

            Assert.Equal(2, ketQua, 10);
        }
    }
}