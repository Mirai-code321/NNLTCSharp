namespace Bai04ConsoleMenu;

public class KetQuaPhuongTrinh
{
    public LoaiNghiem LoaiNghiem { get; }

    public double? X1 { get; }

    public double? X2 { get; }

    public KetQuaPhuongTrinh(
        LoaiNghiem loaiNghiem,
        double? x1 = null,
        double? x2 = null
    )
    {
        LoaiNghiem = loaiNghiem;
        X1 = x1;
        X2 = x2;
    }

    public override string ToString()
    {
        return LoaiNghiem switch
        {
            LoaiNghiem.VoNghiem =>
                "Phuong trinh vo nghiem.",

            LoaiNghiem.VoSoNghiem =>
                "Phuong trinh co vo so nghiem.",

            LoaiNghiem.MotNghiem =>
                $"Phuong trinh co mot nghiem x = {X1:0.##}.",

            LoaiNghiem.NghiemKep =>
                $"Phuong trinh co nghiem kep x = {X1:0.##}.",

            LoaiNghiem.HaiNghiemPhanBiet =>
                $"Phuong trinh co hai nghiem " +
                $"x1 = {X1:0.##}, x2 = {X2:0.##}.",

            _ => "Ket qua khong xac dinh."
        };
    }
}