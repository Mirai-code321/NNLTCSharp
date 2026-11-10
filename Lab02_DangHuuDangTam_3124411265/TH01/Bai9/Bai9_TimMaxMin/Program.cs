using System;

namespace Bai9_TimMaxMin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== BAI 9: TIM GTLN & GTNN CUA BA SO THUC (THAM CHIEU OUT) ===");

            double soA = NhapSoThuc("Nhap so thuc a: ");
            double soB = NhapSoThuc("Nhap so thuc b: ");
            double soC = NhapSoThuc("Nhap so thuc c: ");

            TimMaxMin doiTuong = new TimMaxMin();

            // Khong can khoi tao gtLon, gtNho truoc khi truyen vao tham so out
            doiTuong.TimGiaTriLonNhoNhat(soA, soB, soC, out double gtLon, out double gtNho);

            Console.WriteLine($"Gia tri lon nhat cua {soA}, {soB}, {soC} la: {gtLon}");
            Console.WriteLine($"Gia tri nho nhat cua {soA}, {soB}, {soC} la: {gtNho}");
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