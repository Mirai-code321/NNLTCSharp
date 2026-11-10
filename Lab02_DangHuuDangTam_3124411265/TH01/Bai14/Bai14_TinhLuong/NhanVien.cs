using System.Globalization;

namespace Bai14_TinhLuong
{
    public class NhanVien
    {
        // Moi ngay vang bi tru 100.000 VND
        public const long TienTruMotNgayVang = 100000;

        // Mot thang nhieu nhat co 31 ngay nen khong the vang qua so nay
        public const int SoNgayVangToiDa = 31;

        // Viet tien theo kieu Viet Nam (10.000.000) nen dung dau cham ngan cach hang nghin.
        // Tu tao NumberFormatInfo rieng de ket qua khong phu thuoc cai dat ngon ngu cua may.
        private static readonly NumberFormatInfo dinhDangSo = new NumberFormatInfo { NumberGroupSeparator = "." };

        public string HoTen { get; }

        // Tien VND khong co phan le nen dung long, khong can decimal/double.
        // long cung du rong cho muc luong lon (int chi toi khoang 2,1 ty).
        public long MucLuong { get; }

        public int SoNgayVang { get; }

        public NhanVien(string? hoTen, long mucLuong, int soNgayVang)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                throw new ArgumentException("Ho ten khong duoc de trong", nameof(hoTen));

            if (mucLuong < 0)
                throw new ArgumentOutOfRangeException(nameof(mucLuong), "Muc luong khong duoc am");

            if (soNgayVang < 0 || soNgayVang > SoNgayVangToiDa)
                throw new ArgumentOutOfRangeException(nameof(soNgayVang), "So ngay vang phai tu 0 den 31");

            HoTen = hoTen.Trim();
            MucLuong = mucLuong;
            SoNgayVang = soNgayVang;
        }

        // Tong tien bi tru = so ngay vang x 100.000
        public long TinhTienTru()
        {
            return SoNgayVang * TienTruMotNgayVang;
        }

        // Luong thuc nhan = muc luong - tien bi tru
        public long TinhLuong()
        {
            long luong = MucLuong - TinhTienTru();

            // vang nhieu den muc tien tru vuot muc luong thi luong nhan duoc la 0,
            // khong de luong bi am
            if (luong < 0)
                return 0;

            return luong;
        }

        // Tra ve thong tin nhieu dong de Program in ra (lop khong tu in ra man hinh)
        public string LayThongTin()
        {
            return "Ho ten         : " + HoTen + Environment.NewLine +
                   "Muc luong      : " + DinhDangTien(MucLuong) + Environment.NewLine +
                   "So ngay vang   : " + SoNgayVang + Environment.NewLine +
                   "Tien bi tru    : " + DinhDangTien(TinhTienTru()) + Environment.NewLine +
                   "Luong thuc nhan: " + DinhDangTien(TinhLuong());
        }

        // Vi du 9800000 -> "9.800.000 VND"
        private static string DinhDangTien(long soTien)
        {
            return soTien.ToString("N0", dinhDangSo) + " VND";
        }
    }
}