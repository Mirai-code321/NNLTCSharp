namespace NNLTCSharp.Buoi04
{
    public class GiaTriHamSoDoThi
    {
        public static double TinhGiaTri(double a)
        {
            if (a <= 1)
                return 1.5 * a - 0.5;
            else
                return -3 * a + 4;
        }
    }
}

