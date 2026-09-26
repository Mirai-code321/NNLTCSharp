using Bai04PhanSo;

Console.WriteLine("CHUONG TRINH XU LY PHAN SO");
Console.WriteLine();

PhanSo phanSoA = new PhanSo();
PhanSo phanSoB = new PhanSo();

Console.WriteLine("Nhap phan so A");
phanSoA.Input();

Console.WriteLine("\nNhap phan so B");
phanSoB.Input();

Console.WriteLine("\nKET QUA");
Console.WriteLine($"A = {phanSoA}");
Console.WriteLine($"B = {phanSoB}");

// Thuc hien cac phep toan mot ngoi.
Console.WriteLine($"+A = {+phanSoA}");
Console.WriteLine($"-A = {-phanSoA}");

// Thuc hien cac phep toan hai ngoi.
Console.WriteLine($"A + B = {phanSoA + phanSoB}");
Console.WriteLine($"A - B = {phanSoA - phanSoB}");
Console.WriteLine($"A * B = {phanSoA * phanSoB}");

// Chi thuc hien phep chia neu B khac 0.
if (phanSoB.TuSo != 0)
{
    Console.WriteLine($"A / B = {phanSoA / phanSoB}");
}
else
{
    Console.WriteLine(
        "Khong the tinh A / B vi B bang 0."
    );
}

// Thuc hien cac phep so sanh.
Console.WriteLine($"A > B  : {phanSoA > phanSoB}");
Console.WriteLine($"A < B  : {phanSoA < phanSoB}");
Console.WriteLine($"A >= B : {phanSoA >= phanSoB}");
Console.WriteLine($"A <= B : {phanSoA <= phanSoB}");
Console.WriteLine($"A == B : {phanSoA == phanSoB}");
Console.WriteLine($"A != B : {phanSoA != phanSoB}");