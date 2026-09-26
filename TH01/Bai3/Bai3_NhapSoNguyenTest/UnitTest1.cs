using System;
using System.IO;
using System.Numerics;
using Xunit;
using Bai3_NhapSoNguyen.App;
using Bai3_NhapSoNguyen.Lib;

namespace Bai3_NhapSoNguyen.Tests
{
    // Test thẳng vào hàm Tinh()
    public class LuyThuaTests
    {
        [Theory]
        [InlineData(7, 3, "343")]                                   // TC1 ví dụ đề bài
        [InlineData(2, 10, "1024")]                                 // TC2
        [InlineData(5, 0, "1")]                                     // TC3 mũ 0
        [InlineData(0, 5, "0")]                                     // TC4 cơ số 0
        [InlineData(0, 0, "1")]                                     // TC5 quy ước 0^0 = 1
        [InlineData(1, 100, "1")]                                   // TC6
        [InlineData(-2, 3, "-8")]                                   // TC7 cơ số âm, mũ lẻ
        [InlineData(-2, 4, "16")]                                   // TC8 cơ số âm, mũ chẵn
        [InlineData(10, 10, "10000000000")]                         // TC9 vượt int
        [InlineData(2, 100, "1267650600228229401496703205376")]     // TC10 số rất lớn
        public void Tinh_SoMuKhongAm_DungKetQua(int x, int y, string mongDoi)
        {
            LuyThua lt = new LuyThua(x, y);
            Assert.Equal(BigInteger.Parse(mongDoi), lt.Tinh());
        }

        [Fact]
        public void Tinh_SoMuAm_NemNgoaiLe()                        // TC11
        {
            LuyThua lt = new LuyThua(2, -3);
            Assert.Throws<ArgumentOutOfRangeException>(() => lt.Tinh());
        }
    }

    // Chạy Main với input giả, kiểm tra đúng chuỗi in ra màn hình
    public class ProgramTests
    {
        private static string ChayVoiInput(string input)
        {
            TextReader inCu = Console.In;
            TextWriter outCu = Console.Out;
            StringWriter ketQua = new StringWriter();
            try
            {
                Console.SetIn(new StringReader(input));
                Console.SetOut(ketQua);
                Program.Main(new string[0]);
            }
            finally
            {
                // trả lại console gốc để không ảnh hưởng test khác
                Console.SetIn(inCu);
                Console.SetOut(outCu);
            }
            return ketQua.ToString();
        }

        [Theory]
        [InlineData("7\n3\n", "Ket qua 7 mu 3 la: 343")]            // TC1 kiểm tra đúng định dạng đề
        [InlineData("2\n-3\n", "Loi: y phai la so khong am")]       // TC11
        [InlineData("abc\n", "Loi: x khong phai so nguyen")]        // TC12
        [InlineData("2\n3.5\n", "Loi: y khong phai so nguyen")]     // TC13
        [InlineData("2147483648\n", "Loi: x khong phai so nguyen")] // TC14 vượt int
        public void Main_InRaDungThongBao(string input, string dongMongDoi)
        {
            string ketQua = ChayVoiInput(input);
            Assert.Contains(dongMongDoi, ketQua);
        }
    }
}