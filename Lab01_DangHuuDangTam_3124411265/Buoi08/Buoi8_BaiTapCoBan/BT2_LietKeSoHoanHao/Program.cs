using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap so n: ");
int n = int.Parse(Console.ReadLine()!);

List<int> ketQua = LietKeSoHoanHao.LietKe(n);

Console.Write($"Cac so hoan hao trong doan [1, {n}]: ");

foreach (int so in ketQua)
{
    Console.Write($"{so} ");
}