using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CosSin;

namespace CosSinTest
{
    [TestClass] // Đánh dấu đây là lớp chứa các bài test tự động
    public class UnitTest1
    {
        // Độ sai số cho phép khi so sánh kết quả số thực double trong Unit Test
        private const double EPS = 0.00001;

      
        // NHÓM 1: Kiểm thử logic hàm TinhCos
  

        [TestMethod] // Trường hợp cos(0) = 1
        public void TinhCos_Goc0_TraVe1()
        {
            double ketQua = CosSinService.TinhCos(0, EPS);
            Assert.AreEqual(1.0, ketQua, EPS, "Cos(0) phải bằng 1");
        }

        [TestMethod] // Trường hợp cos(PI / 3) = cos(60 deg) = 0.5
        public void TinhCos_GocPiChia3_TraVePoint5()
        {
            double x = Math.PI / 3;
            double ketQua = CosSinService.TinhCos(x, EPS);
            Assert.AreEqual(0.5, ketQua, EPS, "Cos(PI/3) phải xấp xỉ 0.5");
        }

        [TestMethod] // Truyền Epsilon <= 0 -> Phải ném ra ngoại lệ ArgumentException
        [ExpectedException(typeof(ArgumentException))]
        public void TinhCos_EpsilonAm_NemNgoaiLe()
        {
            CosSinService.TinhCos(1.0, -0.01);
        }

       
        // NHÓM 2: Kiểm thử logic hàm TinhSin
      

        [TestMethod] // Trường hợp sin(0) = 0
        public void TinhSin_Goc0_TraVe0()
        {
            double ketQua = CosSinService.TinhSin(0, EPS);
            Assert.AreEqual(0.0, ketQua, EPS, "Sin(0) phải bằng 0");
        }

        [TestMethod] // Trường hợp sin(PI / 6) = sin(30 deg) = 0.5
        public void TinhSin_GocPiChia6_TraVePoint5()
        {
            double x = Math.PI / 6;
            double ketQua = CosSinService.TinhSin(x, EPS);
            Assert.AreEqual(0.5, ketQua, EPS, "Sin(PI/6) phải xấp xỉ 0.5");
        }

      
        // NHÓM 3: Kiểm thử nhập liệu Epsilon
        

        [TestMethod] // Nhập chuỗi số thực dương hợp lệ
        public void KiemTraEpsilon_HopLe_TraVeTrue()
        {
            Assert.IsTrue(CosSinService.KiemTraEpsilonHopLe("0.0001", out double eps));
            Assert.AreEqual(0.0001, eps, 0.000001);
        }

        [TestMethod] // Nhập 0 hoặc số âm -> Phải trả về false
        public void KiemTraEpsilon_SoAmHoacBang0_TraVeFalse()
        {
            Assert.IsFalse(CosSinService.KiemTraEpsilonHopLe("0", out _));
            Assert.IsFalse(CosSinService.KiemTraEpsilonHopLe("-0.001", out _));
        }
    }
}

