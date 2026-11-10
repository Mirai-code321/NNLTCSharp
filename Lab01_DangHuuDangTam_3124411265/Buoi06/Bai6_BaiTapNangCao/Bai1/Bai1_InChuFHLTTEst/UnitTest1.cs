using Xunit;
using InChuFHLT;

namespace Bai1_InChuFHLTTests
{
    public class ChuFHLTTests
    {
        [Fact]
        public void InChuF_ChieuCao5_Co5Dong()
        {
            // Tạo hình chữ F với chiều cao 5
            string ketQua = new ChuFHLT().InChuF(5);

            // Tách các dòng để kiểm tra
            string[] dong = ketQua.TrimEnd('\n').Split('\n');

            // Hình phải có đúng 5 dòng
            Assert.Equal(5, dong.Length);
        }

        [Fact]
        public void InChuH_ChieuCao5_Co5Dong()
        {
            // Tạo hình chữ H với chiều cao 5
            string ketQua = new ChuFHLT().InChuH(5);

            string[] dong = ketQua.TrimEnd('\n').Split('\n');

            // Hình phải có đúng 5 dòng
            Assert.Equal(5, dong.Length);
        }

        [Fact]
        public void InChuL_ChieuCao5_Co5Dong()
        {
            // Tạo hình chữ L với chiều cao 5
            string ketQua = new ChuFHLT().InChuL(5);

            string[] dong = ketQua.TrimEnd('\n').Split('\n');

            // Hình phải có đúng 5 dòng
            Assert.Equal(5, dong.Length);
        }

        [Fact]
        public void InChuT_ChieuCao5_Co5Dong()
        {
            // Tạo hình chữ T với chiều cao 5
            string ketQua = new ChuFHLT().InChuT(5);

            string[] dong = ketQua.TrimEnd('\n').Split('\n');

            // Hình phải có đúng 5 dòng
            Assert.Equal(5, dong.Length);
        }

        [Fact]
        public void InChuF_ChieuCao3_Co3Dong()
        {
            // Kiểm tra trường hợp chiều cao nhỏ
            string ketQua = new ChuFHLT().InChuF(3);

            string[] dong = ketQua.TrimEnd('\n').Split('\n');

            Assert.Equal(3, dong.Length);
        }

        [Fact]
        public void InChuL_ChieuCao7_Co7Dong()
        {
            // Kiểm tra chữ L với chiều cao 7
            string ketQua = new ChuFHLT().InChuL(7);

            string[] dong = ketQua.TrimEnd('\n').Split('\n');

            Assert.Equal(7, dong.Length);
        }
    }
}