using Xunit;
using KiemTraSoHoanHao;

namespace Bai2_KiemTraSoHoanHaoTests
{
    public class KiemTraSoHoanHaoTests
    {
        [Fact]
        public void KiemTra_ViDuMau_6_LaSoHoanHao()
        {
            // Arrange
            int n = 6;

            // Act
            var (laHoanHao, uocSo, tongUoc) = Program.KiemTraSoHoanHao(n);

            // Assert
            Assert.True(laHoanHao);
            Assert.Equal(new List<int> { 1, 2, 3 }, uocSo);
            Assert.Equal(6, tongUoc);
        }

        [Fact]
        public void KiemTra_ViDuMau_8_KhongLaSoHoanHao()
        {
            var (laHoanHao, _, tongUoc) = Program.KiemTraSoHoanHao(8);

            Assert.False(laHoanHao);
            Assert.Equal(7, tongUoc);
        }

        [Theory]
        [InlineData(6, true)]     // So hoan hao nho nhat
        [InlineData(28, true)]    // So hoan hao thu 2
        [InlineData(496, true)]   // So hoan hao thu 3
        [InlineData(8, false)]
        [InlineData(10, false)]
        [InlineData(12, false)]
        [InlineData(1, false)]    // Truong hop bien: so 1 khong co uoc nao (ngoai chinh no)
        public void KiemTra_NhieuTruongHop(int n, bool ketQuaMongMuon)
        {
            var (laHoanHao, _, _) = Program.KiemTraSoHoanHao(n);
            Assert.Equal(ketQuaMongMuon, laHoanHao);
        }

        [Fact]
        public void TimCacUocSo_ViDu_28()
        {
            var ketQua = Program.TimCacUocSo(28);
            Assert.Equal(new List<int> { 1, 2, 4, 7, 14 }, ketQua);
        }
    }
}