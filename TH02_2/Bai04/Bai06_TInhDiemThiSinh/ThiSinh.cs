namespace Bai06TinhDiemThiSinh;

public abstract class ThiSinh
{
    private string soBaoDanh = string.Empty;
    private string hoTen = string.Empty;
    private double bai1;
    private double bai2;
    private double bai3;

    public string SoBaoDanh
    {
        get => soBaoDanh;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "So bao danh khong duoc de trong."
                );
            }

            soBaoDanh = value.Trim();
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

    public double Bai1
    {
        get => bai1;
        set
        {
            KiemTraDiem(value);
            bai1 = value;
        }
    }

    public double Bai2
    {
        get => bai2;
        set
        {
            KiemTraDiem(value);
            bai2 = value;
        }
    }

    public double Bai3
    {
        get => bai3;
        set
        {
            KiemTraDiem(value);
            bai3 = value;
        }
    }

    // Tong diem duoc tinh tu lop con.
    public double TongDiem => TinhTongDiem();

    protected ThiSinh()
    {
        soBaoDanh = "Chua xac dinh";
        hoTen = "Chua xac dinh";
        bai1 = 0;
        bai2 = 0;
        bai3 = 0;
    }

    protected ThiSinh(
        string soBaoDanh,
        string hoTen,
        double bai1,
        double bai2,
        double bai3
    )
    {
        SoBaoDanh = soBaoDanh;
        HoTen = hoTen;
        Bai1 = bai1;
        Bai2 = bai2;
        Bai3 = bai3;
    }

    protected static void KiemTraDiem(
        double diem
    )
    {
        if (diem < 0 || diem > 10)
        {
            throw new ArgumentException(
                "Diem phai nam trong khoang 0 den 10."
            );
        }
    }

    public virtual void Input()
    {
        SoBaoDanh = NhapChuoiKhongRong(
            "Nhap so bao danh: "
        );

        HoTen = NhapChuoiKhongRong(
            "Nhap ho ten: "
        );

        Bai1 = NhapDiem("Nhap diem bai 1: ");
        Bai2 = NhapDiem("Nhap diem bai 2: ");
        Bai3 = NhapDiem("Nhap diem bai 3: ");
    }

    protected static string NhapChuoiKhongRong(
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

    protected static double NhapDiem(
        string thongBao
    )
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (!double.TryParse(
                duLieu,
                out double diem
            ))
            {
                Console.WriteLine(
                    "Loi: Diem phai la mot so."
                );

                continue;
            }

            if (diem < 0 || diem > 10)
            {
                Console.WriteLine(
                    "Loi: Diem phai nam trong khoang 0 den 10."
                );

                continue;
            }

            return diem;
        }
    }

    public abstract double TinhTongDiem();

    public abstract string LayLoaiThiSinh();

    public override string ToString()
    {
        return
            $"So bao danh: {SoBaoDanh}\n" +
            $"Ho ten: {HoTen}\n" +
            $"Loai thi sinh: {LayLoaiThiSinh()}\n" +
            $"Bai 1: {Bai1:0.##}\n" +
            $"Bai 2: {Bai2:0.##}\n" +
            $"Bai 3: {Bai3:0.##}\n" +
            $"Tong diem: {TongDiem:0.##}";
    }
}