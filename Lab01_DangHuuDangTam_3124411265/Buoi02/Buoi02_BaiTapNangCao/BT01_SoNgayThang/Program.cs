using NNLTCSharp.Buoi02;
Console.Write("Nhap thang m: ");
int m = int.Parse(Console.ReadLine()!);
Console.Write("Nhap nam y: ");
int y = int.Parse(Console.ReadLine()!);

int soNgay = SoNgayThang.TinhSoNgay(m, y);
Console.WriteLine($"Thang {m} nam {y} co {soNgay} ngay");

