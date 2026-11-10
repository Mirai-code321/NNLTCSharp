using System;
using System.Text;

namespace Bai6_BaiTapCoBan
{
    public class InChuIvaUService
    {
        /// <summary>
        /// Hàm sinh ra chuỗi hình chữ I và chữ U ghép lại với nhau
        /// </summary>
        /// <param name="h">Chiều cao nhập vào</param>
        /// <returns>Chuỗi ký tự hoàn chỉnh để in ra console</returns>
        public static string TaoHinhChuIvaU(int h)
        {
            // Kiểm tra điều kiện chiều cao h phải >= 3 mới đủ nét tạo chữ
            if (h < 3)
            {
                throw new ArgumentException("Chieu cao h phai lon hon hoac bang 3 de hinh thanh chu I va U.");
            }

            // Dùng StringBuilder giúp tối ưu hiệu năng khi nối chuỗi nhiều lần
            StringBuilder sb = new StringBuilder();

            // Vòng lặp chạy từ hàng 0 đến hàng thứ (h - 1)
            for (int i = 0; i < h; i++)
            {
                // ==========================================================
                // VẼ CHỮ I (Độ rộng 5 ký tự)
                // ==========================================================
                if (i == 0 || i == h - 1)
                {
                    // Nếu là hàng ĐẦU TIÊN (i=0) hoặc hàng CUỐI CÙNG (i=h-1):
                    // In nét gạch ngang trên/dưới của chữ I gồm 5 dấu '*'
                    sb.Append("* * * * *");
                }
                else
                {
                    // Nếu là các hàng Ở GIỮA:
                    // In 4 khoảng trắng + 1 dấu '*' ở giữa + 4 khoảng trắng để làm thân chữ I
                    sb.Append("    *    ");
                }

                // ==========================================================
                // KHOẢNG CÁCH GIỮA CHỮ I VÀ CHỮ U
                // ==========================================================
                // Thêm 2 khoảng trắng ngăn cách giữa 2 chữ cho đẹp
                sb.Append("  ");

                // ==========================================================
                // VẼ CHỮ U (Độ rộng 5 ký tự)
                // ==========================================================
                if (i == h - 1)
                {
                    // Nếu là hàng CUỐI CÙNG:
                    // In nét đáy chữ U gồm 5 dấu '*' nối liền nhau
                    sb.Append("* * * * *");
                }
                else
                {
                    // Nếu là các hàng TRÊN ĐÁY:
                    // In 1 dấu '*' bên trái + 7 khoảng trắng ở giữa + 1 dấu '*' bên phải
                    sb.Append("*       *");
                }

                // Xuống dòng sau khi hoàn thành 1 hàng của cả 2 chữ (trừ hàng cuối)
                if (i < h - 1)
                {
                    sb.AppendLine();
                }
            }

            // Chuyển đối tượng StringBuilder thành chuỗi string hoàn chỉnh
            return sb.ToString();
        }

        /// <summary>
        /// Hàm kiểm tra xem dữ liệu người dùng nhập vào có phải số hợp lệ >= 3 không
        /// </summary>
        public static bool KiemTraHHopLe(string? input, out int h)
        {
            // Ép kiểu chuỗi nhập sang số nguyên (int), trả về true nếu thành công
            bool parseThanhCong = int.TryParse(input, out h);

            // Chỉ trả về true khi ép kiểu thành công VÀ h >= 3
            return parseThanhCong && h >= 3;
        }
    }
}