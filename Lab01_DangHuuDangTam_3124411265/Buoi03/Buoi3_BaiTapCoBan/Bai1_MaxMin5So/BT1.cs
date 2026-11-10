using System;

namespace MaxMin5So
{
    public class Program
    {
        // Ham tinh toan thuan tuy - co the unit test duoc
        public static (int max, int min) TimMaxMin(int a, int b, int c, int d, int e)
        {
            int max = a;
            int min = a;

            if (b > max) max = b;
            if (c > max) max = c;
            if (d > max) max = d;
            if (e > max) max = e;

            if (b < min) min = b;
            if (c < min) min = c;
            if (d < min) min = d;
            if (e < min) min = e;

            return (max, min);
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap 5 so a, b, c, d ,e: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            string[] input = dongNhap.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int c = int.Parse(input[2]);
            int d = int.Parse(input[3]);
            int e = int.Parse(input[4]);

            var (max, min) = TimMaxMin(a, b, c, d, e);

            Console.WriteLine("Gia tri lon nhat cua {0}, {1}, {2}, {3}, {4} la {5}.", a, b, c, d, e, max);
            Console.WriteLine("Gia tri nho nhat cua {0}, {1}, {2}, {3}, {4} la {5}.", a, b, c, d, e, min);
        }
    }
}

