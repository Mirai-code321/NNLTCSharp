using NNLTCSharp.Buoi8;

Console.Write("Moi ban nhap tu so: ");
int tuSo = int.Parse(Console.ReadLine()!);

Console.Write("Moi ban nhap mau so: ");
int mauSo = int.Parse(Console.ReadLine()!);

string ketQua = RutGonPhanSo.RutGon(tuSo, mauSo);

Console.WriteLine(
    $"Phan so {tuSo}/{mauSo} duoc rut gon thanh {ketQua}."
);