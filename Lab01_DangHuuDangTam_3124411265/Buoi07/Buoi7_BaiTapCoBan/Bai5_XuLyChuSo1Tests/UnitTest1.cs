using Xunit;
using XuLyChuSo1;

namespace Bai5_XuLyChuSo1Tests
{
    public class XuLyChuSo1Tests
    {
        [Fact]
        public void ChuSoTaiViTri_ViDuMau_ViTri2()
        {
            // Arrange
            int n = 182345, k = 2;

            // Act
            int ketQua = Program.ChuSoTaiViTri(n, k);

            // Assert
            Assert.Equal(8, ketQua);
        }

        [Theory]
        [InlineData(182345, 1, 1)]  // Vi tri dau tien
        [InlineData(182345, 6, 5)]  // Vi tri cuoi cung
        [InlineData(182345, 3, 2)]
        public void ChuSoTaiViTri_NhieuTruongHop(int n, int k, int ketQuaMongMuon)
        {
            int ketQua = Program.ChuSoTaiViTri(n, k);
            Assert.Equal(ketQuaMongMuon, ketQua);
        }

        [Fact]
        public void TongCacChuSoLe_ViDuMau_182345()
        {
            int ketQua = Program.TongCacChuSoLe(182345);
            Assert.Equal(9, ketQua);
        }

        [Theory]
        [InlineData(2468, 0)]     // Khong co chu so le nao
        [InlineData(13579, 25)]  // Toan chu so le
        [InlineData(1000000, 1)]
        public void TongCacChuSoLe_NhieuTruongHop(int n, int tongMongMuon)
        {
            int ketQua = Program.TongCacChuSoLe(n);
            Assert.Equal(tongMongMuon, ketQua);
        }

        [Fact]
        public void TimChuSoLeNhoNhatLonNhat_ViDuMau_182345()
        {
            var ketQua = Program.TimChuSoLeNhoNhatLonNhat(182345);

            Assert.NotNull(ketQua);
            Assert.Equal(1, ketQua!.Value.nhoNhat);
            Assert.Equal(5, ketQua.Value.lonNhat);
        }

        [Fact]
        public void TimChuSoLeNhoNhatLonNhat_KhongCoChuSoLe_TraVeNull()
        {
            // 2468 chi co chu so chan, khong co chu so le nao
            var ketQua = Program.TimChuSoLeNhoNhatLonNhat(2468);

            Assert.Null(ketQua);
        }

        [Fact]
        public void TimChuSoLeNhoNhatLonNhat_ChiCoMotChuSoLe_MinBangMax()
        {
            // 1000000 chi co 1 chu so le duy nhat la 1
            var ketQua = Program.TimChuSoLeNhoNhatLonNhat(1000000);

            Assert.NotNull(ketQua);
            Assert.Equal(1, ketQua!.Value.nhoNhat);
            Assert.Equal(1, ketQua.Value.lonNhat);
        }

        [Fact]
        public void TimChuSoLeNhoNhatLonNhat_ToanChuSoLe()
        {
            var ketQua = Program.TimChuSoLeNhoNhatLonNhat(13579);

            Assert.NotNull(ketQua);
            Assert.Equal(1, ketQua!.Value.nhoNhat);
            Assert.Equal(9, ketQua.Value.lonNhat);
        }
    }
}