using System;
using System.Globalization;

namespace CosSin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CHUONG TRINH TINH COS(X) VA SIN(X) ===");

            // 1. Nhập số thực x (tính bằng Radian)
            double x;
            while (true)
            {
                Console.Write("Nhap so thuc x (radian): ");
                string? inputX = Console.ReadLine();
                
                // Ép kiểu chuỗi sang double (chấp nhận cả dấu . lẫn ,)
                if (double.TryParse(inputX?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out x))
                {
                    break; // Thoát vòng lặp khi nhập đúng số thực
                }
                Console.WriteLine("Loi: x phai la so thuc! Vui long nhap lai.");
            }

            // 2. Nhập độ sai số epsilon (yêu cầu epsilon > 0)
            double epsilon;
            while (true)
            {
                Console.Write("Nhap do sai so epsilon (> 0, vi du 0.00001): ");
                string? inputEps = Console.ReadLine();
                
                // Gọi hàm kiểm tra validation Epsilon đã viết bên Service
                if (CosSinService.KiemTraEpsilonHopLe(inputEps, out epsilon))
                {
                    break; // Thoát vòng lặp khi epsilon > 0
                }
                Console.WriteLine("Loi: Epsilon phai la so thuc duong (> 0)! Vui long nhap lai.");
            }

            // 3. Tính toán kết quả và in ra màn hình
            double cosX = CosSinService.TinhCos(x, epsilon);
            double sinX = CosSinService.TinhSin(x, epsilon);

            Console.WriteLine($"\n--- KET QUA (Epsilon = {epsilon}) ---");
            Console.WriteLine($"Cos({x}) = {cosX}");
            Console.WriteLine($"Sin({x}) = {sinX}");
        }
    }
}

