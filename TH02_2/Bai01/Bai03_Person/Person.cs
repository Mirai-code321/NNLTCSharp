namespace Bai03Person;

public class Person
{
    // Field luu thong tin cua mot nguoi.
    private string id = string.Empty;
    private string name = string.Empty;
    private int yob;
    private int yod;

    public string Id
    {
        get => id;
        set
        {
            // Id khong duoc null, rong hoac chi co khoang trang.
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Id khong duoc de trong."
                );
            }

            id = value.Trim();
        }
    }

    public string Name
    {
        get => name;
        set
        {
            // Ho ten khong duoc null, rong
            // hoac chi co khoang trang.
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Ho ten khong duoc de trong."
                );
            }

            name = value.Trim();
        }
    }

    public int Yob
    {
        get => yob;
        set
        {
            int namHienTai = DateTime.Now.Year;

            // Nam sinh phai duong va
            // khong duoc lon hon nam hien tai.
            if (value <= 0 || value > namHienTai)
            {
                throw new ArgumentException(
                    $"Nam sinh phai nam trong khoang 1 den {namHienTai}."
                );
            }

            // Neu da co nam mat thi nam sinh
            // khong duoc lon hon nam mat.
            if (yod != 0 && value > yod)
            {
                throw new ArgumentException(
                    "Nam sinh khong duoc lon hon nam mat."
                );
            }

            yob = value;
        }
    }

    public int Yod
    {
        get => yod;
        set
        {
            int namHienTai = DateTime.Now.Year;

            // Gia tri 0 co nghia la nguoi nay con song.
            if (value == 0)
            {
                yod = 0;
                return;
            }

            // Nam mat phai nam trong khoang hop le.
            if (value < yob || value > namHienTai)
            {
                throw new ArgumentException(
                    $"Nam mat phai tu nam sinh den {namHienTai}, " +
                    "hoac bang 0 neu nguoi nay con song."
                );
            }

            yod = value;
        }
    }

    // Constructor mac dinh tao mot doi tuong hop le.
    public Person()
    {
        id = "Chua xac dinh";
        name = "Chua xac dinh";
        yob = DateTime.Now.Year;
        yod = 0;
    }

    // Constructor co tham so.
    public Person(
        string id,
        string name,
        int yob,
        int yod
    )
    {
        // Gan nam sinh truoc vi viec kiem tra
        // nam mat phu thuoc vao nam sinh.
        Id = id;
        Name = name;
        Yob = yob;
        Yod = yod;
    }

    // Constructor sao chep.
    public Person(Person person)
    {
        ArgumentNullException.ThrowIfNull(person);

        id = person.id;
        name = person.name;
        yob = person.yob;
        yod = person.yod;
    }

    public void Input()
    {
        Id = NhapChuoiKhongRong("Nhap id: ");
        Name = NhapChuoiKhongRong("Nhap ho ten: ");

        while (true)
        {
            int namSinhMoi = NhapSoNguyen("Nhap nam sinh: ");

            try
            {
                Yob = namSinhMoi;
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }

        while (true)
        {
            int namMatMoi = NhapSoNguyen(
                "Nhap nam mat, nhap 0 neu con song: "
            );

            try
            {
                Yod = namMatMoi;
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }
    }

    private static string NhapChuoiKhongRong(
        string thongBao
    )
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(duLieu))
            {
                return duLieu.Trim();
            }

            Console.WriteLine(
                "Loi: Du lieu khong duoc de trong."
            );
        }
    }

    private static int NhapSoNguyen(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (int.TryParse(duLieu, out int giaTri))
            {
                return giaTri;
            }

            Console.WriteLine(
                "Loi: Du lieu phai la mot so nguyen."
            );
        }
    }

    public bool IsLiving()
    {
        // Theo quy uoc cua de:
        // yod bang 0 co nghia la nguoi nay con song.
        return Yod == 0;
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        string trangThai = IsLiving()
            ? "Con song"
            : $"Da mat nam {Yod}";

        return
            $"Id: {Id}\n" +
            $"Ho ten: {Name}\n" +
            $"Nam sinh: {Yob}\n" +
            $"Trang thai: {trangThai}";
    }
}