using System;

namespace Bai4_TimKiem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimKiem xuLy = new TimKiem();

            // Buoc 1: nhap so luong phan tu cua mang
            Console.Write("Moi ban nhap so luong phan tu: ");
            int n = int.Parse(Console.ReadLine()!);

            // Buoc 2: kiem tra dieu kien n (0 < n <= 500) theo de bai
            if (!xuLy.KiemTraSoPhanTuHopLe(n))
            {
                Console.WriteLine("So luong phan tu khong hop le (yeu cau 0 < n <= 500).");
                return;
            }

            // Buoc 3: nhap gia tri cho tung phan tu cua mang (so thuc)
            double[] mang = xuLy.NhapMang(n);

            // Buoc 3.1: in lai dãy so vua nhap de nguoi dung kiem tra lai
            Console.WriteLine($"Day so co {n} phan tu: " + string.Join(" ", mang));

            // Buoc 4: nhap gia tri x can tim kiem
            Console.WriteLine("* Tim kiem");
            double x = xuLy.NhapGiaTriCanTim();

            // Buoc 5: dem so lan xuat hien va tim vi tri dau tien / cuoi cung
            int soLanXuatHien = xuLy.DemSoLanXuatHien(mang, x);

            // Buoc 6: in ket qua ra man hinh
            if (soLanXuatHien == 0)
            {
                Console.WriteLine($"Gia tri {x} khong ton tai trong day so.");
            }
            else
            {
                int viTriDauTien = xuLy.TimViTriDauTien(mang, x);
                int viTriCuoiCung = xuLy.TimViTriCuoiCung(mang, x);

                Console.WriteLine($"Gia tri {x} xuat hien {soLanXuatHien} lan o vi tri dau tien {viTriDauTien} va cuoi cung {viTriCuoiCung}.");
            }
        }
    }
}