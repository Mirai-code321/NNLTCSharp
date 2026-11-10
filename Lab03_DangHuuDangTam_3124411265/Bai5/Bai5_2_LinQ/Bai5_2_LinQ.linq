<Query Kind="Program" />

void Main()
{
	var dsMon = DuLieu.DS_Mon();

	// a. Tổng số môn hiện có
	dsMon.Count().Dump("Câu a");

	// b. Đếm số môn có tên bắt đầu bằng "Lập trình"
	dsMon.Count(m => m.TenMon.StartsWith("Lập trình")).Dump("Câu b");

	// c. Tổng số tiết của hệ KTV
	dsMon.Where(m => m.He == "KTV").Sum(m => m.SoTiet).Dump("Câu c");

	// d. Tổng số môn của mỗi hệ
	dsMon.GroupBy(m => m.He)
		.Select(g => new { He = g.Key, TongSoMon = g.Count() })
		.Dump("Câu d");

	// e. Nhóm theo Số tiết; in Số tiết và Tổng số môn, giảm dần theo Số tiết
	dsMon.GroupBy(m => m.SoTiet)
		.OrderByDescending(g => g.Key)
		.Select(g => new { SoTiet = g.Key, TongSoMon = g.Count() })
		.Dump("Câu e");

	// f. Môn học có số tiết cao nhất
	var maxTiet = dsMon.Max(m => m.SoTiet);
	dsMon.Where(m => m.SoTiet == maxTiet).Dump("Câu f");

	// g. Thống kê theo Hệ
	dsMon.GroupBy(m => m.He)
		.Select(g => new
		{
			He = g.Key,
			TongSoMon = g.Count(),
			TongSoTiet = g.Sum(m => (int)m.SoTiet),
			CaoNhat = g.Max(m => m.SoTiet),
			ThapNhat = g.Min(m => m.SoTiet)
		})
		.Dump("Câu g");

	// h. Các môn học phân nhóm theo Hệ
	dsMon.GroupBy(m => m.He).Dump("Câu h");

	// i. Các môn học phân nhóm theo Số tiết, tăng dần theo Số tiết
	dsMon.GroupBy(m => m.SoTiet).OrderBy(g => g.Key).Dump("Câu i");

	// j. Hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5; sắp xếp theo Mã môn
	dsMon.Where(m => m.He == "KTV")
		.GroupBy(m => m.MaMon.Substring(0, 3))
		.OrderBy(g => g.Key)
		.Select(g => new { HocPhan = g.Key, DS = g.OrderBy(m => m.MaMon) })
		.Dump("Câu j");

	// k. Phân nhóm theo Hệ, chỉ lấy môn có Số tiết > 40; mỗi nhóm sắp xếp theo Mã môn
	dsMon.Where(m => m.SoTiet > 40)
		.GroupBy(m => m.He)
		.Select(g => new { He = g.Key, DS = g.OrderBy(m => m.MaMon) })
		.Dump("Câu k");
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
