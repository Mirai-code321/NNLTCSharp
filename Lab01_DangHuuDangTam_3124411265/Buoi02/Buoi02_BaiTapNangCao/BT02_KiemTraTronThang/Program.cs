using NNLTCSharp.Buoi02;

Console.Write("Nhap tam O(x, y): ");
string[] toaDo = Console.ReadLine()!.Split(' ');

double x = double.Parse(toaDo[0]);
double y = double.Parse(toaDo[1]);

Console.Write("Nhap ban kinh r: ");
double r = double.Parse(Console.ReadLine()!);

Console.Write("Nhap A, B, C cua duong thang: ");
string[] heSo = Console.ReadLine()!.Split(' ');

double A = double.Parse(heSo[0]);
double B = double.Parse(heSo[1]);
double C = double.Parse(heSo[2]);

string ketQua = KiemTraTronThang.KiemTra(x, y, r, A, B, C);

Console.WriteLine($"Ket qua: {ketQua}");

