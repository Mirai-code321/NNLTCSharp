using System;
using TinhCan;

namespace TinhCan.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            double a;
            int n;
            double kq;

            Console.Write("Nhap so thuc a: ");
            a = double.Parse(Console.ReadLine()!);
            Console.Write("Nhap so mu n: ");
            n = int.Parse(Console.ReadLine()!);

            kq = TinhCanBacN.TinhCan(a, n);

            Console.WriteLine("Can bac {0} cua {1} = {2:0.00}", n, a, kq);
            Console.Read();
        }
    }
}

