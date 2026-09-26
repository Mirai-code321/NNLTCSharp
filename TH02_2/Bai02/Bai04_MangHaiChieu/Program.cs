using Bai04MangHaiChieu;

Console.WriteLine("CHUONG TRINH QUAN LY MANG HAI CHIEU");
Console.WriteLine();

// Tao doi tuong bang constructor mac dinh.
MangHaiChieu mang = new MangHaiChieu();

// Nhap mang.
mang.Input();

Console.WriteLine("\nMANG DA NHAP");
mang.Output();

// Tim cac so nguyen to.
List<int> cacSoNguyenTo =
    mang.TimSoNguyenTo();

Console.WriteLine("\nCAC SO NGUYEN TO TRONG MANG");

if (cacSoNguyenTo.Count == 0)
{
    Console.WriteLine(
        "Mang khong co so nguyen to."
    );
}
else
{
    Console.WriteLine(
        string.Join(" ", cacSoNguyenTo)
    );
}

if (mang.SoDong > 0 && mang.SoCot > 0)
{
    // Minh hoa cach doc phan tu bang indexer.
    Console.WriteLine(
        $"\nPhan tu tai [0, 0]: {mang[0, 0]}"
    );

    // Minh hoa cach thay doi phan tu bang indexer.
    mang[0, 0] = 100;

    Console.WriteLine(
        "Mang sau khi doi phan tu [0, 0] thanh 100:"
    );

    mang.Output();
}