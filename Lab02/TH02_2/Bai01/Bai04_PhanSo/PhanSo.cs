namespace Bai04PhanSo;

public class PhanSo
{
    // Field luu tu so va mau so cua phan so.
    private long tuSo;
    private long mauSo;

    // Chi cho phep doc du lieu tu ben ngoai.
    // Moi gia tri deu duoc kiem tra va rut gon trong constructor.
    public long TuSo => tuSo;
    public long MauSo => mauSo;

    // Constructor mac dinh tao phan so 0/1.
    public PhanSo()
    {
        tuSo = 0;
        mauSo = 1;
    }

    // Constructor tao phan so tu mot so nguyen.
    // Vi du: new PhanSo(5) tao phan so 5/1.
    public PhanSo(long tuSo)
    {
        this.tuSo = tuSo;
        mauSo = 1;
    }

    // Constructor co hai tham so.
    public PhanSo(long tuSo, long mauSo)
    {
        if (mauSo == 0)
        {
            throw new ArgumentException(
                "Mau so phai khac 0."
            );
        }

        this.tuSo = tuSo;
        this.mauSo = mauSo;

        ChuanHoa();
    }

    // Constructor sao chep.
    public PhanSo(PhanSo phanSo)
    {
        ArgumentNullException.ThrowIfNull(phanSo);

        tuSo = phanSo.tuSo;
        mauSo = phanSo.mauSo;
    }

    // Tim uoc chung lon nhat bang thuat toan Euclid.
    private static long UocChungLonNhat(long a, long b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        while (b != 0)
        {
            long soDu = a % b;
            a = b;
            b = soDu;
        }

        return a;
    }

    private void ChuanHoa()
    {
        // Neu tu so bang 0 thi phan so duoc chuan hoa thanh 0/1.
        if (tuSo == 0)
        {
            mauSo = 1;
            return;
        }

        // Dua dau am len tu so.
        if (mauSo < 0)
        {
            tuSo = -tuSo;
            mauSo = -mauSo;
        }

        // Rut gon phan so bang uoc chung lon nhat.
        long ucln = UocChungLonNhat(tuSo, mauSo);

        tuSo /= ucln;
        mauSo /= ucln;
    }

    public void Input()
    {
        long tuMoi = NhapSoNguyen("Nhap tu so: ");
        long mauMoi;

        while (true)
        {
            mauMoi = NhapSoNguyen("Nhap mau so: ");

            if (mauMoi != 0)
            {
                break;
            }

            Console.WriteLine(
                "Loi: Mau so phai khac 0."
            );
        }

        tuSo = tuMoi;
        mauSo = mauMoi;

        ChuanHoa();
    }

    private static long NhapSoNguyen(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (long.TryParse(duLieu, out long giaTri))
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
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        // Neu mau so bang 1 thi chi can xuat tu so.
        if (MauSo == 1)
        {
            return TuSo.ToString();
        }

        return $"{TuSo}/{MauSo}";
    }

    // Toan tu duong mot ngoi tra ve mot ban sao cua phan so.
    public static PhanSo operator +(PhanSo a)
    {
        ArgumentNullException.ThrowIfNull(a);

        return new PhanSo(a);
    }

    // Toan tu am mot ngoi doi dau tu so.
    public static PhanSo operator -(PhanSo a)
    {
        ArgumentNullException.ThrowIfNull(a);

        return new PhanSo(-a.TuSo, a.MauSo);
    }

    // Cong hai phan so.
    public static PhanSo operator +(PhanSo a, PhanSo b)
    {
        KiemTraHaiPhanSo(a, b);

        long tuMoi = checked(
            a.TuSo * b.MauSo +
            b.TuSo * a.MauSo
        );

        long mauMoi = checked(
            a.MauSo * b.MauSo
        );

        return new PhanSo(tuMoi, mauMoi);
    }

    // Tru hai phan so.
    public static PhanSo operator -(PhanSo a, PhanSo b)
    {
        KiemTraHaiPhanSo(a, b);

        long tuMoi = checked(
            a.TuSo * b.MauSo -
            b.TuSo * a.MauSo
        );

        long mauMoi = checked(
            a.MauSo * b.MauSo
        );

        return new PhanSo(tuMoi, mauMoi);
    }

    // Nhan hai phan so.
    public static PhanSo operator *(PhanSo a, PhanSo b)
    {
        KiemTraHaiPhanSo(a, b);

        long tuMoi = checked(a.TuSo * b.TuSo);
        long mauMoi = checked(a.MauSo * b.MauSo);

        return new PhanSo(tuMoi, mauMoi);
    }

    // Chia hai phan so.
    public static PhanSo operator /(PhanSo a, PhanSo b)
    {
        KiemTraHaiPhanSo(a, b);

        if (b.TuSo == 0)
        {
            throw new DivideByZeroException(
                "Khong the chia cho phan so bang 0."
            );
        }

        long tuMoi = checked(a.TuSo * b.MauSo);
        long mauMoi = checked(a.MauSo * b.TuSo);

        return new PhanSo(tuMoi, mauMoi);
    }

    public static bool operator >(PhanSo a, PhanSo b)
    {
        KiemTraHaiPhanSo(a, b);

        return SoSanh(a, b) > 0;
    }

    public static bool operator <(PhanSo a, PhanSo b)
    {
        KiemTraHaiPhanSo(a, b);

        return SoSanh(a, b) < 0;
    }

    public static bool operator >=(PhanSo a, PhanSo b)
    {
        KiemTraHaiPhanSo(a, b);

        return SoSanh(a, b) >= 0;
    }

    public static bool operator <=(PhanSo a, PhanSo b)
    {
        KiemTraHaiPhanSo(a, b);

        return SoSanh(a, b) <= 0;
    }

    public static bool operator ==(PhanSo? a, PhanSo? b)
    {
        // Neu hai bien cung tro den mot doi tuong hoac cung null.
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        // Neu chi co mot doi tuong null.
        if (a is null || b is null)
        {
            return false;
        }

        // Phan so da duoc rut gon nen chi can so sanh tu va mau.
        return a.TuSo == b.TuSo &&
               a.MauSo == b.MauSo;
    }

    public static bool operator !=(PhanSo? a, PhanSo? b)
    {
        return !(a == b);
    }

    private static int SoSanh(PhanSo a, PhanSo b)
    {
        // Dung decimal de giam nguy co tran so khi nhan cheo.
        decimal veTrai =
            (decimal)a.TuSo * b.MauSo;

        decimal vePhai =
            (decimal)b.TuSo * a.MauSo;

        return veTrai.CompareTo(vePhai);
    }

    private static void KiemTraHaiPhanSo(
        PhanSo? a,
        PhanSo? b
    )
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);
    }

    public override bool Equals(object? obj)
    {
        return obj is PhanSo phanSo &&
               this == phanSo;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(TuSo, MauSo);
    }
}