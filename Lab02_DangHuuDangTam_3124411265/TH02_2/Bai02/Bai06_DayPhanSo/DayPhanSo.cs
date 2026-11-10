using Bai04PhanSo;

namespace Bai06DayPhanSo;

public class DayPhanSo
{
    // Danh sach dung de luu cac phan so.
    private readonly List<PhanSo> cacPhanSo;

    // Tra ve so luong phan so trong day.
    public int Count => cacPhanSo.Count;

    // Constructor mac dinh tao day rong.
    public DayPhanSo()
    {
        cacPhanSo = new List<PhanSo>();
    }

    // Constructor tao day gom n phan so.
    // Moi phan so ban dau bang 0/1.
    public DayPhanSo(int soLuong)
    {
        if (soLuong < 0)
        {
            throw new ArgumentException(
                "So luong phan so khong duoc am."
            );
        }

        cacPhanSo = new List<PhanSo>();

        for (int i = 0; i < soLuong; i++)
        {
            cacPhanSo.Add(
                new PhanSo()
            );
        }
    }

    // Constructor nhan mot mang phan so co san.
    public DayPhanSo(PhanSo[] mangPhanSo)
    {
        ArgumentNullException.ThrowIfNull(mangPhanSo);

        cacPhanSo = new List<PhanSo>();

        // Tao ban sao cho tung phan so.
        foreach (PhanSo phanSo in mangPhanSo)
        {
            ArgumentNullException.ThrowIfNull(phanSo);

            cacPhanSo.Add(
                new PhanSo(phanSo)
            );
        }
    }

    // Constructor sao chep.
    public DayPhanSo(DayPhanSo dayPhanSo)
    {
        ArgumentNullException.ThrowIfNull(dayPhanSo);

        cacPhanSo = new List<PhanSo>();

        // Tao ban sao doc lap cho tung phan so.
        foreach (PhanSo phanSo in dayPhanSo.cacPhanSo)
        {
            cacPhanSo.Add(
                new PhanSo(phanSo)
            );
        }
    }

    // Indexer truy cap phan so tai vi tri index.
    public PhanSo this[int index]
    {
        get
        {
            KiemTraChiSo(index);
            return cacPhanSo[index];
        }

        set
        {
            KiemTraChiSo(index);
            ArgumentNullException.ThrowIfNull(value);

            // Tao ban sao de tranh dung chung doi tuong.
            cacPhanSo[index] = new PhanSo(value);
        }
    }

    public void Add(PhanSo phanSo)
    {
        ArgumentNullException.ThrowIfNull(phanSo);

        // Tao ban sao cua phan so duoc them.
        cacPhanSo.Add(
            new PhanSo(phanSo)
        );
    }

    private void KiemTraChiSo(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException(
                $"Chi so {index} khong hop le."
            );
        }
    }

    public void Input()
    {
        int soLuong = NhapSoLuong();

        // Xoa du lieu cu truoc khi nhap day moi.
        cacPhanSo.Clear();

        for (int i = 0; i < soLuong; i++)
        {
            Console.WriteLine(
                $"\nNhap phan so thu {i + 1}:"
            );

            PhanSo phanSo = new PhanSo();
            phanSo.Input();

            cacPhanSo.Add(phanSo);
        }
    }

    private static int NhapSoLuong()
    {
        while (true)
        {
            Console.Write("Nhap so luong phan so: ");
            string? duLieu = Console.ReadLine();

            if (int.TryParse(duLieu, out int soLuong) &&
                soLuong >= 0)
            {
                return soLuong;
            }

            Console.WriteLine(
                "Loi: So luong phai la so nguyen khong am."
            );
        }
    }

    public PhanSo TinhTong()
    {
        // Tong ban dau bang 0/1.
        PhanSo tong = new PhanSo(0, 1);

        foreach (PhanSo phanSo in cacPhanSo)
        {
            tong = tong + phanSo;
        }

        return tong;
    }

    public void Output()
    {
        if (Count == 0)
        {
            Console.WriteLine("Day phan so dang rong.");
            return;
        }

        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        if (Count == 0)
        {
            return "Day rong";
        }

        return string.Join(
            " ",
            cacPhanSo
        );
    }
}