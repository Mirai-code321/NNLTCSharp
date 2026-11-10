namespace Bai04ConsoleMenu;

public class PTBac2Console : ConsoleMenu
{
    private PhuongTrinhBacHai phuongTrinh;

    public PTBac2Console()
        : base("MENU GIAI PHUONG TRINH BAC HAI")
    {
        phuongTrinh = new PhuongTrinhBacHai();

        // Them cac chuc nang vao menu ke thua.
        ThemChucNang(
            1,
            "Nhap phuong trinh"
        );

        ThemChucNang(
            2,
            "Giai phuong trinh"
        );

        ThemChucNang(
            3,
            "Xuat phuong trinh"
        );

        // Dang ky ham xu ly cho event Choose.
        Choose += XuLyLuaChon;
    }

    private void XuLyLuaChon(
        object? sender,
        MenuEventArgs e
    )
    {
        switch (e.LuaChon)
        {
            case 1:
                NhapPhuongTrinh();
                e.DaXuLy = true;
                break;

            case 2:
                GiaiPhuongTrinh();
                e.DaXuLy = true;
                break;

            case 3:
                XuatPhuongTrinh();
                e.DaXuLy = true;
                break;
        }
    }

    private void NhapPhuongTrinh()
    {
        Console.WriteLine(
            "Nhap phuong trinh ax^2 + bx + c = 0"
        );

        double a = NhapSoThuc("Nhap a: ");
        double b = NhapSoThuc("Nhap b: ");
        double c = NhapSoThuc("Nhap c: ");

        phuongTrinh =
            new PhuongTrinhBacHai(a, b, c);

        Console.WriteLine(
            "Da nhap phuong trinh thanh cong."
        );
    }

    private void GiaiPhuongTrinh()
    {
        Console.WriteLine(
            $"Phuong trinh: {phuongTrinh}"
        );

        KetQuaPhuongTrinh ketQua =
            phuongTrinh.Giai();

        Console.WriteLine(ketQua);
    }

    private void XuatPhuongTrinh()
    {
        Console.WriteLine(
            $"Phuong trinh hien tai: {phuongTrinh}"
        );
    }

    private static double NhapSoThuc(
        string thongBao
    )
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            if (double.TryParse(
                duLieu,
                out double giaTri
            ))
            {
                return giaTri;
            }

            Console.WriteLine(
                "Loi: Du lieu phai la mot so."
            );
        }
    }
}