namespace PhanTichThuaSo1
{
    public class PhanTichThuaSo
    {
        // Phân tích số n thành các thừa số nguyên tố
        // Ví dụ:
        // n = 100
        // 100 = 2^2 x 5^2
        public string PhanTich(int n)
        {
            string ketQua = "";
            bool dauTien = true;

            // Bắt đầu thử chia từ 2
            int i = 2;

            // Tiếp tục khi i * i <= n
            while (i * i <= n)
            {
                // Kiểm tra n có chia hết cho i không
                if (n % i == 0)
                {
                    int soMu = 0;

                    // Đếm số lần i xuất hiện trong phép phân tích
                    while (n % i == 0)
                    {
                        n /= i;
                        soMu++;
                    }

                    // Nếu không phải thừa số đầu tiên
                    // thì thêm dấu " x "
                    if (!dauTien)
                    {
                        ketQua += " x ";
                    }

                    // Nếu số mũ lớn hơn 1 thì hiển thị ^số mũ
                    if (soMu == 1)
                    {
                        ketQua += i.ToString();
                    }
                    else
                    {
                        ketQua += i + "^" + soMu;
                    }

                    dauTien = false;
                }

                // Thử thừa số tiếp theo
                i++;
            }

            // Nếu n > 1 thì n còn lại chính là một số nguyên tố
            if (n > 1)
            {
                if (!dauTien)
                {
                    ketQua += " x ";
                }

                ketQua += n.ToString();
            }

            return ketQua;
        }
    }
}