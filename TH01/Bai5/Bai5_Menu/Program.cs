using System;

namespace Bai5_Menu
{
    public class Program
    {
        // Nhap 1 so thuc tu ban phim, tu dong bao loi va bat nhap lai
        // neu nguoi dung nhap sai (giong cach lam o bai 4, nhung dung
        // double.TryParse thay vi int.TryParse vi day la so thuc)
        public static double NhapSoThuc(string nhanText)
        {
            while (true)
            {
                Console.Write(nhanText);
                string? chuoiNhap = Console.ReadLine();

                if (double.TryParse(chuoiNhap, out double ketQua))
                {
                    return ketQua; // nhap dung -> tra ve gia tri, thoat ham
                }

                // nhap sai -> bao loi, quay lai dau vong lap de hoi lai
                Console.Write($"Loi: \"{chuoiNhap}\" ");
                Console.WriteLine("khong hop le. Nhap lai!");
            }
        }

        // In menu ra man hinh, dung nhu dinh dang de bai yeu cau
        static void HienThiMenu()
        {
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
            Console.WriteLine("2. Tinh x^y");
            Console.WriteLine("3. Tinh can bac 2 cua x va y");
            Console.WriteLine("4. Thoat");
            Console.Write("Chon chuc nang: ");
        }

        static void Main(string[] args)
        {
            double x = 0, y = 0;

            // Co the ban se thac mac tai sao can bien nay:
            // neu nguoi dung chon 2 hoac 3 truoc khi chon 1,
            // thi x, y van dang la 0 (gia tri mac dinh), chuong trinh
            // se tinh "sai" ma khong bao ai biet. Bien nay dung de
            // nhac nguoi dung phai nhap x, y truoc khi tinh.
            bool daNhap = false;

            while (true) // lap lai menu cho den khi nguoi dung chon 4
            {
                HienThiMenu();
                string? luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1":
                        x = NhapSoThuc("Nhap x: ");
                        y = NhapSoThuc("Nhap y: ");
                        daNhap = true;
                        break;

                    case "2":
                        if (!daNhap)
                        {
                            Console.WriteLine("Ban chua nhap x, y. Vui long chon 1 truoc!");
                            break; // quay lai vong lap, hien menu lai, khong tinh
                        }

                        double ketQuaLuyThua = MathTools.TinhLuyThua(x, y);
                        Console.WriteLine($"Ket qua {x} mu {y} la: {ketQuaLuyThua}");
                        break;

                    case "3":
                        if (!daNhap)
                        {
                            Console.WriteLine("Ban chua nhap x, y. Vui long chon 1 truoc!");
                            break;
                        }

                        // Tinh rieng can bac 2 cua x va cua y
                        double? canX = MathTools.TinhCanBac2(x);
                        double? canY = MathTools.TinhCanBac2(y);

                        // canX == null nghia la x la so am, khong tinh duoc
                        if (canX == null)
                            Console.WriteLine($"Khong tinh duoc can bac 2 cua x = {x} (so am)");
                        else
                            Console.WriteLine($"Can bac 2 cua x = {x} la: {canX}");

                        if (canY == null)
                            Console.WriteLine($"Khong tinh duoc can bac 2 cua y = {y} (so am)");
                        else
                            Console.WriteLine($"Can bac 2 cua y = {y} la: {canY}");
                        break;

                    case "4":
                        Console.WriteLine("Tam biet!");
                        return; // ket thuc Main -> thoat chuong trinh

                    default:
                        // nguoi dung go linh tinh, khong phai 1/2/3/4
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai!");
                        break;
                }
            }
        }
    }
}