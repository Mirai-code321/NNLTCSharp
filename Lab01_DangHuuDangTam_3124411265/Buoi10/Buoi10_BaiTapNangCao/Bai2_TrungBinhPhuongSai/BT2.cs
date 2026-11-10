using System;

namespace Bai2_TrungBinhPhuongSai
{
    public class BT2
    {
        // Hàm tính trung bình cộng của dãy số
        public static double TinhTrungBinh(double[] a)
        {
            // Biến lưu tổng các phần tử
            double tong = 0;

            // Duyệt qua toàn bộ dãy
            for (int i = 0; i < a.Length; i++)
            {
                // Cộng phần tử hiện tại vào tổng
                tong += a[i];
            }

            // Trung bình = tổng / số phần tử
            return tong / a.Length;
        }


        // Hàm tính phương sai của dãy số
        public static double TinhPhuongSai(double[] a)
        {
            // Tính giá trị trung bình
            double trungBinh = TinhTrungBinh(a);

            // Biến lưu tổng bình phương độ lệch
            double tongBinhPhuong = 0;

            // Duyệt qua toàn bộ dãy
            for (int i = 0; i < a.Length; i++)
            {
                // Tính độ lệch của phần tử so với trung bình
                double doLech = a[i] - trungBinh;

                // Cộng bình phương độ lệch
                tongBinhPhuong += doLech * doLech;
            }

            // Theo đề:
            // Phương sai = Tổng (xi - x trung bình)^2 / (n - 1)
            return tongBinhPhuong / (a.Length - 1);
        }


        // Hàm tính độ lệch chuẩn
        public static double TinhDoLechChuan(double[] a)
        {
            // Độ lệch chuẩn = căn bậc hai của phương sai
            return Math.Sqrt(TinhPhuongSai(a));
        }


        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 2: TRUNG BINH, PHUONG SAI =====");

            // Nhập số lượng phần tử
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra n
            // Vì phương sai dùng n - 1
            // nên cần n >= 2
            if (n < 2 || n > 500)
            {
                Console.WriteLine("n phai nam trong khoang 2 den 500!");
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

            // Tính trung bình
            double trungBinh = TinhTrungBinh(a);

            // Tính phương sai
            double phuongSai = TinhPhuongSai(a);

            // Tính độ lệch chuẩn
            double doLechChuan = TinhDoLechChuan(a);

            // Xuất kết quả
            Console.WriteLine();
            Console.WriteLine("Trung binh = {0:F4}", trungBinh);
            Console.WriteLine("Phuong sai = {0:F4}", phuongSai);
            Console.WriteLine("Do lech chuan = {0:F4}", doLechChuan);
        }
    }
}