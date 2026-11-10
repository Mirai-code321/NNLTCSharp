using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap k: ");
int k = int.Parse(Console.ReadLine()!);

Console.Write("Moi ban nhap n: ");
int n = int.Parse(Console.ReadLine()!);

long ketQua = GiaiThua.TinhToHop(n, k);

Console.WriteLine($"C({k}, {n}) = {ketQua}");