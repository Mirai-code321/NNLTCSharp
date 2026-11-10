using NNLTCSharp.Buoi02;

Console.Write("Nhap so canh n: ");
int n = int.Parse(Console.ReadLine()!);

Console.Write("Nhap ban kinh R: ");
double R = double.Parse(Console.ReadLine()!);

double ketQua = ChuViDaGiacDeu.TinhChuVi(n, R);

Console.WriteLine($"Chu vi da giac deu = {ketQua:F2}");

