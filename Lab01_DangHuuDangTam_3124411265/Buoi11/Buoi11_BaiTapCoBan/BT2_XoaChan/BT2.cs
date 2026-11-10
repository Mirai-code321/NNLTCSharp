namespace NNLTCSharp.Buoi11
{
    // Bài toán: loại bỏ các số chẵn khỏi mảng.
    // 
    // Ý tưởng thuật toán:
    //   1. Đếm số phần tử lẻ để xác định kích thước mảng mới.
    //   2. Duyệt lại mảng và chỉ sao chép các số lẻ vào kết quả.
    public class XoaChan
    {
        // Hàm Xoa thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a.
        // Đầu ra: mảng số nguyên sau khi xử lý.
        public static int[] Xoa(int[] a)
        {
            int soPhanTuLe = 0;

            // Đếm số phần tử lẻ
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 != 0)
                {
                    soPhanTuLe++;
                }
            }

            // Tạo mảng mới chỉ chứa số lẻ
            int[] ketQua = new int[soPhanTuLe];

            int viTri = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 != 0)
                {
                    ketQua[viTri] = a[i];
                    viTri++;
                }
            }

            return ketQua;
        }
    }
}
