namespace Bai04MangHaiChieu;

public class MangHaiChieu
{
    // Field luu du lieu cua mang hai chieu.
    private int[,] duLieu;

    // GetLength(0) tra ve so dong.
    public int SoDong => duLieu.GetLength(0);

    // GetLength(1) tra ve so cot.
    public int SoCot => duLieu.GetLength(1);

    // Constructor mac dinh tao mang rong 0 x 0.
    public MangHaiChieu()
    {
        duLieu = new int[0, 0];
    }

    // Constructor tao mang co so dong va so cot cho truoc.
    public MangHaiChieu(int soDong, int soCot)
    {
        if (soDong < 0)
        {
            throw new ArgumentException(
                "So dong khong duoc am."
            );
        }

        if (soCot < 0)
        {
            throw new ArgumentException(
                "So cot khong duoc am."
            );
        }

        duLieu = new int[soDong, soCot];
    }

    // Constructor nhan mot mang hai chieu co san.
    public MangHaiChieu(int[,] mang)
    {
        ArgumentNullException.ThrowIfNull(mang);

        int soDong = mang.GetLength(0);
        int soCot = mang.GetLength(1);

        duLieu = new int[soDong, soCot];

        // Sao chep tung phan tu sang mang moi.
        for (int i = 0; i < soDong; i++)
        {
            for (int j = 0; j < soCot; j++)
            {
                duLieu[i, j] = mang[i, j];
            }
        }
    }

    // Constructor sao chep.
    public MangHaiChieu(MangHaiChieu mang)
    {
        ArgumentNullException.ThrowIfNull(mang);

        duLieu = new int[mang.SoDong, mang.SoCot];

        // Tao ban sao doc lap cua mang.
        for (int i = 0; i < mang.SoDong; i++)
        {
            for (int j = 0; j < mang.SoCot; j++)
            {
                duLieu[i, j] = mang[i, j];
            }
        }
    }

    // Indexer truy cap phan tu tai dong i va cot j.
    public int this[int i, int j]
    {
        get
        {
            KiemTraChiSo(i, j);
            return duLieu[i, j];
        }

        set
        {
            KiemTraChiSo(i, j);
            duLieu[i, j] = value;
        }
    }

    private void KiemTraChiSo(int i, int j)
    {
        if (i < 0 || i >= SoDong)
        {
            throw new IndexOutOfRangeException(
                $"Chi so dong {i} khong hop le."
            );
        }

        if (j < 0 || j >= SoCot)
        {
            throw new IndexOutOfRangeException(
                $"Chi so cot {j} khong hop le."
            );
        }
    }

    public void Input()
    {
        int soDong = NhapKichThuoc("Nhap so dong: ");
        int soCot = NhapKichThuoc("Nhap so cot: ");

        // Tao mang moi theo kich thuoc vua nhap.
        duLieu = new int[soDong, soCot];

        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                duLieu[i, j] = NhapSoNguyen(
                    $"Nhap phan tu [{i}, {j}]: "
                );
            }
        }
    }

    private static int NhapKichThuoc(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieuNhap = Console.ReadLine();

            if (int.TryParse(duLieuNhap, out int giaTri) &&
                giaTri >= 0)
            {
                return giaTri;
            }

            Console.WriteLine(
                "Loi: Kich thuoc phai la so nguyen khong am."
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
        if (SoDong == 0 || SoCot == 0)
        {
            Console.WriteLine("Mang hai chieu dang rong.");
            return;
        }

        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                // Can phai moi phan tu trong 6 ky tu
                // de ket qua hien thi thang hang.
                Console.Write($"{duLieu[i, j],6}");
            }

            Console.WriteLine();
        }
    }

    public static bool LaSoNguyenTo(int n)
    {
        // Cac so nho hon 2 khong phai so nguyen to.
        if (n < 2)
        {
            return false;
        }

        // Chi can thu cac uoc tu 2 den can bac hai cua n.
        // Dung i <= n / i de tranh tran so cua i * i.
        for (int i = 2; i <= n / i; i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public List<int> TimSoNguyenTo()
    {
        List<int> cacSoNguyenTo = new List<int>();

        for (int i = 0; i < SoDong; i++)
        {
            for (int j = 0; j < SoCot; j++)
            {
                if (LaSoNguyenTo(duLieu[i, j]))
                {
                    cacSoNguyenTo.Add(duLieu[i, j]);
                }
            }
        }

        return cacSoNguyenTo;
    }
}