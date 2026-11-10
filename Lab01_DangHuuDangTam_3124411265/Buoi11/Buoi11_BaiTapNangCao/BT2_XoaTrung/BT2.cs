namespace NNLTCSharp.Buoi11
{
    // Bài toán: loại bỏ các phần tử trùng lặp, giữ lại lần xuất hiện đầu tiên.
    // 
    // Ý tưởng thuật toán:
    //   Với mỗi phần tử, kiểm tra nó có trong phần kết quả đã tạo hay chưa.
    //   Chỉ thêm phần tử khi chưa tìm thấy giá trị trùng.
    public class XoaTrung
    {
        // Hàm Xoa thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a.
        // Đầu ra: mảng số nguyên sau khi xử lý.
        public static int[] Xoa(int[] a)
        {
            int[] ketQua = new int[a.Length];
            int soPhanTu = 0;

            for (int i = 0; i < a.Length; i++)
            {
                bool daCo = false;

                // Kiểm tra a[i] đã xuất hiện trong ketQua chưa
                for (int j = 0; j < soPhanTu; j++)
                {
                    if (a[i] == ketQua[j])
                    {
                        daCo = true;
                        break;
                    }
                }

                // Nếu chưa có thì thêm vào
                if (!daCo)
                {
                    ketQua[soPhanTu] = a[i];
                    soPhanTu++;
                }
            }

            // Tạo mảng đúng số phần tử
            int[] ketQuaCuoi = new int[soPhanTu];

            for (int i = 0; i < soPhanTu; i++)
            {
                ketQuaCuoi[i] = ketQua[i];
            }

            return ketQuaCuoi;
        }
    }
}
