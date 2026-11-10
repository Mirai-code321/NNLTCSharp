namespace Bai05TinhLuongDaHinh;

public abstract class NhanVien
{
    private string maNhanVien = string.Empty;
    private string hoTen = string.Empty;

    public string MaNhanVien
    {
        get => maNhanVien;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "Ma nhan vien khong duoc de trong."
                );
            }

            maNhanVien = value.Trim();
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

    protected NhanVien(
        string maNhanVien,
        string hoTen
    )
    {
        MaNhanVien = maNhanVien;
        HoTen = hoTen;
    }

    // Moi loai nhan vien co cach tinh luong rieng.
    public abstract decimal TinhLuong();

    public abstract string LayTenLoaiNhanVien();

    public override string ToString()
    {
        return
            $"Ma nhan vien: {MaNhanVien}\n" +
            $"Ho ten: {HoTen}\n" +
            $"Loai: {LayTenLoaiNhanVien()}\n" +
            $"Luong: {TinhLuong():N0} VND";
    }
}