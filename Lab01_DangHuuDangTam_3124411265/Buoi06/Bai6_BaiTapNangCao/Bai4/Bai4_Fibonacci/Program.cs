using Bai4_Fibonacci;

// Nhập số nguyên dương n
Console.Write("Nhap n: ");
int n = int.Parse(Console.ReadLine()!);

// Tạo đối tượng để tìm số Fibonacci
TimSoFibonacci fibonacci = new TimSoFibonacci();

// Tìm số Fibonacci lớn nhất nhỏ hơn n
int ketQua = fibonacci.TimSo(n);

// In kết quả
Console.WriteLine($"So Fibonacci lon nhat nho hon {n} la: {ketQua}");