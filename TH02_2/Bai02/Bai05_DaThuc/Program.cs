using Bai05DaThuc;

Console.WriteLine("CHUONG TRINH XU LY DA THUC");
Console.WriteLine();

// Tao da thuc bang constructor mac dinh.
DaThuc daThuc = new DaThuc();

// Nhap da thuc.
daThuc.Input();

Console.WriteLine("\nDA THUC DA NHAP");
Console.WriteLine($"P(x) = {daThuc}");

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

// Tinh gia tri cua da thuc.
double giaTri = daThuc.TinhGiaTri(x);

Console.WriteLine("\nKET QUA");
Console.WriteLine($"P(x) = {daThuc}");
Console.WriteLine($"P({x:0.##}) = {giaTri:0.##}");

if (daThuc.Count > 0)
{
    // Truy cap don thuc dau tien bang indexer.
    Console.WriteLine(
        $"Don thuc tai vi tri 0: {daThuc[0]}"
    );

    // Truy cap don thuc bac cao nhat.
    Console.WriteLine(
        $"Don thuc bac cao nhat: {daThuc[daThuc.Bac]}"
    );
}