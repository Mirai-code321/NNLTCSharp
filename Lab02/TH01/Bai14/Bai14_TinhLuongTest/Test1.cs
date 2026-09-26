using Bai14_TinhLuong;

namespace Bai14_TinhLuongTest
{
    [TestClass]
    public class Test1
    {
        // ---- Khoi tao ----

        [TestMethod]
        public void KhoiTao_DuLieuHopLe_CacThuocTinhDungGiaTri()
        {
            NhanVien nv = new NhanVien("Nguyen Van A", 10000000, 2);

            Assert.AreEqual("Nguyen Van A", nv.HoTen);
            Assert.AreEqual(10000000L, nv.MucLuong);
            Assert.AreEqual(2, nv.SoNgayVang);
        }

        [TestMethod]
        public void KhoiTao_HoTenCoKhoangTrangDauCuoi_DuocCatBo()
        {
            NhanVien nv = new NhanVien("  Nguyen Van A  ", 10000000, 0);
            Assert.AreEqual("Nguyen Van A", nv.HoTen);
        }

        [TestMethod]
        public void KhoiTao_HoTenRong_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentException>(
                () => new NhanVien("", 10000000, 0));
        }

        [TestMethod]
        public void KhoiTao_HoTenNull_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentException>(
                () => new NhanVien(null, 10000000, 0));
        }

        [TestMethod]
        public void KhoiTao_MucLuongAm_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(
                () => new NhanVien("Nguyen Van A", -1, 0));
        }

        [TestMethod]
        public void KhoiTao_MucLuongBangKhong_HopLe()
        {
            NhanVien nv = new NhanVien("Nguyen Van A", 0, 0);
            Assert.AreEqual(0L, nv.MucLuong);
        }

        [TestMethod]
        public void KhoiTao_SoNgayVangAm_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(
                () => new NhanVien("Nguyen Van A", 10000000, -1));
        }

        [TestMethod]
        public void KhoiTao_SoNgayVangLonHon31_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(
                () => new NhanVien("Nguyen Van A", 10000000, 32));
        }

        // ---- Tinh luong ----

        [TestMethod]
        public void TinhLuong_KhongVangNgayNao_LuongBangMucLuong()
        {
            NhanVien nv = new NhanVien("Nguyen Van A", 10000000, 0);
            Assert.AreEqual(10000000L, nv.TinhLuong());
        }

        [TestMethod]
        public void TinhLuong_VangMotNgay_TruDung100Nghin()
        {
            NhanVien nv = new NhanVien("Nguyen Van A", 10000000, 1);
            Assert.AreEqual(9900000L, nv.TinhLuong());
        }

        [TestMethod]
        public void TinhLuong_VangNamNgay_TruDung500Nghin()
        {
            NhanVien nv = new NhanVien("Nguyen Van A", 10000000, 5);
            Assert.AreEqual(9500000L, nv.TinhLuong());
        }

        [TestMethod]
        public void TinhLuong_TienTruBangDungMucLuong_LuongBangKhong()
        {
            NhanVien nv = new NhanVien("Nguyen Van A", 1000000, 10);
            Assert.AreEqual(0L, nv.TinhLuong());
        }

        [TestMethod]
        public void TinhLuong_TienTruVuotMucLuong_LuongBangKhongKhongAm()
        {
            // tru 8 x 100.000 = 800.000 > 500.000 nhung luong khong duoc am
            NhanVien nv = new NhanVien("Nguyen Van A", 500000, 8);
            Assert.AreEqual(0L, nv.TinhLuong());
        }

        [TestMethod]
        public void TinhLuong_VangToiDa31Ngay_TruDung3Trieu100Nghin()
        {
            NhanVien nv = new NhanVien("Nguyen Van A", 10000000, 31);
            Assert.AreEqual(6900000L, nv.TinhLuong());
        }

        [TestMethod]
        public void TinhLuong_MucLuongRatLon_KhongTranSo()
        {
            // 9 nghin ty vuot xa gioi han cua int, kiem tra dung long la du
            NhanVien nv = new NhanVien("Nguyen Van A", 9000000000000, 2);
            Assert.AreEqual(8999999800000L, nv.TinhLuong());
        }

        [TestMethod]
        public void TinhTienTru_VangBaNgay_Tru300Nghin()
        {
            NhanVien nv = new NhanVien("Nguyen Van A", 10000000, 3);
            Assert.AreEqual(300000L, nv.TinhTienTru());
        }

        // ---- Xuat thong tin ----

        [TestMethod]
        public void LayThongTin_TraVeDungDinhDang()
        {
            NhanVien nv = new NhanVien("Nguyen Van A", 10000000, 2);

            string mongDoi = "Ho ten         : Nguyen Van A" + Environment.NewLine +
                             "Muc luong      : 10.000.000 VND" + Environment.NewLine +
                             "So ngay vang   : 2" + Environment.NewLine +
                             "Tien bi tru    : 200.000 VND" + Environment.NewLine +
                             "Luong thuc nhan: 9.800.000 VND";

            Assert.AreEqual(mongDoi, nv.LayThongTin());
        }
    }
}