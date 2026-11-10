using NNLTCSharp.Buoi04;

Console.Write("Nhap ngay d: ");
int d = int.Parse(Console.ReadLine()!);

Console.Write("Nhap thang m: ");
int m = int.Parse(Console.ReadLine()!);

Console.Write("Nhap nam y: ");
int y = int.Parse(Console.ReadLine()!);

if (KiemTraNgayHopLe.KiemTra(d, m, y))
    Console.WriteLine($"{d}/{m}/{y} la ngay hop le.");
else
    Console.WriteLine($"{d}/{m}/{y} khong phai ngay hop le.");

