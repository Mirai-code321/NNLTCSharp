using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai16_SapXepHoTen;

namespace Bai16_SapXepHoTenTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SapXepTangDan_MangBinhThuong_SapXepDungThuTu()
        {
            var tools = new MangHoTen();
            string[] mang = { "Tran Van B", "Nguyen Van A", "Le Thi C" };

            tools.SapXepTangDan(mang);

            CollectionAssert.AreEqual(
                new string[] { "Le Thi C", "Nguyen Van A", "Tran Van B" },
                mang
            );
        }

        [TestMethod]
        public void SapXepTangDan_MangDaSapXep_KhongDoiThuTu()
        {
            var tools = new MangHoTen();
            string[] mang = { "An", "Binh", "Chi" };

            tools.SapXepTangDan(mang);

            CollectionAssert.AreEqual(new string[] { "An", "Binh", "Chi" }, mang);
        }

        [TestMethod]
        public void SapXepTangDan_MangNguocThuTu_SapXepLaiDung()
        {
            var tools = new MangHoTen();
            string[] mang = { "Chi", "Binh", "An" };

            tools.SapXepTangDan(mang);

            CollectionAssert.AreEqual(new string[] { "An", "Binh", "Chi" }, mang);
        }

        [TestMethod]
        public void SapXepTangDan_MotPhanTu_KhongDoi()
        {
            // Truong hop bien: mang chi co 1 phan tu thi khong can sap xep
            var tools = new MangHoTen();
            string[] mang = { "MotMinh" };

            tools.SapXepTangDan(mang);

            CollectionAssert.AreEqual(new string[] { "MotMinh" }, mang);
        }

        [TestMethod]
        public void SapXepTangDan_MangRong_KhongLoi()
        {
            // Truong hop bien: mang rong khong duoc gay loi khi sap xep
            var tools = new MangHoTen();
            string[] mang = new string[0];

            tools.SapXepTangDan(mang);

            Assert.IsEmpty(mang);
        }

        [TestMethod]
        public void SapXepTangDan_CoTenTrungNhau_GiuNguyenSoLuong()
        {
            // Truong hop bien: co ten bang nhau, sap xep khong duoc lam mat phan tu
            var tools = new MangHoTen();
            string[] mang = { "Binh", "An", "An" };

            tools.SapXepTangDan(mang);

            CollectionAssert.AreEqual(new string[] { "An", "An", "Binh" }, mang);
        }

        [TestMethod]
        public void SapXepTangDan_KhongPhanBietHoaThuong_SapXepDung()
        {
            // Kiem chung dung StringComparison.OrdinalIgnoreCase: chu hoa/thuong khong lam sai thu tu
            var tools = new MangHoTen();
            string[] mang = { "binh", "An", "chi" };

            tools.SapXepTangDan(mang);

            CollectionAssert.AreEqual(new string[] { "An", "binh", "chi" }, mang);
        }
    }
}