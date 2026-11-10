using System;

namespace Bai15_XuLyMang
{
    class Program
    {
        static void Main()
        {
            int n = NhapSoNguyenDuong("Nhap so phan tu cua mang: ");
            MangTools tools = new MangTools(); // phai new doi tuong vi cac ham nghiep vu la instance method

            int[] mang = tools.NhapMang(n);

            Console.WriteLine("Mang vua nhap:");
            tools.InMang(mang);

            // Goi ham co out, phai khai bao bien nhan gia tri ngay tai cho gan (out int max, out int min)
            tools.TimMaxMin(mang, out int max, out int min);
            Console.WriteLine($"Phan tu lon nhat: {max}");
            Console.WriteLine($"Phan tu nho nhat: {min}");

            int[] mangNguyenTo = tools.LayMangSoNguyenTo(mang);
            Console.WriteLine("Cac so nguyen to trong mang:");
            tools.InMang(mangNguyenTo); // tai su dung lai ham InMang, tu xu ly duoc ca truong hop khong co so nguyen to nao
        }

        // Ham rieng de nhap so phan tu mang, tach khoi Main cho gon
        // Kiem tra them dieu kien > 0 vi so phan tu mang khong the la 0 hoac am
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