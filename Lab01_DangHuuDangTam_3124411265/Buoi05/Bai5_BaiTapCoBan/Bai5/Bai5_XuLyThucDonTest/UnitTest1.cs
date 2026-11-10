using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThucDon;

namespace ThucDonTest
{
    // [TestClass]: Đánh dấu đây là lớp chứa các bài test tự động cho MSTest nhận diện
    [TestClass]
    public class UnitTest1
    {
       
        // NHÓM 1: Kiểm thử hàm KiemTraHopLe
        // Mục tiêu: Bọc lót mọi khả năng nhập liệu của người dùng (biên, chữ, rỗng, null, số âm)

        [TestMethod] // Test giá trị biên dưới hợp lệ
        public void KiemTraHopLe_ChonSo1_TraVeTrue()
        {
            // Nhập "1" -> Là biên hợp lệ nhỏ nhất -> Bắt buộc trả về True và luaChon = 1
            bool ketQua = XuLyThucDon.KiemTraHopLe("1", out int luaChon);

            Assert.IsTrue(ketQua, "Giá trị 1 phải được chấp nhận.");
            Assert.AreEqual(1, luaChon, "Giá trị luaChon out ra phải bằng 1.");
        }

        [TestMethod] // Test giá trị biên trên hợp lệ
        public void KiemTraHopLe_ChonSo4_TraVeTrue()
        {
            // Nhập "4" -> Là biên hợp lệ lớn nhất -> Bắt buộc trả về True và luaChon = 4
            bool ketQua = XuLyThucDon.KiemTraHopLe("4", out int luaChon);

            Assert.IsTrue(ketQua, "Giá trị 4 phải được chấp nhận.");
            Assert.AreEqual(4, luaChon, "Giá trị luaChon out ra phải bằng 4.");
        }

        [TestMethod] // Test giá trị sát biên dưới (ngoại lệ)
        public void KiemTraHopLe_ChonSo0_TraVeFalse()
        {
            // Nhập "0" -> Là số nhưng < 1 (nằm ngoài khoảng [1,4]) -> Phải trả về False
            bool ketQua = XuLyThucDon.KiemTraHopLe("0", out int luaChon);

            Assert.IsFalse(ketQua, "Giá trị 0 nằm ngoài khoảng [1,4] nên phải bị từ chối.");
        }

        [TestMethod] // Test giá trị sát biên trên (ngoại lệ)
        public void KiemTraHopLe_ChonSo5_TraVeFalse()
        {
            // Nhập "5" -> Là số nhưng > 4 (nằm ngoài khoảng [1,4]) -> Phải trả về False
            bool ketQua = XuLyThucDon.KiemTraHopLe("5", out int luaChon);

            Assert.IsFalse(ketQua, "Giá trị 5 nằm ngoài khoảng [1,4] nên phải bị từ chối.");
        }

        [TestMethod] // Test nhập ký tự/chữ
        public void KiemTraHopLe_ChuoiKhongPhaiSo_TraVeFalse()
        {
            // Nhập "abc" -> Không thể ép kiểu sang số -> Phải xử lý an toàn và trả về False
            bool ketQua = XuLyThucDon.KiemTraHopLe("abc", out int luaChon);

            Assert.IsFalse(ketQua, "Chuỗi ký tự không phải số phải bị từ chối.");
        }

        [TestMethod] // Test trường hợp ấn Enter luôn (chuỗi rỗng)
        public void KiemTraHopLe_ChuoiRong_TraVeFalse()
        {
            // Nhập "" -> Không hợp lệ -> Trả về False
            bool ketQua = XuLyThucDon.KiemTraHopLe("", out int luaChon);

            Assert.IsFalse(ketQua, "Chuỗi rỗng không được chấp nhận.");
        }

        [TestMethod] // Test trường hợp Null (ví dụ nhấn Ctrl+Z khi nhập)
        public void KiemTraHopLe_InputNull_TraVeFalse()
        {
            // Truyền null -> Không được văng lỗi crash ứng dụng -> Trả về False
            bool ketQua = XuLyThucDon.KiemTraHopLe(null, out int luaChon);

            Assert.IsFalse(ketQua, "Dữ liệu null phải được xử lý an toàn và trả về False.");
        }

        [TestMethod] // Test số âm
        public void KiemTraHopLe_SoAm_TraVeFalse()
        {
            // Nhập "-1" -> Số âm không thuộc [1,4] -> Trả về False
            bool ketQua = XuLyThucDon.KiemTraHopLe("-1", out int luaChon);

            Assert.IsFalse(ketQua, "Số âm phải bị từ chối.");
        }

        
        // NHÓM 2: Kiểm thử hàm LayThongBao
        // Mục tiêu: Khớp đúng 100% nội dung chuỗi đầu ra và bắt lỗi khi nhận tham số sai
       

        [TestMethod]
        public void LayThongBao_ChonSo1_TraVeThongBaoTamGiac()
        {
            string thongBao = XuLyThucDon.LayThongBao(1);
            Assert.AreEqual("Ban moi vua chon chuc nang tinh dien tich tam giac.", thongBao);
        }

        [TestMethod]
        public void LayThongBao_ChonSo2_TraVeThongBaoHinhChuNhat()
        {
            string thongBao = XuLyThucDon.LayThongBao(2);
            Assert.AreEqual("Ban moi vua chon chuc nang tinh dien tich hinh chu nhat.", thongBao);
        }

        [TestMethod]
        public void LayThongBao_ChonSo3_TraVeThongBaoHinhTron()
        {
            string thongBao = XuLyThucDon.LayThongBao(3);
            Assert.AreEqual("Ban moi vua chon chuc nang tinh dien tich hinh tron.", thongBao);
        }

        [TestMethod]
        public void LayThongBao_ChonSo4_TraVeThongBaoThoat()
        {
            string thongBao = XuLyThucDon.LayThongBao(4);
            Assert.AreEqual("Ban moi vua chon chuc nang thoat chuong trinh.", thongBao);
        }

        [TestMethod]
        // [ExpectedException]: Đánh dấu Test này CHỈ PASS nếu hàm bên dưới ném đúng ngoại lệ ArgumentOutOfRangeException
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LayThongBao_LuaChonNgoaiKhoang_NemNgoaiLe()
        {
            // Truyền 10 -> Hàm phải chủ động quăng ngoại lệArgumentOutOfRangeException
            XuLyThucDon.LayThongBao(10);
        }

      
        // NHÓM 3: Kiểm thử hàm LaLuaChonThoat
        // Mục tiêu: Đảm bảo chỉ có số 4 mới được nhận diện là lệnh thoát
      

        [TestMethod]
        public void LaLuaChonThoat_ChonSo4_TraVeTrue()
        {
            // Số 4 -> Đúng là lệnh thoát -> True
            Assert.IsTrue(XuLyThucDon.LaLuaChonThoat(4));
        }

        [TestMethod]
        public void LaLuaChonThoat_ChonSo1_TraVeFalse()
        {
            // Số 1 -> Không phải lệnh thoát -> False
            Assert.IsFalse(XuLyThucDon.LaLuaChonThoat(1));
        }

        [TestMethod]
        public void LaLuaChonThoat_ChonSo2_TraVeFalse()
        {
            // Số 2 -> Không phải lệnh thoát -> False
            Assert.IsFalse(XuLyThucDon.LaLuaChonThoat(2));
        }

        [TestMethod]
        public void LaLuaChonThoat_ChonSo3_TraVeFalse()
        {
            // Số 3 -> Không phải lệnh thoát -> False
            Assert.IsFalse(XuLyThucDon.LaLuaChonThoat(3));
        }
    }
}

