using NNLTCSharp.Buoi04;

Console.Write("Moi ban nhap a: ");
double a = double.Parse(Console.ReadLine()!);

double ketQua = GiaTriHamSoDoThi.TinhGiaTri(a);

Console.WriteLine($"f({a}) = {ketQua}");

