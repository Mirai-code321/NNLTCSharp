using Bai02Point;
using Bai06ArrayPoint;

Console.WriteLine("CHUONG TRINH QUAN LY DANH SACH DIEM");
Console.WriteLine();

ArrayPoint danhSach = new ArrayPoint();

// Nhap danh sach diem.
danhSach.Input();

Console.WriteLine("\nKET QUA");

// Xuat danh sach diem.
danhSach.Output();

if (danhSach.Count > 0)
{
    // Su dung indexer de truy cap diem dau tien.
    Console.WriteLine(
        $"\nDiem dau tien: {danhSach[0]}"
    );
}

// Them mot diem moi vao cuoi danh sach.
Point diemMoi = new Point(10, 20);
danhSach.Add(diemMoi);

Console.WriteLine("\nSAU KHI THEM DIEM (10, 20)");
danhSach.Output();

if (danhSach.Count > 0)
{
    // Su dung indexer de thay doi phan tu dau tien.
    danhSach[0] = new Point(100, 200);

    Console.WriteLine(
        "\nSAU KHI THAY DOI DIEM DAU TIEN"
    );

    danhSach.Output();
}