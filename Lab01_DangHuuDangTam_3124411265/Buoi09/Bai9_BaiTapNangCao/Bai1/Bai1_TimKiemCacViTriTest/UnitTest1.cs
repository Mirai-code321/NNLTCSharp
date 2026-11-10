using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai1_TimKiemCacViTri;
using System.Collections.Generic;

namespace Bai1_TimKiemCacViTriTest
{
    [TestClass]
    public class UnitTest1
    {
        // Truong hop x xuat hien nhieu lan trong mang
        [TestMethod]
        public void TimTatCaViTri_XXuatHienNhieuLan_TraVeDungCacViTri()
        {
            // Arrange
            TimKiemCacViTri xuLy = new TimKiemCacViTri();
            int[] mang = { 3, 7, 3, 2, 3, 9 };
            int x = 3;

            // Act
            List<int> ketQua = xuLy.TimTatCaViTri(mang, x);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 0, 2, 4 }, ketQua);
        }

        // Truong hop x khong ton tai trong mang
        [TestMethod]
        public void TimTatCaViTri_XKhongTonTai_TraVeDanhSachRong()
        {
            TimKiemCacViTri xuLy = new TimKiemCacViTri();
            int[] mang = { 1, 2, 4, 5 };
            int x = 100;

            List<int> ketQua = xuLy.TimTatCaViTri(mang, x);

            Assert.AreEqual(0, ketQua.Count);
        }

        // Truong hop x chi xuat hien dung 1 lan
        [TestMethod]
        public void TimTatCaViTri_XXuatHienMotLan_TraVeDanhSachMotPhanTu()
        {
            TimKiemCacViTri xuLy = new TimKiemCacViTri();
            int[] mang = { 1, 2, 3, 4 };
            int x = 3;

            List<int> ketQua = xuLy.TimTatCaViTri(mang, x);

            CollectionAssert.AreEqual(new List<int> { 2 }, ketQua);
        }

        // Kiem tra dieu kien hop le cua so luong phan tu n (0 < n <= 500)
        [TestMethod]
        public void KiemTraSoPhanTuHopLe_CacTruongHopBienCua_n()
        {
            TimKiemCacViTri xuLy = new TimKiemCacViTri();

            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(0));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(500));
            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(501));
        }
    }
}