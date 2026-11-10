using NNLTCSharp.Buoi02;

Console.Write("Nhap k: ");
int k = int.Parse(Console.ReadLine()!);

string ketQua = ChuSoGiaiThua.TinhChuSoCuoi(k);

Console.WriteLine($"{k} chu so cuoi cua 100! la: {ketQua}");

