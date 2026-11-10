using NNLTCSharp.Buoi11;

Console.Write("Nhap so phan tu n: ");
int n = int.Parse(Console.ReadLine()!);

double[] a = new double[n];

int soPhanTu = 0;

// Nhap tung phan tu
for (int i = 0; i < n; i++)
{
    Console.Write($"Nhap a[{i}]: ");
    double x = double.Parse(Console.ReadLine()!);

    // Chen x vao dung vi tri
    NhapTang.Nhap(a, soPhanTu, x);

    soPhanTu++;

    // In mang sau moi lan nhap
    Console.Write("Day hien tai: ");

    for (int j = 0; j < soPhanTu; j++)
    {
        Console.Write(a[j] + " ");
    }

    Console.WriteLine();
}

// In ket qua
Console.WriteLine("\nMang sau khi nhap:");
Console.WriteLine($"Day so co {n} phan tu:");

for (int i = 0; i < n; i++)
{
    Console.Write(a[i] + " ");
}

Console.WriteLine();
