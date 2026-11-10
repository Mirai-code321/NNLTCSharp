using System;

namespace ChuSoLonNhat
{
    public class Program
    {
        // Ham tinh toan thuan tuy - co the unit test duoc
        public static int TimChuSoLonNhat(int n)
        {
            int max = 0;

            while (n > 0)
            {
                int chuSo = n % 10;
                if (chuSo > max)
                {
                    max = chuSo;
                }
                n = n / 10;
            }

            return max;
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap n (4 chu so): ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            int n = int.Parse(dongNhap);

            int chuSoLonNhat = TimChuSoLonNhat(n);

            Console.WriteLine("Chu so lon nhat cua {0} la {1}.", n, chuSoLonNhat);
        }
    }
}

