using System;

namespace GiaTriHamSo2
{
    public class Program
    {
        // Ham tinh toan thuan tuy - co the unit test duoc
        public static double TinhF(double a)
        {
            if (a <= 0.5)
            {
                return -0.5;
            }
            else if (a >= 1.5)
            {
                return 1;
            }
            else // 0.5 < a < 1.5
            {
                return -0.5 + 1.5 * (a - 0.5);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap so thuc a: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            double a = double.Parse(dongNhap);

            double ketQua = TinhF(a);

            Console.WriteLine("f({0}) = {1:0.####}.", a, ketQua);
        }
    }
}

