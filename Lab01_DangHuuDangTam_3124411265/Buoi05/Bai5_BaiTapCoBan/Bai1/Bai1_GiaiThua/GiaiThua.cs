using System;

namespace Bai1_GiaiThua
{
    // Class này chứa các hàm xử lý logic tính giai thừa
    // Tách riêng ra khỏi Program.cs để dễ viết Unit Test
    public class GiaiThua
    {
        // Hàm tính giai thừa của n (n!)
        // Input: n (số nguyên dương, 1 <= n <= 12)
        // Output: kết quả n! dạng long
        public static long Tinh(int n)
        {
            // Kiểm tra điều kiện hợp lệ của n theo đề bài
            // Nếu n ngoài khoảng [1, 12] thì ném ra lỗi (exception)
            if (n < 1 || n > 12)
                throw new ArgumentOutOfRangeException(nameof(n), "n phai trong khoang 1 den 12");

            // Biến lưu kết quả, khởi tạo = 1 (vì nhân dồn)
            // Dùng kiểu long vì 12! = 479,001,600 khá lớn, int có thể không đủ chứa trong 1 số trường hợp
            long ketQua = 1;

            // Vòng lặp từ 1 đến n, mỗi lần nhân dồn vào ketQua
            // Ví dụ n=5: ketQua lần lượt = 1, 1*2=2, 2*3=6, 6*4=24, 24*5=120
            for (int i = 1; i <= n; i++)
            {
                ketQua *= i;   // Tương đương ketQua = ketQua * i
            }

            return ketQua;
        }

        // Hàm tạo chuỗi hiển thị phép tính dạng "1.2.3.4.5"
        // Dùng để in ra màn hình cho đúng định dạng đề bài yêu cầu
        // Input: n
        // Output: chuỗi string, ví dụ n=5 -> "1.2.3.4.5"
        public static string TaoChuoiPhepTinh(int n)
        {
            // Bắt đầu chuỗi bằng "1" vì phép tính luôn có số 1 đầu tiên
            string chuoi = "1";

            // Bắt đầu từ i=2 (vì số 1 đã có sẵn), nối thêm ".i" vào chuỗi
            // Ví dụ n=5: chuoi lần lượt = "1" -> "1.2" -> "1.2.3" -> "1.2.3.4" -> "1.2.3.4.5"
            for (int i = 2; i <= n; i++)
            {
                chuoi += "." + i;   // Nối chuỗi: thêm dấu "." rồi tới số i
            }

            return chuoi;
        }
    }
}

