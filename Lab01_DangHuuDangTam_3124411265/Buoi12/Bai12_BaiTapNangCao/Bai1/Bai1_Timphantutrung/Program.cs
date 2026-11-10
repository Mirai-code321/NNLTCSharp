using System;

namespace Bai1_TimPhanTuTrung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimPhanTuTrung xuLy = new TimPhanTuTrung();

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

            // Buoc 4: in lai ma tran de nguoi dung kiem tra
            xuLy.InMaTran(maTranA);

            // Buoc 5: tim tat ca cac phan tu trung
            var danhSachTrung = xuLy.TimTatCaPhanTuTrung(maTranA);

            // Buoc 6: in ket qua ra man hinh
            if (danhSachTrung.Count == 0)
            {
                Console.WriteLine("Khong co phan tu trung nao trong ma tran.");
            }
            else
            {
                Console.WriteLine("Cac phan tu trung trong ma tran:");
                foreach (var (hang, cot, giaTri) in danhSachTrung)
                {
                    Console.WriteLine($"Vi tri ({hang}, {cot}) co gia tri {giaTri}.");
                }
            }
        }
    }
}