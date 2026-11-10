namespace NNLTCSharp.Buoi11
{
    // Bài toán: dịch vòng mảng sang trái k vị trí.
    // 
    // Ý tưởng thuật toán:
    //   Sao chép đoạn từ vị trí k đến cuối trước, rồi nối k phần tử đầu mảng vào sau.
    public class DiChuyen
    {
        // Hàm DiChuyenKPhanTu thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a; giá trị vị trí/số bước k.
        // Đầu ra: mảng số nguyên sau khi xử lý.
        public static int[] DiChuyenKPhanTu(int[] a, int k)
        {
            int[] ketQua = new int[a.Length];

            int viTri = 0;

            // Đưa các phần tử từ vị trí k đến cuối lên trước
            for (int i = k; i < a.Length; i++)
            {
                ketQua[viTri] = a[i];
                viTri++;
            }

            // Đưa k phần tử đầu xuống cuối
            for (int i = 0; i < k; i++)
            {
                ketQua[viTri] = a[i];
                viTri++;
            }

            return ketQua;
        }
    }
}
