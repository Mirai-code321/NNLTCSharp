using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bai4_Robot;
using System;
using System.Collections.Generic;

namespace Bai4_RobotTest
{
    [TestClass]
    public class UnitTest1
    {
        // Test theo dung vi du mau trong de bai:
        // Ma tran A 5x5, day lenh B = (1, 2, 2, 1, 1)
        // Duong di: (0,0)=1 -> (0,1)=2 -> (1,1)=1 -> (2,1)=1 -> (2,2)=0 -> (2,3)=1
        // Tong = 1 + 2 + 1 + 1 + 0 + 1 = 6
        [TestMethod]
        public void TinhTongDuongDi_ViDuTrongDeBai_TraVe6()
        {
            // Arrange
            Robot xuLy = new Robot();
            int[,] maTranA = new int[,]
            {
                { 1, 2, 1, 1, 2 },
                { 1, 1, 1, 1, 2 },
                { 0, 1, 0, 1, 1 },
                { 0, 0, 1, 1, 2 },
                { 1, 0, 1, 1, 1 }
            };
            List<int> danhSachLenh = new List<int> { 1, 2, 2, 1, 1 };

            // Act
            int tong = xuLy.TinhTongDuongDi(maTranA, danhSachLenh);

            // Assert
            Assert.AreEqual(6, tong);
        }

        // Truong hop robot khong di chuyen (day lenh rong) -> tong chi la gia tri o (0,0)
        [TestMethod]
        public void TinhTongDuongDi_DayLenhRong_ChiTinhOXuatPhat()
        {
            Robot xuLy = new Robot();
            int[,] maTranA = new int[,]
            {
                { 5, 1 },
                { 2, 3 }
            };
            List<int> danhSachLenh = new List<int>();

            int tong = xuLy.TinhTongDuongDi(maTranA, danhSachLenh);

            Assert.AreEqual(5, tong);
        }

        // Truong hop robot di qua lai CUNG MOT O nhieu lan -> phai cong don moi lan
        [TestMethod]
        public void TinhTongDuongDi_DiQuaLaiCungMotO_CongDonMoiLan()
        {
            Robot xuLy = new Robot();
            int[,] maTranA = new int[,]
            {
                { 1, 2 },
                { 3, 4 }
            };
            // Di phai roi di trai -> quay lai o (0,0)
            List<int> danhSachLenh = new List<int> { 1, 3 };

            int tong = xuLy.TinhTongDuongDi(maTranA, danhSachLenh);

            // (0,0)=1 -> (0,1)=2 -> (0,0)=1 : tong = 1 + 2 + 1 = 4
            Assert.AreEqual(4, tong);
        }

        // Truong hop robot di ra ngoai ma tran -> phai nem loi
        [TestMethod]
        public void TinhTongDuongDi_DiRaNgoaiMaTran_NemLoi()
        {
            Robot xuLy = new Robot();
            int[,] maTranA = new int[,] { { 1, 2 } };
            List<int> danhSachLenh = new List<int> { 4 }; // di len khi dang o hang 0 -> ra ngoai

            Assert.ThrowsException<InvalidOperationException>(() =>
                xuLy.TinhTongDuongDi(maTranA, danhSachLenh));
        }

        // Truong hop lenh khong hop le (ngoai tap {1, 2, 3, 4}) -> phai nem loi
        [TestMethod]
        public void TinhTongDuongDi_LenhKhongHopLe_NemLoi()
        {
            Robot xuLy = new Robot();
            int[,] maTranA = new int[,] { { 1, 2 }, { 3, 4 } };
            List<int> danhSachLenh = new List<int> { 5 };

            Assert.ThrowsException<ArgumentException>(() =>
                xuLy.TinhTongDuongDi(maTranA, danhSachLenh));
        }

        // Kiem tra dieu kien hop le cua kich thuoc ma tran va so luong lenh
        [TestMethod]
        public void KiemTraDieuKienHopLe_CacTruongHopBienCua()
        {
            Robot xuLy = new Robot();

            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(0));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(1));
            Assert.IsTrue(xuLy.KiemTraKichThuocHopLe(100));
            Assert.IsFalse(xuLy.KiemTraKichThuocHopLe(101));

            Assert.IsFalse(xuLy.KiemTraSoLenhHopLe(0));
            Assert.IsTrue(xuLy.KiemTraSoLenhHopLe(1));
            Assert.IsTrue(xuLy.KiemTraSoLenhHopLe(200));
            Assert.IsFalse(xuLy.KiemTraSoLenhHopLe(201));
        }
    }
}