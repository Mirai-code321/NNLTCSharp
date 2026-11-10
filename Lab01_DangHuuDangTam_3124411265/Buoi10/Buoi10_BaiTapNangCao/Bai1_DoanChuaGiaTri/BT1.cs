using System;

namespace Bai1_DoanChuaGiaTri
{
    public class BT1
    {
        // Hàm tìm đoạn [a, b] ngắn nhất
        // chứa tất cả các giá trị trong mảng
        public static double[] TimDoanChuaGiaTri(double[] mang)
        {
            // Phần tử đầu tiên được dùng làm giá trị nhỏ nhất
            double giaTriNhoNhat = mang[0];

            // Phần tử đầu tiên được dùng làm giá trị lớn nhất
            double giaTriLonNhat = mang[0];

            // Duyệt qua các phần tử còn lại
            for (int i = 1; i < mang.Length; i++)
            {
                // Nếu tìm thấy giá trị nhỏ hơn
                if (mang[i] < giaTriNhoNhat)
                {
                    // Cập nhật giá trị nhỏ nhất
                    giaTriNhoNhat = mang[i];
                }

                // Nếu tìm thấy giá trị lớn hơn
                if (mang[i] > giaTriLonNhat)
                {
                    // Cập nhật giá trị lớn nhất
                    giaTriLonNhat = mang[i];
                }
            }

            // Đoạn ngắn nhất chứa toàn bộ giá trị
            // chính là [giá trị nhỏ nhất, giá trị lớn nhất]
            return new double[]
            {
                giaTriNhoNhat,
                giaTriLonNhat
            };
        }

        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 1: TIM DOAN CHUA GIA TRI =====");

            // Nhập số lượng phần tử
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra n
            if (n <= 0 || n > 500)
            {
                Console.WriteLine("n phai nam trong khoang 1 den 500!");
                return;
            }

            // Khởi tạo mảng
            double[] mang = new double[n];

            // Nhập các phần tử
            Console.WriteLine("Nhap day so:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                mang[i] = double.Parse(Console.ReadLine()!);
            }

            // Tìm đoạn ngắn nhất chứa tất cả giá trị
            double[] ketQua = TimDoanChuaGiaTri(mang);

            // Xuất kết quả
            Console.WriteLine(
                "Doan ngan nhat chua tat ca gia tri trong mang la: [{0}, {1}]",
                ketQua[0],
                ketQua[1]
            );
        }
    }
}