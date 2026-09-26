namespace Bai02InterfaceSort;

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
            if (value < 0 || value > 10)
            {
                throw new ArgumentException(
                    "Diem trung binh phai nam trong khoang 0 den 10."
                );
            }

            diemTrungBinh = value;
        }
    }

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

    public int CompareTo(SinhVien? other)
    {
        if (other is null)
        {
            return 1;
        }

        // So sanh diem trung binh tang dan.
        int ketQuaDiem =
            DiemTrungBinh.CompareTo(
                other.DiemTrungBinh
            );

        if (ketQuaDiem != 0)
        {
            return ketQuaDiem;
        }

        // Neu bang diem thi so sanh ho ten.
        int ketQuaTen = string.Compare(
            HoTen,
            other.HoTen,
            StringComparison.OrdinalIgnoreCase
        );

        if (ketQuaTen != 0)
        {
            return ketQuaTen;
        }

        // Neu tiep tuc trung ten thi so sanh ma.
        return string.Compare(
            MaSinhVien,
            other.MaSinhVien,
            StringComparison.OrdinalIgnoreCase
        );
    }

    public override string ToString()
    {
        return
            $"Ma SV: {MaSinhVien,-10} | " +
            $"Ho ten: {HoTen,-25} | " +
            $"Diem TB: {DiemTrungBinh:0.##}";
    }
}