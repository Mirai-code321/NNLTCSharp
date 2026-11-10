namespace NNLTCSharp.Buoi3
{
    public class LoaiTamGiac
    {
        public static string KiemTraTamGiac(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 ||
                a + b <= c ||
                a + c <= b ||
                b + c <= a)
            {
                return "Khong phai tam giac";
            }

            double epsilon = 0.000001;

            bool laTamGiacVuong =
                Math.Abs(a * a + b * b - c * c) < epsilon ||
                Math.Abs(a * a + c * c - b * b) < epsilon ||
                Math.Abs(b * b + c * c - a * a) < epsilon;

            bool laTamGiacCan =
                Math.Abs(a - b) < epsilon ||
                Math.Abs(a - c) < epsilon ||
                Math.Abs(b - c) < epsilon;

            // Tam giác đều
            if (laTamGiacCan &&
                Math.Abs(a - b) < epsilon &&
                Math.Abs(b - c) < epsilon)
            {
                return "Tam giac deu";
            }

            // Tam giác vuông cân
            if (laTamGiacVuong && laTamGiacCan)
            {
                return "Tam giac vuong can";
            }

            // Tam giác vuông
            if (laTamGiacVuong)
            {
                return "Tam giac vuong";
            }

            // Tam giác cân
            if (laTamGiacCan)
            {
                return "Tam giac can";
            }

            return "Tam giac thuong";
        }
    }
}

