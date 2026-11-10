using System;
using System.Globalization;

namespace Bai2_DemSoTrenBienMang2C
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho ma tran A chua cac so thuc co n dong va m cot (1 <= n, m <= 100).
    //  Dem cac so duong, am, va khong TREN BIEN ma tran A."
    //
    // "Bien" cua ma tran la cac phan tu thuoc DONG DAU, DONG CUOI,
    // COT DAU, hoac COT CUOI. Cac phan tu con lai (nam hoan toan ben trong)
    // duoc goi la phan tu noi bo va KHONG duoc tinh.
    public class DemSoTrenBienMang2C
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

        // Ham kiem tra phan tu tai vi tri (i, j) co nam TREN BIEN cua ma tran hay khong
        // Bien = dong dau (i == 0), dong cuoi (i == n - 1),
        //        cot dau (j == 0), hoac cot cuoi (j == m - 1)
        public bool LaPhanTuBien(int i, int j, int n, int m)
        {
            return i == 0 || i == n - 1 || j == 0 || j == m - 1;
        }

        // Ham chinh: dem so luong so duong, so am, so khong CHI TINH TREN BIEN ma tran
        //
        // Pseudocode:
        //   soDuong = 0, soAm = 0, soKhong = 0
        //   for moi vi tri (i, j) trong ma tran:
        //       neu (i, j) la phan tu bien thi:
        //           neu gia tri > 0 thi soDuong++
        //           nguoc lai neu gia tri < 0 thi soAm++
        //           nguoc lai thi soKhong++
        //   return (soDuong, soAm, soKhong)
        public (int SoDuong, int SoAm, int SoKhong) DemSoTrenBien(double[,] maTran)
        {
            int n = maTran.GetLength(0);
            int m = maTran.GetLength(1);

            int soDuong = 0;
            int soAm = 0;
            int soKhong = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (!LaPhanTuBien(i, j, n, m))
                    {
                        continue;
                    }

                    double giaTri = maTran[i, j];

                    if (giaTri > 0)
                    {
                        soDuong++;
                    }
                    else if (giaTri < 0)
                    {
                        soAm++;
                    }
                    else
                    {
                        soKhong++;
                    }
                }
            }

            return (soDuong, soAm, soKhong);
        }
    }
}