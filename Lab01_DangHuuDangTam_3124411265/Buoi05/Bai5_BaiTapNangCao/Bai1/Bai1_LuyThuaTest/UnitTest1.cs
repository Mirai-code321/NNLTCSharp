using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LuyThua;

namespace LuyThuaTest
{
    [TestClass] // Khai báo lớp chứa các bài test tự động
    public class UnitTest1
    {
        
        // NHÓM 1: Test logic hàm TinhLuyThua
      

        [TestMethod] // Trường hợp thông thường: Cơ số dương, số mũ dương
        public void TinhLuyThua_CoSoDuongSoMuDuong_TraVeKetQuaDung()
        {
            // Tính 2^3 -> Mong đợi bằng 8.0
            double ketQua = LuyThuaService.TinhLuyThua(2.0, 3);
            
            // Delta 0.00001 dùng để so sánh số thực double tránh lỗi làm tròn
            Assert.AreEqual(8.0, ketQua, 0.00001, "2^3 phải bằng 8");
        }

        [TestMethod] // Trường hợp số mũ bằng 0 (Quy ước toán học: a^0 = 1)
        public void TinhLuyThua_SoMuBang0_TraVe1()
        {
            double ketQua = LuyThuaService.TinhLuyThua(5.5, 0);
            Assert.AreEqual(1.0, ketQua, 0.00001, "Bất kỳ số nào mũ 0 cũng bằng 1");
        }

        [TestMethod] // Cơ số âm + Số mũ lẻ -> Kết quả phải là số âm
        public void TinhLuyThua_CoSoAmSoMuLe_TraVeKetQuaAm()
        {
            // (-3)^3 = (-3) * (-3) * (-3) = -27
            double ketQua = LuyThuaService.TinhLuyThua(-3.0, 3);
            Assert.AreEqual(-27.0, ketQua, 0.00001);
        }

        [TestMethod] // Cơ số âm + Số mũ chẵn -> Kết quả phải là số dương
        public void TinhLuyThua_CoSoAmSoMuChan_TraVeKetQuaDuong()
        {
            // (-3)^2 = (-3) * (-3) = 9
            double ketQua = LuyThuaService.TinhLuyThua(-3.0, 2);
            Assert.AreEqual(9.0, ketQua, 0.00001);
        }

        [TestMethod] // Truyền số mũ âm -> Hàm bắt buộc phải ném ArgumentException
        [ExpectedException(typeof(ArgumentException))]
        public void TinhLuyThua_SoMuAm_NemNgoaiLe()
        {
            LuyThuaService.TinhLuyThua(2.0, -1);
        }

       
        // NHÓM 2: Test validation nhập liệu hàm KiemTraSoMuHopLe
       
        [TestMethod] // Nhập số nguyên dương hợp lệ
        public void KiemTraSoMuHopLe_SoNguyenDuong_TraVeTrue()
        {
            Assert.IsTrue(LuyThuaService.KiemTraSoMuHopLe("5", out int n));
            Assert.AreEqual(5, n);
        }

        [TestMethod] // Nhập số 0 -> Bị từ chối vì đề yêu cầu số nguyên DƯƠNG (n > 0)
        public void KiemTraSoMuHopLe_So0_TraVeFalse()
        {
            Assert.IsFalse(LuyThuaService.KiemTraSoMuHopLe("0", out _));
        }

        [TestMethod] // Nhập số âm -> Bị từ chối
        public void KiemTraSoMuHopLe_SoAm_TraVeFalse()
        {
            Assert.IsFalse(LuyThuaService.KiemTraSoMuHopLe("-3", out _));
        }

        [TestMethod] // Nhập chuỗi chữ cái -> Bị từ chối do không ép kiểu được
        public void KiemTraSoMuHopLe_ChuoiKitu_TraVeFalse()
        {
            Assert.IsFalse(LuyThuaService.KiemTraSoMuHopLe("abc", out _));
        }
    }
}

