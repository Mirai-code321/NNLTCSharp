namespace Bai01ArraySort;

public static class QuanLySinhVien
{
    public static SinhVien[] NhapDanhSach()
    {
        int soLuong = NhapSoLuong();

        SinhVien[] danhSach =
            new SinhVien[soLuong];

        for (int i = 0; i < soLuong; i++)
        {
            Console.WriteLine(
                $"\nNhap sinh vien thu {i + 1}:"
            );

            SinhVien sinhVien = new SinhVien();
            sinhVien.Input();

            danhSach[i] = sinhVien;
        }

        return danhSach;
    }

    private static int NhapSoLuong()
    {
        while (true)
        {
            Console.Write("Nhap so luong sinh vien: ");
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

    public static void SapXep(SinhVien[] danhSach)
    {
        ArgumentNullException.ThrowIfNull(danhSach);

        // Array.Sort se goi CompareTo cua lop SinhVien.
        Array.Sort(danhSach);
    }

    public static void XuatDanhSach(
        SinhVien[] danhSach
    )
    {
        ArgumentNullException.ThrowIfNull(danhSach);

        if (danhSach.Length == 0)
        {
            Console.WriteLine(
                "Danh sach sinh vien dang rong."
            );

            return;
        }

        for (int i = 0; i < danhSach.Length; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {danhSach[i]}"
            );
        }
    }
}