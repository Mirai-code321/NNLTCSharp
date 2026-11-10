using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap so nguyen n: ");
int n = int.Parse(Console.ReadLine()!);

long ketQua = SapLaiChuSo.SapXep(n);

Console.WriteLine($"So sau khi sap lai: {ketQua}");