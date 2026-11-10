using NNLTCSharp.Buoi11;

Console.Write("Nhap so phan tu n: ");
int n = int.Parse(Console.ReadLine()!);

int[] a = new int[n];

for (int i = 0; i < n; i++)
{
    Console.Write($"a[{i}] = ");
    a[i] = int.Parse(Console.ReadLine()!);
}

Console.Write("Nhap k: ");
int k = int.Parse(Console.ReadLine()!);

Console.WriteLine("\nMang truoc khi di chuyen:");

for (int i = 0; i < n; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();

int[] ketQua = DiChuyen.DiChuyenKPhanTu(a, k);

Console.WriteLine("\nMang sau khi di chuyen:");

for (int i = 0; i < ketQua.Length; i++)
{
    Console.Write(ketQua[i] + " ");
}

Console.WriteLine();
