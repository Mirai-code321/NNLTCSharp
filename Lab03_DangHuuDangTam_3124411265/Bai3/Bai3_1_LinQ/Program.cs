using System;
using System.Linq;

// Bài 3.1: Thống kê mảng số
int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

Console.OutputEncoding = System.Text.Encoding.UTF8; // để in được tiếng Việt
Console.WriteLine("Mảng: " + string.Join(", ", mangSo));

// Câu a: Count() đếm tất cả, Count(điều kiện) đếm phần tử thỏa điều kiện
Console.WriteLine("a. Tổng số phần tử: " + mangSo.Count());
Console.WriteLine("   Số phần tử chẵn: " + mangSo.Count(x => x % 2 == 0));
Console.WriteLine("   Số phần tử lẻ: " + mangSo.Count(x => x % 2 != 0));

// Câu b: Sum, Max, Min
Console.WriteLine("b. Tổng: " + mangSo.Sum());
Console.WriteLine("   Lớn nhất: " + mangSo.Max());
Console.WriteLine("   Nhỏ nhất: " + mangSo.Min());

// Câu c: Distinct() loại giá trị trùng, rồi đếm
Console.WriteLine("c. Số giá trị khác nhau: " + mangSo.Distinct().Count());

// Câu d: GroupBy gom phần tử theo số dư khi chia cho 5 (g.Key là số dư)
Console.WriteLine("d. Phân nhóm theo số dư khi chia cho 5:");
foreach (var nhom in mangSo.GroupBy(x => x % 5).OrderBy(g => g.Key))
{
    Console.WriteLine($"   Dư {nhom.Key}: {string.Join(", ", nhom)}");
}