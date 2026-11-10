using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai4_DayNguyenTo;
using System.Collections.Generic;

namespace Bai4_DayNguyenToTest
{
    [TestClass]
    public class UnitTest1
    {
        // Kiem tra ham LaSoNguyenTo voi cac truong hop tieu bieu
        [TestMethod]
        public void LaSoNguyenTo_CacTruongHopTieuBieu_TraVeDungKetQua()
        {
            DayNguyenTo xuLy = new DayNguyenTo();

            Assert.IsFalse(xuLy.LaSoNguyenTo(-5));  // so am -> khong phai nguyen to
            Assert.IsFalse(xuLy.LaSoNguyenTo(0));   // 0 -> khong phai nguyen to
            Assert.IsFalse(xuLy.LaSoNguyenTo(1));   // 1 -> khong phai nguyen to
            Assert.IsTrue(xuLy.LaSoNguyenTo(2));    // 2 -> so nguyen to duy nhat la so chan
            Assert.IsTrue(xuLy.LaSoNguyenTo(13));   // 13 -> nguyen to
            Assert.IsFalse(xuLy.LaSoNguyenTo(15));  // 15 = 3 x 5 -> khong phai nguyen to
            Assert.IsTrue(xuLy.LaSoNguyenTo(97));   // 97 -> nguyen to
        }

        // Truong hop mang co ca so nguyen to va khong nguyen to
        [TestMethod]
        public void LayDanhSachSoNguyenTo_MangHonHop_TraVeDungDanhSach()
        {
            // Arrange
            DayNguyenTo xuLy = new DayNguyenTo();
            int[] mang = { 4, 7, 9, 11, 15, 2 };

            // Act
            List<int> ketQua = xuLy.LayDanhSachSoNguyenTo(mang);

            // Assert
            CollectionAssert.AreEqual(new List<int> { 7, 11, 2 }, ketQua);
        }

        // Truong hop mang khong co so nguyen to nao
        [TestMethod]
        public void LayDanhSachSoNguyenTo_KhongCoSoNguyenTo_TraVeDanhSachRong()
        {
            DayNguyenTo xuLy = new DayNguyenTo();
            int[] mang = { 4, 6, 8, 9, 10 };

            List<int> ketQua = xuLy.LayDanhSachSoNguyenTo(mang);

            Assert.AreEqual(0, ketQua.Count);
        }

        // Kiem tra tinh tong va trung binh cong tren danh sach so nguyen to
        [TestMethod]
        public void TinhTongVaTrungBinh_DanhSachCoDuLieu_TraVeDungKetQua()
        {
            DayNguyenTo xuLy = new DayNguyenTo();
            List<int> danhSachNguyenTo = new List<int> { 2, 3, 5 };

            int tong = xuLy.TinhTong(danhSachNguyenTo);
            double trungBinh = xuLy.TinhTrungBinh(danhSachNguyenTo);

            Assert.AreEqual(10, tong);
            Assert.AreEqual(10.0 / 3, trungBinh, 0.0001);
        }

        // Kiem tra dieu kien hop le cua so luong phan tu n (0 < n <= 500)
        [TestMethod]
        public void KiemTraSoPhanTuHopLe_CacTruongHopBienCua_n()
        {
            DayNguyenTo xuLy = new DayNguyenTo();

            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(0));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(500));
            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(501));
        }
    }
}