namespace NNLTCSharp.Buoi02
{
    public class KiemTraTronThang
    {
        public static string KiemTra(
            double x,
            double y,
            double r,
            double A,
            double B,
            double C)
        {
            double d = Math.Abs(A * x + B * y + C)
                        / Math.Sqrt(A * A + B * B);

            if (d < r)
            {
                return "Cat";
            }

            if (d == r)
            {
                return "TiepXuc";
            }

            return "KhongCat";
        }
    }
}

