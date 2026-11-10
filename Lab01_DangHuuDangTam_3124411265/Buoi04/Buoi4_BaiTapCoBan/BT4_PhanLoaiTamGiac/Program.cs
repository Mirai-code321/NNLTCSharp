using NNLTCSharp.Buoi3;

Console.Write("Moi ban nhap ba so thuc a, b, c: ");

string[] input = Console.ReadLine()!.Split(' ');

double a = double.Parse(input[0]);
double b = double.Parse(input[1]);
double c = double.Parse(input[2]);

string ketQua = LoaiTamGiac.KiemTraTamGiac(a, b, c);

if (ketQua == "Khong phai tam giac")
{
    Console.WriteLine($"Ba so ({a}, {b}, {c}) khong tao thanh duoc tam giac.");
}
else
{
    Console.WriteLine($"Ba so ({a}, {b}, {c}) tao thanh duoc tam giac.");
    Console.WriteLine($"Tam giac tao thanh la {ketQua}.");
}

