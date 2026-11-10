using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class GiaiThuaTest
    {
        [Fact]
        public void Test_GiaiThua_5()
        {
            long ketQua = GiaiThua.TinhGiaiThua(5);

            Assert.Equal(120, ketQua);
        }

        [Fact]
        public void Test_ToHop_10_5()
        {
            long ketQua = GiaiThua.TinhToHop(10, 5);

            Assert.Equal(252, ketQua);
        }

        [Fact]
        public void Test_ToHop_5_2()
        {
            long ketQua = GiaiThua.TinhToHop(5, 2);

            Assert.Equal(10, ketQua);
        }

        [Fact]
        public void Test_ToHop_6_3()
        {
            long ketQua = GiaiThua.TinhToHop(6, 3);

            Assert.Equal(20, ketQua);
        }
    }
}