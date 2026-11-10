using System; // Bắt buộc nằm ở dòng 1 để tránh lỗi CS1529

namespace Bai6_BaiTapCoBan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int h; // Biến lưu trữ chiều cao sau khi nhập thành công

            // Vòng lặp vô hạn, bắt người dùng nhập lại nếu cố tình nhập sai
            while (true)
            {
                // In dòng nhắc nhập liệu
                Console.Write("Moi ban nhap chieu cao h: ");
                
                // Đọc dòng dữ liệu người dùng gõ từ bàn phím
                string? input = Console.ReadLine();

                // Gọi hàm validate kiểm tra h nhập vào
                if (InChuIvaUService.KiemTraHHopLe(input, out h))
                {
                    break; // Nếu hợp lệ (h >= 3 và là số), thoát vòng lặp ngay
                }

                // Nếu nhập sai (chữ, số bé hơn 3...), báo lỗi và quay lại nhập lại
                Console.WriteLine("Loi: h phai la so nguyen >= 3! Vui long nhap lai.\n");
            }

            // In tiêu đề hiển thị kết quả đúng chuẩn theo mẫu đề bài
            Console.WriteLine($"Chu I va U ung voi h = {h} la:");

            // Gọi Service để tạo hình chữ I và U dạng chuỗi
            string hinhIn = InChuIvaUService.TaoHinhChuIvaU(h);

            // In kết quả hình vẽ ra màn hình Console
            Console.WriteLine(hinhIn);
        }
    }
}