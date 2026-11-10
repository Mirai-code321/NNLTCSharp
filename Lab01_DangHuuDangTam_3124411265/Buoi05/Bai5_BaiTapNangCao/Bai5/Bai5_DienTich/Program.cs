using System;
using System.Globalization;

namespace TinhDienTich
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vòng lặp vô hạn để giữ giao diện menu lặp lại sau mỗi lần tính
            while (true)
            {
                Console.Clear(); // Xóa màn hình cho sạch giao diện

                // 1. In thực đơn (Menu) chuẩn theo mẫu hình ảnh
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("THUC DON");
                Console.WriteLine("1. Tinh dien tich tam giac");
                Console.WriteLine("2. Tinh dien tich hinh chu nhat");
                Console.WriteLine("3. Tinh dien tich hinh tron");
                Console.WriteLine("4. Thoat");
                Console.WriteLine("--------------------------------------------------");

                // 2. Nhập lựa chọn chức năng từ người dùng
                Console.Write("Moi ban chon chuc nang [1, 2, 3, 4]: ");
                string? inputChoice = Console.ReadLine();
                Console.WriteLine("--------------------------------------------------");

                // Validation dữ liệu nhập menu
                if (!TinhDienTichService.KiemTraLoiChon(inputChoice, out int luaChon))
                {
                    Console.WriteLine("Loi: Chuc nang khong hop le! Nhan phim bat ky de thu lai...");
                    Console.ReadKey();
                    continue; // Quay lại đầu vòng lặp menu
                }

                // Nếu chọn 4 thì thoát chương trình
                if (luaChon == 4)
                {
                    break;
                }

                // 3. Điều hướng gọi hàm xử lý tương ứng theo lựa chọn
                switch (luaChon)
                {
                    case 1:
                        TinhTamGiac();
                        break;
                    case 2:
                        TinhHinhChuNhat();
                        break;
                    case 3:
                        TinhHinhTron();
                        break;
                }

                // Tạm dừng màn hình chờ người dùng nhấn phím bất kỳ để tiếp tục
                Console.WriteLine("\nBan nhan phim bat ky de tiep tuc ...");
                Console.ReadKey();
            }
        }

        // Hàm xử lý nhập và tính cho Tam Giác
        static void TinhTamGiac()
        {
            Console.WriteLine("Tinh dien tich tam giac:");
            Console.Write("Moi ban do dai 3 canh a b c: ");

            // Tách chuỗi nhập vào bởi khoảng trắng
            string[]? arr = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Kiểm tra xem có đủ 3 tham số nhập vào không và parse sang kiểu double
            if (arr != null && arr.Length == 3 &&
                double.TryParse(arr[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double a) &&
                double.TryParse(arr[1].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double b) &&
                double.TryParse(arr[2].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double c))
            {
                try
                {
                    double dt = TinhDienTichService.TinhDienTichTamGiac(a, b, c);
                    Console.WriteLine($"Tam giac co 3 canh {a}, {b}, {c} co dien tich la {dt}.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Loi: Du lieu nhap vao khong hop le!");
            }
        }

        // Hàm xử lý nhập và tính cho Hình Chữ Nhật (Khớp đúng mẫu nhập "3 5" trong ảnh)
        static void TinhHinhChuNhat()
        {
            Console.WriteLine("Tinh dien tich hinh chu nhat:");
            Console.Write("Moi ban do dai va do rong cua hinh chu nhat: ");

            // Tách chuỗi nhập vào cách nhau bởi dấu khoảng trắng (Ví dụ: "3 5")
            string[]? arr = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Ép kiểu 2 tham số vừa tách sang số thực double
            if (arr != null && arr.Length == 2 &&
                double.TryParse(arr[0].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double dai) &&
                double.TryParse(arr[1].Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double rong))
            {
                try
                {
                    double dt = TinhDienTichService.TinhDienTichHinhChuNhat(dai, rong);
                    // In kết quả theo đúng mẫu câu của đề bài
                    Console.WriteLine($"Hinh chu nhat do dai {dai} va do rong {rong} co dien tich la {dt}.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Loi: Du lieu nhap vao khong hop le!");
            }
        }

        // Hàm xử lý nhập và tính cho Hình Tròn
        static void TinhHinhTron()
        {
            Console.WriteLine("Tinh dien tich hinh tron:");
            Console.Write("Moi ban nhap ban kinh r: ");
            string? input = Console.ReadLine();

            // Chuyển đổi dữ liệu nhập sang kiểu double (chấp nhận cả dấu '.' hoặc ',')
            if (double.TryParse(input?.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double r))
            {
                try
                {
                    double dt = TinhDienTichService.TinhDienTichHinhTron(r);
                    Console.WriteLine($"Hinh tron ban kinh {r} co dien tich la {dt}.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Loi: Du lieu nhap vao khong hop le!");
            }
        }
    }
}

