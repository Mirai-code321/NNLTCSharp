using System;

namespace CosSin
{
    public class CosSinService
    {
        /// <summary>
        /// Tính cos(x) theo chuỗi Maclaurin: cos(x) = 1 - x^2/2! + x^4/4! - ...
        /// </summary>
        /// <param name="x">Góc x (tính bằng Radian)</param>
        /// <param name="epsilon">Độ sai số cho phép (> 0)</param>
        public static double TinhCos(double x, double epsilon)
        {
            // Kiểm tra ràng buộc độ sai số epsilon
            if (epsilon <= 0)
            {
                throw new ArgumentException("Epsilon phải lớn hơn 0.");
            }

            // Số hạng đầu tiên u_0 = 1 (tương ứng x^0 / 0!)
            double soHang = 1.0;
            
            // Biến tích lũy tổng chuỗi
            double tong = soHang;
            
            // Biến đếm bước lặp n (bắt đầu từ n = 1)
            int n = 1;

            // Vòng lặp dừng lại khi |số hạng| < epsilon
            while (Math.Abs(soHang) >= epsilon)
            {
                // Công thức quy nạp tính số hạng tiếp theo u_n từ u_{n-1}:
                // u_n = -u_{n-1} * x^2 / ((2n - 1) * 2n)
                // Giúp tránh việc tính riêng x^2n và (2n)! dễ bị tràn số
                soHang = -soHang * x * x / ((2 * n - 1) * (2 * n));
                
                // Cộng dồn số hạng mới vào tổng
                tong += soHang;
                
                // Tăng n lên cho bước tiếp theo
                n++;
            }

            return tong;
        }

        /// <summary>
        /// Tính sin(x) theo chuỗi Maclaurin: sin(x) = x - x^3/3! + x^5/5! - ...
        /// </summary>
        /// <param name="x">Góc x (tính bằng Radian)</param>
        /// <param name="epsilon">Độ sai số cho phép (> 0)</param>
        public static double TinhSin(double x, double epsilon)
        {
            if (epsilon <= 0)
            {
                throw new ArgumentException("Epsilon phải lớn hơn 0.");
            }

            // Số hạng đầu tiên u_0 = x (tương ứng x^1 / 1!)
            double soHang = x;
            
            // Biến tích lũy tổng chuỗi
            double tong = soHang;
            
            // Biến đếm bước lặp n (bắt đầu từ n = 1)
            int n = 1;

            // Vòng lặp dừng lại khi |số hạng| < epsilon
            while (Math.Abs(soHang) >= epsilon)
            {
                // Công thức quy nạp tính số hạng tiếp theo u_n từ u_{n-1}:
                // u_n = -u_{n-1} * x^2 / ((2n) * (2n + 1))
                soHang = -soHang * x * x / ((2 * n) * (2 * n + 1));
                
                // Cộng dồn số hạng mới vào tổng
                tong += soHang;
                
                // Tăng n lên cho bước tiếp theo
                n++;
            }

            return tong;
        }

        /// <summary>
        /// Kiểm tra giá trị Epsilon người dùng nhập vào
        /// </summary>
        public static bool KiemTraEpsilonHopLe(string? input, out double epsilon)
        {
            // Thay thế dấu phẩy bằng dấu chấm để chấp nhận mọi kiểu định dạng số thực
            bool parseThanhCong = double.TryParse(
                input?.Replace(',', '.'), 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.CultureInfo.InvariantCulture, 
                out epsilon
            );

            // Epsilon bắt buộc phải là số thực và lớn hơn 0
            return parseThanhCong && epsilon > 0;
        }
    }
}

