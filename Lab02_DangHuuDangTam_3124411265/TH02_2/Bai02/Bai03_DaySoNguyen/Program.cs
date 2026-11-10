using Bai03DaySoNguyen;

Console.WriteLine("CHUONG TRINH QUAN LY DAY SO NGUYEN");
Console.WriteLine();

// Tao doi tuong bang constructor mac dinh.
DaySoNguyen daySo = new DaySoNguyen();

// Nhap day so.
daySo.Input();

Console.WriteLine("\nDAY SO DA NHAP");
daySo.Output();

// Tim cac so chan.
DaySoNguyen daySoChan = daySo.TimSoChan();

Console.WriteLine("\nCAC SO CHAN TRONG DAY");
daySoChan.Output();

if (daySo.Count > 0)
{
    // Minh hoa cach truy cap phan tu bang indexer.
    Console.WriteLine(
        $"\nPhan tu dau tien: {daySo[0]}"
    );

    // Thay doi phan tu dau tien bang indexer.
    daySo[0] = 100;

    Console.WriteLine(
        "Day so sau khi doi phan tu dau tien thanh 100:"
    );

    daySo.Output();
}