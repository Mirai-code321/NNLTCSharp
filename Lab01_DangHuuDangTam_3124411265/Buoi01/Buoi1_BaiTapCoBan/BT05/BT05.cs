namespace NNLTCSharp.Buoi01
{
    public class TamGiac
    {
        public static double TinhDienTich(double a, double b, double c)
        {
            double p = (a + b + c) / 2;

            double dienTich = Math.Sqrt(
                p * (p - a) * (p - b) * (p - c)
            );

            return dienTich;
        }
    }
}
