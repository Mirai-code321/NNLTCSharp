using Xunit;
using NNLTCSharp.Buoi04;

namespace NNLTCSharp.Tests
{
    public class UnitTestGiaTriHamSoDoThi
    {
        [Fact]
        public void Test_DoanThuNhat()
        {
            Assert.Equal(-0.5, GiaTriHamSoDoThi.TinhGiaTri(0));
            Assert.Equal(0.25, GiaTriHamSoDoThi.TinhGiaTri(0.5));
            Assert.Equal(1, GiaTriHamSoDoThi.TinhGiaTri(1));
        }

        [Fact]
        public void Test_DoanThuHai()
        {
            Assert.Equal(-0.5, GiaTriHamSoDoThi.TinhGiaTri(1.5));
            Assert.Equal(-2, GiaTriHamSoDoThi.TinhGiaTri(2));
        }
    }
}

