using System;

namespace ThangTiengAnh
{
    public class Program
    {
        private static readonly string[] TenThang = new string[]
        {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        // Ham tinh toan thuan tuy - co the unit test duoc
        // Tra ve null neu thang khong hop le (ngoai khoang 1-12)
        public static string? DocThang(int thang)
        {
            if (thang < 1 || thang > 12)
            {
                return null;
            }

            return TenThang[thang - 1];
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap vao thang: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            int thang = int.Parse(dongNhap);

            string? tenThang = DocThang(thang);

            if (tenThang == null)
            {
                Console.WriteLine("Thang khong hop le! Vui long nhap tu 1 den 12.");
            }
            else
            {
                Console.WriteLine("Tieng anh cua thang {0} la {1}.", thang, tenThang);
            }
        }
    }
}


