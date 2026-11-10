namespace Bai06TinhDiemThiSinh;

public class ThiSinhSieuCup : ThiSinh
{
    private double csdl;

    public double CSDL
    {
        get => csdl;
        set
        {
            KiemTraDiem(value);
            csdl = value;
        }
    }

    public ThiSinhSieuCup()
        : base()
    {
        csdl = 0;
    }

    public ThiSinhSieuCup(
        string soBaoDanh,
        string hoTen,
        double bai1,
        double bai2,
        double bai3,
        double csdl
    )
        : base(
            soBaoDanh,
            hoTen,
            bai1,
            bai2,
            bai3
        )
    {
        CSDL = csdl;
    }

    public override double TinhTongDiem()
    {
        // Thi sinh Sieu cup cong diem cua ca bon bai.
        return Bai1 +
               Bai2 +
               Bai3 +
               CSDL;
    }

    public override string LayLoaiThiSinh()
    {
        return "Thi sinh Sieu cup";
    }

    public override void Input()
    {
        base.Input();

        CSDL = NhapDiem(
            "Nhap diem CSDL: "
        );
    }

    public override string ToString()
    {
        return
            $"{base.ToString()}\n" +
            $"CSDL: {CSDL:0.##}";
    }
}