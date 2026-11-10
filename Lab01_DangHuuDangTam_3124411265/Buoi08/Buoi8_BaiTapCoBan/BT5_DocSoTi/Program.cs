using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap so nguyen n: ");
long n = long.Parse(Console.ReadLine()!);

string ketQua = DocSoTi.DocSo(n);

Console.WriteLine($"So {n:N0} doc thanh: [{ketQua}]");