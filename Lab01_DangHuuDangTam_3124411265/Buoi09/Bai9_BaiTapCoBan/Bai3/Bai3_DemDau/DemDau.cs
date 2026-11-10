using System;
using System.Globalization;

namespace Bai3_DemDau
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho day so thuc co n phan tu (n <= 500). Dem day so co bao nhieu
    //  so duong, so am, va so khong."
    public class DemDau
    {
        // Gioi han so phan tu toi da theo de bai
        private const int SO_PHAN_TU_TOI_DA = 500;

        // Ham nhap mang so thuc tu ban phim
        // Dung double vi de bai yeu cau "day so thuc"
        public double[] NhapMang(int n)
        {
            double[] mang = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan tu {i}: ");
                // Dung InvariantCulture de dau cham "." luon duoc hieu la dau thap phan
                mang[i] = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
            }

            return mang;
        }

        // Ham kiem tra n co hop le hay khong (0 < n <= 500)
        public bool KiemTraSoPhanTuHopLe(int n)
        {
            return n > 0 && n <= SO_PHAN_TU_TOI_DA;
        }

        // Dem so luong phan tu MANG GIA TRI DUONG (lon hon 0)
        //
        // Pseudocode:
        //   dem = 0
        //   for moi phan tu x trong mang:
        //       neu x > 0 thi dem = dem + 1
        //   return dem
        public int DemSoDuong(double[] mang)
        {
            int dem = 0;
            foreach (double x in mang)
            {
                if (x > 0)
                {
                    dem++;
                }
            }
            return dem;
        }

        // Dem so luong phan tu MANG GIA TRI AM (nho hon 0)
        public int DemSoAm(double[] mang)
        {
            int dem = 0;
            foreach (double x in mang)
            {
                if (x < 0)
                {
                    dem++;
                }
            }
            return dem;
        }

        // Dem so luong phan tu BANG 0
        public int DemSoKhong(double[] mang)
        {
            int dem = 0;
            foreach (double x in mang)
            {
                if (x == 0)
                {
                    dem++;
                }
            }
            return dem;
        }
    }
}