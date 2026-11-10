using System;
using System.Collections.Generic;
using System.Linq;

Console.OutputEncoding = System.Text.Encoding.UTF8; // để in được tiếng Việt

var dsMon = DuLieu.DS_Mon();

// in danh sách môn học đầy đủ 4 cột
void InMon(IEnumerable<MonHoc> ds)
{
    foreach (var m in ds)
        Console.WriteLine($"   {m.MaMon,-8}{m.TenMon,-44}{m.He,-5}{m.SoTiet}");
}

// a. Tổng số môn hiện có
Console.WriteLine("a. Tổng số môn hiện có: " + dsMon.Count());
Console.WriteLine();

// b. Đếm số môn có tên bắt đầu bằng "Lập trình"
int soMonLapTrinh = dsMon.Count(m => m.TenMon.StartsWith("Lập trình"));
Console.WriteLine("b. Số môn có tên bắt đầu bằng \"Lập trình\": " + soMonLapTrinh);
Console.WriteLine();

// c. Tổng số tiết của hệ KTV
int tongTietKTV = dsMon.Where(m => m.He == "KTV").Sum(m => m.SoTiet);
Console.WriteLine("c. Tổng số tiết của hệ KTV: " + tongTietKTV);
Console.WriteLine();

// d. Tổng số môn của mỗi hệ
Console.WriteLine("d. Tổng số môn của mỗi hệ:");
var cauD = dsMon.GroupBy(m => m.He)
                .Select(g => new { He = g.Key, TongSoMon = g.Count() });
foreach (var x in cauD)
    Console.WriteLine($"   Hệ: {(x.He == "" ? "(trống)" : x.He),-8} Tổng số môn: {x.TongSoMon}");
// (đã đạt: GroupBy + Count nằm trong truy vấn, foreach chỉ in)
Console.WriteLine();

// e. Nhóm theo Số tiết; in Số tiết và Tổng số môn, sắp xếp giảm dần theo Số tiết
Console.WriteLine("e. Nhóm theo Số tiết (giảm dần):");
var cauE = dsMon.GroupBy(m => m.SoTiet)
                .OrderByDescending(g => g.Key)
                .Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() });
foreach (var x in cauE)
    Console.WriteLine($"   Số tiết: {x.SoTiet,-5} Tổng số môn: {x.TongSoMon}");
Console.WriteLine();

// f. Thông tin môn học có số tiết cao nhất
Console.WriteLine("f. Môn học có số tiết cao nhất:");
int maxTiet = dsMon.Max(m => m.SoTiet);
InMon(dsMon.Where(m => m.SoTiet == maxTiet));
Console.WriteLine();

// g. Thống kê theo Hệ: tổng số môn, tổng số tiết, số tiết cao nhất, số tiết thấp nhất
Console.WriteLine("g. Thống kê theo Hệ:");
var cauG = dsMon.GroupBy(m => m.He)
                .Select(g => new
                {
                    He = g.Key,
                    TongSoMon = g.Count(),
                    TongSoTiet = g.Sum(m => (int)m.SoTiet),
                    CaoNhat = g.Max(m => m.SoTiet),
                    ThapNhat = g.Min(m => m.SoTiet)
                });
foreach (var x in cauG)
    Console.WriteLine($"   Hệ: {(x.He == "" ? "(trống)" : x.He),-8} Số môn: {x.TongSoMon,-3} Tổng tiết: {x.TongSoTiet,-5} Cao nhất: {x.CaoNhat,-4} Thấp nhất: {x.ThapNhat}");
Console.WriteLine();

// h. Liệt kê các môn học được phân nhóm theo Hệ
Console.WriteLine("h. Các môn học phân nhóm theo Hệ:");
foreach (var g in dsMon.GroupBy(m => m.He)
                       .Select(gr => new { Key = gr.Key, Count = gr.Count(), Items = gr }))
{
    Console.WriteLine($" * Hệ: {(g.Key == "" ? "(trống)" : g.Key)} ({g.Count} môn)");
    InMon(g.Items);
}
Console.WriteLine();

// i. Liệt kê các môn học được phân nhóm theo Số tiết và tăng dần theo Số tiết
Console.WriteLine("i. Các môn học phân nhóm theo Số tiết (tăng dần):");
foreach (var g in dsMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key)
                       .Select(gr => new { Key = gr.Key, Count = gr.Count(), Items = gr }))
{
    Console.WriteLine($" * Số tiết: {g.Key} ({g.Count} môn)");
    InMon(g.Items);
}
Console.WriteLine();

// j. Hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn
Console.WriteLine("j. Hệ KTV, phân nhóm theo học phần:");
var cauJ = dsMon.Where(m => m.He == "KTV")
                .GroupBy(m => m.MaMon.Substring(0, 3)) // lấy 3 ký tự đầu: HP2, HP3, HP4, HP5
                .OrderBy(g => g.Key)
                .Select(gr => new
                {
                    Key = gr.Key,
                    Count = gr.Count(),
                    Items = gr.OrderBy(m => m.MaMon)
                });
foreach (var g in cauJ)
{
    Console.WriteLine($" * Học phần {g.Key}:");
    InMon(g.Items);
}
Console.WriteLine();

// k. Phân nhóm theo Hệ, chỉ lấy các môn có Số tiết > 40; mỗi nhóm sắp xếp theo Mã môn
Console.WriteLine("k. Phân nhóm theo Hệ, chỉ lấy môn có Số tiết > 40:");
var cauK = dsMon.Where(m => m.SoTiet > 40)
                .GroupBy(m => m.He)
                .Select(gr => new
                {
                    Key = gr.Key,
                    Count = gr.Count(),
                    Items = gr.OrderBy(m => m.MaMon)
                });
foreach (var g in cauK)
{
    Console.WriteLine($" * Hệ: {g.Key}");
    InMon(g.Items);
}
