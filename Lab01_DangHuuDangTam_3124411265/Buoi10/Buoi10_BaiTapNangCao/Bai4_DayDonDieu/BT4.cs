using System;

namespace Bai4_DayDonDieu
{
    public class BT4
    {
        // Hàm kiểm tra dãy có tăng dần hay không
        // Tăng dần: a[i] <= a[i + 1]
        public static bool KiemTraTangDan(double[] a)
        {
            // Duyệt từng cặp phần tử liên tiếp
            for (int i = 0; i < a.Length - 1; i++)
            {
                // Nếu phần tử trước lớn hơn phần tử sau
                // thì dãy không tăng dần
                if (a[i] > a[i + 1])
                {
                    return false;
                }
            }

            // Tất cả các phần tử đều thỏa mãn
            return true;
        }


        // Hàm kiểm tra dãy có giảm dần hay không
        // Giảm dần: a[i] >= a[i + 1]
        public static bool KiemTraGiamDan(double[] a)
        {
            // Duyệt từng cặp phần tử liên tiếp
            for (int i = 0; i < a.Length - 1; i++)
            {
                // Nếu phần tử trước nhỏ hơn phần tử sau
                // thì dãy không giảm dần
                if (a[i] < a[i + 1])
                {
                    return false;
                }
            }

            // Tất cả các phần tử đều thỏa mãn
            return true;
        }


        // Hàm kiểm tra dãy có đơn điệu hay không
        // Tức là tăng dần hoặc giảm dần
        public static bool KiemTraDonDieu(double[] a)
        {
            // Nếu tăng dần hoặc giảm dần
            // thì dãy là đơn điệu
            return KiemTraTangDan(a) || KiemTraGiamDan(a);
        }


        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 4: DAY DON DIEU =====");

            // Nhập số lượng phần tử
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra điều kiện của đề
            // 3 <= n <= 500
            if (n < 3 || n > 500)
            {
                Console.WriteLine("n phai thoa man 3 <= n <= 500!");
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

            // Kiểm tra tính đơn điệu
            if (KiemTraTangDan(a))
            {
                Console.WriteLine("Day so tang dan.");
            }
            else if (KiemTraGiamDan(a))
            {
                Console.WriteLine("Day so giam dan.");
            }
            else
            {
                Console.WriteLine("Day so khong don dieu.");
            }
        }
    }
}