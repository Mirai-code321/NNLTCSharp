using Bai01TinhTuoiSinhVien;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("CHƯƠNG TRÌNH TÍNH TUỔI SINH VIÊN");
Console.WriteLine();

// Tạo đối tượng bằng constructor mặc định.
SinhVien sinhVien = new SinhVien();

// Nhập thông tin cho đối tượng.
sinhVien.Nhap();

// Xuất thông tin và tuổi sinh viên.
sinhVien.Xuat();