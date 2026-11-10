using System;

namespace Bai10_KiemTraDoiXung
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 10: KIEM TRA CHUOI DOI XUNG (PALINDROME) ===");

            string chuoiNhap = NhapChuoi("Nhap chuoi can kiem tra: ");

            KiemTraChuoi doiTuong = new KiemTraChuoi();
            bool laDoiXung = doiTuong.KiemTraDoiXung(chuoiNhap);

            if (laDoiXung)
            {
                Console.WriteLine($"Chuoi \"{chuoiNhap}\" LA chuoi doi xung.");
            }
            else
            {
                Console.WriteLine($"Chuoi \"{chuoiNhap}\" KHONG PHAI chuoi doi xung.");
            }
        }

        // Nhap chuoi, dung while(true) de bat loi neu nguoi dung nhap rong hoac chi toan khoang trang
        static string NhapChuoi(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string? dongNhap = Console.ReadLine();

                if (!string.IsNullOrEmpty(dongNhap))
                {
                    return dongNhap;
                }

                Console.WriteLine("Loi: chuoi khong duoc de rong. Nhap lai!");
            }
        }
    }
}