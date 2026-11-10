using System;

namespace Bai17_MangHaiChieu
{
    class Program
    {
        static void Main()
        {
            int n = NhapSoNguyenDuong("Nhap so hang n: ");
            int m = NhapSoNguyenDuong("Nhap so cot m: ");

            MangHaiChieu tools = new MangHaiChieu(); // phai new doi tuong vi la instance method

            int[,] mang = tools.SinhNgauNhien(n, m);

            Console.WriteLine("\nMang A vua sinh ngau nhien:");
            tools.InMang(mang);

            int[] mangChan = tools.LayMangChan(mang);
            int[] mangLe = tools.LayMangLe(mang);

            Console.WriteLine("\nCac so chan trong mang:");
            Console.WriteLine(mangChan.Length > 0 ? string.Join(" ", mangChan) : "(Khong co)");

            Console.WriteLine("\nCac so le trong mang:");
            Console.WriteLine(mangLe.Length > 0 ? string.Join(" ", mangLe) : "(Khong co)");
        }

        // Nhap so nguyen duong, lap lai neu nhap sai dinh dang hoac <= 0
        static int NhapSoNguyenDuong(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string? dong = Console.ReadLine();
                if (int.TryParse(dong, out int giaTri) && giaTri > 0)
                    return giaTri;
                Console.WriteLine("Loi: vui long nhap so nguyen duong!");
            }
        }
    }
}