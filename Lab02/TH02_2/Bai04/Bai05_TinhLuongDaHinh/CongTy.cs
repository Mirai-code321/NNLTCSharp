namespace Bai05TinhLuongDaHinh;

public class CongTy
{
    // Danh sach lop cha co the luu moi lop con NhanVien.
    private readonly List<NhanVien> danhSach;

    public int Count => danhSach.Count;

    public CongTy()
    {
        danhSach = new List<NhanVien>();
    }

    public NhanVien this[int index]
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

    public void Add(NhanVien nhanVien)
    {
        ArgumentNullException.ThrowIfNull(nhanVien);

        danhSach.Add(nhanVien);
    }

    public decimal TinhTongLuong()
    {
        decimal tongLuong = 0;

        foreach (NhanVien nhanVien in danhSach)
        {
            // Da hinh:
            // TinhLuong cua dung lop con se duoc goi.
            tongLuong += nhanVien.TinhLuong();
        }

        return tongLuong;
    }

    public void Output()
    {
        if (Count == 0)
        {
            Console.WriteLine(
                "Cong ty chua co nhan vien."
            );

            return;
        }

        Console.WriteLine(
            $"DANH SACH GOM {Count} NHAN VIEN"
        );

        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(
                $"\nNhan vien thu {i + 1}:"
            );

            Console.WriteLine(
                danhSach[i]
            );
        }

        Console.WriteLine(
            $"\nTong luong cong ty: " +
            $"{TinhTongLuong():N0} VND"
        );
    }
}