using System;

namespace BTBuoi1.BT2
{
    class bt2
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap ban kinh R: ");
            double R = Convert.ToDouble(Console.ReadLine());

            HinhTron hinhTron = new HinhTron();

            double dienTich = hinhTron.TinhDienTich(R);
            double chuVi = hinhTron.TinhChuVi(R);

            Console.WriteLine("Dien tich hinh tron la: {0}", dienTich);
            Console.WriteLine("Chu vi hinh tron la: {0}", chuVi);
        }
    }
}
