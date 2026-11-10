using System;
using System.Globalization;

namespace Bai4_TimKiem
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho day so thuc co n phan tu (n <= 500) va so thuc x. Cho biet vi tri
    //  'dau tien', 'cuoi cung', va so lan xuat hien cua gia tri x."
    public class TimKiem
    {
        // Gioi han so phan tu toi da theo de bai
        private const int SO_PHAN_TU_TOI_DA = 500;

        // Hang so danh dau "khong tim thay"
        public const int KHONG_TIM_THAY = -1;

        // Ham nhap mang so thuc tu ban phim
        public double[] NhapMang(int n)
        {
            double[] mang = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan tu {i}: ");
                mang[i] = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            }

            return mang;
        }

        // Ham nhap gia tri x can tim tu ban phim
        public double NhapGiaTriCanTim()
        {
            Console.Write("Moi ban nhap gia tri x can tim: ");
            return double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
        }

        // Ham kiem tra n co hop le hay khong (0 < n <= 500)
        public bool KiemTraSoPhanTuHopLe(int n)
        {
            return n > 0 && n <= SO_PHAN_TU_TOI_DA;
        }

        // Tim vi tri XUAT HIEN DAU TIEN cua x trong mang (duyet tu trai sang phai)
        //
        // Pseudocode:
        //   for i chay tu 0 den (n - 1):
        //       neu mang[i] == x thi:
        //           tra ve i (dung ngay khi gap lan dau tien)
        //   neu khong tim thay: tra ve KHONG_TIM_THAY
        public int TimViTriDauTien(double[] mang, double x)
        {
            for (int i = 0; i < mang.Length; i++)
            {
                if (mang[i] == x)
                {
                    return i;
                }
            }

            return KHONG_TIM_THAY;
        }

        // Tim vi tri XUAT HIEN CUOI CUNG cua x trong mang (duyet tu phai sang trai)
        public int TimViTriCuoiCung(double[] mang, double x)
        {
            for (int i = mang.Length - 1; i >= 0; i--)
            {
                if (mang[i] == x)
                {
                    return i;
                }
            }

            return KHONG_TIM_THAY;
        }

        // Dem so lan xuat hien cua x trong mang
        //
        // Pseudocode:
        //   dem = 0
        //   for moi phan tu trong mang:
        //       neu phan tu == x thi dem = dem + 1
        //   return dem
        public int DemSoLanXuatHien(double[] mang, double x)
        {
            int dem = 0;
            foreach (double phanTu in mang)
            {
                if (phanTu == x)
                {
                    dem++;
                }
            }
            return dem;
        }
    }
}