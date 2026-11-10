using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai3_TanSo;
using System.Collections.Generic;

namespace Bai3_TanSoTest
{
    [TestClass]
    public class UnitTest1
    {
        // Truong hop co nhieu gia tri trung nhau
        [TestMethod]
        public void TinhTanSo_MangCoTrungLap_TraVeDungTanSoTheoThuTuXuatHienDauTien()
        {
            // Arrange
            TanSo xuLy = new TanSo();
            int[] mang = { 5, 2, 5, 8, 2, 5 };

            // Act
            var ketQua = xuLy.TinhTanSo(mang);

            // Assert
            // Thu tu xuat hien lan dau: 5 (vi tri 0), 2 (vi tri 1), 8 (vi tri 3)
            var kyVong = new List<(int, int)> { (5, 3), (2, 2), (8, 1) };
            CollectionAssert.AreEqual(kyVong, ketQua);
        }

        // Truong hop tat ca phan tu deu khac nhau -> tan so deu la 1
        [TestMethod]
        public void TinhTanSo_TatCaKhacNhau_MoiGiaTriTanSoBang1()
        {
            TanSo xuLy = new TanSo();
            int[] mang = { 1, 2, 3, 4 };

            var ketQua = xuLy.TinhTanSo(mang);

            var kyVong = new List<(int, int)> { (1, 1), (2, 1), (3, 1), (4, 1) };
            CollectionAssert.AreEqual(kyVong, ketQua);
        }

        // Truong hop tat ca phan tu deu giong nhau
        [TestMethod]
        public void TinhTanSo_TatCaGiongNhau_TraVeMotGiaTriDuyNhat()
        {
            TanSo xuLy = new TanSo();
            int[] mang = { 7, 7, 7, 7 };

            var ketQua = xuLy.TinhTanSo(mang);

            var kyVong = new List<(int, int)> { (7, 4) };
            CollectionAssert.AreEqual(kyVong, ketQua);
        }

        // Kiem tra dieu kien hop le cua so luong phan tu n (0 < n <= 1000)
        [TestMethod]
        public void KiemTraSoPhanTuHopLe_CacTruongHopBienCua_n()
        {
            TanSo xuLy = new TanSo();

            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(0));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1000));
            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(1001));
        }
    }
}