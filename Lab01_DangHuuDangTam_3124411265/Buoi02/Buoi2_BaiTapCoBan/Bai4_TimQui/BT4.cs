using System;

namespace TimQui
{
    public class Program
    {
        // Hàm xác định quý của một tháng
        // Ví dụ:
        // Tháng 1, 2, 3  -> Quý 1
        // Tháng 4, 5, 6  -> Quý 2
        // Tháng 7, 8, 9  -> Quý 3
        // Tháng 10, 11, 12 -> Quý 4
        //
        // Hàm không sử dụng Console nên có thể Unit Test.
        public static int TimQui(int thang)
        {
            // Công thức xác định quý:
            // (tháng - 1) / 3 + 1
            //
            // C# chia hai số nguyên thì lấy phần nguyên.
            int qui = (thang - 1) / 3 + 1;

            // Trả về số quý
            return qui;
        }

        static void Main(string[] args)
        {
            // Yêu cầu người dùng nhập tháng
            Console.Write("Moi ban nhap thang: ");

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

            // Chuyển dữ liệu từ kiểu string sang kiểu int
            int thang = int.Parse(dongNhap);

            // Gọi hàm TimQui để xác định quý của tháng
            int qui = TimQui(thang);

            // In kết quả ra màn hình
            Console.WriteLine("Thang {0} thuoc qui {1}.", thang, qui);
        }
    }
}
