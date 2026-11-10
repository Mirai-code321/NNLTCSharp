using System;
using System.Collections.Generic;

namespace Bai4_Robot
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho ma tran A gom cac so nguyen cap n x m (1 <= n, m <= 100). Robot dat
    //  tai o (0, 0). Voi day lenh chuong trinh B gom toi da k lenh
    //  (1 <= k <= 200), tinh tong cac o ma robot di qua theo day lenh
    //  (robot co the di qua nhieu lan mot o, moi lan di qua deu duoc cong don)."
    //
    // Quy uoc lenh dieu khien:
    //   1 = di qua PHAI  (cot tang len 1)
    //   2 = di XUONG     (hang tang len 1)
    //   3 = di qua TRAI  (cot giam di 1)
    //   4 = di LEN       (hang giam di 1)
    public class Robot
    {
        // Gioi han kich thuoc ma tran toi da theo de bai
        private const int KICH_THUOC_TOI_DA = 100;

        // Gioi han so luong lenh toi da theo de bai
        private const int SO_LENH_TOI_DA = 200;

        // Ham kiem tra n hoac m co hop le hay khong (1 <= gia tri <= 100)
        public bool KiemTraKichThuocHopLe(int soLuong)
        {
            return soLuong >= 1 && soLuong <= KICH_THUOC_TOI_DA;
        }

        // Ham kiem tra so luong lenh k co hop le hay khong (1 <= k <= 200)
        public bool KiemTraSoLenhHopLe(int k)
        {
            return k >= 1 && k <= SO_LENH_TOI_DA;
        }

        // Ham nhap ma tran A tu ban phim (so nguyen)
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

        // Ham in ma tran ra man hinh
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

        // Ham nhap day lenh chuong trinh B tu ban phim
        // Nguoi dung go k so (1, 2, 3, hoac 4), cach nhau boi khoang trang
        public List<int> NhapDayLenh(int k)
        {
            Console.Write($"Nhap {k} lenh (cach nhau boi khoang trang): ");
            string[] cacLenh = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<int> danhSachLenh = new List<int>();
            for (int i = 0; i < k; i++)
            {
                danhSachLenh.Add(int.Parse(cacLenh[i]));
            }

            return danhSachLenh;
        }

        // Ham chinh: cho robot di theo day lenh B, tinh TONG GIA TRI cac o
        // ma robot di qua (bao gom o xuat phat (0, 0), cong don ca khi
        // di qua lai cung mot o nhieu lan)
        //
        // Pseudocode:
        //   hang = 0, cot = 0
        //   tong = A[hang, cot]           (tinh o xuat phat)
        //   for moi lenh trong day lenh B:
        //       neu lenh == 1: cot = cot + 1        (qua phai)
        //       neu lenh == 2: hang = hang + 1       (xuong)
        //       neu lenh == 3: cot = cot - 1         (qua trai)
        //       neu lenh == 4: hang = hang - 1       (len)
        //       tong = tong + A[hang, cot]           (cong gia tri o moi den)
        //   return tong
        public int TinhTongDuongDi(int[,] maTranA, List<int> danhSachLenh)
        {
            int n = maTranA.GetLength(0);
            int m = maTranA.GetLength(1);

            int hang = 0;
            int cot = 0;
            int tong = maTranA[hang, cot];

            foreach (int lenh in danhSachLenh)
            {
                switch (lenh)
                {
                    case 1: cot++; break;  // qua phai
                    case 2: hang++; break; // xuong
                    case 3: cot--; break;  // qua trai
                    case 4: hang--; break; // len
                    default:
                        throw new ArgumentException($"Lenh khong hop le: {lenh}. Chi chap nhan cac gia tri 1, 2, 3, 4.");
                }

                if (hang < 0 || hang >= n || cot < 0 || cot >= m)
                {
                    throw new InvalidOperationException(
                        $"Robot di ra ngoai ma tran tai vi tri (hang={hang}, cot={cot}).");
                }

                tong += maTranA[hang, cot];
            }

            return tong;
        }
    }
}