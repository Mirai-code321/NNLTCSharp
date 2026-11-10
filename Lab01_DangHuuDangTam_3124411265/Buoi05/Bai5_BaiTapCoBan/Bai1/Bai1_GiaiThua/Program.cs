using System;

namespace Bai1_GiaiThua
{
    class Program
    {
        static void Main()
        {
            // Biến n dùng để lưu số người dùng nhập vào
            int n;

            // Vòng lặp vô hạn, chỉ thoát khi người dùng nhập đúng giá trị hợp lệ
            while (true)
            {
                Console.Write("Moi ban nhap so n: ");

                // TryParse: cố gắng chuyển chuỗi nhập vào thành số int
                // Trả về true nếu chuyển thành công, false nếu người dùng nhập chữ/ký tự linh tinh
                // Kết quả chuyển đổi được lưu vào biến n (out n)
                bool hopLe = int.TryParse(Console.ReadLine(), out n);

                // Kiểm tra: chuyển đổi thành công VÀ n nằm trong khoảng [1, 12]
                if (hopLe && n >= 1 && n <= 12)
                {
                    break; // Thoát khỏi vòng lặp while vì đã nhập đúng
                }

                // Nếu không hợp lệ thì báo lỗi và vòng lặp sẽ hỏi lại từ đầu
                Console.WriteLine("So n khong hop le! Vui long nhap lai (1 <= n <= 12).");
            }

            // Gọi hàm Tinh() từ class GiaiThua để tính n!
            long ketQua = GiaiThua.Tinh(n);

            // Gọi hàm TaoChuoiPhepTinh() để lấy chuỗi hiển thị dạng "1.2.3.4.5"
            string chuoiPhepTinh = GiaiThua.TaoChuoiPhepTinh(n);

            // In kết quả ra màn hình theo đúng định dạng đề bài
            // $"..." là string interpolation, cho phép chèn biến trực tiếp vào chuỗi bằng {}
            Console.WriteLine($"{n}! = {chuoiPhepTinh} = {ketQua}.");
        }
    }
}

