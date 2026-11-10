using Bai04PhanSo;
using Bai06DayPhanSo;

Console.WriteLine("CHUONG TRINH TINH TONG DAY PHAN SO");
Console.WriteLine();

// Tao day phan so bang constructor mac dinh.
DayPhanSo dayPhanSo = new DayPhanSo();

// Nhap day phan so.
dayPhanSo.Input();

Console.WriteLine("\nDAY PHAN SO DA NHAP");
dayPhanSo.Output();

// Tinh tong cac phan so.
PhanSo tong = dayPhanSo.TinhTong();

Console.WriteLine($"\nTong day phan so: {tong}");

if (dayPhanSo.Count > 0)
{
    // Minh hoa cach truy cap bang indexer.
    Console.WriteLine(
        $"Phan so dau tien: {dayPhanSo[0]}"
    );
}