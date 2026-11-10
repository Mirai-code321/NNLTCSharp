using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai9_TimMaxMin;

namespace Bai9_TimMaxMinTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TruongHopBinhThuong_TimDungMaxMin()
        {
            TimMaxMin doiTuong = new TimMaxMin();

            doiTuong.TimGiaTriLonNhoNhat(10.5, 3.2, 7.8, out double gtLon, out double gtNho);

            Assert.AreEqual(10.5, gtLon);
            Assert.AreEqual(3.2, gtNho);
        }

        [TestMethod]
        public void HaiSoAmMotSoDuong_TimDungMaxMin()
        {
            TimMaxMin doiTuong = new TimMaxMin();

            doiTuong.TimGiaTriLonNhoNhat(-2.5, 6.6, -9.1, out double gtLon, out double gtNho);

            Assert.AreEqual(6.6, gtLon);
            Assert.AreEqual(-9.1, gtNho);
        }

        [TestMethod]
        public void BaSoAm_TimDungMaxMin()
        {
            TimMaxMin doiTuong = new TimMaxMin();

            doiTuong.TimGiaTriLonNhoNhat(-10.0, -3.5, -7.2, out double gtLon, out double gtNho);

            Assert.AreEqual(-3.5, gtLon);
            Assert.AreEqual(-10.0, gtNho);
        }

        [TestMethod]
        public void BaSoBangNhau_MaxMinBangNhau()
        {
            // Truong hop bien: ca 3 so bang nhau thi max = min = chinh so do
            TimMaxMin doiTuong = new TimMaxMin();

            doiTuong.TimGiaTriLonNhoNhat(4.0, 4.0, 4.0, out double gtLon, out double gtNho);

            Assert.AreEqual(4.0, gtLon);
            Assert.AreEqual(4.0, gtNho);
        }

        [TestMethod]
        public void CoSoBangKhong_TimDungMaxMin()
        {
            // Truong hop bien: mot trong ba so bang 0
            TimMaxMin doiTuong = new TimMaxMin();

            doiTuong.TimGiaTriLonNhoNhat(0.0, -5.5, 8.1, out double gtLon, out double gtNho);

            Assert.AreEqual(8.1, gtLon);
            Assert.AreEqual(-5.5, gtNho);
        }

        [TestMethod]
        public void HaiSoBangNhauLaCucTri_TimDungMaxMin()
        {
            // Truong hop bien: hai trong ba so bang nhau va la gia tri lon nhat
            TimMaxMin doiTuong = new TimMaxMin();

            doiTuong.TimGiaTriLonNhoNhat(9.0, 9.0, 2.0, out double gtLon, out double gtNho);

            Assert.AreEqual(9.0, gtLon);
            Assert.AreEqual(2.0, gtNho);
        }

        [TestMethod]
        public void ThamSoOut_KhongCanKhoiTaoTruoc_VanNhanDungGiaTri()
        {
            // Test minh chung dac diem rieng cua out: bien gtLon, gtNho khai bao
            // ma KHONG gan gia tri ban dau (khac voi ref bat buoc phai co gia tri truoc),
            // sau khi goi ham xong van nhan dung gia tri vi ham bat buoc phai gan out truoc khi return
            TimMaxMin doiTuong = new TimMaxMin();
            double gtLon;
            double gtNho;

            doiTuong.TimGiaTriLonNhoNhat(1.5, 12.25, 6.75, out gtLon, out gtNho);

            Assert.AreEqual(12.25, gtLon);
            Assert.AreEqual(1.5, gtNho);
        }
    }
}