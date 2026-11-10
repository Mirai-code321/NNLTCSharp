namespace Bai06TinhDiemThiSinh;

public class CuocThi
{
    // Danh sach lop cha co the luu ca hai loai thi sinh.
    private readonly List<ThiSinh> danhSach;

    public int Count => danhSach.Count;

    public CuocThi()
    {
        danhSach = new List<ThiSinh>();
    }

    public ThiSinh this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(
                    $"Chi so {index} khong hop le."
                );
            }

            return danhSach[index];
        }
    }

    public void Add(ThiSinh thiSinh)
    {
        ArgumentNullException.ThrowIfNull(thiSinh);

        danhSach.Add(thiSinh);
    }

    public void Input()
    {
        int soLuong = NhapSoLuong();

        danhSach.Clear();

        for (int i = 0; i < soLuong; i++)
        {
            Console.WriteLine(
                $"\nNhap thi sinh thu {i + 1}:"
            );

            int loai = NhapLoaiThiSinh();

            ThiSinh thiSinh;

            if (loai == 1)
            {
                thiSinh = new ThiSinhChuyen();
            }
            else
            {
                thiSinh = new ThiSinhSieuCup();
            }

            // Da hinh: goi Input cua dung lop con.
            thiSinh.Input();

            danhSach.Add(thiSinh);
        }
    }

    private static int NhapSoLuong()
    {
        while (true)
        {
            Console.Write("Nhap so luong thi sinh: ");
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

    private static int NhapLoaiThiSinh()
    {
        while (true)
        {
            Console.WriteLine(
                "1. Thi sinh Chuyen"
            );

            Console.WriteLine(
                "2. Thi sinh Sieu cup"
            );

            Console.Write("Chon loai thi sinh: ");
            string? duLieu = Console.ReadLine();

            if (int.TryParse(duLieu, out int loai) &&
                (loai == 1 || loai == 2))
            {
                return loai;
            }

            Console.WriteLine(
                "Loi: Chi duoc chon 1 hoac 2."
            );
        }
    }

    public void Output()
    {
        if (Count == 0)
        {
            Console.WriteLine(
                "Cuoc thi chua co thi sinh."
            );

            return;
        }

        Console.WriteLine(
            $"DANH SACH GOM {Count} THI SINH"
        );

        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(
                $"\nThi sinh thu {i + 1}:"
            );

            // Da hinh: goi ToString cua dung lop con.
            Console.WriteLine(
                danhSach[i]
            );
        }
    }
}