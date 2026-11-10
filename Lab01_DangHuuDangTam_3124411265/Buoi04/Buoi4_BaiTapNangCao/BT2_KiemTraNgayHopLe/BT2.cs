namespace NNLTCSharp.Buoi04
{
    public class KiemTraNgayHopLe
    {
        public static bool KiemTra(int d, int m, int y)
        {
            // Kiểm tra tháng
            if (m < 1 || m > 12)
                return false;

            // Kiểm tra năm
            if (y < 1)
                return false;

            int soNgayTrongThang;

            if (m == 2)
            {
                // Năm nhuận
                if (y % 400 == 0 || (y % 4 == 0 && y % 100 != 0))
                    soNgayTrongThang = 29;
                else
                    soNgayTrongThang = 28;
            }
            else if (m == 4 || m == 6 || m == 9 || m == 11)
            {
                soNgayTrongThang = 30;
            }
            else
            {
                soNgayTrongThang = 31;
            }

            // Kiểm tra ngày
            if (d >= 1 && d <= soNgayTrongThang)
                return true;

            return false;
        }
    }
}

