namespace Bai04ConsoleMenu;

public class ConsoleMenu
{
    // Dictionary luu ma chuc nang va ten chuc nang.
    private readonly Dictionary<int, string> cacChucNang;

private string tieuDe = string.Empty;
    public string TieuDe
    {
        get => tieuDe;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Tieu de khong duoc de trong."
                );
            }

            tieuDe = value.Trim();
        }
    }

    // Event duoc phat khi nguoi dung chon mot chuc nang.
    public event EventHandler<MenuEventArgs>? Choose;

    public ConsoleMenu(string tieuDe)
    {
        TieuDe = tieuDe;
        cacChucNang = new Dictionary<int, string>();
    }

    protected void ThemChucNang(
        int maChucNang,
        string tenChucNang
    )
    {
        if (maChucNang <= 0)
        {
            throw new ArgumentException(
                "Ma chuc nang phai lon hon 0."
            );
        }

        if (string.IsNullOrWhiteSpace(tenChucNang))
        {
            throw new ArgumentException(
                "Ten chuc nang khong duoc de trong."
            );
        }

        if (cacChucNang.ContainsKey(maChucNang))
        {
            throw new ArgumentException(
                $"Ma chuc nang {maChucNang} da ton tai."
            );
        }

        cacChucNang.Add(
            maChucNang,
            tenChucNang.Trim()
        );
    }

    protected virtual void HienThiMenu()
    {
        Console.WriteLine();
        Console.WriteLine(TieuDe);

        foreach (
            KeyValuePair<int, string> chucNang
            in cacChucNang.OrderBy(x => x.Key)
        )
        {
            Console.WriteLine(
                $"{chucNang.Key}. {chucNang.Value}"
            );
        }

        Console.WriteLine("0. Thoat");
    }

    protected virtual void OnChoose(
        MenuEventArgs e
    )
    {
        // Phat su kien Choose den cac ham da dang ky.
        Choose?.Invoke(this, e);
    }

    public void Run()
    {
        while (true)
        {
            HienThiMenu();

            int luaChon = NhapLuaChon();

            if (luaChon == 0)
            {
                Console.WriteLine(
                    "Chuong trinh da ket thuc."
                );

                break;
            }

            if (!cacChucNang.ContainsKey(luaChon))
            {
                Console.WriteLine(
                    "Loi: Chuc nang khong ton tai."
                );

                continue;
            }

            Console.WriteLine(
                $"Ban thuc hien chuc nang {luaChon}."
            );

            MenuEventArgs e =
                new MenuEventArgs(luaChon);

            OnChoose(e);

            if (!e.DaXuLy)
            {
                Console.WriteLine(
                    "Chuc nang nay chua duoc xu ly."
                );
            }
        }
    }

    private static int NhapLuaChon()
    {
        while (true)
        {
            Console.Write("Thuc hien: ");
            string? duLieu = Console.ReadLine();

            if (int.TryParse(duLieu, out int luaChon))
            {
                return luaChon;
            }

            Console.WriteLine(
                "Loi: Lua chon phai la mot so nguyen."
            );
        }
    }
}