namespace NNLTCSharp.Buoi02
{
    public class NamTrong
    {
        public static bool KiemTra(double x, double y)
        {
            if (y >= 0 &&
                y <= 1 &&
                y <= x + 1 &&
                y <= -x + 1)
            {
                return true;
            }

            return false;
        }
    }
}

