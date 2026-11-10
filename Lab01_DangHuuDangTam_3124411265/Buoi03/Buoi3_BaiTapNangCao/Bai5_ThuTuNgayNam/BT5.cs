using System;

namespace ThuTuNgayNam
{
    public class Program
    {
        public static bool LaNamNhuan(int nam)
        {
            if (nam % 4 != 0)
                return false;
            else if (nam % 100 != 0)
                return true;
            else if (nam % 400 != 0)
                return false;
            else
                return true;
        }

        public static int SoNgayCuaThang(int thang, int nam)
        {
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
                return LaNamNhuan(nam) ? 29 : 28;
            }
        }

        // Ham tinh toan thuan tuy - co the unit test duoc
        // Tra ve so ngay cach ngay dau nam (1/1 cung nam)
        public static int SoNgayCachDauNam(int ngay, int thang, int nam)
        {
            int tongSoNgay = 0;

            for (int i = 1; i < thang; i++)
            {
                tongSoNgay += SoNgayCuaThang(i, nam);
            }

            tongSoNgay += ngay;

            return tongSoNgay - 1;
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap ngay, thang, nam: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            string[] input = dongNhap.Split(new char[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);
            int ngay = int.Parse(input[0]);
            int thang = int.Parse(input[1]);
            int nam = int.Parse(input[2]);

            int soNgayCach = SoNgayCachDauNam(ngay, thang, nam);

            Console.WriteLine("Ngay {0}/{1}/{2} cach ngay dau nam (1/1/{2}) la {3} ngay.", ngay, thang, nam, soNgayCach);
        }
    }
}

