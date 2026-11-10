using System;
using DaoSo;

namespace DaoSo.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            int x, y;

            Console.Write("Nhap so nguyen x (co bon chu so): ");
            x = int.Parse(Console.ReadLine()!);

            y = SoDao.TinhSoDao(x);

            Console.WriteLine("x = {0}", x);
            Console.WriteLine("y (so dao cua x) = {0}", y);
            Console.Read();
        }
    }
}

