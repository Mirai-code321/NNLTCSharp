using System;

namespace Bai4_GiaiHePhuongTrinh
{
    public class BT4
    {
        // Hàm giải hệ phương trình:
        // ax + by = c
        // dx + ey = f
        public static string GiaiHePhuongTrinh(
            double a, double b, double c,
            double d, double e, double f)
        {
            // Tính định thức D
            double D = a * e - b * d;

            // Tính Dx và Dy theo quy tắc Cramer
            double Dx = c * e - b * f;
            double Dy = a * f - c * d;

            // Trường hợp D khác 0:
            // Hệ có duy nhất một nghiệm
            if (D != 0)
            {
                double x = Dx / D;
                double y = Dy / D;

                return $"He co nghiem duy nhat: x = {x}, y = {y}";
            }

            // Trường hợp D = 0 và Dx = Dy = 0:
            // Hệ có vô số nghiệm
            if (Dx == 0 && Dy == 0)
            {
                return "He co vo so nghiem";
            }

            // Trường hợp D = 0 nhưng Dx hoặc Dy khác 0:
            // Hệ vô nghiệm
            return "He vo nghiem";
        }

        // Hàm Main để nhập dữ liệu và xuất kết quả
        public static void Main(string[] args)
        {
            // Nhập 6 hệ số
            Console.Write("Nhap a: ");
            double a = double.Parse(Console.ReadLine()!);

            Console.Write("Nhap b: ");
            double b = double.Parse(Console.ReadLine()!);

            Console.Write("Nhap c: ");
            double c = double.Parse(Console.ReadLine()!);

            Console.Write("Nhap d: ");
            double d = double.Parse(Console.ReadLine()!);

            Console.Write("Nhap e: ");
            double e = double.Parse(Console.ReadLine()!);

            Console.Write("Nhap f: ");
            double f = double.Parse(Console.ReadLine()!);

            // Gọi hàm giải hệ phương trình
            string ketQua = GiaiHePhuongTrinh(a, b, c, d, e, f);

            // Xuất kết quả
            Console.WriteLine(ketQua);
        }
    }
}