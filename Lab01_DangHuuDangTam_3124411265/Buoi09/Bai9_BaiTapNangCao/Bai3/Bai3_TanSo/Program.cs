using System;

namespace Bai3_TanSo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TanSo xuLy = new TanSo();

            // Buoc 1: nhap so luong phan tu cua day so
            Console.Write("Moi ban nhap so luong phan tu n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Buoc 2: kiem tra dieu kien n (0 < n <= 1000) theo de bai
            if (!xuLy.KiemTraSoPhanTuHopLe(n))
            {
                Console.WriteLine("So luong phan tu khong hop le (yeu cau 0 < n <= 1000).");
                return;
            }

            // Buoc 3: nhap gia tri cho tung phan tu a0, a1, ..., a(n-1)
            int[] mang = xuLy.NhapMang(n);

            // Buoc 4: tinh tan so xuat hien cua tung gia tri phan biet
            var danhSachTanSo = xuLy.TinhTanSo(mang);

            // Buoc 5: in ket qua ra man hinh, moi gia tri phan biet mot dong
            Console.WriteLine("Tan so xuat hien cua cac phan tu trong day:");
            foreach (var (giaTri, soLan) in danhSachTanSo)
            {
                Console.WriteLine($"Gia tri {giaTri} xuat hien {soLan} lan.");
            }
        }
    }
}