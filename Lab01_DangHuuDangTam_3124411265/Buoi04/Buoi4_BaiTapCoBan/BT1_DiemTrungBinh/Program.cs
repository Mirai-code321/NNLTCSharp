using NNLTCSharp.Buoi3;

Console.Write("Moi ban nhap diem Toan, Ly, Hoa: ");

string[] diem = Console.ReadLine()!.Split(' ');

double toan = double.Parse(diem[0]);
double ly = double.Parse(diem[1]);
double hoa = double.Parse(diem[2]);

double diemTrungBinh = DiemTrungBinh.TinhDiemTrungBinh(toan, ly, hoa);
string xepLoai = DiemTrungBinh.XepLoai(diemTrungBinh);

Console.WriteLine(
    $"Ban co diem trung binh {diemTrungBinh:F2} duoc xep loai {xepLoai}."
);

