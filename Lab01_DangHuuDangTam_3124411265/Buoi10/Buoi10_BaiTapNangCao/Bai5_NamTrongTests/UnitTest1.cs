using Bai5_NamTrong;

namespace Bai5_NamTrongTests
{
    public class UnitTest1
    {
        // --------------------------------------------------
        // TEST 1:
        // Tất cả phần tử của a đều nằm trong b
        //
        // a = {1, 2, 3}
        // b = {1, 2, 3, 4, 5}
        //
        // Kết quả: true
        // --------------------------------------------------
        [Fact]
        public void NamTrong_TatCaPhanTuNamTrongB()
        {
            double[] a = { 1, 2, 3 };
            double[] b = { 1, 2, 3, 4, 5 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 2:
        // Có một phần tử của a không nằm trong b
        //
        // a = {1, 2, 6}
        // b = {1, 2, 3, 4, 5}
        //
        // 6 không nằm trong b
        //
        // Kết quả: false
        // --------------------------------------------------
        [Fact]
        public void NamTrong_CoPhanTuKhongNamTrongB()
        {
            double[] a = { 1, 2, 6 };
            double[] b = { 1, 2, 3, 4, 5 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.False(ketQua);
        }


        // --------------------------------------------------
        // TEST 3:
        // Hai mảng giống nhau
        //
        // a = {1, 2, 3}
        // b = {1, 2, 3}
        //
        // Kết quả: true
        // --------------------------------------------------
        [Fact]
        public void NamTrong_HaiMangGiongNhau()
        {
            double[] a = { 1, 2, 3 };
            double[] b = { 1, 2, 3 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 4:
        // a chứa nhiều phần tử hơn b
        //
        // a = {1, 2, 3, 4}
        // b = {1, 2, 3}
        //
        // 4 không nằm trong b
        //
        // Kết quả: false
        // --------------------------------------------------
        [Fact]
        public void NamTrong_MangAKhongNamHetTrongB()
        {
            double[] a = { 1, 2, 3, 4 };
            double[] b = { 1, 2, 3 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.False(ketQua);
        }


        // --------------------------------------------------
        // TEST 5:
        // Kiểm tra số âm
        //
        // a = {-5, -3, -1}
        // b = {-5, -3, -1, 0, 2}
        //
        // Kết quả: true
        // --------------------------------------------------
        [Fact]
        public void NamTrong_SoAm()
        {
            double[] a = { -5, -3, -1 };
            double[] b = { -5, -3, -1, 0, 2 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 6:
        // Kiểm tra số thực
        //
        // a = {1.5, 2.5}
        // b = {1.5, 2.5, 3.5}
        //
        // Kết quả: true
        // --------------------------------------------------
        [Fact]
        public void NamTrong_SoThuc()
        {
            double[] a = { 1.5, 2.5 };
            double[] b = { 1.5, 2.5, 3.5 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 7:
        // Có số 0
        //
        // a = {0, 2, 4}
        // b = {0, 1, 2, 3, 4}
        //
        // Kết quả: true
        // --------------------------------------------------
        [Fact]
        public void NamTrong_CoSo0()
        {
            double[] a = { 0, 2, 4 };
            double[] b = { 0, 1, 2, 3, 4 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 8:
        // a có phần tử trùng nhau
        //
        // a = {2, 2, 3}
        // b = {1, 2, 3, 4}
        //
        // Vì bài toán kiểm tra "giá trị có nằm trong b"
        // nên hai số 2 đều tìm thấy trong b.
        //
        // Kết quả: true
        // --------------------------------------------------
        [Fact]
        public void NamTrong_CoPhanTuTrungNhau()
        {
            double[] a = { 2, 2, 3 };
            double[] b = { 1, 2, 3, 4 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 9:
        // a chỉ có một phần tử
        //
        // a = {5}
        // b = {1, 2, 5, 7}
        //
        // Kết quả: true
        // --------------------------------------------------
        [Fact]
        public void NamTrong_MotPhanTu()
        {
            double[] a = { 5 };
            double[] b = { 1, 2, 5, 7 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 10:
        // a không có phần tử nào xuất hiện trong b
        //
        // a = {10, 20, 30}
        // b = {1, 2, 3}
        //
        // Kết quả: false
        // --------------------------------------------------
        [Fact]
        public void NamTrong_KhongCoPhanTuNao()
        {
            double[] a = { 10, 20, 30 };
            double[] b = { 1, 2, 3 };

            bool ketQua = BT5.KiemTraNamTrong(a, b);

            Assert.False(ketQua);
        }
    }
}