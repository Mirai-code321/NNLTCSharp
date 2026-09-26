namespace Bai03DaySoNguyen;

public class DaySoNguyen
{
    // Mang dung de luu cac so nguyen.
    private int[] duLieu;

    // Tra ve so phan tu cua day.
    public int Count => duLieu.Length;

    // Constructor mac dinh tao mot day rong.
    public DaySoNguyen()
    {
        duLieu = Array.Empty<int>();
    }

    // Constructor tao day gom n phan tu.
    // Cac phan tu ban dau deu bang 0.
    public DaySoNguyen(int soLuong)
    {
        if (soLuong < 0)
        {
            throw new ArgumentException(
                "So luong phan tu khong duoc am."
            );
        }

        duLieu = new int[soLuong];
    }

    // Constructor nhan mot mang co san.
    public DaySoNguyen(int[] mang)
    {
        ArgumentNullException.ThrowIfNull(mang);

        // ToArray tao ban sao cua mang dau vao.
        // Doi tuong khong dung chung mang voi ben ngoai.
        duLieu = mang.ToArray();
    }

    // Constructor sao chep.
    public DaySoNguyen(DaySoNguyen daySo)
    {
        ArgumentNullException.ThrowIfNull(daySo);

        // Tao ban sao doc lap cua mang.
        duLieu = daySo.duLieu.ToArray();
    }

    // Indexer cho phep truy cap bang cu phap daySo[index].
    public int this[int index]
    {
        get
        {
            KiemTraChiSo(index);
            return duLieu[index];
        }

        set
        {
            KiemTraChiSo(index);
            duLieu[index] = value;
        }
    }

    private void KiemTraChiSo(int index)
    {
        // Chi so hop le nam trong khoang 0 den Count - 1.
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

        // Tao mang moi theo so luong vua nhap.
        duLieu = new int[soLuong];

        for (int i = 0; i < Count; i++)
        {
            duLieu[i] = NhapSoNguyen(
                $"Nhap phan tu [{i}]: "
            );
        }
    }

    private static int NhapSoLuong()
    {
        while (true)
        {
            Console.Write("Nhap so luong phan tu: ");
            string? duLieuNhap = Console.ReadLine();

            if (int.TryParse(duLieuNhap, out int soLuong) &&
                soLuong >= 0)
            {
                return soLuong;
            }

            Console.WriteLine(
                "Loi: So luong phai la so nguyen khong am."
            );
        }
    }

    private static int NhapSoNguyen(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieuNhap = Console.ReadLine();

            if (int.TryParse(duLieuNhap, out int giaTri))
            {
                return giaTri;
            }

            Console.WriteLine(
                "Loi: Du lieu phai la mot so nguyen."
            );
        }
    }

    public void Output()
    {
        if (Count == 0)
        {
            Console.WriteLine("Day so dang rong.");
            return;
        }

        Console.WriteLine(ToString());
    }

    public DaySoNguyen TimSoChan()
    {
        // Dung List de luu tam cac so chan
        // vi chua biet truoc co bao nhieu so chan.
        List<int> cacSoChan = new List<int>();

        foreach (int so in duLieu)
        {
            if (so % 2 == 0)
            {
                cacSoChan.Add(so);
            }
        }

        // Chuyen List thanh mang va tao doi tuong ket qua.
        return new DaySoNguyen(cacSoChan.ToArray());
    }

    public override string ToString()
    {
        if (Count == 0)
        {
            return "Day rong";
        }

        return string.Join(" ", duLieu);
    }
}