namespace NNLTCSharp.Buoi8
{
    public class DemChuSo
    {
        public static int DemSoLanXuatHien(int n, int chuSo)
        {
            int dem = 0;

            while (n > 0)
            {
                int soCuoi = n % 10;

                if (soCuoi == chuSo)
                    dem++;

                n /= 10;
            }

            return dem;
        }
    }
}