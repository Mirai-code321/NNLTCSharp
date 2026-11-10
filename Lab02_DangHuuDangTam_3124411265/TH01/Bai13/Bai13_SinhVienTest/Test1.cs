using Bai13_SinhVien;

namespace Bai13_SinhVienTest
{
    [TestClass]
    public class Test1
    {
        // ---- Khoi tao hop le ----

        [TestMethod]
        public void KhoiTao_DuLieuHopLe_CacThuocTinhDungGiaTri()
        {
            SinhVien sv = new SinhVien("SV001", "Nguyen Van A", "12 Tran Hung Dao", 2);

            Assert.AreEqual("SV001", sv.MaSinhVien);
            Assert.AreEqual("Nguyen Van A", sv.HoTen);
            Assert.AreEqual("12 Tran Hung Dao", sv.DiaChi);
            Assert.AreEqual(2, sv.NamThu);
        }

        [TestMethod]
        public void KhoiTao_ThongTinCoKhoangTrangDauCuoi_DuocCatBo()
        {
            SinhVien sv = new SinhVien("  SV001 ", "  Nguyen Van A ", " 12 Tran Hung Dao  ", 2);

            Assert.AreEqual("SV001", sv.MaSinhVien);
            Assert.AreEqual("Nguyen Van A", sv.HoTen);
            Assert.AreEqual("12 Tran Hung Dao", sv.DiaChi);
        }

        [TestMethod]
        public void KhoiTao_TiengVietCoDau_GiuNguyen()
        {
            SinhVien sv = new SinhVien("SV002", "Nguyễn Văn An", "Quận 5, TP. Hồ Chí Minh", 3);

            Assert.AreEqual("Nguyễn Văn An", sv.HoTen);
            Assert.AreEqual("Quận 5, TP. Hồ Chí Minh", sv.DiaChi);
        }

        // ---- Bien cua nam thu ----

        [TestMethod]
        public void KhoiTao_NamThuNhoNhat_HopLe()
        {
            SinhVien sv = new SinhVien("SV001", "Nguyen Van A", "HCM", 1);
            Assert.AreEqual(1, sv.NamThu);
        }

        [TestMethod]
        public void KhoiTao_NamThuLonNhat_HopLe()
        {
            SinhVien sv = new SinhVien("SV001", "Nguyen Van A", "HCM", 6);
            Assert.AreEqual(6, sv.NamThu);
        }

        [TestMethod]
        public void KhoiTao_NamThuBangKhong_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(
                () => new SinhVien("SV001", "Nguyen Van A", "HCM", 0));
        }

        [TestMethod]
        public void KhoiTao_NamThuLonHonToiDa_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(
                () => new SinhVien("SV001", "Nguyen Van A", "HCM", 7));
        }

        [TestMethod]
        public void KhoiTao_NamThuAm_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentOutOfRangeException>(
                () => new SinhVien("SV001", "Nguyen Van A", "HCM", -1));
        }

        // ---- Du lieu chuoi khong hop le ----

        [TestMethod]
        public void KhoiTao_MaSinhVienRong_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentException>(
                () => new SinhVien("", "Nguyen Van A", "HCM", 2));
        }

        [TestMethod]
        public void KhoiTao_MaSinhVienNull_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentException>(
                () => new SinhVien(null, "Nguyen Van A", "HCM", 2));
        }

        [TestMethod]
        public void KhoiTao_HoTenToanKhoangTrang_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentException>(
                () => new SinhVien("SV001", "     ", "HCM", 2));
        }

        [TestMethod]
        public void KhoiTao_DiaChiRong_NemLoi()
        {
            Assert.ThrowsExactly<ArgumentException>(
                () => new SinhVien("SV001", "Nguyen Van A", "", 2));
        }

        // ---- Xuat thong tin va doi tuong doc lap ----

        [TestMethod]
        public void LayThongTin_TraVeDungDinhDang()
        {
            SinhVien sv = new SinhVien("SV001", "Nguyen Van A", "12 Tran Hung Dao", 2);

            string mongDoi = "Ma sinh vien: SV001" + Environment.NewLine +
                             "Ho ten      : Nguyen Van A" + Environment.NewLine +
                             "Dia chi     : 12 Tran Hung Dao" + Environment.NewLine +
                             "Nam thu     : 2";

            Assert.AreEqual(mongDoi, sv.LayThongTin());
        }

        [TestMethod]
        public void HaiDoiTuong_DuLieuDocLapNhau()
        {
            // moi doi tuong giu du lieu rieng cua minh
            SinhVien sv1 = new SinhVien("SV001", "Nguyen Van A", "HCM", 1);
            SinhVien sv2 = new SinhVien("SV002", "Tran Thi B", "Ha Noi", 4);

            Assert.AreEqual("SV001", sv1.MaSinhVien);
            Assert.AreEqual("Tran Thi B", sv2.HoTen);
            Assert.AreNotEqual(sv1.NamThu, sv2.NamThu);
        }
    }
}
