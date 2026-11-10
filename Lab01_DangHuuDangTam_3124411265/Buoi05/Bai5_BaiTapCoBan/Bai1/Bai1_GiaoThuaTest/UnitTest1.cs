using Xunit;              // Thư viện xUnit, cung cấp [Fact] và Assert để viết test
using Bai1_GiaiThua;       // Import namespace chứa class GiaiThua cần test

namespace Bai1_GiaoThuaTest
{
    // Trong xUnit, không cần gắn attribute [TestClass] như MSTest
    // Chỉ cần là 1 class public bình thường là xUnit tự nhận diện được
    public class UnitTest1
    {
        // [Fact] đánh dấu đây là 1 test case, không nhận tham số đầu vào
        // Khi gõ "dotnet test", xUnit sẽ tự động chạy tất cả hàm có [Fact]
        [Fact]
        public void Test_GiaiThua_5()
        {
            // Arrange: chuẩn bị dữ liệu đầu vào và kết quả mong đợi
            int n = 5;
            long ketQuaMongDoi = 120;

            // Act: gọi hàm cần kiểm tra (hàm Tinh() trong class GiaiThua)
            long ketQua = GiaiThua.Tinh(n);

            // Assert: so sánh kết quả thực tế (ketQua) với kết quả mong đợi (ketQuaMongDoi)
            // Assert.Equal(giá trị mong đợi, giá trị thực tế)
            // Nếu 2 giá trị khác nhau, test sẽ FAIL và báo lỗi ngay dòng này
            Assert.Equal(ketQuaMongDoi, ketQua);
        }

        [Fact]
        public void Test_GiaiThua_1()
        {
            // Test trường hợp biên: n = 1 (giá trị nhỏ nhất được phép theo đề bài)
            // 1! = 1
            Assert.Equal(1, GiaiThua.Tinh(1));
        }

        [Fact]
        public void Test_GiaiThua_12()
        {
            // Test trường hợp biên: n = 12 (giá trị lớn nhất được phép theo đề bài)
            // 12! = 479001600 — số khá lớn, nếu hàm Tinh() dùng kiểu int thay vì long sẽ bị tràn số
            Assert.Equal(479001600, GiaiThua.Tinh(12));
        }

        [Fact]
        public void Test_GiaiThua_3()
        {
            // Test trường hợp bình thường: n = 3
            // 3! = 1 x 2 x 3 = 6
            Assert.Equal(6, GiaiThua.Tinh(3));
        }

        [Fact]
        public void Test_GiaiThua_NgoaiKhoang_0()
        {
            // Test trường hợp ngoại lệ: n = 0, nhỏ hơn giới hạn cho phép (1 <= n <= 12)
            // Assert.Throws<Kiểu lỗi>(() => hành động cần kiểm tra)
            // Nghĩa là: khi gọi GiaiThua.Tinh(0), hàm PHẢI ném ra ArgumentOutOfRangeException
            // Nếu hàm KHÔNG ném lỗi (hoặc ném sai loại lỗi), test sẽ FAIL
            Assert.Throws<ArgumentOutOfRangeException>(() => GiaiThua.Tinh(0));
        }

        [Fact]
        public void Test_GiaiThua_NgoaiKhoang_13()
        {
            // Test trường hợp ngoại lệ: n = 13, lớn hơn giới hạn cho phép (1 <= n <= 12)
            Assert.Throws<ArgumentOutOfRangeException>(() => GiaiThua.Tinh(13));
        }

        [Fact]
        public void Test_ChuoiPhepTinh_5()
        {
            // Test hàm TaoChuoiPhepTinh() — hàm tạo chuỗi hiển thị dạng "1.2.3.4.5"
            // Với n = 5, kết quả mong đợi là chuỗi "1.2.3.4.5"
            Assert.Equal("1.2.3.4.5", GiaiThua.TaoChuoiPhepTinh(5));
        }

        [Fact]
        public void Test_ChuoiPhepTinh_1()
        {
            // Test trường hợp biên: n = 1 thì chuỗi chỉ có mỗi số "1", không có dấu chấm nào
            Assert.Equal("1", GiaiThua.TaoChuoiPhepTinh(1));
        }
    }
}

