using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai15_XuLyMang;

namespace Bai15_XuLyMangTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TimMaxMin_TruongHopBinhThuong_TraVeDung()
        {
            var tools = new MangTools();
            int[] mang = { 5, 1, 9, 3, 7 };

            tools.TimMaxMin(mang, out int max, out int min);

            Assert.AreEqual(9, max);
            Assert.AreEqual(1, min);
        }

        [TestMethod]
        public void TimMaxMin_MotPhanTu_MaxMinBangNhau()
        {
            // Truong hop bien: mang chi co 1 phan tu thi max va min phai bang nhau va bang chinh phan tu do
            var tools = new MangTools();
            int[] mang = { 42 };

            tools.TimMaxMin(mang, out int max, out int min);

            Assert.AreEqual(42, max);
            Assert.AreEqual(42, min);
        }

        [TestMethod]
        public void TimMaxMin_CoSoAm_TraVeDung()
        {
            var tools = new MangTools();
            int[] mang = { -5, -1, -9, -3 };

            tools.TimMaxMin(mang, out int max, out int min);

            Assert.AreEqual(-1, max);
            Assert.AreEqual(-9, min);
        }

        [TestMethod]
        public void TimMaxMin_MangRong_NemNgoaiLe()
        {
            // Truong hop bien quan trong nhat: mang rong phai nem ngoai le thay vi crash IndexOutOfRange
            var tools = new MangTools();
            int[] mang = Array.Empty<int>();

            Assert.ThrowsExactly<ArgumentException>(() =>
            {
                tools.TimMaxMin(mang, out int max, out int min);
            });
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_SoNguyenTo_TraVeTrue()
        {
            var tools = new MangTools();
            Assert.IsTrue(tools.KiemTraSoNguyenTo(2)); // 2 la so nguyen to nho nhat, de test bien duoi
            Assert.IsTrue(tools.KiemTraSoNguyenTo(13));
            Assert.IsTrue(tools.KiemTraSoNguyenTo(97));
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_SoKhongPhaiNguyenTo_TraVeFalse()
        {
            var tools = new MangTools();
            Assert.IsFalse(tools.KiemTraSoNguyenTo(4));
            Assert.IsFalse(tools.KiemTraSoNguyenTo(100));
        }

        [TestMethod]
        public void KiemTraSoNguyenTo_SoAmVa0Va1_TraVeFalse()
        {
            // Test rieng nhom bien 0, 1, so am vi day la loi hay gap nhat khi tu viet thuat toan kiem tra nguyen to
            var tools = new MangTools();
            Assert.IsFalse(tools.KiemTraSoNguyenTo(-7));
            Assert.IsFalse(tools.KiemTraSoNguyenTo(0));
            Assert.IsFalse(tools.KiemTraSoNguyenTo(1));
        }

        [TestMethod]
        public void LayMangSoNguyenTo_MangHonHop_TraVeDungCacSoNguyenTo()
        {
            var tools = new MangTools();
            int[] mang = { 4, 7, 9, 11, 15, 2 };

            int[] ketQua = tools.LayMangSoNguyenTo(mang);

            // Ket qua phai giu dung thu tu xuat hien trong mang goc: 7, 11, 2
            CollectionAssert.AreEqual(new int[] { 7, 11, 2 }, ketQua);
        }

        [TestMethod]
        public void LayMangSoNguyenTo_KhongCoSoNguyenTo_TraVeMangRong()
        {
            var tools = new MangTools();
            int[] mang = { 4, 6, 8, 9, 10 };

            int[] ketQua = tools.LayMangSoNguyenTo(mang);

            Assert.AreEqual(0, ketQua.Length);
        }

        [TestMethod]
        [DoNotParallelize] // Console.Out la tai nguyen dung chung, phai chay rieng le tranh xung dot voi test khac
        public void InMang_MangCoPhanTu_InDungDinhDang()
        {
            var tools = new MangTools();
            int[] mang = { 1, 2, 3 };
            var output = new StringWriter();
            var consoleGoc = Console.Out; // luu lai Console goc de khoi phuc sau khi test xong

            Console.SetOut(output);
            try
            {
                tools.InMang(mang);
                Assert.AreEqual("1 2 3", output.ToString().Trim());
            }
            finally
            {
                Console.SetOut(consoleGoc); // luon khoi phuc, ke ca khi assert that bai
            }
        }

        [TestMethod]
        [DoNotParallelize]
        public void InMang_MangRong_InThongBaoRong()
        {
            var tools = new MangTools();
            int[] mang = Array.Empty<int>();
            var output = new StringWriter();
            var consoleGoc = Console.Out;

            Console.SetOut(output);
            try
            {
                tools.InMang(mang);
                Assert.AreEqual("(Mang rong)", output.ToString().Trim());
            }
            finally
            {
                Console.SetOut(consoleGoc);
            }
        }
    }
}