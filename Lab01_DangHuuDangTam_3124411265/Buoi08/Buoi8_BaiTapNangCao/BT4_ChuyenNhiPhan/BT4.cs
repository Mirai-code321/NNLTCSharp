namespace NNLTCSharp.Buoi8
{
    public class ChuyenNhiPhan
    {
        public static string Chuyen(double x)
        {
            bool am = x < 0;

            x = Math.Abs(x);

            // Phan nguyen
            long phanNguyen = (long)x;

            string ketQuaNguyen = "";

            if (phanNguyen == 0)
            {
                ketQuaNguyen = "0";
            }
            else
            {
                while (phanNguyen > 0)
                {
                    long soDu = phanNguyen % 2;

                    ketQuaNguyen = soDu + ketQuaNguyen;

                    phanNguyen /= 2;
                }
            }

            // Phan thap phan
            double phanThapPhan = x - (long)x;

            string ketQuaThapPhan = "";

            for (int i = 0; i < 10; i++)
            {
                phanThapPhan *= 2;

                if (phanThapPhan >= 1)
                {
                    ketQuaThapPhan += "1";
                    phanThapPhan -= 1;
                }
                else
                {
                    ketQuaThapPhan += "0";
                }
            }

            string ketQua;

            if (am)
                ketQua = "-";

            else
                ketQua = "";

            ketQua += ketQuaNguyen + "." + ketQuaThapPhan;

            return ketQua;
        }
    }
}