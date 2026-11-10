namespace NNLTCSharp.Buoi11
{
    // Bài toán: cộng hai số lớn được biểu diễn bằng mảng chữ số.
    // 
    // Ý tưởng thuật toán:
    //   Duyệt từ phải sang trái, cộng từng cặp chữ số cùng số nhớ,
    //   rồi lưu chữ số hàng đơn vị và cập nhật số nhớ cho lần lặp kế tiếp.
    public class CongSo
    {
        // Hàm Cong thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a; mảng đầu vào b.
        // Đầu ra: mảng số nguyên sau khi xử lý.
        public static int[] Cong(int[] a, int[] b)
        {
            int n = a.Length;
            int m = b.Length;

            int doDai = Math.Max(n, m) + 1;

            int[] ketQua = new int[doDai];

            int i = n - 1;
            int j = m - 1;
            int k = doDai - 1;

            int nho = 0;

            while (i >= 0 || j >= 0)
            {
                int tong = nho;

                if (i >= 0)
                {
                    tong += a[i];
                    i--;
                }

                if (j >= 0)
                {
                    tong += b[j];
                    j--;
                }

                ketQua[k] = tong % 10;
                nho = tong / 10;

                k--;
            }

            ketQua[k] = nho;

            // Nếu chữ số đầu là 0 thì bỏ đi
            if (ketQua[0] == 0)
            {
                int[] ketQuaCuoi = new int[doDai - 1];

                for (int x = 0; x < ketQuaCuoi.Length; x++)
                {
                    ketQuaCuoi[x] = ketQua[x + 1];
                }

                return ketQuaCuoi;
            }

            return ketQua;
        }
    }
}
