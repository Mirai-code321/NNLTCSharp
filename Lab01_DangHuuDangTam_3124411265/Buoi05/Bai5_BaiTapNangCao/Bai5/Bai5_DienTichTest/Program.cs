using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TinhDienTich;

namespace TinhDienTichTest
{
    [TestClass] // Đánh dấu đây là lớp chứa các phương thức UnitTest
    public class UnitTest1
    {
        private const double EPS = 0.00001; // Đặt sai số cho phép khi so sánh 2 số thực double

        // NHÓM 1: Kiểm thử diện tích Tam Giác
        

        [TestMethod] // Test trường hợp tam giác vuông 3-4-5 -> Diện tích phải bằng 6
        public void TinhDienTichTamGiac_CanhHopLe_TraVeDienTichDung()
        {
            double dt = TinhDienTichService.TinhDienTichTamGiac(3, 4, 5);
            Assert.AreEqual(6.0, dt, EPS); // So sánh kết quả trả về với số 6.0
        }

        [TestMethod] // Test trường hợp 3 cạnh không tạo thành tam giác -> Phải ném lỗi ArgumentException
        [ExpectedException(typeof(ArgumentException))]
        public void TinhDienTichTamGiac_CanhKhongHopLe_NemNgoaiLe()
        {
            TinhDienTichService.TinhDienTichTamGiac(1, 2, 3);
        }


        // NHÓM 2: Kiểm thử diện tích Hình Chữ Nhật
       

        [TestMethod] // Test đúng theo mẫu đề bài: Dài = 3, Rộng = 5 -> Diện tích = 15
        public void TinhDienTichHinhChuNhat_KichThuocHopLe_TraVe15()
        {
            double dt = TinhDienTichService.TinhDienTichHinhChuNhat(3, 5);
            Assert.AreEqual(15.0, dt, EPS);
        }

        [TestMethod] // Test trường hợp nhập cạnh âm -> Phải ném ngoại lệ
        [ExpectedException(typeof(ArgumentException))]
        public void TinhDienTichHinhChuNhat_KichThuocAm_NemNgoaiLe()
        {
            TinhDienTichService.TinhDienTichHinhChuNhat(-3, 5);
        }

   
        // NHÓM 3: Kiểm thử diện tích Hình Tròn
        

        [TestMethod] // Test bán kính r = 2 -> Diện tích phải bằng PI * 4
        public void TinhDienTichHinhTron_BanKinhHopLe_TraVeDienTichDung()
        {
            double dt = TinhDienTichService.TinhDienTichHinhTron(2);
            Assert.AreEqual(Math.PI * 4, dt, EPS);
        }

        
        // NHÓM 4: Kiểm thử Lựa chọn Menu
        

        [TestMethod] // Nhập "2" -> Lựa chọn hợp lệ (trả về true)
        public void KiemTraLoiChon_Menu2_TraVeTrue()
        {
            Assert.IsTrue(TinhDienTichService.KiemTraLoiChon("2", out int choice));
            Assert.AreEqual(2, choice);
        }

        [TestMethod] // Nhập số "5" hoặc chữ "abc" -> Không hợp lệ (trả về false)
        public void KiemTraLoiChon_MenuKhongHopLe_TraVeFalse()
        {
            Assert.IsFalse(TinhDienTichService.KiemTraLoiChon("5", out _));
            Assert.IsFalse(TinhDienTichService.KiemTraLoiChon("abc", out _));
        }
    }
}


