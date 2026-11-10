namespace NNLTCSharp.Buoi04
{
    public class TinhChatSo1
    {
        // (a) Đếm số chữ số
        public static int DemSoChuSo(int n)
        {
            if (n < 10)
                return 1;
            else if (n < 100)
                return 2;
            else
                return 3;
        }

        // (b) Tính tổng các chữ số
        public static int TinhTongChuSo(int n)
        {
            int tong = 0;

            while (n > 0)
            {
                tong += n % 10;
                n /= 10;
            }

            return tong;
        }

        // (c) Tìm chữ số cuối
        public static int TimChuSoCuoi(int n)
        {
            return n % 10;
        }

        // (d) Tìm chữ số đầu
        public static int TimChuSoDau(int n)
        {
            while (n >= 10)
            {
                n /= 10;
            }

            return n;
        }
    }
}

