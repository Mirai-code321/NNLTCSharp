using System;

namespace Bai2_TinhLuyThua
{
    public class BT2
    {
        // Hàm tính lũy thừa a^n
        // a: số thực
        // n: số nguyên dương
        public static double TinhLuyThua(double a, int n)
        {
            // Khởi tạo kết quả bằng 1
            double ketQua = 1;

            // Nhân a với chính nó n lần
            // Không sử dụng Math.Pow()
            for (int i = 1; i <= n; i++)
            {
                ketQua = ketQua * a;
            }

            // Trả về kết quả a^n
            return ketQua;
        }

        public static void Main(string[] args)
        {
            // Nhập số thực a
            Console.Write("Nhap so thuc a: ");
            double a = double.Parse(Console.ReadLine()!);

            // Nhập số nguyên dương n
            Console.Write("Nhap so nguyen duong n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra n phải là số nguyên dương
            if (n <= 0)
            {
                Console.WriteLine("n phai la so nguyen duong!");
                return;
            }

            // Gọi hàm tính lũy thừa
            double ketQua = TinhLuyThua(a, n);

            // Xuất kết quả
            Console.WriteLine("{0}^{1} = {2}", a, n, ketQua);
        }
    }
}