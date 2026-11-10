using System;

namespace SoNgayThangReNhanh
{
    public class Program
    {
        // Ham kiem tra nam nhuan
        public static bool LaNamNhuan(int nam)
        {
            if (nam % 4 != 0)
            {
                return false;
            }
            else if (nam % 100 != 0)
            {
                return true;
            }
            else if (nam % 400 != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Ham tinh toan thuan tuy - co the unit test duoc
        // Tra ve 0 neu thang khong hop le (ngoai khoang 1-12)
        public static int SoNgayCuaThang(int thang, int nam)
        {
            if (thang < 1 || thang > 12)
            {
                return 0;
            }

            if (thang == 1 || thang == 3 || thang == 5 || thang == 7 ||
                thang == 8 || thang == 10 || thang == 12)
            {
                return 31;
            }
            else if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
            {
                return 30;
            }
            else // thang == 2
            {
                if (LaNamNhuan(nam))
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap vao thang, nam: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            string[] input = dongNhap.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int thang = int.Parse(input[0]);
            int nam = int.Parse(input[1]);

            int soNgay = SoNgayCuaThang(thang, nam);

            if (soNgay == 0)
            {
                Console.WriteLine("Thang khong hop le! Vui long nhap tu 1 den 12.");
            }
            else
            {
                Console.WriteLine("Thang {0} trong nam {1} co {2} ngay.", thang, nam, soNgay);
            }
        }
    }
}

