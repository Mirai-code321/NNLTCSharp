using System;
using System.Numerics;

namespace Bai3_NhapSoNguyen.Lib
{
    public class LuyThua
    {
        // cơ số và số mũ, để private, chỉ đọc qua constructor
        private int x;
        private int y;

        public LuyThua(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Tính x^y.
        public BigInteger Tinh()
        {
            // số mũ âm thì kết quả là phân số, bài này chỉ xét số mũ không âm
            if (y < 0)
                throw new ArgumentOutOfRangeException("y", "So mu phai khong am");

            // x^y = x * x * ... * x (y lần). Bắt đầu từ 1 nên y = 0 cho ra 1,
            // vòng lặp không chạy lần nào.
            // Dùng BigInteger thay vì int/long vì 10^10 hay 2^100 đều tràn kiểu int.
            BigInteger ketQua = 1;
            for (int i = 0; i < y; i++)
            {
                ketQua = ketQua * x;
            }
            return ketQua;
        }
    }
}