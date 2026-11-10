using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai6_TimGiaTriLonNhat;

namespace Bai6_TimGiaTriLonNhatTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TimGiaTriLonNhat_ALonNhat_TraVeA()
        {
            BaSoNguyen baSo = new BaSoNguyen();
            int ketQua = baSo.TimGiaTriLonNhat(10, 3, 5);
            Assert.AreEqual(10, ketQua);
        }

        [TestMethod]
        public void TimGiaTriLonNhat_BLonNhat_TraVeB()
        {
            BaSoNguyen baSo = new BaSoNguyen();
            int ketQua = baSo.TimGiaTriLonNhat(2, 9, 5);
            Assert.AreEqual(9, ketQua);
        }

        [TestMethod]
        public void TimGiaTriLonNhat_CLonNhat_TraVeC()
        {
            BaSoNguyen baSo = new BaSoNguyen();
            int ketQua = baSo.TimGiaTriLonNhat(2, 3, 7);
            Assert.AreEqual(7, ketQua);
        }

        [TestMethod]
        public void TimGiaTriLonNhat_TatCaBangNhau_TraVeGiaTriDo()
        {
            BaSoNguyen baSo = new BaSoNguyen();
            int ketQua = baSo.TimGiaTriLonNhat(5, 5, 5);
            Assert.AreEqual(5, ketQua);
        }

        [TestMethod]
        public void TimGiaTriLonNhat_CoSoAm_TraVeDung()
        {
            // Ca 3 so am, so lon nhat la so "gan 0" nhat
            BaSoNguyen baSo = new BaSoNguyen();
            int ketQua = baSo.TimGiaTriLonNhat(-10, -3, -7);
            Assert.AreEqual(-3, ketQua);
        }

        [TestMethod]
        public void TimGiaTriLonNhat_KhongLamThayDoiThamSoGoc()
        {
            // Kiem tra dac diem cua tham tri: goi ham xong,
            // cac bien a, b, c ben ngoai KHONG bi thay doi gia tri
            int a = 10, b = 3, c = 5;
            BaSoNguyen baSo = new BaSoNguyen();
            baSo.TimGiaTriLonNhat(a, b, c);

            Assert.AreEqual(10, a);
            Assert.AreEqual(3, b);
            Assert.AreEqual(5, c);
        }
    }
}