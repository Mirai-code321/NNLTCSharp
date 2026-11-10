using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class SapLaiChuSoTest
    {
        [Fact]
        public void Test_SapLai_13231()
        {
            long ketQua = SapLaiChuSo.SapXep(13231);

            Assert.Equal(33211, ketQua);
        }

        [Fact]
        public void Test_SapLai_12345()
        {
            long ketQua = SapLaiChuSo.SapXep(12345);

            Assert.Equal(54321, ketQua);
        }

        [Fact]
        public void Test_SapLai_54321()
        {
            long ketQua = SapLaiChuSo.SapXep(54321);

            Assert.Equal(54321, ketQua);
        }

        [Fact]
        public void Test_SapLai_112233()
        {
            long ketQua = SapLaiChuSo.SapXep(112233);

            Assert.Equal(332211, ketQua);
        }
    }
}