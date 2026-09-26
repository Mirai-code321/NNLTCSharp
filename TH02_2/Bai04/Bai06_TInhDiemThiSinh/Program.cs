using Bai06TinhDiemThiSinh;

Console.WriteLine(
    "CHUONG TRINH TINH DIEM THI SINH"
);

Console.WriteLine();

CuocThi cuocThi = new CuocThi();

// Nhap danh sach thi sinh.
cuocThi.Input();

Console.WriteLine("\nKET QUA CUOC THI");

// Xuat tong diem cua tung thi sinh.
cuocThi.Output();