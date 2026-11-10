namespace NNLTCSharp.Buoi8
{
    public class SapLaiChuSo
    {
        public static long SapXep(int n)
        {
            List<int> chuSo = new List<int>();

            while (n > 0)
            {
                int soCuoi = n % 10;
                chuSo.Add(soCuoi);

                n /= 10;
            }

            chuSo.Sort();
            chuSo.Reverse();

            long ketQua = 0;

            foreach (int so in chuSo)
            {
                ketQua = ketQua * 10 + so;
            }

            return ketQua;
        }
    }
}