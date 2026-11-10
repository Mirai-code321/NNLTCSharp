using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai2_DemSoTrenBienMang2C;

namespace Bai2_DemSoTrenBienMang2CTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test theo dung vi du mau trong de bai:
        // Ma tran 3x4:
        //   1.5  -3.2  4.8   0
        //  -1.8   3.9  2.7  4.5
        //   3.3   9.6 -2.8 -4.9
        //
        // Cac phan tu TREN BIEN (khong tinh 3.9 va 2.7 vi la phan tu noi bo):
        //   1.5, -3.2, 4.8, 0, -1.8, 4.5, 3.3, 9.6, -2.8, -4.9
        // -> 5 so duong, 4 so am, 1 so khong
        [TestMethod]
        public void DemSoTrenBien_ViDuTrongDeBai_TraVeDungSoLuong()
        {
            // Arrange
            DemSoTrenBienMang2C xuLy = new DemSoTrenBienMang2C();
            double[,] maTran = new double[,]
            {
                { 1.5, -3.2, 4.8, 0 },
                { -1.8, 3.9, 2.7, 4.5 },
                { 3.3, 9.6, -2.8, -4.9 }
            };

            // Act
            var (soDuong, soAm, soKhong) = xuLy.DemSoTrenBien(maTran);

            // Assert
            Assert.AreEqual(5, soDuong);
            Assert.AreEqual(4, soAm);
            Assert.AreEqual(1, soKhong);
        }

        // Kiem tra ham LaPhanTuBien cho mot ma tran 3x4:
        // Phan tu noi bo duy nhat la (1,1) va (1,2)
        [TestMethod]
        public void LaPhanTuBien_MaTran3x4_NhanDienDungPhanTuNoiBo()
        {
            DemSoTrenBienMang2C xuLy = new DemSoTrenBienMang2C();
            int n = 3, m = 4;

            Assert.IsTrue(xuLy.LaPhanTuBien(0, 0, n, m));   // goc tren trai -> bien
            Assert.IsTrue(xuLy.LaPhanTuBien(2, 3, n, m));   // goc duoi phai -> bien
            Assert.IsTrue(xuLy.LaPhanTuBien(1, 0, n, m));   // cot dau, dong giua -> bien
            Assert.IsFalse(xuLy.LaPhanTuBien(1, 1, n, m));  // noi bo
            Assert.IsFalse(xuLy.LaPhanTuBien(1, 2, n, m));  // noi bo
        }

        // Truong hop ma tran chi co 1 dong (moi phan tu deu la bien)
        [TestMethod]
        public void DemSoTrenBien_MaTranMotDong_TatCaPhanTuDeuLaBien()
        {
            DemSoTrenBienMang2C xuLy = new DemSoTrenBienMang2C();
            double[,] maTran = new double[,] { { 1, -2, 0, 3 } };

            var (soDuong, soAm, soKhong) = xuLy.DemSoTrenBien(maTran);

            Assert.AreEqual(2, soDuong);
            Assert.AreEqual(1, soAm);
            Assert.AreEqual(1, soKhong);
        }

        // Kiem tra dieu kien hop le cua kich thuoc ma tran (1 <= gia tri <= 100)
        [TestMethod]
        public void KiemTraKichThuocHopLe_CacTruongHopBienCua()
        {
            DemSoTrenBienMang2C xuLy = new DemSoTrenBienMang2C();

            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(0));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(1));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(100));
            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(101));
        }
    }
}