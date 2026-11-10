using System;

namespace TongDoan
{
    public class Program
    {
        // Hàm tính toán thuần túy - có thể unit test được
        public static long TinhTongDoan(int a, int b)
        {
            long tong = 0;
            for (int i = a; i <= b; i++)
            {
                tong = tong + i;
            }
            return tong;
        }

        static void Main(string[] args)
        {
            int a, b;

            Console.Write("Moi ban nhap so a, b: ");
            string[] input = Console.ReadLine()!.Split(' ');
            a = int.Parse(input[0]);
            b = int.Parse(input[1]);

            long tong = TinhTongDoan(a, b);

            Console.WriteLine("Tong cua cac so trong doan[{0}, {1}] la {2}.", a, b, tong);
        }
    }
}




