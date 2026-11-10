namespace NNLTCSharp.Buoi3
{
    public class DiemTrungBinh
    {
        public static double TinhDiemTrungBinh(double toan, double ly, double hoa)
        {
            return (toan * 2 + ly * 3 + hoa) / 6;
        }

        public static string XepLoai(double diemTrungBinh)
        {
            if (diemTrungBinh >= 8 && diemTrungBinh <= 10)
                return "Gioi";
            else if (diemTrungBinh >= 6.5)
                return "Kha";
            else if (diemTrungBinh >= 5)
                return "Trung binh";
            else
                return "Yeu";
        }
    }
}

