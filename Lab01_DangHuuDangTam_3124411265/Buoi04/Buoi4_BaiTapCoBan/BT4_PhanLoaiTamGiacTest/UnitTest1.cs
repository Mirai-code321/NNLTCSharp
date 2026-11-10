using Xunit;
using NNLTCSharp.Buoi3;

namespace NNLTCSharp.Tests
{
    public class UnitTestLoaiTamGiac
    {
        [Fact]
        public void Test_TamGiacThuong()
        {
            string ketQua = LoaiTamGiac.KiemTraTamGiac(4, 5, 6);

            Assert.Equal("Tam giac thuong", ketQua);
        }

        [Fact]
        public void Test_TamGiacCan()
        {
            string ketQua = LoaiTamGiac.KiemTraTamGiac(5, 5, 6);

            Assert.Equal("Tam giac can", ketQua);
        }

        [Fact]
        public void Test_TamGiacVuong()
        {
            string ketQua = LoaiTamGiac.KiemTraTamGiac(3, 4, 5);

            Assert.Equal("Tam giac vuong", ketQua);
        }

        [Fact]
        public void Test_TamGiacVuongCan()
        {
            string ketQua = LoaiTamGiac.KiemTraTamGiac(1, 1, Math.Sqrt(2));

            Assert.Equal("Tam giac vuong can", ketQua);
        }

        [Fact]
        public void Test_TamGiacDeu()
        {
            string ketQua = LoaiTamGiac.KiemTraTamGiac(5, 5, 5);

            Assert.Equal("Tam giac deu", ketQua);
        }

        [Fact]
        public void Test_KhongPhaiTamGiac()
        {
            string ketQua = LoaiTamGiac.KiemTraTamGiac(1, 2, 5);

            Assert.Equal("Khong phai tam giac", ketQua);
        }
    }
}

