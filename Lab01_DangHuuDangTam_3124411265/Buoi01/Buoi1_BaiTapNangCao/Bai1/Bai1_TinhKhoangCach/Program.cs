// Khai bao thu vien
using System;
using KhoangCach;

namespace KhoangCach.App
{
    // Don the chua diem vao chuong trinh
    class Program
    {
        // Phuong thuc diem vao chuong trinh
        public static void Main(string[] args)
        {
            // Khai bao bien
            double x1, y1, x2, y2, d;

            // Nhap du lieu toa do diem A
            Console.Write("Nhap x1: ");
            x1 = double.Parse(Console.ReadLine()!);
            Console.Write("Nhap y1: ");
            y1 = double.Parse(Console.ReadLine()!);

            // Nhap du lieu toa do diem B
            Console.Write("Nhap x2: ");
            x2 = double.Parse(Console.ReadLine()!);
            Console.Write("Nhap y2: ");
            y2 = double.Parse(Console.ReadLine()!);

            // Xu ly: goi ham tinh khoang cach tu thu vien KhoangCach
            d = TinhKhoangCach.TinhKC(x1, y1, x2, y2);

            // Xuat du lieu, lam tron 2 so le thap phan
            Console.WriteLine("Khoang cach AB = {0:0.00}", d);

            // Dung chuong trinh cho nhap phim
            Console.Read();
        }
    }
}

