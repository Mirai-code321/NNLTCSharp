using System;
using System.Globalization;

namespace LuyThua
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CHUONG TRINH TINH LUY THUA a^n ===");

            // 1. Nhập số thực a
            double a;
            while (true)
            {
                Console.Write("Nhap so thuc a: ");
                string? inputA = Console.ReadLine();

                // Chuẩn hóa dấu phẩy (,) thành dấu chấm (.) để nhập kiểu nào cũng ăn
                if (double.TryParse(inputA?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out a))
                {
                    break; // Nhập đúng số thực thì thoát vòng lặp nhập a
                }
                Console.WriteLine("Loi: Gia tri a phai la so thuc! Vui long nhap lai.");
            }

            // 2. Nhập số nguyên dương n
            int n;
            while (true)
            {
                Console.Write("Nhap so nguyen duong n: ");
                string? inputN = Console.ReadLine();

                // Gọi hàm validate đã viết bên LuyThuaService
                if (LuyThuaService.KiemTraSoMuHopLe(inputN, out n))
                {
                    break; // Nhập đúng số nguyên dương thì thoát vòng lặp nhập n
                }
                Console.WriteLine("Loi: n phai la so nguyen duong (n > 0)! Vui long nhap lai.");
            }

            // 3. Gọi hàm tính toán và in kết quả ra màn hình
            double ketQua = LuyThuaService.TinhLuyThua(a, n);
            Console.WriteLine($"\nKet qua: {a}^{n} = {ketQua}");
        }
    }
}

