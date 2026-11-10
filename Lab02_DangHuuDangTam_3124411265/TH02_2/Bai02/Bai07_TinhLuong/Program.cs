using Bai07TinhLuong;

Console.WriteLine(
    "CHUONG TRINH TINH TONG LUONG PHONG BAN"
);

Console.WriteLine();

PhongBan phongBan = new PhongBan();

// Nhap danh sach nhan vien.
phongBan.Input();

Console.WriteLine("\nKET QUA");

// Xuat danh sach va tong luong.
phongBan.Output();