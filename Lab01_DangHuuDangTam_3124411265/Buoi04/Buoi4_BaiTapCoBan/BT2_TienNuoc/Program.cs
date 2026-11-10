using NNLTCSharp.Buoi3;

Console.Write("Moi ban nhap chi so tieu thu nuoc thang truoc (m^3): ");
int chiSoCu = int.Parse(Console.ReadLine()!);

Console.Write("Moi ban nhap chi so tieu thu nuoc trong thang (m^3): ");
int chiSoMoi = int.Parse(Console.ReadLine()!);

Console.Write("Moi ban nhap so nguoi dang ky trong ho: ");
int soNguoi = int.Parse(Console.ReadLine()!);

int soMetKhoi = chiSoMoi - chiSoCu;

double tienNuoc = TienNuoc.TinhTienNuoc(
    chiSoCu,
    chiSoMoi,
    soNguoi
);

Console.WriteLine(
    $"So tien phai tra cho {soMetKhoi} m^3 tieu thu trong thang la {tienNuoc:F0} Đ."
);

