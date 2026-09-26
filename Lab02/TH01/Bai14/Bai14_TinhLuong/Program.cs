using System.Text;

namespace Bai14_TinhLuong
{
    internal class Program
    {
        // Nhap 1 chuoi khong rong, sai thi bao loi va cho nhap lai
        static string NhapChuoi(string nhan)
        {
            while (true)
            {
                Console.Write(nhan);
                string? nhap = Console.ReadLine();   // string? vi ReadLine co the tra ve null

                if (!string.IsNullOrWhiteSpace(nhap))
                    return nhap.Trim();

                Console.WriteLine("Khong duoc de trong, moi nhap lai!");
            }
        }

        // Nhap muc luong: so nguyen khong am, viet lien (khong co dau cham/phay ngan cach)
        static long NhapMucLuong()
        {
            while (true)
            {
                Console.Write("Nhap muc luong (VND): ");
                string? nhap = Console.ReadLine();

                if (long.TryParse(nhap, out long mucLuong) && mucLuong >= 0)
                    return mucLuong;

                Console.WriteLine("Muc luong phai la so nguyen khong am (vi du 10000000), moi nhap lai!");
            }
        }

        // Nhap so ngay vang: so nguyen tu 0 den 31
        static int NhapSoNgayVang()
        {
            while (true)
            {
                Console.Write("Nhap so ngay vang: ");
                string? nhap = Console.ReadLine();

                if (int.TryParse(nhap, out int soNgay)
                    && soNgay >= 0
                    && soNgay <= NhanVien.SoNgayVangToiDa)
                {
                    return soNgay;
                }

                Console.WriteLine("So ngay vang phai la so nguyen tu 0 den 31, moi nhap lai!");
            }
        }

        static void Main(string[] args)
        {
            // dat UTF-8 de nhap/xuat duoc chuoi co dau tieng Viet, khong bi loi font
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string hoTen = NhapChuoi("Nhap ho ten: ");
            long mucLuong = NhapMucLuong();
            int soNgayVang = NhapSoNgayVang();

            NhanVien nhanVien = new NhanVien(hoTen, mucLuong, soNgayVang);

            Console.WriteLine();
            Console.WriteLine("Thong tin luong:");
            Console.WriteLine(nhanVien.LayThongTin());
        }
    }
}