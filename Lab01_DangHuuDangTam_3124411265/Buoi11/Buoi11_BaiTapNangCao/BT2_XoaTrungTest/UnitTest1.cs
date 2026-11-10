using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestXoaTrung
    {
        [Fact]
        public void Test_XoaTrung()
        {
            int[] a = { 2, 4, 3, 2, 4, 5, 3, 5 };

            int[] ketQua = XoaTrung.Xoa(a);

            int[] mongDoi = { 2, 4, 3, 5 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_KhongCoPhanTuTrung()
        {
            int[] a = { 1, 2, 3, 4, 5 };

            int[] ketQua = XoaTrung.Xoa(a);

            int[] mongDoi = { 1, 2, 3, 4, 5 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_TatCaGiongNhau()
        {
            int[] a = { 5, 5, 5, 5 };

            int[] ketQua = XoaTrung.Xoa(a);

            int[] mongDoi = { 5 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_MangRong()
        {
            int[] a = { };

            int[] ketQua = XoaTrung.Xoa(a);

            int[] mongDoi = { };

            Assert.Equal(mongDoi, ketQua);
        }
    }
}
