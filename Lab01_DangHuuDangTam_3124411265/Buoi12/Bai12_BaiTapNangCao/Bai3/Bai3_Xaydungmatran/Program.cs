using System;

namespace Bai3_XayDungMaTran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XayDungMaTran xuLy = new XayDungMaTran();

            // Buoc 1: nhap so dong n va so cot m cua ma tran
            Console.Write("Nhap so dong n: ");
            int n = int.Parse(Console.ReadLine()!);

            Console.Write("Nhap so cot m: ");
            int m = int.Parse(Console.ReadLine()!);

            // Buoc 2: kiem tra dieu kien n, m (1 <= n, m <= 100) theo de bai
            if (!xuLy.KiemTraKichThuocHopLe(n) || !xuLy.KiemTraKichThuocHopLe(m))
            {
                Console.WriteLine("Kich thuoc ma tran khong hop le (yeu cau 1 <= n, m <= 100).");
                return;
            }

            // Buoc 3: nhap gia tri cho ma tran A (so thuc)
            Console.WriteLine($"Mang co {n} dong x {m} cot:");
            double[,] maTranA = xuLy.NhapMaTran(n, m);

            // Buoc 4: in lai ma tran A de nguoi dung kiem tra
            Console.WriteLine("Ma tran A:");
            xuLy.InMaTran(maTranA);

            // Buoc 5: xay dung ma tran B tu ma tran A
            int[,] maTranB = xuLy.XayDungMaTranB(maTranA);

            // Buoc 6: in ma tran B ra man hinh
            Console.WriteLine("Ma tran B (so phan tu duong xung quanh moi vi tri):");
            xuLy.InMaTran(maTranB);
        }
    }
}