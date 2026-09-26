using Bai05DonThuc;

Console.WriteLine("CHUONG TRINH XU LY DON THUC");
Console.WriteLine();

// Tao don thuc bang constructor mac dinh.
DonThuc donThuc = new DonThuc();

// Nhap he so va so mu.
donThuc.Input();

Console.WriteLine($"\nDon thuc P(x) = {donThuc}");

// Nhap gia tri x.
double x;

while (true)
{
    Console.Write("Nhap gia tri x: ");
    string? duLieu = Console.ReadLine();

    if (double.TryParse(duLieu, out x))
    {
        break;
    }

    Console.WriteLine(
        "Loi: x phai la mot so thuc."
    );
}

// Tinh gia tri cua don thuc tai x.
double giaTri = donThuc.TinhGiaTri(x);

// Tinh don thuc dao ham.
DonThuc daoHam = donThuc.DaoHam();

// Tinh gia tri dao ham tai x.
double giaTriDaoHam = daoHam.TinhGiaTri(x);

Console.WriteLine("\nKET QUA");
Console.WriteLine($"P(x) = {donThuc}");
Console.WriteLine($"P({x:0.##}) = {giaTri:0.##}");
Console.WriteLine($"P'(x) = {daoHam}");
Console.WriteLine($"P'({x:0.##}) = {giaTriDaoHam:0.##}");