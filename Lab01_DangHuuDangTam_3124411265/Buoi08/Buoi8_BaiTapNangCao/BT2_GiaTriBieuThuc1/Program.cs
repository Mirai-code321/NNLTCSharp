using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap a: ");
double a = double.Parse(Console.ReadLine()!);

Console.Write("Moi ban nhap x: ");
double x = double.Parse(Console.ReadLine()!);

Console.Write("Moi ban nhap n: ");
int n = int.Parse(Console.ReadLine()!);

double ketQua = GiaTriBieuThuc1.TinhG(a, x, n);

Console.WriteLine($"Gia tri bieu thuc g = {ketQua:F2}");