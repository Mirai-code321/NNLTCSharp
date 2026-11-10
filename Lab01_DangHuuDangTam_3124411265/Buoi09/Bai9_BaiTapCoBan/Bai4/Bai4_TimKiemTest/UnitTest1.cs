using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai4_TimKiem;

namespace Bai4_TimKiemTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test theo dung vi du mau trong de bai:
        // Mang: -2.9, 5, -4, -2.9, -5 ; x = -2.9
        // x xuat hien 2 lan, vi tri dau tien = 0, vi tri cuoi cung = 3
        [TestMethod]
        public void TimKiem_ViDuTrongDeBai_TraVeDungViTriVaSoLan()
        {
            // Arrange
            TimKiem xuLy = new TimKiem();
            double[] mang = { -2.9, 5, -4, -2.9, -5 };
            double x = -2.9;

            // Act
            int soLan = xuLy.DemSoLanXuatHien(mang, x);
            int viTriDauTien = xuLy.TimViTriDauTien(mang, x);
            int viTriCuoiCung = xuLy.TimViTriCuoiCung(mang, x);

            // Assert
            Assert.AreEqual(2, soLan);
            Assert.AreEqual(0, viTriDauTien);
            Assert.AreEqual(3, viTriCuoiCung);
        }

        // Truong hop x khong ton tai trong mang
        [TestMethod]
        public void TimKiem_XKhongTonTai_TraVeKhongTimThayVaSoLanBang0()
        {
            TimKiem xuLy = new TimKiem();
            double[] mang = { 1, 2, 3, 4 };
            double x = 100;

            Assert.AreEqual(0, xuLy.DemSoLanXuatHien(mang, x));
            Assert.AreEqual(TimKiem.KHONG_TIM_THAY, xuLy.TimViTriDauTien(mang, x));
            Assert.AreEqual(TimKiem.KHONG_TIM_THAY, xuLy.TimViTriCuoiCung(mang, x));
        }

        // Truong hop x chi xuat hien dung 1 lan
        // -> vi tri dau tien va cuoi cung phai trung nhau
        [TestMethod]
        public void TimKiem_XXuatHienMotLan_ViTriDauVaCuoiTrungNhau()
        {
            TimKiem xuLy = new TimKiem();
            double[] mang = { 1, 2, 3, 4 };
            double x = 3;

            Assert.AreEqual(1, xuLy.DemSoLanXuatHien(mang, x));
            Assert.AreEqual(2, xuLy.TimViTriDauTien(mang, x));
            Assert.AreEqual(2, xuLy.TimViTriCuoiCung(mang, x));
        }

        // Kiem tra dieu kien hop le cua so luong phan tu n (0 < n <= 500)
        [TestMethod]
        public void KiemTraSoPhanTuHopLe_CacTruongHopBienCua_n()
        {
            TimKiem xuLy = new TimKiem();

            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(0));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(500));
            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(501));
        }
    }
}