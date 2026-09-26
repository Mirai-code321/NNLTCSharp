using Bai05TinhLuongDaHinh;

Console.WriteLine(
    "CHUONG TRINH TINH LUONG NHAN VIEN"
);

Console.WriteLine();

CongTy congTy = new CongTy();

// Bien lop cha luu doi tuong nhan vien kinh doanh.
NhanVien nhanVienKinhDoanh =
    new NhanVienKinhDoanh(
        "KD01",
        "Nguyen Van An",
        10_000_000m,
        4
    );

// Bien lop cha luu doi tuong nhan vien san xuat.
NhanVien nhanVienSanXuat =
    new NhanVienSanXuat(
        "SX01",
        "Tran Thi Binh",
        4_000
    );

NhanVien nhanVienSanXuatKhac =
    new NhanVienSanXuat(
        "SX02",
        "Le Van Cuong",
        3_000
    );

congTy.Add(nhanVienKinhDoanh);
congTy.Add(nhanVienSanXuat);
congTy.Add(nhanVienSanXuatKhac);

// Xuat danh sach va luong cua tung nhan vien.
congTy.Output();