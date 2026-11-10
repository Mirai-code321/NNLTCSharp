using System;

namespace Bai2_TanSoX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TanSoX xuLy = new TanSoX();

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

            // Buoc 4: nhap gia tri x can tim tan so xuat hien
            int x = xuLy.NhapGiaTriCanTim();

            // Buoc 5: dem tan so xuat hien cua x trong day so
            int tanSo = xuLy.DemTanSo(mang, x);

            // Buoc 6: in ket qua ra man hinh
            Console.WriteLine($"So {x} xuat hien {tanSo} lan trong day so.");
        }
    }
}