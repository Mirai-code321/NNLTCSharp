using System;

namespace TinhDienTich
{
    public class TinhDienTichService
    {
       
        /// Tính diện tích tam giác theo công thức Heron: S = sqrt(p * (p-a) * (p-b) * (p-c))
   
        public static double TinhDienTichTamGiac(double a, double b, double c)
        {
            // Kiểm tra từng cạnh phải lớn hơn 0 và thỏa mãn bất đẳng thức tam giác (tổng 2 cạnh phải lớn hơn cạnh còn lại)
            if (a <= 0 || b <= 0 || c <= 0 || (a + b <= c) || (a + c <= b) || (b + c <= a))
            {
                throw new ArgumentException("Ba canh khong tao thanh mot tam giac hop le.");
            }

            // Tính nửa chu vi p
            double p = (a + b + c) / 2.0;

            // Tính diện tích theo công thức Heron
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        
        /// Tính diện tích hình chữ nhật: S = dài * rộng
     
        public static double TinhDienTichHinhChuNhat(double dai, double rong)
        {
            // Kiểm tra kích thước chiều dài và chiều rộng phải là số dương
            if (dai <= 0 || rong <= 0)
            {
                throw new ArgumentException("Chieu dai va chieu rong phai lon hon 0.");
            }

            // Trả về diện tích = dài * rộng
            return dai * rong;
        }

 
        /// Tính diện tích hình tròn: S = PI * r^2
   
        public static double TinhDienTichHinhTron(double r)
        {
            // Bán kính phải lớn hơn 0
            if (r <= 0)
            {
                throw new ArgumentException("Ban kinh phai lon hon 0.");
            }

            // Trả về diện tích = PI * r * r
            return Math.PI * r * r;
        }

   
        /// Kiểm tra lựa chọn từ menu có phải là số từ 1 đến 4 hay không
 
        public static bool KiemTraLoiChon(string? input, out int luaChon)
        {
            // Thử ép kiểu chuỗi nhập vào sang kiểu số nguyên int
            bool parseThanhCong = int.TryParse(input, out luaChon);

            // Trả về true nếu ép kiểu thành công và số đó nằm trong khoảng [1, 4]
            return parseThanhCong && luaChon >= 1 && luaChon <= 4;
        }
    }
}

