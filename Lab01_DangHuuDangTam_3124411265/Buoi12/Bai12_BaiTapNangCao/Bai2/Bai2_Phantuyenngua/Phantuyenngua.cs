using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bai2_PhanTuYenNgua
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho ma tran A chua cac so thuc co n dong va m cot (1 <= n, m <= 100).
    //  Mot phan tu duoc goi la DIEM YEN NGUA neu phan tu do la:
    //    - Phan tu NHO NHAT trong DONG chua no, VA
    //    - Phan tu LON NHAT trong COT chua no.
    //  Xac dinh tat ca cac diem yen ngua co the co."
    public class PhanTuYenNgua
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

        // Tim GIA TRI NHO NHAT trong mot DONG cu the (chi so hang)
        private double TimGiaTriNhoNhatTrongDong(double[,] maTran, int hang)
        {
            int m = maTran.GetLength(1);
            double nhoNhat = maTran[hang, 0];

            for (int j = 1; j < m; j++)
            {
                if (maTran[hang, j] < nhoNhat)
                {
                    nhoNhat = maTran[hang, j];
                }
            }

            return nhoNhat;
        }

        // Tim GIA TRI LON NHAT trong mot COT cu the (chi so cot)
        private double TimGiaTriLonNhatTrongCot(double[,] maTran, int cot)
        {
            int n = maTran.GetLength(0);
            double lonNhat = maTran[0, cot];

            for (int i = 1; i < n; i++)
            {
                if (maTran[i, cot] > lonNhat)
                {
                    lonNhat = maTran[i, cot];
                }
            }

            return lonNhat;
        }

        // Ham kiem tra phan tu tai vi tri (i, j) co phai la DIEM YEN NGUA hay khong
        //
        // Pseudocode:
        //   giaTriNhoNhatDong = gia tri nho nhat trong dong i
        //   giaTriLonNhatCot  = gia tri lon nhat trong cot j
        //   neu maTran[i, j] == giaTriNhoNhatDong VA maTran[i, j] == giaTriLonNhatCot thi:
        //       tra ve true
        //   nguoc lai: tra ve false
        public bool LaDiemYenNgua(double[,] maTran, int i, int j)
        {
            double giaTriNhoNhatDong = TimGiaTriNhoNhatTrongDong(maTran, i);
            double giaTriLonNhatCot = TimGiaTriLonNhatTrongCot(maTran, j);

            return maTran[i, j] == giaTriNhoNhatDong && maTran[i, j] == giaTriLonNhatCot;
        }

        // Ham chinh: tim TAT CA cac diem yen ngua trong ma tran
        // Ket qua tra ve la danh sach cac vi tri (Hang, Cot, GiaTri)
        public List<(int Hang, int Cot, double GiaTri)> TimTatCaDiemYenNgua(double[,] maTran)
        {
            List<(int, int, double)> ketQua = new List<(int, int, double)>();
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (LaDiemYenNgua(maTran, i, j))
                    {
                        ketQua.Add((i, j, maTran[i, j]));
                    }
                }
            }

            return ketQua;
        }
    }
}