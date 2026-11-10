using Xunit;
using NNLTCSharp.Buoi02;

namespace NNLTCSharp.Tests
{
    public class UnitTestNamTrong
    {
        [Fact]
        public void Test_Diem_Nam_Giua_TamGiac()
        {
            bool ketQua = NamTrong.KiemTra(0, 0.5);

            Assert.True(ketQua);
        }

        [Fact]
        public void Test_Diem_Nam_Ngoai_TamGiac()
        {
            bool ketQua = NamTrong.KiemTra(1, 0.5);

            Assert.False(ketQua);
        }

        [Fact]
        public void Test_Diem_Nam_Tren_Bien()
        {
            bool ketQua = NamTrong.KiemTra(0, 1);

            Assert.True(ketQua);
        }

        [Fact]
        public void Test_Diem_Nam_Duoi_Day()
        {
            bool ketQua = NamTrong.KiemTra(0, -0.1);

            Assert.False(ketQua);
        }

        [Fact]
        public void Test_Diem_Nam_Tren_Canh_Trai()
        {
            bool ketQua = NamTrong.KiemTra(-0.5, 0.5);

            Assert.True(ketQua);
        }
    }
}

