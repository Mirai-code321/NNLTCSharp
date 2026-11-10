using System;
using System.Collections.Generic;

namespace InHUFLIT
{
    public class Program
    {
        // Ham tao chu F kich thuoc h x h, tra ve danh sach cac dong (moi dong la 1 chuoi)
        public static List<string> TaoChuF(int h)
        {
            List<string> cacDong = new List<string>();
            int hangGiua = (h + 1) / 2; // hang chua gach ngang giua cua chu F

            for (int i = 1; i <= h; i++)
            {
                string dong = "";
                for (int j = 1; j <= h; j++)
                {
                    // Gach doc ben trai (j==1), gach ngang tren (i==1),
                    // gach ngang giua nhung ngan hon 1 cot (i==hangGiua va j<=h-1)
                    bool laSao = (j == 1 || i == 1 || (i == hangGiua && j <= h - 1));
                    dong += laSao ? '*' : ' ';
                    if (j < h) dong += ' ';
                }
                cacDong.Add(dong);
            }
            return cacDong;
        }

        // Ham tao chu H kich thuoc h x h
        public static List<string> TaoChuH(int h)
        {
            List<string> cacDong = new List<string>();
            int hangGiua = (h + 1) / 2;

            for (int i = 1; i <= h; i++)
            {
                string dong = "";
                for (int j = 1; j <= h; j++)
                {
                    // 2 cot doc trai/phai (j==1 hoac j==h), gach ngang giua (i==hangGiua)
                    bool laSao = (j == 1 || j == h || i == hangGiua);
                    dong += laSao ? '*' : ' ';
                    if (j < h) dong += ' ';
                }
                cacDong.Add(dong);
            }
            return cacDong;
        }

        // Ham tao chu L kich thuoc h x h
        public static List<string> TaoChuL(int h)
        {
            List<string> cacDong = new List<string>();

            for (int i = 1; i <= h; i++)
            {
                string dong = "";
                for (int j = 1; j <= h; j++)
                {
                    // Cot doc trai (j==1), gach ngang duoi cung (i==h)
                    bool laSao = (j == 1 || i == h);
                    dong += laSao ? '*' : ' ';
                    if (j < h) dong += ' ';
                }
                cacDong.Add(dong);
            }
            return cacDong;
        }

        // Ham tao chu T kich thuoc h x h
        public static List<string> TaoChuT(int h)
        {
            List<string> cacDong = new List<string>();
            int cotGiua = (h + 1) / 2;

            for (int i = 1; i <= h; i++)
            {
                string dong = "";
                for (int j = 1; j <= h; j++)
                {
                    // Gach ngang tren (i==1), cot doc giua (j==cotGiua)
                    bool laSao = (i == 1 || j == cotGiua);
                    dong += laSao ? '*' : ' ';
                    if (j < h) dong += ' ';
                }
                cacDong.Add(dong);
            }
            return cacDong;
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap do cao h: ");
            int h = int.Parse(Console.ReadLine()!);

            var f = TaoChuF(h);
            var hh = TaoChuH(h);
            var l = TaoChuL(h);
            var t = TaoChuT(h);

            Console.WriteLine("h = {0}", h);

            // Ghep 4 chu lai, in tung dong tuong ung, cach nhau 1 khoang trang co dinh
            string khoangCach = "        "; // 8 khoang trang giua cac chu
            for (int i = 0; i < h; i++)
            {
                Console.WriteLine(f[i] + khoangCach + hh[i] + khoangCach + l[i] + khoangCach + t[i]);
            }
        }
    }
}