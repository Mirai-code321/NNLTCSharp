using System;
using System.Collections.Generic;

namespace Bai3_TanSo
{
    // Lop nay chua cac ham xu ly chinh cho bai toan:
    // "Cho so nguyen n (n <= 1000) va day n so nguyen a0, a1, ..., a(n-1).
    //  Cho biet cac phan tu trong day xuat hien bao nhieu lan."
    public class TanSo
    {
        // Gioi han so phan tu toi da theo de bai
        private const int SO_PHAN_TU_TOI_DA = 1000;

        // Ham nhap mang so nguyen tu ban phim
        public int[] NhapMang(int n)
        {
            int[] mang = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan tu a{i}: ");
                mang[i] = int.Parse(Console.ReadLine()!);
            }

            return mang;
        }

        // Ham kiem tra n co hop le hay khong (0 < n <= 1000)
        public bool KiemTraSoPhanTuHopLe(int n)
        {
            return n > 0 && n <= SO_PHAN_TU_TOI_DA;
        }

        // Ham chinh: tinh tan so xuat hien cua TUNG GIA TRI PHAN BIET trong mang
        // Ket qua tra ve la danh sach cac cap (gia tri, so lan xuat hien),
        // theo dung THU TU XUAT HIEN LAN DAU cua moi gia tri trong mang.
        //
        // Pseudocode:
        //   danhSachGiaTri = danh sach rong (luu cac gia tri phan biet, theo thu tu gap lan dau)
        //   soLanDem = tu dien rong (gia tri -> so lan xuat hien)
        //
        //   for moi phan tu a[i] trong mang:
        //       neu a[i] chua tung xuat hien (chua co trong soLanDem) thi:
        //           them a[i] vao danhSachGiaTri
        //           soLanDem[a[i]] = 1
        //       nguoc lai:
        //           soLanDem[a[i]] = soLanDem[a[i]] + 1
        //
        //   ketQua = danh sach rong
        //   for moi gia tri v trong danhSachGiaTri (theo dung thu tu da luu):
        //       them cap (v, soLanDem[v]) vao ketQua
        //   return ketQua
        public List<(int GiaTri, int SoLan)> TinhTanSo(int[] mang)
        {
            List<int> danhSachGiaTri = new List<int>();
            Dictionary<int, int> soLanDem = new Dictionary<int, int>();

            foreach (int giaTri in mang)
            {
                if (!soLanDem.ContainsKey(giaTri))
                {
                    danhSachGiaTri.Add(giaTri);
                    soLanDem[giaTri] = 1;
                }
                else
                {
                    soLanDem[giaTri]++;
                }
            }

            List<(int GiaTri, int SoLan)> ketQua = new List<(int, int)>();
            foreach (int giaTri in danhSachGiaTri)
            {
                ketQua.Add((giaTri, soLanDem[giaTri]));
            }

            return ketQua;
        }
    }
}