using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // để in được tiếng Việt
        Bai62();
    }

    // in từng dòng của kết quả truy vấn theo định dạng cho trước
    static void In<T>(IEnumerable<T> ds, Func<T, string> dinhDang)
    {
        foreach (var x in ds)
            Console.WriteLine(dinhDang(x));
    }

    static void Bai62()
    {
        var dsMon = DuLieu.DS_Mon();
        var dsHe = DuLieu.DS_He();

        // a. Dùng Join liệt kê: Tên hệ, Mã môn, Tên môn (chỉ các dòng khớp hệ)
        Console.WriteLine("a. Join: Tên hệ, Mã môn, Tên môn");
        var cauA = dsHe.Join(dsMon,
                             h => h.MaHe,
                             m => m.He,
                             (h, m) => new { h.TenHe, m.MaMon, m.TenMon });
        In(cauA, x => $"   {x.TenHe,-20}{x.MaMon,-8}{x.TenMon}");
        Console.WriteLine($"   => {cauA.Count()} dòng");
        Console.WriteLine();

        // b. Left outer join: GroupJoin + DefaultIfEmpty, giữ cả hệ chưa có môn
        Console.WriteLine("b. Left outer join (kể cả hệ chưa có môn học):");
        var cauB = dsHe.GroupJoin(dsMon, h => h.MaHe, m => m.He,
                                  (h, nhom) => new { h, nhom })
                       .SelectMany(x => x.nhom.DefaultIfEmpty(),
                                   (x, m) => new
                                   {
                                       x.h.TenHe,
                                       MaMon = m?.MaMon ?? "(chưa có)",
                                       TenMon = m?.TenMon ?? "(chưa có môn học)"
                                   });
        In(cauB, x => $"   {x.TenHe,-20}{x.MaMon,-10}{x.TenMon}");
        Console.WriteLine($"   => {cauB.Count()} dòng");
        Console.WriteLine();

        // các môn chưa khai báo hệ (Hệ không có trong DS_He)
        var monChuaCoHe = dsMon.Where(m => !dsHe.Any(h => h.MaHe == m.He))
                               .Select(m => new
                               {
                                   TenHe = "(chưa khai báo hệ)",
                                   m.MaMon,
                                   m.TenMon
                               });

        // c. Full outer join: hệ chưa có môn + môn chưa khai báo hệ
        Console.WriteLine("c. Full outer join (cả hệ chưa có môn và môn chưa khai báo hệ):");
        var cauC = cauB.Concat(monChuaCoHe);
        In(cauC, x => $"   {x.TenHe,-20}{x.MaMon,-10}{x.TenMon}");
        Console.WriteLine($"   => {cauC.Count()} dòng");
        Console.WriteLine();

        // d. Chỉ liệt kê hệ chưa có môn và môn chưa khai báo hệ
        Console.WriteLine("d. Chỉ hệ chưa có môn và môn chưa khai báo hệ:");
        var heChuaCoMon = dsHe.Where(h => !dsMon.Any(m => m.He == h.MaHe))
                              .Select(h => new
                              {
                                  h.TenHe,
                                  MaMon = "(chưa có)",
                                  TenMon = "(chưa có môn học)"
                              });
        var cauD = heChuaCoMon.Concat(monChuaCoHe);
        In(cauD, x => $"   {x.TenHe,-20}{x.MaMon,-10}{x.TenMon}");
        Console.WriteLine();

        // e. 5 môn đầu tiên có số tiết giảm dần: Tên hệ, Mã môn, Tên môn, Số tiết
        Console.WriteLine("e. 5 môn có số tiết cao nhất:");
        var cauE = dsHe.Join(dsMon, h => h.MaHe, m => m.He,
                             (h, m) => new { h.TenHe, m.MaMon, m.TenMon, m.SoTiet })
                       .OrderByDescending(x => x.SoTiet)
                       .ThenBy(x => x.MaMon)
                       .Take(5);
        In(cauE, x => $"   {x.TenHe,-20}{x.MaMon,-8}{x.TenMon,-40}{x.SoTiet}");
        Console.WriteLine();

        // f. Tổng số môn của mỗi hệ: Mã hệ, Tên hệ, Tổng số môn (GroupJoin giữ cả hệ có 0 môn)
        Console.WriteLine("f. Tổng số môn của mỗi hệ:");
        var cauF = dsHe.GroupJoin(dsMon, h => h.MaHe, m => m.He,
                                  (h, nhom) => new { h.MaHe, h.TenHe, TongSoMon = nhom.Count() });
        In(cauF, x => $"   {x.MaHe,-8}{x.TenHe,-20}Tổng số môn: {x.TongSoMon}");
        Console.WriteLine();

        // g. Có bao nhiêu loại Số tiết khác nhau
        Console.WriteLine("g. Số loại Số tiết khác nhau:");
        var dsSoTiet = dsMon.Select(m => m.SoTiet).Distinct().OrderByDescending(s => s).ToList();
        Console.WriteLine($"   {dsSoTiet.Count} loại ({string.Join(", ", dsSoTiet)})");
        Console.WriteLine();

        // h. Môn học đầu tiên có tên bắt đầu bằng "Lập trình"
        Console.WriteLine("h. Môn học đầu tiên có tên bắt đầu bằng \"Lập trình\":");
        var cauH = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
        if (cauH != null)
            Console.WriteLine($"   {cauH.MaMon} - {cauH.TenMon} ({cauH.He}, {cauH.SoTiet} tiết)");
        else
            Console.WriteLine("   Không có môn nào.");
        Console.WriteLine();

        // i. Liệt kê các môn theo từng hệ, đánh số thứ tự trong mỗi nhóm
        Console.WriteLine("i. Các môn theo từng hệ (đánh số thứ tự):");
foreach (var g in dsMon.GroupBy(m => m.He)
                       .Select(gr => new
                       {
                           Key = gr.Key,
                           Count = gr.Count(),
                           TenHe = dsHe.FirstOrDefault(h => h.MaHe == gr.Key)?.TenHe ?? "(chưa khai báo hệ)",
                           Items = gr
                       }))
{
    string maHe = g.Key == "" ? "(trống)" : g.Key;
    Console.WriteLine($" * Hệ: {maHe} - {g.TenHe} ({g.Count} môn)");
    var ds = g.Items.Select((m, i) => new { STT = i + 1, m.MaMon, m.TenMon });
    In(ds, x => $"   {x.STT,2}. {x.MaMon,-8}{x.TenMon}");
}
    }
}