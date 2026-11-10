using Microsoft.VisualStudio.TestTools.UnitTesting; // Thư viện MSTest chạy kiểm thử
using System;
using Bai2_BangCuuChuong; // Import namespace của project chính

namespace Bai2_BangCuuChuongTest
{
    [TestClass] // Đánh dấu lớp kiểm thử Unit Test
    public class UnitTest1
    {
        // Test kiểm tra chuỗi trả về không rỗng
        [TestMethod]
        public void TaoBangCuuChuong_TraVeChuoiKhongRong()
        {
            // Gọi hàm sinh bảng cửu chương
            string ketQua = InBangCuuChuongService.TaoBangCuuChuong();

            // Assert: Kiểm tra xem kết quả có bị rỗng hay không
            Assert.IsFalse(string.IsNullOrEmpty(ketQua));
        }

        // Test kiểm tra các phép tính cốt lõi có xuất hiện trong bảng cửu chương không
        [TestMethod]
        public void TaoBangCuuChuong_ChuaDungCacPhepTinhChinh()
        {
            // Lấy chuỗi thực tế từ Service
            string ketQua = InBangCuuChuongService.TaoBangCuuChuong();
            
            // Xóa hết khoảng trắng thừa để so sánh chính xác logic phép tính mà không lo lệch space
            string chuoiChuanHoa = ketQua.Replace(" ", "");

            // Assert: So sánh các phép tính tiêu biểu sau khi xóa khoảng trắng
            Assert.IsTrue(chuoiChuanHoa.Contains("2x1=2"));   // Phép tính đầu khối 1
            Assert.IsTrue(chuoiChuanHoa.Contains("9x5=45"));  // Phép tính cuối khối 1
            Assert.IsTrue(chuoiChuanHoa.Contains("9x10=90")); // Phép tính cuối khối 2
        }

        // Test kiểm tra logic phép nhân hợp lệ
        [TestMethod]
        public void KiemTraKetQuaPhepNhan_DauVaoHopLe_TraVeTrueVaKetQuaDung()
        {
            // Truyền tham số 5 x 5
            bool status = InBangCuuChuongService.KiemTraKetQuaPhepNhan(5, 5, out int ketQua);

            // Assert: Phải trả về true và kết quả bằng 25
            Assert.IsTrue(status);
            Assert.AreEqual(25, ketQua);
        }

        // Test kiểm tra logic phép nhân với đầu vào ngoài phạm vi
        [TestMethod]
        public void KiemTraKetQuaPhepNhan_DauVaoNgoaiPhamVi_TraVeFalse()
        {
            // Test n = 1 (ngoài khoảng cửu chương 2..9)
            Assert.IsFalse(InBangCuuChuongService.KiemTraKetQuaPhepNhan(1, 5, out _));

            // Test i = 11 (ngoài khoảng hệ số 1..10)
            Assert.IsFalse(InBangCuuChuongService.KiemTraKetQuaPhepNhan(5, 11, out _));
        }
    }
}