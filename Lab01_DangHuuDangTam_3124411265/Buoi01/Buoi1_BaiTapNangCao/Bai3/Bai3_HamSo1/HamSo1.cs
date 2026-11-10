// Khai bao thu vien
using System;
using HamSo1;

namespace HamSo1.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Khai bao bien
            double x, y1, y2;

            // Nhap du lieu
            Console.Write("Nhap so thuc x: ");
            x = double.Parse(Console.ReadLine()!);

            // Xu ly: goi ham tinh y1, y2 tu thu vien HamSo1
            y1 = TinhHamSo.TinhY1(x);
            y2 = TinhHamSo.TinhY2(x);

            // Xuat du lieu, lam tron 2 so le thap phan
            Console.WriteLine("y1 = {0:0.00}", y1);
            Console.WriteLine("y2 = {0:0.00}", y2);

            // Dung chuong trinh cho nhap phim
            Console.Read();
        }
    }
}

