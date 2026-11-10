namespace NNLTCSharp.Buoi04
{
    public class TinhChatSo
    {
        // Kiểm tra số đối xứng
        public static bool LaSoDoiXung(int n)
        {
            int a = n / 1000;
            int b = n / 100 % 10;
            int c = n / 10 % 10;
            int d = n % 10;

            return a == d && b == c;
        }

        // Kiểm tra có đúng 3 chữ số giống nhau
        public static bool Co3ChuSoGiongNhau(int n)
        {
            int a = n / 1000;
            int b = n / 100 % 10;
            int c = n / 10 % 10;
            int d = n % 10;

            return (a == b && b == c) ||
                   (a == b && b == d) ||
                   (a == c && c == d) ||
                   (b == c && c == d);
        }

        // Kiểm tra 4 chữ số khác nhau
        public static bool Co4ChuSoKhacNhau(int n)
        {
            int a = n / 1000;
            int b = n / 100 % 10;
            int c = n / 10 % 10;
            int d = n % 10;

            return a != b && a != c && a != d &&
                   b != c && b != d &&
                   c != d;
        }
    }
}

