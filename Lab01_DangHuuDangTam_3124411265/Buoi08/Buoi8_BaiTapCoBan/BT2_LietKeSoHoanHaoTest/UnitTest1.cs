using Xunit;
using NNLTCSharp.Buoi8;

namespace NNLTCSharp.Tests
{
    public class LietKeSoHoanHaoTest
    {
        [Fact]
        public void Test_SoHoanHao_6()
        {
            bool ketQua = LietKeSoHoanHao.LaSoHoanHao(6);

            Assert.True(ketQua);
        }

        [Fact]
        public void Test_SoKhongHoanHao_10()
        {
            bool ketQua = LietKeSoHoanHao.LaSoHoanHao(10);

            Assert.False(ketQua);
        }

        [Fact]
        public void Test_LietKe_10()
        {
            List<int> ketQua = LietKeSoHoanHao.LietKe(10);

            Assert.Equal(new List<int> { 6 }, ketQua);
        }

        [Fact]
        public void Test_LietKe_1000()
        {
            List<int> ketQua = LietKeSoHoanHao.LietKe(1000);

            Assert.Equal(new List<int> { 496, 28, 6 }, ketQua);
        }
    }
}