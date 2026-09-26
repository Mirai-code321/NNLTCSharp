using Bai02InterfaceSort;

Console.WriteLine(
    "CHUONG TRINH SAP XEP MANG TONG QUAT BANG INTERFACE"
);

Console.WriteLine();

// Sap xep mang so nguyen.
int[] mangSoNguyen =
{
    5, 2, 8, 1, 4
};

Console.WriteLine("MANG SO NGUYEN TRUOC KHI SAP XEP");
Console.WriteLine(
    string.Join(" ", mangSoNguyen)
);

BoSapXep.SapXep(mangSoNguyen);

Console.WriteLine("MANG SO NGUYEN SAU KHI SAP XEP");
Console.WriteLine(
    string.Join(" ", mangSoNguyen)
);

// Sap xep mang chuoi.
string[] mangChuoi =
{
    "Cam",
    "Buoi",
    "Tao",
    "Dua"
};

Console.WriteLine("\nMANG CHUOI TRUOC KHI SAP XEP");
Console.WriteLine(
    string.Join(" ", mangChuoi)
);

BoSapXep.SapXep(mangChuoi);

Console.WriteLine("MANG CHUOI SAU KHI SAP XEP");
Console.WriteLine(
    string.Join(" ", mangChuoi)
);

// Sap xep mang sinh vien.
SinhVien[] danhSachSinhVien =
{
    new SinhVien(
        "SV01",
        "Nguyen Van An",
        8.5
    ),

    new SinhVien(
        "SV02",
        "Tran Thi Binh",
        6.5
    ),

    new SinhVien(
        "SV03",
        "Le Van Cuong",
        9.0
    ),

    new SinhVien(
        "SV04",
        "Hoang Anh",
        8.5
    )
};

Console.WriteLine(
    "\nDANH SACH SINH VIEN TRUOC KHI SAP XEP"
);

XuatDanhSach(danhSachSinhVien);

BoSapXep.SapXep(
    danhSachSinhVien
);

Console.WriteLine(
    "\nDANH SACH SINH VIEN SAU KHI SAP XEP"
);

XuatDanhSach(danhSachSinhVien);

static void XuatDanhSach(
    SinhVien[] danhSach
)
{
    for (int i = 0; i < danhSach.Length; i++)
    {
        Console.WriteLine(
            $"{i + 1}. {danhSach[i]}"
        );
    }
}