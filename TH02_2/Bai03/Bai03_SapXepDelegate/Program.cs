using Bai03DelegateSort;

Console.WriteLine(
    "CHUONG TRINH SAP XEP MANG TONG QUAT BANG DELEGATE"
);

Console.WriteLine();

// ==================================================
// SAP XEP MANG SO NGUYEN
// ==================================================

int[] mangSo =
{
    5, 2, 8, 1, 4
};

Console.WriteLine("MANG BAN DAU");
Console.WriteLine(
    string.Join(" ", mangSo)
);

// Delegate sap xep so nguyen tang dan.
SoSanh<int> tangDan = (a, b) =>
    a.CompareTo(b);

BoSapXep.SapXep(
    mangSo,
    tangDan
);

Console.WriteLine("SAP XEP TANG DAN");
Console.WriteLine(
    string.Join(" ", mangSo)
);

// Delegate sap xep so nguyen giam dan.
SoSanh<int> giamDan = (a, b) =>
    b.CompareTo(a);

BoSapXep.SapXep(
    mangSo,
    giamDan
);

Console.WriteLine("SAP XEP GIAM DAN");
Console.WriteLine(
    string.Join(" ", mangSo)
);

// ==================================================
// SAP XEP SINH VIEN
// ==================================================

SinhVien[] danhSach =
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
        9
    ),

    new SinhVien(
        "SV04",
        "Hoang Anh",
        8.5
    )
};

Console.WriteLine(
    "\nDANH SACH SINH VIEN BAN DAU"
);

XuatDanhSach(danhSach);

// Delegate sap xep diem giam dan.
SoSanh<SinhVien> theoDiemGiamDan =
    (a, b) =>
    {
        int ketQuaDiem =
            b.DiemTrungBinh.CompareTo(
                a.DiemTrungBinh
            );

        if (ketQuaDiem != 0)
        {
            return ketQuaDiem;
        }

        // Neu bang diem thi sap xep theo ten.
        return string.Compare(
            a.HoTen,
            b.HoTen,
            StringComparison.OrdinalIgnoreCase
        );
    };

BoSapXep.SapXep(
    danhSach,
    theoDiemGiamDan
);

Console.WriteLine(
    "\nSAP XEP THEO DIEM GIAM DAN"
);

XuatDanhSach(danhSach);

// Delegate sap xep ho ten tu A den Z.
SoSanh<SinhVien> theoHoTen =
    (a, b) => string.Compare(
        a.HoTen,
        b.HoTen,
        StringComparison.OrdinalIgnoreCase
    );

BoSapXep.SapXep(
    danhSach,
    theoHoTen
);

Console.WriteLine(
    "\nSAP XEP THEO HO TEN"
);

XuatDanhSach(danhSach);

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