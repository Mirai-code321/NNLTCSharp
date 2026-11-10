namespace NNLTCSharp.Buoi8
{
    public class ViTriChuSo
    {
        public static int TimChuSo(long k)
        {
            long soLuong = 9;
            long doDai = 1;
            long batDau = 1;

            while (k > soLuong * doDai)
            {
                k -= soLuong * doDai;

                doDai++;
                soLuong *= 10;
                batDau *= 10;
            }

            long viTriSo = (k - 1) / doDai;
            long viTriChuSo = (k - 1) % doDai;

            long soCanTim = batDau + viTriSo;

            string chuoi = soCanTim.ToString();

            return chuoi[(int)viTriChuSo] - '0';
        }
    }
}