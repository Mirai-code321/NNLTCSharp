using System;
using System.Collections.Generic;

namespace Bai1_TimKiemCacViTri
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho day so nguyen co n phan tu (n <= 500). Voi gia tri x cho truoc,
    //  tim tat ca cac vi tri cua cac phan tu trong mang co gia tri bang x."
    public class TimKiemCacViTri
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

        // Ham nhap gia tri x can tim tu ban phim
        public int NhapGiaTriCanTim()
        {
            Console.Write("Moi ban nhap gia tri x can tim: ");
            return int.Parse(Console.ReadLine()!);
        }

        // Ham kiem tra n co hop le hay khong (0 < n <= 500)
        public bool KiemTraSoPhanTuHopLe(int n)
        {
            return n > 0 && n <= SO_PHAN_TU_TOI_DA;
        }

        // Ham chinh: tim TAT CA cac vi tri (chi so) trong mang co gia tri bang x
        //
        // Pseudocode:
        //   ketQua = danh sach rong
        //   for i chay tu 0 den (n - 1):
        //       neu mang[i] == x thi:
        //           them i vao ketQua
        //   return ketQua
        public List<int> TimTatCaViTri(int[] mang, int x)
        {
            List<int> ketQua = new List<int>();

            for (int i = 0; i < mang.Length; i++)
            {
                if (mang[i] == x)
                {
                    ketQua.Add(i);
                }
            }

            return ketQua;
        }

        // Ham ho tro: chuyen danh sach vi tri thanh chuoi, cac so cach nhau boi dau cach
        // Vi du: [1, 3, 4] -> "1 3 4"
        public string ChuyenDanhSachThanhChuoi(List<int> danhSach)
        {
            return string.Join(" ", danhSach);
        }
    }
}