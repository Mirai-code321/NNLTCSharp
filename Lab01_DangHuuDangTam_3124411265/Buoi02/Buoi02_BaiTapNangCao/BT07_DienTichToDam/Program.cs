using NNLTCSharp.Buoi02;

Console.Write("Nhap a: ");
double a = double.Parse(Console.ReadLine()!);

double ketQua = DienTichToDam.TinhDienTich(a);

Console.WriteLine($"Dien tich to dam = {ketQua:F2}");

