namespace Bai05TinhLuongDaHinh;

public class NhanVienSanXuat : NhanVien
{
    public const decimal TienMoiSanPham =
        1_000m;

    public const int MocThuong =
        3_000;

    public const decimal TyLeThuong =
        0.05m;

    private int soSanPham;

    public int SoSanPham
    {
        get => soSanPham;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "So san pham khong duoc am."
                );
            }

            soSanPham = value;
        }
    }

    public NhanVienSanXuat(
        string maNhanVien,
        string hoTen,
        int soSanPham
    )
        : base(maNhanVien, hoTen)
    {
        SoSanPham = soSanPham;
    }

    public override decimal TinhLuong()
    {
        decimal luong =
            SoSanPham * TienMoiSanPham;

        // Chi thuong neu so san pham lon hon 3000.
        if (SoSanPham > MocThuong)
        {
            luong += luong * TyLeThuong;
        }

        return luong;
    }

    public override string LayTenLoaiNhanVien()
    {
        return "Nhan vien san xuat";
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}\n" +
            $"So san pham: {SoSanPham}";
    }
}