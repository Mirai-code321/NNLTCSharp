using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

Console.OutputEncoding = Encoding.UTF8; // để hiển thị tiếng Việt

var dsMon = DuLieu.DS_Mon();

// a. Tên môn bắt đầu bằng "Lập trình"
In("Câu a", dsMon
    .Where(m => m.TenMon.StartsWith("Lập trình"))
    .Select(m => m.TenMon));

// b. Hệ CD, số tiết giảm dần rồi mã môn tăng dần
In("Câu b", dsMon
    .Where(m => m.He == "CD")
    .OrderByDescending(m => m.SoTiet)
    .ThenBy(m => m.MaMon)
    .Select(m => $"{m.MaMon} | {m.TenMon} | {m.He} | {m.SoTiet}"));

// c. Tên môn chứa "web", chỉ lấy Tên môn và Hệ
In("Câu c", dsMon
    .Where(m => m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
    .Select(m => new { m.TenMon, m.He }));

// d. Hệ KTV, mã môn tăng dần
In("Câu d", dsMon
    .Where(m => m.He == "KTV")
    .OrderBy(m => m.MaMon)
    .Select(m => $"{m.MaMon} | {m.TenMon} | {m.He} | {m.SoTiet}"));

// Hàm in thay cho .Dump() của LINQPad
static void In<T>(string tieuDe, IEnumerable<T> ds)
{
    Console.WriteLine($"=== {tieuDe} ===");
    foreach (var item in ds)
        Console.WriteLine(item);
    Console.WriteLine();
}