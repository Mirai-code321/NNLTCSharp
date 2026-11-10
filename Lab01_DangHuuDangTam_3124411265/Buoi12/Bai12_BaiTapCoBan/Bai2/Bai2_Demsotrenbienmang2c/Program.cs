using System;

namespace Bai2_DemSoTrenBienMang2C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DemSoTrenBienMang2C xuLy = new DemSoTrenBienMang2C();

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

            // Buoc 5: dem so duong, so am, so khong TREN BIEN ma tran
            var (soDuong, soAm, soKhong) = xuLy.DemSoTrenBien(maTranA);

            // Buoc 6: in ket qua ra man hinh
            Console.WriteLine($"Tren duong bien co {soDuong} so duong, {soAm} so am va {soKhong} so khong.");
        }
    }
}