namespace NNLTCSharp.Buoi02
{
    public class ChuViDaGiacDeu
    {
        public static double TinhChuVi(int n, double R)
        {
            double canh = 2 * R * Math.Sin(Math.PI / n);

            double chuVi = n * canh;

            return chuVi;
        }
    }
}

