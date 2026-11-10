using System;

namespace Bai4_TimDoan
{
    public class BT4
    {
        // Hàm tìm đoạn [i, j] dài nhất có tổng bằng k
        public static int[] TimDoanDaiNhat(double[] a, double k)
        {
            // Vị trí bắt đầu và kết thúc của đoạn dài nhất
            int viTriBatDau = -1;
            int viTriKetThuc = -1;

            // Độ dài đoạn dài nhất tìm được
            int doDaiLonNhat = 0;

            // Chọn vị trí bắt đầu của đoạn
            for (int i = 0; i < a.Length; i++)
            {
                // Khởi tạo tổng của đoạn
                double tong = 0;

                // Chọn vị trí kết thúc của đoạn
                for (int j = i; j < a.Length; j++)
                {
                    // Cộng phần tử hiện tại vào tổng
                    tong += a[j];

                    // Kiểm tra tổng của đoạn có bằng k hay không
                    if (Math.Abs(tong - k) < 1e-10)
                    {
                        // Tính độ dài đoạn hiện tại
                        int doDai = j - i + 1;

                        // Nếu đoạn hiện tại dài hơn đoạn đã tìm được
                        if (doDai > doDaiLonNhat)
                        {
                            // Cập nhật độ dài lớn nhất
                            doDaiLonNhat = doDai;

                            // Lưu vị trí đoạn
                            viTriBatDau = i;
                            viTriKetThuc = j;
                        }
                    }
                }
            }

            // Trả về vị trí đoạn [i, j]
            // Nếu không tìm thấy thì trả về [-1, -1]
            return new int[] { viTriBatDau, viTriKetThuc };
        }

        // Hàm Main để nhập dữ liệu và xuất kết quả
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 4: TIM DOAN =====");

            // Nhập số lượng phần tử
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra n phải nằm trong khoảng 1 đến 500
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

            // Nhập số k
            Console.Write("Moi ban nhap so k: ");
            double k = double.Parse(Console.ReadLine()!);

            // Tìm đoạn dài nhất có tổng bằng k
            int[] ketQua = TimDoanDaiNhat(a, k);

            // Nếu không tìm được đoạn
            if (ketQua[0] == -1)
            {
                Console.WriteLine("Khong co doan nao co tong bang k.");
            }
            else
            {
                // Xuất vị trí đoạn
                Console.WriteLine(
                    "Doan [{0}, {1}] dai nhat co tong bang {2}:",
                    ketQua[0],
                    ketQua[1],
                    k
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