namespace Bai3_InLich
{
    public class InLich
    {
        // Kiểm tra năm nhuận
        public bool LaNamNhuan(int nam)
        {
            return nam % 400 == 0 ||
                   (nam % 4 == 0 && nam % 100 != 0);
        }

        // Tính số ngày trong tháng
        public int SoNgayTrongThang(int nam, int thang)
        {
            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;

                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;

                case 2:
                    return LaNamNhuan(nam) ? 29 : 28;

                default:
                    return 0;
            }
        }

        // Tính thứ của ngày bằng công thức Zeller
        // 0 = Chủ nhật, 1 = Thứ hai, ..., 6 = Thứ bảy
        public int ThuTrongTuan(int ngay, int thang, int nam)
        {
            int a = (14 - thang) / 12;
            int y = nam - a;
            int m = thang + 12 * a - 2;

            int dayOfWeek =
                (ngay + y + y / 4 - y / 100 + y / 400
                + (31 * m) / 12) % 7;

            return dayOfWeek;
        }

        // Hiển thị lịch của tháng
        public void HienThiLich(int nam, int thang)
        {
            int soNgay = SoNgayTrongThang(nam, thang);

            // Tính thứ của ngày 1
            int thuNgayDauTien = ThuTrongTuan(1, thang, nam);

            Console.WriteLine("CN T2 T3 T4 T5 T6 T7");

            // Chừa khoảng trống trước ngày 1
            for (int i = 0; i < thuNgayDauTien; i++)
            {
                Console.Write("   ");
            }

            // In các ngày trong tháng
            for (int ngay = 1; ngay <= soNgay; ngay++)
            {
                Console.Write($"{ngay,2} ");

                // Đủ 7 ngày thì xuống dòng
                if ((thuNgayDauTien + ngay) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }
    }
}