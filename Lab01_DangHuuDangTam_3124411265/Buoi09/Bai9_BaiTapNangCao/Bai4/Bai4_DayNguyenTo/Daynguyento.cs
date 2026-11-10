using System;
using System.Collections.Generic;

namespace Bai4_DayNguyenTo
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho day so nguyen co n phan tu (n <= 500). Liet ke so luong, tong va
    //  trung binh cong cac phan tu so nguyen to co trong day so."
    public class DayNguyenTo
    {
        // Gioi han so phan tu toi da theo de bai
        private const int SO_PHAN_TU_TOI_DA = 500;

        // Ham nhap mang so nguyen tu ban phim
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

        // Ham kiem tra mot so co phai la SO NGUYEN TO hay khong
        //
        // Pseudocode:
        //   neu so <= 1 thi khong phai nguyen to (tra ve false)
        //   neu so == 2 thi la nguyen to (tra ve true)
        //   neu so chan (chia het cho 2) thi khong phai nguyen to
        //   for i chay tu 3 den can bac hai cua so, buoc nhay 2:
        //       neu so chia het cho i thi khong phai nguyen to
        //   neu khong co uoc nao tim thay thi la nguyen to
        public bool LaSoNguyenTo(int so)
        {
            if (so <= 1)
            {
                return false;
            }

            if (so == 2)
            {
                return true;
            }

            if (so % 2 == 0)
            {
                return false;
            }

            int canBacHai = (int)Math.Sqrt(so);
            for (int i = 3; i <= canBacHai; i += 2)
            {
                if (so % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Ham chinh: loc ra danh sach cac phan tu la SO NGUYEN TO trong mang
        // (giu nguyen thu tu xuat hien trong mang goc)
        public List<int> LayDanhSachSoNguyenTo(int[] mang)
        {
            List<int> ketQua = new List<int>();

            foreach (int giaTri in mang)
            {
                if (LaSoNguyenTo(giaTri))
                {
                    ketQua.Add(giaTri);
                }
            }

            return ketQua;
        }

        // Tinh tong cac phan tu trong danh sach so nguyen to
        public int TinhTong(List<int> danhSachNguyenTo)
        {
            int tong = 0;
            foreach (int giaTri in danhSachNguyenTo)
            {
                tong += giaTri;
            }
            return tong;
        }

        // Tinh trung binh cong cac phan tu trong danh sach so nguyen to
        // Luu y: chi goi ham nay khi danh sach KHONG rong, de tranh chia cho 0
        public double TinhTrungBinh(List<int> danhSachNguyenTo)
        {
            int tong = TinhTong(danhSachNguyenTo);
            return (double)tong / danhSachNguyenTo.Count;
        }
    }
}