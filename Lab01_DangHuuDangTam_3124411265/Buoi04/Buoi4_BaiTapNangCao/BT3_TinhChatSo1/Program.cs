using NNLTCSharp.Buoi04;

Console.Write("Moi ban nhap so n: ");
int n = int.Parse(Console.ReadLine()!);

int soChuSo = TinhChatSo1.DemSoChuSo(n);
int tongChuSo = TinhChatSo1.TinhTongChuSo(n);
int chuSoCuoi = TinhChatSo1.TimChuSoCuoi(n);
int chuSoDau = TinhChatSo1.TimChuSoDau(n);

Console.WriteLine($"n co {soChuSo} chu so.");
Console.WriteLine($"Tong cac chu so cua n = {tongChuSo}.");
Console.WriteLine($"Chu so cuoi cua n = {chuSoCuoi}.");
Console.WriteLine($"Chu so dau cua n = {chuSoDau}.");

