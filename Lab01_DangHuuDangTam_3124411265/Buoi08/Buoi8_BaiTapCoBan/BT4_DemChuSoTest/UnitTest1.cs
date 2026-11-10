using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class DemChuSoTest
    {
        [Fact]
        public void Test_ChuSo3_XuatHien_2_Lan()
        {
            int ketQua = DemChuSo.DemSoLanXuatHien(13324, 3);

            Assert.Equal(2, ketQua);
        }

        [Fact]
        public void Test_ChuSo1_XuatHien_1_Lan()
        {
            int ketQua = DemChuSo.DemSoLanXuatHien(13324, 1);

            Assert.Equal(1, ketQua);
        }

        [Fact]
        public void Test_ChuSo5_KhongXuatHien()
        {
            int ketQua = DemChuSo.DemSoLanXuatHien(13324, 5);

            Assert.Equal(0, ketQua);
        }

                [Fact]
        public void Test_ChuSo0_XuatHien_3_Lan()
        {
            int ketQua = DemChuSo.DemSoLanXuatHien(10020, 0);

            Assert.Equal(3, ketQua);
        }

        [Fact]
        public void Test_ChuSo9_XuatHien_3_Lan()
        {
            int ketQua = DemChuSo.DemSoLanXuatHien(99912, 9);

            Assert.Equal(3, ketQua);
        }
    }
}