using System;

class Program
{
    static void Main()
    {
        // In lời nhắc, dùng Write (không phải WriteLine) để không xuống dòng
        Console.Write("Nhap ho ten cua ban: ");

        // Doc chuoi nguoi dung nhap vao tu ban phim
        // ?? "" de tranh loi neu ReadLine tra ve null
        string hoTen = Console.ReadLine() ?? "";

        // Ghep chuoi loi chao bang string interpolation ($"...")
        // gia tri cua bien hoTen se duoc chen vao vi tri {hoTen}
        Console.WriteLine($"Chao ban {hoTen}!");
    }
}