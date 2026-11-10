using Xunit;
using NNLTCSharp.Buoi04;

namespace NNLTCSharp.Tests
{
    public class UnitTestTinhChatSo
    {
        [Fact]
        public void Test_SoDoiXung()
        {
            Assert.True(TinhChatSo.LaSoDoiXung(1221));
            Assert.False(TinhChatSo.LaSoDoiXung(1234));
        }

        [Fact]
        public void Test_Co3ChuSoGiongNhau()
        {
            Assert.True(TinhChatSo.Co3ChuSoGiongNhau(1112));
            Assert.True(TinhChatSo.Co3ChuSoGiongNhau(1211));
            Assert.False(TinhChatSo.Co3ChuSoGiongNhau(1221));
        }

        [Fact]
        public void Test_Co4ChuSoKhacNhau()
        {
            Assert.True(TinhChatSo.Co4ChuSoKhacNhau(1234));
            Assert.False(TinhChatSo.Co4ChuSoKhacNhau(1221));
        }
    }
}

