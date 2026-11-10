using Xunit;
using NNLTCSharp.Buoi02;

namespace NNLTCSharp.Tests
{
    public class UnitTestSoNgayThang
    {
        [Fact]
        public void Test_Thang2_NamNhuan()
        {
            int ketQua = SoNgayThang.TinhSoNgay(2, 2024);

            Assert.Equal(29, ketQua);
        }

        [Fact]
        public void Test_Thang2_NamKhongNhuan()
        {
            int ketQua = SoNgayThang.TinhSoNgay(2, 2023);

            Assert.Equal(28, ketQua);
        }

        [Fact]
        public void Test_Thang4()
        {
            int ketQua = SoNgayThang.TinhSoNgay(4, 2024);

            Assert.Equal(30, ketQua);
        }

        [Fact]
        public void Test_Thang1()
        {
            int ketQua = SoNgayThang.TinhSoNgay(1, 2024);

            Assert.Equal(31, ketQua);
        }
    }
}

