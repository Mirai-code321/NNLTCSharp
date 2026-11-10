using System;
using XuLyChuSo1;

class Program
{
    static void Main(string[] args)
    {
        // Tạo đối tượng xử lý chữ số
        XuLyChuSo xuLy = new XuLyChuSo();

        // Nhập số nguyên n
        Console.Write("Moi ban nhap so nguyen n: ");
        int n = int.Parse(Console.ReadLine()!);

        // Nhập vị trí k
        Console.Write("Moi ban nhap vi tri k: ");
        int k = int.Parse(Console.ReadLine()!);

        // Tìm chữ số thứ k tính từ trái sang
        int chuSoK = xuLy.LayChuSoThuK(n, k);

        // Tính tổng các chữ số lẻ
        int tongChuSoLe = xuLy.TongChuSoLe(n);

        // Tìm chữ số lẻ nhỏ nhất và lớn nhất
        int nhoNhat;
        int lonNhat;

        xuLy.TimChuSoLeNhoNhatLonNhat(
            n,
            out nhoNhat,
            out lonNhat
        );

        // In kết quả
        Console.WriteLine(
            $"Chu so o vi tri {k} (tinh tu trai) cua {n} la {chuSoK}."
        );

        Console.WriteLine(
            $"Tong cac chu so le cua {n} la {tongChuSoLe}."
        );

        Console.WriteLine(
            $"{n} co chu so le nho nhat la {nhoNhat} va lon nhat la {lonNhat}."
        );
    }
}