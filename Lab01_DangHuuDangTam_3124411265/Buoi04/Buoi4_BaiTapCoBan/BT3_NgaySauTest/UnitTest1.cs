using Xunit;
using NNLTCSharp.Buoi3;

namespace NNLTCSharp.Tests
{
    public class UnitTestNgaySauDo
    {
        [Fact]
        public void Test_NgayBinhThuong()
        {
            string ketQua = NgaySauDo.TinhNgaySau(15, 1, 2015);

            Assert.Equal("16/1/2015", ketQua);
        }

        [Fact]
        public void Test_NgayCuoiThang31()
        {
            string ketQua = NgaySauDo.TinhNgaySau(31, 1, 2015);

            Assert.Equal("1/2/2015", ketQua);
        }

        [Fact]
        public void Test_NgayCuoiThang30()
        {
            string ketQua = NgaySauDo.TinhNgaySau(30, 4, 2015);

            Assert.Equal("1/5/2015", ketQua);
        }

        [Fact]
        public void Test_NgayCuoiThang2_NamKhongNhuan()
        {
            string ketQua = NgaySauDo.TinhNgaySau(28, 2, 2015);

            Assert.Equal("1/3/2015", ketQua);
        }

        [Fact]
        public void Test_NgayCuoiThang2_NamNhuan()
        {
            string ketQua = NgaySauDo.TinhNgaySau(29, 2, 2016);

            Assert.Equal("1/3/2016", ketQua);
        }

        [Fact]
        public void Test_NgayCuoiNam()
        {
            string ketQua = NgaySauDo.TinhNgaySau(31, 12, 2015);

            Assert.Equal("1/1/2016", ketQua);
        }
    }
}

