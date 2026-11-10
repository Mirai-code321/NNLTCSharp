using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai2_TimKiemGiaTriChan;

namespace Bai2_TimKiemGiaTriChanTest
{
    [TestClass]
    public class UnitTest1
    {
        // Truong hop binh thuong: co nhieu so chan nam ram trong mang
        [TestMethod]
        public void TimChiSo_MangCoNhieuSoChan_TraVeDungViTriDauVaCuoi()
        {
            // Arrange
            TimKiemGiaTriChan xuLy = new TimKiemGiaTriChan();
            int[] mang = { -2, 5, 8, 9, 16 };

            // Act
            int dauTien = xuLy.TimChiSoChanDauTien(mang);
            int cuoiCung = xuLy.TimChiSoChanCuoiCung(mang);

            // Assert
            // -2 la so chan dau tien gap khi duyet tu trai sang phai (vi tri 0)
            Assert.AreEqual(0, dauTien);
            // 16 la so chan cuoi cung gap khi duyet tu phai sang trai (vi tri 4)
            Assert.AreEqual(4, cuoiCung);
        }

        // Truong hop mang khong co so chan nao
        [TestMethod]
        public void TimChiSo_MangKhongCoSoChan_TraVeKhongTimThay()
        {
            TimKiemGiaTriChan xuLy = new TimKiemGiaTriChan();
            int[] mang = { 1, 3, 5, 7, 9 };

            int dauTien = xuLy.TimChiSoChanDauTien(mang);
            int cuoiCung = xuLy.TimChiSoChanCuoiCung(mang);

            Assert.AreEqual(TimKiemGiaTriChan.KHONG_TIM_THAY, dauTien);
            Assert.AreEqual(TimKiemGiaTriChan.KHONG_TIM_THAY, cuoiCung);
        }

        // Truong hop mang chi co dung mot so chan duy nhat
        // -> dau tien va cuoi cung phai trung nhau
        [TestMethod]
        public void TimChiSo_MangChiCoMotSoChan_DauTienVaCuoiCungTrungNhau()
        {
            TimKiemGiaTriChan xuLy = new TimKiemGiaTriChan();
            int[] mang = { 1, 3, 4, 5, 7 };

            int dauTien = xuLy.TimChiSoChanDauTien(mang);
            int cuoiCung = xuLy.TimChiSoChanCuoiCung(mang);

            Assert.AreEqual(2, dauTien);
            Assert.AreEqual(2, cuoiCung);
        }

        // Kiem tra dieu kien hop le cua so luong phan tu n (0 < n <= 500)
        [TestMethod]
        public void KiemTraSoPhanTuHopLe_CacTruongHopBienCua_n()
        {
            TimKiemGiaTriChan xuLy = new TimKiemGiaTriChan();

            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(0));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(500));
            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(501));
        }
    }
}