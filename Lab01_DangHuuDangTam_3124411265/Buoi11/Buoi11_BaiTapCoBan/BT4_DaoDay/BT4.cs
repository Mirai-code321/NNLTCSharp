namespace NNLTCSharp.Buoi11
{
    // Bài toán: đảo ngược thứ tự các phần tử trong mảng.
    // 
    // Ý tưởng thuật toán:
    //   Hoán đổi phần tử ở hai đầu mảng rồi dịch hai chỉ số dần vào giữa.
    public class DaoDay
    {
        // Hàm Dao thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a.
        // Đầu ra: mảng số nguyên sau khi xử lý.
        public static int[] Dao(int[] a)
        {
            int trai = 0;
            int phai = a.Length - 1;

            // Hoán đổi hai đầu mảng rồi thu hẹp dần vào giữa để đảo thứ tự.
            while (trai < phai)
            {
                int tam = a[trai];
                a[trai] = a[phai];
                a[phai] = tam;

                trai++;
                phai--;
            }

            return a;
        }
    }
}
