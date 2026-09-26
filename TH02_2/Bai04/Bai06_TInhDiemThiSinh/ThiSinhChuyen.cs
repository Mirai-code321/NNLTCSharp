namespace Bai06TinhDiemThiSinh;

public class ThiSinhChuyen : ThiSinh
{
    private double tiengAnh;

    public double TiengAnh
    {
        get => tiengAnh;
        set
        {
            KiemTraDiem(value);
            tiengAnh = value;
        }
    }

    public ThiSinhChuyen()
        : base()
    {
        tiengAnh = 0;
    }

    public ThiSinhChuyen(
        string soBaoDanh,
        string hoTen,
        double bai1,
        double bai2,
        double bai3,
        double tiengAnh
    )
        : base(
            soBaoDanh,
            hoTen,
            bai1,
            bai2,
            bai3
        )
    {
        TiengAnh = tiengAnh;
    }

    public double TinhDiemThuong()
    {
        // Tu 7 den 8 duoc thuong 1 diem.
        if (TiengAnh >= 7 &&
            TiengAnh <= 8)
        {
            return 1;
        }

        // Tu 9 den 10 duoc thuong 2 diem.
        if (TiengAnh >= 9 &&
            TiengAnh <= 10)
        {
            return 2;
        }

        return 0;
    }

    public override double TinhTongDiem()
    {
        return Bai1 +
               Bai2 +
               Bai3 +
               TinhDiemThuong();
    }

    public override string LayLoaiThiSinh()
    {
        return "Thi sinh Chuyen";
    }

    public override void Input()
    {
        base.Input();

        TiengAnh = NhapDiem(
            "Nhap diem tieng Anh: "
        );
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}\n" +
            $"Tieng Anh: {TiengAnh:0.##}\n" +
            $"Diem thuong: {TinhDiemThuong():0.##}";
    }
}