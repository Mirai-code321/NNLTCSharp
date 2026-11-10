using System;
using System.Collections.Generic;

namespace Bai4_DongTangDan
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho ma tran A chua cac so nguyen co n dong va m cot (1 <= n, m <= 100).
    //  Liet ke cac dong ma cac gia tri tao thanh day TANG DAN."
    public class DongTangDan
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

        // Ham kiem tra MOT DONG cu the (chi so hang i) co tao thanh
        // day TANG DAN (moi phan tu sau lon hon phan tu ngay truoc) hay khong
        //
        // Pseudocode:
        //   for j chay tu 0 den (m - 2):
        //       neu maTran[i, j] >= maTran[i, j + 1] thi:
        //           tra ve false (gap cap phan tu khong tang)
        //   neu duyet het ma khong gap loi: tra ve true
        public bool LaDongTangDan(int[,] maTran, int hang)
        {
            int m = maTran.GetLength(1);

            for (int j = 0; j < m - 1; j++)
            {
                if (maTran[hang, j] >= maTran[hang, j + 1])
                {
                    return false;
                }
            }

            return true;
        }

        // Ham chinh: liet ke TAT CA cac chi so dong ma tao thanh day tang dan
        public List<int> LayDanhSachDongTangDan(int[,] maTran)
        {
            List<int> ketQua = new List<int>();
            int n = maTran.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                if (LaDongTangDan(maTran, i))
                {
                    ketQua.Add(i);
                }
            }

            return ketQua;
        }
    }
}