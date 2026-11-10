namespace NNLTCSharp.Buoi04
{
    public class HePhuongTrinh
    {
        public static string GiaiHe(double a, double b, double c,
                                    double d, double e, double f)
        {
            double D = a * e - b * d;
            double Dx = c * e - b * f;
            double Dy = a * f - c * d;

            if (D != 0)
            {
                double x = Dx / D;
                double y = Dy / D;

                return $"x = {x:F2}, y = {y:F2}";
            }

            if (Dx == 0 && Dy == 0)
                return "He phuong trinh co vo so nghiem.";

            return "He phuong trinh vo nghiem.";
        }
    }
}

