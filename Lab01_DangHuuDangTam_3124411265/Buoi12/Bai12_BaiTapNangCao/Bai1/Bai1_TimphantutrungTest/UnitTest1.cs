using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai1_TimPhanTuTrung;
using System.Collections.Generic;

namespace Bai1_TimPhanTuTrungTest
{
    [TestClass]
    public class UnitTest1
    {
        // Ma tran 3x3, phan tu giua (1,1) nho hon ca 8 phan tu xung quanh -> la phan tu trung
        [TestMethod]
        public void LaPhanTuTrung_PhanTuGiuaNhoNhat_TraVeTrue()
        {
            // Arrange
            TimPhanTuTrung xuLy = new TimPhanTuTrung();
            double[,] maTran = new double[,]
            {
                { 5, 5, 5 },
                { 5, 1, 5 },
                { 5, 5, 5 }
            };

            // Act
            bool ketQua = xuLy.LaPhanTuTrung(maTran, 1, 1);

            // Assert
            Assert.IsTrue(ketQua);
        }

        // Phan tu tren bien khong duoc xet la phan tu trung, du gia tri nho nhat
        [TestMethod]
        public void LaPhanTuTrung_PhanTuTrenBien_LuonTraVeFalse()
        {
            TimPhanTuTrung xuLy = new TimPhanTuTrung();
            double[,] maTran = new double[,]
            {
                { 0, 5, 5 },
                { 5, 9, 5 },
                { 5, 5, 5 }
            };

            Assert.IsFalse(xuLy.LaPhanTuTrung(maTran, 0, 0)); // goc tren trai -> bien
        }

        // Phan tu giua nhung co it nhat 1 lang gieng nho hon hoac bang -> khong phai trung
        [TestMethod]
        public void LaPhanTuTrung_CoLangGiengNhoHonHoacBang_TraVeFalse()
        {
            TimPhanTuTrung xuLy = new TimPhanTuTrung();
            double[,] maTran = new double[,]
            {
                { 5, 5, 5 },
                { 5, 3, 2 }, // 2 < 3 -> (1,1) khong phai trung
                { 5, 5, 5 }
            };

            Assert.IsFalse(xuLy.LaPhanTuTrung(maTran, 1, 1));
        }

        // Kiem tra ham tong hop tren ma tran 4x4 co dung 1 phan tu trung
        [TestMethod]
        public void TimTatCaPhanTuTrung_MaTran4x4_TraVeDungDanhSach()
        {
            TimPhanTuTrung xuLy = new TimPhanTuTrung();
            double[,] maTran = new double[,]
            {
                { 9, 9, 9, 9 },
                { 9, 1, 9, 9 },
                { 9, 9, 9, 9 },
                { 9, 9, 9, 9 }
            };

            List<(int Hang, int Cot, double GiaTri)> ketQua = xuLy.TimTatCaPhanTuTrung(maTran);

            Assert.AreEqual(1, ketQua.Count);
            Assert.AreEqual((1, 1, 1.0), ketQua[0]);
        }

        // Truong hop khong co phan tu trung nao
        [TestMethod]
        public void TimTatCaPhanTuTrung_KhongCoPhanTuTrung_TraVeDanhSachRong()
        {
            TimPhanTuTrung xuLy = new TimPhanTuTrung();
            double[,] maTran = new double[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            List<(int Hang, int Cot, double GiaTri)> ketQua = xuLy.TimTatCaPhanTuTrung(maTran);

            Assert.AreEqual(0, ketQua.Count);
        }

        // Kiem tra dieu kien hop le cua kich thuoc ma tran (1 <= gia tri <= 100)
        [TestMethod]
        public void KiemTraKichThuocHopLe_CacTruongHopBienCua()
        {
            TimPhanTuTrung xuLy = new TimPhanTuTrung();

            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(0));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(1));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(100));
            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(101));
        }
    }
}