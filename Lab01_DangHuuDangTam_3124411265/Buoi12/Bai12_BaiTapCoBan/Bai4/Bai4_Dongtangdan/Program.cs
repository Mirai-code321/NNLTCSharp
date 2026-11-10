using System;

namespace Bai4_DongTangDan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DongTangDan xuLy = new DongTangDan();

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

            // Buoc 5: liet ke cac dong tao thanh day tang dan
            var danhSachDong = xuLy.LayDanhSachDongTangDan(maTranA);

            // Buoc 6: in ket qua ra man hinh
            if (danhSachDong.Count == 0)
            {
                Console.WriteLine("Khong co dong nao tao thanh day tang dan.");
            }
            else
            {
                Console.WriteLine("Cac dong tao thanh day tang: " + string.Join(" ", danhSachDong));
            }
        }
    }
}