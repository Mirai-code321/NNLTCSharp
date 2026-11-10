using System;

namespace BieuThucNhanh1
{
    public class Program
    {
        // Hàm tính giá trị biểu thức:
        // f(x) = 1 + 2x + 3x^2 - 4x^3
        //
        // Sử dụng sơ đồ Horner để giảm số phép tính.
        // Hàm không sử dụng Console nên có thể Unit Test.
        public static double TinhBieuThuc(double x)
        {
            // Bước 1: Tính -4x
            double t1 = -4 * x;      // phép toán 1: nhân

            // Bước 2: Tính 3 - 4x
            double t2 = 3 + t1;      // phép toán 2: cộng

            // Bước 3: Tính (3 - 4x)x
            double t3 = t2 * x;      // phép toán 3: nhân

            // Bước 4: Tính 2 + (3 - 4x)x
            double t4 = 2 + t3;      // phép toán 4: cộng

            // Bước 5: Tính [2 + (3 - 4x)x]x
            double t5 = t4 * x;      // phép toán 5: nhân

            // Bước 6: Cộng thêm 1 để có kết quả cuối cùng
            double t6 = 1 + t5;      // phép toán 6: cộng

            // Trả về giá trị của biểu thức
            return t6;
        }

        static void Main(string[] args)
        {
            // Yêu cầu người dùng nhập số thực x
            Console.Write("Moi ban nhap so thuc x: ");

            // Đọc dữ liệu từ bàn phím
            string? dongNhap = Console.ReadLine();

            // Kiểm tra nếu người dùng không nhập dữ liệu
            if (string.IsNullOrEmpty(dongNhap))
            {
                // Thông báo cho người dùng
                Console.WriteLine("Ban chua nhap gi ca!");

                // Kết thúc chương trình
                return;
            }

            // Chuyển dữ liệu từ string sang kiểu double
            double x = double.Parse(dongNhap);

            // Gọi hàm TinhBieuThuc để tính giá trị f(x)
            double ketQua = TinhBieuThuc(x);

            // In kết quả ra màn hình
            // {1:0.00} hiển thị kết quả với 2 chữ số sau dấu phẩy
            Console.WriteLine("f({0}) = {1:0.00}", x, ketQua);
        }
    }
}
