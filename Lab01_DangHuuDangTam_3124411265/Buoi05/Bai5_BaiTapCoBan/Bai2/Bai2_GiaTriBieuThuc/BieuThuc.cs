using System;

namespace Bai2_GiaTriBieuThuc
{
    // Class chứa logic tính toán 2 biểu thức S1 và S2
    // Tách riêng khỏi Program.cs để dễ viết Unit Test
    public class BieuThuc
    {
        // Tính S1 = 1/1 + 1/2 + 1/3 + ... + 1/n
        // Input: n (số nguyên dương)
        // Output: giá trị S1 dạng double (vì kết quả là số thập phân)
        public static double Tinh_S1(int n)
        {
            double s1 = 0;

            // Cộng dồn từng phân số 1/i, i chạy từ 1 đến n
            for (int i = 1; i <= n; i++)
            {
                // Lưu ý: phải ép kiểu (double)1 / i hoặc dùng 1.0 / i
                // Vì nếu để 1 / i (cả 2 đều là int) thì C# sẽ làm phép chia nguyên -> luôn ra 0
                s1 += 1.0 / i;
            }

            return s1;
        }

        // Tính S2 = 1/n - 1/(n-1) + 1/(n-2) - ... + (-1)^(n+1) * 1/1
        // Nhận xét: số hạng thứ i (i=1,2,3...n) có:
        //   - Mẫu số = n - i + 1 (giảm dần từ n về 1)
        //   - Dấu = (+) nếu i lẻ, (-) nếu i chẵn -> dùng (-1)^(i+1)
        public static double Tinh_S2(int n)
        {
            double s2 = 0;

            for (int i = 1; i <= n; i++)
            {
                int mauSo = n - i + 1;               // Mẫu số giảm dần: n, n-1, n-2, ..., 1
                int dau = (i % 2 == 1) ? 1 : -1;      // i lẻ -> dấu +, i chẵn -> dấu -
                s2 += dau * (1.0 / mauSo);
            }

            return s2;
        }
    }
}

