using System;

namespace TimLonNhat
{
    public class TimLonNhatService
    {
        /// <summary>
        /// (a) Tìm số nguyên k lớn nhất sao cho 4^k < n
        /// </summary>
        /// <param name="n">Số tự nhiên n (n > 1)</param>
        /// <returns>Giá trị k hợp lệ lớn nhất</returns>
        public static int TimKLonNhat(long n)
        {
            // Kiểm tra điều kiện đầu vào: Nếu n <= 1 thì không tồn tại k >= 0 để 4^k < n (vì 4^0 = 1)
            if (n <= 1)
            {
                throw new ArgumentException("Để có 4^k < n với k >= 0 thì n phải lớn hơn 1.");
            }

            int k = 0;              // Khởi tạo k = 0
            long luyThua = 1;       // Giá trị 4^0 = 1

            // Vòng lặp: Kiểm tra nếu lấy giá trị hiện tại nhân 4 (tức 4^(k+1)) mà vẫn nhỏ hơn n
            // thì tiếp tục nhân 4 và tăng số mũ k lên 1
            while (luyThua * 4 < n)
            {
                luyThua *= 4;       // Tăng lũy thừa lên gấp 4 lần
                k++;                // Tăng biến đếm k
            }

            return k;               // Trả về số nguyên k lớn nhất thỏa mãn
        }

        /// <summary>
        /// (b) Tìm số nguyên bé nhất có dạng 2^k không bé hơn n (tức là 2^k >= n)
        /// </summary>
        /// <param name="n">Số tự nhiên n (n > 0)</param>
        /// <returns>Giá trị 2^k nhỏ nhất thỏa mãn lớn hơn hoặc bằng n</returns>
        public static long Tim2MuKNhoNhat(long n)
        {
            // Kiểm tra ràng buộc n phải là số tự nhiên dương
            if (n <= 0)
            {
                throw new ArgumentException("n phải là số tự nhiên lớn hơn 0.");
            }

            long giatri = 1;        // Khởi tạo giá trị ban đầu là 2^0 = 1

            // Vòng lặp: Nếu giá trị hiện tại vẫn bé hơn n thì tiếp tục nhân đôi (tăng k)
            while (giatri < n)
            {
                giatri *= 2;        // Nhân đôi giá trị (tương đương với 2^(k+1))
            }

            return giatri;          // Khi giatri >= n thì dừng và trả về giá trị 2^k đó
        }

        /// <summary>
        /// Kiểm tra chuỗi nhập vào có phải số tự nhiên hợp lệ (n > 0) hay không
        /// </summary>
        public static bool KiemTraNHopLe(string? input, out long n)
        {
            // Ép kiểu chuỗi về số nguyên long (tránh văng lỗi khi nhập sai định dạng)
            bool parseThanhCong = long.TryParse(input, out n);

            // Trả về true nếu ép kiểu thành công và n là số dương
            return parseThanhCong && n > 0;
        }
    }
}

