using System;

namespace Bai4_Robot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot xuLy = new Robot();

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

            Console.WriteLine("Ma tran A:");
            xuLy.InMaTran(maTranA);

            // Buoc 4: nhap so luong lenh k va day lenh chuong trinh B
            Console.Write("Nhap so luong lenh k: ");
            int k = int.Parse(Console.ReadLine()!);

            if (!xuLy.KiemTraSoLenhHopLe(k))
            {
                Console.WriteLine("So luong lenh khong hop le (yeu cau 1 <= k <= 200).");
                return;
            }

            var danhSachLenh = xuLy.NhapDayLenh(k);

            // Buoc 5: tinh tong cac o ma robot di qua theo day lenh B
            int tong = xuLy.TinhTongDuongDi(maTranA, danhSachLenh);

            // Buoc 6: in ket qua ra man hinh
            Console.WriteLine($"Tong gia tri cac o robot di qua la: {tong}");
        }
    }
}