using System;

namespace Bai3_TongPhanSoSaiSo
{
    class Program
    {
        static void Main()
        {
            double a, epsilon;

            // Nhập a: chỉ cần là số thực hợp lệ (a > 0 để tránh chia cho 0 hoặc số âm gây vô hạn)
            while (true)
            {
                Console.Write("Moi ban nhap so a: ");
                bool hopLe = double.TryParse(Console.ReadLine(), out a);

                if (hopLe && a > 0)
                {
                    break;
                }
                Console.WriteLine("So a khong hop le! Vui long nhap lai (a phai la so thuc duong).");
            }

            // Nhập epsilon: phải <= 0.1 và > 0 theo đề bài
            while (true)
            {
                Console.Write("Moi ban nhap sai so epsilon (<=0.1): ");
                bool hopLe = double.TryParse(Console.ReadLine(), out epsilon);

                if (hopLe && epsilon > 0 && epsilon <= 0.1)
                {
                    break;
                }
                Console.WriteLine("Epsilon khong hop le! Vui long nhap lai (0 < epsilon <= 0.1).");
            }

            // Gọi hàm tính tổng
            double s = TongPhanSo.TinhTong(a, epsilon);

            // In kết quả, làm tròn 4 chữ số thập phân
            Console.WriteLine($"Gia tri cua bieu thuc S(a = {a}, epsilon = {epsilon}) = {s:F4}.");
        }
    }
}

