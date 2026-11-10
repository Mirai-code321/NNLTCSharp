using System;

Console.OutputEncoding = System.Text.Encoding.UTF8; // để in được tiếng Việt

// Gọi phương thức tĩnh để lấy danh sách môn học
var dsMon = DuLieu.DS_Mon();

Console.WriteLine("a. Danh sách môn học:");
Console.WriteLine($"{"Mã môn",-8}{"Tên môn",-44}{"Hệ",-5}Số tiết");
foreach (var mon in dsMon)
{
    Console.WriteLine($"{mon.MaMon,-8}{mon.TenMon,-44}{mon.He,-5}{mon.SoTiet}");
}