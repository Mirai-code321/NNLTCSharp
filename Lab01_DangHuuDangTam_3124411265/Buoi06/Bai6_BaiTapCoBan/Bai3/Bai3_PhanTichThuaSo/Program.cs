using System;
using PhanTichThuaSo1;

class Program
{
    static void Main(string[] args)
    {
        // Nhập số nguyên n
        Console.Write("Moi ban nhap so nguyen n: ");
        int n = int.Parse(Console.ReadLine()!);

        // Tạo đối tượng phân tích thừa số
        PhanTichThuaSo phanTich = new PhanTichThuaSo();

        // Thực hiện phân tích n
        string ketQua = phanTich.PhanTich(n);

        // In kết quả theo đúng dạng đề bài
        Console.WriteLine($"{n} = {ketQua}");
    }
}