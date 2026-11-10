using System;
using System.Text;
using System.Linq;

namespace InHinhTamGiacVaVuong
{
    public class Program
    {
        // Ham tao chuoi tam giac ho rong, day dac - co the unit test duoc
        public static string TaoHinhTamGiac(int h)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= h; i++)
            {
                if (i < h)
                {
                    int leading = 2 * h - 1 - i;
                    sb.Append(new string(' ', leading));

                    if (i == 1)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        int khoangGiua = 2 * (i - 1);
                        sb.Append('*');
                        sb.Append(new string(' ', khoangGiua));
                        sb.Append('*');
                    }
                }
                else
                {
                    // Dong day: dac, cac dau * cach nhau 1 khoang trang, co 1 khoang trang dau dong
                    sb.Append(' ');
                    string noiDung = string.Join(" ", Enumerable.Repeat("*", 2 * h - 1));
                    sb.Append(noiDung);
                }

                sb.Append('\n');
            }

            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap chieu cao h: ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            int h = int.Parse(dongNhap);

            Console.WriteLine("h={0}", h);
            Console.Write(TaoHinhTamGiac(h));
        }
    }
}