using Bai12_ChuoiNhieuTu;

namespace Bai12_ChuoiNhieuTuTest
{
    [TestClass]
    public class Test1
    {
        // MSTest tao doi tuong test moi cho tung [TestMethod] nen dung chung field nay duoc
        private readonly XuLyChuoi xuLy = new XuLyChuoi();

        // ---- ChuyenSangThuong ----

        [TestMethod]
        public void Thuong_ChuoiHoaThuongLanLon_TraVeToanChuThuong()
        {
            Assert.AreEqual("xin chao cac ban", xuLy.ChuyenSangThuong("Xin Chao CAC Ban"));
        }

        [TestMethod]
        public void Thuong_ChuoiTiengVietCoDau_DoiDungChuCoDau()
        {
            Assert.AreEqual("việt nam", xuLy.ChuyenSangThuong("VIỆT Nam"));
        }

        [TestMethod]
        public void Thuong_ChuoiCoSoVaKyTuDacBiet_GiuNguyenPhanKhongPhaiChu()
        {
            Assert.AreEqual("abc 123 !@#", xuLy.ChuyenSangThuong("ABC 123 !@#"));
        }

        [TestMethod]
        public void Thuong_ChuoiRong_TraVeChuoiRong()
        {
            Assert.AreEqual("", xuLy.ChuyenSangThuong(""));
        }

        [TestMethod]
        public void Thuong_ChuoiNull_TraVeChuoiRong()
        {
            Assert.AreEqual("", xuLy.ChuyenSangThuong(null));
        }

        // ---- ChuyenSangHoa ----

        [TestMethod]
        public void Hoa_ChuoiHoaThuongLanLon_TraVeToanChuHoa()
        {
            Assert.AreEqual("XIN CHAO CAC BAN", xuLy.ChuyenSangHoa("Xin Chao cac Ban"));
        }

        [TestMethod]
        public void Hoa_ChuoiTiengVietCoDau_DoiDungChuCoDau()
        {
            Assert.AreEqual("VIỆT NAM", xuLy.ChuyenSangHoa("Việt Nam"));
        }

        [TestMethod]
        public void Hoa_ChuoiRong_TraVeChuoiRong()
        {
            Assert.AreEqual("", xuLy.ChuyenSangHoa(""));
        }

        [TestMethod]
        public void Hoa_ChuoiNull_TraVeChuoiRong()
        {
            Assert.AreEqual("", xuLy.ChuyenSangHoa(null));
        }

        // ---- DemSoTu ----

        [TestMethod]
        public void DemTu_ChuoiBinhThuong_TraVeDungSoTu()
        {
            Assert.AreEqual(4, xuLy.DemSoTu("Xin chao cac ban"));
        }

        [TestMethod]
        public void DemTu_MotTu_TraVeMot()
        {
            Assert.AreEqual(1, xuLy.DemSoTu("hello"));
        }

        [TestMethod]
        public void DemTu_NhieuKhoangTrangGiuaCacTu_KhongDemThuaTu()
        {
            Assert.AreEqual(2, xuLy.DemSoTu("xin     chao"));
        }

        [TestMethod]
        public void DemTu_KhoangTrangDauVaCuoi_KhongDemThuaTu()
        {
            Assert.AreEqual(2, xuLy.DemSoTu("  hello world  "));
        }

        [TestMethod]
        public void DemTu_NganCachBangTab_VanTinhLaHaiTu()
        {
            Assert.AreEqual(2, xuLy.DemSoTu("xin\tchao"));
        }

        [TestMethod]
        public void DemTu_ChuoiTiengVietVaKyTuDacBiet_TraVeDungSoTu()
        {
            // "C#" van tinh la 1 tu
            Assert.AreEqual(3, xuLy.DemSoTu("Lập trình C#"));
        }

        [TestMethod]
        public void DemTu_ChuoiRong_TraVeKhong()
        {
            Assert.AreEqual(0, xuLy.DemSoTu(""));
        }

        [TestMethod]
        public void DemTu_ToanKhoangTrang_TraVeKhong()
        {
            Assert.AreEqual(0, xuLy.DemSoTu("     "));
        }

        [TestMethod]
        public void DemTu_ChuoiNull_TraVeKhong()
        {
            Assert.AreEqual(0, xuLy.DemSoTu(null));
        }
    }
}