using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bai1_TimPhanTuTrung
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho ma tran A chua cac so thuc co n dong va m cot (1 <= n, m <= 100).
    //  Mot phan tu duoc goi la TRUNG neu:
    //    - Phan tu nay KHONG nam tren bien cua ma tran, VA
    //    - Gia tri cua phan tu nay NHO HON ca 8 phan tu xung quanh no.
    //  Hay tim cac phan tu trung co trong ma tran."
    public class TimPhanTuTrung
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

        // Ham in ma tran ra man hinh, dung de nguoi dung kiem tra lai du lieu da nhap
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

        // Ham kiem tra phan tu tai (i, j) co nam TREN BIEN cua ma tran hay khong
        private bool LaPhanTuBien(int i, int j, int n, int m)
        {
            return i == 0 || i == n - 1 || j == 0 || j == m - 1;
        }

        // Ham kiem tra phan tu tai vi tri (i, j) co phai la PHAN TU TRUNG hay khong
        //
        // Pseudocode:
        //   neu (i, j) nam tren bien thi tra ve false (khong xet)
        //   for moi vi tri lan can (di, dj) trong 8 huong xung quanh (i, j):
        //       neu maTran[i, j] >= maTran[i + di, j + dj] thi:
        //           tra ve false (khong nho hon TAT CA 8 phan tu xung quanh)
        //   neu maTran[i, j] nho hon ca 8 phan tu xung quanh: tra ve true
        public bool LaPhanTuTrung(double[,] maTran, int i, int j)
        {
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            if (LaPhanTuBien(i, j, n, m))
            {
                return false;
            }

            for (int di = -1; di <= 1; di++)
            {
                for (int dj = -1; dj <= 1; dj++)
                {
                    if (di == 0 && dj == 0)
                    {
                        continue; // bo qua chinh no
                    }

                    if (maTran[i, j] >= maTran[i + di, j + dj])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Ham chinh: tim TAT CA cac phan tu trung trong ma tran
        // Ket qua tra ve la danh sach cac vi tri (Hang, Cot, GiaTri)
        public List<(int Hang, int Cot, double GiaTri)> TimTatCaPhanTuTrung(double[,] maTran)
        {
            List<(int, int, double)> ketQua = new List<(int, int, double)>();
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (LaPhanTuTrung(maTran, i, j))
                    {
                        ketQua.Add((i, j, maTran[i, j]));
                    }
                }
            }

            return ketQua;
        }
    }
}