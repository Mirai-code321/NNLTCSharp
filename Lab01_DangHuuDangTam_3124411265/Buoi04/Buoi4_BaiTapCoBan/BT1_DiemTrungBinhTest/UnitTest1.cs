using Xunit;
using NNLTCSharp.Buoi3;

namespace NNLTCSharp.Tests
{
    public class UnitTestDiemTrungBinh
    {
        [Fact]
        public void Test_DiemTrungBinh()
        {
            double ketQua = DiemTrungBinh.TinhDiemTrungBinh(7, 6, 8);

            Assert.Equal(6.67, ketQua, 2);
        }

        [Fact]
        public void Test_XepLoai_Gioi()
        {
            Assert.Equal("Gioi", DiemTrungBinh.XepLoai(8));
        }

        [Fact]
        public void Test_XepLoai_Kha()
        {
            Assert.Equal("Kha", DiemTrungBinh.XepLoai(6.5));
        }

        [Fact]
        public void Test_XepLoai_TrungBinh()
        {
            Assert.Equal("Trung binh", DiemTrungBinh.XepLoai(5));
        }

        [Fact]
        public void Test_XepLoai_Yeu()
        {
            Assert.Equal("Yeu", DiemTrungBinh.XepLoai(4.99));
        }
    }
}

