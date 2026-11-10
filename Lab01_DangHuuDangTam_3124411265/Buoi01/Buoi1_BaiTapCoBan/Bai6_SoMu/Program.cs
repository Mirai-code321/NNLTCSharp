using System;
using TinhMu;

namespace TinhMu.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap so thuc a: ");
            double a = double.Parse(Console.ReadLine()!);
            Console.Write("Nhap so mu n: ");
            int n = int.Parse(Console.ReadLine()!);

            double kq = HamMu.TinhLuyThua(a, n);

            Console.WriteLine("Ket qua {0}^{1} = {2}", a, n, kq);
            Console.Read();
        }
    }
}
