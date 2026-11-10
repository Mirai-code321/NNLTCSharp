using NNLTCSharp.Buoi04;

Console.WriteLine("Nhap a, b, c, d:");

string[] input = Console.ReadLine()!.Split(' ');

double a = double.Parse(input[0]);
double b = double.Parse(input[1]);
double c = double.Parse(input[2]);
double d = double.Parse(input[3]);

string ketQua = PhuongTrinhBac3.Giai(a, b, c, d);

Console.WriteLine(ketQua);

