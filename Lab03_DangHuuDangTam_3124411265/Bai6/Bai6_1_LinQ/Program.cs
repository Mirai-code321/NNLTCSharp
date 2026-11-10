using System;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8; // để in được tiếng Việt

var dsHe = DuLieu.DS_He();

Console.WriteLine($"Danh sách hệ đào tạo ({dsHe.Count} hệ):");
Console.WriteLine($"   {"Mã hệ",-8}{"Tên hệ"}");
foreach (var h in dsHe)
    Console.WriteLine($"   {h.MaHe,-8}{h.TenHe}");