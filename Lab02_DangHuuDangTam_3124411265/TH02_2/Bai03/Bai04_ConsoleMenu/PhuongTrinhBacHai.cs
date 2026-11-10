namespace Bai04ConsoleMenu;

public class PhuongTrinhBacHai
{
    // Sai so dung de so sanh so thuc voi 0.
    private const double Epsilon = 1e-10;

    public double A { get; set; }

    public double B { get; set; }

    public double C { get; set; }

    public PhuongTrinhBacHai()
    {
        A = 0;
        B = 0;
        C = 0;
    }

    public PhuongTrinhBacHai(
        double a,
        double b,
        double c
    )
    {
        A = a;
        B = b;
        C = c;
    }

    public KetQuaPhuongTrinh Giai()
    {
        // Neu A bang 0 thi phuong trinh tro thanh bac nhat.
        if (GanBangKhong(A))
        {
            return GiaiPhuongTrinhBacNhat();
        }

        double delta =
            B * B - 4 * A * C;

        if (delta < -Epsilon)
        {
            return new KetQuaPhuongTrinh(
                LoaiNghiem.VoNghiem
            );
        }

        if (GanBangKhong(delta))
        {
            double x = -B / (2 * A);

            return new KetQuaPhuongTrinh(
                LoaiNghiem.NghiemKep,
                x,
                x
            );
        }

        double canDelta = Math.Sqrt(delta);

        double x1 =
            (-B + canDelta) / (2 * A);

        double x2 =
            (-B - canDelta) / (2 * A);

        return new KetQuaPhuongTrinh(
            LoaiNghiem.HaiNghiemPhanBiet,
            x1,
            x2
        );
    }

    private KetQuaPhuongTrinh GiaiPhuongTrinhBacNhat()
    {
        // 0x + 0 = 0.
        if (GanBangKhong(B) &&
            GanBangKhong(C))
        {
            return new KetQuaPhuongTrinh(
                LoaiNghiem.VoSoNghiem
            );
        }

        // 0x + c = 0 voi c khac 0.
        if (GanBangKhong(B))
        {
            return new KetQuaPhuongTrinh(
                LoaiNghiem.VoNghiem
            );
        }

        // bx + c = 0.
        double x = -C / B;

        return new KetQuaPhuongTrinh(
            LoaiNghiem.MotNghiem,
            x
        );
    }

    private static bool GanBangKhong(
        double giaTri
    )
    {
        return Math.Abs(giaTri) < Epsilon;
    }

    public override string ToString()
    {
        return
            $"{A:0.##}x^2 + " +
            $"{B:0.##}x + " +
            $"{C:0.##} = 0";
    }
}