using System;

namespace HaiChuSoCuoi
{
    public class Program
    {
        // Hàm tính lũy thừa nhanh theo modulo
        // Tính (coSo ^ soMu) % m
        //
        // Sử dụng phương pháp "lũy thừa nhị phân"
        // giúp giảm số lần nhân khi số mũ rất lớn.
        //
        // Dùng modulo trong quá trình tính để hạn chế
        // giá trị số trở nên quá lớn và gây tràn số.
        public static long LuyThuaModulo(long coSo, long soMu, long m)
        {
            // Khởi tạo kết quả bằng 1
            long ketQua = 1;

            // Đưa cơ số về khoảng [0, m - 1]
            // Cách này cũng đảm bảo cơ số không âm.
            coSo = ((coSo % m) + m) % m;

            // Lặp cho đến khi số mũ bằng 0
            while (soMu > 0)
            {
                // Nếu số mũ là số lẻ
                if (soMu % 2 == 1)
                {
                    // Nhân kết quả với cơ số rồi lấy dư cho m
                    ketQua = (ketQua * coSo) % m;
                }

                // Bình phương cơ số và lấy dư cho m
                coSo = (coSo * coSo) % m;

                // Chia đôi số mũ
                soMu = soMu / 2;
            }

            // Trả về kết quả (coSo ^ soMu) % m
            return ketQua;
        }

        // Hàm tính hai chữ số cuối của n^278
        // Vì muốn lấy 2 chữ số cuối nên lấy modulo 100.
        // Ví dụ:
        // n^278 % 100 = 25
        // => hai chữ số cuối là 25.
        // Hàm không sử dụng Console nên có thể Unit Test.
        public static int TinhHaiChuSoCuoi(long n)
        {
            // Tính n^278 % 100
            return (int)LuyThuaModulo(n, 278, 100);
        }

        static void Main(string[] args)
        {
            // Yêu cầu người dùng nhập số nguyên n
            Console.Write("Moi ban nhap so nguyen n: ");

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

            // Chuyển dữ liệu từ string sang kiểu long
            long n = long.Parse(dongNhap);

            // Gọi hàm TinhHaiChuSoCuoi để tính hai chữ số cuối
            int ketQua = TinhHaiChuSoCuoi(n);

            // In kết quả
            // {1:D2} đảm bảo luôn hiển thị đủ 2 chữ số
            // Ví dụ: 5 sẽ được hiển thị thành 05.
            Console.WriteLine(
                "{0}^278 co 2 chu so cuoi cung la {1:D2}.",
                n,
                ketQua
            );
        }
    }
}
