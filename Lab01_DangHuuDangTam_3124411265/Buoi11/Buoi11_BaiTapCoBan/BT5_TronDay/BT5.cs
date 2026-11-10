namespace NNLTCSharp.Buoi11
{
    // Bài toán: trộn hai dãy đã tăng dần thành một dãy tăng dần.
    // 
    // Ý tưởng thuật toán:
    //   So sánh phần tử đầu chưa dùng của hai dãy, chọn phần tử nhỏ hơn,
    //   rồi sao chép phần còn lại của dãy chưa duyệt hết.
    public class TronDay
    {
        // Hàm Tron thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a; mảng đầu vào b.
        // Đầu ra: mảng số nguyên sau khi xử lý.
        public static int[] Tron(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];

            int i = 0;
            int j = 0;
            int k = 0;

            // So sánh từng phần tử của A và B
            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    c[k] = a[i];
                    i++;
                }
                else
                {
                    c[k] = b[j];
                    j++;
                }

                k++;
            }

            // Nếu A vẫn còn phần tử
            while (i < a.Length)
            {
                c[k] = a[i];
                i++;
                k++;
            }

            // Nếu B vẫn còn phần tử
            while (j < b.Length)
            {
                c[k] = b[j];
                j++;
                k++;
            }

            return c;
        }
    }
}
