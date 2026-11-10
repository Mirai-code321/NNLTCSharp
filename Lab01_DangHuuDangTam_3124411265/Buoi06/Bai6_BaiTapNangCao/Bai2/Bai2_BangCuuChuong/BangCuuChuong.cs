using System;
using System.Text;

namespace Bai2_BangCuuChuong
{
    public class InBangCuuChuongService
    {
        // Hàm sinh ra toàn bộ chuỗi Bảng cửu chương theo đúng định dạng mẫu
        public static string TaoBangCuuChuong()
        {
            // Khởi tạo StringBuilder để thực hiện nối các dòng chữ nhanh và không tốn bộ nhớ
            StringBuilder sb = new StringBuilder();

            // Khối 1: Vòng lặp i chạy từ 1 đến 5 đại diện cho các hàng nhân
            for (int i = 1; i <= 5; i++)
            {
                // Vòng lặp j chạy từ 2 đến 9 đại diện cho các cột bảng cửu chương
                for (int j = 2; j <= 9; j++)
                {
                    // Tính tích của phép nhân hiện tại
                    int tích = j * i;

                    // Định dạng chuỗi phép tính: {j} cửu chương, {i,2} căn lề phải rộng 2, {tích,-2} căn trái rộng 2
                    string phepTinh = $"{j} x {i,2}={tích,-2}";

                    // PadRight(12): Thêm các khoảng trắng vào bên phải chuỗi phép tính để đảm bảo mỗi cột chiếm 12 ký tự
                    sb.Append(phepTinh.PadRight(12));
                }
                // Xuống dòng sau khi in xong 1 hàng của khối 1
                sb.AppendLine();
            }

            // In một dòng trống phân cách giữa Khối 1 và Khối 2
            sb.AppendLine();

            // Khối 2: Vòng lặp i chạy từ 6 đến 10 đại diện cho các hàng nhân
            for (int i = 6; i <= 10; i++)
            {
                for (int j = 2; j <= 9; j++)
                {
                    int tích = j * i;

                    // Hàng i = 10 bỏ khoảng trắng giữa chữ 'x' và số '10' (ví dụ: "2 x10=20")
                    string phepTinh = (i == 10) ? $"{j} x{i}={tích,-2}" : $"{j} x {i,2}={tích,-2}";

                    // Đệm khoảng trắng rộng 12 ký tự cho các cột thẳng nhau
                    sb.Append(phepTinh.PadRight(12));
                }

                // Nếu chưa phải là hàng cuối cùng (hàng i = 10) thì thực hiện xuống dòng
                if (i < 10)
                {
                    sb.AppendLine();
                }
            }

            // Trả về toàn bộ chuỗi bảng cửu chương hoàn chỉnh
            return sb.ToString();
        }

        // Hàm kiểm tra logic tính toán của phép nhân (phục vụ Unit Test verification)
        public static bool KiemTraKetQuaPhepNhan(int n, int i, out int ketQua)
        {
            // Kiểm tra đầu vào: n thuộc cửu chương 2..9, i nằm trong khoảng 1..10
            if (n < 2 || n > 9 || i < 1 || i > 10)
            {
                ketQua = 0;
                return false;
            }

            // Thực hiện phép nhân và gán vào biến out ketQua
            ketQua = n * i;

            // Trả về true xác nhận phép tính hợp lệ
            return true;
        }
    }
}