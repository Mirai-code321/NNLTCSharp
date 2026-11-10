using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai3_DemDau;

namespace Bai3_DemDauTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test theo dung vi du mau trong de bai:
        // Mang: -2, 5, 0, -3, -4
        // Ket qua mong muon: 3 so am, 1 so khong, 1 so duong
        [TestMethod]
        public void DemDau_ViDuTrongDeBai_TraVeDungSoLuong()
        {
            // Arrange
            DemDau xuLy = new DemDau();
            double[] mang = { -2, 5, 0, -3, -4 };

            // Act
            int soDuong = xuLy.DemSoDuong(mang);
            int soAm = xuLy.DemSoAm(mang);
            int soKhong = xuLy.DemSoKhong(mang);

            // Assert
            Assert.AreEqual(1, soDuong);
            Assert.AreEqual(3, soAm);
            Assert.AreEqual(1, soKhong);
        }

        // Truong hop tat ca deu la so duong
        [TestMethod]
        public void DemDau_TatCaDeuDuong_SoAmVaSoKhongBang0()
        {
            DemDau xuLy = new DemDau();
            double[] mang = { 1.5, 2, 3.7 };

            Assert.AreEqual(3, xuLy.DemSoDuong(mang));
            Assert.AreEqual(0, xuLy.DemSoAm(mang));
            Assert.AreEqual(0, xuLy.DemSoKhong(mang));
        }

        // Truong hop mang chi toan so 0
        [TestMethod]
        public void DemDau_TatCaDeuBang0_ChiSoKhongDuoc_Dem()
        {
            DemDau xuLy = new DemDau();
            double[] mang = { 0, 0, 0 };

            Assert.AreEqual(0, xuLy.DemSoDuong(mang));
            Assert.AreEqual(0, xuLy.DemSoAm(mang));
            Assert.AreEqual(3, xuLy.DemSoKhong(mang));
        }

        // Truong hop co so thuc le (khong phai so nguyen)
        [TestMethod]
        public void DemDau_CoSoThucLe_VanDemDungDau()
        {
            DemDau xuLy = new DemDau();
            double[] mang = { -1.25, 0.0001, -0.5 };

            Assert.AreEqual(1, xuLy.DemSoDuong(mang));
            Assert.AreEqual(2, xuLy.DemSoAm(mang));
            Assert.AreEqual(0, xuLy.DemSoKhong(mang));
        }

        // Kiem tra dieu kien hop le cua so luong phan tu n (0 < n <= 500)
        [TestMethod]
        public void KiemTraSoPhanTuHopLe_CacTruongHopBienCua_n()
        {
            DemDau xuLy = new DemDau();

            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(0));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(1));
            Assert.IsTrue(xuLy.KiemTraSoPhanTuHopLe(500));
            Assert.IsFalse(xuLy.KiemTraSoPhanTuHopLe(501));
        }
    }
}