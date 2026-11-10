namespace NNLTCSharp.Buoi11
{
    // Bài toán: chèn x vào dãy tăng dần có sẵn.
    // 
    // Ý tưởng thuật toán:
    //   Dịch sang phải mọi phần tử lớn hơn x, sau đó đặt x vào vị trí trống.
    public class NhapTang
    {
        // Hàm Nhap thực hiện phần xử lý tương ứng của bài toán.
        // Đầu vào: mảng đầu vào a; số phần tử đang có; giá trị x cần xử lý.
        // Đầu ra: mảng số thực sau khi xử lý.
        public static double[] Nhap(double[] a, int soPhanTu, double x)
        {
            int viTri = soPhanTu;

            // Tìm vị trí để chèn x
            while (viTri > 0 && a[viTri - 1] > x)
            {
                a[viTri] = a[viTri - 1];
                viTri--;
            }

            // Đưa x vào vị trí thích hợp
            a[viTri] = x;

            return a;
        }
    }
}
