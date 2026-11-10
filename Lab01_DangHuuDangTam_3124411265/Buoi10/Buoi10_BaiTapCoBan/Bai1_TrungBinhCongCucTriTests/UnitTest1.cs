using Bai1_TrungBinhCongCucTri;

namespace Bai1_TrungBinhCongCucTriTests
{
    public class UnitTest1
    {
        // Test theo đúng ví dụ của đề
        // -2 5 -3 -4 -6 2 1
        // Các cực đại địa phương: 5 và 2
        // Tổng = 7
        [Fact]
        public void TinhTongCucTri_TheoViDu_TraVe7()
        {
            double[] a = { -2, 5, -3, -4, -6, 2, 1 };

            double ketQua = BT1.TinhTongCucTri(a);

            Assert.Equal(7, ketQua);
        }

        // Kiểm tra dãy tăng dần
        // Không có phần tử nào lớn hơn hai phần tử bên cạnh
        [Fact]
        public void TinhTongCucTri_DayTang_TraVe0()
        {
            double[] a = { 1, 2, 3, 4, 5 };

            double ketQua = BT1.TinhTongCucTri(a);

            Assert.Equal(0, ketQua);
        }

        // Kiểm tra dãy giảm dần
        // Không có cực đại địa phương
        [Fact]
        public void TinhTongCucTri_DayGiam_TraVe0()
        {
            double[] a = { 5, 4, 3, 2, 1 };

            double ketQua = BT1.TinhTongCucTri(a);

            Assert.Equal(0, ketQua);
        }

        // Kiểm tra một cực đại
        // 1 5 2
        // 5 là cực đại
        [Fact]
        public void TinhTongCucTri_MotCucDai_TraVe5()
        {
            double[] a = { 1, 5, 2 };

            double ketQua = BT1.TinhTongCucTri(a);

            Assert.Equal(5, ketQua);
        }

        // Kiểm tra nhiều cực đại
        // 1 5 2 8 3
        // Các cực đại: 5 và 8
        // Tổng = 13
        [Fact]
        public void TinhTongCucTri_NhieuCucDai_TraVe13()
        {
            double[] a = { 1, 5, 2, 8, 3 };

            double ketQua = BT1.TinhTongCucTri(a);

            Assert.Equal(13, ketQua);
        }

        // Kiểm tra số thực
        // 1.5 3.5 2.5
        // 3.5 là cực đại
        [Fact]
        public void TinhTongCucTri_SoThuc_TraVe3_5()
        {
            double[] a = { 1.5, 3.5, 2.5 };

            double ketQua = BT1.TinhTongCucTri(a);

            Assert.Equal(3.5, ketQua);
        }

        // Kiểm tra trường hợp có các phần tử bằng nhau
        [Fact]
        public void TinhTongCucTri_PhanTuBangNhau_TraVe0()
        {
            double[] a = { 2, 2, 2, 2, 2 };

            double ketQua = BT1.TinhTongCucTri(a);

            Assert.Equal(0, ketQua);
        }

        // Kiểm tra cực đại có giá trị âm
        // -5 -2 -4
        // -2 lớn hơn -5 và -4
        [Fact]
        public void TinhTongCucTri_CucDaiAm_TraVeAm2()
        {
            double[] a = { -5, -2, -4 };

            double ketQua = BT1.TinhTongCucTri(a);

            Assert.Equal(-2, ketQua);
        }
    }
}