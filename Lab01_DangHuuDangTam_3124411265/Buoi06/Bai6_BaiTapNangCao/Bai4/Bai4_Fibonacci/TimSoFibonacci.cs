namespace Bai4_Fibonacci
{
    public class TimSoFibonacci
    {
        // Tìm số Fibonacci lớn nhất nhưng nhỏ hơn n
        public int TimSo(int n)
        {
            // Hai số đầu tiên của dãy Fibonacci
            int f1 = 1;
            int f2 = 1;

            // Nếu n <= 1 thì không có số Fibonacci dương nào nhỏ hơn n
            if (n <= 1)
                return 0;

            while (f2 < n)
            {
                // Tính số Fibonacci tiếp theo
                int f3 = f1 + f2;

                // Nếu số tiếp theo >= n thì f2 là số cần tìm
                if (f3 >= n)
                    return f2;

                // Cập nhật để tính số Fibonacci tiếp theo
                f1 = f2;
                f2 = f3;
            }

            return f2;
        }
    }
}