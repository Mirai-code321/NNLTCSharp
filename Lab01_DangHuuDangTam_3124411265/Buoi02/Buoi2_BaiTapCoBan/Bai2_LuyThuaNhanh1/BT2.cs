using System;

namespace LuyThuaNhanh1
{
    public class Program
    {
        // Hàm tính lũy thừa của a với số mũ 2, 5 và 17
        // Hàm này không phụ thuộc vào Console nên có thể Unit Test
        public static (double aMu2, double aMu5, double aMu17) TinhLuyThua(double a)
        {
            // Tính a^2
            double a2 = a * a;         // phép nhân 1: a^2

            // Tính a^4 dựa vào a^2
            double a4 = a2 * a2;       // phép nhân 2: a^4

            // Tính a^5 = a^4 * a
            double a5 = a4 * a;        // phép nhân 3: a^5

            // Tính a^8 = a^4 * a^4
            double a8 = a4 * a4;       // phép nhân 4: a^8

            // Tính a^16 = a^8 * a^8
            double a16 = a8 * a8;      // phép nhân 5: a^16

            // Tính a^17 = a^16 * a
            double a17 = a16 * a;      // phép nhân 6: a^17

            // Trả về đồng thời 3 kết quả: a^2, a^5 và a^17
            return (a2, a5, a17);
        }

        static void Main(string[] args)
        {
            // Yêu cầu người dùng nhập một số thực a
            Console.Write("Moi ban nhap so thuc a: ");

            // Đọc dữ liệu từ bàn phím
            string? dongNhap = Console.ReadLine();

            // Kiểm tra nếu người dùng không nhập gì
            if (string.IsNullOrEmpty(dongNhap))
            {
                // Thông báo cho người dùng
                Console.WriteLine("Ban chua nhap gi ca!");

                // Kết thúc chương trình
                return;
            }

            // Chuyển dữ liệu từ kiểu string sang kiểu double
            double a = double.Parse(dongNhap);

            // Gọi hàm TinhLuyThua để tính a^2, a^5 và a^17
            // Dùng tuple để nhận 3 giá trị trả về
            var (aMu2, aMu5, aMu17) = TinhLuyThua(a);

            // In kết quả ra màn hình
            // {1:0.00} nghĩa là hiển thị số thực với 2 chữ số sau dấu phẩy
            Console.WriteLine(
                "Ket qua: {0}^2={1:0.00}, {0}^5={2:0.00}, {0}^17={3:0.00}.",
                a, aMu2, aMu5, aMu17
            );
        }
    }
}
