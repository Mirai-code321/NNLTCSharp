<Query Kind="Program" />

void Main()
{
	var dsHe = DuLieu.DS_He();
	dsHe.Dump("Danh sách hệ");
}

// Lớp hệ đào tạo
public class He
{
	public string MaHe { get; set; } = "";
	public string TenHe { get; set; } = "";
}

// Lớp môn học (Bài 4.1)
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

	public static List<He> DS_He()
	{
		return new List<He>
		{
			new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
			new He { MaHe = "CD", TenHe = "Chuyên đề" },
			new He { MaHe = "QT", TenHe = "Chứng chỉ quốc tế" }
		};
	}
}
