using Bai01ArraySort;

Console.WriteLine(
    "CHUONG TRINH SAP XEP SINH VIEN BANG ARRAY.SORT"
);

Console.WriteLine();

// Nhap danh sach sinh vien.
SinhVien[] danhSach =
    QuanLySinhVien.NhapDanhSach();

Console.WriteLine("\nDANH SACH TRUOC KHI SAP XEP");

QuanLySinhVien.XuatDanhSach(
    danhSach
);

// Sap xep bang phuong thuc tinh Array.Sort.
QuanLySinhVien.SapXep(
    danhSach
);

Console.WriteLine(
    "\nDANH SACH SAU KHI SAP XEP TANG DAN THEO DIEM"
);

QuanLySinhVien.XuatDanhSach(
    danhSach
);