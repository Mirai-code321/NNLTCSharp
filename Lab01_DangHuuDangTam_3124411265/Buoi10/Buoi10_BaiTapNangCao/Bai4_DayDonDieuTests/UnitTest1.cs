using Bai4_DayDonDieu;

namespace Bai4_DayDonDieuTests
{
    public class UnitTest1
    {
        // --------------------------------------------------
        // TEST 1:
        // Dãy tăng dần
        //
        // 1 2 3 4 5
        // --------------------------------------------------
        [Fact]
        public void KiemTraDonDieu_TangDan()
        {
            double[] a = { 1, 2, 3, 4, 5 };

            bool ketQua = BT4.KiemTraDonDieu(a);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 2:
        // Dãy giảm dần
        //
        // 5 4 3 2 1
        // --------------------------------------------------
        [Fact]
        public void KiemTraDonDieu_GiamDan()
        {
            double[] a = { 5, 4, 3, 2, 1 };

            bool ketQua = BT4.KiemTraDonDieu(a);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 3:
        // Dãy không đơn điệu
        //
        // 1 3 2 4
        //
        // Tăng rồi giảm rồi tăng
        // --------------------------------------------------
        [Fact]
        public void KiemTraDonDieu_KhongDonDieu()
        {
            double[] a = { 1, 3, 2, 4 };

            bool ketQua = BT4.KiemTraDonDieu(a);

            Assert.False(ketQua);
        }


        // --------------------------------------------------
        // TEST 4:
        // Dãy tăng có các phần tử bằng nhau
        //
        // 1 2 2 3 4
        //
        // Vẫn được xem là tăng dần
        // --------------------------------------------------
        [Fact]
        public void KiemTraDonDieu_TangCoPhanTuBangNhau()
        {
            double[] a = { 1, 2, 2, 3, 4 };

            bool ketQua = BT4.KiemTraDonDieu(a);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 5:
        // Dãy giảm có các phần tử bằng nhau
        //
        // 5 4 4 2 1
        //
        // Vẫn được xem là giảm dần
        // --------------------------------------------------
        [Fact]
        public void KiemTraDonDieu_GiamCoPhanTuBangNhau()
        {
            double[] a = { 5, 4, 4, 2, 1 };

            bool ketQua = BT4.KiemTraDonDieu(a);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 6:
        // Tất cả phần tử bằng nhau
        //
        // 5 5 5 5
        //
        // Vừa không giảm vừa không tăng
        // nên vẫn là dãy đơn điệu
        // --------------------------------------------------
        [Fact]
        public void KiemTraDonDieu_CacPhanTuBangNhau()
        {
            double[] a = { 5, 5, 5, 5 };

            bool ketQua = BT4.KiemTraDonDieu(a);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 7:
        // Dãy số âm tăng dần
        //
        // -5 -3 -1 2
        // --------------------------------------------------
        [Fact]
        public void KiemTraDonDieu_SoAmTangDan()
        {
            double[] a = { -5, -3, -1, 2 };

            bool ketQua = BT4.KiemTraDonDieu(a);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 8:
        // Dãy số thực giảm dần
        //
        // 5.5 4.2 3.1 1.8
        // --------------------------------------------------
        [Fact]
        public void KiemTraDonDieu_SoThucGiamDan()
        {
            double[] a = { 5.5, 4.2, 3.1, 1.8 };

            bool ketQua = BT4.KiemTraDonDieu(a);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 9:
        // Kiểm tra chính xác hàm tăng dần
        // --------------------------------------------------
        [Fact]
        public void KiemTraTangDan_Dung()
        {
            double[] a = { -3, -1, 0, 2, 5 };

            bool ketQua = BT4.KiemTraTangDan(a);

            Assert.True(ketQua);
        }


        // --------------------------------------------------
        // TEST 10:
        // Kiểm tra chính xác hàm giảm dần
        // --------------------------------------------------
        [Fact]
        public void KiemTraGiamDan_Dung()
        {
            double[] a = { 10, 8, 5, 3, 1 };

            bool ketQua = BT4.KiemTraGiamDan(a);

            Assert.True(ketQua);
        }
    }
}