using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap x: ");
double x = double.Parse(Console.ReadLine()!);

string ketQua = ChuyenNhiPhan.Chuyen(x);

Console.WriteLine($"So {x} trong he nhi phan la: {ketQua}");