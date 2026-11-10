using NNLTCSharp.Buoi04;

Console.Write("Moi ban nhap so n: ");
int n = int.Parse(Console.ReadLine()!);

if (TinhChatSo.LaSoDoiXung(n))
    Console.WriteLine($"{n} la so doi xung.");
else
    Console.WriteLine($"{n} khong la so doi xung.");

if (TinhChatSo.Co3ChuSoGiongNhau(n))
    Console.WriteLine($"{n} co 3 chu so giong nhau.");
else
    Console.WriteLine($"{n} khong co 3 chu so giong nhau.");

if (TinhChatSo.Co4ChuSoKhacNhau(n))
    Console.WriteLine($"{n} co 4 chu so khac nhau.");
else
    Console.WriteLine($"{n} khong co 4 chu so khac nhau.");

