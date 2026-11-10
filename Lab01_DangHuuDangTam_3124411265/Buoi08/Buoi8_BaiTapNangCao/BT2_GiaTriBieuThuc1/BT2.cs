namespace NNLTCSharp.Buoi8
{
    public class GiaTriBieuThuc1
    {
        public static double TinhF(double x)
        {
            return (x * x + 1) * Math.Pow(Math.Cos(x), 2);
        }

        public static double TinhG(double a, double x, int n)
        {
            double tong = 0;

            for (int i = 0; i <= n; i++)
            {
                double giaTri = a + i * x;

                tong += TinhF(giaTri);
            }

            return tong;
        }
    }
}