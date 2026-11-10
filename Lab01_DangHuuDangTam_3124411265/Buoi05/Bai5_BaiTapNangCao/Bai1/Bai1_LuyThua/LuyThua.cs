using System;

namespace LuyThua
{
    public class LuyThuaService
    {
        /// <summary>
        /// Hàm tính a^n bằng cách nhân dồn (không dùng thư viện Math.Pow)
        /// </summary>
        /// <param name="a">Cơ số (số thực)</param>
        /// <param name="n">Số mũ (số nguyên)</param>
        /// <returns>Kết quả a^n</returns>
        public static double TinhLuyThua(double a, int n)
        {
            // Kiểm tra ràng buộc: Nếu n âm thì ném lỗi để Unit Test bắt trường hợp này
            if (n < 0)
            {
                throw new ArgumentException("Số mũ n phải là số nguyên không âm.");
            }

            // Khởi tạo biến tích ban đầu = 1 (vì bất kỳ số nào nhân với 1 cũng bằng chính nó)
            double ketQua = 1.0;

            // Chạy vòng lặp n lần, mỗi lần nhân dồn giá trị a vào ketQua
            for (int i = 0; i < n; i++)
            {
                ketQua *= a; // Tương đương với: ketQua = ketQua * a
            }

            return ketQua;
        }

        /// <summary>
        /// Hàm kiểm tra số mũ n nhập vào có đúng là số nguyên dương (n > 0) hay không
        /// </summary>
        /// <param name="input">Chuỗi văn bản người dùng nhập vào từ bàn phím</param>
        /// <param name="n">Giá trị số nguyên lấy ra nếu chuyển đổi thành công</param>
        /// <returns>True nếu hợp lệ (n > 0), ngược lại trả về False</returns>
        public static bool KiemTraSoMuHopLe(string? input, out int n)
        {
            // Ép kiểu chuỗi sang int an toàn, tránh văng lỗi crash app
            bool parseThanhCong = int.TryParse(input, out n);

            // Điều kiện đúng: Phải ép kiểu thành công VÀ số mũ n phải lớn hơn 0
            return parseThanhCong && n > 0;
        }
    }
}

