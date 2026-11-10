namespace TinhCan;

public class TinhCanBacN
{
    // Can bac n cua a = a^(1/n)
    // Luu y: neu a < 0 va n chan, ket qua se la NaN (khong co can thuc trong so thuc)
    public static double TinhCan(double a, int n)
    {
        return Math.Pow(a, 1.0 / n);
    }
}

