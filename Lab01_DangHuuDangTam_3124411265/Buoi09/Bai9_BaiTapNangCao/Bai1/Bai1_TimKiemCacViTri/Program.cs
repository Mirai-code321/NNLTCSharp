using System;

namespace Bai1_TimKiemCacViTri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimKiemCacViTri xuLy = new TimKiemCacViTri();

            // Buoc 1: nhap so luong phan tu cua mang
            Console.Write("Moi ban nhap so luong phan tu: ");
            int n = int.Parse(Console.ReadLine()!);

            // Buoc 2: kiem tra dieu kien n (0 < n <= 500) theo de bai
            if (!xuLy.KiemTraSoPhanTuHopLe(n))
            {
                Console.WriteLine("So luong phan tu khong hop le (yeu cau 0 < n <= 500).");
                return;
            }

            // Buoc 3: nhap gia tri cho tung phan tu cua mang
            int[] mang = xuLy.NhapMang(n);

            // Buoc 4: nhap gia tri x can tim kiem
            int x = xuLy.NhapGiaTriCanTim();

            // Buoc 5: tim tat ca cac vi tri co gia tri bang x
            var danhSachViTri = xuLy.TimTatCaViTri(mang, x);

            // Buoc 6: in ket qua ra man hinh
            if (danhSachViTri.Count == 0)
            {
                Console.WriteLine($"Khong co phan tu nao trong mang bang {x}.");
            }
            else
            {
                Console.WriteLine($"Gia tri {x} xuat hien tai cac vi tri: {xuLy.ChuyenDanhSachThanhChuoi(danhSachViTri)}");
            }
        }
    }
}