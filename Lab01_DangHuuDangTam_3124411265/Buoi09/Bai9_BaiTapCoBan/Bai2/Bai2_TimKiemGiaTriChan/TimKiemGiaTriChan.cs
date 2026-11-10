using System;

namespace Bai2_TimKiemGiaTriChan
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho day so nguyen co n phan tu (n <= 500). Tim gia tri chan 'dau tien'
    //  va 'cuoi cung' cua day so nguyen."
    public class TimKiemGiaTriChan
    {
        // Gioi han so phan tu toi da theo de bai
        private const int SO_PHAN_TU_TOI_DA = 500;

        // Hang so danh dau "khong tim thay" (mang khong co phan tu chan nao)
        public const int KHONG_TIM_THAY = -1;

        // Ham nhap mang tu ban phim
        public int[] NhapMang(int n)
        {
            int[] mang = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan tu {i}: ");
                mang[i] = int.Parse(Console.ReadLine()!);
            }

            return mang;
        }

        // Ham kiem tra n co hop le hay khong (0 < n <= 500)
        public bool KiemTraSoPhanTuHopLe(int n)
        {
            return n > 0 && n <= SO_PHAN_TU_TOI_DA;
        }

        // Tim chi so cua gia tri chan DAU TIEN (duyet tu trai sang phai)
        //
        // Pseudocode:
        //   for i chay tu 0 den (n - 1):
        //       neu mang[i] chia het cho 2 thi:
        //           tra ve i (dung lai ngay khi gap phan tu chan dau tien)
        //   neu khong tim thay: tra ve KHONG_TIM_THAY
        public int TimChiSoChanDauTien(int[] mang)
        {
            for (int i = 0; i < mang.Length; i++)
            {
                if (mang[i] % 2 == 0)
                {
                    return i;
                }
            }

            return KHONG_TIM_THAY;
        }

        // Tim chi so cua gia tri chan CUOI CUNG (duyet tu phai sang trai)
        //
        // Pseudocode:
        //   for i chay tu (n - 1) giam dan ve 0:
        //       neu mang[i] chia het cho 2 thi:
        //           tra ve i (dung lai ngay khi gap phan tu chan dau tien tinh tu ben phai)
        //   neu khong tim thay: tra ve KHONG_TIM_THAY
        public int TimChiSoChanCuoiCung(int[] mang)
        {
            for (int i = mang.Length - 1; i >= 0; i--)
            {
                if (mang[i] % 2 == 0)
                {
                    return i;
                }
            }

            return KHONG_TIM_THAY;
        }
    }
}