using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai4_DongTangDan;
using System.Collections.Generic;

namespace Bai4_DongTangDanTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test theo dung vi du mau trong de bai:
        // Ma tran 3x3: [1 7 9] [5 3 15] [3 4 8]
        // Dong 0 (1<7<9) va dong 2 (3<4<8) la tang dan; dong 1 (5>=3) thi khong
        [TestMethod]
        public void LayDanhSachDongTangDan_ViDuTrongDeBai_TraVeDungCacDong()
        {
            // Arrange
            DongTangDan xuLy = new DongTangDan();
            int[,] maTran = new int[,]
            {
                { 1, 7, 9 },
                { 5, 3, 15 },
                { 3, 4, 8 }
            };

            // Act
            List<int> ketQua = xuLy.LayDanhSachDongTangDan(maTran);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 0, 2 }, ketQua);
        }

        // Kiem tra rieng ham LaDongTangDan cho tung dong
        [TestMethod]
        public void LaDongTangDan_KiemTraTungDongRieng()
        {
            DongTangDan xuLy = new DongTangDan();
            int[,] maTran = new int[,]
            {
                { 1, 7, 9 },
                { 5, 3, 15 },
                { 3, 4, 8 }
            };

            Assert.IsTrue(xuLy.LaDongTangDan(maTran, 0));
            Assert.IsFalse(xuLy.LaDongTangDan(maTran, 1));
            Assert.IsTrue(xuLy.LaDongTangDan(maTran, 2));
        }

        // Truong hop dong co 2 phan tu bang nhau -> khong duoc tinh la tang dan (tang NGHIEM NGAT)
        [TestMethod]
        public void LaDongTangDan_CoHaiPhanTuBangNhau_TraVeFalse()
        {
            DongTangDan xuLy = new DongTangDan();
            int[,] maTran = new int[,] { { 2, 2, 5 } };

            Assert.IsFalse(xuLy.LaDongTangDan(maTran, 0));
        }

        // Truong hop khong co dong nao tang dan
        [TestMethod]
        public void LayDanhSachDongTangDan_KhongCoDongNaoTangDan_TraVeDanhSachRong()
        {
            DongTangDan xuLy = new DongTangDan();
            int[,] maTran = new int[,]
            {
                { 5, 4, 3 },
                { 9, 1, 2 }
            };

            List<int> ketQua = xuLy.LayDanhSachDongTangDan(maTran);

            Assert.AreEqual(0, ketQua.Count);
        }

        // Kiem tra dieu kien hop le cua kich thuoc ma tran (1 <= gia tri <= 100)
        [TestMethod]
        public void KiemTraKichThuocHopLe_CacTruongHopBienCua()
        {
            DongTangDan xuLy = new DongTangDan();

            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(0));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(1));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(100));
            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(101));
        }
    }
}