namespace Bai07TinhLuong;

public class PhongBan
{
    // Danh sach nhan vien cua phong ban.
    private readonly List<NhanVien> danhSach;

    public int Count => danhSach.Count;

    // Constructor mac dinh.
    public PhongBan()
    {
        danhSach = new List<NhanVien>();
    }

    // Constructor sao chep.
    public PhongBan(PhongBan phongBan)
    {
        ArgumentNullException.ThrowIfNull(phongBan);

        danhSach = new List<NhanVien>();

        foreach (NhanVien nhanVien in phongBan.danhSach)
        {
            danhSach.Add(
                new NhanVien(nhanVien)
            );
        }
    }

    public NhanVien this[int index]
    {
        get
        {
            KiemTraChiSo(index);
            return danhSach[index];
        }

        set
        {
            KiemTraChiSo(index);
            ArgumentNullException.ThrowIfNull(value);

            danhSach[index] = value;
        }
    }

    public void Add(NhanVien nhanVien)
    {
        ArgumentNullException.ThrowIfNull(nhanVien);

        danhSach.Add(nhanVien);
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

        danhSach.Clear();

        for (int i = 0; i < soLuong; i++)
        {
            Console.WriteLine(
                $"\nNhap nhan vien thu {i + 1}:"
            );

            NhanVien nhanVien = new NhanVien();
            nhanVien.Input();

            danhSach.Add(nhanVien);
        }
    }

    private static int NhapSoLuong()
    {
        while (true)
        {
            Console.Write("Nhap so luong nhan vien: ");
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

    public decimal TinhTongLuong()
    {
        decimal tongLuong = 0;

        foreach (NhanVien nhanVien in danhSach)
        {
            tongLuong += nhanVien.TinhLuongThucNhan();
        }

        return tongLuong;
    }

    public void Output()
    {
        if (Count == 0)
        {
            Console.WriteLine(
                "Phong ban chua co nhan vien."
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

            danhSach[i].Output();
        }

        Console.WriteLine(
            $"\nTong luong phong ban: " +
            $"{TinhTongLuong():N0} VND"
        );
    }
}