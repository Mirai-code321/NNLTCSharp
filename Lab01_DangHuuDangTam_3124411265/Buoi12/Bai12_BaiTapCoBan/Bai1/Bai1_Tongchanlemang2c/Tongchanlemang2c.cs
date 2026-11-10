    using System;

namespace Bai1_TongChanLeMang2C
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho ma tran A chua cac so nguyen co n dong va m cot (1 <= n, m <= 100).
    //  Tinh tong cac so chan, so le co trong ma tran A."
    public class TongChanLeMang2C
    {
        // Gioi han kich thuoc ma tran toi da theo de bai
        private const int KICH_THUOC_TOI_DA = 100;

        // Ham kiem tra n hoac m co hop le hay khong (1 <= gia tri <= 100)
        public bool KiemTraKichThuocHopLe(int soLuong)
        {
            return soLuong >= 1 && soLuong <= KICH_THUOC_TOI_DA;
        }

        // Ham nhap ma tran A tu ban phim
        // Moi dong nguoi dung go m so nguyen, cach nhau boi khoang trang
        public int[,] NhapMaTran(int n, int m)
        {
            int[,] maTran = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Dong {i}: ");
                string[] cacSo = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < m; j++)
                {
                    maTran[i, j] = int.Parse(cacSo[j]);
                }
            }

            return maTran;
        }

        // Ham in ma tran ra man hinh, dung de nguoi dung kiem tra lai du lieu da nhap
        public void InMaTran(int[,] maTran)
        {
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{maTran[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        // Tinh TONG CAC SO CHAN co trong ma tran
        //
        // Pseudocode:
        //   tong = 0
        //   for moi phan tu trong ma tran:
        //       neu phan tu chia het cho 2 thi:
        //           tong = tong + phan tu
        //   return tong
        public int TinhTongSoChan(int[,] maTran)
        {
            int tong = 0;
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (maTran[i, j] % 2 == 0)
                    {
                        tong += maTran[i, j];
                    }
                }
            }

            return tong;
        }

        // Tinh TONG CAC SO LE co trong ma tran
        public int TinhTongSoLe(int[,] maTran)
        {
            int tong = 0;
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (maTran[i, j] % 2 != 0)
                    {
                        tong += maTran[i, j];
                    }
                }
            }

            return tong;
        }
    }
}   