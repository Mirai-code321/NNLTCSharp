using System;

namespace Bai5_DoanDuongDaiNhat
{
    public class BT5
    {
        // Hàm tìm đoạn chứa toàn số dương dài nhất
        public static int[] TimDoanDuongDaiNhat(double[] a)
        {
            // Vị trí bắt đầu của đoạn dương dài nhất
            int viTriBatDau = -1;

            // Vị trí kết thúc của đoạn dương dài nhất
            int viTriKetThuc = -1;

            // Độ dài đoạn dương dài nhất
            int doDaiLonNhat = 0;

            // Vị trí bắt đầu của đoạn dương hiện tại
            int batDauHienTai = -1;

            // Độ dài đoạn dương hiện tại
            int doDaiHienTai = 0;

            // Duyệt qua toàn bộ dãy số
            for (int i = 0; i < a.Length; i++)
            {
                // Nếu phần tử hiện tại là số dương
                if (a[i] > 0)
                {
                    // Nếu đây là phần tử dương đầu tiên
                    // của một đoạn mới
                    if (doDaiHienTai == 0)
                    {
                        batDauHienTai = i;
                    }

                    // Tăng độ dài đoạn dương hiện tại
                    doDaiHienTai++;

                    // Nếu đoạn hiện tại dài hơn đoạn dài nhất
                    if (doDaiHienTai > doDaiLonNhat)
                    {
                        // Cập nhật độ dài lớn nhất
                        doDaiLonNhat = doDaiHienTai;

                        // Lưu vị trí bắt đầu
                        viTriBatDau = batDauHienTai;

                        // Lưu vị trí kết thúc
                        viTriKetThuc = i;
                    }
                }
                else
                {
                    // Gặp số không dương thì đoạn dương kết thúc
                    doDaiHienTai = 0;
                    batDauHienTai = -1;
                }
            }

            // Trả về vị trí đoạn dương dài nhất
            // Nếu không có số dương thì trả về [-1, -1]
            return new int[] { viTriBatDau, viTriKetThuc };
        }

        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 5: TIM DOAN DUONG DAI NHAT =====");

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
            double[] a = new double[n];

            // Nhập dãy số
            Console.WriteLine("Nhap day so:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                a[i] = double.Parse(Console.ReadLine()!);
            }

            // Tìm đoạn dương dài nhất
            int[] ketQua = TimDoanDuongDaiNhat(a);

            // Nếu không có số dương
            if (ketQua[0] == -1)
            {
                Console.WriteLine("Day khong co doan duong.");
            }
            else
            {
                // Xuất vị trí đoạn dương
                Console.WriteLine(
                    "Doan duong [{0}, {1] dai nhat:",
                    ketQua[0],
                    ketQua[1]
                );

                // Xuất các phần tử trong đoạn
                for (int i = ketQua[0]; i <= ketQua[1]; i++)
                {
                    Console.Write(a[i] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}