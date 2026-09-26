using System;

namespace Bai4_NhapSoNguyen
{
    public class Program
    {
        // Ham kiem tra 1 chuoi co phai la so nguyen hop le khong.
        // Tach rieng ra (thay vi viet thang trong NhapSoNguyen) va de public
        // de ben project Bai4_NhapSoNguyenTest co the goi toi va test duoc,
        // vi Console.ReadLine() thi khong the test tu dong.
        public static bool KiemTraSoNguyen(string? chuoiNhap, out int ketQua)
        {
            // int.TryParse tra ve true/false thay vi nem loi (exception)
            // nhu int.Parse, nen khong lam crash chuong trinh khi nhap sai
            return int.TryParse(chuoiNhap, out ketQua);
        }

        // Nhap 1 so nguyen tu ban phim, tu dong bao loi va bat nhap lai
        // neu nguoi dung nhap sai dinh dang (chu, so thap phan, de trong...)
        static int NhapSoNguyen(string nhanText)
        {
            while (true) // lap lai cho den khi nhap dung moi thoat (return/break)
            {
                Console.Write(nhanText);
                string? chuoiNhap = Console.ReadLine();

                if (KiemTraSoNguyen(chuoiNhap, out int ketQua))
                {
                    return ketQua; // nhap dung -> thoat ham, tra ve gia tri
                }

                // nhap sai -> bao loi roi quay lai dau vong lap, hoi lai
                Console.Write($"Loi: \"{chuoiNhap}\" ");
                Console.WriteLine("khong hop le. Nhap lai!");
            }
        }

        static void Main(string[] args)
        {
            int x = NhapSoNguyen("Nhap so nguyen x: ");
            int y = NhapSoNguyen("Nhap so nguyen y: ");

            // Goi sang lop LuyThua de tinh toan, Main chi lo nhap/xuat
            long ketQua = LuyThua.TinhLuyThua(x, y);

            Console.WriteLine($"Ket qua {x} mu {y} la: {ketQua}");
        }
    }
}