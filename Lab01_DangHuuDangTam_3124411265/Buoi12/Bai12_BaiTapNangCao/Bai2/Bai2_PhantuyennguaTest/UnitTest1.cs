using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai2_PhanTuYenNgua;
using System.Collections.Generic;

namespace Bai2_PhanTuYenNguaTest
{
    [TestClass]
    public class UnitTest1
    {
        // Vi du kinh dien: ma tran 3x3 tang dan ca theo hang lan cot
        // 1 2 3
        // 4 5 6
        // 7 8 9
        // -> diem yen ngua duy nhat la (2, 0) = 7
        //    (nho nhat trong hang [7,8,9], dong thoi lon nhat trong cot [1,4,7])
        [TestMethod]
        public void TimTatCaDiemYenNgua_ViDuKinhDien_TimDungMotDiem()
        {
            // Arrange
            PhanTuYenNgua xuLy = new PhanTuYenNgua();
            double[,] maTran = new double[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            // Act
            List<(int Hang, int Cot, double GiaTri)> ketQua = xuLy.TimTatCaDiemYenNgua(maTran);

            // Assert
            Assert.AreEqual(1, ketQua.Count);
            Assert.AreEqual((2, 0, 7.0), ketQua[0]);
        }

        // Kiem tra ham LaDiemYenNgua rieng cho vi tri cu the
        [TestMethod]
        public void LaDiemYenNgua_ViTriDungLaYenNgua_TraVeTrue()
        {
            PhanTuYenNgua xuLy = new PhanTuYenNgua();
            double[,] maTran = new double[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Assert.IsTrue(xuLy.LaDiemYenNgua(maTran, 2, 0));
            Assert.IsFalse(xuLy.LaDiemYenNgua(maTran, 0, 0));
        }

        // Truong hop ma tran khong co diem yen ngua nao
        [TestMethod]
        public void TimTatCaDiemYenNgua_KhongCoDiemNao_TraVeDanhSachRong()
        {
            PhanTuYenNgua xuLy = new PhanTuYenNgua();
            double[,] maTran = new double[,]
            {
                { 3, 1, 2 },
                { 2, 4, 5 }
            };

            List<(int Hang, int Cot, double GiaTri)> ketQua = xuLy.TimTatCaDiemYenNgua(maTran);

            Assert.AreEqual(0, ketQua.Count);
        }

        // Truong hop ma tran chi co 1 phan tu -> luon la diem yen ngua
        [TestMethod]
        public void TimTatCaDiemYenNgua_MaTranMotPhanTu_LuonLaYenNgua()
        {
            PhanTuYenNgua xuLy = new PhanTuYenNgua();
            double[,] maTran = new double[,] { { 5 } };

            List<(int Hang, int Cot, double GiaTri)> ketQua = xuLy.TimTatCaDiemYenNgua(maTran);

            Assert.AreEqual(1, ketQua.Count);
            Assert.AreEqual((0, 0, 5.0), ketQua[0]);
        }

        // Kiem tra dieu kien hop le cua kich thuoc ma tran (1 <= gia tri <= 100)
        [TestMethod]
        public void KiemTraKichThuocHopLe_CacTruongHopBienCua()
        {
            PhanTuYenNgua xuLy = new PhanTuYenNgua();

            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(0));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(1));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(100));
            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(101));
        }
    }
}