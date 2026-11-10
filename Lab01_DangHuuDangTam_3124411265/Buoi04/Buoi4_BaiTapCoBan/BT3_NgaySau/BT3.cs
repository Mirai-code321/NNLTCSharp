namespace NNLTCSharp.Buoi3
{
    public class NgaySauDo
    {
        public static string TinhNgaySau(int ngay, int thang, int nam)
        {
            int soNgayTrongThang;

            // Xác định số ngày của tháng
            if (thang == 2)
            {
                if (nam % 400 == 0 || (nam % 4 == 0 && nam % 100 != 0))
                    soNgayTrongThang = 29;
                else
                    soNgayTrongThang = 28;
            }
            else if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
            {
                soNgayTrongThang = 30;
            }
            else
            {
                soNgayTrongThang = 31;
            }

            // Nếu chưa phải ngày cuối tháng
            if (ngay < soNgayTrongThang)
            {
                ngay++;
            }
            else
            {
                ngay = 1;

                // Nếu chưa phải tháng 12
                if (thang < 12)
                {
                    thang++;
                }
                else
                {
                    thang = 1;
                    nam++;
                }
            }

            return $"{ngay}/{thang}/{nam}";
        }
    }
}

