namespace NNLTCSharp.Buoi8
{
    public class TinhEx
    {
        public static double Tinh(double x, double epsilon)
        {
            double tong = 1;
            double soHang = 1;
            int i = 1;

            while (true)
            {
                soHang = soHang * x / i;

                if (Math.Abs(soHang) <= epsilon)
                    break;

                tong += soHang;
                i++;
            }

            return tong;
        }
    }
}