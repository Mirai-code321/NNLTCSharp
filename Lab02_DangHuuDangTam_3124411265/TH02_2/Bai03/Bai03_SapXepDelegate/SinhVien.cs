namespace Bai03DelegateSort;

public class SinhVien
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

    public override string ToString()
    {
        return
            $"Ma SV: {MaSinhVien,-10} | " +
            $"Ho ten: {HoTen,-25} | " +
            $"Diem TB: {DiemTrungBinh:0.##}";
    }
}