using System;
using System.Collections.Generic;

namespace Bai3_BoBa
{
    public class BT3
    {
        // Hàm tìm các bộ ba giá trị a, b, c
        // thỏa mãn a = b + c
        // và a, b, c là ba giá trị khác nhau
        public static List<string> TimBoBa(double[] mang)
        {
            // Danh sách lưu các bộ ba tìm được
            List<string> ketQua = new List<string>();

            // Chọn giá trị a
            for (int i = 0; i < mang.Length; i++)
            {
                // Chọn giá trị b
                for (int j = 0; j < mang.Length; j++)
                {
                    // a và b phải là hai giá trị khác nhau
                    if (i == j || mang[i] == mang[j])
                    {
                        continue;
                    }

                    // Chọn giá trị c
                    for (int k = 0; k < mang.Length; k++)
                    {
                        // a, b, c phải là ba giá trị khác nhau
                        if (k == i || k == j)
                        {
                            continue;
                        }

                        if (mang[k] == mang[i] || mang[k] == mang[j])
                        {
                            continue;
                        }

                        // Kiểm tra điều kiện a = b + c
                        if (Math.Abs(mang[i] - (mang[j] + mang[k])) < 1e-10)
                        {
                            // Tạo chuỗi bộ ba
                            string boBa =
                                $"a = {mang[i]}, b = {mang[j]}, c = {mang[k]}";

                            // Tránh thêm trùng bộ ba
                            if (!ketQua.Contains(boBa))
                            {
                                ketQua.Add(boBa);
                            }
                        }
                    }
                }
            }

            // Trả về danh sách các bộ ba
            return ketQua;
        }


        // Hàm Main để nhập và xuất dữ liệu
        public static void Main(string[] args)
        {
            Console.WriteLine("===== BAI 3: BO BA =====");

            // Nhập số lượng phần tử
            Console.Write("Nhap n: ");
            int n = int.Parse(Console.ReadLine()!);

            // Kiểm tra điều kiện của đề
            // 3 < n < 500
            if (n <= 3 || n >= 500)
            {
                Console.WriteLine("n phai thoa man 3 < n < 500!");
                return;
            }

            // Khởi tạo mảng
            double[] mang = new double[n];

            // Nhập dãy số
            Console.WriteLine("Nhap day so:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}] = ");
                mang[i] = double.Parse(Console.ReadLine()!);
            }

            // Tìm các bộ ba
            List<string> ketQua = TimBoBa(mang);

            // Kiểm tra kết quả
            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay bo ba nao.");
            }
            else
            {
                Console.WriteLine("Cac bo ba thoa man a = b + c:");

                // Xuất từng bộ ba
                foreach (string boBa in ketQua)
                {
                    Console.WriteLine(boBa);
                }
            }
        }
    }
}