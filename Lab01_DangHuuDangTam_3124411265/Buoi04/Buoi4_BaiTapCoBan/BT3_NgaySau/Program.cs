using NNLTCSharp.Buoi3;

Console.Write("Moi ban nhap ngay, thang, nam: ");

string[] input = Console.ReadLine()!.Split(' ');

int ngay = int.Parse(input[0]);
int thang = int.Parse(input[1]);
int nam = int.Parse(input[2]);

string ngaySau = NgaySauDo.TinhNgaySau(ngay, thang, nam);

Console.WriteLine(
    $"Ngay sau ngay {ngay}/{thang}/{nam} la ngay {ngaySau}."
);

