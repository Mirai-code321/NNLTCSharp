using System;

namespace Bai3_DemDau
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DemDau xuLy = new DemDau();

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

            // Buoc 4: dem so luong so duong, so am, so khong
            int soDuong = xuLy.DemSoDuong(mang);
            int soAm = xuLy.DemSoAm(mang);
            int soKhong = xuLy.DemSoKhong(mang);

            // Buoc 5: in ket qua ra man hinh theo dung dinh dang mau
            Console.WriteLine($"Day so co {soAm} so am, {soKhong} so khong va {soDuong} so duong.");
        }
    }
}