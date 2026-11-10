using Xunit;
using NNLTCSharp.Buoi3;

namespace NNLTCSharp.Tests
{
    public class UnitTestTienNuoc
    {
        [Fact]
        public void Test_TienNuoc_TrongDinhMucDau()
        {
            double ketQua = TienNuoc.TinhTienNuoc(10, 15, 2);

            Assert.Equal(25300, ketQua, 0);
        }

        [Fact]
        public void Test_TienNuoc_VuotDinhMucDau()
        {
            double ketQua = TienNuoc.TinhTienNuoc(10, 20, 2);

            Assert.Equal(59570, ketQua, 0);
        }

        [Fact]
        public void Test_TienNuoc_VuotDinhMucThuHai()
        {
            double ketQua = TienNuoc.TinhTienNuoc(10, 30, 2);

            Assert.Equal(175260, ketQua, 0);
        }
    }
}

