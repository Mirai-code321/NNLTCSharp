using System;

namespace Bai2_GiaTriBieuThuc
{
    class Program
    {
        static void Main()
        {
            int n;

            // Vòng lặp yêu cầu nhập lại nếu người dùng nhập không hợp lệ (không phải số nguyên dương)
            while (true)
            {
                Console.Write("Moi ban nhap so nguyen n: ");
                bool hopLe = int.TryParse(Console.ReadLine(), out n);

                if (hopLe && n > 0)
                {
                    break; // Nhập đúng số nguyên dương thì thoát vòng lặp
                }
                Console.WriteLine("So khong hop le! Vui long nhap lai (n phai la so nguyen duong).");
            }

            // Gọi hàm tính từ class BieuThuc
            double s1 = BieuThuc.Tinh_S1(n);
            double s2 = BieuThuc.Tinh_S2(n);

            // In kết quả, dùng "F4" để làm tròn 4 chữ số thập phân cho dễ nhìn
            Console.WriteLine($"S1(n={n}) = {s1:F4}.");
            Console.WriteLine($"S2(n={n}) = {s2:F4}");
        }
    }
}

