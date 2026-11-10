using System;
using System.Linq;

namespace XuLyChuSo1
{
    public class Program
    {
        // Ham lay chu so tai vi tri k (tinh tu trai sang), vi tri bat dau tu 1
        // Vi du: n=182345, k=2 -> tra ve 8 (vi 1=vi tri1, 8=vi tri2,...)
        public static int ChuSoTaiViTri(int n, int k)
        {
            string chuoiSo = n.ToString();
            int chiSoMang = k - 1; // chuyen tu "vi tri thu k" sang chi so mang (bat dau tu 0)
            char kyTu = chuoiSo[chiSoMang];
            return kyTu - '0'; // chuyen ky tu so thanh gia tri so nguyen
        }

        // Ham tinh tong cac chu so LE cua n
        public static int TongCacChuSoLe(int n)
        {
            string chuoiSo = n.ToString();
            int tong = 0;

            // Duyet qua tung ky tu trong chuoi, kiem tra chu so do co le khong
            foreach (char kyTu in chuoiSo)
            {
                int chuSo = kyTu - '0';
                if (chuSo % 2 != 0) // chu so le
                {
                    tong += chuSo;
                }
            }

            return tong;
        }

        // Ham tim chu so LE nho nhat va lon nhat cua n
        // Tra ve null neu n khong co chu so le nao ca (vi du n = 2468)
        public static (int nhoNhat, int lonNhat)? TimChuSoLeNhoNhatLonNhat(int n)
        {
            string chuoiSo = n.ToString();

            // Loc ra danh sach cac chu so le, dung LINQ cho gon
            var cacChuSoLe = chuoiSo
                .Select(kyTu => kyTu - '0')   // chuyen tung ky tu thanh so nguyen
                .Where(chuSo => chuSo % 2 != 0) // chi giu lai chu so le
                .ToList();

            // Neu khong co chu so le nao thi khong the tim min/max -> tra ve null
            if (cacChuSoLe.Count == 0)
            {
                return null;
            }

            return (cacChuSoLe.Min(), cacChuSoLe.Max());
        }

        static void Main(string[] args)
        {
            Console.Write("Moi ban nhap so nguyen n: ");
            int n = int.Parse(Console.ReadLine()!);

            Console.Write("Moi ban nhap vi tri k: ");
            int k = int.Parse(Console.ReadLine()!);

            // (a) Chu so tai vi tri k
            int chuSoTaiK = ChuSoTaiViTri(n, k);
            Console.WriteLine("Chu so o vi tri {0} (tinh tu trai) cua {1} la {2}.", k, n, chuSoTaiK);

            // (b) Tong cac chu so le
            int tongChuSoLe = TongCacChuSoLe(n);
            Console.WriteLine("Tong cac chu so le cua {0} la {1}.", n, tongChuSoLe);

            // (c) Chu so le nho nhat va lon nhat
            var ketQuaMinMax = TimChuSoLeNhoNhatLonNhat(n);
            if (ketQuaMinMax == null)
            {
                Console.WriteLine("{0} khong co chu so le nao.", n);
            }
            else
            {
                var (nhoNhat, lonNhat) = ketQuaMinMax.Value;
                Console.WriteLine("{0} co chu so le nho nhat la {1} va lon nhat la {2}.", n, nhoNhat, lonNhat);
            }
        }
    }
}