namespace Bai05TinhLuongDaHinh;

public class NhanVienKinhDoanh : NhanVien
{
    // Tien hoa hong tren moi hop dong.
    public const decimal HoaHongMoiHopDong =
        500_000m;

    private decimal luongCoBan;
    private int soHopDong;

    public decimal LuongCoBan
    {
        get => luongCoBan;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Luong co ban khong duoc am."
                );
            }

            luongCoBan = value;
        }
    }

    public int SoHopDong
    {
        get => soHopDong;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "So hop dong khong duoc am."
                );
            }

            soHopDong = value;
        }
    }

    public NhanVienKinhDoanh(
        string maNhanVien,
        string hoTen,
        decimal luongCoBan,
        int soHopDong
    )
        : base(maNhanVien, hoTen)
    {
        LuongCoBan = luongCoBan;
        SoHopDong = soHopDong;
    }

    public override decimal TinhLuong()
    {
        // Luong bang luong co ban cong hoa hong hop dong.
        return LuongCoBan +
               SoHopDong * HoaHongMoiHopDong;
    }

    public override string LayTenLoaiNhanVien()
    {
        return "Nhan vien kinh doanh";
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}\n" +
            $"Luong co ban: {LuongCoBan:N0} VND\n" +
            $"So hop dong: {SoHopDong}";
    }
}