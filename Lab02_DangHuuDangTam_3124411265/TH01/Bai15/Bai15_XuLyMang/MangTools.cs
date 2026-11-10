using System;
using System.Collections.Generic;

namespace Bai15_XuLyMang
{
    public class MangTools
    {
        // Nhap mang gom n phan tu
        // Dung while(true) + TryParse thay vi Parse de khong bi crash khi nguoi dung go sai dinh dang
        public int[] NhapMang(int n)
        {
            int[] mang = new int[n];
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"Nhap phan tu thu {i + 1}: ");
                    string? dong = Console.ReadLine(); // string? de tranh canh bao CS8600 (ReadLine co the tra ve null)
                    if (int.TryParse(dong, out int giaTri))
                    {
                        mang[i] = giaTri;
                        break;
                    }
                    Console.WriteLine("Loi: vui long nhap so nguyen hop le!");
                }
            }
            return mang;
        }

        // In mang ra man hinh
        // Xu ly rieng truong hop mang rong de tranh in ra dong trong khong ro nghia
        public void InMang(int[] mang)
        {
            if (mang.Length == 0)
            {
                Console.WriteLine("(Mang rong)");
                return;
            }
            Console.WriteLine(string.Join(" ", mang)); // string.Join gon hon vong lap thu cong, tu dong cach nhau bang dau space
        }

        // Tim dong thoi max va min
        // Dung out vi ham can tra ve 2 gia tri cung luc, khong the dung return don (giong cach truyen tham chieu o bai truoc)
        public void TimMaxMin(int[] mang, out int max, out int min)
        {
            if (mang.Length == 0)
                throw new ArgumentException("Mang rong, khong the tim phan tu lon nhat/nho nhat");
            // Neu khong chan mang rong o day, cac lenh gan max = mang[0] ben duoi se nem loi IndexOutOfRange
            // kho hieu hon, nen chu dong bao loi ro rang truoc

            max = mang[0];
            min = mang[0];
            // Bat buoc phai gan gia tri ban dau cho max/min truoc khi duyet vi la tham so out
            // (C# yeu cau moi bien out phai duoc gan gia tri truoc khi ham ket thuc)
            for (int i = 1; i < mang.Length; i++)
            {
                if (mang[i] > max) max = mang[i];
                if (mang[i] < min) min = mang[i];
            }
        }

        // Kiem tra so nguyen to
        // Chi can xet uoc so tu 2 den can bac hai cua x, vi neu x = a*b thi it nhat 1 trong 2 uoc so
        // phai <= can(x), xet het den can(x) la du, giup thuat toan nhanh hon nhieu so voi xet den x-1
        public bool KiemTraSoNguyenTo(int x)
        {
            if (x < 2) return false; // quy uoc: so nguyen to phai lon hon hoac bang 2 (0, 1, so am khong tinh)
            for (int i = 2; i * i <= x; i++) // dieu kien i*i <= x tuong duong i <= can(x), tranh phai goi Math.Sqrt
            {
                if (x % i == 0) return false;
            }
            return true;
        }

        // Duyet mang goc, gom cac phan tu la so nguyen to vao mang moi
        // Dung List<int> vi khong biet truoc so luong so nguyen to se co bao nhieu phan tu,
        // sau khi gom xong moi ToArray() de tra ve dung kieu du lieu int[] theo yeu cau de bai
        public int[] LayMangSoNguyenTo(int[] mang)
        {
            List<int> ketQua = new List<int>();
            foreach (int x in mang)
            {
                if (KiemTraSoNguyenTo(x)) ketQua.Add(x);
            }
            return ketQua.ToArray();
        }
    }
}