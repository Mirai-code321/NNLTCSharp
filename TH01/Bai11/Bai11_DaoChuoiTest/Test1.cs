using Bai11_DaoChuoi;

namespace Bai11_DaoChuoiTest
{
    [TestClass]
    public class Test1
    {
        // MSTest tao doi tuong test moi cho tung [TestMethod] nen dung chung field nay duoc
        private readonly XuLyChuoi xuLy = new XuLyChuoi();

        // ---- Truong hop thuong ----

        [TestMethod]
        public void ChuoiBinhThuong_TraVeChuoiDao()
        {
            Assert.AreEqual("cba", xuLy.DaoChuoi("abc"));
        }

        [TestMethod]
        public void ChuoiCoKhoangTrang_KhoangTrangDoiVeDungViTri()
        {
            Assert.AreEqual("oahc nix", xuLy.DaoChuoi("xin chao"));
        }

        [TestMethod]
        public void ChuoiSo_TraVeChuoiDao()
        {
            Assert.AreEqual("54321", xuLy.DaoChuoi("12345"));
        }

        [TestMethod]
        public void ChuoiDoiXung_DaoXongVanGiuNguyen()
        {
            Assert.AreEqual("abba", xuLy.DaoChuoi("abba"));
        }

        [TestMethod]
        public void ChuoiHoaThuong_GiuNguyenKieuChu()
        {
            // chi doi vi tri, khong doi hoa/thuong cua tung ky tu
            Assert.AreEqual("CbA", xuLy.DaoChuoi("AbC"));
        }

        [TestMethod]
        public void ChuoiTiengVietCoDau_DaoDungKyTu()
        {
            Assert.AreEqual("maN tệiV", xuLy.DaoChuoi("Việt Nam"));
        }

        // ---- Truong hop bien ----

        [TestMethod]
        public void MotKyTu_TraVeChinNo()
        {
            Assert.AreEqual("a", xuLy.DaoChuoi("a"));
        }

        [TestMethod]
        public void ChuoiRong_TraVeChuoiRong()
        {
            Assert.AreEqual("", xuLy.DaoChuoi(""));
        }

        [TestMethod]
        public void ChuoiNull_TraVeChuoiRong()
        {
            Assert.AreEqual("", xuLy.DaoChuoi(null));
        }

        [TestMethod]
        public void KhoangTrangODauChuoi_ChuyenSangCuoiChuoi()
        {
            Assert.AreEqual("ba  ", xuLy.DaoChuoi("  ab"));
        }

        // ---- Kiem tra tinh chat ----

        [TestMethod]
        public void DaoHaiLan_RaLaiChuoiGoc()
        {
            string goc = "Hello World";
            Assert.AreEqual(goc, xuLy.DaoChuoi(xuLy.DaoChuoi(goc)));
        }

        [TestMethod]
        public void SauKhiDao_ChuoiGocKhongBiThayDoi()
        {
            // string bat bien nen ham chi tra ve chuoi moi, chuoi goc van nhu cu
            string goc = "abc";
            xuLy.DaoChuoi(goc);
            Assert.AreEqual("abc", goc);
        }
    }
}