using System.Text;

namespace Bai13_SinhVien
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

        // Nhap nam thu: phai la so nguyen nam trong khoang cho phep cua lop SinhVien
        static int NhapNamThu()
        {
            while (true)
            {
                Console.Write("Nhap sinh vien nam thu may: ");
                string? nhap = Console.ReadLine();

                if (int.TryParse(nhap, out int namThu)
                    && namThu >= SinhVien.NamThuToiThieu
                    && namThu <= SinhVien.NamThuToiDa)
                {
                    return namThu;
                }

                Console.WriteLine("Nam thu phai la so nguyen tu 1 den 6, moi nhap lai!");
            }
        }

        static void Main(string[] args)
        {
            // dat UTF-8 de nhap/xuat duoc chuoi co dau tieng Viet, khong bi loi font
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string maSinhVien = NhapChuoi("Nhap ma sinh vien: ");
            string hoTen = NhapChuoi("Nhap ho ten: ");
            string diaChi = NhapChuoi("Nhap dia chi: ");
            int namThu = NhapNamThu();

            SinhVien sinhVien = new SinhVien(maSinhVien, hoTen, diaChi, namThu);

            Console.WriteLine();
            Console.WriteLine("Thong tin sinh vien:");
            Console.WriteLine(sinhVien.LayThongTin());
        }
    }
}