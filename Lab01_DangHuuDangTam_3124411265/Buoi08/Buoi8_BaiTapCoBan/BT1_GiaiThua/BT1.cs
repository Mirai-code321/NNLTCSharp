namespace NNLTCSharp.Buoi8
{
    public class GiaiThua
    {
        public static long TinhGiaiThua(int n)
        {
            long ketQua = 1;

            for (int i = 1; i <= n; i++)
            {
                ketQua *= i;
            }

            return ketQua;
        }

        public static long TinhToHop(int n, int k)
        {
            long nGiaiThua = TinhGiaiThua(n);
            long kGiaiThua = TinhGiaiThua(k);
            long nkGiaiThua = TinhGiaiThua(n - k);

            return nGiaiThua / (kGiaiThua * nkGiaiThua);
        }
    }
}