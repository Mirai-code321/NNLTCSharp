using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TimLonNhat;

namespace TimLonNhatTest
{
    [TestClass] // Lớp đánh dấu chứa các phương thức Unit Test
    public class UnitTest1
    {
    
        // NHÓM 1: Kiểm thử câu (a) TimKLonNhat (4^k < n)
       

        [TestMethod] // Với n = 10 -> 4^1 = 4 < 10 < 4^2 = 16 -> k lớn nhất là 1
        public void TimKLonNhat_N10_TraVe1()
        {
            int k = TimLonNhatService.TimKLonNhat(10);
            Assert.AreEqual(1, k, "Với n=10, 4^1 < 10 nên k phải bằng 1");
        }

        [TestMethod] // Với n = 17 -> 4^2 = 16 < 17 < 4^3 = 64 -> k lớn nhất là 2
        public void TimKLonNhat_N17_TraVe2()
        {
            int k = TimLonNhatService.TimKLonNhat(17);
            Assert.AreEqual(2, k);
        }

        [TestMethod] // Trường hợp n <= 1 -> Bắt buộc ném ngoại lệ ArgumentException
        [ExpectedException(typeof(ArgumentException))]
        public void TimKLonNhat_NBang1_NemNgoaiLe()
        {
            TimLonNhatService.TimKLonNhat(1);
        }


        // NHÓM 2: Kiểm thử câu (b) Tim2MuKNhoNhat (2^k >= n)
       
        [TestMethod] // Với n = 5 -> Các lũy thừa 2 là 1, 2, 4, 8... Số bé nhất >= 5 là 8 (2^3)
        public void Tim2MuKNhoNhat_N5_TraVe8()
        {
            long ketQua = TimLonNhatService.Tim2MuKNhoNhat(5);
            Assert.AreEqual(8, ketQua);
        }

        [TestMethod] // Trường hợp n chính là một số lũy thừa của 2 (n = 16) -> Trả về chính 16
        public void Tim2MuKNhoNhat_N16_TraVe16()
        {
            long ketQua = TimLonNhatService.Tim2MuKNhoNhat(16);
            Assert.AreEqual(16, ketQua);
        }

        [TestMethod] // Truyền n <= 0 -> Ném ArgumentException
        [ExpectedException(typeof(ArgumentException))]
        public void Tim2MuKNhoNhat_NAm_NemNgoaiLe()
        {
            TimLonNhatService.Tim2MuKNhoNhat(0);
        }

        // NHÓM 3: Kiểm thử validation chuỗi nhập n
       

        [TestMethod] // Nhập chuỗi số hợp lệ "100" -> Trả về true và n = 100
        public void KiemTraN_HopLe_TraVeTrue()
        {
            Assert.IsTrue(TimLonNhatService.KiemTraNHopLe("100", out long n));
            Assert.AreEqual(100, n);
        }

        [TestMethod] // Nhập chữ hoặc số âm -> Phải trả về false
        public void KiemTraN_KhongHopLe_TraVeFalse()
        {
            Assert.IsFalse(TimLonNhatService.KiemTraNHopLe("abc", out _));
            Assert.IsFalse(TimLonNhatService.KiemTraNHopLe("-5", out _));
        }
    }
}

