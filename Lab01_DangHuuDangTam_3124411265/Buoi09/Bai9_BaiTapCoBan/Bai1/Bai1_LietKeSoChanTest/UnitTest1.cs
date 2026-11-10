using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai1_LietKeSoChan;
using System.Collections.Generic;

namespace Bai1_LietKeSoChanTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test case theo dung vi du mau trong de bai:
        // Mang nhap vao: 2 3 5 6
        // Ket qua mong muon (duyet tu phai sang trai, lay so chan): 6 2
        [TestMethod]
        public void LayDanhSachSoChan_ViDuTrongDeBai_TraVeDungThuTu()
        {
            // Arrange
            LietKeSoChan xuLy = new LietKeSoChan();
            int[] mang = { 2, 3, 5, 6 };

            // Act
            List<int> ketQua = xuLy.LayDanhSachSoChan(mang);
            string chuoiKetQua = xuLy.ChuyenDanhSachThanhChuoi(ketQua);

            // Assert
            Assert.AreEqual("6 2", chuoiKetQua);
        }

        // Truong hop mang khong co phan tu chan nao
        [TestMethod]
        public void LayDanhSachSoChan_KhongCoSoChan_TraVeDanhSachRong()
        {
            LietKeSoChan xuLy = new LietKeSoChan();
            int[] mang = { 1, 3, 5, 7, 9 };

            List<int> ketQua = xuLy.LayDanhSachSoChan(mang);

            Assert.AreEqual(0, ketQua.Count);
        }

        // Truong hop tat ca phan tu deu la so chan
        [TestMethod]
        public void LayDanhSachSoChan_TatCaDeuChan_TraVeDuThuTuNguoc()
        {
            LietKeSoChan xuLy = new LietKeSoChan();
            int[] mang = { 2, 4, 6, 8 };

            List<int> ketQua = xuLy.LayDanhSachSoChan(mang);

            CollectionAssert.AreEqual(new List<int> { 8, 6, 4, 2 }, ketQua);
        }

        // Truong hop mang co so am, van phai xet dung tinh chat chan/le
        [TestMethod]
        public void LayDanhSachSoChan_CoSoAm_VanNhanDienDungSoChan()
        {
            LietKeSoChan xuLy = new LietKeSoChan();
            int[] mang = { -4, 1, -3, 2 };

            List<int> ketQua = xuLy.LayDanhSachSoChan(mang);

            CollectionAssert.AreEqual(new List<int> { 2, -4 }, ketQua);
        }

        // Kiem tra dieu kien hop le cua so luong phan tu n (0 < n <= 500)
        [TestMethod]
        public void KiemTraSoPhanTuHopLe_CacTruongHopBienCua_n()
        {
            LietKeSoChan xuLy = new LietKeSoChan();

            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(0));    // n = 0 -> khong hop le
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1));     // n = 1 -> hop le
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(500));   // n = 500 -> hop le (bien tren)
            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(501));  // n = 501 -> khong hop le
        }
    }
}