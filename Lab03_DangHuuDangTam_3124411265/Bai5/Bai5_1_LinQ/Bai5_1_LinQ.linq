<Query Kind="Program" />

void Main()
{
	var dsMon = DuLieu.DS_Mon();

	// a. Liệt kê tên các môn học bắt đầu bằng "Lập trình"
	dsMon
		.Where(m => m.TenMon.StartsWith("Lập trình"))
		.Select(m => m.TenMon)
		.Dump("Câu a");

	// b. Hệ "CD", sắp xếp số tiết giảm dần rồi mã môn tăng dần
	dsMon
		.Where(m => m.He == "CD")
		.OrderByDescending(m => m.SoTiet)
		.ThenBy(m => m.MaMon)
		.Dump("Câu b");

	// c. Tên môn chứa từ "web", chỉ lấy Tên môn và Hệ
	dsMon
		.Where(m => m.TenMon.Contains("web", StringComparison.OrdinalIgnoreCase))
		.Select(m => new { m.TenMon, m.He })
		.Dump("Câu c");

	// d. Hệ "KTV", sắp xếp tăng dần theo Mã môn
	dsMon
		.Where(m => m.He == "KTV")
		.OrderBy(m => m.MaMon)
		.Dump("Câu d");
}

// Lớp môn học
public class MonHoc
{
	public string MaMon { get; set; } = "";
	public string TenMon { get; set; } = "";
	public string He { get; set; } = "";
	public byte SoTiet { get; set; }
}

// Lớp dữ liệu
public class DuLieu
{
	public static List<MonHoc> DS_Mon()
	{
		return new List<MonHoc>
		{
			new MonHoc { MaMon = "HP2_1", TenMon = "Nền tảng C#", He = "KTV", SoTiet = 64 },
			new MonHoc { MaMon = "HP2_2", TenMon = "Công nghệ ADO.NET", He = "KTV", SoTiet = 64 },
			new MonHoc { MaMon = "HP3_1", TenMon = "Lập trình Windows Forms", He = "KTV", SoTiet = 64 },
			new MonHoc { MaMon = "HP3_2", TenMon = "Xây dựng ứng dụng Windows Forms", He = "KTV", SoTiet = 64 },
			new MonHoc { MaMon = "HP4_1", TenMon = "Lập trình Web với HTML, CSS và JavaScript", He = "KTV", SoTiet = 64 },
			new MonHoc { MaMon = "HP4_2", TenMon = "Xây dựng ứng dụng Web với ASP.NET", He = "KTV", SoTiet = 64 },
			new MonHoc { MaMon = "HP5_1", TenMon = "Lập trình CSDL SQL Server căn bản", He = "KTV", SoTiet = 64 },
			new MonHoc { MaMon = "HP5_2", TenMon = "Lập trình CSDL SQL Server nâng cao", He = "KTV", SoTiet = 64 },
			new MonHoc { MaMon = "JLCB", TenMon = "Joomla cơ bản", He = "CD", SoTiet = 72 },
			new MonHoc { MaMon = "LINQ", TenMon = "Language-Integrated Query", He = "CD", SoTiet = 64 },
			new MonHoc { MaMon = "DAWEB", TenMon = "Đồ án thực tế Web với ASP.NET", He = "CD", SoTiet = 40 },
			new MonHoc { MaMon = "DAWIN", TenMon = "Đồ án thực tế Windows Forms", He = "CD", SoTiet = 40 },
			new MonHoc { MaMon = "CC++", TenMon = "Lập trình hướng đối tượng với C/C++", He = "CD", SoTiet = 128 },
			new MonHoc { MaMon = "JQUE", TenMon = "JQuery", He = "CD", SoTiet = 22 },
			new MonHoc { MaMon = "XML", TenMon = "Công nghệ XML", He = "CD", SoTiet = 32 },
			new MonHoc { MaMon = "CRYS", TenMon = "Crystal Report trong Visual Studio", He = "CD", SoTiet = 32 },
			new MonHoc { MaMon = "BWEB", TenMon = "HTML, CSS và JavaScript", He = "CD", SoTiet = 32 },
			new MonHoc { MaMon = "XYZ", TenMon = "Chưa đặt tên môn", He = "", SoTiet = 0 }
		};
	}
}
