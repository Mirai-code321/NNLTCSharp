using System;

namespace TimLonNhat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CHUONG TRINH TIM SO LUY THUA THOA DIEU KIEN ===");

            // 1. Nhập số tự nhiên n lớn hơn 1
            long n;
            while (true)
            {
                Console.Write("Nhap so tu nhien n (n > 1): ");
                string? input = Console.ReadLine();

                // Kiểm tra xem n có hợp lệ và lớn hơn 1 không
                if (TimLonNhatService.KiemTraNHopLe(input, out n) && n > 1)
                {
                    break; // Đúng điều kiện thì thoát khỏi vòng lặp nhập
                }
                Console.WriteLine("Loi: n phai la so nguyen lon hon 1! Vui long nhap lai.");
            }

            // 2. Gọi các hàm xử lý tính toán từ Service
            int k = TimLonNhatService.TimKLonNhat(n);
            long so2MuK = TimLonNhatService.Tim2MuKNhoNhat(n);

            // 3. Hiển thị kết quả chi tiết ra màn hình Console
            Console.WriteLine($"\n(a) So nguyen k lon nhat de 4^k < {n} la: k = {k} (vi 4^{k} = {Math.Pow(4, k)})");
            Console.WriteLine($"(b) So be nhat dang 2^k khong be hon {n} la: {so2MuK}");
        }
    }
}

