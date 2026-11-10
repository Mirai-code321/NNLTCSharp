using System;

namespace Bai4_DayNguyenTo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DayNguyenTo xuLy = new DayNguyenTo();

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

            // Buoc 4: loc ra danh sach cac phan tu la so nguyen to
            var danhSachNguyenTo = xuLy.LayDanhSachSoNguyenTo(mang);

            // Buoc 5: in ket qua ra man hinh
            if (danhSachNguyenTo.Count == 0)
            {
                Console.WriteLine("Day so khong co phan tu nao la so nguyen to.");
            }
            else
            {
                int tong = xuLy.TinhTong(danhSachNguyenTo);
                double trungBinh = xuLy.TinhTrungBinh(danhSachNguyenTo);

                Console.WriteLine($"So luong so nguyen to: {danhSachNguyenTo.Count}");
                Console.WriteLine($"Tong cac so nguyen to: {tong}");
                Console.WriteLine($"Trung binh cong cac so nguyen to: {trungBinh:0.##}");
            }
        }
    }
}