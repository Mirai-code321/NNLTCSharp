using System;

namespace Bai8_HoanVi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 8: HOAN VI HAI SO THUC (THAM CHIEU REF) ===");

            double soThu1 = NhapSoThuc("Nhap so thuc thu nhat: ");
            double soThu2 = NhapSoThuc("Nhap so thuc thu hai: ");

            Console.WriteLine($"\nTruoc khi hoan vi: a = {soThu1}, b = {soThu2}");

            HoanVi doiTuong = new HoanVi();
            doiTuong.ThucHienHoanVi(ref soThu1, ref soThu2);

            Console.WriteLine($"Sau khi hoan vi:  a = {soThu1}, b = {soThu2}");
        }

        // Nhap so thuc, dung TryParse + while(true) de bat loi, khong dung Parse tran tranh crash
        static double NhapSoThuc(string thongBao)
        {
            double ketQua;
            while (true)
            {
                Console.Write(thongBao);
                string? dongNhap = Console.ReadLine();

                if (double.TryParse(dongNhap, out ketQua))
                {
                    return ketQua;
                }

                Console.WriteLine("Loi: vui long nhap dung dinh dang so thuc (vi du 3.14). Nhap lai!");
            }
        }
    }
}