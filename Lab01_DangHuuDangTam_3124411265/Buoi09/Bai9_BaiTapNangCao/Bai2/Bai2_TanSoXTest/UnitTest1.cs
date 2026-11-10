using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai2_TanSoX;

namespace Bai2_TanSoXTest
{
    [TestClass]
    public class UnitTest1
    {
        // Truong hop x xuat hien nhieu lan
        [TestMethod]
        public void DemTanSo_XXuatHienNhieuLan_TraVeDungSoLuong()
        {
            // Arrange
            TanSoX xuLy = new TanSoX();
            int[] mang = { 5, 2, 5, 8, 5, 1 };
            int x = 5;

            // Act
            int tanSo = xuLy.DemTanSo(mang, x);

            // Assert
            Assert.AreEqual(3, tanSo);
        }

        // Truong hop x khong ton tai trong day so
        [TestMethod]
        public void DemTanSo_XKhongTonTai_TraVe0()
        {
            TanSoX xuLy = new TanSoX();
            int[] mang = { 1, 2, 3, 4 };
            int x = 100;

            int tanSo = xuLy.DemTanSo(mang, x);

            Assert.AreEqual(0, tanSo);
        }

        // Truong hop x xuat hien dung 1 lan
        [TestMethod]
        public void DemTanSo_XXuatHienMotLan_TraVe1()
        {
            TanSoX xuLy = new TanSoX();
            int[] mang = { 1, 2, 3, 4 };
            int x = 3;

            int tanSo = xuLy.DemTanSo(mang, x);

            Assert.AreEqual(1, tanSo);
        }

        // Kiem tra dieu kien hop le cua so luong phan tu n (0 < n <= 1000)
        [TestMethod]
        public void KiemTraSoPhanTuHopLe_CacTruongHopBienCua_n()
        {
            TanSoX xuLy = new TanSoX();

            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(0));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1000));
            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(1001));
        }
    }
}