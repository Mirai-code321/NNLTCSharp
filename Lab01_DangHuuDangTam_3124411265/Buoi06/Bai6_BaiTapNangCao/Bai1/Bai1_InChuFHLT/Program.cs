using System;
using InChuFHLT;

class Program
{
    static void Main(string[] args)
    {
        // Nhập chiều cao h
        Console.Write("Moi ban nhap chieu cao h: ");
        int h = int.Parse(Console.ReadLine()!);

        // Kiểm tra chiều cao phải lớn hơn 0
        if (h <= 0)
        {
            Console.WriteLine("Chieu cao h phai lon hon 0.");
            return;
        }

        // Tạo đối tượng xử lý
        ChuFHLT chu = new ChuFHLT();

        // In chữ F
        Console.WriteLine("\nChu F:");
        Console.WriteLine(chu.InChuF(h));

        // In chữ H
        Console.WriteLine("Chu H:");
        Console.WriteLine(chu.InChuH(h));

        // In chữ L
        Console.WriteLine("Chu L:");
        Console.WriteLine(chu.InChuL(h));

        // In chữ T
        Console.WriteLine("Chu T:");
        Console.WriteLine(chu.InChuT(h));
    }
}