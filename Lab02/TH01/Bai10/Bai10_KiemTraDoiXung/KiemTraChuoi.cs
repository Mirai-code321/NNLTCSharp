using System;
using System.Text;

namespace Bai10_KiemTraDoiXung
{
    // Lop xu ly nghiep vu kiem tra chuoi doi xung (palindrome), khong dinh Console
    public class KiemTraChuoi
    {
        // Phuong thuc thanh vien (instance method): phai new doi tuong truoc khi goi.
        // Dung StringBuilder de dao nguoc chuoi, dung theo dung chu de "string, StringBuilder"
        // thay vi goi thang ham co san nhu Array.Reverse.
        public bool KiemTraDoiXung(string chuoi)
        {
            StringBuilder chuoiDaoNguoc = new StringBuilder();

            // Duyet tu ky tu cuoi ve dau, append lan luot vao StringBuilder
            for (int i = chuoi.Length - 1; i >= 0; i--)
            {
                chuoiDaoNguoc.Append(chuoi[i]);
            }

            // Chuoi doi xung khi chuoi goc giong het chuoi da dao nguoc (phan biet hoa/thuong)
            return string.Equals(chuoi, chuoiDaoNguoc.ToString());
        }
    }
}