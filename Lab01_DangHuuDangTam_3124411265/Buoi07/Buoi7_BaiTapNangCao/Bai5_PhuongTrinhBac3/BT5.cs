using System;

namespace Bai5_PhuongTrinhBac3
{
    public class BT5
    {
        // Hàm tính căn bậc ba của một số thực
        // Không sử dụng Math.Cbrt()
        public static double CanBacBa(double x)
        {
            if (x == 0)
                return 0;

            double dau = x < 0 ? -1 : 1;
            double giaTri = Math.Abs(x);

            // Newton-Raphson để tính căn bậc ba
            double ketQua = giaTri;

            for (int i = 0; i < 50; i++)
            {
                ketQua = (2 * ketQua + giaTri / (ketQua * ketQua)) / 3;
            }

            return dau * ketQua;
        }

        // Hàm giải phương trình bậc 3:
        // ax^3 + bx^2 + cx + d = 0
        public static string GiaiPhuongTrinhBac3(
            double a, double b, double c, double d)
        {
            // Kiểm tra điều kiện a khác 0
            if (a == 0)
            {
                return "a phai khac 0";
            }

            // Đưa phương trình về dạng:
            // x^3 + A*x^2 + B*x + C = 0
            double A = b / a;
            double B = c / a;
            double C = d / a;

            // Đưa về phương trình:
            // y^3 + p*y + q = 0
            double p = B - A * A / 3;
            double q = 2 * A * A * A / 27
                       - A * B / 3
                       + C;

            // Tính Delta
            double delta = q * q / 4 + p * p * p / 27;

            // Sai số cho số thực
            double epsilon = 1e-10;

            // =====================================================
            // TRƯỜNG HỢP 1: Delta > 0
            // Phương trình có 1 nghiệm thực
            // =====================================================
            if (delta > epsilon)
            {
                double canDelta = Math.Sqrt(delta);

                double u = CanBacBa(-q / 2 + canDelta);
                double v = CanBacBa(-q / 2 - canDelta);

                double x = u + v - A / 3;

                return $"Phuong trinh co 1 nghiem thuc: x = {x}";
            }

            // =====================================================
            // TRƯỜNG HỢP 2: Delta = 0
            // Phương trình có nghiệm kép
            // =====================================================
            if (Math.Abs(delta) <= epsilon)
            {
                // Trường hợp có nghiệm ba
                if (Math.Abs(p) <= epsilon &&
                    Math.Abs(q) <= epsilon)
                {
                    double x = -A / 3;

                    return $"Phuong trinh co nghiem kep ba: x = {x}";
                }

                // Trường hợp có 2 nghiệm thực phân biệt,
                // trong đó có 1 nghiệm kép
                double u = CanBacBa(-q / 2);

                double x1 = 2 * u - A / 3;
                double x2 = -u - A / 3;

                return $"Phuong trinh co 2 nghiem thuc: x1 = {x1}, x2 = {x2} (x2 la nghiem kep)";
            }

            // =====================================================
            // TRƯỜNG HỢP 3: Delta < 0
            // Phương trình có 3 nghiệm thực phân biệt
            // =====================================================

            // Tính góc theta
            double theta = Math.Acos(
                (3 * q / (2 * p)) * Math.Sqrt(-3 / p)
            );

            // Tính bán kính
            double r = 2 * Math.Sqrt(-p / 3);

            // Tính 3 nghiệm
            double x1_3 = r * Math.Cos(theta / 3) - A / 3;

            double x2_3 = r * Math.Cos(
                (theta + 2 * Math.PI) / 3
            ) - A / 3;

            double x3_3 = r * Math.Cos(
                (theta + 4 * Math.PI) / 3
            ) - A / 3;

            return $"Phuong trinh co 3 nghiem thuc phan biet: x1 = {x1_3}, x2 = {x2_3}, x3 = {x3_3}";
        }

        // Hàm Main
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 5: GIAI PHUONG TRINH BAC 3 =====");

            // Nhập hệ số a
            Console.Write("Nhap a: ");
            double a = double.Parse(Console.ReadLine()!);

            // Nhập hệ số b
            Console.Write("Nhap b: ");
            double b = double.Parse(Console.ReadLine()!);

            // Nhập hệ số c
            Console.Write("Nhap c: ");
            double c = double.Parse(Console.ReadLine()!);

            // Nhập hệ số d
            Console.Write("Nhap d: ");
            double d = double.Parse(Console.ReadLine()!);

            // Kiểm tra điều kiện a khác 0
            if (a == 0)
            {
                Console.WriteLine("a phai khac 0!");
                return;
            }

            // Gọi hàm giải phương trình
            string ketQua = GiaiPhuongTrinhBac3(a, b, c, d);

            // Xuất kết quả
            Console.WriteLine(ketQua);
        }
    }
}