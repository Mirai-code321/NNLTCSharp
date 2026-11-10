using NNLTCSharp.Buoi02;

Console.Write("Nhap x: ");
double x = double.Parse(Console.ReadLine()!);

Console.Write("Nhap y: ");
double y = double.Parse(Console.ReadLine()!);

bool ketQua = NamTrong.KiemTra(x, y);

if (ketQua)
{
    Console.WriteLine("Diem nam trong tam giac.");
}
else
{
    Console.WriteLine("Diem khong nam trong tam giac.");
}

