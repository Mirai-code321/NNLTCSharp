namespace NNLTCSharp.Buoi01
{
    public class ThoiGian
    {
        public static string DoiThoiGian(long tongGiay)
        {
            long gio = tongGiay / 3600;

            long phut = (tongGiay % 3600) / 60;

            long giay = tongGiay % 60;

            return $"{gio}:{phut}:{giay}";
        }
    }
}
