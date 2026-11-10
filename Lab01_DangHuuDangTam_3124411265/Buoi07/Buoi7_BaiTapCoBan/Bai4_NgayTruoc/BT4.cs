using System;

namespace NgayTruoc
{
    public class Program
    {
        // Ham kiem tra nam nhuan
        // Nam nhuan: chia het cho 4, nhung neu chia het cho 100 thi phai chia het cho 400 moi tinh la nhuan
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

        // Ham tra ve so ngay cua 1 thang trong 1 nam cu the (co xet nam nhuan cho thang 2)
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
        // Tra ve ngay, thang, nam CUA NGAY LIEN TRUOC ngay/thang/nam duoc nhap vao
        public static (int ngay, int thang, int nam) NgayTruocDo(int ngay, int thang, int nam)
        {
            // Truong hop 1: ngay khong phai la ngay dau thang -> chi can lui 1 ngay, giu nguyen thang/nam
            if (ngay > 1)
            {
                return (ngay - 1, thang, nam);
            }

            // Truong hop 2: ngay la ngay 1, nhung khong phai thang 1 -> lui ve thang truoc, cung nam
            // Ngay cua ngay truoc chinh la ngay CUOI CUNG cua thang truoc do
            if (thang > 1)
            {
                int thangTruoc = thang - 1;
                int ngayCuoiThangTruoc = SoNgayCuaThang(thangTruoc, nam);
                return (ngayCuoiThangTruoc, thangTruoc, nam);
            }

            // Truong hop 3: ngay la 1/1 (dau nam) -> lui ve 31/12 cua nam truoc do
            return (31, 12, nam - 1);
        }

        static void Main(string[] args)
        {
            // Nhap ngay, thang, nam theo TUNG DONG rieng biet nhu de bai yeu cau
            Console.Write("Moi ban nhap ngay: ");
            int ngay = int.Parse(Console.ReadLine()!);

            Console.Write("Moi ban nhap thang: ");
            int thang = int.Parse(Console.ReadLine()!);

            Console.Write("Moi ban nhap nam: ");
            int nam = int.Parse(Console.ReadLine()!);

            var (ngayTruoc, thangTruoc, namTruoc) = NgayTruocDo(ngay, thang, nam);

            Console.WriteLine("Ngay truoc ngay {0}/{1}/{2} la ngay {3}/{4}/{5}.",
                ngay, thang, nam, ngayTruoc, thangTruoc, namTruoc);
        }
    }
}