using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai3_XayDungMaTran;

namespace Bai3_XayDungMaTranTest
{
    [TestClass]
    public class UnitTest1
    {
        // Ma tran A 3x3 xen ke duong/am, tinh tay truoc de doi chieu:
        //   1  -2   3
        //  -4   5  -6
        //   7  -8   9
        [TestMethod]
        public void DemSoPhanTuDuongXungQuanh_ViTriGiua_DemDu8LangGieng()
        {
            // Arrange
            XayDungMaTran xuLy = new XayDungMaTran();
            double[,] maTranA = new double[,]
            {
                { 1, -2, 3 },
                { -4, 5, -6 },
                { 7, -8, 9 }
            };

            // Act
            // (1,1) co du 8 lang gieng: 1,-2,3,-4,-6,7,-8,9 -> 4 so duong (1,3,7,9)
            int dem = xuLy.DemSoPhanTuDuongXungQuanh(maTranA, 1, 1);

            // Assert
            Assert.AreEqual(4, dem);
        }

        // Vi tri o goc chi co 3 lang gieng (vi nam tren bien)
        [TestMethod]
        public void DemSoPhanTuDuongXungQuanh_ViTriGoc_ChiXetLangGiengHopLe()
        {
            XayDungMaTran xuLy = new XayDungMaTran();
            double[,] maTranA = new double[,]
            {
                { 1, -2, 3 },
                { -4, 5, -6 },
                { 7, -8, 9 }
            };

            // (0,0) chi co 3 lang gieng hop le: (0,1)=-2, (1,0)=-4, (1,1)=5 -> 1 so duong
            int dem = xuLy.DemSoPhanTuDuongXungQuanh(maTranA, 0, 0);

            Assert.AreEqual(1, dem);
        }

        // Kiem tra ham tong hop XayDungMaTranB tren toan bo ma tran mau
        [TestMethod]
        public void XayDungMaTranB_MaTran3x3_TraVeDungKichThuocVaGiaTri()
        {
            XayDungMaTran xuLy = new XayDungMaTran();
            double[,] maTranA = new double[,]
            {
                { 1, -2, 3 },
                { -4, 5, -6 },
                { 7, -8, 9 }
            };

            int[,] maTranB = xuLy.XayDungMaTranB(maTranA);

            // Kich thuoc B phai giong het A
            Assert.AreEqual(3, maTranB.GetLength(0));
            Assert.AreEqual(3, maTranB.GetLength(1));

            // Doi chieu lai 2 gia tri da tinh tay o tren
            Assert.AreEqual(4, maTranB[1, 1]);
            Assert.AreEqual(1, maTranB[0, 0]);
        }

        // Truong hop ma tran chi co 1 phan tu -> khong co lang gieng nao ca
        [TestMethod]
        public void DemSoPhanTuDuongXungQuanh_MaTranMotPhanTu_TraVe0()
        {
            XayDungMaTran xuLy = new XayDungMaTran();
            double[,] maTranA = new double[,] { { 5 } };

            int dem = xuLy.DemSoPhanTuDuongXungQuanh(maTranA, 0, 0);

            Assert.AreEqual(0, dem);
        }

        // Kiem tra dieu kien hop le cua kich thuoc ma tran (1 <= gia tri <= 100)
        [TestMethod]
        public void KiemTraKichThuocHopLe_CacTruongHopBienCua()
        {
            XayDungMaTran xuLy = new XayDungMaTran();

            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(0));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(1));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(100));
            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(101));
        }
    }
}