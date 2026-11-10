using System;

namespace Bai3_MaTranToanLe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MaTranToanLe xuLy = new MaTranToanLe();

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

            // Buoc 3: nhap gia tri cho ma tran A
            Console.WriteLine($"Mang co {n} dong x {m} cot:");
            int[,] maTranA = xuLy.NhapMaTran(n, m);

            // Buoc 4: in lai ma tran de nguoi dung kiem tra
            xuLy.InMaTran(maTranA);

            // Buoc 5: kiem tra ma tran co toan le hay khong
            bool toanLe = xuLy.KiemTraToanLe(maTranA);

            // Buoc 6: in ket qua ra man hinh
            if (toanLe)
            {
                Console.WriteLine("Mang A toan le!");
            }
            else
            {
                Console.WriteLine("Mang A khong toan le.");
            }
        }
    }
}