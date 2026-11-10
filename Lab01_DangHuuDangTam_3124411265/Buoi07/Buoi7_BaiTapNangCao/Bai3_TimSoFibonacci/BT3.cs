using System;

namespace Bai3_TimSoFibonacci
{
    public class BT3
    {
        // Hàm tìm số Fibonacci lớn nhất nhỏ hơn n
        public static int TimFibonacciNhoHon(int n)
        {
            // Hai số Fibonacci đầu tiên
            int fib1 = 1;
            int fib2 = 1;

            // Nếu n <= 1 thì không có số Fibonacci dương nào nhỏ hơn n
            if (n <= 1)
            {
                return 0;
            }

            // Tìm số Fibonacci lớn nhất nhỏ hơn n
            while (fib2 < n)
            {
                // Tính số Fibonacci tiếp theo
                int fib3 = fib1 + fib2;

                // Cập nhật hai số Fibonacci
                fib1 = fib2;
                fib2 = fib3;
            }

            // Khi vòng lặp kết thúc, fib2 >= n
            // Vì vậy fib1 là số Fibonacci lớn nhất nhỏ hơn n
            return fib1;
        }

        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            // Nhập số nguyên dương n
            Console.Write("Nhap so nguyen duong n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra n có phải số nguyên dương không
            if (n <= 0)
            {
                Console.WriteLine("n phai la so nguyen duong!");
                return;
            }

            // Tìm số Fibonacci lớn nhất nhỏ hơn n
            int ketQua = TimFibonacciNhoHon(n);

            // Xuất kết quả
            Console.WriteLine(
                "So Fibonacci lon nhat nho hon {0} la: {1}",
                n,
                ketQua
            );
        }
    }
}