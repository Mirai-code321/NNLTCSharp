using System;

namespace Bai1_TrungBinhCongCucTri
{
    public class BT1
    {
        // Hàm tính tổng các phần tử cực trị
        // Theo ví dụ của đề: chỉ lấy phần tử lớn hơn
        // hai phần tử đứng ngay bên cạnh
        public static double TinhTongCucTri(double[] a)
        {
            // Khởi tạo tổng bằng 0
            double tong = 0;

            // Xét các phần tử từ vị trí thứ 2 đến trước phần tử cuối
            // Vì phần tử đầu và cuối chỉ có một phần tử bên cạnh
            for (int i = 1; i < a.Length - 1; i++)
            {
                // Nếu phần tử hiện tại lớn hơn
                // cả phần tử bên trái và bên phải
                // thì đây là phần tử cực trị
                if (a[i] > a[i - 1] && a[i] > a[i + 1])
                {
                    // Cộng phần tử cực trị vào tổng
                    tong += a[i];
                }
            }

            // Trả về tổng các phần tử cực trị
            return tong;
        }

        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 1: TRUNG BINH CONG PHAN TU CUC TRI =====");

            // Nhập số lượng phần tử
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra n
            if (n < 3)
            {
                Console.WriteLine("n phai lon hon hoac bang 3!");
                return;
            }

            // Khởi tạo mảng
            double[] a = new double[n];

            // Nhập các phần tử của mảng
            Console.WriteLine("Nhap day so:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = double.Parse(Console.ReadLine()!);
            }

            // Tính tổng các phần tử cực trị
            double tong = TinhTongCucTri(a);

            // Xuất kết quả
            Console.WriteLine(
                "Tong cac phan tu cuc tri co trong day so: {0}",
                tong
            );
        }
    }
}