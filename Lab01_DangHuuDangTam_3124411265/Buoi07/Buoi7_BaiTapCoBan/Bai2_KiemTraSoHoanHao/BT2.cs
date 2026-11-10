using System;
using System.Collections.Generic;
using System.Linq;

namespace KiemTraSoHoanHao
{
    public class Program
    {
        // Ham tim tat ca uoc so cua n, KHONG tinh chinh n
        // Vi du: n=6 -> tra ve [1, 2, 3]
        public static List<int> TimCacUocSo(int n)
        {
            List<int> danhSachUoc = new List<int>();

            // Duyet tu 1 den n-1, kiem tra i co chia het n khong
            // Chi can duyet den n/2 la du (vi uoc lon nhat cua n, tru chinh no, khong vuot qua n/2)
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    danhSachUoc.Add(i);
                }
            }

            return danhSachUoc;
        }

        // Ham kiem tra n co phai so hoan hao khong
        // So hoan hao: tong cac uoc (khong ke chinh no) bang chinh no
        // Tra ve: (co phai hoan hao khong, danh sach uoc, tong cac uoc)
        public static (bool laHoanHao, List<int> uocSo, int tongUoc) KiemTraSoHoanHao(int n)
        {
            List<int> uocSo = TimCacUocSo(n);

            // Tinh tong tat ca uoc so vua tim duoc
            int tongUoc = uocSo.Sum();

            // So la hoan hao neu tong uoc bang chinh no
            bool laHoanHao = (tongUoc == n);

            return (laHoanHao, uocSo, tongUoc);
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap n: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            int n = int.Parse(dongNhap);

            var (laHoanHao, uocSo, tongUoc) = KiemTraSoHoanHao(n);

            if (laHoanHao)
            {
                // Tao chuoi dang "1 + 2 + 3" tu danh sach uoc so
                string chuoiPhepCong = string.Join(" + ", uocSo);
                Console.WriteLine("{0} = {1} la so hoan hao.", n, chuoiPhepCong);
            }
            else
            {
                Console.WriteLine("{0} khong la so hoan hao.", n);
            }
        }
    }
}