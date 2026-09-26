using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai4_NhapSoNguyen;

namespace Bai4_NhapSoNguyenTest
{
    [TestClass]
    public class UnitTest1
    {
        // ---------- Test cho ham tinh luy thua (LuyThua.TinhLuyThua) ----------

        [TestMethod]
        public void TinhLuyThua_TruongHopBinhThuong_TraVeDung()
        {
            // Truong hop mau trong de bai: 7^3 = 343
            long ketQua = LuyThua.TinhLuyThua(7, 3);
            Assert.AreEqual(343, ketQua);
        }

        [TestMethod]
        public void TinhLuyThua_SoMuBangKhong_TraVeMot()
        {
            // Bat ky so nao mu 0 cung bang 1
            long ketQua = LuyThua.TinhLuyThua(5, 0);
            Assert.AreEqual(1, ketQua);
        }

        [TestMethod]
        public void TinhLuyThua_CoSoAm_TraVeDung()
        {
            // Co so am, so mu le -> ket qua am: (-2)^3 = -8
            long ketQua = LuyThua.TinhLuyThua(-2, 3);
            Assert.AreEqual(-8, ketQua);
        }

        [TestMethod]
        public void TinhLuyThua_SoMuLon_KhongTranSo()
        {
            // Kiem tra dung kieu long moi chua duoc so lon, int se bi tran
            long ketQua = LuyThua.TinhLuyThua(10, 9);
            Assert.AreEqual(1000000000L, ketQua);
        }

        // ---------- Test cho ham kiem tra nhap lieu (Program.KiemTraSoNguyen) ----------

        [TestMethod]
        public void KiemTraSoNguyen_ChuoiHopLe_TraVeTrue()
        {
            // Chuoi "7" la so nguyen hop le -> phai tra ve true va ra dung gia tri 7
            bool hopLe = Program.KiemTraSoNguyen("7", out int ketQua);
            Assert.IsTrue(hopLe);
            Assert.AreEqual(7, ketQua);
        }

        [TestMethod]
        public void KiemTraSoNguyen_ChuoiChu_TraVeFalse()
        {
            // Chuoi chu cai khong phai so nguyen -> phai tra ve false
            bool hopLe = Program.KiemTraSoNguyen("abc", out int ketQua);
            Assert.IsFalse(hopLe);
        }

        [TestMethod]
        public void KiemTraSoNguyen_SoThapPhan_TraVeFalse()
        {
            // "3.5" la so thap phan, khong phai so nguyen -> phai tra ve false
            bool hopLe = Program.KiemTraSoNguyen("3.5", out int ketQua);
            Assert.IsFalse(hopLe);
        }

        [TestMethod]
        public void KiemTraSoNguyen_ChuoiRong_TraVeFalse()
        {
            // Nguoi dung bo trong, nhan Enter luon -> phai tra ve false
            bool hopLe = Program.KiemTraSoNguyen("", out int ketQua);
            Assert.IsFalse(hopLe);
        }
    }
}