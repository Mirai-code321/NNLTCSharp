using Bai02Point;

Console.WriteLine("CHUONG TRINH XU LY DIEM");
Console.WriteLine();

// Tao hai doi tuong diem A va B.
Point diemA = new Point();
Point diemB = new Point();

Console.WriteLine("Nhap diem A");
diemA.Input();

Console.WriteLine("\nNhap diem B");
diemB.Input();

Console.WriteLine("\nKET QUA");
Console.WriteLine($"A = {diemA}");
Console.WriteLine($"B = {diemB}");

// Cong hai diem.
Point tong = diemA + diemB;

// Tru hai diem.
Point hieu = diemA - diemB;

// Doi dau toa do cua diem A.
Point doiDiemA = -diemA;

Console.WriteLine($"A + B = {tong}");
Console.WriteLine($"A - B = {hieu}");
Console.WriteLine($"-A = {doiDiemA}");

// Cach 1: Tinh khoang cach bang phuong thuc thanh vien.
double khoangCachThanhVien =
    diemA.KhoangCachDen(diemB);

// Cach 2: Tinh khoang cach bang phuong thuc tinh.
double khoangCachTinh =
    Point.KhoangCach(diemA, diemB);

Console.WriteLine(
    $"Khoang cach A den B bang phuong thuc thanh vien: " +
    $"{khoangCachThanhVien:0.##}"
);

Console.WriteLine(
    $"Khoang cach A den B bang phuong thuc tinh: " +
    $"{khoangCachTinh:0.##}"
);

// Cach 1: Tim trung diem bang phuong thuc thanh vien.
Point trungDiemThanhVien =
    diemA.TrungDiemVoi(diemB);

// Cach 2: Tim trung diem bang phuong thuc tinh.
Point trungDiemTinh =
    Point.TrungDiem(diemA, diemB);

Console.WriteLine(
    $"Trung diem bang phuong thuc thanh vien: " +
    $"{trungDiemThanhVien}"
);

Console.WriteLine(
    $"Trung diem bang phuong thuc tinh: " +
    $"{trungDiemTinh}"
);