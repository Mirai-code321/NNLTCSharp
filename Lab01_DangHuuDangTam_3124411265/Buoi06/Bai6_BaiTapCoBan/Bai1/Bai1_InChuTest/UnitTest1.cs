using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bai6_BaiTapCoBan; // Import namespace project chính để gọi class Service

namespace Bai6_BaiTapCoBanTest
{
    [TestClass] // Đánh dấu đây là class kiểm thử MSTest
    public class UnitTest1
    {
        // =====================================================================
        // NHÓM TEST 1: KIỂM THỬ HÀM TẠO HÌNH (TaoHinhChuIvaU)
        // =====================================================================

        [TestMethod] // Test trường hợp chuẩn với chiều cao h = 5
        public void TaoHinhChuIvaU_H5_TraVeChuoiDungMau()
        {
            // Arrange (Chuẩn bị dữ liệu mẫu)
            int h = 5;
            string mauChuan = 
                "* * * * *  *       *\n" +
                "    *      *       *\n" +
                "    *      *       *\n" +
                "    *      *       *\n" +
                "* * * * *  * * * * *";

            // Act (Gọi hàm thực thi) - Đổi \r\n thành \n để đồng bộ chuẩn xuống dòng
            string ketQua = InChuIvaUService.TaoHinhChuIvaU(h).Replace("\r\n", "\n");

            // Assert (So sánh kết quả hàm trả về với mẫu chuẩn)
            Assert.AreEqual(mauChuan, ketQua);
        }

        [TestMethod] // Test trường hợp h < 3 phải ném ra ngoại lệ ArgumentException
        [ExpectedException(typeof(ArgumentException))]
        public void TaoHinhChuIvaU_HNhoHon3_NemNgoaiLe()
        {
            // Act: Nhập h = 2 (nhỏ hơn 3) xem hệ thống có quăng lỗi ra không
            InChuIvaUService.TaoHinhChuIvaU(2);
        }

        // =====================================================================
        // NHÓM TEST 2: KIỂM THỬ HÀM VALIDATE (KiemTraHHopLe)
        // =====================================================================

        [TestMethod] // Test nhập chuỗi số hợp lệ "5" -> Hàm phải trả về true
        public void KiemTraH_HopLe_TraVeTrue()
        {
            Assert.IsTrue(InChuIvaUService.KiemTraHHopLe("5", out int h));
            Assert.AreEqual(5, h); // Giá trị biến out h phải bằng 5
        }

        [TestMethod] // Test nhập chuỗi sai ("abc" hoặc số < 3) -> Hàm phải trả về false
        public void KiemTraH_KhongHopLe_TraVeFalse()
        {
            Assert.IsFalse(InChuIvaUService.KiemTraHHopLe("abc", out _)); // Nhập chữ
            Assert.IsFalse(InChuIvaUService.KiemTraHHopLe("2", out _));   // Nhập h < 3
        }
    }
}