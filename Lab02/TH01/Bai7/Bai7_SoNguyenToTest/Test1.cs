using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai7_SoNguyenTo;

namespace Bai7_SoNguyenToTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void KiemTraSoNguyenTo_SoNguyenToNhoNhat_TraVeTrue()
        {
            // 2 la so nguyen to nho nhat
            SoNguyenTo kiemTra = new SoNguyenTo();
            bool ketQua = kiemTra.KiemTraSoNguyenTo(2);
            Assert.IsTrue(ketQua);
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_SoNguyenToLe_TraVeTrue()
        {
            SoNguyenTo kiemTra = new SoNguyenTo();
            Assert.IsTrue(kiemTra.KiemTraSoNguyenTo(7));
            Assert.IsTrue(kiemTra.KiemTraSoNguyenTo(13));
            Assert.IsTrue(kiemTra.KiemTraSoNguyenTo(17));
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_SoChan_TraVeFalse()
        {
            // So chan lon hon 2 khong bao gio la so nguyen to
            SoNguyenTo kiemTra = new SoNguyenTo();
            bool ketQua = kiemTra.KiemTraSoNguyenTo(8);
            Assert.IsFalse(ketQua);
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_HopSoLe_TraVeFalse()
        {
            // 9 = 3 x 3, la hop so du la so le
            SoNguyenTo kiemTra = new SoNguyenTo();
            bool ketQua = kiemTra.KiemTraSoNguyenTo(9);
            Assert.IsFalse(ketQua);
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_BangMot_TraVeFalse()
        {
            // Theo dinh nghia, 1 khong phai so nguyen to
            SoNguyenTo kiemTra = new SoNguyenTo();
            bool ketQua = kiemTra.KiemTraSoNguyenTo(1);
            Assert.IsFalse(ketQua);
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_BangKhong_TraVeFalse()
        {
            SoNguyenTo kiemTra = new SoNguyenTo();
            bool ketQua = kiemTra.KiemTraSoNguyenTo(0);
            Assert.IsFalse(ketQua);
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_SoAm_TraVeFalse()
        {
            SoNguyenTo kiemTra = new SoNguyenTo();
            bool ketQua = kiemTra.KiemTraSoNguyenTo(-7);
            Assert.IsFalse(ketQua);
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_SoNguyenToLon_TraVeTrue()
        {
            // 97 la so nguyen to, dung de test gioi han vong lap can(n)
            SoNguyenTo kiemTra = new SoNguyenTo();
            bool ketQua = kiemTra.KiemTraSoNguyenTo(97);
            Assert.IsTrue(ketQua);
        }
    }
}