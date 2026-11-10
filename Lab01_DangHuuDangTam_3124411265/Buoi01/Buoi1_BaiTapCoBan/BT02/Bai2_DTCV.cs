namespace NNLTCShrap.Buoi01
{
    public class HinhTron
    {
        private const double PI = 3.14;
        public double BanKinh { get; set; }

        public HinhTron(double banKinh)
        {
            BanKinh = banKinh;
        }
        public double TinhDienTich()
        {
            return Math.Round(PI * BanKinh * BanKinh, 1);
        }
        public double TinhChuVi()
        {
            return Math.Round(PI * 2 * BanKinh, 1);
        }
    }
}
