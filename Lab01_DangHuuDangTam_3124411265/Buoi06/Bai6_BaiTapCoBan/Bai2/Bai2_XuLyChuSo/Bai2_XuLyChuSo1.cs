namespace XuLyChuSo1
{
    public class XuLyChuSo
    {
        // Tìm chữ số thứ k tính từ trái sang phải
        public int LayChuSoThuK(int n, int k)
        {
            // Chuyển số thành chuỗi để lấy vị trí từ trái sang phải
            string chuoi = n.ToString();

            // Kiểm tra vị trí k có hợp lệ không
            if (k < 1 || k > chuoi.Length)
            {
                return -1;
            }

            // Vì vị trí trong chuỗi bắt đầu từ 0
            // nên vị trí k tương ứng với k - 1
            return chuoi[k - 1] - '0';
        }

        // Tính tổng các chữ số lẻ
        public int TongChuSoLe(int n)
        {
            int tong = 0;

            // Tách từng chữ số của n
            while (n > 0)
            {
                int chuSo = n % 10;

                // Nếu chữ số là số lẻ thì cộng vào tổng
                if (chuSo % 2 != 0)
                {
                    tong += chuSo;
                }

                // Bỏ chữ số cuối
                n /= 10;
            }

            return tong;
        }

        // Tìm chữ số lẻ nhỏ nhất và lớn nhất
        public void TimChuSoLeNhoNhatLonNhat(
            int n,
            out int nhoNhat,
            out int lonNhat)
        {
            nhoNhat = -1;
            lonNhat = -1;

            // Duyệt qua từng chữ số
            while (n > 0)
            {
                int chuSo = n % 10;

                // Chỉ xét chữ số lẻ
                if (chuSo % 2 != 0)
                {
                    // Nếu chưa có chữ số lẻ nào
                    if (nhoNhat == -1)
                    {
                        nhoNhat = chuSo;
                        lonNhat = chuSo;
                    }
                    else
                    {
                        // Tìm chữ số lẻ nhỏ nhất
                        if (chuSo < nhoNhat)
                        {
                            nhoNhat = chuSo;
                        }

                        // Tìm chữ số lẻ lớn nhất
                        if (chuSo > lonNhat)
                        {
                            lonNhat = chuSo;
                        }
                    }
                }

                // Bỏ chữ số cuối
                n /= 10;
            }
        }
    }
}