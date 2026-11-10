using System;
using System.Collections.Generic;

namespace Bai17_MangHaiChieu
{
    public class MangHaiChieu
    {
        // Dung 1 Random duy nhat cho ca lop, tao 1 lan trong constructor
        // (tranh loi hay gap: new Random() lien tuc trong vong lap se cho ket qua giong nhau do cung seed thoi gian)
        private readonly Random ngauNhien;

        public MangHaiChieu()
        {
            ngauNhien = new Random();
        }

        // Sinh ngau nhien mang A[n x m], gia tri trong doan [10, 100]
        // Dung int[,] (mang 2 chieu that su) thay vi mang jagged vi n, m co kich thuoc co dinh tu dau
        public int[,] SinhNgauNhien(int n, int m)
        {
            int[,] mang = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // Random.Next(min, max) can cai bien tren, +1 de 100 cung co the xuat hien
                    mang[i, j] = ngauNhien.Next(10, 101);
                }
            }
            return mang;
        }

        // In mang ra man hinh, moi hang 1 dong, cac phan tu cach nhau bang tab cho thang cot
        public void InMang(int[,] mang)
        {
            int n = mang.GetLength(0);
            int m = mang.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(mang[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Duyet toan bo mang 2 chieu, gom cac phan tu chan vao mang 1 chieu
        // Dung List<int> vi khong biet truoc so luong so chan se co bao nhieu
        public int[] LayMangChan(int[,] mang)
        {
            List<int> ketQua = new List<int>();
            int n = mang.GetLength(0);
            int m = mang.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mang[i, j] % 2 == 0) ketQua.Add(mang[i, j]);
                }
            }
            return ketQua.ToArray();
        }

        // Duyet toan bo mang 2 chieu, gom cac phan tu le vao mang 1 chieu
        public int[] LayMangLe(int[,] mang)
        {
            List<int> ketQua = new List<int>();
            int n = mang.GetLength(0);
            int m = mang.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (mang[i, j] % 2 != 0) ketQua.Add(mang[i, j]);
                }
            }
            return ketQua.ToArray();
        }
    }
}