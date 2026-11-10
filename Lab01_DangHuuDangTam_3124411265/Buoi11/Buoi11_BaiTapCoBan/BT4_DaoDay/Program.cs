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

// Mang truoc dao
Console.WriteLine("\nMang truoc dao:");
Console.WriteLine($"Day so co {n} phan tu:");

for (int i = 0; i < n; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();

// Dao day
int[] ketQua = DaoDay.Dao(a);

// Mang sau khi dao
Console.WriteLine("\nMang sau khi dao:");
Console.WriteLine($"Day so co {ketQua.Length} phan tu:");

for (int i = 0; i < ketQua.Length; i++)
{
    Console.Write(ketQua[i] + " ");
}

Console.WriteLine();
