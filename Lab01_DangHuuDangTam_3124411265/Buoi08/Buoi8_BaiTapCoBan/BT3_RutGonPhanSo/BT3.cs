namespace NNLTCSharp.Buoi8
{
    public class RutGonPhanSo
    {
        public static int TimUCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                int tam = a % b;
                a = b;
                b = tam;
            }

            return a;
        }

        public static string RutGon(int tuSo, int mauSo)
        {
            int ucln = TimUCLN(tuSo, mauSo);

            tuSo /= ucln;
            mauSo /= ucln;

            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }

            return $"{tuSo}/{mauSo}";
        }
    }
}