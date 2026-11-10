using System;
using System.Linq;

// Bài 2.2: Truy vấn LINQ trên mảng chuỗi
string[] mangChuoi = { "đầu", "lòng", "hai", "à", "tố", "nga",
    "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

Console.OutputEncoding = System.Text.Encoding.UTF8; // để in được tiếng Việt

// Câu a: lọc chuỗi dài 4 ký tự, rồi sắp xếp theo ký tự đầu tiên
var cauA = mangChuoi.Where(s => s.Length == 4).OrderBy(s => s[0]);
Console.WriteLine("a. " + string.Join(", ", cauA));

// Câu b: mỗi phần tử biến thành "chữ thường - CHỮ HOA"
var cauB = mangChuoi.Select(s => s.ToLower() + " - " + s.ToUpper());
Console.WriteLine("b. " + string.Join(", ", cauB));

// Câu c: phần tử có chứa ký tự 'u'
var cauC = mangChuoi.Where(s => s.Contains('u'));
Console.WriteLine("c. " + string.Join(", ", cauC));

// Câu d: chọn phần tử bắt đầu bằng chữ hoa rồi nối bằng khoảng trắng
var cauD = string.Join(" ", mangChuoi.Where(s => char.IsUpper(s[0])));
Console.WriteLine("d. " + cauD);