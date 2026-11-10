using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap vi tri k: ");
long k = long.Parse(Console.ReadLine()!);

int ketQua = ViTriChuSo.TimChuSo(k);

Console.WriteLine($"Chu so tai vi tri {k} la: {ketQua}");