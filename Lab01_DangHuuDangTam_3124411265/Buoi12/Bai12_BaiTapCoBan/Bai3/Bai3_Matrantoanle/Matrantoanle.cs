using System;

namespace Bai3_MaTranToanLe
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho ma tran A chua cac so nguyen co n dong va m cot (1 <= n, m <= 100).
    //  Kiem tra xem ma tran co TOAN LE (tat ca phan tu deu la so le) hay khong."
    public class MaTranToanLe
    {
        // Gioi han kich thuoc ma tran toi da theo de bai
        private const int KICH_THUOC_TOI_DA = 100;

        // Ham kiem tra n hoac m co hop le hay khong (1 <= gia tri <= 100)
        public bool KiemTraKichThuocHopLe(int soLuong)
        {
            return soLuong >= 1 && soLuong <= KICH_THUOC_TOI_DA;
        }

        // Ham nhap ma tran A tu ban phim (so nguyen)
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

        // Ham chinh: kiem tra ma tran co TOAN LE hay khong
        // (nghia la MOI phan tu trong ma tran deu la so le)
        //
        // Pseudocode:
        //   for moi phan tu trong ma tran:
        //       neu phan tu la so chan (chia het cho 2) thi:
        //           tra ve false ngay lap tuc (chi can 1 phan tu chan la du)
        //   neu duyet het ma tran ma khong gap so chan nao: tra ve true
        public bool KiemTraToanLe(int[,] maTran)
        {
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (maTran[i, j] % 2 == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}