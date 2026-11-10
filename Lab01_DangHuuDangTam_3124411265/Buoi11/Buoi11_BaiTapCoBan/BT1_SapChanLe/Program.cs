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

// Mang truoc khi sap xep
Console.WriteLine("\nMang truoc khi sap xep:");
Console.WriteLine($"Day so co {n} phan tu:");

for (int i = 0; i < n; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();

// Sap xep
int[] ketQua = SapChanLe.SapXep(a);

// Mang sau khi sap xep
Console.WriteLine("\nMang sau khi sap xep:");
Console.WriteLine($"Day so co {n} phan tu:");

for (int i = 0; i < n; i++)
{
    Console.Write(ketQua[i] + " ");
}

Console.WriteLine();
