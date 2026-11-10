namespace NNLTCSharp.Buoi11
{
    // Bài toán: sắp xếp tăng dần các số nguyên tố trong mảng.
    // 
    // Ý tưởng thuật toán:
    //   Sao chép mảng, chỉ so sánh và đổi chỗ hai phần tử nếu cả hai là số nguyên tố.
    //   Các phần tử không nguyên tố vì vậy vẫn giữ nguyên vị trí.
    public class SapNguyenTo
    {
        // Kiểm tra số nguyên tố
        // Hàm LaSoNguyenTo thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: giá trị n.
        // Đầu ra: true hoặc false theo điều kiện kiểm tra.
        public static bool LaSoNguyenTo(int n)
        {
            if (n < 2)
            {
                return false;
            }

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // Sắp xếp các số nguyên tố tăng dần
        // Hàm SapXep thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a.
        // Đầu ra: mảng số nguyên sau khi xử lý.
        public static int[] SapXep(int[] a)
        {
            int[] ketQua = new int[a.Length];

            // Sao chép mảng ban đầu
            for (int i = 0; i < a.Length; i++)
            {
                ketQua[i] = a[i];
            }

            // Chỉ sắp xếp những vị trí chứa số nguyên tố
            for (int i = 0; i < ketQua.Length - 1; i++)
            {
                if (!LaSoNguyenTo(ketQua[i]))
                {
                    continue;
                }

                for (int j = i + 1; j < ketQua.Length; j++)
                {
                    if (LaSoNguyenTo(ketQua[j]) &&
                        ketQua[i] > ketQua[j])
                    {
                        int tam = ketQua[i];
                        ketQua[i] = ketQua[j];
                        ketQua[j] = tam;
                    }
                }
            }

            return ketQua;
        }
    }
}
