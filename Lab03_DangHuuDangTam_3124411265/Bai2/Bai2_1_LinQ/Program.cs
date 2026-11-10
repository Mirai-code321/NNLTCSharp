using System;
using System.Linq;

// Bài 2.1: Truy vấn LINQ trên mảng số nguyên
int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

Console.WriteLine("Mảng ban đầu: " + string.Join(", ", mangSo));

// Câu a: phần tử chia hết cho 4 và 3
// Where() giữ lại phần tử thỏa điều kiện, cả hai điều kiện nối bằng &&
var cauA = mangSo.Where(x => x % 4 == 0 && x % 3 == 0);
Console.WriteLine("a. Chia hết cho 4 và 3: " + string.Join(", ", cauA));

// Câu b: phần tử nhỏ hơn hoặc bằng 3
var cauB = mangSo.Where(x => x <= 3);
Console.WriteLine("b. Nhỏ hơn hoặc bằng 3: " + string.Join(", ", cauB));

// Câu c: tạo dãy mới, chẵn thì chia đôi, lẻ thì giữ nguyên
// Select() biến đổi từng phần tử thành giá trị mới
var cauC = mangSo.Select(x => x % 2 == 0 ? x / 2 : x);
Console.WriteLine("c. Dãy mới: " + string.Join(", ", cauC));