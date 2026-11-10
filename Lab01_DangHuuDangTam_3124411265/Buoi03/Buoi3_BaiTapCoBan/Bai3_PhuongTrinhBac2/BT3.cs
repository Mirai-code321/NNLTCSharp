using System;

namespace PhuongTrinhBac2
{
    public class Program
    {
        // soNghiem: -1 = vo so nghiem, 0 = vo nghiem, 1 = nghiem kep/1 nghiem, 2 = hai nghiem phan biet
        public static (int soNghiem, double x1, double x2) GiaiPhuongTrinhBac2(double a, double b, double c)
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                        return (-1, 0, 0); // vo so nghiem
                    else
                        return (0, 0, 0);  // vo nghiem
                }
                else
                {
                    double x = -c / b;
                    return (1, x, x); // phuong trinh bac 1
                }
            }

            double delta = b * b - 4 * a * c;

            if (delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                return (2, x1, x2);
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                return (1, x, x);
            }
            else
            {
                return (0, 0, 0); // vo nghiem thuc
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap he so a, b, c: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            string[] input = dongNhap.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double a = double.Parse(input[0]);
            double b = double.Parse(input[1]);
            double c = double.Parse(input[2]);

            var (soNghiem, x1, x2) = GiaiPhuongTrinhBac2(a, b, c);

            string veTrai = string.Format("{0}x^2 + {1}x + {2}", a, b, c);

            if (soNghiem == -1)
            {
                Console.WriteLine("Phuong trinh bac 2 {0} = 0 co vo so nghiem.", veTrai);
            }
            else if (soNghiem == 0)
            {
                Console.WriteLine("Phuong trinh bac 2 {0} = 0 vo nghiem.", veTrai);
            }
            else if (soNghiem == 1)
            {
                Console.WriteLine("Phuong trinh bac 2 {0} = 0 co: 1 nghiem, x = {1:0.00}.", veTrai, x1);
            }
            else
            {
                Console.WriteLine("Phuong trinh bac 2 {0} = 0 co: 2 nghiem, x1 = {1:0.00}, x2 = {2:0.00}.", veTrai, x1, x2);
            }
        }
    }
}

