namespace NNLTCSharp.Buoi11
{
    // Bài toán: sắp số chẵn tăng dần ở đầu mảng và số lẻ giảm dần ở cuối mảng.
    // 
    // Ý tưởng thuật toán:
    //   1. Tách lần lượt số chẵn và số lẻ vào mảng kết quả.
    //   2. Sắp xếp riêng đoạn số chẵn tăng dần và đoạn số lẻ giảm dần.
    public class SapChanLe
    {
        // Hàm SapXep thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a.
        // Đầu ra: mảng số nguyên sau khi xử lý.
        public static int[] SapXep(int[] a)
        {
            int[] ketQua = new int[a.Length];

            int viTri = 0;

            // Đưa số chẵn vào kết quả
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    ketQua[viTri] = a[i];
                    viTri++;
                }
            }

            // Đưa số lẻ vào kết quả
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 != 0)
                {
                    ketQua[viTri] = a[i];
                    viTri++;
                }
            }

            // Sắp xếp phần chẵn tăng dần
            int soChan = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                    soChan++;
            }

            for (int i = 0; i < soChan - 1; i++)
            {
                for (int j = i + 1; j < soChan; j++)
                {
                    if (ketQua[i] > ketQua[j])
                    {
                        int tam = ketQua[i];
                        ketQua[i] = ketQua[j];
                        ketQua[j] = tam;
                    }
                }
            }

            // Sắp xếp phần lẻ giảm dần
            for (int i = soChan; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (ketQua[i] < ketQua[j])
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
