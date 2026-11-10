using System;
using System.Collections.Generic;

namespace Bai1_LietKeSoChan
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho day so nguyen co n phan tu (n <= 500). Liet ke cac phan tu chan
    //  trong mang theo thu tu tu phai sang trai."
    public class LietKeSoChan
    {
        // Gioi han so phan tu toi da theo de bai
        private const int SO_PHAN_TU_TOI_DA = 500;

        // Ham nhap mang tu ban phim
        // Dau vao: n - so luong phan tu can nhap
        // Dau ra: mang so nguyen da nhap
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

        // Ham chinh: liet ke cac phan tu chan trong mang theo thu tu TU PHAI SANG TRAI
        //
        // Mo ta thuat toan (pseudocode):
        //   ketQua = danh sach rong
        //   for i chay tu (n - 1) giam dan ve 0:
        //       neu mang[i] chia het cho 2 thi:
        //           them mang[i] vao ketQua
        //   return ketQua
        //
        // Vi di duyet mang tu chi so cuoi (ben phai) ve chi so dau (ben trai)
        // nen ket qua tra ve da tu nhien co thu tu tu phai sang trai,
        // khong can dao nguoc lai lan nua.
        public List<int> LayDanhSachSoChan(int[] mang)
        {
            List<int> ketQua = new List<int>();

            for (int i = mang.Length - 1; i >= 0; i--)
            {
                // Dieu kien mot so la so chan: phan du cho 2 bang 0
                if (mang[i] % 2 == 0)
                {
                    ketQua.Add(mang[i]);
                }
            }

            return ketQua;
        }

        // Ham ho tro: chuyen danh sach so nguyen thanh chuoi, cac so cach nhau boi dau cach
        // Vi du: [6, 2] -> "6 2"
        public string ChuyenDanhSachThanhChuoi(List<int> danhSach)
        {
            return string.Join(" ", danhSach);
        }
    }
}