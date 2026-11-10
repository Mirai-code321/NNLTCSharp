using Bai3_InLich;

// Nhập năm
Console.Write("Nhap nam: ");
int nam = int.Parse(Console.ReadLine()!);

// Nhập thứ chọn ngày đầu tiên
Console.Write("Nhap thu chon ngay dau tien: ");
int thuChon = int.Parse(Console.ReadLine()!);

// Nhập tháng
Console.Write("Nhap thang: ");
int thang = int.Parse(Console.ReadLine()!);

// Tạo đối tượng InLich
InLich lich = new InLich();

// Hiển thị lịch
lich.HienThiLich(nam, thang);