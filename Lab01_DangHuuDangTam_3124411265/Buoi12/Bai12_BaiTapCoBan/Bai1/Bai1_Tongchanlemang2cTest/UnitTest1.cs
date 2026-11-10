using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai1_TongChanLeMang2C;

namespace Bai1_TongChanLeMang2CTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test theo dung vi du mau trong de bai:
        // Ma tran 2x3: [2 4 5] [8 10 15]
        // Tong so chan = 24, tong so le = 20
        [TestMethod]
        public void TinhTongChanLe_ViDuTrongDeBai_TraVeDungTong()
        {
            // Arrange
            TongChanLeMang2C xuLy = new TongChanLeMang2C();
            int[,] maTran = new int[,]
            {
                { 2, 4, 5 },
                { 8, 10, 15 }
            };

            // Act
            int tongChan = xuLy.TinhTongSoChan(maTran);
            int tongLe = xuLy.TinhTongSoLe(maTran);

            // Assert
            Assert.AreEqual(24, tongChan);
            Assert.AreEqual(20, tongLe);
        }

        // Truong hop ma tran chi toan so chan
        [TestMethod]
        public void TinhTongChanLe_TatCaDeuChan_TongLeBang0()
        {
            TongChanLeMang2C xuLy = new TongChanLeMang2C();
            int[,] maTran = new int[,]
            {
                { 2, 4 },
                { 6, 8 }
            };

            Assert.AreEqual(20, xuLy.TinhTongSoChan(maTran));
            Assert.AreEqual(0, xuLy.TinhTongSoLe(maTran));
        }

        // Truong hop ma tran chi toan so le
        [TestMethod]
        public void TinhTongChanLe_TatCaDeuLe_TongChanBang0()
        {
            TongChanLeMang2C xuLy = new TongChanLeMang2C();
            int[,] maTran = new int[,]
            {
                { 1, 3 },
                { 5, 7 }
            };

            Assert.AreEqual(0, xuLy.TinhTongSoChan(maTran));
            Assert.AreEqual(16, xuLy.TinhTongSoLe(maTran));
        }

        // Kiem tra dieu kien hop le cua kich thuoc ma tran (1 <= gia tri <= 100)
        [TestMethod]
        public void KiemTraKichThuocHopLe_CacTruongHopBienCua()
        {
            TongChanLeMang2C xuLy = new TongChanLeMang2C();

            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(0));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(1));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(100));
            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(101));
        }
    }
}