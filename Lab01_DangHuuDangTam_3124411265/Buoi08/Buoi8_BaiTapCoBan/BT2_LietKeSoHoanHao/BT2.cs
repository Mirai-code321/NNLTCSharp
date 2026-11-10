namespace NNLTCSharp.Buoi8
{
    public class LietKeSoHoanHao
    {
        public static bool LaSoHoanHao(int n)
        {
            if (n <= 1)
                return false;

            int tong = 0;

            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                    tong += i;
            }

            return tong == n;
        }

        public static List<int> LietKe(int n)
        {
            List<int> ketQua = new List<int>();

            for (int i = n; i >= 1; i--)
            {
                if (LaSoHoanHao(i))
                    ketQua.Add(i);
            }

            return ketQua;
        }
    }
}