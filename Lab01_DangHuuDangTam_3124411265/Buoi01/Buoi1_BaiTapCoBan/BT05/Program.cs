using NNLTCSharp.Buoi01;

Console.Write("Nhap do dai canh a: ");
double a = double.Parse(Console.ReadLine()!);

Console.Write("Nhap do dai canh b: ");
double b = double.Parse(Console.ReadLine()!);

Console.Write("Nhap do dai canh c: ");
double c = double.Parse(Console.ReadLine()!);

double S = TamGiac.TinhDienTich(a, b, c);

Console.WriteLine($"Dien tich tam giac S = {S:F2}");
