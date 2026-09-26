using System;

namespace Bai7_SoNguyenTo
{
    class Program
    {
        // Nhap 1 so nguyen, bat loi va cho nhap lai neu sai (giong bai 4, 6)
        static int NhapSoNguyen(string nhanText)
        {
            while (true)
            {
                Console.Write(nhanText);
                string? chuoiNhap = Console.ReadLine();

                if (int.TryParse(chuoiNhap, out int ketQua))
                {
                    return ketQua;
                }

                Console.Write($"Loi: \"{chuoiNhap}\" ");
                Console.WriteLine("khong hop le. Nhap lai!");
            }
        }

        static void Main(string[] args)
        {
            int n = NhapSoNguyen("Nhap so n: ");

            SoNguyenTo kiemTra = new SoNguyenTo();
            bool ketQua = kiemTra.KiemTraSoNguyenTo(n);

            if (ketQua)
            {
                Console.WriteLine($"{n} la so nguyen to");
            }
            else
            {
                Console.WriteLine($"{n} khong phai la so nguyen to");
            }
        }
    }
}