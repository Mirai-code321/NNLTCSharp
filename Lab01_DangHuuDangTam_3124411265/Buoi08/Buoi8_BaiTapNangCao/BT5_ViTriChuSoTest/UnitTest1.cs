using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class ViTriChuSoTest
    {
        [Fact]
        public void Test_ViTri_1()
        {
            int ketQua = ViTriChuSo.TimChuSo(1);

            Assert.Equal(1, ketQua);
        }

        [Fact]
        public void Test_ViTri_9()
        {
            int ketQua = ViTriChuSo.TimChuSo(9);

            Assert.Equal(9, ketQua);
        }

        [Fact]
        public void Test_ViTri_10()
        {
            int ketQua = ViTriChuSo.TimChuSo(10);

            Assert.Equal(1, ketQua);
        }

        [Fact]
        public void Test_ViTri_11()
        {
            int ketQua = ViTriChuSo.TimChuSo(11);

            Assert.Equal(0, ketQua);
        }

        [Fact]
        public void Test_ViTri_15()
        {
            int ketQua = ViTriChuSo.TimChuSo(15);

            Assert.Equal(2, ketQua);
        }

        [Fact]
        public void Test_ViTri_20()
        {
            int ketQua = ViTriChuSo.TimChuSo(20);

            Assert.Equal(1, ketQua);
        }
    }
}