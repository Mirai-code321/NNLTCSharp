namespace Bai13_SinhVien
{
    public class SinhVien
    {
        // Sinh vien hoc tu nam 1 den nam 6 (nganh y co the hoc 6 nam)
        public const int NamThuToiThieu = 1;
        public const int NamThuToiDa = 6;

        // Chi cho gan gia tri qua constructor (thuoc tinh chi co get), de moi doi tuong
        // tao ra luon hop le, khong ai sua thanh gia tri sai o ben ngoai duoc.
        public string MaSinhVien { get; }
        public string HoTen { get; }
        public string DiaChi { get; }
        public int NamThu { get; }

        public SinhVien(string? maSinhVien, string? hoTen, string? diaChi, int namThu)
        {
            // IsNullOrWhiteSpace bat ca null, rong va chuoi chi toan khoang trang
            if (string.IsNullOrWhiteSpace(maSinhVien))
                throw new ArgumentException("Ma sinh vien khong duoc de trong", nameof(maSinhVien));

            if (string.IsNullOrWhiteSpace(hoTen))
                throw new ArgumentException("Ho ten khong duoc de trong", nameof(hoTen));

            if (string.IsNullOrWhiteSpace(diaChi))
                throw new ArgumentException("Dia chi khong duoc de trong", nameof(diaChi));

            if (namThu < NamThuToiThieu || namThu > NamThuToiDa)
                throw new ArgumentOutOfRangeException(nameof(namThu), "Nam thu phai tu 1 den 6");

            // Trim de bo khoang trang thua o dau/cuoi khi nguoi dung go du
            MaSinhVien = maSinhVien.Trim();
            HoTen = hoTen.Trim();
            DiaChi = diaChi.Trim();
            NamThu = namThu;
        }

        // Tra ve thong tin dang chuoi nhieu dong de Program in ra.
        // Khong dung Console.WriteLine ngay trong lop nay de lop chi lo du lieu,
        // viec in ra man hinh la cua Program (cung de viet test cho de).
        public string LayThongTin()
        {
            return "Ma sinh vien: " + MaSinhVien + Environment.NewLine +
                   "Ho ten      : " + HoTen + Environment.NewLine +
                   "Dia chi     : " + DiaChi + Environment.NewLine +
                   "Nam thu     : " + NamThu;
        }
    }
}