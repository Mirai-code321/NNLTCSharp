namespace NNLTCSharp.Buoi04
{
    public class PhuongTrinhBac3
    {
        public static string Giai(double a, double b, double c, double d)
        {
            double p = (3 * a * c - b * b) / (3 * a * a);

            double q = (2 * b * b * b
                      - 9 * a * b * c
                      + 27 * a * a * d)
                      / (27 * a * a * a);

            double delta = -4 * p * p * p - 27 * q * q;

            double epsilon = 0.000001;

            // x = t - b / (3a)
            double dichuyen = -b / (3 * a);

            // Có 3 nghiệm thực phân biệt
            if (delta > epsilon)
            {
                double r = 2 * Math.Sqrt(-p / 3);

                double cosValue =
                    (3 * q / (2 * p))
                    * Math.Sqrt(-3 / p);

                if (cosValue > 1)
                    cosValue = 1;

                if (cosValue < -1)
                    cosValue = -1;

                double theta = Math.Acos(cosValue);

                double t1 = r * Math.Cos(theta / 3);
                double t2 = r * Math.Cos((theta + 2 * Math.PI) / 3);
                double t3 = r * Math.Cos((theta + 4 * Math.PI) / 3);

                double x1 = t1 + dichuyen;
                double x2 = t2 + dichuyen;
                double x3 = t3 + dichuyen;

                return $"x1 = {x1:F2}, x2 = {x2:F2}, x3 = {x3:F2}";
            }

            // Có nghiệm kép
            if (Math.Abs(delta) <= epsilon)
            {
                if (Math.Abs(p) <= epsilon && Math.Abs(q) <= epsilon)
                {
                    double xKep = dichuyen;

                    return $"Phuong trinh co nghiem kep x = {xKep:F2}.";
                }

                double t1 = 3 * q / p;
                double t2 = -3 * q / (2 * p);

                double x1 = t1 + dichuyen;
                double x2 = t2 + dichuyen;

                return $"x1 = {x1:F2}, x2 = {x2:F2} (x2 la nghiem kep)";
            }

            // Có 1 nghiệm thực
            double A = -q / 2 + Math.Sqrt(-delta / 108);
            double B = -q / 2 - Math.Sqrt(-delta / 108);

            double u = Math.Cbrt(A);
            double v = Math.Cbrt(B);

            double t = u + v;

            double x = t + dichuyen;

            return $"Phuong trinh co 1 nghiem thuc: x = {x:F2}";
        }
    }
}

