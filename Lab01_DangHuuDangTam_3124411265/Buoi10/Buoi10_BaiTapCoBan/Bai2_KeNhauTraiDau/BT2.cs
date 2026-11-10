using System;

namespace Bai2_KeNhauTraiDau
{
    public class BT2
    {
        // Hàm đếm số cặp phần tử kề nhau trái dấu
        public static int DemKeNhauTraiDau(double[] a)
        {
            // Khởi tạo số lượng bằng 0
            int dem = 0;

            // Duyệt từ phần tử thứ 2
            // đến phần tử kế cuối
            // Theo ví dụ của đề không xét cặp đầu tiên
            for (int i = 1; i < a.Length - 1; i++)
            {
                // Nếu hai phần tử kề nhau trái dấu
                if (a[i] * a[i + 1] < 0)
                {
                    // Tăng số lượng lên 1
                    dem++;
                }
            }

            // Trả về số lượng
            return dem;
        }

        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 2: KE NHAU TRAI DAU =====");

            // Nhập số lượng phần tử
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra số lượng phần tử
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

            // Đếm số lượng phần tử kề nhau trái dấu
            int ketQua = DemKeNhauTraiDau(a);

            // Xuất kết quả
            Console.WriteLine(
                "So luong cac phan tu ke nhau ma trai dau: {0}",
                ketQua
            );
        }
    }
}