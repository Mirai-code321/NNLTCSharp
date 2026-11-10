using System;

namespace Bai6_TimGiaTriLonNhat
{
    public class BaSoNguyen
    {
        // Tim gia tri lon nhat trong 3 so nguyen.
        // a, b, c la tham so duoc truyen theo THAM TRI (mac dinh cua kieu int):
        // ham chi nhan ban sao gia tri, khong lam thay doi bien goc ben ngoai.
        // Ket qua duoc lay ra bang return (khac voi ref/out se hoc o bai sau).
        public int TimGiaTriLonNhat(int a, int b, int c)
        {
            int max = a; // gia su a la lon nhat truoc

            if (b > max)
            {
                max = b;
            }

            if (c > max)
            {
                max = c;
            }

            return max;
        }
    }
}