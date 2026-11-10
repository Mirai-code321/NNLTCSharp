using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai3_MaTranToanLe;

namespace Bai3_MaTranToanLeTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test theo dung vi du mau trong de bai:
        // Ma tran 2x3: [1 7 9] [5 3 15] -> tat ca deu le
        [TestMethod]
        public void KiemTraToanLe_ViDuTrongDeBai_TraVeTrue()
        {
            // Arrange
            MaTranToanLe xuLy = new MaTranToanLe();
            int[,] maTran = new int[,]
            {
                { 1, 7, 9 },
                { 5, 3, 15 }
            };

            // Act
            bool ketQua = xuLy.KiemTraToanLe(maTran);

            // Assert
            Assert.IsTrue(ketQua);
        }

        // Truong hop ma tran co it nhat 1 phan tu chan -> khong con toan le
        [TestMethod]
        public void KiemTraToanLe_CoMotPhanTuChan_TraVeFalse()
        {
            MaTranToanLe xuLy = new MaTranToanLe();
            int[,] maTran = new int[,]
            {
                { 1, 3, 5 },
                { 7, 8, 9 } // 8 la so chan
            };

            bool ketQua = xuLy.KiemTraToanLe(maTran);

            Assert.IsFalse(ketQua);
        }

        // Truong hop ma tran co so am le -> van phai nhan dien dung
        [TestMethod]
        public void KiemTraToanLe_CoSoAmLe_VanTraVeTrue()
        {
            MaTranToanLe xuLy = new MaTranToanLe();
            int[,] maTran = new int[,]
            {
                { -1, -3 },
                { 5, -7 }
            };

            bool ketQua = xuLy.KiemTraToanLe(maTran);

            Assert.IsTrue(ketQua);
        }

        // Truong hop ma tran chi co 1 phan tu
        [TestMethod]
        public void KiemTraToanLe_MaTranMotPhanTu_KiemTraDungTheoGiaTri()
        {
            MaTranToanLe xuLy = new MaTranToanLe();

            int[,] maTranLe = new int[,] { { 3 } };
            int[,] maTranChan = new int[,] { { 4 } };

            Assert.IsTrue(xuLy.KiemTraToanLe(maTranLe));
            Assert.IsFalse(xuLy.KiemTraToanLe(maTranChan));
        }

        // Kiem tra dieu kien hop le cua kich thuoc ma tran (1 <= gia tri <= 100)
        [TestMethod]
        public void KiemTraKichThuocHopLe_CacTruongHopBienCua()
        {
            MaTranToanLe xuLy = new MaTranToanLe();

            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(0));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(1));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(100));
            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(101));
        }
    }
}