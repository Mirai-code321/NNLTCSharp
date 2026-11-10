using System;

namespace GiaTriHamSo1
{
    public class Program
    {
        // Ham tinh toan thuan tuy - co the unit test duoc
        public static double TinhF1(double x)
        {
            if (x <= 0)
            {
                return 0;
            }
            else if (x <= 1) // 0 < x <= 1
            {
                return x;
            }
            else // x > 1
            {
                return x * x * x * x;
            }
        }

        public static double TinhF2(double x)
        {
            if (x <= 2)
            {
                return x * x + 4 * x + 5;
            }
            else // x > 2
            {
                return 1 / (x * x + 4 * x + 5);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap so thuc x: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            double x = double.Parse(dongNhap);

            double f1 = TinhF1(x);
            double f2 = TinhF2(x);

            Console.WriteLine("f1({0}) = {1:0.##}.", x, f1);
            Console.WriteLine("f2({0}) = {1:0.####}.", x, f2);
        }
    }
}

