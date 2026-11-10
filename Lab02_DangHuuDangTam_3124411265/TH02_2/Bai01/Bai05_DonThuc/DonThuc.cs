namespace Bai05DonThuc;

public class DonThuc
{
    // Field luu he so a va so mu n cua don thuc ax^n.
    private double heSo;
    private int soMu;

    public double HeSo
    {
        get => heSo;
        set => heSo = value;
    }

    public int SoMu
    {
        get => soMu;
        set
        {
            // Theo de bai, so mu phai la so nguyen khong am.
            if (value < 0)
            {
                throw new ArgumentException(
                    "So mu phai la so nguyen khong am."
                );
            }

            soMu = value;
        }
    }

    // Constructor mac dinh tao don thuc 0.
    public DonThuc()
    {
        heSo = 0;
        soMu = 0;
    }

    // Constructor co tham so.
    public DonThuc(double heSo, int soMu)
    {
        HeSo = heSo;
        SoMu = soMu;
    }

    // Constructor sao chep.
    public DonThuc(DonThuc donThuc)
    {
        ArgumentNullException.ThrowIfNull(donThuc);

        heSo = donThuc.heSo;
        soMu = donThuc.soMu;
    }

    public void Input()
    {
        HeSo = NhapSoThuc("Nhap he so a: ");

        while (true)
        {
            int soMuMoi = NhapSoNguyen("Nhap so mu n: ");

            try
            {
                SoMu = soMuMoi;
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
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
                "Loi: Du lieu phai la mot so thuc."
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

    public double TinhGiaTri(double x)
    {
        // Math.Pow(x, SoMu) tinh x luy thua SoMu.
        return HeSo * Math.Pow(x, SoMu);
    }

    public DonThuc DaoHam()
    {
        // Dao ham cua hang so bang 0.
        if (SoMu == 0)
        {
            return new DonThuc(0, 0);
        }

        // (a*x^n)' = a*n*x^(n-1).
        return new DonThuc(
            HeSo * SoMu,
            SoMu - 1
        );
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        // Neu he so bang 0 thi don thuc bang 0.
        if (HeSo == 0)
        {
            return "0";
        }

        // Neu so mu bang 0 thi don thuc la mot hang so.
        if (SoMu == 0)
        {
            return $"{HeSo:0.##}";
        }

        // Neu so mu bang 1 thi khong can hien thi so mu.
        if (SoMu == 1)
        {
            return $"{HeSo:0.##}x";
        }

        return $"{HeSo:0.##}x^{SoMu}";
    }
}