using System;

namespace Bai2_BangCuuChuong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // In tiêu đề chương trình ra màn hình Console
            Console.WriteLine("BANG CUU CHUONG\n");

            // Gọi đúng tên class InBangCuuChuongService ở file BangCuuChuong.cs
            string result = InBangCuuChuongService.TaoBangCuuChuong();

            // In toàn bộ chuỗi bảng cửu chương ra màn hình
            Console.WriteLine(result);
        }
    }
}