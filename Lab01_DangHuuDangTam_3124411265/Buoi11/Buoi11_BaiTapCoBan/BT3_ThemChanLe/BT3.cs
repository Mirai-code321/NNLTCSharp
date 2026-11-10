namespace NNLTCSharp.Buoi11
{
    // Bài toán: chèn một số lẻ giữa hai số chẵn liên tiếp.
    // 
    // Ý tưởng thuật toán:
    //   1. Đếm số cặp chẵn liên tiếp để tạo mảng kết quả đủ lớn.
    //   2. Sao chép từng phần tử và chèn thêm số lẻ sau mỗi cặp phù hợp.
    public class ThemChanLe
    {
        // Hàm Them thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a.
        // Đầu ra: mảng số nguyên sau khi xử lý.
        public static int[] Them(int[] a)
        {
            int soPhanTuThem = 0;

            // Đếm số lần cần thêm
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] % 2 == 0 && a[i + 1] % 2 == 0)
                {
                    soPhanTuThem++;
                }
            }

            // Tạo mảng mới
            int[] ketQua = new int[a.Length + soPhanTuThem];

            int viTri = 0;

            for (int i = 0; i < a.Length; i++)
            {
                // Đưa phần tử hiện tại vào mảng
                ketQua[viTri] = a[i];
                viTri++;

                // Nếu phần tử hiện tại và phần tử kế tiếp đều chẵn
                if (i < a.Length - 1 &&
                    a[i] % 2 == 0 &&
                    a[i + 1] % 2 == 0)
                {
                    // Thêm một số lẻ = số chẵn + 1
                    ketQua[viTri] = a[i] + 1;
                    viTri++;
                }
            }

            return ketQua;
        }
    }
}
