using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap ho ten: ");
        string hoTen = Console.ReadLine() ?? "";
        Console.WriteLine("Ho ten ban vua nhap la: " + hoTen);
    }
}