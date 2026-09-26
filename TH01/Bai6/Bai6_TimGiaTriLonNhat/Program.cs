using System;

namespace Bai6_TimGiaTriLonNhat
{
    class Program
    {
        // Nhap 1 so nguyen, bat loi va cho nhap lai neu sai (giong bai 4)
        static int NhapSoNguyen(string nhanText)
        {
            while (true)
            {
                Console.Write(nhanText);
                string chuoiNhap = Console.ReadLine();

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
            int a = NhapSoNguyen("Nhap so a: ");
            int b = NhapSoNguyen("Nhap so b: ");
            int c = NhapSoNguyen("Nhap so c: ");

            // Tao doi tuong tu lop BaSoNguyen roi goi phuong thuc cua no
            BaSoNguyen baSo = new BaSoNguyen();
            int max = baSo.TimGiaTriLonNhat(a, b, c);

            Console.WriteLine($"Gia tri lon nhat cua {a}, {b}, {c} la: {max}");
        }
    }
}