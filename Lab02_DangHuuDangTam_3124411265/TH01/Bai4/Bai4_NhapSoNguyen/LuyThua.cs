namespace Bai4_NhapSoNguyen
{
    public class LuyThua
    {
        // Tinh x^y bang vong lap nhan don (khong dung Math.Pow vi ham do
        // tra ve kieu double, de bi sai so khi ep ve so nguyen)
        // Luu y: de bai chi xet y khong am, khong xu ly y < 0
        // Dung kieu long cho ket qua de tranh tran so khi y lon
        public static long TinhLuyThua(long x, int y)
        {
            long ketQua = 1;

            for (int i = 0; i < y; i++)
            {
                ketQua *= x; // nhan don ket qua voi x, lap dung y lan
            }

            return ketQua;
        }
    }
}