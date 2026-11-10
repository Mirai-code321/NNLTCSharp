using System;

namespace Bai2_TanSoX
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho so nguyen n (n <= 1000) va day n so nguyen a0, a1, ..., a(n-1).
    //  Voi so nguyen x cho truoc, cho biet so x xuat hien bao nhieu lan
    //  trong day so."
    public class TanSoX
    {
        // Gioi han so phan tu toi da theo de bai
        private const int SO_PHAN_TU_TOI_DA = 1000;

        // Ham nhap mang so nguyen tu ban phim
        public int[] NhapMang(int n)
        {
            int[] mang = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan tu a{i}: ");
                mang[i] = int.Parse(Console.ReadLine()!);
            }

            return mang;
        }

        // Ham nhap gia tri x can tim tan so tu ban phim
        public int NhapGiaTriCanTim()
        {
            Console.Write("Moi ban nhap gia tri x can tim tan so: ");
            return int.Parse(Console.ReadLine()!);
        }

        // Ham kiem tra n co hop le hay khong (0 < n <= 1000)
        public bool KiemTraSoPhanTuHopLe(int n)
        {
            return n > 0 && n <= SO_PHAN_TU_TOI_DA;
        }

        // Ham chinh: dem so lan xuat hien (tan so) cua x trong mang
        //
        // Pseudocode:
        //   dem = 0
        //   for moi phan tu a[i] trong mang:
        //       neu a[i] == x thi:
        //           dem = dem + 1
        //   return dem
        public int DemTanSo(int[] mang, int x)
        {
            int dem = 0;

            foreach (int giaTri in mang)
            {
                if (giaTri == x)
                {
                    dem++;
                }
            }

            return dem;
        }
    }
}