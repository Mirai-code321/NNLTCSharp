using System;

namespace Bai16_SapXepHoTen
{
    class Program
    {
        static void Main()
        {
            int n = NhapSoNguyenDuong("Nhap so nguoi: ");
            MangHoTen tools = new MangHoTen(); // phai new doi tuong vi cac ham nghiep vu la instance method

            string[] mang = tools.NhapMang(n);

            Console.WriteLine("\nDanh sach truoc khi sap xep:");
            tools.InMang(mang);

            tools.SapXepTangDan(mang); // sap xep truc tiep tren mang (khong tao mang moi)

            Console.WriteLine("\nDanh sach sau khi sap xep tang dan:");
            tools.InMang(mang);
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