using NNLTCSharp.Buoi04;

Console.WriteLine("Nhap a, b, c, d, e, f:");

string[] input = Console.ReadLine()!.Split(' ');

double a = double.Parse(input[0]);
double b = double.Parse(input[1]);
double c = double.Parse(input[2]);
double d = double.Parse(input[3]);
double e = double.Parse(input[4]);
double f = double.Parse(input[5]);

string ketQua = HePhuongTrinh.GiaiHe(a, b, c, d, e, f);

Console.WriteLine(ketQua);

