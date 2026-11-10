using NNLTCSharp.Buoi01;

Console.Write("Nhap vao tong so giay: ");

long tongGiay = long.Parse(Console.ReadLine()!);

string ketQua = ThoiGian.DoiThoiGian(tongGiay);

Console.WriteLine($"{tongGiay} giay co dang {ketQua}");
