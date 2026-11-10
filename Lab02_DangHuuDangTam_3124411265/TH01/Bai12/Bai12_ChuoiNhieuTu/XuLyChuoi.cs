namespace Bai12_ChuoiNhieuTu
{
    public class XuLyChuoi
    {
        // Doi toan bo chuoi sang chu thuong.
        // Dung ToLowerInvariant de ket qua giong nhau tren moi may, khong phu thuoc
        // cai dat ngon ngu/vung cua Windows. Chu co dau tieng Viet van doi dung.
        public string ChuyenSangThuong(string? chuoi)
        {
            // null hoac rong thi tra ve chuoi rong, noi goi khong phai kiem tra null
            if (string.IsNullOrEmpty(chuoi))
                return string.Empty;

            return chuoi.ToLowerInvariant();
        }

        // Doi toan bo chuoi sang chu hoa (cach lam giong ham tren)
        public string ChuyenSangHoa(string? chuoi)
        {
            if (string.IsNullOrEmpty(chuoi))
                return string.Empty;

            return chuoi.ToUpperInvariant();
        }

        // Dem so tu: tu la day ky tu lien nhau, cach nhau boi khoang trang hoac tab.
        // RemoveEmptyEntries de nhieu khoang trang lien tiep, hoac khoang trang o
        // dau/cuoi chuoi, khong bi dem thanh "tu rong".
        public int DemSoTu(string? chuoi)
        {
            // chuoi rong hoac toan khoang trang thi khong co tu nao
            if (string.IsNullOrWhiteSpace(chuoi))
                return 0;

            string[] cacTu = chuoi.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return cacTu.Length;
        }
    }
}