using System;

namespace ThucDon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int luaChon;

            // Sử dụng do-while để đảm bảo thực đơn luôn được in ra ít nhất 1 lần
            do
            {
                // Xóa sạch nội dung màn hình console cũ trước khi vẽ thực đơn mới
                Console.Clear();

                // 1. In tiêu đề và danh sách tính năng theo đúng thiết kế của đề
                Console.WriteLine("THUC DON");
                Console.WriteLine("1. Tinh dien tich tam giac");
                Console.WriteLine("2. Tinh dien tich hinh chu nhat");
                Console.WriteLine("3. Tinh dien tich hinh tron");
                Console.WriteLine("4. Thoat");
                Console.WriteLine("--------------------------------------------");

                // 2. Yêu cầu nhập dữ liệu
                Console.Write("Moi ban chon chuc nang [1, 2, 3, 4]: ");
                string? input = Console.ReadLine();
                // 3. Kiểm tra tính hợp lệ thông qua hàm logic đã tách riêng
                if (XuLyThucDon.KiemTraHopLe(input, out luaChon))
                {
                    Console.WriteLine("--------------------------------------------");
                    // In dòng thông báo kết quả tương ứng
                    Console.WriteLine(XuLyThucDon.LayThongBao(luaChon));

                    // Nếu người dùng chọn 4 -> Bắt sự kiện thoát và bứt khỏi vòng lặp
                    if (XuLyThucDon.LaLuaChonThoat(luaChon))
                    {
                        break;
                    }
                }
                else
                {
                    // Trường hợp nhập sai (chữ, số ngoài 1-4, rỗng)
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Lua chon khong hop le! Vui long chon tu 1 den 4.");
                }

                // 4. Dừng màn hình chờ người dùng ấn 1 phím bất kỳ trước khi clear màn hình lặp lại
                Console.WriteLine();
                Console.WriteLine("Ban nhan phim bat ky de tiep tuc ...");
                Console.ReadKey();

            } while (true); // Vòng lặp chạy vô hạn cho đến khi gặp lệnh break (khi chọn 4)
        }
    }
}

