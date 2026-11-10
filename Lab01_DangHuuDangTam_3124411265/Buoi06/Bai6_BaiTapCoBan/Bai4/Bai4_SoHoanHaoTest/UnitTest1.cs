using Xunit;
using KiemTraSoHoanHao;

namespace Bai4_KiemTraSoHoanHaoTests
{
    public class SoHoanHaoTests
    {
        [Fact]
        public void KiemTra_6_LaSoHoanHao()
        {
            // 6 = 1 + 2 + 3
            // Tổng các ước không kể chính nó bằng 6
            bool ketQua = new SoHoanHao().KiemTra(6);

            Assert.True(ketQua);
        }

        [Fact]
        public void KiemTra_8_KhongLaSoHoanHao()
        {
            // Các ước của 8 không kể chính nó:
            // 1 + 2 + 4 = 7
            // 7 khác 8 nên 8 không phải số hoàn hảo
            bool ketQua = new SoHoanHao().KiemTra(8);

            Assert.False(ketQua);
        }

        [Fact]
        public void KiemTra_28_LaSoHoanHao()
        {
            // 28 = 1 + 2 + 4 + 7 + 14
            bool ketQua = new SoHoanHao().KiemTra(28);

            Assert.True(ketQua);
        }

        [Fact]
        public void TongUoc_6_TraVe6()
        {
            // 1 + 2 + 3 = 6
            int ketQua = new SoHoanHao().TongUoc(6);

            Assert.Equal(6, ketQua);
        }

        [Fact]
        public void TongUoc_8_TraVe7()
        {
            // 1 + 2 + 4 = 7
            int ketQua = new SoHoanHao().TongUoc(8);

            Assert.Equal(7, ketQua);
        }

        [Fact]
        public void LayDanhSachUoc_6_TraVe1Cong2Cong3()
        {
            // Kiểm tra danh sách các ước của 6
            string ketQua = new SoHoanHao().LayDanhSachUoc(6);

            Assert.Equal("1 + 2 + 3", ketQua);
        }

        [Fact]
        public void LayDanhSachUoc_28_TraVeDungDanhSach()
        {
            // Các ước của 28 không kể chính nó:
            // 1 + 2 + 4 + 7 + 14
            string ketQua = new SoHoanHao().LayDanhSachUoc(28);

            Assert.Equal("1 + 2 + 4 + 7 + 14", ketQua);
        }

        [Theory]
        [InlineData(6, true)]
        [InlineData(28, true)]
        [InlineData(496, true)]
        [InlineData(8, false)]
        [InlineData(10, false)]
        [InlineData(12, false)]
        public void KiemTra_NhieuTruongHop(
            int n,
            bool ketQuaMongMuon)
        {
            // Kiểm tra nhiều trường hợp
            bool ketQua = new SoHoanHao().KiemTra(n);

            Assert.Equal(ketQuaMongMuon, ketQua);
        }
    }
}