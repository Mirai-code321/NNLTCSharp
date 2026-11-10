using System;

namespace Bai5_NamTrong
{
    public class BT5
    {
        // Hàm kiểm tra tất cả phần tử của mảng a
        // có nằm trong mảng b hay không
        public static bool KiemTraNamTrong(double[] a, double[] b)
        {
            // Duyệt từng phần tử của mảng a
            for (int i = 0; i < a.Length; i++)
            {
                // Biến đánh dấu phần tử a[i] có trong b hay chưa
                bool timThay = false;

                // Tìm a[i] trong mảng b
                for (int j = 0; j < b.Length; j++)
                {
                    // Nếu tìm thấy phần tử giống nhau
                    if (a[i] == b[j])
                    {
                        timThay = true;
                        break;
                    }
                }

                // Nếu có một phần tử của a không nằm trong b
                // thì kết luận ngay là false
                if (!timThay)
                {
                    return false;
                }
            }

            // Tất cả phần tử của a đều nằm trong b
            return true;
        }


        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 5: NAM TRONG =====");

            // -------------------------------
            // Nhập số phần tử của mảng a
            // -------------------------------
            Console.Write("Nhap n (mang a): ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra n
            if (n <= 0 || n > 500)
            {
                Console.WriteLine("n phai nam trong khoang 1 den 500!");
                return;
            }

            // Khởi tạo mảng a
            double[] a = new double[n];

            // Nhập mảng a
            Console.WriteLine("Nhap mang a:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = double.Parse(Console.ReadLine()!);
            }


            // -------------------------------
            // Nhập số phần tử của mảng b
            // -------------------------------
            Console.Write("Nhap m (mang b): ");
            int m = int.Parse(Console.ReadLine()!);

            // Kiểm tra m
            if (m <= 0 || m > 500)
            {
                Console.WriteLine("m phai nam trong khoang 1 den 500!");
                return;
            }

            // Khởi tạo mảng b
            double[] b = new double[m];

            // Nhập mảng b
            Console.WriteLine("Nhap mang b:");

            for (int i = 0; i < m; i++)
            {
                Console.Write($"b[{i}] = ");
                b[i] = double.Parse(Console.ReadLine()!);
            }


            // -------------------------------
            // Kiểm tra
            // -------------------------------
            bool ketQua = KiemTraNamTrong(a, b);

            if (ketQua)
            {
                Console.WriteLine(
                    "Tat ca phan tu cua mang a nam trong mang b."
                );
            }
            else
            {
                Console.WriteLine(
                    "Khong phai tat ca phan tu cua mang a nam trong mang b."
                );
            }
        }
    }
}