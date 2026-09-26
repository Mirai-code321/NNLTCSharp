using System;
using Bai3_NhapSoNguyen.Lib;

namespace Bai3_NhapSoNguyen.App
{
    // Luồng chạy: nhập x, y -> kiểm tra hợp lệ -> LuyThua tính -> in kết quả.
    // Class để public để project test gọi được Main.
    public class Program
    {
        // Đọc một dòng và thử đổi sang int, giá trị đọc được trả về qua tham số out.
        // Trả về false nếu gõ chữ, số thực, để trống hoặc số vượt phạm vi int.
        private static bool NhapSoNguyen(string loiNhac, out int giaTri)
        {
            Console.Write(loiNhac);
            return int.TryParse(Console.ReadLine(), out giaTri);
        }

        public static void Main(string[] args)
        {
            int x, y;

            // nhập sai x thì báo lỗi rồi thoát luôn, không hỏi y nữa
            if (!NhapSoNguyen("Nhap so nguyen x: ", out x))
            {
                Console.WriteLine("Loi: x khong phai so nguyen");
                return;
            }
            if (!NhapSoNguyen("Nhap so nguyen y: ", out y))
            {
                Console.WriteLine("Loi: y khong phai so nguyen");
                return;
            }
            if (y < 0)
            {
                Console.WriteLine("Loi: y phai la so khong am");
                return;
            }

            LuyThua lt = new LuyThua(x, y);

            // {2} tự gọi ToString() của BigInteger nên in đủ mọi chữ số
            Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, lt.Tinh());
        }
    }
}