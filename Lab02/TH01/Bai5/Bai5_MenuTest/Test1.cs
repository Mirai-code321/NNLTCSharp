using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai5_Menu;

namespace Bai5_MenuTest
{
    [TestClass]
    public class UnitTest1
    {
        // ---------- Test cho ham TinhLuyThua ----------

        [TestMethod]
        public void TinhLuyThua_TruongHopBinhThuong_TraVeDung()
        {
            // 2^10 = 1024
            double ketQua = MathTools.TinhLuyThua(2, 10);

            // Dung AreEqual voi sai so 0.0001 vi day la kieu double,
            // phep tinh dau phay dong co the lech rat nho
            Assert.AreEqual(1024, ketQua, 0.0001);
        }

        [TestMethod]
        public void TinhLuyThua_SoMuAm_TraVeDung()
        {
            // 2^-1 = 1/2 = 0.5
            double ketQua = MathTools.TinhLuyThua(2, -1);
            Assert.AreEqual(0.5, ketQua, 0.0001);
        }

        [TestMethod]
        public void TinhLuyThua_SoMuLaPhanSo_TraVeDung()
        {
            // 4^0.5 chinh la can bac 2 cua 4 = 2
            double ketQua = MathTools.TinhLuyThua(4, 0.5);
            Assert.AreEqual(2, ketQua, 0.0001);
        }

        // ---------- Test cho ham TinhCanBac2 ----------

        [TestMethod]
        public void TinhCanBac2_SoDuong_TraVeDung()
        {
            double? ketQua = MathTools.TinhCanBac2(16);

            // Kiem tra khong phai null truoc, roi moi kiem tra gia tri ben trong
            Assert.IsNotNull(ketQua);
            Assert.AreEqual(4, ketQua!.Value, 0.0001);
        }

        [TestMethod]
        public void TinhCanBac2_SoAm_TraVeNull()
        {
            // So am -> ham phai tra ve null, khong duoc nem loi hay tra NaN
            double? ketQua = MathTools.TinhCanBac2(-9);
            Assert.IsNull(ketQua);
        }

        [TestMethod]
        public void TinhCanBac2_SoKhong_TraVeKhong()
        {
            // Truong hop bien: can bac 2 cua 0 la 0, khong phai loi
            double? ketQua = MathTools.TinhCanBac2(0);
            Assert.IsNotNull(ketQua);
            Assert.AreEqual(0, ketQua!.Value, 0.0001);
        }
    }
}