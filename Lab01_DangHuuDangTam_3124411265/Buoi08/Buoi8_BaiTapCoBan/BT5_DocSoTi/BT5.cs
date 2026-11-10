namespace NNLTCSharp.Buoi8
{
    public class DocSoTi
    {
        private static string[] ChuSo =
        {
            "khong", "mot", "hai", "ba", "bon",
            "nam", "sau", "bay", "tam", "chin"
        };

        public static string DocBaChuSo(int n)
        {
            int tram = n / 100;
            int chuc = n / 10 % 10;
            int donVi = n % 10;

            string ketQua = "";

            // Hang tram
            if (tram > 0)
            {
                ketQua += ChuSo[tram] + " tram";
            }

            // Hang chuc
            if (chuc > 0)
            {
                if (ketQua != "")
                    ketQua += " ";

                if (chuc == 1)
                    ketQua += "muoi";
                else
                    ketQua += ChuSo[chuc] + " muoi";
            }
            else if (tram > 0 && donVi > 0)
            {
                ketQua += " le";
            }

            // Hang don vi
            if (donVi > 0)
            {
                if (chuc > 1 && donVi == 1)
                    ketQua += " mot";
                else if (chuc > 0 && donVi == 5)
                    ketQua += " lam";
                else
                    ketQua += " " + ChuSo[donVi];
            }

            return ketQua;
        }

        public static string DocSo(long n)
        {
            if (n == 0)
                return "khong";

            long ty = n / 1000000000;
            long trieu = n / 1000000 % 1000;
            long nghin = n / 1000 % 1000;
            long donVi = n % 1000;

            string ketQua = "";

            if (ty > 0)
            {
                ketQua += DocBaChuSo((int)ty) + " ty";
            }

            if (trieu > 0)
            {
                if (ketQua != "")
                    ketQua += " ";

                ketQua += DocBaChuSo((int)trieu) + " trieu";
            }

            if (nghin > 0)
            {
                if (ketQua != "")
                    ketQua += " ";

                ketQua += DocBaChuSo((int)nghin) + " nghin";
            }

            if (donVi > 0)
            {
                if (ketQua != "")
                    ketQua += " ";

                ketQua += DocBaChuSo((int)donVi);
            }

            return ketQua.Trim().Replace("  ", " ");
        }
    }
}