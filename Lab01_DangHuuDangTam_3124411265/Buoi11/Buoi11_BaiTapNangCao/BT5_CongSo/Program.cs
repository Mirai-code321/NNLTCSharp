using NNLTCSharp.Buoi11;

Console.Write("Nhap so phan tu n cua mang a: ");
int n = int.Parse(Console.ReadLine()!);

int[] a = new int[n];

for (int i = 0; i < n; i++)
{
    Console.Write($"a[{i}] = ");
    a[i] = int.Parse(Console.ReadLine()!);
}

Console.Write("Nhap so phan tu m cua mang b: ");
int m = int.Parse(Console.ReadLine()!);

int[] b = new int[m];

for (int i = 0; i < m; i++)
{
    Console.Write($"b[{i}] = ");
    b[i] = int.Parse(Console.ReadLine()!);
}

Console.WriteLine("\nSo a:");

for (int i = 0; i < a.Length; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();

Console.WriteLine("So b:");

for (int i = 0; i < b.Length; i++)
{
    Console.Write(b[i] + " ");
}

Console.WriteLine();

int[] ketQua = CongSo.Cong(a, b);

Console.WriteLine("\nTong:");

for (int i = 0; i < ketQua.Length; i++)
{
    Console.Write(ketQua[i] + " ");
}

Console.WriteLine();
