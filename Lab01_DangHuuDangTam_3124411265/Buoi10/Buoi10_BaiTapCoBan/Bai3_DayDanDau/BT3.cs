using System;

namespace Bai3_DayDanDau
{
    public class BT3
    {
        // Hàm kiểm tra dãy số có phải là dãy đan dấu hay không
        public static bool KiemTraDayDanDau(double[] a)
        {
            // Duyệt qua từng cặp phần tử liên tiếp
            for (int i = 0; i < a.Length - 1; i++)
            {
                // Hai phần tử phải khác 0
                // và phải trái dấu nhau
                if (a[i] * a[i + 1] >= 0)
                {
                    // Nếu có một cặp không trái dấu
                    // thì dãy không phải dãy đan dấu
                    return false;
                }
            }

            // Tất cả các cặp đều trái dấu
            // nên đây là dãy đan dấu
            return true;
        }

        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 3: DAY DAN DAU =====");

            // Nhập số lượng phần tử
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra n
            if (n <= 0 || n > 500)
            {
                Console.WriteLine("n phai nam trong khoang 1 den 500!");
                return;
            }

            // Khởi tạo mảng
            double[] a = new double[n];

            // Nhập dãy số
            Console.WriteLine("Nhap day so:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = double.Parse(Console.ReadLine()!);
            }

            // Kiểm tra dãy có đan dấu hay không
            bool ketQua = KiemTraDayDanDau(a);

            // Xuất kết quả
            if (ketQua)
            {
                Console.WriteLine("Day so tren la day dan dau.");
            }
            else
            {
                Console.WriteLine("Day so tren khong phai la day dan dau.");
            }
        }
    }
}