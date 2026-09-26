using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai8_HoanVi;

namespace Bai8_HoanViTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TruongHopBinhThuong_HoanViDung()
        {
            HoanVi doiTuong = new HoanVi();
            double a = 3.5;
            double b = 7.2;

            doiTuong.ThucHienHoanVi(ref a, ref b);

            Assert.AreEqual(7.2, a);
            Assert.AreEqual(3.5, b);
        }

        [TestMethod]
        public void HaiSoAm_HoanViDung()
        {
            HoanVi doiTuong = new HoanVi();
            double a = -5.5;
            double b = -1.1;

            doiTuong.ThucHienHoanVi(ref a, ref b);

            Assert.AreEqual(-1.1, a);
            Assert.AreEqual(-5.5, b);
        }

        [TestMethod]
        public void MotSoAmMotSoDuong_HoanViDung()
        {
            HoanVi doiTuong = new HoanVi();
            double a = -4.2;
            double b = 8.8;

            doiTuong.ThucHienHoanVi(ref a, ref b);

            Assert.AreEqual(8.8, a);
            Assert.AreEqual(-4.2, b);
        }

        [TestMethod]
        public void HaiSoBangNhau_HoanViVanGiuNguyenGiaTri()
        {
            // Truong hop bien: 2 so bang nhau, hoan vi xong gia tri khong doi
            HoanVi doiTuong = new HoanVi();
            double a = 5.0;
            double b = 5.0;

            doiTuong.ThucHienHoanVi(ref a, ref b);

            Assert.AreEqual(5.0, a);
            Assert.AreEqual(5.0, b);
        }

        [TestMethod]
        public void SoBangKhong_HoanViDung()
        {
            // Truong hop bien: mot trong hai so la 0
            HoanVi doiTuong = new HoanVi();
            double a = 0.0;
            double b = 9.9;

            doiTuong.ThucHienHoanVi(ref a, ref b);

            Assert.AreEqual(9.9, a);
            Assert.AreEqual(0.0, b);
        }

        [TestMethod]
        public void HoanViHaiLan_TraVeGiaTriBanDau()
        {
            // Hoan vi 2 lan lien tiep phai tra ve dung gia tri ban dau
            HoanVi doiTuong = new HoanVi();
            double a = 12.34;
            double b = 56.78;
            double aGoc = a;
            double bGoc = b;

            doiTuong.ThucHienHoanVi(ref a, ref b);
            doiTuong.ThucHienHoanVi(ref a, ref b);

            Assert.AreEqual(aGoc, a);
            Assert.AreEqual(bGoc, b);
        }

        [TestMethod]
        public void ThamChieuRef_ThayDoiBienGocBenNgoai_KhacVoiThamTri()
        {
            // Test minh chung ro su khac biet giua tham chieu (ref) va tham tri
            double a = 1.1;
            double b = 2.2;
            double aGocBanDau = a;
            double bGocBanDau = b;

            HoanViThamTri(a, b); // truyen theo tham tri -> khong anh huong ben ngoai
            Assert.AreEqual(aGocBanDau, a);
            Assert.AreEqual(bGocBanDau, b);

            HoanVi doiTuong = new HoanVi();
            doiTuong.ThucHienHoanVi(ref a, ref b); // truyen theo tham chieu -> co anh huong ben ngoai
            Assert.AreEqual(bGocBanDau, a);
            Assert.AreEqual(aGocBanDau, b);
        }

        // Ham phu tro dung tham tri (khong ref) de doi chieu voi ThucHienHoanVi dung ref
        private void HoanViThamTri(double x, double y)
        {
            double tam = x;
            x = y;
            y = tam;
        }
    }
}