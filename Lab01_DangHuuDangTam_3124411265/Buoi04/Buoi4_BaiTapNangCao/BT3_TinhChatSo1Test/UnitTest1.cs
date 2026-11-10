using Xunit;
using NNLTCSharp.Buoi04;

namespace NNLTCSharp.Tests
{
    public class UnitTestTinhChatSo1
    {
        [Fact]
        public void Test_DemSoChuSo()
        {
            Assert.Equal(1, TinhChatSo1.DemSoChuSo(5));
            Assert.Equal(2, TinhChatSo1.DemSoChuSo(25));
            Assert.Equal(3, TinhChatSo1.DemSoChuSo(123));
        }

        [Fact]
        public void Test_TinhTongChuSo()
        {
            Assert.Equal(6, TinhChatSo1.TinhTongChuSo(123));
            Assert.Equal(18, TinhChatSo1.TinhTongChuSo(567));
            Assert.Equal(1, TinhChatSo1.TinhTongChuSo(100));
        }

        [Fact]
        public void Test_TimChuSoCuoi()
        {
            Assert.Equal(3, TinhChatSo1.TimChuSoCuoi(123));
            Assert.Equal(7, TinhChatSo1.TimChuSoCuoi(567));
            Assert.Equal(0, TinhChatSo1.TimChuSoCuoi(100));
        }

        [Fact]
        public void Test_TimChuSoDau()
        {
            Assert.Equal(1, TinhChatSo1.TimChuSoDau(123));
            Assert.Equal(5, TinhChatSo1.TimChuSoDau(567));
            Assert.Equal(1, TinhChatSo1.TimChuSoDau(100));
        }
    }
}

