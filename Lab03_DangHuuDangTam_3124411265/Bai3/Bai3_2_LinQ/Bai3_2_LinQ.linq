<Query Kind="Statements" />

string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
    "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
    "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

// a. Phần tử ngắn nhất và dài nhất (theo số ký tự, tính cả khoảng trắng)
int doDaiMin = monAn.Min(s => s.Length);
int doDaiMax = monAn.Max(s => s.Length);
monAn.Where(s => s.Length == doDaiMin).Dump("a. Ngắn nhất (" + doDaiMin + " ký tự)");
monAn.Where(s => s.Length == doDaiMax).Dump("a. Dài nhất (" + doDaiMax + " ký tự)");

// b. Nhóm theo từ đầu tiên của tên món
var cauB = monAn.GroupBy(s => s.Split(' ')[0])
                .Select(g => new { TuDau = g.Key, SoLuong = g.Count(), CacMon = string.Join(", ", g) });
cauB.Dump("b. Nhóm theo từ đầu tiên");

// c. Đếm phần tử có từ đầu tiên là "Bánh"
monAn.Count(s => s.Split(' ')[0] == "Bánh").Dump("c. Số món bắt đầu bằng từ Bánh");