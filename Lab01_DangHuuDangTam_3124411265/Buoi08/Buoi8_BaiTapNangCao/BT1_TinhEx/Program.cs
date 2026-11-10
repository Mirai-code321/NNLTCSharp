using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap x: ");
double x = double.Parse(Console.ReadLine()!);

Console.Write("Moi ban nhap epsilon: ");
double epsilon = double.Parse(Console.ReadLine()!);

double ketQua = TinhEx.Tinh(x, epsilon);

Console.WriteLine($"e^{x} = {ketQua}");