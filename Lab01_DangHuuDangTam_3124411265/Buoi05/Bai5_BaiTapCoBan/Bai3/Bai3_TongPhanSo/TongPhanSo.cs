using System;

namespace Bai3_TongPhanSoSaiSo
{
    // Class chứa logic tính tổng phân số với điều kiện dừng theo sai số
    public class TongPhanSo
    {
        // Tính S = 1/a + 1/(a+1) + 1/(a+2) + ... cho đến khi 1/(a+n) < epsilon
        // Input: a (số thực), epsilon (sai số, <= 0.1)
        // Output: giá trị S dạng double
        public static double TinhTong(double a, double epsilon)
        {
            double s = 0;
            int n = 0; // n bắt đầu từ 0 -> số hạng đầu tiên là 1/(a+0) = 1/a

            // Tính số hạng hiện tại: 1/(a+n)
            double soHang = 1.0 / (a + n);

            // Lặp: chỉ cộng vào tổng KHI số hạng còn >= epsilon
            // Ngay khi số hạng < epsilon thì dừng, KHÔNG cộng số hạng đó vào S
            while (soHang >= epsilon)
            {
                s += soHang;   // Cộng số hạng hiện tại vào tổng
                n++;           // Tăng n để tính số hạng tiếp theo: 1/(a+1), 1/(a+2), ...
                soHang = 1.0 / (a + n); // Tính lại số hạng mới với n đã tăng
            }

            return s;
        }
    }
}

