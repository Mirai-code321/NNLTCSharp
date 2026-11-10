namespace Bai07TinhLuong;

public class NhanVien
{
    // So tien bi tru cho moi ngay vang.
    public const decimal TienPhatMoiNgay = 100_000m;

    private string hoTen = string.Empty;
    private decimal mucLuong;
    private int soNgayVang;

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

    public decimal MucLuong
    {
        get => mucLuong;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "Muc luong khong duoc am."
                );
            }

            mucLuong = value;
        }
    }

    public int SoNgayVang
    {
        get => soNgayVang;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException(
                    "So ngay vang khong duoc am."
                );
            }

            soNgayVang = value;
        }
    }

    // Constructor mac dinh.
    public NhanVien()
    {
        hoTen = "Chua xac dinh";
        mucLuong = 0;
        soNgayVang = 0;
    }

    // Constructor co tham so.
    public NhanVien(
        string hoTen,
        decimal mucLuong,
        int soNgayVang
    )
    {
        HoTen = hoTen;
        MucLuong = mucLuong;
        SoNgayVang = soNgayVang;
    }

    // Constructor sao chep.
    public NhanVien(NhanVien nhanVien)
    {
        ArgumentNullException.ThrowIfNull(nhanVien);

        hoTen = nhanVien.hoTen;
        mucLuong = nhanVien.mucLuong;
        soNgayVang = nhanVien.soNgayVang;
    }

    public decimal TinhLuongThucNhan()
    {
        decimal tienBiTru =
            SoNgayVang * TienPhatMoiNgay;

        return MucLuong - tienBiTru;
    }

    public void Input()
    {
        HoTen = NhapChuoiKhongRong(
            "Nhap ho ten: "
        );

        while (true)
        {
            decimal luongMoi = NhapSoThuc(
                "Nhap muc luong: "
            );

            try
            {
                MucLuong = luongMoi;
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }

        while (true)
        {
            int ngayVangMoi = NhapSoNguyen(
                "Nhap so ngay vang: "
            );

            try
            {
                SoNgayVang = ngayVangMoi;
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

    private static decimal NhapSoThuc(
        string thongBao
    )
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (decimal.TryParse(
                duLieu,
                out decimal giaTri
            ))
            {
                return giaTri;
            }

            Console.WriteLine(
                "Loi: Du lieu phai la mot so."
            );
        }
    }

    private static int NhapSoNguyen(
        string thongBao
    )
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (int.TryParse(duLieu, out int giaTri))
            {
                return giaTri;
            }

            Console.WriteLine(
                "Loi: Du lieu phai la mot so nguyen."
            );
        }
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return
            $"Ho ten: {HoTen}\n" +
            $"Muc luong: {MucLuong:N0} VND\n" +
            $"So ngay vang: {SoNgayVang}\n" +
            $"Luong thuc nhan: " +
            $"{TinhLuongThucNhan():N0} VND";
    }
}