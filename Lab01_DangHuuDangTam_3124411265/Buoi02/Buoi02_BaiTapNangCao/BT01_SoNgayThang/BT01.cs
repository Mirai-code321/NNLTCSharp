namespace NNLTCSharp.Buoi02
{
    public class SoNgayThang
    {
        public static int TinhSoNgay(int m, int y)
        {
            if (m == 2)
            {
                if (y % 400 == 0 || (y % 4 == 0 && y % 100 != 0))
                {
                    return 29;
                }
                return 28;
            }

            if (m == 4 || m == 6 || m == 9 || m == 11)
            {
                return 30;
            }
            return 31;
        }
    }
}

