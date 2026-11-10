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

// Mang truoc khi xoa
Console.WriteLine("\nMang truoc xoa:");
Console.WriteLine($"Day so co {n} phan tu:");

for (int i = 0; i < n; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();

// Xoa trung
int[] ketQua = XoaTrung.Xoa(a);

// Mang sau khi xoa
Console.WriteLine("\nMang sau khi xoa:");
Console.WriteLine($"Day so co {ketQua.Length} phan tu:");

for (int i = 0; i < ketQua.Length; i++)
{
    Console.Write(ketQua[i] + " ");
}

Console.WriteLine();
