using System;
using DoiSangGiay;

namespace DoiSangGiay.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap so gio:");
            int h = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap so phut: ");
            int m = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap so giay: ");
            int s = int.Parse(Console.ReadLine() ?? "0");

            int tongGiay = ChuyenDoi.TinhTongGiay(h, m, s);

            Console.WriteLine("Tong so giay cua {0}:{1}:{2} la {3} giay", h, m, s, tongGiay);
            Console.Read();
        }
    }
}