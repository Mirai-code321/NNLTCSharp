using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap so nguyen n: ");
int n = int.Parse(Console.ReadLine()!);

for (int i = 0; i <= 9; i++)
{
    int soLan = DemChuSo.DemSoLanXuatHien(n, i);

    if (soLan > 0)
    {
        Console.WriteLine(
            $"Chu so {i} xuat hien {soLan} lan."
        );
    }
}