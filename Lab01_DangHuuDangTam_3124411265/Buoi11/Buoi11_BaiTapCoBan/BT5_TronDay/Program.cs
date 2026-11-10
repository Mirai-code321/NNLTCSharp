using NNLTCSharp.Buoi11;

Console.Write("Nhap so phan tu n cua day A: ");
int n = int.Parse(Console.ReadLine()!);

int[] a = new int[n];

Console.WriteLine("Nhap day A tang dan:");

for (int i = 0; i < n; i++)
{
    Console.Write($"A[{i}] = ");
    a[i] = int.Parse(Console.ReadLine()!);
}


Console.Write("\nNhap so phan tu m cua day B: ");
int m = int.Parse(Console.ReadLine()!);

int[] b = new int[m];

Console.WriteLine("Nhap day B tang dan:");

for (int i = 0; i < m; i++)
{
    Console.Write($"B[{i}] = ");
    b[i] = int.Parse(Console.ReadLine()!);
}


// In day A
Console.WriteLine("\nDay A:");
Console.WriteLine($"Day so co {n} phan tu:");

for (int i = 0; i < n; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();


// In day B
Console.WriteLine("\nDay B:");
Console.WriteLine($"Day so co {m} phan tu:");

for (int i = 0; i < m; i++)
{
    Console.Write(b[i] + " ");
}

Console.WriteLine();


// Tron 2 day
int[] c = TronDay.Tron(a, b);


// In day C
Console.WriteLine("\nDay C:");
Console.WriteLine($"Day so co {c.Length} phan tu:");

for (int i = 0; i < c.Length; i++)
{
    Console.Write(c[i] + " ");
}

Console.WriteLine();
