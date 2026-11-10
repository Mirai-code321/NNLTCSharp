using NNLTCSharp.Buoi11;

Console.Write("Nhap so phan tu n: ");
int n = int.Parse(Console.ReadLine()!);

int[] a = new int[n];

// Nhap day so
for (int i = 0; i < n; i++)
{
    Console.Write($"a[{i}] = ");
    a[i] = int.Parse(Console.ReadLine()!);
}

// Mang truoc them
Console.WriteLine("\nMang truoc them:");
Console.WriteLine($"Day so co {n} phan tu:");

for (int i = 0; i < n; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();

// Them so le
int[] ketQua = ThemChanLe.Them(a);

// Mang sau khi them
Console.WriteLine("\nMang sau khi them:");
Console.WriteLine($"Day so co {ketQua.Length} phan tu:");

for (int i = 0; i < ketQua.Length; i++)
{
    Console.Write(ketQua[i] + " ");
}

Console.WriteLine();
