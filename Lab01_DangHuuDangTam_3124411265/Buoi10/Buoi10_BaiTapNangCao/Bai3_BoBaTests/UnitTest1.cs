using Bai3_BoBa;

namespace Bai3_BoBaTests
{
    public class UnitTest1
    {
        // --------------------------------------------------
        // TEST 1:
        // Có bộ ba đơn giản
        //
        // 2 3 5
        //
        // 5 = 2 + 3
        // 5 = 3 + 2
        // --------------------------------------------------
        [Fact]
        public void TimBoBa_BoBaDonGian()
        {
            double[] mang = { 2, 3, 5 };

            List<string> ketQua = BT3.TimBoBa(mang);

            Assert.Equal(2, ketQua.Count);

            Assert.Contains(
                "a = 5, b = 2, c = 3",
                ketQua
            );

            Assert.Contains(
                "a = 5, b = 3, c = 2",
                ketQua
            );
        }


        // --------------------------------------------------
        // TEST 2:
        // Có nhiều bộ ba
        //
        // 1 2 3 4 5
        //
        // 3 = 1 + 2
        // 4 = 1 + 3
        // 5 = 1 + 4
        // 5 = 2 + 3
        // --------------------------------------------------
        [Fact]
        public void TimBoBa_NhieuBoBa()
        {
            double[] mang = { 1, 2, 3, 4, 5 };

            List<string> ketQua = BT3.TimBoBa(mang);

            Assert.Equal(8, ketQua.Count);
        }


        // --------------------------------------------------
        // TEST 3:
        // Không có bộ ba
        // --------------------------------------------------
        [Fact]
        public void TimBoBa_KhongCoBoBa()
        {
            double[] mang = { 1, 4, 8, 15 };

            List<string> ketQua = BT3.TimBoBa(mang);

            Assert.Empty(ketQua);
        }


        // --------------------------------------------------
        // TEST 4:
        // Không chấp nhận b = c
        //
        // 2 4 6
        //
        // 6 = 2 + 4
        // Có bộ ba hợp lệ.
        //
        // Nhưng 4 = 2 + 2 không được tính
        // vì b và c phải khác nhau.
        // --------------------------------------------------
        [Fact]
        public void TimBoBa_BVaCKhacNhau()
        {
            double[] mang = { 2, 4, 6 };

            List<string> ketQua = BT3.TimBoBa(mang);

            Assert.Equal(2, ketQua.Count);

            Assert.Contains(
                "a = 6, b = 2, c = 4",
                ketQua
            );

            Assert.Contains(
                "a = 6, b = 4, c = 2",
                ketQua
            );
        }


        // --------------------------------------------------
        // TEST 5:
        // Kiểm tra số âm
        //
        // -5 2 -3
        //
        // -3 = -5 + 2
        // --------------------------------------------------
        [Fact]
        public void TimBoBa_CoSoAm()
        {
            double[] mang = { -5, 2, -3 };

            List<string> ketQua = BT3.TimBoBa(mang);

            Assert.Equal(2, ketQua.Count);

            Assert.Contains(
                "a = -3, b = -5, c = 2",
                ketQua
            );

            Assert.Contains(
                "a = -3, b = 2, c = -5",
                ketQua
            );
        }


        // --------------------------------------------------
        // TEST 6:
        // Kiểm tra số thực
        //
        // 1.5 2.5 4
        //
        // 4 = 1.5 + 2.5
        // --------------------------------------------------
        [Fact]
        public void TimBoBa_SoThuc()
        {
            double[] mang = { 1.5, 2.5, 4 };

            List<string> ketQua = BT3.TimBoBa(mang);

            Assert.Equal(2, ketQua.Count);

            // Máy dùng định dạng số thập phân của Việt Nam
            // nên 1.5 được hiển thị thành 1,5
            Assert.Contains(
                "a = 4, b = 1,5, c = 2,5",
                ketQua
            );

            Assert.Contains(
                "a = 4, b = 2,5, c = 1,5",
                ketQua
            );
        }


        // --------------------------------------------------
        // TEST 7:
        // Có phần tử trùng nhau
        //
        // 2 2 3 5
        //
        // 5 = 2 + 3
        //
        // Hai số 2 giống giá trị nhau nên không được
        // xem là hai giá trị khác nhau.
        // --------------------------------------------------
        [Fact]
        public void TimBoBa_CoGiaTriTrung()
        {
            double[] mang = { 2, 2, 3, 5 };

            List<string> ketQua = BT3.TimBoBa(mang);

            Assert.Equal(2, ketQua.Count);

            Assert.Contains(
                "a = 5, b = 2, c = 3",
                ketQua
            );

            Assert.Contains(
                "a = 5, b = 3, c = 2",
                ketQua
            );
        }


        // --------------------------------------------------
        // TEST 8:
        // Trường hợp không có đủ ba giá trị khác nhau
        // --------------------------------------------------
        [Fact]
        public void TimBoBa_TatCaBangNhau()
        {
            double[] mang = { 5, 5, 5, 5 };

            List<string> ketQua = BT3.TimBoBa(mang);

            Assert.Empty(ketQua);
        }
    }
}