using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai17_MangHaiChieu;

namespace Bai17_MangHaiChieuTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LayMangChan_MangBinhThuong_TraVeDungCacSoChan()
        {
            var tools = new MangHaiChieu();
            int[,] mang = { { 1, 2, 3 }, { 4, 5, 6 } };

            int[] ketQua = tools.LayMangChan(mang);

            CollectionAssert.AreEqual(new int[] { 2, 4, 6 }, ketQua);
        }

        [TestMethod]
        public void LayMangLe_MangBinhThuong_TraVeDungCacSoLe()
        {
            var tools = new MangHaiChieu();
            int[,] mang = { { 1, 2, 3 }, { 4, 5, 6 } };

            int[] ketQua = tools.LayMangLe(mang);

            CollectionAssert.AreEqual(new int[] { 1, 3, 5 }, ketQua);
        }

        [TestMethod]
        public void LayMangChan_KhongCoSoChan_TraVeMangRong()
        {
            var tools = new MangHaiChieu();
            int[,] mang = { { 1, 3 }, { 5, 7 } };

            int[] ketQua = tools.LayMangChan(mang);

            Assert.IsEmpty(ketQua);
        }

        [TestMethod]
        public void LayMangLe_KhongCoSoLe_TraVeMangRong()
        {
            var tools = new MangHaiChieu();
            int[,] mang = { { 2, 4 }, { 6, 8 } };

            int[] ketQua = tools.LayMangLe(mang);

            Assert.IsEmpty(ketQua);
        }

        [TestMethod]
        public void LayMangChanVaLe_TongSoLuongBangTongPhanTu()
        {
            // Kiem chung khong bi trung hoac mat phan tu: chan + le phai bang tong so phan tu ban dau
            var tools = new MangHaiChieu();
            int[,] mang = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };

            int[] mangChan = tools.LayMangChan(mang);
            int[] mangLe = tools.LayMangLe(mang);

            Assert.AreEqual(12, mangChan.Length + mangLe.Length);
        }

        [TestMethod]
        public void LayMangChan_MotHangMotCot_HoatDongDung()
        {
            // Truong hop bien: mang chi co 1 phan tu (1x1)
            var tools = new MangHaiChieu();
            int[,] mang = { { 8 } };

            int[] ketQua = tools.LayMangChan(mang);

            CollectionAssert.AreEqual(new int[] { 8 }, ketQua);
        }

        [TestMethod]
        public void SinhNgauNhien_KichThuocVaKhoangGiaTri_DungYeuCau()
        {
            // Kiem tra kich thuoc dung n x m va moi phan tu nam trong doan [10, 100]
            var tools = new MangHaiChieu();
            int n = 5, m = 4;

            int[,] mang = tools.SinhNgauNhien(n, m);

            Assert.AreEqual(n, mang.GetLength(0));
            Assert.AreEqual(m, mang.GetLength(1));

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Assert.IsTrue(mang[i, j] >= 10 && mang[i, j] <= 100,
                        $"Gia tri {mang[i, j]} tai [{i},{j}] nam ngoai doan [10, 100]");
                }
            }
        }
    }
}