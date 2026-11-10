using System;

namespace Bai16_SapXepHoTen
{
    public class MangHoTen
    {
        // Nhap mang ho ten gom n nguoi
        // Ho ten co the chua khoang trang nen khong dung TryParse so, chi kiem tra chuoi rong/trang
        public string[] NhapMang(int n)
        {
            string[] mang = new string[n];
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    Console.Write($"Nhap ho ten nguoi thu {i + 1}: ");
                    string? dong = Console.ReadLine(); // string? tranh canh bao CS8600
                    if (!string.IsNullOrWhiteSpace(dong))
                    {
                        mang[i] = dong.Trim(); // Trim de bo khoang trang thua dau/cuoi
                        break;
                    }
                    Console.WriteLine("Loi: ho ten khong duoc de trong!");
                }
            }
            return mang;
        }

        // In mang ra man hinh, moi ten 1 dong, co danh so thu tu cho de nhin
        public void InMang(string[] mang)
        {
            if (mang.Length == 0)
            {
                Console.WriteLine("(Mang rong)");
                return;
            }
            for (int i = 0; i < mang.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {mang[i]}");
            }
        }

        // Sap xep tang dan theo thu tu tu dien (a-z) bang thuat toan Selection Sort
        // Tu viet thuat toan thay vi dung Array.Sort de the hien ro cach sap xep,
        // dung string.Compare (khong phan biet hoa/thuong) de so sanh 2 ten
        public void SapXepTangDan(string[] mang)
        {
            for (int i = 0; i < mang.Length - 1; i++)
            {
                int viTriNhoNhat = i;
                for (int j = i + 1; j < mang.Length; j++)
                {
                    if (string.Compare(mang[j], mang[viTriNhoNhat], StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        viTriNhoNhat = j;
                    }
                }
                if (viTriNhoNhat != i)
                {
                    // Hoan doi 2 phan tu bang bien tam
                    string tam = mang[i];
                    mang[i] = mang[viTriNhoNhat];
                    mang[viTriNhoNhat] = tam;
                }
            }
        }
    }
}