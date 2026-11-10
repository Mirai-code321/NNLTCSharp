using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class DocSoTiTest
    {
        [Fact]
        public void Test_DocSo_15()
        {
            string ketQua = DocSoTi.DocSo(15);

            Assert.Equal("muoi lam", ketQua);
        }

        [Fact]
        public void Test_DocSo_105()
        {
            string ketQua = DocSoTi.DocSo(105);

            Assert.Equal("mot tram le nam", ketQua);
        }

        [Fact]
        public void Test_DocSo_1000()
        {
            string ketQua = DocSoTi.DocSo(1000);

            Assert.Equal("mot nghin", ketQua);
        }

        [Fact]
        public void Test_DocSo_123456()
        {
            string ketQua = DocSoTi.DocSo(123456);

            Assert.Equal(
                "mot tram hai muoi ba nghin bon tram nam muoi sau",
                ketQua
            );
        }

        [Fact]
        public void Test_DocSo_105708051006()
        {
            string ketQua = DocSoTi.DocSo(105708051006);

            Assert.Equal(
                "mot tram le nam ty bay tram le tam trieu nam muoi mot nghin sau",
                ketQua
            );
        }
    }
}