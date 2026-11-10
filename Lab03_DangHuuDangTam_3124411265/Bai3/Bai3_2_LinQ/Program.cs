using System;
using System.Linq;

// Bài 3.2: Thống kê mảng chuỗi
string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
    "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
    "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

Console.OutputEncoding = System.Text.Encoding.UTF8; // để in được tiếng Việt

// Câu a: tìm độ dài nhỏ nhất/lớn nhất trước, rồi lọc các phần tử có độ dài đó
// (dùng Where thay vì First vì có thể có nhiều phần tử cùng độ dài)
int doDaiMin = monAn.Min(s => s.Length);
int doDaiMax = monAn.Max(s => s.Length);
var ngan = monAn.Where(s => s.Length == doDaiMin);
var dai = monAn.Where(s => s.Length == doDaiMax);
Console.WriteLine($"a. Ngắn nhất ({doDaiMin} ký tự): " + string.Join(", ", ngan));
Console.WriteLine($"   Dài nhất ({doDaiMax} ký tự): " + string.Join(", ", dai));

// Câu b: tách chuỗi theo khoảng trắng, lấy từ đầu tiên làm khóa nhóm
Console.WriteLine("b. Phân nhóm theo từ đầu tiên:");
foreach (var nhom in monAn.GroupBy(s => s.Split(' ')[0])
                          .Select(g => new { Key = g.Key, Count = g.Count(), Items = g }))
{
    Console.WriteLine($"   {nhom.Key} ({nhom.Count}): {string.Join(", ", nhom.Items)}");
}

// Câu c: đếm phần tử có từ đầu tiên là "Bánh"
int soBanh = monAn.Count(s => s.Split(' ')[0] == "Bánh");
Console.WriteLine("c. Số món bắt đầu bằng từ Bánh: " + soBanh);