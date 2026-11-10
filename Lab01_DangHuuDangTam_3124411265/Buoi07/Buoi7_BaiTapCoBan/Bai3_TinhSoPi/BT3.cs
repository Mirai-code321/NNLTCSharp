using System;

namespace TinhSoPi
{
    public class Program
    {
        // Ham tinh so pi bang cong thuc Leibniz, dung khi so hang tiep theo < epsilon
        // Tra ve: (gia tri pi tinh duoc, sai so thuc te so voi Math.PI)
        public static (double piTinhDuoc, double saiSoThucTe) TinhPi(double epsilon)
        {
            double tong = 0;
            int n = 0;

            // Lap: cong tung so hang 4/(2n+1) voi dau xen ke (+, -, +, -, ...)
            // Dieu kien dung: khi so hang tiep theo (4/(2n+1)) nho hon epsilon thi dung lai
            while (4.0 / (2 * n + 1) >= epsilon)
            {
                double soHang = 4.0 / (2 * n + 1);

                // n chan -> dau cong (+), n le -> dau tru (-)
                if (n % 2 == 0)
                {
                    tong += soHang;
                }
                else
                {
                    tong -= soHang;
                }

                n++;
            }

            double piTinhDuoc = tong;

            // Sai so thuc te = khoang cach giua gia tri tinh duoc va gia tri pi chinh xac cua he thong
            double saiSoThucTe = Math.Abs(piTinhDuoc - Math.PI);

            return (piTinhDuoc, saiSoThucTe);
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap do sai so epsilon: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            double epsilon = double.Parse(dongNhap);

            var (piTinhDuoc, saiSoThucTe) = TinhPi(epsilon);

            Console.WriteLine("So pi tinh den do chinh xac {0} la {1}.", epsilon, piTinhDuoc);
            Console.WriteLine("Do sai so thuc te la {0}.", saiSoThucTe);
        }
    }
}