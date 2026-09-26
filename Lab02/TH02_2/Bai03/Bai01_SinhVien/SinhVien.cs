namespace Bai01ArraySort;

public class SinhVien : IComparable<SinhVien>
{
    private string maSinhVien = string.Empty;
    private string hoTen = string.Empty;
    private double diemTrungBinh;

    public string MaSinhVien
    {
        get => maSinhVien;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Ma sinh vien khong duoc de trong."
                );
            }

            maSinhVien = value.Trim();
        }
    }

    public string HoTen
    {
        get => hoTen;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Ho ten khong duoc de trong."
                );
            }

            hoTen = value.Trim();
        }
    }

    public double DiemTrungBinh
    {
        get => diemTrungBinh;
        set
        {
            // Diem trung binh phai nam trong khoang 0 den 10.
            if (value < 0 || value > 10)
            {
                throw new ArgumentException(
                    "Diem trung binh phai nam trong khoang 0 den 10."
                );
            }

            diemTrungBinh = value;
        }
    }

    // Constructor mac dinh.
    public SinhVien()
    {
        maSinhVien = "Chua xac dinh";
        hoTen = "Chua xac dinh";
        diemTrungBinh = 0;
    }

    // Constructor co tham so.
    public SinhVien(
        string maSinhVien,
        string hoTen,
        double diemTrungBinh
    )
    {
        MaSinhVien = maSinhVien;
        HoTen = hoTen;
        DiemTrungBinh = diemTrungBinh;
    }

    // Constructor sao chep.
    public SinhVien(SinhVien sinhVien)
    {
        ArgumentNullException.ThrowIfNull(sinhVien);

        maSinhVien = sinhVien.maSinhVien;
        hoTen = sinhVien.hoTen;
        diemTrungBinh = sinhVien.diemTrungBinh;
    }

    public int CompareTo(SinhVien? other)
    {
        // Mot doi tuong khac null luon lon hon null.
        if (other is null)
        {
            return 1;
        }

        // Buoc 1: So sanh diem trung binh tang dan.
        int ketQuaDiem =
            DiemTrungBinh.CompareTo(
                other.DiemTrungBinh
            );

        if (ketQuaDiem != 0)
        {
            return ketQuaDiem;
        }

        // Buoc 2: Neu bang diem thi so sanh ho ten.
        int ketQuaHoTen = string.Compare(
            HoTen,
            other.HoTen,
            StringComparison.OrdinalIgnoreCase
        );

        if (ketQuaHoTen != 0)
        {
            return ketQuaHoTen;
        }

        // Buoc 3: Neu tiep tuc trung ho ten
        // thi so sanh ma sinh vien.
        return string.Compare(
            MaSinhVien,
            other.MaSinhVien,
            StringComparison.OrdinalIgnoreCase
        );
    }

    public void Input()
    {
        MaSinhVien = NhapChuoiKhongRong(
            "Nhap ma sinh vien: "
        );

        HoTen = NhapChuoiKhongRong(
            "Nhap ho ten: "
        );

        while (true)
        {
            double diemMoi = NhapSoThuc(
                "Nhap diem trung binh: "
            );

            try
            {
                DiemTrungBinh = diemMoi;
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }
    }

    private static string NhapChuoiKhongRong(
        string thongBao
    )
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(duLieu))
            {
                return duLieu.Trim();
            }

            Console.WriteLine(
                "Loi: Du lieu khong duoc de trong."
            );
        }
    }

    private static double NhapSoThuc(
        string thongBao
    )
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (double.TryParse(
                duLieu,
                out double giaTri
            ))
            {
                return giaTri;
            }

            Console.WriteLine(
                "Loi: Du lieu phai la mot so."
            );
        }
    }

    public override string ToString()
    {
        return
            $"Ma SV: {MaSinhVien,-10} | " +
            $"Ho ten: {HoTen,-25} | " +
            $"Diem TB: {DiemTrungBinh:0.##}";
    }
}