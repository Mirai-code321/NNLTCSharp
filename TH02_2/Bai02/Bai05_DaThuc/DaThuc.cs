using Bai05DonThuc;

namespace Bai05DaThuc;

public class DaThuc
{
    // Danh sach gom n + 1 don thuc.
    // Vi tri i luu don thuc co so mu i.
    private readonly List<DonThuc> cacDonThuc;

    // Bac cua da thuc.
    // Da thuc rong co bac bang -1.
    public int Bac => cacDonThuc.Count - 1;

    // So luong don thuc trong da thuc.
    public int Count => cacDonThuc.Count;

    // Constructor mac dinh tao da thuc rong.
    public DaThuc()
    {
        cacDonThuc = new List<DonThuc>();
    }

    // Constructor tao da thuc bac n.
    // Ban dau moi he so deu bang 0.
    public DaThuc(int bac)
    {
        if (bac < 0)
        {
            throw new ArgumentException(
                "Bac cua da thuc phai la so nguyen khong am."
            );
        }

        cacDonThuc = new List<DonThuc>();

        for (int i = 0; i <= bac; i++)
        {
            cacDonThuc.Add(
                new DonThuc(0, i)
            );
        }
    }

    // Constructor tao da thuc tu mang he so.
    // Phan tu tai vi tri i la he so cua x^i.
    public DaThuc(double[] cacHeSo)
    {
        ArgumentNullException.ThrowIfNull(cacHeSo);

        if (cacHeSo.Length == 0)
        {
            throw new ArgumentException(
                "Mang he so phai co it nhat mot phan tu."
            );
        }

        cacDonThuc = new List<DonThuc>();

        for (int i = 0; i < cacHeSo.Length; i++)
        {
            cacDonThuc.Add(
                new DonThuc(cacHeSo[i], i)
            );
        }
    }

    // Constructor sao chep.
    public DaThuc(DaThuc daThuc)
    {
        ArgumentNullException.ThrowIfNull(daThuc);

        cacDonThuc = new List<DonThuc>();

        // Tao ban sao cho tung don thuc.
        foreach (DonThuc donThuc in daThuc.cacDonThuc)
        {
            cacDonThuc.Add(
                new DonThuc(donThuc)
            );
        }
    }

    // Indexer truy cap don thuc thu i.
    public DonThuc this[int index]
    {
        get
        {
            KiemTraChiSo(index);

            return cacDonThuc[index];
        }

        set
        {
            KiemTraChiSo(index);
            ArgumentNullException.ThrowIfNull(value);

            // Don thuc tai vi tri index phai co so mu bang index.
            cacDonThuc[index] = new DonThuc(
                value.HeSo,
                index
            );
        }
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
        int bac = NhapBac();

        // Xoa du lieu cu truoc khi nhap da thuc moi.
        cacDonThuc.Clear();

        for (int i = 0; i <= bac; i++)
        {
            double heSo = NhapSoThuc(
                $"Nhap he so a{i} cua x^{i}: "
            );

            cacDonThuc.Add(
                new DonThuc(heSo, i)
            );
        }
    }

    private static int NhapBac()
    {
        while (true)
        {
            Console.Write("Nhap bac cua da thuc: ");
            string? duLieu = Console.ReadLine();

            if (int.TryParse(duLieu, out int bac) &&
                bac >= 0)
            {
                return bac;
            }

            Console.WriteLine(
                "Loi: Bac phai la so nguyen khong am."
            );
        }
    }

    private static double NhapSoThuc(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (double.TryParse(duLieu, out double giaTri))
            {
                return giaTri;
            }

            Console.WriteLine(
                "Loi: He so phai la mot so thuc."
            );
        }
    }

    public double TinhGiaTri(double x)
    {
        double tong = 0;

        // Gia tri da thuc bang tong gia tri cac don thuc.
        foreach (DonThuc donThuc in cacDonThuc)
        {
            tong += donThuc.TinhGiaTri(x);
        }

        return tong;
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        if (Count == 0)
        {
            return "0";
        }

        string ketQua = string.Empty;

        // Xuat tu bac cao xuong bac thap.
        for (int i = Bac; i >= 0; i--)
        {
            double heSo = cacDonThuc[i].HeSo;

            // Khong hien thi don thuc co he so bang 0.
            if (heSo == 0)
            {
                continue;
            }

            double triTuyetDoi = Math.Abs(heSo);
            string noiDungDonThuc;

            if (i == 0)
            {
                noiDungDonThuc =
                    $"{triTuyetDoi:0.##}";
            }
            else if (i == 1)
            {
                noiDungDonThuc = triTuyetDoi == 1
                    ? "x"
                    : $"{triTuyetDoi:0.##}x";
            }
            else
            {
                noiDungDonThuc = triTuyetDoi == 1
                    ? $"x^{i}"
                    : $"{triTuyetDoi:0.##}x^{i}";
            }

            if (string.IsNullOrEmpty(ketQua))
            {
                // Don thuc dau tien khong can dau cong.
                ketQua = heSo < 0
                    ? $"-{noiDungDonThuc}"
                    : noiDungDonThuc;
            }
            else
            {
                // Cac don thuc sau them dau cong hoac tru.
                ketQua += heSo < 0
                    ? $" - {noiDungDonThuc}"
                    : $" + {noiDungDonThuc}";
            }
        }

        // Tat ca he so deu bang 0.
        return string.IsNullOrEmpty(ketQua)
            ? "0"
            : ketQua;
    }
}