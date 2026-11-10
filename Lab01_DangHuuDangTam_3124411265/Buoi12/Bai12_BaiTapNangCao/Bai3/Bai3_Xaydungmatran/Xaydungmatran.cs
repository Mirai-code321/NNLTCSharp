using System;
using System.Globalization;

namespace Bai3_XayDungMaTran
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho ma tran A chua cac so thuc co n dong va m cot (1 <= n, m <= 100).
    //  Hay xay dung ma tran B cung kich thuoc n x m tu ma tran A sao cho
    //  B[i][j] la SO LUONG PHAN TU DUONG xung quanh A[i][j] trong ma tran A
    //  (moi phan tu co toi da 8 phan tu xung quanh no)."
    public class XayDungMaTran
    {
        // Gioi han kich thuoc ma tran toi da theo de bai
        private const int KICH_THUOC_TOI_DA = 100;

        // Ham kiem tra n hoac m co hop le hay khong (1 <= gia tri <= 100)
        public bool KiemTraKichThuocHopLe(int soLuong)
        {
            return soLuong >= 1 && soLuong <= KICH_THUOC_TOI_DA;
        }

        // Ham nhap ma tran A tu ban phim (so thuc)
        // Moi dong nguoi dung go m so thuc, cach nhau boi khoang trang
        public double[,] NhapMaTran(int n, int m)
        {
            double[,] maTran = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Dong {i}: ");
                string[] cacSo = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < m; j++)
                {
                    maTran[i, j] = double.Parse(cacSo[j], CultureInfo.InvariantCulture);
                }
            }

            return maTran;
        }

        // Ham in ma tran so thuc ra man hinh
        public void InMaTran(double[,] maTran)
        {
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{maTran[i, j],6}");
                }
                Console.WriteLine();
            }
        }

        // Ham in ma tran so nguyen ra man hinh (dung cho ma tran B)
        public void InMaTran(int[,] maTran)
        {
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{maTran[i, j],4}");
                }
                Console.WriteLine();
            }
        }

        // Dem so luong phan tu DUONG xung quanh vi tri (i, j) trong ma tran A
        // (toi da 8 phan tu: tren, duoi, trai, phai va 4 duong cheo)
        // Cac vi tri nam ngoai ma tran (khi (i, j) o bien) se KHONG duoc tinh.
        //
        // Pseudocode:
        //   dem = 0
        //   for moi huong lan can (di, dj) trong 8 huong xung quanh (i, j):
        //       toa do lang gieng = (i + di, j + dj)
        //       neu toa do lang gieng nam TRONG ma tran VA gia tri tai do > 0 thi:
        //           dem = dem + 1
        //   return dem
        public int DemSoPhanTuDuongXungQuanh(double[,] maTranA, int i, int j)
        {
            int n = maTranA.GetLength(0);
            int m = maTranA.GetLength(1);
            int dem = 0;

            for (int di = -1; di <= 1; di++)
            {
                for (int dj = -1; dj <= 1; dj++)
                {
                    if (di == 0 && dj == 0)
                    {
                        continue; // bo qua chinh no
                    }

                    int hangLangGieng = i + di;
                    int cotLangGieng = j + dj;

                    bool namTrongMaTran = hangLangGieng >= 0 && hangLangGieng < n
                                       && cotLangGieng >= 0 && cotLangGieng < m;

                    if (namTrongMaTran && maTranA[hangLangGieng, cotLangGieng] > 0)
                    {
                        dem++;
                    }
                }
            }

            return dem;
        }

        // Ham chinh: xay dung ma tran B cung kich thuoc voi A,
        // trong do B[i, j] la so luong phan tu duong xung quanh A[i, j]
        public int[,] XayDungMaTranB(double[,] maTranA)
        {
            int n = maTranA.GetLength(0);
            int m = maTranA.GetLength(1);
            int[,] maTranB = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    maTranB[i, j] = DemSoPhanTuDuongXungQuanh(maTranA, i, j);
                }
            }

            return maTranB;
        }
    }
}