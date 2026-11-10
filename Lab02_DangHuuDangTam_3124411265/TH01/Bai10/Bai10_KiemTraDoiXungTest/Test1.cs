using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai10_KiemTraDoiXung;

namespace Bai10_KiemTraDoiXungTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void ChuoiDoiXung_TraVeTrue()
        {
            KiemTraChuoi doiTuong = new KiemTraChuoi();

            bool ketQua = doiTuong.KiemTraDoiXung("level");

            Assert.IsTrue(ketQua);
        }

        [TestMethod]
        public void ChuoiKhongDoiXung_TraVeFalse()
        {
            KiemTraChuoi doiTuong = new KiemTraChuoi();

            bool ketQua = doiTuong.KiemTraDoiXung("hello");

            Assert.IsFalse(ketQua);
        }

        [TestMethod]
        public void ChuoiRong_TraVeTrue()
        {
            // Truong hop bien: chuoi rong dao nguoc van la chinh no
            KiemTraChuoi doiTuong = new KiemTraChuoi();

            bool ketQua = doiTuong.KiemTraDoiXung("");

            Assert.IsTrue(ketQua);
        }

        [TestMethod]
        public void ChuoiMotKyTu_TraVeTrue()
        {
            // Truong hop bien: chuoi chi co 1 ky tu luon doi xung
            KiemTraChuoi doiTuong = new KiemTraChuoi();

            bool ketQua = doiTuong.KiemTraDoiXung("a");

            Assert.IsTrue(ketQua);
        }

        [TestMethod]
        public void ChuoiSoDoiXung_TraVeTrue()
        {
            KiemTraChuoi doiTuong = new KiemTraChuoi();

            bool ketQua = doiTuong.KiemTraDoiXung("12321");

            Assert.IsTrue(ketQua);
        }

        [TestMethod]
        public void ChuoiCoKhoangTrangDoiXung_TraVeTrue()
        {
            // Truong hop bien: chuoi co khoang trang nhung van doi xung neu tinh ca khoang trang
            KiemTraChuoi doiTuong = new KiemTraChuoi();

            bool ketQua = doiTuong.KiemTraDoiXung("a b a");

            Assert.IsTrue(ketQua);
        }

        [TestMethod]
        public void ChuoiKhacHoaThuong_PhanBietHoaThuong_TraVeFalse()
        {
            // Minh chung ham phan biet hoa/thuong: "Aba" dao nguoc la "abA", khac voi ban goc
            KiemTraChuoi doiTuong = new KiemTraChuoi();

            bool ketQua = doiTuong.KiemTraDoiXung("Aba");

            Assert.IsFalse(ketQua);
        }
    }
}