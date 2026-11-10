// Khai bao thu vien
using System;
using DoSangRadian;

namespace DoSangRadian.App
{
    // Don the chua diem vao chuong trinh
    class Program
    {
        // Phuong thuc diem vao chuong trinh
        public static void Main(string[] args)
        {
            // Khai bao bien
            double doGoc, radian;

            // Nhap du lieu
            Console.Write("Nhap so do (degree): ");
            doGoc = double.Parse(Console.ReadLine()!);

            // Xu ly: goi ham chuyen doi tu thu vien DoSangRadian
            radian = ChuyenDoiGoc.DoiSangRadian(doGoc);

            // Xuat du lieu (4 so le thap phan cho de nhin)
            Console.WriteLine("{0} do = {1:0.0000} radian", doGoc, radian);

            // Dung chuong trinh cho nhap phim
            Console.Read();
        }
    }
}

