namespace HamSo1;

public class TinhHamSo
{
    // y1 = 4*(x^2 + 10*x*can(x) + 3x + 1)
    // Luu y: can(x) doi hoi x >= 0, neu x < 0 se bi loi (NaN)
    public static double TinhY1(double x)
    {
        return 4 * (Math.Pow(x, 2) + 10 * x * Math.Sqrt(x) + 3 * x + 1);
    }

    // y2 = [sin(pi*x^2) + can(x^2+1)] / [e^(2x) + cos(pi/4 * x)]
    public static double TinhY2(double x)
    {
        double tuSo = Math.Sin(Math.PI * x * x) + Math.Sqrt(x * x + 1);
        double mauSo = Math.Exp(2 * x) + Math.Cos(Math.PI / 4 * x);
        return tuSo / mauSo;
    }
}

