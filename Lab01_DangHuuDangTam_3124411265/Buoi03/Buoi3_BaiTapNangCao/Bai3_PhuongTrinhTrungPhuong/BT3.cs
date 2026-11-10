using System;
using System.Collections.Generic;
using System.Linq;

namespace PhuongTrinhTrungPhuong
{
    public class Program
    {
        // Tra ve null neu vo so nghiem (a=b=c=0)
        // Tra ve mang rong neu vo nghiem thuc
        // Nguoc lai tra ve mang cac nghiem x, da sap xep tang dan
        public static double[]? GiaiPhuongTrinhTrungPhuong(double a, double b, double c)
        {
            List<double> danhSachT = new List<double>();

            if (a == 0)
            {
                // Phuong trinh tro thanh: b*t + c = 0
                if (b == 0)
                {
                    if (c == 0)
                        return null; // vo so nghiem
                    else
                        return Array.Empty<double>(); // vo nghiem
                }
                else
                {
                    danhSachT.Add(-c / b);
                }
            }
            else
            {
                // Phuong trinh bac 2 theo t: a*t^2 + b*t + c = 0
                double delta = b * b - 4 * a * c;

                if (delta > 0)
                {
                    double t1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double t2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    danhSachT.Add(t1);
                    danhSachT.Add(t2);
                }
                else if (delta == 0)
                {
                    danhSachT.Add(-b / (2 * a));
                }
                // delta < 0: khong co t thuc, danhSachT rong
            }

            // Voi moi t >= 0, suy ra nghiem x = +-sqrt(t)
            List<double> danhSachX = new List<double>();
            foreach (double t in danhSachT)
            {
                if (t > 0)
                {
                    danhSachX.Add(Math.Sqrt(t));
                    danhSachX.Add(-Math.Sqrt(t));
                }
                else if (t == 0)
                {
                    danhSachX.Add(0);
                }
                // t < 0: bo qua, khong co nghiem thuc tuong ung
            }

            return danhSachX.Distinct().OrderBy(x => x).ToArray();
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

            double[]? nghiem = GiaiPhuongTrinhTrungPhuong(a, b, c);

            string veTrai = string.Format("{0}x^4 + {1}x^2 + {2}", a, b, c);

            if (nghiem == null)
            {
                Console.WriteLine("Phuong trinh trung phuong {0} = 0 co vo so nghiem.", veTrai);
            }
            else if (nghiem.Length == 0)
            {
                Console.WriteLine("Phuong trinh trung phuong {0} = 0 vo nghiem.", veTrai);
            }
            else
            {
                string cacNghiem = string.Join(", ", nghiem.Select((x, i) => string.Format("x{0} = {1:0.00}", i + 1, x)));
                Console.WriteLine("Phuong trinh trung phuong {0} = 0 co: {1} nghiem, {2}.", veTrai, nghiem.Length, cacNghiem);
            }
        }
    }
}

