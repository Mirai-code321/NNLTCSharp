namespace KiemTraSoHoanHao
{
    public class SoHoanHao
    {
        // Kiểm tra n có phải là số hoàn hảo hay không
        public bool KiemTra(int n)
        {
            // Số hoàn hảo phải lớn hơn 1
            if (n <= 1)
            {
                return false;
            }

            int tong = 0;

            // Tìm các ước của n nhưng không tính chính nó
            for (int i = 1; i <= n / 2; i++)
            {
                // Nếu i là ước của n thì cộng vào tổng
                if (n % i == 0)
                {
                    tong += i;
                }
            }

            // Nếu tổng các ước bằng chính n
            // thì n là số hoàn hảo
            return tong == n;
        }

        // Lấy chuỗi các ước của n, không kể chính nó
        // Ví dụ: n = 6
        // Kết quả: "1 + 2 + 3"
        public string LayDanhSachUoc(int n)
        {
            string ketQua = "";
            bool laUocDauTien = true;

            // Các ước thực sự của n không lớn hơn n / 2
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    // Nếu không phải ước đầu tiên
                    // thì thêm dấu +
                    if (!laUocDauTien)
                    {
                        ketQua += " + ";
                    }

                    ketQua += i;

                    laUocDauTien = false;
                }
            }

            return ketQua;
        }

        // Tính tổng các ước không kể chính nó
        public int TongUoc(int n)
        {
            int tong = 0;

            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    tong += i;
                }
            }

            return tong;
        }
    }
}