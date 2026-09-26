using System;

namespace Bai7_SoNguyenTo
{
    public class SoNguyenTo
    {
        // Phuong thuc tra ve bool: true neu n la so nguyen to, false neu khong phai
        public bool KiemTraSoNguyenTo(int n)
        {
            // So nguyen to phai lon hon 1 (0, 1, so am deu khong phai so nguyen to)
            if (n <= 1)
            {
                return false;
            }

            // 2 la so nguyen to nho nhat, xu ly rieng cho gon
            if (n == 2)
            {
                return true;
            }

            // So chan lon hon 2 thi chac chan khong phai so nguyen to
            if (n % 2 == 0)
            {
                return false;
            }

            // Chi can thu cac uoc le tu 3 den can bac hai cua n
            int gioiHan = (int)Math.Sqrt(n);

            for (int i = 3; i <= gioiHan; i += 2)
            {
                if (n % i == 0)
                {
                    return false; // tim thay uoc -> khong phai so nguyen to
                }
            }

            return true; // khong tim thay uoc nao -> la so nguyen to
        }
    }
}