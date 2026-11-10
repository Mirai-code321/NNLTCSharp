using System;
using System.Text;

namespace DocKySo
{
    public class Program
    {
        private static readonly string[] TenKySo = new string[]
        {
            "khong", "mot", "hai", "ba", "bon", "nam", "sau", "bay", "tam", "chin"
        };

        // Ham tinh toan thuan tuy - co the unit test duoc
        // Doc tung ky so cua n theo thu tu tu trai sang phai
        public static string DocKySo(int n)
        {
            string chuoiSo = n.ToString();
            StringBuilder ketQua = new StringBuilder();

            for (int i = 0; i < chuoiSo.Length; i++)
            {
                int chuSo = chuoiSo[i] - '0';
                ketQua.Append(TenKySo[chuSo]);

                if (i < chuoiSo.Length - 1)
                {
                    ketQua.Append(' ');
                }
            }

            return ketQua.ToString();
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap n (4 chu so): ");
            string? dongNhap = Console.ReadLine();

            if (string.IsNullOrEmpty(dongNhap))
            {
                Console.WriteLine("Ban chua nhap gi ca!");
                return;
            }

            int n = int.Parse(dongNhap);

            if (n < 1000 || n > 9999)
            {
                Console.WriteLine("Vui long nhap so nguyen duong co 4 chu so (1000-9999)!");
                return;
            }

            string ketQua = DocKySo(n);

            Console.WriteLine("n = {0} thi in ra man hinh la \"{1}\".", n, ketQua);
        }
    }
}

