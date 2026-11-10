using System;

namespace Bai1_LietKeSoChan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LietKeSoChan xuLy = new LietKeSoChan();

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

            // Buoc 4: liet ke cac phan tu chan theo thu tu tu phai sang trai
            var danhSachSoChan = xuLy.LayDanhSachSoChan(mang);

            // Buoc 5: in ket qua ra man hinh
            Console.WriteLine("Cac phan tu chan trong mang: " + xuLy.ChuyenDanhSachThanhChuoi(danhSachSoChan));
        }
    }
}