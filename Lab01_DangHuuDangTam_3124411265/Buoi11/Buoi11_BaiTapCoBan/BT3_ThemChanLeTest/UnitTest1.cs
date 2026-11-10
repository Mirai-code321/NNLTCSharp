using Xunit;
using NNLTCSharp.Buoi11;

namespace NNLTCSharp.Tests
{
    public class UnitTestThemChanLe
    {
        [Fact]
        public void Test_ThemChanLe()
        {
            int[] a = { 2, 4, 3, 4, 2, 8, 2, 5 };

            int[] ketQua = ThemChanLe.Them(a);

            int[] mongDoi = { 2, 3, 4, 3, 4, 5, 2, 3, 8, 9, 2, 5 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_HaiSoChanLienTiep()
        {
            int[] a = { 2, 4 };

            int[] ketQua = ThemChanLe.Them(a);

            int[] mongDoi = { 2, 3, 4 };

            Assert.Equal(mongDoi, ketQua);
        }

        [Fact]
        public void Test_KhongCoHaiSoChan()
        {
            int[] a = { 2, 3, 4, 5 };

            int[] ketQua = ThemChanLe.Them(a);

            int[] mongDoi = { 2, 3, 4, 5 };

            Assert.Equal(mongDoi, ketQua);
        }
    }
}
