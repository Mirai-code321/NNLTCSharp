namespace NNLTCSharp.Buoi3
{
    public class TienNuoc
    {
        public static double TinhTienNuoc(int chiSoCu, int chiSoMoi, int soNguoi)
        {
            int soMetKhoi = chiSoMoi - chiSoCu;

            int dinhMucDau = 4 * soNguoi;
            int dinhMucTiep = 2 * soNguoi;

            double tienNuoc = 0;

            if (soMetKhoi <= dinhMucDau)
            {
                tienNuoc = soMetKhoi * 4400;
            }
            else if (soMetKhoi <= dinhMucDau + dinhMucTiep)
            {
                tienNuoc = dinhMucDau * 4400
                         + (soMetKhoi - dinhMucDau) * 8300;
            }
            else
            {
                tienNuoc = dinhMucDau * 4400
                         + dinhMucTiep * 8300
                         + (soMetKhoi - dinhMucDau - dinhMucTiep) * 10500;
            }

            double tongTien = tienNuoc * 1.15;

            return tongTien;
        }
    }
}

